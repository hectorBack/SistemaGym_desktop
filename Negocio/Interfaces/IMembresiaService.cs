using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IMembresiaService
    {
        Task<IEnumerable<MembresiaDto>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<MembresiaDto?> ObtenerPorIdAsync(int id);
        Task<MembresiaDto> CrearAsync(MembresiaCreateDto dto);
        Task ActualizarAsync(MembresiaUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);
    }
}
