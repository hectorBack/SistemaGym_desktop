using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class VisitaDto
    {
        public int VisitaID { get; set; }
        public int? SocioID { get; set; }
        public int? MembresiaID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public decimal MontoPagado { get; set; }
        public string TipoAcceso { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public string? NombreMembresia { get; set; }
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class VisitaCreateDto
    {
        public string Clave { get; set; } = string.Empty; // "100" para visita casual o la clave del socio
        public int? MembresiaID { get; set; }             // Opcional/Requerido para visita casual
        public string? Nombre { get; set; }               // Requerido si Clave == "100"
        public string? Apellido { get; set; }             // Opcional
        public string? Telefono { get; set; }             // Opcional
        public string? Observaciones { get; set; }
    }

    public class VisitaUpdateDto
    {
        public int VisitaID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}
