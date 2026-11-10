using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface ICompraService
    {
        Task<IEnumerable<CompraDto>> ObtenerTodasAsync(string? estadoFiltro = "Activo");
        Task<CompraDto?> ObtenerPorIdAsync(int id);
        Task<CompraDto?> ObtenerPorCodigoAsync(string codigo);
        Task<IEnumerable<CompraDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<CompraDto> CrearAsync(CompraCreateDto dto);
        Task CancelarCompraAsync(int id, int usuarioId, string? motivo = null);
        Task EliminarLogicoAsync(int id, int usuarioId);
        Task<string> ObtenerSiguienteCodigoAsync();
        Task<IEnumerable<CompraDto>> ObtenerResumenPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
