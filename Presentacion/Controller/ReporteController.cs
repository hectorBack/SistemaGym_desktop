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

        public async Task<IEnumerable<ReporteMembresiaViewModel>> ObtenerMembresiasAsync(DateTime inicio, DateTime fin)
        {
            // Pasamos el rango de fechas al servicio
            var dtos = await _reporteService.ObtenerMembresiasAsync(inicio, fin);

            return dtos.Select(r => new ReporteMembresiaViewModel
            {
                SocioMembresiaID = r.SocioMembresiaID,
                Membresia = r.Membresia,
                Socio = r.Socio,
                FechaRegistro = r.FechaRegistro,
                FechaInicio = r.FechaInicio,
                Vencimiento = r.Vencimiento,
                Precio = r.Precio,
                TotalAbonado = r.TotalAbonado,
                EstadoMembresia = r.EstadoMembresia
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
                FechaVencimiento = r.FechaVencimiento,
                Estatus = r.Estatus
            });
        }

        public async Task<IEnumerable<ReporteRegistroViewModel>> ObtenerRegistrosAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerRegistrosAsync(inicio, fin);

            return dtos.Select(r => new ReporteRegistroViewModel
            {
                SocioID = r.SocioID,
                NombreCompleto = r.NombreCompleto,
                FechaRegistro = r.FechaRegistro
            });
        }

        public async Task<IEnumerable<ReporteVentaProductoViewModel>> ObtenerVentaProductosAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerVentaProductosAsync(inicio, fin);

            return dtos.Select(r => new ReporteVentaProductoViewModel
            {
                ProductoID = r.ProductoID,
                FechaRegistro = r.FechaRegistro.ToString("dd/MM/yyyy HH:mm"),
                Producto = r.Producto,
                CantidadVendida = r.Cantidad,
                CostoUnitario = r.CostoUnitario.ToString("C2"),
                PrecioUnitario = r.PrecioUnitario.ToString("C2"),
                Ganancia = r.Ganancia.ToString("C2")
            });
        }

        public async Task<IEnumerable<ReporteVisitaViewModel>> ObtenerVisitasAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerVisitasAsync(inicio, fin);

            return dtos.Select(r => new ReporteVisitaViewModel
            {
                VisitaID = r.VisitaID,
                SocioID = r.SocioID,
                Nombre = r.Nombre,
                Monto = r.Monto,
                FechaHora = r.FechaHora
            });
        }

        public async Task<IEnumerable<ReportePagoMembresiaViewModel>> ObtenerPagosMembresiasAsync(DateTime inicio, DateTime fin)
        {
            var dtos = await _reporteService.ObtenerPagosMembresiasAsync(inicio, fin);

            return dtos.Select(p => new ReportePagoMembresiaViewModel
            {
                PagoID = p.PagoID,
                SocioMembresiaID = p.SocioMembresiaID,
                Socio = p.Socio,
                Membresia = p.Membresia,
                FechaInicio = p.FechaInicio,
                Folio = p.Folio ?? "N/A",
                Observaciones = p.Observaciones ?? "N/A",
                Monto = p.Monto,
                TotalPagado = p.TotalPagado,
                PrecioMembresia = p.PrecioMembresia,
                FormaPago = p.FormaPago,
                FechaPago = p.FechaPago
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
