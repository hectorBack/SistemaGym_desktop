using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Negocio.DTOs.ReporteDto;

namespace Negocio.Interfaces
{
    public interface IReporteService
    {
        Task<IEnumerable<ReporteInventarioDto>> ObtenerInventarioAsync();
        Task<IEnumerable<ReporteMembresiaDto>> ObtenerMembresiasAsync();
        Task<IEnumerable<ReporteSocioDto>> ObtenerSociosAsync();
        Task<IEnumerable<ReporteRegistroDto>> ObtenerRegistrosAsync(DateTime inicio, DateTime fin);
        Task<IEnumerable<ReporteVentaProductoDto>> ObtenerVentaProductosAsync(DateTime inicio, DateTime fin);
        Task<IEnumerable<ReporteVisitaDto>> ObtenerVisitasAsync(DateTime inicio, DateTime fin);
        Task<IEnumerable<ReportePagoMembresiaDto>> ObtenerPagosMembresiasAsync(DateTime inicio, DateTime fin);
        Task<IEnumerable<ReporteMovimientoDto>> ObtenerMovimientosAsync(DateTime inicio, DateTime fin);
    }
}
