using Datos.Interfaces;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Negocio.DTOs.ReporteDto;

namespace Negocio.Services
{
    public class ReporteService : IReporteService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ReporteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ReporteInventarioDto>> ObtenerInventarioAsync()
        {
            var productos = await _unitOfWork.Producto.ObtenerTodasAsync(incluirInactivas: true);

            return productos.Select(p => new ReporteInventarioDto
            {
                ProductoID = p.ProductoID,
                Codigo = p.CodigoBarras ?? string.Empty,
                Producto = p.Nombre,
                Categoria = p.Categoria != null ? p.Categoria.Nombre : "Sin Categoría",
                StockActual = p.Stock,
                PrecioCompra = p.Costo,
                PrecioVenta = p.Precio,
                Activo = p.Activo
            });
        }

        public async Task<IEnumerable<ReporteMembresiaDto>> ObtenerMembresiasAsync(DateTime inicio, DateTime fin)
        {
            ValidarRangoFechas(inicio, fin);

            // Consultamos la tabla SocioMembresia por rango de fechas de contratación
            var socioMembresias = await _unitOfWork.SocioMembresia.ObtenerPorRangoFechasAsync(inicio, fin);

            return socioMembresias
                .Where(sm => sm.Activo)
                .Select(sm =>
                {
                    decimal precio = sm.Membresia?.Precio ?? 0;
                    decimal totalAbonado = sm.Pagos != null
                        ? sm.Pagos.Where(p => p.Activo).Sum(p => p.Monto)
                        : 0;

                    // Determinar el estado exacto de la membresía vendida
                    string estado = "Sin Pagar";
                    if (totalAbonado >= precio && precio > 0)
                    {
                        estado = "Pagada";
                    }
                    else if (totalAbonado > 0)
                    {
                        estado = "Parcial";
                    }

                    return new ReporteMembresiaDto
                    {
                        SocioMembresiaID = sm.SocioMembresiaID,
                        Membresia = sm.Membresia?.Nombre ?? "N/A",
                        Socio = sm.Socio != null ? $"{sm.Socio.Nombre} {sm.Socio.Apellido}".Trim() : "N/A",
                        FechaRegistro = sm.CreatedAt,
                        FechaInicio = sm.FechaInicio,
                        Vencimiento = sm.FechaFin,
                        Precio = precio,
                        TotalAbonado = totalAbonado,
                        EstadoMembresia = estado
                    };
                });
        }

        public async Task<IEnumerable<ReporteMovimientoDto>> ObtenerMovimientosAsync(DateTime inicio, DateTime fin)
        {
            ValidarRangoFechas(inicio, fin);
            var movimientos = await _unitOfWork.Movimiento.ObtenerPorRangoFechasAsync(inicio, fin);

            return movimientos
                .Where(m => m.Activo)
                .Select(m => new ReporteMovimientoDto
                {
                    MovimientoID = m.MovimientoID,
                    Tipo = m.Tipo,
                    Concepto = m.Concepto != null ? m.Concepto.Nombre : "Sin Concepto",
                    Total = m.Total,
                    FormaPago = m.FormaPago,
                    Usuario = $"Usuario #{m.UsuarioID}",
                    Fecha = m.CreatedAt
                });
        }

        public async Task<IEnumerable<ReportePagoMembresiaDto>> ObtenerPagosMembresiasAsync(DateTime inicio, DateTime fin)
        {
            ValidarRangoFechas(inicio, fin);
            var pagos = await _unitOfWork.PagoSocioMembresia.ObtenerPorRangoFechasAsync(inicio, fin);

            var resultado = new List<ReportePagoMembresiaDto>();

            foreach (var p in pagos.Where(p => p.Activo))
            {
                // Consultamos el acumulado real abonado a esta membresía específica
                decimal acumuladoPagado = await _unitOfWork.PagoSocioMembresia
                    .ObtenerTotalPagadoPorSocioMembresiaIdAsync(p.SocioMembresiaID);

                resultado.Add(new ReportePagoMembresiaDto
                {
                    PagoID = p.PagoID,
                    SocioMembresiaID = p.SocioMembresiaID,
                    Socio = p.SocioMembresia?.Socio != null
                        ? $"{p.SocioMembresia.Socio.Nombre} {p.SocioMembresia.Socio.Apellido}".Trim()
                        : "N/A",
                    Membresia = p.SocioMembresia?.Membresia != null
                        ? p.SocioMembresia.Membresia.Nombre
                        : "N/A",
                    Monto = p.Monto,
                    TotalPagado = acumuladoPagado, // <--- Asigna los $300.00 acumulados reales
                    PrecioMembresia = p.SocioMembresia?.Membresia != null
                        ? p.SocioMembresia.Membresia.Precio
                        : p.Monto,
                    FormaPago = p.FormaPago ?? "Efectivo",
                    FechaPago = p.CreatedAt
                });
            }

            return resultado;
        }

        public async Task<IEnumerable<ReporteRegistroDto>> ObtenerRegistrosAsync(DateTime inicio, DateTime fin)
        {
            ValidarRangoFechas(inicio, fin);
            var socios = await _unitOfWork.Socio.ObtenerPorRangoFechasAsync(inicio, fin);

            return socios.Select(s => new ReporteRegistroDto
            {
                SocioID = s.SocioID,
                Clave = s.Clave ?? string.Empty,
                NombreCompleto = $"{s.Nombre} {s.Apellido}".Trim(),
                Telefono = s.Telefono ?? string.Empty,
                FechaRegistro = s.CreatedAt
            });
        }

        public async Task<IEnumerable<ReporteSocioDto>> ObtenerSociosAsync()
        {
            var socios = await _unitOfWork.Socio.ObtenerTodosAsync(incluirInactivos: true);

            return socios.Select(s => new ReporteSocioDto
            {
                SocioID = s.SocioID,
                Clave = s.Clave ?? string.Empty,
                NombreCompleto = $"{s.Nombre} {s.Apellido}".Trim(),
                Telefono = s.Telefono ?? string.Empty,
                EstadoSocio = s.Activo ? "Activo" : "Inactivo",
                Activo = s.Activo,
                FechaRegistro = s.CreatedAt
            });
        }

        public async Task<IEnumerable<ReporteVentaProductoDto>> ObtenerVentaProductosAsync(DateTime inicio, DateTime fin)
        {
            ValidarRangoFechas(inicio, fin);
            var ventas = await _unitOfWork.Venta.ObtenerPorRangoFechasAsync(inicio, fin);

            // Filtrar solo las ventas completadas/activas y agrupar sus detalles por producto
            return ventas
                .Where(v => v.Activo)
                .SelectMany(v => v.Detalles)
                .GroupBy(d => new { d.ProductoID, Nombre = d.Producto != null ? d.Producto.Nombre : "Producto " + d.ProductoID })
                .Select(g => new ReporteVentaProductoDto
                {
                    ProductoID = g.Key.ProductoID,
                    Producto = g.Key.Nombre,
                    CantidadVendida = g.Sum(d => d.Cantidad),
                    TotalRecaudado = g.Sum(d => d.Subtotal)
                });
        }

        public async Task<IEnumerable<ReporteVisitaDto>> ObtenerVisitasAsync(DateTime inicio, DateTime fin)
        {
            ValidarRangoFechas(inicio, fin);
            var visitas = await _unitOfWork.Visita.ObtenerPorRangoFechasAsync(inicio, fin);

            return visitas.Select(v => new ReporteVisitaDto
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                SocioNombre = v.Socio != null ? $"{v.Socio.Nombre} {v.Socio.Apellido}".Trim() : "Visitante General",
                FechaHora = v.CreatedAt,
                Observacion = v.Observaciones ?? string.Empty
            });
        }

        #region Métodos Privados
        private void ValidarRangoFechas(DateTime inicio, DateTime fin)
        {
            if (inicio > fin)
            {
                throw new BusinessException("La fecha de inicio no puede ser posterior a la fecha de fin.");
            }
        }
        #endregion
    }
}
