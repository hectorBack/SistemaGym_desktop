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
        Task<IEnumerable<VentaDto>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<VentaDto?> ObtenerPorIdAsync(int id);
        Task<VentaDto> CrearAsync(VentaCreateDto dto);
        Task EliminarLogicoAsync(int id); // Anular venta
        Task EliminarFisicoAsync(int id);

        // --- MÉTODOS ADICIONALES DE NEGOCIO PARA VENTAS ---
        Task<IEnumerable<VentaDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<IEnumerable<VentaDto>> ObtenerPorSocioIdAsync(int socioId);
    }
}
