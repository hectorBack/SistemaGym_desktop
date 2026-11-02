using Datos;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using System.Diagnostics;
using System.Globalization;

namespace Negocio.Services
{
    public class RespaldoService : IRespaldoService
    {
        private readonly IValidator<RespaldoManualDto> _validadorRespaldo;
        private readonly IValidator<RestaurarManualDto> _validadorRestaurar;

        public RespaldoService(
            IValidator<RespaldoManualDto> validadorRespaldo,
            IValidator<RestaurarManualDto> validadorRestaurar)
        {
            _validadorRespaldo = validadorRespaldo ?? throw new ArgumentNullException(nameof(validadorRespaldo));
            _validadorRestaurar = validadorRestaurar ?? throw new ArgumentNullException(nameof(validadorRestaurar));
        }

        public async Task GenerarRespaldoManualAsync(RespaldoManualDto dto)
        {
            var valResult = await _validadorRespaldo.ValidateAsync(dto);
            if (!valResult.IsValid)
            {
                throw new BusinessException(string.Join(" ", valResult.Errors.Select(e => e.ErrorMessage)));
            }

            try
            {
                string nombreArchivo = $"gym_{DateTime.Now.ToString("yyyyMMdd_HHmmss_fff", CultureInfo.InvariantCulture)}_{Guid.NewGuid():N}.sql";
                string rutaArchivo = Path.Combine(dto.RutaDestino, nombreArchivo);

                var conexionDatos = new Conexion();
                string connectionString = string.Empty;

                using (var conn = conexionDatos.ObtenerConexion())
                {
                    connectionString = conn.ConnectionString;
                }

                string servidor = "localhost";
                string puerto = "3308";
                string usuario = "root";
                string password = string.Empty;
                string nombreBaseDatos = "bd_gym";

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

                string rutaMysqldump = @"C:\Program Files\MySQL\MySQL Workbench 8.0 CE\mysqldump.exe";

                if (!File.Exists(rutaMysqldump))
                {
                    string rutaAlternativa1 = @"C:\Program Files\MySQL\MySQL Workbench 8.0 CE\mysqldump.exe";
                    string rutaAlternativa2 = @"C:\xampp\mysql\bin\mysqldump.exe";

                    if (File.Exists(rutaAlternativa1))
                        rutaMysqldump = rutaAlternativa1;
                    else if (File.Exists(rutaAlternativa2))
                        rutaMysqldump = rutaAlternativa2;
                    else
                    {
                        throw new BusinessException("No se encontró el ejecutable 'mysqldump.exe' en las rutas predeterminadas de MySQL.");
                    }
                }

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

                using (var proceso = Process.Start(startInfo))
                {
                    if (proceso == null)
                        throw new BusinessException("No se pudo iniciar el proceso de respaldo de MySQL.");

                    using (var lector = proceso.StandardOutput)
                    {
                        string resultadoSql = await lector.ReadToEndAsync();

                        if (string.IsNullOrWhiteSpace(resultadoSql))
                        {
                            throw new BusinessException("El volcado de la base de datos devolvió un resultado vacío.");
                        }

                        await File.WriteAllTextAsync(rutaArchivo, resultadoSql);
                    }
                    proceso.WaitForExit();

                    if (proceso.ExitCode != 0)
                    {
                        throw new BusinessException("El comando mysqldump finalizó con un código de error. Verifique las credenciales y permisos.");
                    }
                }
            }
            catch (Exception ex) when (ex is not BusinessException)
            {
                throw new BusinessException($"Ocurrió un error inesperado al generar el respaldo: {ex.Message}");
            }
        }

        public async Task RestaurarBaseDatosAsync(RestaurarManualDto dto)
        {
            var valResult = await _validadorRestaurar.ValidateAsync(dto);
            if (!valResult.IsValid)
            {
                throw new BusinessException(string.Join(" ", valResult.Errors.Select(e => e.ErrorMessage)));
            }

            try
            {
                var conexionDatos = new Conexion();
                string connectionString = string.Empty;

                using (var conn = conexionDatos.ObtenerConexion())
                {
                    connectionString = conn.ConnectionString;
                }

                string servidor = "localhost";
                string puerto = "3308";
                string usuario = "root";
                string password = string.Empty;
                string nombreBaseDatos = "bd_gym";

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

                // Buscar la ruta de mysql.exe (gestor de ejecución de scripts) en el equipo
                string rutaMysqlExe = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe";

                if (!File.Exists(rutaMysqlExe))
                {
                    string rutaAlt1 = @"C:\Program Files\MySQL\MySQL Server 8.4\bin\mysql.exe";
                    string rutaAlt2 = @"C:\Program Files\xampp\mysql\bin\mysql.exe";

                    if (File.Exists(rutaAlt1))
                        rutaMysqlExe = rutaAlt1;
                    else if (File.Exists(rutaAlt2))
                        rutaMysqlExe = rutaAlt2;
                    else
                    {
                        throw new BusinessException("No se encontró el ejecutable 'mysql.exe' para realizar la restauración en las rutas predeterminadas.");
                    }
                }

                string argumentos = string.IsNullOrEmpty(password)
                    ? $"-h{servidor} -P{puerto} -u{usuario} {nombreBaseDatos}"
                    : $"-h{servidor} -P{puerto} -u{usuario} -p{password} {nombreBaseDatos}";

                var startInfo = new ProcessStartInfo
                {
                    FileName = rutaMysqlExe,
                    Arguments = argumentos,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var proceso = Process.Start(startInfo))
                {
                    if (proceso == null)
                        throw new BusinessException("No se pudo iniciar el proceso de restauración de MySQL.");

                    Task<string> errorOutputTask = proceso.StandardError.ReadToEndAsync();
                    using (var escritor = proceso.StandardInput)
                    using (var lector = new StreamReader(dto.RutaArchivo))
                    {
                        char[] buffer = new char[81920];
                        int caracteresLeidos;
                        while ((caracteresLeidos = await lector.ReadAsync(buffer.AsMemory())) > 0)
                        {
                            await escritor.WriteAsync(buffer.AsMemory(0, caracteresLeidos));
                        }
                    }

                    await proceso.WaitForExitAsync();
                    string errorOutput = await errorOutputTask;

                    if (proceso.ExitCode != 0)
                    {
                        string detalle = string.IsNullOrWhiteSpace(errorOutput)
                            ? $"MySQL terminó con el código de salida {proceso.ExitCode}."
                            : errorOutput.Trim();

                        throw new BusinessException($"Error al restaurar la base de datos: {detalle}");
                    }
                }
            }
            catch (Exception ex) when (ex is not BusinessException)
            {
                throw new BusinessException($"Ocurrió un error inesperado al restaurar el respaldo: {ex.Message}");
            }
        }
    }
}
