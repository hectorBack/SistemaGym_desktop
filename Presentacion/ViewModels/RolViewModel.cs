using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class RolViewModel
    {
        public int RolID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public List<string> ModulosPermitidos { get; set; } = new();
        public string ModulosTexto => ModulosPermitidos != null && ModulosPermitidos.Any()
            ? string.Join(", ", ModulosPermitidos)
            : "Ninguno";
        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
        public DateTime? CreatedAt { get; set; }
    }
}
