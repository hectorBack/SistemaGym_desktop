using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface ISocioService
    {
        Task<IEnumerable<SocioDto>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<SocioDto?> ObtenerPorIdAsync(int id);
        Task<SocioDto> CrearAsync(SocioCreateDto dto);
        Task ActualizarAsync(SocioUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);
        Task<string> ObtenerSiguienteClaveFormateadaAsync();
        Task<SocioDetalleDto?> ObtenerDetalleCompletoAsync(int socioId);

    }
}
