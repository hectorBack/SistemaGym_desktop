using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface ITicketService
    {

        /// <summary>
        /// Imprime el ticket de una venta con la configuración de la pestaña Ticket.
        /// Devuelve false (sin imprimir) si la impresora está deshabilitada en la configuración.
        /// </summary>
        Task<bool> ImprimirTicketVentaAsync(int ventaId);

        /// <summary>
        /// Imprime el comprobante de un pago de membresía con la configuración de la pestaña Ticket.
        /// Devuelve false (sin imprimir) si la impresora está deshabilitada en la configuración.
        /// </summary>
        Task<bool> ImprimirTicketPagoMembresiaAsync(int pagoId);
    }
}
