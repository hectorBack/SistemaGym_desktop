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
    public class ConceptoController
    {
        private readonly IConceptoService _conceptoService;

        public ConceptoController(IConceptoService conceptoService)
        {
            _conceptoService = conceptoService;
        }

        public async Task<IEnumerable<ConceptoViewModel>> ObtenerConceptosAsync(bool incluirInactivos = true)
        {
            var dtos = await _conceptoService.ObtenerTodosAsync(incluirInactivos);

            return dtos.Select(c => new ConceptoViewModel
            {
                ConceptoID = c.ConceptoID,
                Nombre = c.Nombre,
                Tipo = c.Tipo,
                Observacion = c.Observacion,
                EsSistema = c.EsSistema,
                Activo = c.Activo,
                CreatedAt = c.CreatedAt
            });
        }

        public async Task<ConceptoDto?> ObtenerPorIdAsync(int id)
        {
            return await _conceptoService.ObtenerPorIdAsync(id);
        }

        public async Task GuardarConceptoAsync(int? id, string nombre, string tipo, string? observacion)
        {
            if (id.HasValue && id.Value > 0)
            {
                var updateDto = new ConceptoUpdateDto
                {
                    ConceptoID = id.Value,
                    Nombre = nombre,
                    Tipo = tipo,
                    Observacion = observacion,
                    Activo = true
                };
                await _conceptoService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new ConceptoCreateDto
                {
                    Nombre = nombre,
                    Tipo = tipo,
                    Observacion = observacion
                };
                await _conceptoService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _conceptoService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _conceptoService.EliminarFisicoAsync(id);
        }
    }
}
