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
    public class VisitaController
    {
        private readonly IVisitaService _visitaService;

        public VisitaController(IVisitaService visitaService)
        {
            _visitaService = visitaService;
        }

        public async Task<IEnumerable<VisitaViewModel>> ObtenerVisitasAsync()
        {
            var dtos = await _visitaService.ObtenerTodasAsync();

            return dtos.Select(v => new VisitaViewModel
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                MembresiaID = v.MembresiaID,
                Clave = v.Clave,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Telefono = v.Telefono,
                MontoPagado = v.MontoPagado,
                TipoAcceso = v.TipoAcceso,
                Observaciones = v.Observaciones,
                NombreMembresia = v.NombreMembresia,
                Activo = v.Activo,
                CreatedAt = v.CreatedAt
            });
        }

        public async Task<IEnumerable<VisitaViewModel>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var dtos = await _visitaService.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);

            return dtos.Select(v => new VisitaViewModel
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                MembresiaID = v.MembresiaID,
                Clave = v.Clave,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Telefono = v.Telefono,
                MontoPagado = v.MontoPagado,
                TipoAcceso = v.TipoAcceso,
                Observaciones = v.Observaciones,
                NombreMembresia = v.NombreMembresia,
                Activo = v.Activo,
                CreatedAt = v.CreatedAt
            });
        }

        public async Task<VisitaDto?> ObtenerPorIdAsync(int id)
        {
            return await _visitaService.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<VisitaViewModel>> ObtenerPorSocioIdAsync(int socioId)
        {
            var dtos = await _visitaService.ObtenerPorSocioIdAsync(socioId);

            return dtos.Select(v => new VisitaViewModel
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                MembresiaID = v.MembresiaID,
                Clave = v.Clave,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Telefono = v.Telefono,
                MontoPagado = v.MontoPagado,
                TipoAcceso = v.TipoAcceso,
                Observaciones = v.Observaciones,
                NombreMembresia = v.NombreMembresia,
                Activo = v.Activo,
                CreatedAt = v.CreatedAt
            });
        }

        public async Task<VisitaViewModel> RegistrarVisitaAsync(VisitaCreateDto createDto)
        {
            var dto = await _visitaService.RegistrarVisitaAsync(createDto);

            return new VisitaViewModel
            {
                VisitaID = dto.VisitaID,
                SocioID = dto.SocioID,
                MembresiaID = dto.MembresiaID,
                Clave = dto.Clave,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                MontoPagado = dto.MontoPagado,
                TipoAcceso = dto.TipoAcceso,
                Observaciones = dto.Observaciones,
                NombreMembresia = dto.NombreMembresia,
                Activo = dto.Activo,
                CreatedAt = dto.CreatedAt
            };
        }

        public async Task ActualizarAsync(VisitaUpdateDto updateDto)
        {
            await _visitaService.ActualizarAsync(updateDto);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _visitaService.EliminarFisicoAsync(id);
        }

        public async Task<AccesoResultadoViewModel> ProcesarAccesoRapidoAsync(string clave)
        {
            var dto = await _visitaService.ProcesarAccesoRapidoAsync(clave);

            return new AccesoResultadoViewModel
            {
                VisitaID = dto.VisitaID,
                Exitoso = dto.Exitoso,
                MensajeError = dto.MensajeError,
                EsVisitaCasual = dto.EsVisitaCasual,
                SocioID = dto.SocioID,
                Clave = dto.Clave,
                NombreCompleto = dto.NombreCompleto,
                FotoRuta = dto.Foto,
                NombreMembresia = dto.NombreMembresia,
                FechaVencimiento = dto.FechaVencimiento,
                MembresiaVigente = dto.MembresiaVigente,
                AsistenciasSemana = dto.AsistenciasSemana,
                PrecioMembresia = dto.PrecioMembresia,
                TotalPagado = dto.TotalPagado
            };
        }

        public async Task<IEnumerable<VisitaViewModel>> ObtenerPorSocioYFechasAsync(int socioId, DateTime desde, DateTime hasta)
        {
            var dtos = await _visitaService.ObtenerPorSocioYFechasAsync(socioId, desde, hasta);

            return dtos.Select(v => new VisitaViewModel
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                MembresiaID = v.MembresiaID,
                Clave = v.Clave,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Telefono = v.Telefono,
                MontoPagado = v.MontoPagado,
                TipoAcceso = v.TipoAcceso,
                Observaciones = v.Observaciones,
                NombreMembresia = v.NombreMembresia,
                Activo = v.Activo,
                CreatedAt = v.CreatedAt
            });
        }

        public async Task CancelarVisitaAsync(int id, string? motivo = null)
        {
            await _visitaService.CancelarVisitaAsync(id, motivo);
        }
    }
}
