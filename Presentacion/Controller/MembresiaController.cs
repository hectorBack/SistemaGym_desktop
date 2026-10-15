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
    public class MembresiaController
    {
        private readonly IMembresiaService _membresiaService;

        public MembresiaController(IMembresiaService membresiaService)
        {
            _membresiaService = membresiaService;
        }

        public async Task<IEnumerable<MembresiaViewModel>> ObtenerMembresiasAsync(bool incluirInactivas = true)
        {
            var dtos = await _membresiaService.ObtenerTodasAsync(incluirInactivas);

            return dtos.Select(m => new MembresiaViewModel
            {
                MembresiaID = m.MembresiaID,
                Nombre = m.Nombre,
                Precio = m.Precio,
                Tipo = m.Tipo,         
                Meses = m.Meses,       
                Semanas = m.Semanas,   
                Dias = m.Dias,        
                DuracionDias = m.DuracionDias,
                Activo = m.Activo,
                CreatedAt = m.CreatedAt
            });
        }

        public async Task<MembresiaDto?> ObtenerPorIdAsync(int id)
        {
            return await _membresiaService.ObtenerPorIdAsync(id);
        }

        // Método actualizado para aceptar los nuevos parámetros desde el modal
        public async Task GuardarMembresiaAsync(int? id, string nombre, decimal precio, string tipo, int meses, int semanas, int dias)
        {
            if (id.HasValue && id.Value > 0)
            {
                var updateDto = new MembresiaUpdateDto
                {
                    MembresiaID = id.Value,
                    Nombre = nombre,
                    Precio = precio,
                    Tipo = tipo,
                    Meses = meses,
                    Semanas = semanas,
                    Dias = dias,
                    Activo = true
                };
                await _membresiaService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new MembresiaCreateDto
                {
                    Nombre = nombre,
                    Precio = precio,
                    Tipo = tipo,
                    Meses = meses,
                    Semanas = semanas,
                    Dias = dias
                };
                await _membresiaService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _membresiaService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _membresiaService.EliminarFisicoAsync(id);
        }
    }
}
