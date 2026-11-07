using Datos.Interfaces;
using System.Net.Mail;
using System.Net;
using Negocio.Helpers;

namespace Negocio.Interfaces
{
    public interface IEmailService
    {
        Task EnviarCorreoAsync(string destinatario, string asunto, string mensaje);

        // Nuevo método para procesar y enviar felicitaciones de cumpleaños a los socios
        Task EnviarFelicitacionesCumpleanosAsync();

        //Nuevo método para enviar recordatorios de vencimiento (1 día antes)
        Task EnviarRecordatorioVencimientoAsync();

        Task EnviarCorreoCorteCajaAsync(decimal efectivoInicial, decimal totalVentas, decimal totalEntradas, decimal totalSalidas, decimal efectivoEsperado, decimal efectivoReal, decimal diferencia, DateTime fechaCorte, DateTime fechaInicio, int usuarioId);

        // Envía el comprobante de un pago al socio (solo si "Correo_EnviarPago" está activo y el socio tiene correo)
        Task EnviarCorreoPagoAsync(string emailSocio, PagoCorreo datos);
    }

}
