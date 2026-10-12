using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class RolesSistema
    {
        public static bool EsAdministrador(string? nombreRol)
        {
            string nombre = nombreRol?.Trim() ?? string.Empty;

            return nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase)
                || nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }
    }
}
