using Negocio.DTOs;
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
    /// Genera el comprobante de pago en PDF con la misma configuración del ticket impreso
    /// (ancho, fuente, tamaños, ancho de imagen y texto inferior). Solo da formato: no consulta la base de datos.
    /// </summary>
    public static class ComprobantePdfHelper
    {
        static ComprobantePdfHelper()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public static byte[] PagoRecibido(TicketConfiguracionDto config, ComprobanteGimnasio gym, PagoCorreo p)
        {
            const float margenMm = 3f;

            float anchoUtilPuntos = (config.AnchoTicket - margenMm * 2) * 72f / 25.4f;
            float interlineaTexto = config.TamanoRenglon / (float)config.TamanoTexto;
            float interlineaEncabezado = config.TamanoRenglonEncabezado / (float)config.TamanoTextoEncabezado;
            float entreSecciones = config.TamanoEntreSecciones;   // puntos

            return Document.Create(documento =>
            {
                documento.Page(pagina =>
                {
                    pagina.ContinuousSize(config.AnchoTicket, Unit.Millimetre);
                    pagina.Margin(margenMm, Unit.Millimetre);
                    pagina.DefaultTextStyle(x => x
                        .FontFamily(config.NombreFuente)
                        .FontSize(config.TamanoTexto)
                        .LineHeight(interlineaTexto));

                    pagina.Content().Column(col =>
                    {
                        // Texto centrado que se ajusta en varios renglones (domicilio largo, texto inferior)
                        void Centrado(string texto, bool destacado = false)
                        {
                            col.Item().Text(t =>
                            {
                                t.AlignCenter();
                                var span = t.Span(texto);
                                if (destacado)
                                    span.Bold().FontSize(config.TamanoTextoEncabezado).LineHeight(interlineaEncabezado);
                            });
                        }

                        // Etiqueta a la izquierda y valor a la derecha
                        void Fila(string etiqueta, string valor, bool destacado = false)
                        {
                            col.Item().Row(r =>
                            {
                                var izquierda = r.RelativeItem().Text(etiqueta);
                                var derecha = r.RelativeItem().AlignRight().Text(valor);

                                if (destacado)
                                {
                                    izquierda.Bold().FontSize(config.TamanoTextoEncabezado).LineHeight(interlineaEncabezado);
                                    derecha.Bold().FontSize(config.TamanoTextoEncabezado).LineHeight(interlineaEncabezado);
                                }
                            });
                        }

                        void Separador()
                        {
                            col.Item().PaddingVertical(entreSecciones / 2f).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);
                        }

                        // ── Encabezado ──
                        if (gym.Logo != null)
                        {
                            col.Item().PaddingBottom(entreSecciones).AlignCenter()
                                .Width(anchoUtilPuntos * config.AnchoImagenPorcentaje / 100f)
                                .Image(gym.Logo).FitWidth();
                        }

                        Centrado(gym.Nombre, destacado: true);
                        if (!string.IsNullOrWhiteSpace(gym.Domicilio)) Centrado(gym.Domicilio);
                        if (!string.IsNullOrWhiteSpace(gym.Telefono)) Centrado($"Tel. {gym.Telefono}");
                        if (!string.IsNullOrWhiteSpace(gym.Rfc)) Centrado($"RFC: {gym.Rfc}");

                        Separador();
                        Centrado("COMPROBANTE DE PAGO", destacado: true);
                        Separador();

                        // ── Socio ──
                        Fila("Clave", p.ClaveSocio);
                        Fila("Socio", p.NombreSocio);

                        Separador();

                        // ── Membresía ──
                        Fila("Membresía", p.Membresia);
                        Fila("Inicio", p.FechaInicio.ToString("dd/MM/yyyy"));
                        Fila("Vencimiento", p.FechaVencimiento.ToString("dd/MM/yyyy"));
                        Fila("Precio", p.Precio.ToString("C2"));
                        Fila("Total pagado", p.TotalPagado.ToString("C2"));
                        Fila("Estado", p.EstadoPago);

                        Separador();

                        // ── Pago ──
                        Fila("Fecha", p.Fecha.ToString("dd/MM/yyyy hh:mm tt"));
                        Fila("Forma de pago", p.FormaPago);
                        if (!string.IsNullOrWhiteSpace(p.Folio)) Fila("Folio", p.Folio);
                        if (!string.IsNullOrWhiteSpace(p.Observacion)) Fila("Observación", p.Observacion);

                        Separador();

                        Fila("MONTO", p.Monto.ToString("C2"), destacado: true);
                        Fila("Te atendió", p.Usuario);

                        // ── Pie ──
                        if (!string.IsNullOrWhiteSpace(config.TextoInferior))
                        {
                            col.Item().PaddingTop(entreSecciones);
                            Centrado(config.TextoInferior);
                        }
                    });
                });
            }).GeneratePdf();
        }
    }
}
