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
        private readonly ITicketService _ticketService;

        public PagoSocioMembresiaController(IPagoSocioMembresiaService pagoSocioMembresiaService, ITicketService ticketService)
        {
            _pagoSocioMembresiaService = pagoSocioMembresiaService;
            _ticketService = ticketService;
        }

        public async Task<IEnumerable<PagoSocioMembresiaViewModel>> ObtenerPagosAsync(bool incluirInactivos = true)
        {
            var dtos = await _pagoSocioMembresiaService.ObtenerTodasAsync(incluirInactivos);

            return dtos.Select(MapToViewModel);
        }

        public async Task<IEnumerable<PagoSocioMembresiaViewModel>> ObtenerPorSocioMembresiaIdAsync(int socioMembresiaId, bool incluirInactivos = false)
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

        // Devuelve el pago creado (para poder imprimir su ticket); null cuando solo se actualizó uno existente.
        public async Task<PagoSocioMembresiaDto?> GuardarPagoAsync(int? pagoId, int socioMembresiaId, int usuarioId, decimal monto, string? folio, string formaPago, string? observacion)
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
                return null;
            }
            else
            {
                var createDto = new PagoSocioMembresiaCreateDto
                {
                    SocioMembresiaID = socioMembresiaId,
                    UsuarioID = usuarioId,
                    Monto = monto,
                    Folio = folio,
                    FormaPago = formaPago,
                    Observacion = observacion
                };
                return await _pagoSocioMembresiaService.CrearAsync(createDto);
            }
        }

        /// <summary>
        /// Imprime el comprobante de un pago. Devuelve false si la impresora está
        /// deshabilitada en la configuración del ticket.
        /// </summary>
        public async Task<bool> ImprimirTicketAsync(int pagoId)
        {
            return await _ticketService.ImprimirTicketPagoMembresiaAsync(pagoId);
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _pagoSocioMembresiaService.EliminarLogicoAsync(id);
        }

        public async Task AnularPagoAsync(int pagoId, int usuarioId, string? motivo = null)
        {
            await _pagoSocioMembresiaService.AnularPagoAsync(pagoId, usuarioId, motivo);
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
