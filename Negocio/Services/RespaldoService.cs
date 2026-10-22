using Datos;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using System.Diagnostics;

namespace Negocio.Services
{
    public class RespaldoService : IRespaldoService
    {
        private readonly IValidator<RespaldoManualDto> _validador;

        public RespaldoService(IValidator<RespaldoManualDto> validador)
        {
            _validador = validador ?? throw new ArgumentNullException(nameof(validador));
        }

        public async Task GenerarRespaldoManualAsync(RespaldoManualDto dto)
        {
            var valResult = await _validador.ValidateAsync(dto);
            if (!valResult.IsValid)
            {
                throw new BusinessException(string.Join(" ", valResult.Errors.Select(e => e.ErrorMessage)));
            }

            try
            {
                string rutaArchivo = Path.Combine(dto.RutaDestino, "gym.sql");

                var conexionDatos = new Conexion();
                string connectionString = string.Empty;

                using (var conn = conexionDatos.ObtenerConexion())
                {
                    connectionString = conn.ConnectionString;
                }

                string servidor = "localhost";
                string puerto = "3306";
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

                // Buscar la ruta de mysqldump en el equipo
                string rutaMysqldump = @"C:\Program Files\MySQL\MySQL Workbench 8.0 CE\mysqldump.exe";

                if (!File.Exists(rutaMysqldump))
                {
                    string rutaAlternativa1 = @"C:\Program Files\MySQL\MySQL Workbench 8.0 CE\mysqldump.exe";
                    string rutaAlternativa2 = @"C:\Program Files\xampp\mysql\bin\mysqldump.exe";

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
    }
}
