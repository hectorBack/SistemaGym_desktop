using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IMembresiaRepository
    {
        Task<IEnumerable<Membresia>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<Membresia?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Membresia membresia);
        void Actualizar(Membresia membresia);
        void EliminarLogico(Membresia membresia);
        void EliminarFisico(Membresia membresia);
        Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null);
    }
}
