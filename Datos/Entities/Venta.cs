using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Venta : BaseEntity
    {
        public int VentaID { get; set; }
        public int UsuarioID { get; set; }
        public int? SocioID { get; set; } 
        public decimal Total { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;

        // Propiedad de navegación para el detalle
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
