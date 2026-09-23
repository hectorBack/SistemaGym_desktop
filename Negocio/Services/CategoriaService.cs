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
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CategoriaCreateDto> _createValidator;
        private readonly IValidator<CategoriaUpdateDto> _updateValidator;

        public CategoriaService(
            IUnitOfWork unitOfWork,
            IValidator<CategoriaCreateDto> createValidator,
            IValidator<CategoriaUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<CategoriaDto>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var categorias = await _unitOfWork.Categorias.ObtenerTodasAsync(incluirInactivas);

            return categorias.Select(c => new CategoriaDto
            {
                CategoriaID = c.CategoriaID,
                Nombre = c.Nombre,
                Activo = c.Activo,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            });
        }

        public async Task<CategoriaDto?> ObtenerPorIdAsync(int id)
        {
            var categoria = await _unitOfWork.Categorias.ObtenerPorIdAsync(id);
            if (categoria == null) return null;

            return new CategoriaDto
            {
                CategoriaID = categoria.CategoriaID,
                Nombre = categoria.Nombre,
                Activo = categoria.Activo,
                CreatedAt = categoria.CreatedAt,
                UpdatedAt = categoria.UpdatedAt
            };
        }

        public async Task<CategoriaDto> CrearAsync(CategoriaCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            if (await _unitOfWork.Categorias.ExisteNombreAsync(dto.Nombre))
            {
                throw new BusinessException($"Ya existe una categoría registrada con el nombre '{dto.Nombre}'.");
            }

            var nuevaCategoria = new Categoria
            {
                Nombre = dto.Nombre.Trim(),
                Activo = true
            };

            await _unitOfWork.Categorias.AgregarAsync(nuevaCategoria);
            await _unitOfWork.SaveChangesAsync();

            return new CategoriaDto
            {
                CategoriaID = nuevaCategoria.CategoriaID,
                Nombre = nuevaCategoria.Nombre,
                Activo = nuevaCategoria.Activo,
                CreatedAt = nuevaCategoria.CreatedAt,
                UpdatedAt = nuevaCategoria.UpdatedAt
            };
        }

        public async Task ActualizarAsync(CategoriaUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var categoria = await _unitOfWork.Categorias.ObtenerPorIdAsync(dto.CategoriaID);
            if (categoria == null)
            {
                throw new BusinessException("La categoría que intenta actualizar no existe.");
            }

            if (await _unitOfWork.Categorias.ExisteNombreAsync(dto.Nombre, dto.CategoriaID))
            {
                throw new BusinessException($"Ya existe otra categoría con el nombre '{dto.Nombre}'.");
            }

            categoria.Nombre = dto.Nombre.Trim();
            categoria.Activo = dto.Activo;

            _unitOfWork.Categorias.Actualizar(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var categoria = await _unitOfWork.Categorias.ObtenerPorIdAsync(id);
            if (categoria == null)
            {
                throw new BusinessException("La categoría a desactivar no existe.");
            }

            _unitOfWork.Categorias.EliminarLogico(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var categoria = await _unitOfWork.Categorias.ObtenerPorIdAsync(id);
            if (categoria == null)
            {
                throw new BusinessException("La categoría a eliminar no existe.");
            }

            // Aquí se puede añadir validación si la categoría contiene productos vinculados antes de eliminar físicamente

            _unitOfWork.Categorias.EliminarFisico(categoria);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
