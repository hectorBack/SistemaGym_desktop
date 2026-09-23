using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IMovimientoService
    {
        Task<IEnumerable<MovimientoDto>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<MovimientoDto?> ObtenerPorIdAsync(int id);
        Task<MovimientoDto> CrearAsync(MovimientoCreateDto dto);
        Task ActualizarAsync(MovimientoUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);
        Task<IEnumerable<MovimientoDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
