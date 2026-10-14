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

        /// <summary>True si hay un usuario con la sesión iniciada.</summary>
        public static bool EstaAutenticado => UsuarioID > 0;

        /// <summary>Cierra la sesión: deja la clase sin ningún dato del usuario anterior.</summary>
        public static void Limpiar()
        {
            UsuarioID = 0;
            NombreUsuario = string.Empty;
            RolNombre = string.Empty;
            ModulosPermitidos = new List<string>();
        }

        public static bool TienePermiso(string modulo)
        {
            // Sin sesión no hay permisos.
            if (!EstaAutenticado) return false;

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
