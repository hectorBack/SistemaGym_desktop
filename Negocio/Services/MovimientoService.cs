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

        // Movimientos que generan otros módulos: su estado lo controla ese módulo, no Movimientos.
        private static readonly int[] ConceptosDeOtrosModulos =
        {
            CajaConstantes.ConceptoVisita, CajaConstantes.ConceptoVenta,
            CajaConstantes.ConceptoCompra, CajaConstantes.ConceptoPagoMembresia
        };

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
                FechaCierreCorte = m.Corte?.FechaCierre,
                UsuarioID = m.UsuarioID,
                UsuarioNombre = m.Usuario?.NombreCompleto,
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
                FechaCierreCorte = movimiento.Corte?.FechaCierre,
                UsuarioID = movimiento.UsuarioID,
                UsuarioNombre = movimiento.Usuario?.NombreCompleto,
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

            // Corte abierto del usuario, o sin corte si no tiene uno (no se abre ninguno).
            var nuevoMovimiento = await _caja.RegistrarMovimientoAsync(
                usuarioId, dto.ConceptoID, dto.Tipo.Trim(), dto.Total, dto.Observacion, dto.FormaPago);

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

            movimiento.Tipo = dto.Tipo.Trim();
            movimiento.ConceptoID = dto.ConceptoID;
            movimiento.FormaPago = dto.FormaPago.Trim();
            movimiento.Total = dto.Total;
            movimiento.Observacion = dto.Observacion?.Trim();

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

            if (ConceptosDeOtrosModulos.Contains(movimiento.ConceptoID))
            {
                throw new BusinessException("Este movimiento lo generó una visita, venta, compra o pago de membresía. Su estado se cambia desde su módulo.");
            }

            _unitOfWork.Movimiento.EliminarLogico(movimiento);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var movimiento = await _unitOfWork.Movimiento.ObtenerPorIdAsync(id);
            if (movimiento == null)
            {
                throw new BusinessException("El movimiento a eliminar no existe.");
            }

            await ValidarCorteEditableAsync(movimiento.CorteID);

            // Un movimiento vigente de otro módulo se elimina desde ese módulo (ahí se revierte stock, vigencia, etc.).
            if (movimiento.Activo && ConceptosDeOtrosModulos.Contains(movimiento.ConceptoID))
            {
                throw new BusinessException("Este movimiento lo generó una visita, venta, compra o pago de membresía. Cancélelo o elimínelo desde su módulo.");
            }

            _unitOfWork.Movimiento.MarcarComoEliminado(movimiento);
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
                FechaCierreCorte = m.Corte?.FechaCierre,
                UsuarioID = m.UsuarioID,
                UsuarioNombre = m.Usuario?.NombreCompleto,
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
