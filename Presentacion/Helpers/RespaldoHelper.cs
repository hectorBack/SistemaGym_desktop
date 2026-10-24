using Datos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                string nombreArchivo = $"gym_{hoy:yyyyMMdd_HHmmss}.sql";
                string rutaCompleta = Path.Combine(rutaDestino, nombreArchivo);

                // 1. Obtener la cadena de conexión desde tu clase Conexion
                var conexionDatos = new Conexion();
                string connectionString = string.Empty;

                using (var conn = conexionDatos.ObtenerConexion())
                {
                    connectionString = conn.ConnectionString;
                }

                // 2. Valores por defecto (puerto 3308 para tu XAMPP)
                string servidor = "localhost";
                string puerto = "3308";
                string usuario = "root";
                string password = string.Empty;
                string nombreBaseDatos = "bd_gym";

                // 3. Extraer los parámetros reales de la cadena de conexión
                foreach (var parte in connectionString.Split(';', StringSplitOptions.RemoveEmptyEntries))
                {
                    var kv = parte.Split('=', 2);
                    if (kv.Length == 2)
                    {
                        string clave = kv[0].Trim().ToLower();
                        string valor = kv[1].Trim();

                        if (clave == "server" || clave == "data source") servidor = valor;
                        else if (clave == "port") puerto = valor;
                        else if (clave == "database" || clave == "initial catalog") nombreBaseDatos = valor;
                        else if (clave == "uid" || clave == "user id") usuario = valor;
                        else if (clave == "pwd" || clave == "password") password = valor;
                    }
                }

                // 4. Buscar la ruta de mysqldump.exe (priorizando XAMPP)
                string rutaMysqldump = @"C:\xampp\mysql\bin\mysqldump.exe";

                if (!File.Exists(rutaMysqldump))
                {
                    string rutaAlternativa1 = @"C:\Program Files\MySQL\MySQL Workbench 8.0 CE\mysqldump.exe";

                    if (File.Exists(rutaAlternativa1))
                        rutaMysqldump = rutaAlternativa1;
                    else
                    {
                        throw new Exception("No se encontró el ejecutable 'mysqldump.exe' en XAMPP ni en las rutas predeterminadas.");
                    }
                }

                // 5. Configurar argumentos para mysqldump
                string argumentos = string.IsNullOrEmpty(password)
                    ? $"-h{servidor} -P{puerto} -u{usuario} {nombreBaseDatos}"
                    : $"-h{servidor} -P{puerto} -u{usuario} -p{password} {nombreBaseDatos}";

                var startInfo = new ProcessStartInfo
                {
                    FileName = rutaMysqldump,
                    Arguments = argumentos,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // 6. Ejecutar el proceso y guardar el archivo .sql real
                using (var proceso = Process.Start(startInfo))
                {
                    if (proceso == null)
                        throw new Exception("No se pudo iniciar el proceso de respaldo de MySQL.");

                    using (var lector = proceso.StandardOutput)
                    {
                        string resultadoSql = await lector.ReadToEndAsync();

                        if (string.IsNullOrWhiteSpace(resultadoSql))
                        {
                            throw new Exception("El volcado de la base de datos devolvió un resultado vacío.");
                        }

                        await File.WriteAllTextAsync(rutaCompleta, resultadoSql);
                    }

                    proceso.WaitForExit();

                    if (proceso.ExitCode != 0)
                    {
                        throw new Exception("El comando mysqldump finalizó con un código de error.");
                    }
                }

                _ultimoRespaldoEjecutado = DateTime.Now;

                // Lanzar Notificación de Windows
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
