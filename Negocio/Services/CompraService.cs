using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class CompraService : ICompraService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CompraCreateDto> _createValidator;

        public CompraService(
            IUnitOfWork unitOfWork,
            IValidator<CompraCreateDto> createValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
        }

        public async Task<IEnumerable<CompraDto>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var compras = await _unitOfWork.Compra.ObtenerTodasAsync(incluirInactivas);
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
                Estado = "Completada",
                Activo = true
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

            // 5. REGISTRAR EGRESO EN CAJA - ConceptoID 2 ('Compra Producto')
            if (totalCompra > 0)
            {
                // Obtiene el corte abierto o lo abre automáticamente si no existe
                var corteAbierto = await ObtenerOAbrirCorteAsync(dto.UsuarioID);

                var movimientoEgreso = new Movimiento
                {
                    CorteID = corteAbierto.CorteID,
                    UsuarioID = dto.UsuarioID,
                    ConceptoID = 2, // 2: 'Compra Producto' (Egreso)
                    Tipo = "Egreso",
                    FormaPago = string.IsNullOrWhiteSpace(dto.FormaPago) ? "Efectivo" : dto.FormaPago,
                    Total = totalCompra,
                    Observacion = $"Compra Folio: {nuevaCompra.Codigo}",
                    Activo = true
                };

                await _unitOfWork.Movimiento.AgregarAsync(movimientoEgreso);
            }

            // 6. Confirmar la transacción en la BD
            await _unitOfWork.SaveChangesAsync();

            return await MapearACompraDtoAsync(nuevaCompra);
        }

        public async Task CancelarCompraAsync(int id, int usuarioId, string? observacion = null)
        {
            var compra = await _unitOfWork.Compra.ObtenerPorIdAsync(id);
            if (compra == null)
            {
                throw new BusinessException("La compra que intenta cancelar no existe.");
            }

            if (compra.Estado == "Cancelada")
            {
                throw new BusinessException("La compra ya se encuentra cancelada.");
            }

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

            // 2. Cambiar estado de la compra
            compra.Estado = "Cancelada";
            compra.Activo = false;
            if (!string.IsNullOrWhiteSpace(observacion))
            {
                compra.Observacion = string.IsNullOrEmpty(compra.Observacion)
                    ? $"[CANCELADA]: {observacion}"
                    : $"{compra.Observacion} | [CANCELADA]: {observacion}";
            }

            _unitOfWork.Compra.Actualizar(compra);

            // 3. REGISTRAR INGRESO EN CAJA - ConceptoID 6 ('Cancelacion Compra Producto')
            if (compra.Total > 0)
            {
                // Obtiene el corte abierto o lo abre automáticamente si no existe
                var corteAbierto = await ObtenerOAbrirCorteAsync(usuarioId);

                var movimientoIngreso = new Movimiento
                {
                    CorteID = corteAbierto.CorteID,
                    UsuarioID = usuarioId,
                    ConceptoID = 6, // 6: 'Cancelacion Compra Producto' (Ingreso)
                    Tipo = "Ingreso",
                    FormaPago = "Efectivo",
                    Total = compra.Total,
                    Observacion = $"Cancelación de Compra Folio: {compra.Codigo}. {observacion?.Trim()}".Trim(),
                    Activo = true
                };

                await _unitOfWork.Movimiento.AgregarAsync(movimientoIngreso);
            }

            // 4. Confirmar en la BD
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var compra = await _unitOfWork.Compra.ObtenerPorIdAsync(id);
            if (compra == null)
            {
                throw new BusinessException("La compra a desactivar no existe.");
            }

            _unitOfWork.Compra.EliminarLogico(compra);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var compra = await _unitOfWork.Compra.ObtenerPorIdAsync(id);
            if (compra == null)
            {
                throw new BusinessException("La compra a eliminar no existe.");
            }

            _unitOfWork.Compra.EliminarFisico(compra);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> ObtenerSiguienteCodigoAsync()
        {
            return await _unitOfWork.Compra.GenerarSiguienteCodigoAsync();
        }

        private async Task<Corte> ObtenerOAbrirCorteAsync(int usuarioId)
        {
            var corteAbierto = await _unitOfWork.Corte.ObtenerCorteAbiertoPorUsuarioAsync(usuarioId);

            if (corteAbierto == null)
            {
                // 1. Consultar la configuración del Efectivo Inicial predeterminado
                var configEfectivo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("EfectivoInicial");
                decimal efectivoInicial = 0.00m;

                if (configEfectivo != null && decimal.TryParse(configEfectivo.Valor, out decimal monto))
                {
                    efectivoInicial = monto;
                }

                // 2. Crear automáticamente la caja para el usuario actual
                corteAbierto = new Corte
                {
                    UsuarioID = usuarioId,
                    FechaApertura = DateTime.Now,
                    MontoInicial = efectivoInicial,
                    TotalIngresos = 0m,
                    TotalEgresos = 0m,
                    MontoFinal = efectivoInicial,
                    Observaciones = "Apertura automática iniciada por movimiento de Compra",
                    Estado = "Abierto",
                    Activo = true
                };

                await _unitOfWork.Corte.AgregarAsync(corteAbierto);
                await _unitOfWork.SaveChangesAsync();
            }

            return corteAbierto;
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
                Estado = c.Estado,
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
