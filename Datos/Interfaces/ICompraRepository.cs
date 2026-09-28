using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface ICompraRepository
    {
        Task<IEnumerable<Compra>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<Compra?> ObtenerPorIdAsync(int id);
        Task<Compra?> ObtenerPorCodigoAsync(string codigo);
        Task<IEnumerable<Compra>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task AgregarAsync(Compra compra);
        void Actualizar(Compra compra);
        void EliminarFisico(Compra compra);
        void EliminarLogico(Compra compra);
        Task<bool> ExisteCodigoAsync(string codigo, int? idExcluir = null);
        Task<string> GenerarSiguienteCodigoAsync();
    }
}
