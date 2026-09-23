using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IMovimientoRepository
    {
        Task<IEnumerable<Movimiento>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<Movimiento?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Movimiento movimiento);
        void Actualizar(Movimiento movimiento);
        void EliminarLogico(Movimiento movimiento);
        void EliminarFisico(Movimiento movimiento);

        Task<IEnumerable<Movimiento>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
