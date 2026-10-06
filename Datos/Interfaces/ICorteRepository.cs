using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface ICorteRepository
    {
        Task<IEnumerable<Corte>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<Corte?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Corte corte);
        void Actualizar(Corte corte);
        void EliminarLogico(Corte corte);
        void EliminarFisico(Corte corte);

        // Métodos específicos para la gestión de cortes de caja
        Task<Corte?> ObtenerCorteAbiertoPorUsuarioAsync(int usuarioId);
        Task<bool> TieneCorteAbiertoAsync(int usuarioId);
        Task<IEnumerable<Corte>> ObtenerPorRangoFechasAsync(DateTime inicio, DateTime fin);
        Task<decimal> ObtenerEfectivoEnCajaAsync();
    }
}
