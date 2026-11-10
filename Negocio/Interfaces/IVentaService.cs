using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IVentaService
    {
        Task<IEnumerable<VentaDto>> ObtenerTodasAsync(string? estadoFiltro = "Activo");
        Task<VentaDto?> ObtenerPorIdAsync(int id);
        Task<VentaDto> CrearAsync(VentaCreateDto dto);
        Task CancelarVentaAsync(int id, int usuarioId, string? motivo = null); // Anular venta
        Task EliminarLogicoAsync(int id, int usuarioId);

        // --- MÉTODOS ADICIONALES DE NEGOCIO PARA VENTAS ---
        Task<IEnumerable<VentaDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);

        Task<IEnumerable<VentaDto>> ObtenerResumenPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<IEnumerable<VentaDto>> ObtenerPorSocioIdAsync(int socioId);
    }
}
