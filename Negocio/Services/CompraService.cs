using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using Presentacion.Helpers;

namespace Negocio.Services
{
    public class CompraService : ICompraService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CompraCreateDto> _createValidator;
        private readonly CajaHelper _caja;

        public CompraService(
            IUnitOfWork unitOfWork,
            IValidator<CompraCreateDto> createValidator,
            CajaHelper caja)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _caja = caja;
        }

        public async Task<IEnumerable<CompraDto>> ObtenerTodasAsync(string? estadoFiltro = "Activo")
        {
            var compras = await _unitOfWork.Compra.ObtenerTodasAsync(estadoFiltro);
            var dtos = new List<CompraDto>();

            foreach (var compra in compras)
            {
                dtos.Add(await MapearACompraDtoAsync(compra));
            }

            return dtos;
        }

        public async Task<CompraDto?> ObtenerPorIdAsync(int id)
        {
            var compra = await _unitOfWork.Compra.ObtenerPorIdAsync(id);
            return compra == null ? null : await MapearACompraDtoAsync(compra);
        }

        public async Task<CompraDto?> ObtenerPorCodigoAsync(string codigo)
        {
            var compra = await _unitOfWork.Compra.ObtenerPorCodigoAsync(codigo);
            return compra == null ? null : await MapearACompraDtoAsync(compra);
        }

        public async Task<IEnumerable<CompraDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var compras = await _unitOfWork.Compra.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);
            var dtos = new List<CompraDto>();

            foreach (var compra in compras)
            {
                dtos.Add(await MapearACompraDtoAsync(compra));
            }

            return dtos;
        }

        // Listado del módulo: no carga las líneas ni consulta productos (el detalle se pide aparte al abrir una compra).
        public async Task<IEnumerable<CompraDto>> ObtenerResumenPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var compras = await _unitOfWork.Compra.ObtenerResumenPorRangoFechasAsync(fechaInicio, fechaFin);

            return compras.Select(c => new CompraDto
            {
                CompraID = c.CompraID,
                Codigo = c.Codigo,
                Total = c.Total,
                Observacion = c.Observacion,
                UsuarioID = c.UsuarioID,
                Activo = c.Activo,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                Detalles = new List<DetalleCompraDto>()
            }).ToList();
        }

        public async Task<CompraDto> CrearAsync(CompraCreateDto dto)
        {
            // 1. Validar DTO con FluentValidation
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            // 2. Validar duplicidad de código/folio
            if (await _unitOfWork.Compra.ExisteCodigoAsync(dto.Codigo))
            {
                throw new BusinessException($"Ya existe una compra registrada con el código o folio '{dto.Codigo}'.");
            }

            // 3. Crear la entidad Compra y sus Detalles
            decimal totalCompra = 0;
            var nuevaCompra = new Compra
            {
                Codigo = dto.Codigo.Trim(),
                Observacion = dto.Observacion?.Trim(),
                UsuarioID = dto.UsuarioID,
                FormaPago = dto.FormaPago,
                Estado = "Activo",
                Activo = true,
            };

            foreach (var item in dto.Detalles)
            {
                // Verificar que el producto exista
                var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(item.ProductoID);
                if (producto == null)
                {
                    throw new BusinessException($"El producto con ID {item.ProductoID} no existe.");
                }

                // Incrementar stock en la entidad del producto
                producto.Stock += item.Cantidad;
                _unitOfWork.Producto.Actualizar(producto);

                // Calcular subtotal acumulado
                decimal subtotal = item.Cantidad * item.CostoUnitario;
                totalCompra += subtotal;

                // Agregar línea de detalle
                nuevaCompra.Detalles.Add(new DetalleCompra
                {
                    ProductoID = item.ProductoID,
                    Cantidad = item.Cantidad,
                    CostoUnitario = item.CostoUnitario,
                    Activo = true
                });
            }

            nuevaCompra.Total = totalCompra;

            // 4. Guardar Compra
            await _unitOfWork.Compra.AgregarAsync(nuevaCompra);

            // 5. REGISTRAR EGRESO EN CAJA - 'Compra Producto'
            if (totalCompra > 0)
            {
                // Corte abierto del usuario, o sin corte si no tiene uno (no se abre ninguno).
                var nuevoMovimiento = await _caja.RegistrarMovimientoAsync(dto.UsuarioID, CajaConstantes.ConceptoCompra, CajaConstantes.TipoEgreso,
                    totalCompra, string.Empty, dto.FormaPago);

                // Enlazamos la compra con el movimiento financiero exacto
                nuevaCompra.Movimiento = nuevoMovimiento;
            }

            // 6. Confirmar la transacción en la BD
            await _unitOfWork.SaveChangesAsync();

            return await MapearACompraDtoAsync(nuevaCompra);
        }

        public async Task CancelarCompraAsync(int id, int usuarioId, string? motivo = null)
        {
            var compra = await _unitOfWork.Compra.ObtenerPorIdAsync(id);
            if (compra == null)
            {
                throw new BusinessException("La compra que intenta cancelar no existe.");
            }

            if (!compra.Activo)
            {
                throw new BusinessException("La compra ya se encuentra anulada.");
            }

            // Se guardan antes de modificar la compra, igual que en la venta.
            decimal montoDevuelto = compra.Total;
            string formaPagoOriginal = compra.FormaPago;

            // 1. Revertir el stock acumulado de cada producto
            foreach (var detalle in compra.Detalles)
            {
                var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(detalle.ProductoID);
                if (producto != null)
                {
                    if (producto.Stock < detalle.Cantidad)
                    {
                        throw new BusinessException($"No se puede cancelar la compra porque el producto '{producto.Nombre}' no cuenta con stock suficiente para descontar.");
                    }

                    producto.Stock -= detalle.Cantidad;
                    _unitOfWork.Producto.Actualizar(producto);
                }
            }

            _unitOfWork.Compra.MarcarComoInactivo(compra);

            // 3. REGISTRAR INGRESO EN CAJA - 'Cancelacion Compra Producto'
            if (montoDevuelto > 0)
            {
                await _caja.RegistrarMovimientoAsync(
                    usuarioId, CajaConstantes.ConceptoCancelacionCompra, CajaConstantes.TipoIngreso,
                    montoDevuelto, string.Empty, formaPagoOriginal);
            }

            // 4. Confirmar en la BD
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id, int usuarioId)
        {
            var compra = await _unitOfWork.Compra.ObtenerPorIdAsync(id);
            if (compra == null)
            {
                throw new BusinessException("La compra a eliminar no existe.");
            }

            // Si la compra sigue vigente, se deshace su efecto: stock y movimiento de caja.
            // Si ya estaba cancelada, el egreso y su cancelación se compensan y el stock ya se revirtió.
            if (compra.Activo && compra.Estado != "Inactivo")
            {
                var movimiento = compra.MovimientoID.HasValue
                    ? await _unitOfWork.Movimiento.ObtenerPorIdAsync(compra.MovimientoID.Value)
                    : null;

                if (movimiento?.CorteID != null)
                {
                    throw new BusinessException("Esta compra ya forma parte de un corte de caja y no se puede eliminar. Para corregirla usa 'Cancelar'.");
                }

                // Restar el stock que sumó la compra
                foreach (var detalle in compra.Detalles)
                {
                    var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(detalle.ProductoID);
                    if (producto != null)
                    {
                        if (producto.Stock < detalle.Cantidad)
                        {
                            throw new BusinessException($"No se puede eliminar la compra porque el producto '{producto.Nombre}' no cuenta con stock suficiente para descontar.");
                        }

                        producto.Stock -= detalle.Cantidad;
                        _unitOfWork.Producto.Actualizar(producto);
                    }
                }

                if (movimiento != null)
                {
                    _unitOfWork.Movimiento.EliminarLogico(movimiento); // se desactiva (no se borra): deja de contar en caja
                }
            }

            // Aplicar el Soft Delete definitivo (estado "Eliminado")
            _unitOfWork.Compra.MarcarComoEliminado(compra);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> ObtenerSiguienteCodigoAsync()
        {
            return await _unitOfWork.Compra.GenerarSiguienteCodigoAsync();
        }

        #region Métodos Privados Auxiliares
        private async Task<CompraDto> MapearACompraDtoAsync(Compra c)
        {
            var detallesDto = new List<DetalleCompraDto>();

            foreach (var d in c.Detalles)
            {
                // Consultar producto por ID para obtener el nombre y código de barras
                var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(d.ProductoID);

                if (producto != null)
                {
                    // Asignar en las propiedades [NotMapped] de la entidad
                    d.CodigoBarras = producto.CodigoBarras;
                    d.ProductoNombre = producto.Nombre;
                }

                detallesDto.Add(new DetalleCompraDto
                {
                    DetalleCompraID = d.DetalleCompraID,
                    CompraID = d.CompraID,
                    ProductoID = d.ProductoID,
                    CodigoBarras = d.CodigoBarras ?? string.Empty,
                    ProductoNombre = d.ProductoNombre ?? string.Empty,
                    Cantidad = d.Cantidad,
                    CostoUnitario = d.CostoUnitario,
                    Activo = d.Activo,
                    CreatedAt = d.CreatedAt,
                    UpdatedAt = d.UpdatedAt
                });
            }

            return new CompraDto
            {
                CompraID = c.CompraID,
                Codigo = c.Codigo,
                Total = c.Total,
                Observacion = c.Observacion,
                UsuarioID = c.UsuarioID,
                Activo = c.Activo,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                Detalles = detallesDto
            };
        }
        #endregion
    }
}
