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
using System.Text.Json;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class RolService : IRolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<RolCreateDto> _createValidator;
        private readonly IValidator<RolUpdateDto> _updateValidator;

        public RolService(
            IUnitOfWork unitOfWork,
            IValidator<RolCreateDto> createValidator,
            IValidator<RolUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<RolDto>> ObtenerTodasAsync(bool incluirInactivos = false)
        {
            var roles = await _unitOfWork.Rol.ObtenerTodasAsync(incluirInactivos);

            return roles.Select(r => new RolDto
            {
                RolID = r.RolID,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                ModulosPermitidos = DeserializarModulos(r.ModulosPermitidos),
                Activo = r.Activo,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            });
        }

        public async Task<RolDto?> ObtenerPorIdAsync(int id)
        {
            var rol = await _unitOfWork.Rol.ObtenerPorIdAsync(id);
            if (rol == null) return null;

            return new RolDto
            {
                RolID = rol.RolID,
                Nombre = rol.Nombre,
                Descripcion = rol.Descripcion,
                ModulosPermitidos = DeserializarModulos(rol.ModulosPermitidos),
                Activo = rol.Activo,
                CreatedAt = rol.CreatedAt,
                UpdatedAt = rol.UpdatedAt
            };
        }

        public async Task<RolDto> CrearAsync(RolCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            if (await _unitOfWork.Rol.ExisteNombreAsync(dto.Nombre))
            {
                throw new BusinessException($"Ya existe un rol registrado con el nombre '{dto.Nombre}'.");
            }

            var nuevoRol = new Rol
            {
                Nombre = dto.Nombre.Trim(),
                Descripcion = dto.Descripcion?.Trim(),
                ModulosPermitidos = JsonSerializer.Serialize(dto.ModulosPermitidos ?? new List<string>()),
                Activo = true
            };

            await _unitOfWork.Rol.AgregarAsync(nuevoRol);
            await _unitOfWork.SaveChangesAsync();

            return new RolDto
            {
                RolID = nuevoRol.RolID,
                Nombre = nuevoRol.Nombre,
                Descripcion = nuevoRol.Descripcion,
                ModulosPermitidos = DeserializarModulos(nuevoRol.ModulosPermitidos),
                Activo = nuevoRol.Activo,
                CreatedAt = nuevoRol.CreatedAt,
                UpdatedAt = nuevoRol.UpdatedAt
            };
        }

        public async Task ActualizarAsync(RolUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }



            var rol = await _unitOfWork.Rol.ObtenerPorIdAsync(dto.RolID);

            if (rol.Nombre != null &&
                (rol.Nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                    rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
            {
                throw new BusinessException("No es posible actualizar el rol Administrador.");
            }

            if (rol == null)
            {
                throw new BusinessException("El rol que intenta actualizar no existe.");
            }

            if (await _unitOfWork.Rol.ExisteNombreAsync(dto.Nombre, dto.RolID))
            {
                throw new BusinessException($"Ya existe otro rol con el nombre '{dto.Nombre}'.");
            }

            rol.Nombre = dto.Nombre.Trim();
            rol.Descripcion = dto.Descripcion?.Trim();
            rol.ModulosPermitidos = JsonSerializer.Serialize(dto.ModulosPermitidos ?? new List<string>());
            rol.Activo = dto.Activo;

            _unitOfWork.Rol.Actualizar(rol);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var rol = await _unitOfWork.Rol.ObtenerPorIdAsync(id);
            if (rol == null)
            {
                throw new BusinessException("El rol a desactivar no existe.");
            }

            if (rol.Nombre != null &&
                (rol.Nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                    rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
            {
                throw new BusinessException("No es posible desactivar el rol Administrador.");
            }

            _unitOfWork.Rol.EliminarLogico(rol);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var rol = await _unitOfWork.Rol.ObtenerPorIdAsync(id);
            if (rol == null)
            {
                throw new BusinessException("El rol a eliminar no existe.");
            }

            if (rol.Nombre != null &&
                (rol.Nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                    rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
            {
                throw new BusinessException("No es posible eliminar el rol Administrador.");
            }

            // Nota: Aquí se puede añadir una validación previa para verificar
            // si existen usuarios asignados a este rol antes de realizar el borrado físico.

            _unitOfWork.Rol.EliminarFisico(rol);
            await _unitOfWork.SaveChangesAsync();
        }

        private static List<string> DeserializarModulos(string jsonModulos)
        {
            if (string.IsNullOrWhiteSpace(jsonModulos))
                return new List<string>();

            try
            {
                return JsonSerializer.Deserialize<List<string>>(jsonModulos) ?? new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}
