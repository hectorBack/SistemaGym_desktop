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
    public class ConceptoService : IConceptoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ConceptoCreateDto> _createValidator;
        private readonly IValidator<ConceptoUpdateDto> _updateValidator;

        public ConceptoService(
            IUnitOfWork unitOfWork,
            IValidator<ConceptoCreateDto> createValidator,
            IValidator<ConceptoUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<ConceptoDto>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var conceptos = await _unitOfWork.Concepto.ObtenerTodosAsync(incluirInactivos);

            return conceptos.Select(c => new ConceptoDto
            {
                ConceptoID = c.ConceptoID,
                Nombre = c.Nombre,
                Tipo = c.Tipo,
                Observacion = c.Observacion,
                EsSistema = c.EsSistema,
                Activo = c.Activo,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            });
        }

        public async Task<ConceptoDto?> ObtenerPorIdAsync(int id)
        {
            var concepto = await _unitOfWork.Concepto.ObtenerPorIdAsync(id);
            if (concepto == null) return null;

            return new ConceptoDto
            {
                ConceptoID = concepto.ConceptoID,
                Nombre = concepto.Nombre,
                Tipo = concepto.Tipo,
                Observacion = concepto.Observacion,
                EsSistema = concepto.EsSistema,
                Activo = concepto.Activo,
                CreatedAt = concepto.CreatedAt,
                UpdatedAt = concepto.UpdatedAt
            };
        }

        public async Task<ConceptoDto> CrearAsync(ConceptoCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            if (await _unitOfWork.Concepto.ExisteNombreAsync(dto.Nombre))
            {
                throw new BusinessException($"Ya existe un concepto registrado con el nombre '{dto.Nombre}'.");
            }

            var nuevoConcepto = new Concepto
            {
                Nombre = dto.Nombre.Trim(),
                Tipo = dto.Tipo.Trim(),
                Observacion = string.IsNullOrWhiteSpace(dto.Observacion) ? null : dto.Observacion.Trim(),
                Activo = true
            };

            await _unitOfWork.Concepto.AgregarAsync(nuevoConcepto);
            await _unitOfWork.SaveChangesAsync();

            return new ConceptoDto
            {
                ConceptoID = nuevoConcepto.ConceptoID,
                Nombre = nuevoConcepto.Nombre,
                Tipo = nuevoConcepto.Tipo,
                Observacion = nuevoConcepto.Observacion,
                Activo = nuevoConcepto.Activo,
                CreatedAt = nuevoConcepto.CreatedAt,
                UpdatedAt = nuevoConcepto.UpdatedAt
            };
        }

        public async Task ActualizarAsync(ConceptoUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var concepto = await _unitOfWork.Concepto.ObtenerPorIdAsync(dto.ConceptoID);
            if (concepto == null)
            {
                throw new BusinessException("El concepto que intenta actualizar no existe.");
            }

            if (await _unitOfWork.Concepto.ExisteNombreAsync(dto.Nombre, dto.ConceptoID))
            {
                throw new BusinessException($"Ya existe otro concepto con el nombre '{dto.Nombre}'.");
            }

            concepto.Nombre = dto.Nombre.Trim();
            concepto.Tipo = dto.Tipo.Trim();
            concepto.Observacion = string.IsNullOrWhiteSpace(dto.Observacion) ? null : dto.Observacion.Trim();
            concepto.Activo = dto.Activo;

            _unitOfWork.Concepto.Actualizar(concepto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var concepto = await _unitOfWork.Concepto.ObtenerPorIdAsync(id);
            if (concepto == null)
            {
                throw new BusinessException("El concepto a desactivar no existe.");
            }

            _unitOfWork.Concepto.EliminarLogico(concepto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var concepto = await _unitOfWork.Concepto.ObtenerPorIdAsync(id);
            if (concepto == null)
            {
                throw new BusinessException("El concepto a eliminar no existe.");
            }

            _unitOfWork.Concepto.EliminarFisico(concepto);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
