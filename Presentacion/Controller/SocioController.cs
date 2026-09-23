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
    public class SocioController
    {
        private readonly ISocioService _socioService;

        public SocioController(ISocioService socioService)
        {
            _socioService = socioService;
        }

        public async Task<IEnumerable<SocioViewModel>> ObtenerSociosAsync(bool incluirInactivos = true)
        {
            var dtos = await _socioService.ObtenerTodosAsync(incluirInactivos);

            return dtos.Select(s => new SocioViewModel
            {
                SocioID = s.SocioID,
                Clave = s.Clave,
                Nombre = s.Nombre,
                Apellido = s.Apellido,
                Telefono = s.Telefono,
                Email = s.Email,
                Foto = s.Foto,
                Observaciones = s.Observaciones,
                Activo = s.Activo,
                CreatedAt = s.CreatedAt
            });
        }

        public async Task<SocioDto?> ObtenerPorIdAsync(int id)
        {
            return await _socioService.ObtenerPorIdAsync(id);
        }

        public async Task GuardarSocioAsync(
            int? id,
            string clave,
            string nombre,
            string apellido,
            string? telefono = null,
            string? email = null,
            string? foto = null,
            string? observaciones = null,
            bool activo = true)
        {
            if (id.HasValue && id.Value > 0)
            {
                var updateDto = new SocioUpdateDto
                {
                    SocioID = id.Value,
                    Clave = clave,
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono,
                    Email = email,
                    Foto = foto,
                    Observaciones = observaciones,
                    Activo = activo
                };
                await _socioService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new SocioCreateDto
                {
                    Clave = clave,
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono,
                    Email = email,
                    Foto = foto,
                    Observaciones = observaciones
                };
                await _socioService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _socioService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _socioService.EliminarFisicoAsync(id);
        }

        public async Task<string> ObtenerSiguienteClaveAsync()
        {
            return await _socioService.ObtenerSiguienteClaveFormateadaAsync();
        }

        public async Task<SocioDetalleViewModel?> ObtenerDetalleSocioAsync(int socioId)
        {
            var dto = await _socioService.ObtenerDetalleCompletoAsync(socioId);
            if (dto == null) return null;

            return new SocioDetalleViewModel
            {
                SocioID = dto.SocioID,
                Clave = dto.Clave,
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
                Telefono = string.IsNullOrWhiteSpace(dto.Telefono) ? "N/A" : dto.Telefono,
                Email = string.IsNullOrWhiteSpace(dto.Email) ? "N/A" : dto.Email,
                Foto = dto.Foto,
                Activo = dto.Activo,
                HistorialMembresias = dto.HistorialMembresias.Select(m => new SocioMembresiaHistorialViewModel
                {
                    NombreMembresia = m.NombreMembresia,
                    FechaInicio = m.FechaInicio,
                    FechaFin = m.FechaFin,
                    Precio = m.Precio,
                    Estado = m.Estado
                }).ToList(),
                HistorialVisitas = dto.HistorialVisitas.Select(v => new SocioVisitaHistorialViewModel
                {
                    FechaHoraEntrada = v.FechaHoraEntrada,
                    TipoAcceso = v.TipoAcceso
                }).ToList()
            };
        }
    }
}
