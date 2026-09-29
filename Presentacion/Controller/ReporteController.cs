using Negocio.Interfaces;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controller
{
    public class ReporteController
    {
        private readonly IReporteService _reporteService;

        public ReporteController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        public async Task<IEnumerable<ReporteInventarioViewModel>> ObtenerInventarioAsync()
        {
            var dtos = await _reporteService.ObtenerInventarioAsync();

            return dtos.Select(r => new ReporteInventarioViewModel
            {
                ProductoID = r.ProductoID,
                Codigo = r.Codigo,
                Producto = r.Producto,
                Categoria = r.Categoria,
                StockActual = r.StockActual,
                PrecioCompra = r.PrecioCompra,
                PrecioVenta = r.PrecioVenta,
                ValorTotalInventario = r.ValorTotalInventario,
                Activo = r.Activo
            });
        }

        public async Task<IEnumerable<ReporteMembresiaViewModel>> ObtenerMembresiasAsync()
        {
            var dtos = await _reporteService.ObtenerMembresiasAsync();

            return dtos.Select(r => new ReporteMembresiaViewModel
            {
                MembresiaID = r.MembresiaID,
                Nombre = r.Nombre,
                DuracionDias = r.DuracionDias,
                Precio = r.Precio,
                Activo = r.Activo
            });
        }

        public async Task<IEnumerable<ReporteSocioViewModel>> ObtenerSociosAsync()
        {
            var dtos = await _reporteService.ObtenerSociosAsync();

            return dtos.Select(r => new ReporteSocioViewModel
            {
                SocioID = r.SocioID,
                Clave = r.Clave,
                NombreCompleto = r.NombreCompleto,
                Telefono = r.Telefono,
                EstadoSocio = r.EstadoSocio,
                Activo = r.Activo,
                FechaRegistro = r.FechaRegistro
            });
        }

        public async Task<IEnumerable<ReporteRegistroViewModel>> ObtenerRegistrosAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerRegistrosAsync(inicio, fin);

            return dtos.Select(r => new ReporteRegistroViewModel
            {
                SocioID = r.SocioID,
                Clave = r.Clave,
                NombreCompleto = r.NombreCompleto,
                Telefono = r.Telefono,
                FechaRegistro = r.FechaRegistro
            });
        }

        public async Task<IEnumerable<ReporteVentaProductoViewModel>> ObtenerVentaProductosAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerVentaProductosAsync(inicio, fin);

            return dtos.Select(r => new ReporteVentaProductoViewModel
            {
                ProductoID = r.ProductoID,
                Producto = r.Producto,
                CantidadVendida = r.CantidadVendida,
                TotalRecaudado = r.TotalRecaudado
            });
        }

        public async Task<IEnumerable<ReporteVisitaViewModel>> ObtenerVisitasAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerVisitasAsync(inicio, fin);

            return dtos.Select(r => new ReporteVisitaViewModel
            {
                VisitaID = r.VisitaID,
                SocioID = r.SocioID,
                SocioNombre = r.SocioNombre,
                FechaHora = r.FechaHora,
                Observacion = r.Observacion
            });
        }

        public async Task<IEnumerable<ReportePagoMembresiaViewModel>> ObtenerPagosMembresiasAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerPagosMembresiasAsync(inicio, fin);

            return dtos.Select(r => new ReportePagoMembresiaViewModel
            {
                PagoID = r.PagoID,
                Socio = r.Socio,
                Membresia = r.Membresia,
                Monto = r.Monto,
                FormaPago = r.FormaPago,
                FechaPago = r.FechaPago
            });
        }

        public async Task<IEnumerable<ReporteMovimientoViewModel>> ObtenerMovimientosAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerMovimientosAsync(inicio, fin);

            return dtos.Select(r => new ReporteMovimientoViewModel
            {
                MovimientoID = r.MovimientoID,
                Tipo = r.Tipo,
                Concepto = r.Concepto,
                Total = r.Total,
                FormaPago = r.FormaPago,
                Usuario = r.Usuario,
                Fecha = r.Fecha
            });
        }
    }
}
