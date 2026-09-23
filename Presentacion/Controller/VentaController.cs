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
    public class VentaController
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        public async Task<IEnumerable<VentaViewModel>> ObtenerVentasAsync(bool incluirInactivas = true)
        {
            var dtos = await _ventaService.ObtenerTodasAsync(incluirInactivas);

            return dtos.Select(MapToViewModel);
        }

        public async Task<VentaDto?> ObtenerPorIdAsync(int id)
        {
            return await _ventaService.ObtenerPorIdAsync(id);
        }

        public async Task<VentaDto> RegistrarVentaAsync(int usuarioId, int? socioId, decimal total, List<DetalleVentaCreateDto> detalles)
        {
            var createDto = new VentaCreateDto
            {
                UsuarioID = usuarioId,
                SocioID = socioId,
                Total = total,
                Detalles = detalles
            };

            return await _ventaService.CrearAsync(createDto);
        }

        public async Task AnularVentaAsync(int id)
        {
            await _ventaService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _ventaService.EliminarFisicoAsync(id);
        }

        public async Task<IEnumerable<VentaViewModel>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var dtos = await _ventaService.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);
            return dtos.Select(MapToViewModel);
        }

        public async Task<IEnumerable<VentaViewModel>> ObtenerPorSocioIdAsync(int socioId)
        {
            var dtos = await _ventaService.ObtenerPorSocioIdAsync(socioId);
            return dtos.Select(MapToViewModel);
        }

        // Método helper privado para mapear DTO a ViewModel
        private static VentaViewModel MapToViewModel(VentaDto dto)
        {
            return new VentaViewModel
            {
                VentaID = dto.VentaID,
                UsuarioID = dto.UsuarioID,
                UsuarioNombre = string.IsNullOrWhiteSpace(dto.UsuarioNombre) ? "N/A" : dto.UsuarioNombre,
                SocioID = dto.SocioID,
                SocioNombre = string.IsNullOrWhiteSpace(dto.SocioNombre) ? "Cliente Casual" : dto.SocioNombre,
                Total = dto.Total,
                FechaVenta = dto.FechaVenta,
                Activo = dto.Activo,
                CantidadProductos = dto.Detalles?.Sum(d => d.Cantidad) ?? 0,
                CreatedAt = dto.CreatedAt
            };
        }
    }
}
