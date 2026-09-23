using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class SocioViewModel
    {
        public int SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Foto { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
        public DateTime? CreatedAt { get; set; }
    }
}
