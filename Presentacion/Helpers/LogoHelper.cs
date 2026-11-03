using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class LogoHelper
    {
        private const string NombreLogo = "Logo horizontal2x (1).png";

        /// <summary>
        /// Devuelve el logo, o null si no se encuentra (nunca impide abrir la aplicación). Primero busca el archivo junto
        /// al programa (Forms\img) y, si no está, dentro del ejecutable (PNG con Acción de compilación = "Recurso incrustado").
        /// Quien lo reciba es responsable de liberarlo (Dispose).
        /// </summary>
        public static Image? Cargar()
        {
            try
            {
                string ruta = Path.Combine(AppContext.BaseDirectory, "Forms", "img", NombreLogo);
                if (File.Exists(ruta))
                {
                    // Se copia a memoria para no dejar el archivo bloqueado mientras la aplicación está abierta.
                    using var original = Image.FromFile(ruta);
                    return new Bitmap(original);
                }

                var ensamblado = typeof(LogoHelper).Assembly;
                string? recurso = ensamblado.GetManifestResourceNames().FirstOrDefault(n =>
                    n.EndsWith(NombreLogo, StringComparison.OrdinalIgnoreCase) ||
                    n.EndsWith(NombreLogo.Replace(' ', '_'), StringComparison.OrdinalIgnoreCase));

                if (recurso != null)
                {
                    using var flujo = ensamblado.GetManifestResourceStream(recurso)!;
                    using var original = Image.FromStream(flujo);
                    return new Bitmap(original);
                }

                System.Diagnostics.Debug.WriteLine($"No se encontró el logo. Se buscó en: {ruta}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"No se pudo cargar el logo: {ex.Message}");
            }

            return null;
        }
    }
}
