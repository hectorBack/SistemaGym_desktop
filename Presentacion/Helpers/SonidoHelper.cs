using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class SonidoHelper
    {
        /// <summary>
        /// Reproduce un sonido corto de éxito al escanear un código de barras.
        /// </summary>
        public static void ReproducirEscaner()
        {
            try
            {
                // Reproduce un sonido limpio del sistema (puedes usar SystemSounds.Beep, Asterisk, Exclamation, etc.)
                SystemSounds.Hand.Play();
            }
            catch
            {
                // Evita que un problema de audio detenga la ejecución de la venta
            }
        }
    }
}
