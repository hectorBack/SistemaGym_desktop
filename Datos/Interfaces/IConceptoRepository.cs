using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IConceptoRepository
    {
        Task<IEnumerable<Concepto>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<Concepto?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Concepto concepto);
        void Actualizar(Concepto concepto);
        void EliminarLogico(Concepto concepto);
        void EliminarFisico(Concepto concepto);
        Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null);
    }
}
