using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IConceptoService
    {
        Task<IEnumerable<ConceptoDto>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<ConceptoDto?> ObtenerPorIdAsync(int id);
        Task<ConceptoDto> CrearAsync(ConceptoCreateDto dto);
        Task ActualizarAsync(ConceptoUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);
    }
}
