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
    public class RolController
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        public async Task<IEnumerable<RolViewModel>> ObtenerRolesAsync(bool incluirInactivos = true)
        {
            var dtos = await _rolService.ObtenerTodasAsync(incluirInactivos);

            return dtos.Select(r => new RolViewModel
            {
                RolID = r.RolID,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                ModulosPermitidos = r.ModulosPermitidos,
                Activo = r.Activo,
                CreatedAt = r.CreatedAt
            });
        }

        public async Task<RolDto?> ObtenerPorIdAsync(int id)
        {
            return await _rolService.ObtenerPorIdAsync(id);
        }

        public async Task GuardarRolAsync(int? id, string nombre, string? descripcion, List<string> modulosPermitidos)
        {
            if (id.HasValue && id.Value > 0)
            {
                var updateDto = new RolUpdateDto
                {
                    RolID = id.Value,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    ModulosPermitidos = modulosPermitidos,
                    Activo = true
                };
                await _rolService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new RolCreateDto
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    ModulosPermitidos = modulosPermitidos
                };
                await _rolService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _rolService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _rolService.EliminarFisicoAsync(id);
        }
    }
}
