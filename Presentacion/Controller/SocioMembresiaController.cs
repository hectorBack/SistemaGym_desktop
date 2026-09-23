using Microsoft.EntityFrameworkCore;
using Negocio.DTOs;
using Negocio.Interfaces;
using Presentacion.ViewModels.TuProyecto.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controller
{
    public class SocioMembresiaController
    {
        private readonly ISocioMembresiaService _socioMembresiaService;

        public SocioMembresiaController(ISocioMembresiaService socioMembresiaService)
        {
            _socioMembresiaService = socioMembresiaService;
        }

        public async Task<IEnumerable<SocioMembresiaViewModel>> ObtenerHistorialPorSocioIdAsync(int socioId)
        {
            var dtos = await _socioMembresiaService.ObtenerPorSocioIdAsync(socioId);

            return dtos.Select(sm => new SocioMembresiaViewModel
            {
                SocioMembresiaID = sm.SocioMembresiaID,
                SocioID = sm.SocioID,
                MembresiaID = sm.MembresiaID,
                NombreMembresia = sm.NombreMembresia ?? "N/A",
                Precio = sm.Precio,
                TotalPagado = sm.TotalPagado,
                FechaInicio = sm.FechaInicio,
                FechaFin = sm.FechaFin,
                CreatedAt = sm.CreatedAt,
                Estado = sm.Estado
            });
        }

        public async Task<SocioMembresiaViewModel?> ObtenerPorIdAsync(int socioMembresiaId)
        {
            var dto = await _socioMembresiaService.ObtenerPorIdAsync(socioMembresiaId);
            if (dto == null) return null;

            return new SocioMembresiaViewModel
            {
                SocioMembresiaID = dto.SocioMembresiaID,
                SocioID = dto.SocioID,
                MembresiaID = dto.MembresiaID,
                NombreMembresia = dto.NombreMembresia ?? "N/A",
                Precio = dto.Precio,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                CreatedAt = dto.CreatedAt,
                Estado = dto.Estado
            };
        }

        public async Task<SocioMembresiaViewModel?> ObtenerMembresiaActivaPorSocioIdAsync(int socioId)
        {
            var dto = await _socioMembresiaService.ObtenerMembresiaActivaPorSocioIdAsync(socioId);
            if (dto == null) return null;

            return new SocioMembresiaViewModel
            {
                SocioMembresiaID = dto.SocioMembresiaID,
                SocioID = dto.SocioID,
                MembresiaID = dto.MembresiaID,
                NombreMembresia = dto.NombreMembresia ?? "N/A",
                Precio = dto.Precio,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                CreatedAt = dto.CreatedAt,
                Estado = dto.Estado
            };
        }

        public async Task AsignarMembresiaAsync(AsignarMembresiaDto dto)
        {
            await _socioMembresiaService.AsignarMembresiaAsync(dto);
        }

        public async Task CancelarMembresiaAsync(int socioMembresiaId)
        {
            await _socioMembresiaService.CancelarMembresiaAsync(socioMembresiaId);
        }

        public async Task EliminarMembresiaAsync(int socioMembresiaId)
        {
            await _socioMembresiaService.EliminarAsync(socioMembresiaId);
        }

    }
}
