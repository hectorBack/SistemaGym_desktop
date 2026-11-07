using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    /// <summary>
    /// Lee el logotipo del gimnasio guardado en la configuración (Gym_Logo): puede ser la ruta de un archivo
    /// o la imagen en Base64. Si no se puede leer devuelve null y el documento se genera sin logo.
    /// </summary>
    public static class LogoGimnasioHelper
    {
        public static byte[]? CargarBytes(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return null;

            try
            {
                string v = valor.Trim();
                if (File.Exists(v)) return File.ReadAllBytes(v);

                int marca = v.IndexOf("base64,", StringComparison.OrdinalIgnoreCase);
                if (marca >= 0) v = v.Substring(marca + 7);

                return Convert.FromBase64String(v);
            }
            catch
            {
                return null;
            }
        }
    }
}
