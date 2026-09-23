using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> ObtenerTodasAsync(bool incluirInactivos = false);
        Task<Rol?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Rol rol);
        void Actualizar(Rol rol);
        void EliminarLogico(Rol rol);
        void EliminarFisico(Rol rol);
        Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null);
    }
}
