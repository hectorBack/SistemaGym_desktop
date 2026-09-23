using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IVisitaRepository
    {
        Task<IEnumerable<Visita>> ObtenerTodasAsync();
        Task<IEnumerable<Visita>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<Visita?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Visita>> ObtenerPorSocioIdAsync(int socioId);
        Task AgregarAsync(Visita visita);
        void Actualizar(Visita visita);
        void EliminarFisico(Visita visita);

        Task<IEnumerable<Visita>> ObtenerPorSocioYFechasAsync(int socioId, DateTime inicioSemana, DateTime finSemana);

        Task<List<Visita>> ObtenerVisitasPorSocioYFechasAsync(int socioId, DateTime desde, DateTime hasta);
        Task<bool> EliminarPorIdAsync(int id);
    }
}
