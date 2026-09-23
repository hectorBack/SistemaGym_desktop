using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Usuario : BaseEntity
    {
        public int UsuarioID { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty; // Mapea a 'Usuario' en SQL
        public string Password { get; set; } = string.Empty;
        public int RolID { get; set; }
        public virtual Rol Rol { get; set; } = null!;
    }
}
