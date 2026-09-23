using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class UsuarioDto
    {
        public int UsuarioID { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public int RolID { get; set; }
        public string RolNombre { get; set; } = string.Empty;
        public List<string> ModulosPermitidos { get; set; } = new();
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class UsuarioCreateDto
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RolID { get; set; }
    }

    public class UsuarioUpdateDto
    {
        public int UsuarioID { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string? Password { get; set; } // Opcional al editar: solo si se desea cambiar
        public int RolID { get; set; }
        public bool Activo { get; set; }
    }
}
