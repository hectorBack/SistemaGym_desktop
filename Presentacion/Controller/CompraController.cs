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
    public class CompraController
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        public async Task<IEnumerable<CompraViewModel>> ObtenerComprasAsync(bool incluirInactivas = true)
        {
            var dtos = await _compraService.ObtenerTodasAsync(incluirInactivas);
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
            var dtos = await _compraService.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);
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

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _compraService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _compraService.EliminarFisicoAsync(id);
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
                Estado = c.Estado,
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
