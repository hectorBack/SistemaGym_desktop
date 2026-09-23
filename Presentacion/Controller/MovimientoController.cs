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
    public class MovimientoController
    {
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        public async Task<IEnumerable<MovimientoViewModel>> ObtenerMovimientosAsync(bool incluirInactivos = true)
        {
            var dtos = await _movimientoService.ObtenerTodosAsync(incluirInactivos);

            return dtos.Select(m => new MovimientoViewModel
            {
                MovimientoID = m.MovimientoID,
                Tipo = m.Tipo,
                ConceptoID = m.ConceptoID,
                ConceptoNombre = m.ConceptoNombre ?? string.Empty,
                FormaPago = m.FormaPago,
                Total = m.Total,
                Observacion = m.Observacion,
                CorteID = m.CorteID,
                UsuarioID = m.UsuarioID,
                Activo = m.Activo,
                CreatedAt = m.CreatedAt
            });
        }

        public async Task<MovimientoDto?> ObtenerPorIdAsync(int id)
        {
            return await _movimientoService.ObtenerPorIdAsync(id);
        }

        public async Task GuardarMovimientoAsync(
            int? id,
            string tipo,
            int conceptoId,
            string formaPago,
            decimal total,
            string? observacion = null,
            int? corteId = null,
            int? usuarioId = null)
        {
            if (id.HasValue && id.Value > 0)
            {
                var updateDto = new MovimientoUpdateDto
                {
                    MovimientoID = id.Value,
                    Tipo = tipo,
                    ConceptoID = conceptoId,
                    FormaPago = formaPago,
                    Total = total,
                    Observacion = observacion,
                    CorteID = corteId,
                    UsuarioID = usuarioId,
                    Activo = true
                };
                await _movimientoService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new MovimientoCreateDto
                {
                    Tipo = tipo,
                    ConceptoID = conceptoId,
                    FormaPago = formaPago,
                    Total = total,
                    Observacion = observacion,
                    CorteID = corteId,
                    UsuarioID = usuarioId
                };
                await _movimientoService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _movimientoService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _movimientoService.EliminarFisicoAsync(id);
        }

        public async Task<IEnumerable<MovimientoViewModel>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var dtos = await _movimientoService.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);

            return dtos.Select(m => new MovimientoViewModel
            {
                MovimientoID = m.MovimientoID,
                Tipo = m.Tipo,
                ConceptoID = m.ConceptoID,
                ConceptoNombre = m.ConceptoNombre ?? string.Empty,
                FormaPago = m.FormaPago,
                Total = m.Total,
                Observacion = m.Observacion,
                CorteID = m.CorteID,
                UsuarioID = m.UsuarioID,
                Activo = m.Activo,
                CreatedAt = m.CreatedAt
            });
        }
    }
}
