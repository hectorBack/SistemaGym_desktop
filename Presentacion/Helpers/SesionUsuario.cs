using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class SesionUsuario
    {
        public static int UsuarioID { get; set; }
        public static string NombreUsuario { get; set; } = string.Empty;
        public static string RolNombre { get; set; } = string.Empty;
        public static List<string> ModulosPermitidos { get; set; } = new();

        public static bool TienePermiso(string modulo)
        {
            // Los administradores tienen acceso total por defecto
            if (RolNombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                RolNombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return ModulosPermitidos.Contains(modulo, StringComparer.OrdinalIgnoreCase);
        }
    }
}
