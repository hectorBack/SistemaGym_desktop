using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Producto producto);
        void Actualizar(Producto producto);
        void EliminarLogico(Producto producto);
        void EliminarFisico(Producto producto);
        Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null);
        Task<bool> ExisteCodigoBarrasAsync(string codigoBarras, int? idExcluir = null);
        Task<Producto?> ObtenerPorCodigoBarrasAsync(string codigoBarras);
    }
}
