using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<MovimientoCreateDto> _createValidator;
        private readonly IValidator<MovimientoUpdateDto> _updateValidator;
        private readonly CajaHelper _caja;

        public MovimientoService(
            IUnitOfWork unitOfWork,
            IValidator<MovimientoCreateDto> createValidator,
            IValidator<MovimientoUpdateDto> updateValidator,
            CajaHelper caja)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _caja = caja;
        }

        public async Task<IEnumerable<MovimientoDto>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var movimientos = await _unitOfWork.Movimiento.ObtenerTodosAsync(incluirInactivos);

            return movimientos.Select(m => new MovimientoDto
            {
                MovimientoID = m.MovimientoID,
                Tipo = m.Tipo,
                ConceptoID = m.ConceptoID,
                ConceptoNombre = m.Concepto?.Nombre,
                FormaPago = m.FormaPago,
                Total = m.Total,
                Observacion = m.Observacion,
                CorteID = m.CorteID,
                FechaAperturaCorte = m.Corte?.FechaApertura,
                UsuarioID = m.UsuarioID,
                UsuarioNombre = m.Usuario?.NombreUsuario,
                Activo = m.Activo,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt
            });
        }

        public async Task<MovimientoDto?> ObtenerPorIdAsync(int id)
        {
            var movimiento = await _unitOfWork.Movimiento.ObtenerPorIdAsync(id);
            if (movimiento == null) return null;

            return new MovimientoDto
            {
                MovimientoID = movimiento.MovimientoID,
                Tipo = movimiento.Tipo,
                ConceptoID = movimiento.ConceptoID,
                ConceptoNombre = movimiento.Concepto?.Nombre,
                FormaPago = movimiento.FormaPago,
                Total = movimiento.Total,
                Observacion = movimiento.Observacion,
                CorteID = movimiento.CorteID,
                FechaAperturaCorte = movimiento.Corte?.FechaApertura,
                UsuarioID = movimiento.UsuarioID,
                UsuarioNombre = movimiento.Usuario?.NombreUsuario,
                Activo = movimiento.Activo,
                CreatedAt = movimiento.CreatedAt,
                UpdatedAt = movimiento.UpdatedAt
            };
        }

        public async Task<MovimientoDto> CrearAsync(MovimientoCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            int usuarioId = dto.UsuarioID ?? 0;

            // Validar que el DTO ya traiga el UsuarioID enviado desde la presentación
            if (usuarioId <= 0)
            {
                throw new BusinessException("No se encontró una sesión de usuario válida.");
            }

            // Corte abierto, o uno nuevo con el fondo configurado (se guarda junto con el movimiento).
            // Antes este servicio tenía su propia copia de la apertura: usaba una clave de configuración
            // incorrecta (fondo en 0) y la observación decía "venta de productos".
            var corteAbierto = await _caja.ObtenerOAbrirCorteAsync(usuarioId, "movimiento manual de caja");

            var nuevoMovimiento = await _caja.AgregarMovimientoAsync(
                corteAbierto, usuarioId, dto.ConceptoID, dto.Tipo.Trim(), dto.Total, dto.Observacion, dto.FormaPago);

            await _unitOfWork.SaveChangesAsync();

            return new MovimientoDto
            {
                MovimientoID = nuevoMovimiento.MovimientoID,
                Tipo = nuevoMovimiento.Tipo,
                ConceptoID = nuevoMovimiento.ConceptoID,
                FormaPago = nuevoMovimiento.FormaPago,
                Total = nuevoMovimiento.Total,
                Observacion = nuevoMovimiento.Observacion,
                CorteID = nuevoMovimiento.CorteID,
                UsuarioID = nuevoMovimiento.UsuarioID,
                Activo = nuevoMovimiento.Activo,
                CreatedAt = nuevoMovimiento.CreatedAt,
                UpdatedAt = nuevoMovimiento.UpdatedAt
            };
        }

        public async Task ActualizarAsync(MovimientoUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var movimiento = await _unitOfWork.Movimiento.ObtenerPorIdAsync(dto.MovimientoID);
            if (movimiento == null)
            {
                throw new BusinessException("El movimiento que intenta actualizar no existe.");
            }

            // Un movimiento de un corte ya cerrado no se modifica: cambiaría las cifras de un corte que ya se entregó.
            await ValidarCorteEditableAsync(movimiento.CorteID);
            if (dto.CorteID != movimiento.CorteID)
                await ValidarCorteEditableAsync(dto.CorteID);

            movimiento.Tipo = dto.Tipo.Trim();
            movimiento.ConceptoID = dto.ConceptoID;
            movimiento.FormaPago = dto.FormaPago.Trim();
            movimiento.Total = dto.Total;
            movimiento.Observacion = dto.Observacion?.Trim();
            movimiento.CorteID = dto.CorteID;
            movimiento.UsuarioID = dto.UsuarioID;
            movimiento.Activo = dto.Activo;

            _unitOfWork.Movimiento.Actualizar(movimiento);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var movimiento = await _unitOfWork.Movimiento.ObtenerPorIdAsync(id);
            if (movimiento == null)
            {
                throw new BusinessException("El movimiento a cambiar de estado no existe.");
            }

            await ValidarCorteEditableAsync(movimiento.CorteID);

            _unitOfWork.Movimiento.EliminarLogico(movimiento);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var movimiento = await _unitOfWork.Movimiento.ObtenerPorIdAsync(id);
            if (movimiento == null)
            {
                throw new BusinessException("El movimiento a eliminar no existe.");
            }

            await ValidarCorteEditableAsync(movimiento.CorteID);

            // 1. Si es un movimiento de Visita, buscamos directamente por la relación exacta
            if (movimiento.ConceptoID == CajaConstantes.ConceptoVisita)
            {
                var visitas = await _unitOfWork.Visita.ObtenerTodasAsync();
                var visitaAsociada = visitas.FirstOrDefault(v => v.MovimientoID == movimiento.MovimientoID);
                if (visitaAsociada != null)
                {
                    _unitOfWork.Visita.EliminarFisico(visitaAsociada);
                }
            }
            // 2. Si es una Venta de Producto
            else if (movimiento.ConceptoID == CajaConstantes.ConceptoVenta)
            {
                var ventas = await _unitOfWork.Venta.ObtenerTodasAsync(); // O un método específico por MovimientoID si lo creas en el repositorio
                var ventaAsociada = ventas.FirstOrDefault(v => v.MovimientoID == movimiento.MovimientoID);
                if (ventaAsociada != null)
                {
                    if (ventaAsociada.Detalles != null)
                    {
                        foreach (var detalle in ventaAsociada.Detalles)
                        {
                            var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(detalle.ProductoID);
                            if (producto != null)
                            {
                                producto.Stock += detalle.Cantidad; // Devolvemos stock
                                _unitOfWork.Producto.Actualizar(producto);
                            }
                        }
                    }
                    _unitOfWork.Venta.EliminarFisico(ventaAsociada);
                }
            }
            // 3. Si es una Compra de Producto
            else if (movimiento.ConceptoID == CajaConstantes.ConceptoCompra)
            {
                var compras = await _unitOfWork.Compra.ObtenerTodasAsync();
                var compraAsociada = compras.FirstOrDefault(c => c.MovimientoID == movimiento.MovimientoID);
                if (compraAsociada != null)
                {
                    if (compraAsociada.Detalles != null)
                    {
                        foreach (var detalle in compraAsociada.Detalles)
                        {
                            var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(detalle.ProductoID);
                            if (producto != null)
                            {
                                producto.Stock -= detalle.Cantidad; // Restamos stock
                                _unitOfWork.Producto.Actualizar(producto);
                            }
                        }
                    }
                    _unitOfWork.Compra.EliminarFisico(compraAsociada);
                }
            }

            // 4. Si el movimiento corresponde a un Pago de Membresía
            else if (movimiento.ConceptoID == CajaConstantes.ConceptoPagoMembresia)
            {
                var pagos = await _unitOfWork.PagoSocioMembresia.ObtenerTodasAsync(true);
                var pagoAsociado = pagos.FirstOrDefault(p => p.MovimientoID == movimiento.MovimientoID);
                if (pagoAsociado != null)
                {
                    _unitOfWork.PagoSocioMembresia.EliminarFisico(pagoAsociado);
                }
            }

            // Finalmente eliminamos el movimiento de caja
            _unitOfWork.Movimiento.EliminarFisico(movimiento);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<IEnumerable<MovimientoDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var movimientos = await _unitOfWork.Movimiento.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);

            return movimientos.Select(m => new MovimientoDto
            {
                MovimientoID = m.MovimientoID,
                Tipo = m.Tipo,
                ConceptoID = m.ConceptoID,
                ConceptoNombre = m.Concepto?.Nombre,
                FormaPago = m.FormaPago,
                Total = m.Total,
                Observacion = m.Observacion,
                CorteID = m.CorteID,
                FechaAperturaCorte = m.Corte?.FechaApertura,
                UsuarioID = m.UsuarioID,
                UsuarioNombre = m.Usuario?.NombreUsuario,
                Activo = m.Activo,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt
            });
        }

        private async Task ValidarCorteEditableAsync(int? corteId)
        {
            if (!corteId.HasValue) return;

            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(corteId.Value);
            if (corte != null && corte.Estado == CajaConstantes.EstadoCerrado)
                throw new BusinessException("El movimiento pertenece a un corte de caja ya cerrado y no puede modificarse.");
        }
    }
}
