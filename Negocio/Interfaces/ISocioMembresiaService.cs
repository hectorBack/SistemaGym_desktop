using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface ISocioMembresiaService
    {
        Task<IEnumerable<SocioMembresiaDto>> ObtenerPorSocioIdAsync(int socioId);
        Task<SocioMembresiaDto?> ObtenerPorIdAsync(int id);
        Task<SocioMembresiaDto?> ObtenerMembresiaActivaPorSocioIdAsync(int socioId);
        Task<SocioMembresiaDto> AsignarMembresiaAsync(AsignarMembresiaDto dto);
        Task CancelarMembresiaAsync(int socioMembresiaId);
        Task EliminarAsync(int id);
    }
}
