using Negocio.DTOs;
using Negocio.Interfaces;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controller
{
    public class UsuarioController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<UsuarioDto> LoginAsync(string usuario, string password)
        {
            var loginDto = new LoginRequestDto
            {
                Usuario = usuario,
                Password = password
            };

            return await _usuarioService.LoginAsync(loginDto);
        }

        public async Task<IEnumerable<UsuarioViewModel>> ObtenerUsuariosAsync(bool incluirInactivos = true)
        {
            var dtos = await _usuarioService.ObtenerTodosAsync(incluirInactivos);

            return dtos.Select(u => new UsuarioViewModel
            {
                UsuarioID = u.UsuarioID,
                NombreCompleto = u.NombreCompleto,
                NombreUsuario = u.NombreUsuario,
                RolID = u.RolID,
                RolNombre = u.RolNombre,
                Activo = u.Activo,
                CreatedAt = u.CreatedAt
            });
        }

        public async Task<UsuarioDto?> ObtenerPorIdAsync(int id)
        {
            return await _usuarioService.ObtenerPorIdAsync(id);
        }

        public async Task GuardarUsuarioAsync(
            int? id,
             string nombreUsuario,
            string nombreCompleto,
            int rolId,
            string? password = null,
            bool activo = true)
        {
            if (id.HasValue && id.Value > 0)
            {
                var updateDto = new UsuarioUpdateDto
                {
                    UsuarioID = id.Value,
                    NombreUsuario = nombreUsuario,
                    NombreCompleto = nombreCompleto,
                    RolID = rolId,
                    Password = password,
                    Activo = activo
                };
                await _usuarioService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new UsuarioCreateDto
                {
                    NombreUsuario = nombreUsuario,
                    NombreCompleto = nombreCompleto,
                    RolID = rolId,
                    Password = password ?? string.Empty
                };
                await _usuarioService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _usuarioService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _usuarioService.EliminarFisicoAsync(id);
        }
    }
}
