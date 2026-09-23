using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class PagoSocioMembresia : BaseEntity
    {
        [Key]
        public int PagoID { get; set; }

        // Clave foránea
        public int SocioMembresiaID { get; set; }

        public decimal Monto { get; set; }
        public string? Folio { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public string? Observacion { get; set; }

        // Propiedad de navegación (Relación 1 a N)
        public virtual SocioMembresia SocioMembresia { get; set; } = null!;
    }
}
