using Negocio.DTOs;
using Negocio.Interfaces;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controls
{
    public class CategoriaController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObtenerCategoriasAsync(bool incluirInactivas = true)
        {
            var dtos = await _categoriaService.ObtenerTodasAsync(incluirInactivas);

            return dtos.Select(c => new CategoriaViewModel
            {
                CategoriaID = c.CategoriaID,
                Nombre = c.Nombre,
                Activo = c.Activo,
                CreatedAt = c.CreatedAt
            });
        }

        public async Task<CategoriaDto?> ObtenerPorIdAsync(int id)
        {
            return await _categoriaService.ObtenerPorIdAsync(id);
        }

        public async Task GuardarCategoriaAsync(int? id, string nombre)
        {
            if (id.HasValue && id.Value > 0)
            {
                var updateDto = new CategoriaUpdateDto
                {
                    CategoriaID = id.Value,
                    Nombre = nombre,
                    Activo = true
                };
                await _categoriaService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new CategoriaCreateDto
                {
                    Nombre = nombre
                };
                await _categoriaService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _categoriaService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _categoriaService.EliminarFisicoAsync(id);
        }
    }
}
