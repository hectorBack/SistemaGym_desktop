using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IVisitaService
    {
        Task<IEnumerable<VisitaDto>> ObtenerTodasAsync();
        Task<IEnumerable<VisitaDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<VisitaDto?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<VisitaDto>> ObtenerPorSocioIdAsync(int socioId);
        Task<VisitaDto> RegistrarVisitaAsync(VisitaCreateDto dto, int? usuarioIdSesion = null);
        Task ActualizarAsync(VisitaUpdateDto dto);
        Task EliminarFisicoAsync(int id);

        Task<AccesoResultadoDto> ProcesarAccesoRapidoAsync(string clave, int usuarioIdSesion);

        Task<IEnumerable<VisitaDto>> ObtenerPorSocioYFechasAsync(int socioId, DateTime desde, DateTime hasta);

        Task CancelarVisitaAsync(int id, int usuarioId, string? motivo = null);
    }
}
