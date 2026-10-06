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
    public class CorteController
    {
        private readonly ICorteService _corteService;

        public CorteController(ICorteService corteService)
        {
            _corteService = corteService;
        }

        public async Task<IEnumerable<CorteViewModel>> ObtenerCortesAsync(bool incluirInactivos = true)
        {
            var dtos = await _corteService.ObtenerTodosAsync(incluirInactivos);

            return dtos.Select(MapearAViewModel);
        }

        public async Task<CorteDto?> ObtenerPorIdAsync(int id)
        {
            return await _corteService.ObtenerPorIdAsync(id);
        }

        public async Task<CorteViewModel?> ObtenerCorteAbiertoPorUsuarioAsync(int usuarioId)
        {
            var dto = await _corteService.ObtenerCorteAbiertoPorUsuarioAsync(usuarioId);
            if (dto == null) return null;

            return MapearAViewModel(dto);
        }

        public async Task<IEnumerable<CorteViewModel>> ObtenerPorRangoFechasAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _corteService.ObtenerPorRangoFechasAsync(inicio, fin);
            return dtos.Select(MapearAViewModel);
        }

        public async Task<CorteDto> AbrirCorteAsync(int usuarioId, decimal montoInicial, string? observaciones = null)
        {
            var createDto = new CorteCreateDto
            {
                UsuarioID = usuarioId,
                MontoInicial = montoInicial,
                Observaciones = observaciones
            };

            return await _corteService.AbrirCorteAsync(createDto);
        }

        public async Task CerrarCorteAsync(int corteId, decimal totalIngresos, decimal totalEgresos, decimal montoFinal, string? observaciones = null)
        {
            var updateDto = new CorteUpdateDto
            {
                CorteID = corteId,
                TotalIngresos = totalIngresos,
                TotalEgresos = totalEgresos,
                MontoFinal = montoFinal,
                Observaciones = observaciones,
                Estado = "Cerrado",
                Activo = true
            };

            await _corteService.CerrarCorteAsync(updateDto);
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _corteService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _corteService.EliminarFisicoAsync(id);
        }

        public async Task<decimal> ObtenerEfectivoEnCajaAsync()
        {
            return await _corteService.ObtenerEfectivoEnCajaAsync();
        }

        private static CorteViewModel MapearAViewModel(CorteDto dto)
        {
            return new CorteViewModel
            {
                CorteID = dto.CorteID,
                UsuarioID = dto.UsuarioID,
                Usuario = dto.NombreUsuario,
                FechaApertura = dto.FechaApertura,
                FechaCierre = dto.FechaCierre,
                MontoInicial = dto.MontoInicial,
                TotalIngresos = dto.TotalIngresos,
                TotalEgresos = dto.TotalEgresos,
                MontoFinal = dto.MontoFinal,
                Observaciones = dto.Observaciones ?? string.Empty,
                Estado = dto.Estado,
                Activo = dto.Activo,
                CreatedAt = dto.CreatedAt
            };
        }
    }
}
