using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface ICorteService
    {
        Task<IEnumerable<CorteDto>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<CorteDto?> ObtenerPorIdAsync(int id);
        Task<CorteDto> AbrirCorteAsync(CorteCreateDto dto);
        Task CerrarCorteAsync(CorteUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);

        // Métodos de negocio específicos del módulo de Corte
        Task<CorteDto?> ObtenerCorteAbiertoPorUsuarioAsync(int usuarioId);
        Task<IEnumerable<CorteDto>> ObtenerPorRangoFechasAsync(DateTime inicio, DateTime fin);
        Task<decimal> ObtenerEfectivoEnCajaAsync();
    }
}
