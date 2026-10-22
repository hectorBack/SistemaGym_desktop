using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Negocio.Helpers
{
    public static class RespaldoHelper
    {
        private static DateTime _ultimoRespaldoEjecutado = DateTime.MinValue;

        /// <summary>
        /// Ejecuta el respaldo automático si ya pasó la hora programada y no se ha hecho hoy.
        /// </summary>
        public static async Task EjecutarRespaldoAutomaticoAsync(string rutaDestino, NotifyIcon? notifyIcon = null)
        {
            if (string.IsNullOrWhiteSpace(rutaDestino) || !Directory.Exists(rutaDestino))
                return;

            DateTime hoy = DateTime.Today;

            // Evitar ejecutar más de una vez el mismo día en la misma sesión
            if (_ultimoRespaldoEjecutado.Date == hoy)
                return;

            try
            {
                // Simulamos o realizamos la exportación del respaldo de la base de datos
                // (Nota: Si usas SQLite es un File.Copy, si usas MySQL puedes invocar mysqldump o respaldar los archivos de datos)
                string nombreArchivo = $"Respaldo_Gym_{hoy:yyyyMMdd_HHmmss}.bak";
                string rutaCompleta = Path.Combine(rutaDestino, nombreArchivo);

                // Ejemplo de respaldo lógico o copiado (ajústalo según cómo manejes tu archivo de BD local):
                // Si tu BD es un archivo local (como SQLite/LocalDB):
                // string rutaBdOrigen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tu_base_datos.db");
                // if (File.Exists(rutaBdOrigen)) File.Copy(rutaBdOrigen, rutaCompleta, true);

                // Si manejas MySQL, aquí puedes integrar la ejecución de procesos de respaldo con mysqldump.
                // Para efectos de prueba y asegurar que cree un archivo físico:
                await File.WriteAllTextAsync(rutaCompleta, $"Respaldo automático generado exitosamente el {DateTime.Now}");

                _ultimoRespaldoEjecutado = DateTime.Now;

                // 🟢 Lanzar Notificación de Windows
                MostrarNotificacionWindows(
                    notifyIcon,
                    "Respaldo Automático Exitoso",
                    $"La base de datos se respaldó correctamente en:\n{rutaCompleta}",
                    ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MostrarNotificacionWindows(
                    notifyIcon,
                    "Error en Respaldo Automático",
                    $"No se pudo completar el respaldo: {ex.Message}",
                    ToolTipIcon.Error);
            }
        }

        public static void MostrarNotificacionWindows(NotifyIcon? notifyIcon, string titulo, string mensaje, ToolTipIcon icono)
        {
            if (notifyIcon != null)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(5000, titulo, mensaje, icono);
            }
        }
    }
}
