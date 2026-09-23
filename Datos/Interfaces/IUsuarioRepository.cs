using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ValidarLoginAsync(string nombreUsuario, string password);
        Task<IEnumerable<Usuario>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Usuario usuario);
        void Actualizar(Usuario usuario);
        void EliminarLogico(Usuario usuario);
        void EliminarFisico(Usuario usuario);
        Task<bool> ExisteNombreUsuarioAsync(string nombreUsuario, int? idExcluir = null);
        Task<Usuario?> ObtenerPorNombreUsuarioAsync(string nombreUsuario);
       
    }
}
