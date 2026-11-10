using Negocio.DTOs;
using Negocio.Interfaces;
using Negocio.Services;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controller
{
    public class CompraController
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        public async Task<IEnumerable<CompraViewModel>> ObtenerComprasAsync(string? estadoFiltro = "Activo")
        {
            var dtos = await _compraService.ObtenerTodasAsync(estadoFiltro);
            return dtos.Select(MapearAViewModel);
        }

        public async Task<CompraDto?> ObtenerPorIdAsync(int id)
        {
            return await _compraService.ObtenerPorIdAsync(id);
        }

        public async Task<CompraDto?> ObtenerPorCodigoAsync(string codigo)
        {
            return await _compraService.ObtenerPorCodigoAsync(codigo);
        }

        public async Task<IEnumerable<CompraViewModel>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            // Consulta ligera para el listado (sin líneas de detalle).
            var dtos = await _compraService.ObtenerResumenPorRangoFechasAsync(fechaInicio, fechaFin);
            return dtos.Select(MapearAViewModel);
        }

        public async Task<CompraDto> CrearCompraAsync(CompraCreateDto createDto)
        {
            return await _compraService.CrearAsync(createDto);
        }

        public async Task CancelarCompraAsync(int id, int usuarioId, string? observacion = null)
        {
            await _compraService.CancelarCompraAsync(id, usuarioId, observacion);
        }

        public async Task EliminarLogicoAsync(int id, int usuarioId)
        {
            await _compraService.EliminarLogicoAsync(id, usuarioId);
        }

        public async Task<string> ObtenerSiguienteCodigoAsync()
        {
            return await _compraService.ObtenerSiguienteCodigoAsync();
        }

        #region Métodos Privados Auxiliares
        private static CompraViewModel MapearAViewModel(CompraDto c)
        {
            return new CompraViewModel
            {
                CompraID = c.CompraID,
                Codigo = c.Codigo,
                Total = c.Total,
                Observacion = c.Observacion,
                UsuarioID = c.UsuarioID,
                UsuarioNombre = c.UsuarioNombre,
                Activo = c.Activo,
                CreatedAt = c.CreatedAt,
                Detalles = c.Detalles.Select(d => new DetalleCompraViewModel
                {
                    DetalleCompraID = d.DetalleCompraID,
                    CompraID = d.CompraID,
                    ProductoID = d.ProductoID,
                    CodigoBarras = d.CodigoBarras,
                    ProductoNombre = d.ProductoNombre,
                    Cantidad = d.Cantidad,
                    CostoUnitario = d.CostoUnitario
                }).ToList()
            };
        }
        #endregion
    }
}
