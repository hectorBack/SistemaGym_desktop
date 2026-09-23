using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class SocioMembresia : BaseEntity
    {
        public int SocioMembresiaID { get; set; }
        public int SocioID { get; set; }
        public int MembresiaID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = "Activa";

        // Propiedades de navegación
        public Socio? Socio { get; set; }
        public Membresia? Membresia { get; set; }

        public virtual ICollection<PagoSocioMembresia> Pagos { get; set; } = new List<PagoSocioMembresia>();
    }
}
