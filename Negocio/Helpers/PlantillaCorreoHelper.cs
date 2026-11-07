using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    // ───────────── Modelos: solo los datos que necesita cada plantilla, sin lógica de negocio ─────────────

    public sealed record MovimientoCorreo(
        string Concepto,
        DateTime? Fecha,
        string Usuario,
        string Tipo,
        string FormaPago,
        decimal Total,
        bool EsIngreso);

    public sealed record FormaPagoCorreo(string FormaPago, decimal Ingresos, decimal Egresos)
    {
        public decimal Neto => Ingresos - Egresos;
    }

    public sealed record PagoCorreo(
        string ClaveSocio,
        string NombreSocio,
        string Membresia,
        DateTime FechaInicio,
        DateTime FechaVencimiento,
        decimal Precio,
        decimal TotalPagado,
        string EstadoPago,
        decimal Monto,
        string FormaPago,
        string? Folio,
        string? Observacion,
        string Usuario,
        DateTime Fecha);

    public sealed record CorteCajaCorreo(
        string NombreGimnasio,
        DateTime FechaInicio,
        DateTime FechaFin,
        string UsuarioGenerador,
        string Observacion,
        decimal EfectivoInicial,
        decimal EfectivoFinal,
        decimal TotalCorte,
        decimal TotalIngresos,
        decimal TotalEgresos,
        IReadOnlyList<FormaPagoCorreo> FormasPago,
        IReadOnlyList<MovimientoCorreo> Movimientos);

    /// <summary>
    /// Construye el HTML de los correos del sistema. Solo da formato: no consulta la base de datos ni decide nada.
    /// Todo texto que viene de datos (nombres, conceptos, observaciones) se codifica aquí, así que un "&amp;" o un "&lt;"
    /// en un nombre no rompe el correo.
    /// </summary>
    public static class PlantillasCorreoHelper
    {
        private const string Verde = "#16a34a";
        private const string Rojo = "#dc2626";
        private const string Azul = "#2563eb";

        private static string H(string? texto) => WebUtility.HtmlEncode(texto ?? string.Empty);

        // ───────────── Corte de caja ─────────────

        public static string CorteCaja(CorteCajaCorreo m)
        {
            string gym = H(m.NombreGimnasio);

            return $@"
                    <div style='font-family: Arial, sans-serif; color: #111; padding: 15px;'>
                        <h1 style='font-size: 22px; font-weight: bold; margin-bottom: 5px;'>{gym}</h1>
                        <h3 style='font-size: 15px; margin-top: 0; margin-bottom: 15px; font-weight: bold;'>Corte de Caja</h3>
 
                        <p style='margin: 4px 0; font-size: 13px;'><strong>Fecha de inicio:</strong> {m.FechaInicio:dd/MM/yyyy hh:mm:ss tt}</p>
                        <p style='margin: 4px 0; font-size: 13px;'><strong>Fecha final:</strong> {m.FechaFin:dd/MM/yyyy hh:mm:ss tt}</p>
                        <p style='margin: 4px 0; font-size: 13px;'><strong>Usuario que lo genero:</strong> {H(m.UsuarioGenerador)}</p>
                        <p style='margin: 4px 0; font-size: 13px;'><strong>Observación:</strong> {H(m.Observacion)}</p>
 
                        <hr style='border: none; border-top: 1px solid #ccc; margin: 15px 0;' />
 
                        <h3 style='font-size: 14px; font-weight: bold; margin-bottom: 10px;'>Totales en Caja</h3>
                        <table style='width: 100%; max-width: 500px; border-collapse: collapse; margin-bottom: 20px; font-size: 13px;'>
                            {FilaResumen("Efectivo en caja INICIAL", m.EfectivoInicial, Azul, true)}
                            {FilaResumen("Efectivo en caja FINAL (solo efectivo)", m.EfectivoFinal, Verde, true)}
                            {FilaResumen("Total del corte (todas las formas de pago)", m.TotalCorte, Azul, true)}
                        </table>
 
                        <h3 style='font-size: 14px; font-weight: bold; margin-bottom: 10px;'>Totales detalle</h3>
                        <table style='width: 100%; max-width: 500px; border-collapse: collapse; margin-bottom: 20px; font-size: 13px;'>
                            {FilaResumen("Ingreso total", m.TotalIngresos, Verde, false)}
                            {FilaResumen("Egreso total", m.TotalEgresos, Rojo, false)}
                        </table>
 
                        <h3 style='font-size: 14px; font-weight: bold; margin-bottom: 10px;'>Totales por forma de pago</h3>
                        <table style='width: 100%; max-width: 500px; border-collapse: collapse; margin-bottom: 25px; font-size: 13px;'>
                            <thead>
                                <tr style='background-color: #f1f3f5; border-bottom: 2px solid #ccc;'>
                                    <th style='padding: 6px 8px; text-align: left;'>Forma de pago</th>
                                    <th style='padding: 6px 8px; text-align: right;'>Ingresos</th>
                                    <th style='padding: 6px 8px; text-align: right;'>Egresos</th>
                                    <th style='padding: 6px 8px; text-align: right;'>Neto</th>
                                </tr>
                            </thead>
                            <tbody>
                                {FilasFormasPago(m.FormasPago)}
                            </tbody>
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
                                {FilasMovimientos(m.Movimientos)}
                            </tbody>
                        </table>
 
                        <hr style='border: none; border-top: 1px solid #ccc; margin: 15px 0;' />
 
                        <p style='font-size: 11px; color: #666; text-align: right; margin-top: 30px;'>
                            {gym} - Creado por sistema automatizado<br/>
                            <a href='#' style='color: {Azul}; text-decoration: none;'>Adquirir software de gimnasio</a>
                        </p>
                    </div>";
        }

        // Fila de dos columnas (etiqueta + importe). "destacada" = etiqueta en negritas y más espacio.
        private static string FilaResumen(string etiqueta, decimal valor, string color, bool destacada)
        {
            string padding = destacada ? "6px 0" : "4px 0";
            string pesoEtiqueta = destacada ? " font-weight: bold;" : string.Empty;

            return $@"<tr>
            <td style='padding: {padding};{pesoEtiqueta}'>{H(etiqueta)}</td>
            <td style='padding: {padding}; text-align: right; color: {color}; font-weight: bold;'>{valor:C2}</td>
        </tr>";
        }

        private static string FilasFormasPago(IEnumerable<FormaPagoCorreo> formas)
        {
            var sb = new StringBuilder();

            foreach (var f in formas)
            {
                string colorNeto = f.Neto >= 0 ? Verde : Rojo;

                sb.Append($@"
            <tr style='border-bottom: 1px solid #e1e4e8;'>
                <td style='padding: 6px 8px;'>{H(f.FormaPago)}</td>
                <td style='padding: 6px 8px; text-align: right; color: {Verde};'>{f.Ingresos:C2}</td>
                <td style='padding: 6px 8px; text-align: right; color: {Rojo};'>{f.Egresos:C2}</td>
                <td style='padding: 6px 8px; text-align: right; font-weight: bold; color: {colorNeto};'>{f.Neto:C2}</td>
            </tr>");
            }

            return sb.ToString();
        }

        private static string FilasMovimientos(IReadOnlyList<MovimientoCorreo> movimientos)
        {
            if (movimientos.Count == 0)
            {
                return @"
            <tr>
                <td colspan='6' style='padding: 12px; text-align: center; color: #666; font-size: 12px;'>No se registraron movimientos en este corte.</td>
            </tr>";
            }

            var sb = new StringBuilder();

            foreach (var mov in movimientos)
            {
                string color = mov.EsIngreso ? Verde : Rojo;

                sb.Append($@"
            <tr style='border-bottom: 1px solid #e1e4e8;'>
                <td style='padding: 8px; font-size: 12px;'>{H(mov.Concepto)}</td>
                <td style='padding: 8px; font-size: 12px;'>{mov.Fecha:dd/MM/yyyy hh:mm tt}</td>
                <td style='padding: 8px; font-size: 12px;'>{H(mov.Usuario)}</td>
                <td style='padding: 8px; font-size: 12px; color: {color}; font-weight: bold;'>{H(mov.Tipo)}</td>
                <td style='padding: 8px; font-size: 12px;'>{H(mov.FormaPago)}</td>
                <td style='padding: 8px; font-size: 12px; text-align: right; color: {color}; font-weight: bold;'>{mov.Total:C2}</td>
            </tr>");
            }

            return sb.ToString();
        }

        // ───────────── Felicitación de cumpleaños ─────────────

        public static string Cumpleanos(string nombreSocio, string nombreGimnasio)
        {
            string socio = H(nombreSocio);
            string gym = H(nombreGimnasio);

            return $@"
                    <div style='font-family: Arial, sans-serif; color: #333;'>
                        <h2 style='color: #1f6feb;'>¡Feliz Cumpleaños, {socio}!</h2>
                        <p>En <strong>{gym}</strong> queremos desearte un día maravilloso lleno de energía y éxito.</p>
                        <p>¡Gracias por formar parte de nuestra gran familia fitness! Sigue entrenando con la misma pasión.</p>
                        <br>
                        <p>Con aprecio,<br><strong>El equipo de {gym}</strong></p>
                    </div>";
        }

        // ───────────── Recordatorio de vencimiento de membresía ─────────────

        public static string RecordatorioVencimiento(
            string nombreSocio,
            string nombreMembresia,
            string nombreGimnasio,
            DateTime fechaVencimiento)
        {
            string socio = H(nombreSocio);
            string membresia = H(nombreMembresia);
            string gym = H(nombreGimnasio);

            return $@"
                    <div style='font-family: Arial, sans-serif; color: #333;'>
                        <h2 style='color: #d97706;'>¡Hola, {socio}!</h2>
                        <p>Te recordamos que tu membresía <strong>{membresia}</strong> en <strong>{gym}</strong> está próxima a vencer el día de mañana (<strong>{fechaVencimiento:dd/MM/yyyy}</strong>).</p>
                        <p>Te invitamos a renovarla a tiempo para que no pierdas tu acceso continuado al gimnasio.</p>
                        <br>
                        <p>¡Te esperamos pronto!<br><strong>El equipo de {gym}</strong></p>
                    </div>";
        }

        // ───────────── Comprobante de pago ─────────────

        public static string PagoRecibido(string nombreGimnasio, PagoCorreo p)
        {
            string gym = H(nombreGimnasio);
            string colorEstado = p.EstadoPago.StartsWith("Pagada", StringComparison.OrdinalIgnoreCase) ? Verde : "#d97706";

            return $@"
            <div style='font-family: Arial, sans-serif; color: #333; padding: 15px;'>
                <h2 style='color: {Azul}; margin-bottom: 5px;'>¡Gracias por tu pago, {H(p.NombreSocio)}!</h2>
                <p style='margin-top: 0;'>Registramos tu pago en <strong>{gym}</strong>.</p>

                <table style='width: 100%; max-width: 450px; border-collapse: collapse; font-size: 14px; margin: 15px 0;'>
                    {FilaPago("Membresía", H(p.Membresia))}
                    {FilaPago("Monto", p.Monto.ToString("C2"), Verde)}
                    {FilaPago("Estado del pago", H(p.EstadoPago), colorEstado)}
                    {FilaPago("Vence", p.FechaVencimiento.ToString("dd/MM/yyyy"))}
                </table>

                <p>Adjuntamos tu comprobante en PDF con el detalle completo.</p>
                <p>¡Te esperamos pronto!<br><strong>El equipo de {gym}</strong></p>
            </div>";
        }

        // Fila etiqueta + valor. El valor ya debe venir codificado (H) o ser un dato propio (fecha, importe).
        private static string FilaPago(string etiqueta, string valorHtml, string? color = null)
        {
            string estilo = color == null ? string.Empty : $" color: {color}; font-weight: bold;";

            return $@"<tr style='border-bottom: 1px solid #e1e4e8;'>
                <td style='padding: 6px 0; font-weight: bold;'>{H(etiqueta)}</td>
                <td style='padding: 6px 0; text-align: right;{estilo}'>{valorHtml}</td>
            </tr>";
        }
    }
}
