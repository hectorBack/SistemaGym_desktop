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
        Task<IEnumerable<CompraDto>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<CompraDto?> ObtenerPorIdAsync(int id);
        Task<CompraDto?> ObtenerPorCodigoAsync(string codigo);
        Task<IEnumerable<CompraDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<CompraDto> CrearAsync(CompraCreateDto dto);
        Task CancelarCompraAsync(int id, string? observacion = null);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);
        Task<string> ObtenerSiguienteCodigoAsync();
    }
}
