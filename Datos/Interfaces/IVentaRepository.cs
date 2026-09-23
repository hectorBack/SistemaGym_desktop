using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IVentaRepository
    {
        /// <summary>
        /// Obtiene el historial de ventas con opción de incluir anuladas/inactivas.
        /// </summary>
        Task<IEnumerable<Venta>> ObtenerTodasAsync(bool incluirInactivas = false);

        /// <summary>
        /// Obtiene una venta por su ID incluyendo sus detalles, usuario y socio asociados.
        /// </summary>
        Task<Venta?> ObtenerPorIdAsync(int id);

        /// <summary>
        /// Registra la cabecera de la venta.
        /// </summary>
        Task AgregarAsync(Venta venta);

        /// <summary>
        /// Modifica los datos de una venta (ej. estado o total).
        /// </summary>
        void Actualizar(Venta venta);

        /// <summary>
        /// Anula lógicamente una venta (Activo = false).
        /// </summary>
        void EliminarLogico(Venta venta);

        /// <summary>
        /// Elimina físicamente el registro de la venta.
        /// </summary>
        void EliminarFisico(Venta venta);

        // --- MÉTODOS ESPECÍFICOS DE VENTAS ---

        /// <summary>
        /// Verifica si existe al menos un registro de venta asociado a un producto específico.
        /// </summary>
        Task<bool> ExisteProductoEnVentasAsync(int productoId);

        /// <summary>
        /// Consulta ventas filtradas por un rango de fechas.
        /// </summary>
        Task<IEnumerable<Venta>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);

        /// <summary>
        /// Obtiene el historial de compras realizadas por un socio en particular.
        /// </summary>
        Task<IEnumerable<Venta>> ObtenerPorSocioIdAsync(int socioId);
    }

}
