using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<CategoriaDto?> ObtenerPorIdAsync(int id);
        Task<CategoriaDto> CrearAsync(CategoriaCreateDto dto);
        Task ActualizarAsync(CategoriaUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);
    }
}
