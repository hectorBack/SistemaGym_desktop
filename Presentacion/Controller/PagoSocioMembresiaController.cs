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
    public class PagoSocioMembresiaController
    {
        private readonly IPagoSocioMembresiaService _pagoSocioMembresiaService;

        public PagoSocioMembresiaController(IPagoSocioMembresiaService pagoSocioMembresiaService)
        {
            _pagoSocioMembresiaService = pagoSocioMembresiaService;
        }

        public async Task<IEnumerable<PagoSocioMembresiaViewModel>> ObtenerPagosAsync(bool incluirInactivos = true)
        {
            var dtos = await _pagoSocioMembresiaService.ObtenerTodasAsync(incluirInactivos);

            return dtos.Select(MapToViewModel);
        }

        public async Task<IEnumerable<PagoSocioMembresiaViewModel>> ObtenerPorSocioMembresiaIdAsync(int socioMembresiaId, bool incluirInactivos = true)
        {
            var dtos = await _pagoSocioMembresiaService.ObtenerPorSocioMembresiaIdAsync(socioMembresiaId, incluirInactivos);

            return dtos.Select(MapToViewModel);
        }

        public async Task<PagoSocioMembresiaDto?> ObtenerPorIdAsync(int id)
        {
            return await _pagoSocioMembresiaService.ObtenerPorIdAsync(id);
        }

        public async Task<decimal> ObtenerTotalPagadoPorSocioMembresiaIdAsync(int socioMembresiaId)
        {
            return await _pagoSocioMembresiaService.ObtenerTotalPagadoPorSocioMembresiaIdAsync(socioMembresiaId);
        }

        public async Task GuardarPagoAsync(int? pagoId, int socioMembresiaId, decimal monto, string? folio, string formaPago, string? observacion)
        {
            if (pagoId.HasValue && pagoId.Value > 0)
            {
                var updateDto = new PagoSocioMembresiaUpdateDto
                {
                    PagoID = pagoId.Value,
                    Monto = monto,
                    Folio = folio,
                    FormaPago = formaPago,
                    Observacion = observacion,
                    Activo = true
                };
                await _pagoSocioMembresiaService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new PagoSocioMembresiaCreateDto
                {
                    SocioMembresiaID = socioMembresiaId,
                    Monto = monto,
                    Folio = folio,
                    FormaPago = formaPago,
                    Observacion = observacion
                };
                await _pagoSocioMembresiaService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _pagoSocioMembresiaService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _pagoSocioMembresiaService.EliminarFisicoAsync(id);
        }

        private static PagoSocioMembresiaViewModel MapToViewModel(PagoSocioMembresiaDto dto)
        {
            return new PagoSocioMembresiaViewModel
            {
                PagoID = dto.PagoID,
                SocioMembresiaID = dto.SocioMembresiaID,
                Monto = dto.Monto,
                Folio = dto.Folio,
                FormaPago = dto.FormaPago,
                Observacion = dto.Observacion,
                Activo = dto.Activo,
                CreatedAt = dto.CreatedAt
            };
        }
    }
}
