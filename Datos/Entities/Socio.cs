using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Socio : BaseEntity
    {
        public int SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Foto { get; set; }
        public string? Observaciones { get; set; }

        public virtual ICollection<SocioMembresia> SocioMembresias { get; set; } = new List<SocioMembresia>();
        public virtual ICollection<Visita> Visitas { get; set; } = new List<Visita>();
    }
}
