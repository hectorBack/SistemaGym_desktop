using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    /// <summary>Datos del gimnasio que aparecen en el encabezado del ticket.</summary>
    public sealed record ComprobanteGimnasio(
        string Nombre,
        string Domicilio,
        string Telefono,
        string Rfc,
        string Mensaje,
        byte[]? Logo);

    /// <summary>
    /// Genera el ticket de pago en PDF (ancho de 80 mm, alto automático). Solo da formato: no consulta la base de datos.
    /// </summary>
    public static class ComprobantePdfHelper
    {
        static ComprobantePdfHelper()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public static byte[] PagoRecibido(ComprobanteGimnasio gym, PagoCorreo p)
        {
            return Document.Create(documento =>
            {
                documento.Page(pagina =>
                {
                    pagina.ContinuousSize(80, Unit.Millimetre);
                    pagina.Margin(5, Unit.Millimetre);
                    pagina.DefaultTextStyle(x => x.FontSize(9));

                    pagina.Content().Column(col =>
                    {
                        col.Spacing(3);

                        // ── Encabezado ──
                        if (gym.Logo != null)
                            col.Item().AlignCenter().MaxHeight(60).Image(gym.Logo).FitArea();

                        col.Item().AlignCenter().Text(gym.Nombre).Bold().FontSize(12);

                        if (!string.IsNullOrWhiteSpace(gym.Domicilio))
                            col.Item().AlignCenter().Text(gym.Domicilio).FontSize(8);
                        if (!string.IsNullOrWhiteSpace(gym.Telefono))
                            col.Item().AlignCenter().Text($"Tel. {gym.Telefono}").FontSize(8);
                        if (!string.IsNullOrWhiteSpace(gym.Rfc))
                            col.Item().AlignCenter().Text($"RFC: {gym.Rfc}").FontSize(8);

                        Separador(col);
                        col.Item().AlignCenter().Text("COMPROBANTE DE PAGO").Bold().FontSize(10);
                        Separador(col);

                        // ── Socio ──
                        Fila(col, "Clave", p.ClaveSocio);
                        Fila(col, "Socio", p.NombreSocio);

                        Separador(col);

                        // ── Membresía ──
                        Fila(col, "Membresía", p.Membresia);
                        Fila(col, "Inicio", p.FechaInicio.ToString("dd/MM/yyyy"));
                        Fila(col, "Vencimiento", p.FechaVencimiento.ToString("dd/MM/yyyy"));
                        Fila(col, "Precio", p.Precio.ToString("C2"));
                        Fila(col, "Total pagado", p.TotalPagado.ToString("C2"));
                        Fila(col, "Estado", p.EstadoPago, negrita: true);

                        Separador(col);

                        // ── Pago ──
                        Fila(col, "Fecha", p.Fecha.ToString("dd/MM/yyyy hh:mm tt"));
                        Fila(col, "Forma de pago", p.FormaPago);
                        if (!string.IsNullOrWhiteSpace(p.Folio))
                            Fila(col, "Folio", p.Folio);
                        if (!string.IsNullOrWhiteSpace(p.Observacion))
                            Fila(col, "Observación", p.Observacion);

                        col.Item().PaddingTop(4).Row(r =>
                        {
                            r.RelativeItem().Text("MONTO").Bold().FontSize(11);
                            r.RelativeItem().AlignRight().Text(p.Monto.ToString("C2")).Bold().FontSize(11);
                        });

                        Separador(col);

                        Fila(col, "Te atendió", p.Usuario);

                        // ── Pie ──
                        col.Item().PaddingTop(6).AlignCenter().Text(
                            string.IsNullOrWhiteSpace(gym.Mensaje) ? "¡Gracias por tu pago!" : gym.Mensaje)
                            .Italic().FontSize(8);
                    });
                });
            }).GeneratePdf();
        }

        private static void Fila(ColumnDescriptor col, string etiqueta, string valor, bool negrita = false)
        {
            col.Item().Row(r =>
            {
                r.RelativeItem().Text(etiqueta).SemiBold();

                var texto = r.RelativeItem().AlignRight().Text(valor);
                if (negrita) texto.Bold();
            });
        }

        private static void Separador(ColumnDescriptor col)
        {
            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);
        }
    }
}
