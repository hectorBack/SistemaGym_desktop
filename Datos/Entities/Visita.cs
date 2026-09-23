using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Visita : BaseEntity
    {
        public int VisitaID { get; set; }
        public int? SocioID { get; set; }
        public int? MembresiaID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public decimal MontoPagado { get; set; } = 0.00m;
        public string TipoAcceso { get; set; } = "Visita Casual";
        public string? Observaciones { get; set; }

        // Propiedades de navegación (Entity Framework)
        public virtual Socio? Socio { get; set; }
        public virtual Membresia? Membresia { get; set; }
    }
}
