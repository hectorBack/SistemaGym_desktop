using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IPagoSocioMembresiaRepository
    {
        Task<IEnumerable<PagoSocioMembresia>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<PagoSocioMembresia?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(PagoSocioMembresia pago);
        void Actualizar(PagoSocioMembresia pago);
        void EliminarLogico(PagoSocioMembresia pago);
        void EliminarFisico(PagoSocioMembresia pago);

        // Métodos específicos para la gestión de pagos de membresía
        Task<IEnumerable<PagoSocioMembresia>> ObtenerPorSocioMembresiaIdAsync(int socioMembresiaId, bool incluirInactivos = false);
        Task<decimal> ObtenerTotalPagadoPorSocioMembresiaIdAsync(int socioMembresiaId);
        Task<bool> ExisteFolioAsync(string folio, int? idExcluir = null);
    }
}
