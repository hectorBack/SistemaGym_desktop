using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<Categoria?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Categoria categoria);
        void Actualizar(Categoria categoria);
        void EliminarLogico(Categoria categoria);
        void EliminarFisico(Categoria categoria);
        Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null);
    }
}
