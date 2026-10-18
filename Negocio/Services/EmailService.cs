using Datos.Interfaces;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class EmailService : IEmailService
    {

        private readonly IUnitOfWork _unitOfWork;

        public EmailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string mensaje)
        {
            // Obtener credenciales configuradas desde la base de datos
            var cfgEmail = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Correo_Email");
            var cfgPassword = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Correo_Password");

            string remitente = cfgEmail?.Valor ?? string.Empty;
            string password = cfgPassword?.Valor ?? string.Empty;

            if (string.IsNullOrWhiteSpace(remitente) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException("Las credenciales de correo electrónico no están configuradas en el sistema.");
            }

            using var clienteSmtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(remitente, password),
                EnableSsl = true
            };

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(remitente, "Sistema de Gimnasio"),
                Subject = asunto,
                Body = mensaje,
                IsBodyHtml = true
            };

            mailMessage.To.Add(destinatario);

            await clienteSmtp.SendMailAsync(mailMessage);
        }

        public async Task EnviarCorreoCorteCajaAsync(
            decimal efectivoInicial,
            decimal totalVentas,
            decimal totalEntradas,
            decimal totalSalidas,
            decimal efectivoEsperado,
            decimal efectivoReal,
            decimal diferencia,
            DateTime fechaCorte,
            DateTime fechaInicio)
        {
            // 1. Obtener el correo configurado para notificaciones de corte de caja
            var cfgEmailDestino = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Corte_EmailNotificacion");
            string emailDestino = cfgEmailDestino?.Valor?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(emailDestino))
            {
                return; // Si no hay un correo configurado, se omite el envío.
            }

            // 2. Obtener el nombre del gimnasio
            var cfgGymNombre = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Gym_Nombre");
            string nombreGym = cfgGymNombre?.Valor ?? "Gimnasio Hdeleon 2.0";

            // 3. Consultar los movimientos dentro del rango del corte de caja
            var movimientosDb = await _unitOfWork.Movimiento.ObtenerPorRangoFechasAsync(fechaInicio, fechaCorte);
            var listaMovimientos = movimientosDb?.Where(m => m.Activo).ToList() ?? new List<Datos.Entities.Movimiento>();

            // Construir dinámicamente las filas de la tabla de movimientos
            StringBuilder sbMovimientos = new StringBuilder();
            foreach (var mov in listaMovimientos)
            {
                bool esIngreso = string.Equals(mov.Tipo?.Trim(), "Ingreso", StringComparison.OrdinalIgnoreCase);
                string colorTexto = esIngreso ? "#16a34a" : "#dc2626"; // Verde ingreso, Rojo egreso

                sbMovimientos.Append($@"
                    <tr style='border-bottom: 1px solid #e1e4e8;'>
                        <td style='padding: 8px; font-size: 12px;'>{mov.Concepto?.Nombre ?? "N/A"}</td>
                        <td style='padding: 8px; font-size: 12px;'>{mov.CreatedAt:dd/MM/yyyy hh:mm tt}</td>
                        <td style='padding: 8px; font-size: 12px;'>{mov.Usuario?.NombreUsuario ?? "admin"}</td>
                        <td style='padding: 8px; font-size: 12px; color: {colorTexto}; font-weight: bold;'>{mov.Tipo}</td>
                        <td style='padding: 8px; font-size: 12px;'>{mov.FormaPago}</td>
                        <td style='padding: 8px; font-size: 12px; text-align: right; color: {colorTexto}; font-weight: bold;'>{mov.Total:C2}</td>
                    </tr>");
            }

            if (listaMovimientos.Count == 0)
            {
                sbMovimientos.Append(@"
                    <tr>
                        <td colspan='6' style='padding: 12px; text-align: center; color: #666; font-size: 12px;'>No se registraron movimientos en este corte.</td>
                    </tr>");
            }

            // Asunto
            string asunto = $"Corte de caja del día: {fechaInicio:dd/MM/yyyy hh:mm:ss tt} a {fechaCorte:dd/MM/yyyy hh:mm:ss tt}";

            // Estructura HTML integrada con la tabla de movimientos requerida
            string mensaje = $@"
                <div style='font-family: Arial, sans-serif; color: #111; padding: 15px;'>
                    <h1 style='font-size: 22px; font-weight: bold; margin-bottom: 5px;'>{nombreGym}</h1>
                    <h3 style='font-size: 15px; margin-top: 0; margin-bottom: 15px; font-weight: bold;'>Corte de Caja</h3>
                    
                    <p style='margin: 4px 0; font-size: 13px;'><strong>Fecha de inicio:</strong> {fechaInicio:dd/MM/yyyy hh:mm:ss tt}</p>
                    <p style='margin: 4px 0; font-size: 13px;'><strong>Fecha final:</strong> {fechaCorte:dd/MM/yyyy hh:mm:ss tt}</p>
                    <p style='margin: 4px 0; font-size: 13px;'><strong>Usuario que lo genero:</strong> admin</p>
                    <p style='margin: 4px 0; font-size: 13px;'><strong>Observación:</strong></p>
                    
                    <hr style='border: none; border-top: 1px solid #ccc; margin: 15px 0;' />

                    <h3 style='font-size: 14px; font-weight: bold; margin-bottom: 10px;'>Totales en Caja</h3>
                    <table style='width: 100%; max-width: 500px; border-collapse: collapse; margin-bottom: 20px; font-size: 13px;'>
                        <tr>
                            <td style='padding: 6px 0; font-weight: bold;'>Efectivo en caja INICIAL</td>
                            <td style='padding: 6px 0; text-align: right; color: #2563eb; font-weight: bold;'>{efectivoInicial:C2}</td>
                        </tr>
                        <tr>
                            <td style='padding: 6px 0; font-weight: bold;'>Efectivo en caja FINAL</td>
                            <td style='padding: 6px 0; text-align: right; color: #16a34a; font-weight: bold;'>{efectivoReal:C2}</td>
                        </tr>
                    </table>

                    <h3 style='font-size: 14px; font-weight: bold; margin-bottom: 10px;'>Totales detalle</h3>
                    <table style='width: 100%; max-width: 500px; border-collapse: collapse; margin-bottom: 25px; font-size: 13px;'>
                        <tr>
                            <td style='padding: 4px 0;'>Ingreso total</td>
                            <td style='padding: 4px 0; text-align: right; color: #16a34a; font-weight: bold;'>{totalVentas:C2}</td>
                        </tr>
                        <tr>
                            <td style='padding: 4px 0;'>Egreso total</td>
                            <td style='padding: 4px 0; text-align: right; color: #dc2626; font-weight: bold;'>{totalSalidas:C2}</td>
                        </tr>
                        <tr>
                            <td style='padding: 4px 0;'>Ingreso efectivo</td>
                            <td style='padding: 4px 0; text-align: right; color: #16a34a; font-weight: bold;'>{totalVentas:C2}</td>
                        </tr>
                        <tr>
                            <td style='padding: 4px 0;'>Egreso efectivo</td>
                            <td style='padding: 4px 0; text-align: right; color: #dc2626; font-weight: bold;'>{totalSalidas:C2}</td>
                        </tr>
                    </table>

                    <h3 style='font-size: 14px; font-weight: bold; margin-bottom: 10px;'>Conceptos (Movimientos)</h3>
                    <table style='width: 100%; border-collapse: collapse; margin-bottom: 20px; font-size: 12px;'>
                        <thead>
                            <tr style='background-color: #f1f3f5; border-bottom: 2px solid #ccc;'>
                                <th style='padding: 8px; text-align: left;'>Concepto</th>
                                <th style='padding: 8px; text-align: left;'>Fecha</th>
                                <th style='padding: 8px; text-align: left;'>Usuario</th>
                                <th style='padding: 8px; text-align: left;'>Tipo</th>
                                <th style='padding: 8px; text-align: left;'>Forma de pago</th>
                                <th style='padding: 8px; text-align: right;'>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            {sbMovimientos}
                        </tbody>
                    </table>

                    <hr style='border: none; border-top: 1px solid #ccc; margin: 15px 0;' />
                    
                    <p style='font-size: 11px; color: #666; text-align: right; margin-top: 30px;'>
                        {nombreGym} - Creado por sistema automatizado<br/>
                        <a href='#' style='color: #2563eb; text-decoration: none;'>Adquirir software de gimnasio</a>
                    </p>
                </div>";

            // 4. Enviar el correo electrónico
            await EnviarCorreoAsync(emailDestino, asunto, mensaje);
        }

        public async Task EnviarFelicitacionesCumpleanosAsync()
        {
            // 1. Verificar si la opción de enviar felicitaciones está activa en la configuración
            var cfgActivo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Correo_EnviarFelicitaciones");
            if (cfgActivo == null || !bool.TryParse(cfgActivo.Valor, out bool enviarFelicidades) || !enviarFelicidades)
            {
                return; // Si no está activado, se omite el proceso
            }

            // 2. Obtener la fecha de hoy (Mes y Día)
            var hoy = DateTime.Today;
            int mesActual = hoy.Month;
            int diaActual = hoy.Day;

            // 3. Obtener todos los socios activos que tengan registrada su fecha de nacimiento y un correo válido
            var socios = await _unitOfWork.Socio.ObtenerTodosAsync(false);
            var cumpleaneros = socios.Where(s =>
                s.Activo &&
                !string.IsNullOrWhiteSpace(s.Email) &&
                s.FechaNacimiento.HasValue &&
                s.FechaNacimiento.Value.Month == mesActual &&
                s.FechaNacimiento.Value.Day == diaActual
            ).ToList();

            if (!cumpleaneros.Any()) return;

            // 4. Obtener nombre del gimnasio para personalizar el mensaje
            var cfgGymNombre = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Gym_Nombre");
            string nombreGym = cfgGymNombre?.Valor ?? "Nuestro Gimnasio";

            // 5. Enviar correo a cada socio cumpleañero
            string asunto = $"¡Feliz Cumpleaños te desea {nombreGym}! 🎂";

            foreach (var socio in cumpleaneros)
            {
                string mensaje = $@"
                    <div style='font-family: Arial, sans-serif; color: #333;'>
                        <h2 style='color: #1f6feb;'>¡Feliz Cumpleaños, {socio.Nombre}!</h2>
                        <p>En <strong>{nombreGym}</strong> queremos desearte un día maravilloso lleno de energía y éxito.</p>
                        <p>¡Gracias por formar parte de nuestra gran familia fitness! Sigue entrenando con la misma pasión.</p>
                        <br>
                        <p>Con aprecio,<br><strong>El equipo de {nombreGym}</strong></p>
                    </div>";

                try
                {
                    await EnviarCorreoAsync(socio.Email!, asunto, mensaje);
                }
                catch (Exception ex)
                {
                    // Opcional: registrar el error de envío individual sin detener el ciclo de los demás socios
                    System.Diagnostics.Debug.WriteLine($"No se pudo enviar correo a {socio.Email}: {ex.Message}");
                }
            }
        }

        // Implementación del envío de recordatorios de vencimiento (1 día antes)
        public async Task EnviarRecordatorioVencimientoAsync()
        {
            // 1. Verificar si la opción de recordatorio está activa en la configuración
            var cfgActivo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Correo_RecordatorioVencimiento");
            if (cfgActivo == null || !bool.TryParse(cfgActivo.Valor, out bool enviarRecordatorio) || !enviarRecordatorio)
            {
                return; // Si no está activado, se omite el proceso
            }

            // 2. La fecha objetivo es mañana (exactamente 1 día antes de que venza la membresía)
            var fechaMañana = DateTime.Today.AddDays(1);

            // 3. Consultar las membresías activas de los socios cuya fecha de fin coincida con mañana
            // Nota: Asumimos que tienes acceso a las relaciones de SocioMembresia a través del repositorio o contexto.
            // Aquí evaluamos las membresías que vencen exactamente mañana y cuyo socio tenga email.
            var sociosConMembresia = await _unitOfWork.Socio.ObtenerTodosAsync(false);

            // Obtenemos el nombre del gimnasio
            var cfgGymNombre = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Gym_Nombre");
            string nombreGym = cfgGymNombre?.Valor ?? "Nuestro Gimnasio";

            foreach (var socio in sociosConMembresia)
            {
                if (string.IsNullOrWhiteSpace(socio.Email)) continue;

                // Buscamos si tiene alguna membresía activa cuyo vencimiento sea exactamente mañana
                var detalleSocio = await _unitOfWork.Socio.ObtenerDetalleCompletoAsync(socio.SocioID);
                if (detalleSocio?.SocioMembresias == null) continue;

                var membresiaPorVencer = detalleSocio.SocioMembresias
                    .FirstOrDefault(m => m.Estado == "Vigente" && m.FechaFin.Date == fechaMañana);

                if (membresiaPorVencer != null)
                {
                    string nombreMembresia = membresiaPorVencer.Membresia?.Nombre ?? "Membresía";
                    string asunto = $"Recordatorio: Tu membresía en {nombreGym} está por vencer";
                    string mensaje = $@"
                        <div style='font-family: Arial, sans-serif; color: #333;'>
                            <h2 style='color: #d97706;'>¡Hola, {socio.Nombre}!</h2>
                            <p>Te recordamos que tu membresía <strong>{nombreMembresia}</strong> en <strong>{nombreGym}</strong> está próxima a vencer el día de mañana (<strong>{membresiaPorVencer.FechaFin:dd/MM/yyyy}</strong>).</p>
                            <p>Te invitamos a renovarla a tiempo para que no pierdas tu acceso continuado al gimnasio.</p>
                            <br>
                            <p>¡Te esperamos pronto!<br><strong>El equipo de {nombreGym}</strong></p>
                        </div>";

                    try
                    {
                        await EnviarCorreoAsync(socio.Email, asunto, mensaje);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"No se pudo enviar recordatorio a {socio.Email}: {ex.Message}");
                    }
                }
            }
        }
    }
}
