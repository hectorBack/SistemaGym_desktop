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
    public class MovimientoService : IMovimientoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<MovimientoCreateDto> _createValidator;
        private readonly IValidator<MovimientoUpdateDto> _updateValidator;

        public MovimientoService(
            IUnitOfWork unitOfWork,
            IValidator<MovimientoCreateDto> createValidator,
            IValidator<MovimientoUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
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
                UsuarioID = m.UsuarioID,
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
                UsuarioID = movimiento.UsuarioID,
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

            var nuevoMovimiento = new Movimiento
            {
                Tipo = dto.Tipo.Trim(),
                ConceptoID = dto.ConceptoID,
                FormaPago = dto.FormaPago.Trim(),
                Total = dto.Total,
                Observacion = dto.Observacion?.Trim(),
                CorteID = dto.CorteID,
                UsuarioID = dto.UsuarioID,
                Activo = true
            };

            await _unitOfWork.Movimiento.AgregarAsync(nuevoMovimiento);
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
                UsuarioID = m.UsuarioID,
                Activo = m.Activo,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt
            });
        }
    }
}
