using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class RolDto
    {
        public int RolID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public List<string> ModulosPermitidos { get; set; } = new();
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class RolCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public List<string> ModulosPermitidos { get; set; } = new();
    }

    public class RolUpdateDto
    {
        public int RolID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public List<string> ModulosPermitidos { get; set; } = new();
        public bool Activo { get; set; }
    }
}
