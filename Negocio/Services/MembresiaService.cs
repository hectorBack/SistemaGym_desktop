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
    public class MembresiaService : IMembresiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<MembresiaCreateDto> _createValidator;
        private readonly IValidator<MembresiaUpdateDto> _updateValidator;

        public MembresiaService(
            IUnitOfWork unitOfWork,
            IValidator<MembresiaCreateDto> createValidator,
            IValidator<MembresiaUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<MembresiaDto>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var membresias = await _unitOfWork.Membresia.ObtenerTodasAsync(incluirInactivas);

            return membresias.Select(m => new MembresiaDto
            {
                MembresiaID = m.MembresiaID,
                Nombre = m.Nombre,
                Precio = m.Precio,
                DuracionDias = m.DuracionDias,
                Activo = m.Activo,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt
            });
        }

        public async Task<MembresiaDto?> ObtenerPorIdAsync(int id)
        {
            var membresia = await _unitOfWork.Membresia.ObtenerPorIdAsync(id);
            if (membresia == null) return null;

            return new MembresiaDto
            {
                MembresiaID = membresia.MembresiaID,
                Nombre = membresia.Nombre,
                Precio = membresia.Precio,
                DuracionDias = membresia.DuracionDias,
                Activo = membresia.Activo,
                CreatedAt = membresia.CreatedAt,
                UpdatedAt = membresia.UpdatedAt
            };
        }

        public async Task<MembresiaDto> CrearAsync(MembresiaCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            if (await _unitOfWork.Membresia.ExisteNombreAsync(dto.Nombre))
            {
                throw new BusinessException($"Ya existe una membresía registrada con el nombre '{dto.Nombre}'.");
            }

            var nuevaMembresia = new Membresia
            {
                Nombre = dto.Nombre.Trim(),
                Precio = dto.Precio,
                DuracionDias = dto.DuracionDias,
                Activo = true
            };

            await _unitOfWork.Membresia.AgregarAsync(nuevaMembresia);
            await _unitOfWork.SaveChangesAsync();

            return new MembresiaDto
            {
                MembresiaID = nuevaMembresia.MembresiaID,
                Nombre = nuevaMembresia.Nombre,
                Precio = nuevaMembresia.Precio,
                DuracionDias = nuevaMembresia.DuracionDias,
                Activo = nuevaMembresia.Activo,
                CreatedAt = nuevaMembresia.CreatedAt,
                UpdatedAt = nuevaMembresia.UpdatedAt
            };
        }

        public async Task ActualizarAsync(MembresiaUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var membresia = await _unitOfWork.Membresia.ObtenerPorIdAsync(dto.MembresiaID);
            if (membresia == null)
            {
                throw new BusinessException("La membresía que intenta actualizar no existe.");
            }

            if (await _unitOfWork.Membresia.ExisteNombreAsync(dto.Nombre, dto.MembresiaID))
            {
                throw new BusinessException($"Ya existe otra membresía con el nombre '{dto.Nombre}'.");
            }

            membresia.Nombre = dto.Nombre.Trim();
            membresia.Precio = dto.Precio;
            membresia.DuracionDias = dto.DuracionDias;
            membresia.Activo = dto.Activo;

            _unitOfWork.Membresia.Actualizar(membresia);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var membresia = await _unitOfWork.Membresia.ObtenerPorIdAsync(id);
            if (membresia == null)
            {
                throw new BusinessException("La membresía a cambiar de estado no existe.");
            }

            _unitOfWork.Membresia.EliminarLogico(membresia);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var membresia = await _unitOfWork.Membresia.ObtenerPorIdAsync(id);
            if (membresia == null)
            {
                throw new BusinessException("La membresía a eliminar no existe.");
            }

            _unitOfWork.Membresia.EliminarFisico(membresia);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
