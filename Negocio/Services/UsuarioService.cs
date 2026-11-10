using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using Negocio.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private const int PasswordHashIterations = 210_000;
        private const int PasswordSaltSize = 16;
        private const int PasswordHashSize = 32;
        private const int MinSupportedPasswordHashIterations = 100_000;
        private const int MaxSupportedPasswordHashIterations = 2_000_000;
        private const string PasswordHashAlgorithm = "PBKDF2-SHA256";

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
            if (usuario == null || usuario.Estado == "Eliminado")
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
            usuario.Estado = dto.Activo ? "Activo" : "Inactivo";

            // Si se especificó una nueva contraseña al editar, la actualizamos
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                usuario.Password = CrearHashPassword(dto.Password);
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
                Password = CrearHashPassword(dto.Password),
                RolID = dto.RolID,
                Activo = true
            };

            await _unitOfWork.Usuarios.AgregarAsync(nuevoUsuario);
            await _unitOfWork.SaveChangesAsync();

            // Re-consultamos para cargar la navegación del Rol
            var usuarioCreado = await _unitOfWork.Usuarios.ObtenerPorIdAsync(nuevoUsuario.UsuarioID);

            return MapearAUsuarioDto(usuarioCreado ?? nuevoUsuario);
        }

        public async Task EliminarAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.ObtenerPorIdAsync(id);
            if (usuario == null || usuario.Estado == "Eliminado")
            {
                throw new BusinessException("El usuario a eliminar no existe.");
            }

            if (usuario.Rol != null &&
                (usuario.Rol.Nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                    usuario.Rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
            {
                throw new BusinessException("No es posible eliminar un usuario Administrador.");
            }

            // Un corte abierto de un usuario eliminado quedaría sin dueño.
            if (await _unitOfWork.Corte.TieneCorteAbiertoAsync(id))
            {
                throw new BusinessException("El usuario tiene un corte de caja abierto. Ciérrelo antes de eliminarlo.");
            }

            // Sus ventas, movimientos y cortes conservan su nombre: solo deja de poder iniciar sesión.
            _unitOfWork.Usuarios.MarcarComoEliminado(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.ObtenerPorIdAsync(id);
            if (usuario == null || usuario.Estado == "Eliminado")
            {
                throw new BusinessException("El usuario a desactivar no existe.");
            }

            if (usuario.Rol != null &&
                (usuario.Rol.Nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                    usuario.Rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
            {
                throw new BusinessException("No es posible desactivar un usuario Administrador.");
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

            var usuario = await _unitOfWork.Usuarios.ObtenerPorNombreUsuarioAsync(loginDto.Usuario.Trim());
            if (usuario == null)
            {
                throw new BusinessException("Usuario o contraseña incorrectos.");
            }

            if (!VerificarPassword(loginDto.Password, usuario.Password, out bool necesitaRehash))
                throw new BusinessException("Usuario o contraseña incorrectos.");

            if (necesitaRehash)
            {
                usuario.Password = CrearHashPassword(loginDto.Password);
                _unitOfWork.Usuarios.Actualizar(usuario);
                await _unitOfWork.SaveChangesAsync();
            }

            return MapearAUsuarioDto(usuario);
        }

        private static string CrearHashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(PasswordSaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                PasswordHashIterations,
                HashAlgorithmName.SHA256,
                PasswordHashSize);

            return string.Join(
                "$",
                PasswordHashAlgorithm,
                PasswordHashIterations.ToString(CultureInfo.InvariantCulture),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        private static bool VerificarPassword(string password, string passwordGuardado, out bool necesitaRehash)
        {
            necesitaRehash = false;

            if (!passwordGuardado.StartsWith(PasswordHashAlgorithm + "$", StringComparison.Ordinal))
            {
                if (!string.Equals(password, passwordGuardado, StringComparison.Ordinal))
                    return false;

                necesitaRehash = true;
                return true;
            }

            string[] partes = passwordGuardado.Split('$');
            if (partes.Length != 4 ||
                !int.TryParse(partes[1], NumberStyles.None, CultureInfo.InvariantCulture, out int iteraciones) ||
                iteraciones < MinSupportedPasswordHashIterations ||
                iteraciones > MaxSupportedPasswordHashIterations)
            {
                return false;
            }

            byte[] salt;
            byte[] hashGuardado;
            try
            {
                salt = Convert.FromBase64String(partes[2]);
                hashGuardado = Convert.FromBase64String(partes[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            if (salt.Length != PasswordSaltSize || hashGuardado.Length != PasswordHashSize)
                return false;

            byte[] hashCalculado = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iteraciones,
                HashAlgorithmName.SHA256,
                PasswordHashSize);

            necesitaRehash = iteraciones < PasswordHashIterations;
            return CryptographicOperations.FixedTimeEquals(hashCalculado, hashGuardado);
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

        private UsuarioDto MapearAUsuarioDto(Usuario usuario)
        {
            var modulosList = new List<string>();

            if (usuario.Rol != null && !string.IsNullOrWhiteSpace(usuario.Rol.ModulosPermitidos))
            {
                try
                {
                    // Deserializa la cadena JSON "[\"Socios\"]" a una lista de C# List<string>
                    modulosList = System.Text.Json.JsonSerializer.Deserialize<List<string>>(usuario.Rol.ModulosPermitidos)
                                  ?? new List<string>();
                }
                catch
                {
                    modulosList = new List<string>();
                }
            }

            return new UsuarioDto
            {
                UsuarioID = usuario.UsuarioID,
                NombreUsuario = usuario.NombreUsuario,
                NombreCompleto = usuario.NombreCompleto, // O la propiedad correspondiente de tu entidad
                RolID = usuario.RolID,
                RolNombre = usuario.Rol?.Nombre ?? string.Empty, // Se asigna el nombre del Rol[cite: 1]
                ModulosPermitidos = modulosList, // Asignación de la lista deserializada
                Activo = usuario.Activo,
                CreatedAt = usuario.CreatedAt
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
