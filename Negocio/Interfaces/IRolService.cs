using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<RolDto>> ObtenerTodasAsync(bool incluirInactivos = false);
        Task<RolDto?> ObtenerPorIdAsync(int id);
        Task<RolDto> CrearAsync(RolCreateDto dto);
        Task ActualizarAsync(RolUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);
    }
}
