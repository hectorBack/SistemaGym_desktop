using Datos.Interfaces;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Negocio.Helpers;
using Negocio.DTOs;

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
            var (remitente, password) = await ObtenerCredencialesAsync();
            await EnviarPorSmtpAsync(remitente, password, destinatario, asunto, mensaje);
        }

        // Credenciales configuradas en la base de datos (rápido). Falla si no están configuradas.
        private async Task<(string Remitente, string Password)> ObtenerCredencialesAsync()
        {
            var cfgEmail = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Correo_Email");
            var cfgPassword = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Correo_Password");

            string remitente = cfgEmail?.Valor ?? string.Empty;
            string password = SecretoHelper.Desproteger(cfgPassword?.Valor);

            if (string.IsNullOrWhiteSpace(remitente) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException("Las credenciales de correo electrónico no están configuradas en el sistema.");
            }

            return (remitente, password);
        }

        // Envío por SMTP (red): es la parte lenta. No toca la base de datos, por eso puede correr en segundo plano.
        private static async Task EnviarPorSmtpAsync(string remitente, string password, string destinatario, string asunto, string mensaje, byte[]? adjuntoPdf = null, string? nombreAdjunto = null)
        {
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

            if (adjuntoPdf != null)
            {
                mailMessage.Attachments.Add(new Attachment(new MemoryStream(adjuntoPdf), nombreAdjunto ?? "comprobante.pdf", "application/pdf"));
            }

            await clienteSmtp.SendMailAsync(mailMessage);
        }

        // Lanza el envío sin esperarlo. Si falla (sin internet, credenciales vencidas...) solo se registra:
        // el cierre de caja ya está guardado y no debe verse afectado.
        private static void EnviarEnSegundoPlano(string remitente, string password, string destinatario, string asunto, string mensaje, byte[]? adjuntoPdf = null, string? nombreAdjunto = null)
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await EnviarPorSmtpAsync(remitente, password, destinatario, asunto, mensaje, adjuntoPdf, nombreAdjunto);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"No se pudo enviar el correo a {destinatario}: {ex.Message}");
                }
            });
        }

        /// <summary>
        /// Prepara el correo del corte (configuración, movimientos y HTML) y lo deja enviándose en segundo plano.
        /// Termina sin esperar a Gmail; las consultas a la base de datos sí se completan antes de volver.
        /// </summary>
        public async Task EnviarCorreoCorteCajaAsync(
            decimal efectivoInicial,
            decimal totalVentas,
            decimal totalEntradas,
            decimal totalSalidas,
            decimal efectivoEsperado,
            decimal efectivoReal,
            decimal diferencia,
            DateTime fechaCorte,
            DateTime fechaInicio,
            int usuarioId)
        {
            // 1. Obtener el correo configurado para notificaciones de corte de caja
            var cfgEmailDestino = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Corte_EmailNotificacion");
            string emailDestino = cfgEmailDestino?.Valor?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(emailDestino))
            {
                return; // Si no hay un correo configurado, se omite el envío.
            }

            // 2. Obtener el nombre del gimnasio (sin nombre de otro negocio como respaldo)
            var cfgGymNombre = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("Gym_Nombre");
            string nombreGym = string.IsNullOrWhiteSpace(cfgGymNombre?.Valor) ? "Gimnasio" : cfgGymNombre!.Valor!.Trim();

            // 2.1 Usuario que realizó el corte (el ID llega desde FrmCorteModal)
            string usuarioGenerador = "N/A";
            if (usuarioId > 0)
            {
                var usuario = await _unitOfWork.Usuarios.ObtenerPorIdAsync(usuarioId);
                usuarioGenerador = string.IsNullOrWhiteSpace(usuario?.NombreCompleto)
                    ? $"Usuario {usuarioId}"
                    : usuario!.NombreCompleto;
            }

            // 3. Consultar los movimientos dentro del rango del corte de caja
            var movimientosDb = await _unitOfWork.Movimiento.ObtenerPorRangoFechasAsync(fechaInicio, fechaCorte);
            var listaMovimientos = movimientosDb?.Where(m => m.Activo).ToList() ?? new List<Datos.Entities.Movimiento>();

            static bool EsIngreso(Datos.Entities.Movimiento m) =>
                string.Equals(m.Tipo?.Trim(), "Ingreso", StringComparison.OrdinalIgnoreCase);

            static string FormaDe(Datos.Entities.Movimiento m) =>
                string.IsNullOrWhiteSpace(m.FormaPago) ? "Efectivo" : m.FormaPago.Trim();

            // 4. Datos para la plantilla (el HTML vive en PlantillasCorreoHelper)
            var movimientos = listaMovimientos
                .Select(m => new MovimientoCorreo(
                    m.Concepto?.Nombre ?? "N/A",
                    m.CreatedAt,
                    m.Usuario?.NombreCompleto ?? "admin",
                    m.Tipo ?? string.Empty,
                    FormaDe(m),
                    m.Total,
                    EsIngreso(m)))
                .ToList();

            // Desglose por forma de pago: siempre Efectivo, Tarjeta y Otro, más cualquier otra que se haya usado.
            var formasBase = new[] { "Efectivo", "Tarjeta", "Otro" };
            var formasExtra = listaMovimientos
                .Select(FormaDe)
                .Where(f => !formasBase.Contains(f, StringComparer.OrdinalIgnoreCase))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(f => f, StringComparer.CurrentCultureIgnoreCase);

            var formasPago = formasBase
                .Concat(formasExtra)
                .Select(forma =>
                {
                    var deEstaForma = listaMovimientos
                        .Where(m => string.Equals(FormaDe(m), forma, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    return new FormaPagoCorreo(
                        forma,
                        deEstaForma.Where(EsIngreso).Sum(m => m.Total),
                        deEstaForma.Where(m => !EsIngreso(m)).Sum(m => m.Total));
                })
                .ToList();

            // El efectivo físico en caja solo cuenta movimientos en efectivo; el total del corte cuenta todas las formas de pago.
            var efectivo = formasPago.First(f => string.Equals(f.FormaPago, "Efectivo", StringComparison.OrdinalIgnoreCase));
            decimal efectivoFinal = efectivoInicial + efectivo.Ingresos - efectivo.Egresos;
            decimal totalDelCorte = efectivoInicial + totalVentas - totalSalidas;

            string asunto = $"Corte de caja del día: {fechaInicio:dd/MM/yyyy hh:mm:ss tt} a {fechaCorte:dd/MM/yyyy hh:mm:ss tt}";

            string mensaje = PlantillasCorreoHelper.CorteCaja(new CorteCajaCorreo(
                NombreGimnasio: nombreGym,
                FechaInicio: fechaInicio,
                FechaFin: fechaCorte,
                UsuarioGenerador: usuarioGenerador,
                Observacion: string.Empty,       // pendiente: recibir las observaciones del corte
                EfectivoInicial: efectivoInicial,
                EfectivoFinal: efectivoFinal,
                TotalCorte: totalDelCorte,
                TotalIngresos: totalVentas,
                TotalEgresos: totalSalidas,
                FormasPago: formasPago,
                Movimientos: movimientos));

            // 5. Enviar el correo: las credenciales se leen aquí (base de datos, rápido) y el envío SMTP sigue sin esperarse.
            var (remitente, password) = await ObtenerCredencialesAsync();
            EnviarEnSegundoPlano(remitente, password, emailDestino, asunto, mensaje);
        }

        /// <summary>
        /// Envía al socio el comprobante de su pago. No hace nada si la opción "Enviar pago por correo" está apagada
        /// o si el socio no tiene correo. Nunca lanza error: el pago ya está guardado y no debe verse afectado.
        /// </summary>
        public async Task EnviarCorreoPagoAsync(string emailSocio, PagoCorreo datos, TicketConfiguracionDto configTicket)
        {
            try
            {
                var cfgActivo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(ConfiguracionService.CLAVE_MAS_ENVIAR_PAGO_POR_CORREO);
                if (cfgActivo == null || !bool.TryParse(cfgActivo.Valor, out bool enviarPago) || !enviarPago)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(emailSocio))
                {
                    return;
                }

                var cfgGymNombre = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(ConfiguracionService.CLAVE_GYM_NOMBRE);
                var cfgDomicilio = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(ConfiguracionService.CLAVE_GYM_DOMICILIO);
                var cfgTelefono = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(ConfiguracionService.CLAVE_GYM_TELEFONO);
                var cfgRfc = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(ConfiguracionService.CLAVE_GYM_RFC);
                var cfgMensaje = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(ConfiguracionService.CLAVE_GYM_MENSAJE);
                var cfgLogo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(ConfiguracionService.CLAVE_GYM_LOGO);

                string nombreGym = string.IsNullOrWhiteSpace(cfgGymNombre?.Valor) ? "Gimnasio" : cfgGymNombre!.Valor!.Trim();

                var gym = new ComprobanteGimnasio(
                    nombreGym,
                    cfgDomicilio?.Valor?.Trim() ?? string.Empty,
                    cfgTelefono?.Valor?.Trim() ?? string.Empty,
                    cfgRfc?.Valor?.Trim() ?? string.Empty,
                    cfgMensaje?.Valor?.Trim() ?? string.Empty,
                    LogoGimnasioHelper.CargarBytes(cfgLogo?.Valor));

                string asunto = $"Comprobante de pago - {nombreGym}";
                string mensaje = PlantillasCorreoHelper.PagoRecibido(nombreGym, datos);

                // Ticket en PDF con la configuración de la pestaña Ticket. Si falla (por ejemplo, un logo en formato
                // no soportado o una fuente que no existe) se reintenta sin logo y con los valores predeterminados;
                // si vuelve a fallar, el correo sale igual, solo con el resumen en el cuerpo.
                byte[]? pdf = null;
                try
                {
                    pdf = ComprobantePdfHelper.PagoRecibido(configTicket, gym, datos);
                }
                catch
                {
                    try
                    {
                        pdf = ComprobantePdfHelper.PagoRecibido(new TicketConfiguracionDto(), gym with { Logo = null }, datos);
                    }
                    catch (Exception exPdf)
                    {
                        System.Diagnostics.Debug.WriteLine($"No se pudo generar el PDF del comprobante: {exPdf.Message}");
                    }
                }

                string nombrePdf = $"Comprobante-{datos.ClaveSocio}-{datos.Fecha:yyyyMMdd-HHmm}.pdf";
                foreach (char c in Path.GetInvalidFileNameChars()) nombrePdf = nombrePdf.Replace(c, '_');

                var (remitente, password) = await ObtenerCredencialesAsync();
                EnviarEnSegundoPlano(remitente, password, emailSocio.Trim(), asunto, mensaje, pdf, nombrePdf);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"No se pudo enviar el comprobante de pago a {emailSocio}: {ex.Message}");
            }
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
                string mensaje = PlantillasCorreoHelper.Cumpleanos(socio.Nombre, nombreGym);

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
                    string mensaje = PlantillasCorreoHelper.RecordatorioVencimiento(
                        socio.Nombre, nombreMembresia, nombreGym, membresiaPorVencer.FechaFin);

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
