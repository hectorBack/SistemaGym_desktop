using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using Negocio.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UsuarioCreateDto> _createValidator;
        private readonly IValidator<UsuarioUpdateDto> _updateValidator;

        public UsuarioService(
            IUnitOfWork unitOfWork,
            IValidator<UsuarioCreateDto> createValidator,
            IValidator<UsuarioUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;

        }

        public async Task ActualizarAsync(UsuarioUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var usuario = await _unitOfWork.Usuarios.ObtenerPorIdAsync(dto.UsuarioID);
            if (usuario == null)
            {
                throw new BusinessException("El usuario que intenta actualizar no existe.");
            }

            if (await _unitOfWork.Usuarios.ExisteNombreUsuarioAsync(dto.NombreUsuario.Trim(), dto.UsuarioID))
            {
                throw new BusinessException($"Ya existe otro usuario registrado con el nombre de usuario '{dto.NombreUsuario}'.");
            }

            usuario.NombreCompleto = dto.NombreCompleto.Trim();
            usuario.NombreUsuario = dto.NombreUsuario.Trim();
            usuario.RolID = dto.RolID;
            usuario.Activo = dto.Activo;

            // Si se especificó una nueva contraseña al editar, la actualizamos
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                usuario.Password = dto.Password;
            }

            _unitOfWork.Usuarios.Actualizar(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UsuarioDto> CrearAsync(UsuarioCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            if (await _unitOfWork.Usuarios.ExisteNombreUsuarioAsync(dto.NombreUsuario.Trim()))
            {
                throw new BusinessException($"Ya existe un usuario registrado con el nombre de usuario '{dto.NombreUsuario}'.");
            }

            var nuevoUsuario = new Usuario
            {
                NombreCompleto = dto.NombreCompleto.Trim(),
                NombreUsuario = dto.NombreUsuario.Trim(),
                Password = dto.Password, // Nota: Si implementas encriptación (BCrypt/SHA256), aplícala aquí
                RolID = dto.RolID,
                Activo = true
            };

            await _unitOfWork.Usuarios.AgregarAsync(nuevoUsuario);
            await _unitOfWork.SaveChangesAsync();

            // Re-consultamos para cargar la navegación del Rol
            var usuarioCreado = await _unitOfWork.Usuarios.ObtenerPorIdAsync(nuevoUsuario.UsuarioID);

            return MapearAUsuarioDto(usuarioCreado ?? nuevoUsuario);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.ObtenerPorIdAsync(id);
            if (usuario == null)
            {
                throw new BusinessException("El usuario a eliminar no existe.");
            }

            _unitOfWork.Usuarios.EliminarFisico(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.ObtenerPorIdAsync(id);
            if (usuario == null)
            {
                throw new BusinessException("El usuario a desactivar no existe.");
            }

            _unitOfWork.Usuarios.EliminarLogico(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UsuarioDto> LoginAsync(LoginRequestDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Usuario) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                throw new BusinessException("Debe ingresar el usuario y la contraseña.");
            }

            var usuario = await _unitOfWork.Usuarios.ValidarLoginAsync(loginDto.Usuario.Trim(), loginDto.Password);

            if (usuario == null)
            {
                throw new BusinessException("Usuario o contraseña incorrectos.");
            }

            return MapearAUsuarioDto(usuario);
        }

        public async Task<UsuarioDto?> ObtenerPorIdAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.ObtenerPorIdAsync(id);
            if (usuario == null) return null;

            return MapearAUsuarioDto(usuario);
        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var usuarios = await _unitOfWork.Usuarios.ObtenerTodosAsync(incluirInactivos);

            return usuarios.Select(MapearAUsuarioDto);
        }

        private static UsuarioDto MapearAUsuarioDto(Usuario u)
        {
            return new UsuarioDto
            {
                UsuarioID = u.UsuarioID,
                NombreCompleto = u.NombreCompleto,
                NombreUsuario = u.NombreUsuario,
                RolID = u.RolID,
                RolNombre = u.Rol?.Nombre ?? string.Empty,
                ModulosPermitidos = DeserializarModulos(u.Rol?.ModulosPermitidos),
                Activo = u.Activo,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            };
        }

        private static List<string> DeserializarModulos(string? jsonModulos)
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
