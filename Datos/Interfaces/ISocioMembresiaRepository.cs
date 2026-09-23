using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface ISocioMembresiaRepository
    {
        Task<IEnumerable<SocioMembresia>> ObtenerPorSocioIdAsync(int socioId);
        Task<SocioMembresia?> ObtenerPorIdAsync(int id);
        Task<SocioMembresia?> ObtenerMembresiaActivaPorSocioIdAsync(int socioId);
        Task AgregarAsync(SocioMembresia socioMembresia);
        void Actualizar(SocioMembresia socioMembresia);
        void Eliminar(SocioMembresia socioMembresia);
    }
}
