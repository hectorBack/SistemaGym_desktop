using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class SocioMembresiaDto
    {
        public int SocioMembresiaID { get; set; }
        public int SocioID { get; set; }
        public int MembresiaID { get; set; }
        public string? NombreMembresia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
        public decimal TotalPagado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Estado { get; set; } = "Activa";
    }

    public class AsignarMembresiaDto
    {
        public int SocioID { get; set; }
        public int MembresiaID { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public decimal Precio { get; set; }
    }
}
