using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;

namespace Negocio.Helpers
{
    // ───────────── Modelos: solo los datos que necesita el ticket, sin depender de las entidades ─────────────

    public sealed record TicketVentaLinea(
        string Descripcion,
        decimal Cantidad,
        decimal PrecioUnitario,
        decimal Importe);

    public sealed record TicketVenta(
        string Folio,
        DateTime Fecha,
        string Usuario,
        string? Cliente,
        string FormaPago,
        IReadOnlyList<TicketVentaLinea> Lineas,
        decimal Total);

    /// <summary>
    /// Dibuja e imprime los tickets (venta y pago de membresía) usando la configuración de la pestaña Ticket
    /// (ancho, fuente, tamaños, imagen y texto inferior). Solo da formato: no consulta la base de datos.
    /// Todo se dibuja en milímetros, así que el resultado no depende del DPI de la impresora.
    /// </summary>
    public static class TicketImpresionHelper
    {
        public static void ImprimirVenta(TicketConfiguracionDto config, ComprobanteGimnasio gimnasio, TicketVenta venta)
        {
            Imprimir(config, gimnasio, (lienzo, logo) => DibujarVenta(lienzo, gimnasio, venta, logo));
        }

        public static void ImprimirPago(TicketConfiguracionDto config, ComprobanteGimnasio gimnasio, PagoCorreo pago)
        {
            Imprimir(config, gimnasio, (lienzo, logo) => DibujarPago(lienzo, gimnasio, pago, logo));
        }

        // ───────────── Contenido de cada ticket ─────────────

        private static void DibujarVenta(Lienzo l, ComprobanteGimnasio gym, TicketVenta v, Image? logo)
        {
            l.Encabezado(gym, logo, "TICKET DE VENTA");

            l.Par("Folio", v.Folio);
            l.Par("Fecha", v.Fecha.ToString("dd/MM/yyyy hh:mm tt"));
            l.Par("Atendió", v.Usuario);
            if (!string.IsNullOrWhiteSpace(v.Cliente)) l.Par("Cliente", v.Cliente);

            l.Separador();

            // Descripción (puede ocupar varios renglones) y debajo "cantidad x precio ... importe"
            foreach (var linea in v.Lineas)
            {
                l.Parrafo(linea.Descripcion);
                l.Par($"{linea.Cantidad:0.##} x {linea.PrecioUnitario:C2}", linea.Importe.ToString("C2"));
            }

            l.Separador();

            l.Par("TOTAL", v.Total.ToString("C2"), destacado: true);
            l.Par("Forma de pago", v.FormaPago);

            l.TextoInferior();
        }

        private static void DibujarPago(Lienzo l, ComprobanteGimnasio gym, PagoCorreo p, Image? logo)
        {
            l.Encabezado(gym, logo, "COMPROBANTE DE PAGO");

            l.Par("Clave", p.ClaveSocio);
            l.Par("Socio", p.NombreSocio);

            l.Separador();

            l.Par("Membresía", p.Membresia);
            l.Par("Inicio", p.FechaInicio.ToString("dd/MM/yyyy"));
            l.Par("Vencimiento", p.FechaVencimiento.ToString("dd/MM/yyyy"));
            l.Par("Precio", p.Precio.ToString("C2"));
            l.Par("Total pagado", p.TotalPagado.ToString("C2"));
            l.Par("Estado", p.EstadoPago);

            l.Separador();

            l.Par("Fecha", p.Fecha.ToString("dd/MM/yyyy hh:mm tt"));
            l.Par("Forma de pago", p.FormaPago);
            if (!string.IsNullOrWhiteSpace(p.Folio)) l.Par("Folio", p.Folio);
            if (!string.IsNullOrWhiteSpace(p.Observacion)) l.Parrafo($"Observación: {p.Observacion}");

            l.Separador();

            l.Par("MONTO", p.Monto.ToString("C2"), destacado: true);
            l.Par("Te atendió", p.Usuario);

            l.TextoInferior();
        }

        // ───────────── Impresión ─────────────

        private static void Imprimir(TicketConfiguracionDto config, ComprobanteGimnasio gimnasio, Action<Lienzo, Image?> dibujar)
        {
            using var logo = gimnasio.Logo == null ? null : CargarImagen(gimnasio.Logo);

            // Primera pasada: se mide el alto real del ticket para que el papel de rollo no salga con espacio de más.
            float altoMm;
            using (var bmp = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(bmp))
            {
                g.PageUnit = GraphicsUnit.Millimeter;
                using var lienzo = new Lienzo(g, config);
                dibujar(lienzo, logo);
                altoMm = lienzo.Alto;
            }

            using var documento = new PrintDocument();

            int ancho = (int)Math.Round(config.AnchoTicket / 25.4f * 100f);   // mm → centésimas de pulgada
            int alto = (int)Math.Ceiling(altoMm / 25.4f * 100f) + 10;

            documento.DefaultPageSettings.PaperSize = new PaperSize("Ticket", ancho, alto);
            documento.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            if (!documento.PrinterSettings.IsValid)
                throw new InvalidOperationException("No hay una impresora predeterminada configurada en Windows.");

            documento.PrintPage += (s, e) =>
            {
                var g = e.Graphics!;
                g.PageUnit = GraphicsUnit.Millimeter;
                using var lienzo = new Lienzo(g, config);
                dibujar(lienzo, logo);
                e.HasMorePages = false;
            };

            documento.Print();
        }

        private static Image? CargarImagen(byte[] bytes)
        {
            try
            {
                using var stream = new MemoryStream(bytes);
                using var original = Image.FromStream(stream);
                return new Bitmap(original);   // copia: no depende del stream
            }
            catch
            {
                return null;   // formato no soportado: se imprime sin logo
            }
        }

        // ───────────── Lienzo: va dibujando de arriba hacia abajo y lleva la cuenta de la altura ─────────────

        private sealed class Lienzo : IDisposable
        {
            private const float Margen = 2f;   // mm

            private readonly Graphics _g;
            private readonly TicketConfiguracionDto _c;
            private readonly Font _texto;
            private readonly Font _encabezado;
            private readonly StringFormat _izquierda = new() { FormatFlags = StringFormatFlags.NoClip };
            private readonly StringFormat _centro = new() { Alignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip };
            private readonly StringFormat _derecha = new() { Alignment = StringAlignment.Far, FormatFlags = StringFormatFlags.NoClip };
            private readonly Pen _guiones = new(Color.Black, 0.2f) { DashStyle = DashStyle.Dash };

            private readonly float _util;
            private readonly float _renglon;
            private readonly float _renglonEnc;
            private readonly float _entre;
            private float _y = Margen;

            public Lienzo(Graphics g, TicketConfiguracionDto c)
            {
                _g = g;
                _c = c;
                _util = c.AnchoTicket - Margen * 2;
                _renglon = Mm(c.TamanoRenglon);
                _renglonEnc = Mm(c.TamanoRenglonEncabezado);
                _entre = Mm(c.TamanoEntreSecciones);
                _texto = new Font(c.NombreFuente, c.TamanoTexto);
                _encabezado = new Font(c.NombreFuente, c.TamanoTextoEncabezado, FontStyle.Bold);
            }

            /// <summary>Alto total del ticket en milímetros.</summary>
            public float Alto => _y + Margen;

            // Puntos tipográficos → milímetros
            private static float Mm(float puntos) => puntos * 25.4f / 72f;

            public void Encabezado(ComprobanteGimnasio gym, Image? logo, string titulo)
            {
                if (logo != null)
                {
                    float w = _util * _c.AnchoImagenPorcentaje / 100f;
                    float h = w * logo.Height / logo.Width;
                    _g.DrawImage(logo, Margen + (_util - w) / 2f, _y, w, h);
                    _y += h + _entre;
                }

                Centrado(gym.Nombre, destacado: true);
                if (!string.IsNullOrWhiteSpace(gym.Domicilio)) Centrado(gym.Domicilio);
                if (!string.IsNullOrWhiteSpace(gym.Telefono)) Centrado($"Tel. {gym.Telefono}");
                if (!string.IsNullOrWhiteSpace(gym.Rfc)) Centrado($"RFC: {gym.Rfc}");

                Separador();
                Centrado(titulo, destacado: true);
                Separador();
            }

            public void TextoInferior()
            {
                if (string.IsNullOrWhiteSpace(_c.TextoInferior)) return;

                _y += _entre;
                Centrado(_c.TextoInferior);
            }

            // Texto centrado; crece si ocupa varios renglones (domicilio largo, texto inferior).
            private void Centrado(string texto, bool destacado = false)
            {
                var fuente = destacado ? _encabezado : _texto;
                float minimo = destacado ? _renglonEnc : _renglon;

                float alto = Math.Max(minimo, _g.MeasureString(texto, fuente, new SizeF(_util, 10000f), _centro).Height);
                _g.DrawString(texto, fuente, Brushes.Black, new RectangleF(Margen, _y, _util, alto), _centro);
                _y += alto;
            }

            // Texto a la izquierda que se ajusta en varios renglones (descripción de producto, observaciones).
            public void Parrafo(string texto)
            {
                float alto = Math.Max(_renglon, _g.MeasureString(texto, _texto, new SizeF(_util, 10000f), _izquierda).Height);
                _g.DrawString(texto, _texto, Brushes.Black, new RectangleF(Margen, _y, _util, alto), _izquierda);
                _y += alto;
            }

            // Etiqueta a la izquierda y valor a la derecha. Si no caben en una línea, el valor baja al renglón siguiente.
            public void Par(string izquierda, string valor, bool destacado = false)
            {
                var fuente = destacado ? _encabezado : _texto;
                float alto = destacado ? _renglonEnc : _renglon;

                float anchoEtiqueta = _g.MeasureString(izquierda, fuente).Width;
                float anchoValor = _g.MeasureString(valor, fuente).Width;

                if (anchoEtiqueta + anchoValor <= _util)
                {
                    var rect = new RectangleF(Margen, _y, _util, alto);
                    _g.DrawString(izquierda, fuente, Brushes.Black, rect, _izquierda);
                    _g.DrawString(valor, fuente, Brushes.Black, rect, _derecha);
                    _y += alto;
                    return;
                }

                _g.DrawString(izquierda, fuente, Brushes.Black, new RectangleF(Margen, _y, _util, alto), _izquierda);
                _y += alto;

                float altoValor = Math.Max(alto, _g.MeasureString(valor, fuente, new SizeF(_util, 10000f), _derecha).Height);
                _g.DrawString(valor, fuente, Brushes.Black, new RectangleF(Margen, _y, _util, altoValor), _derecha);
                _y += altoValor;
            }

            public void Separador()
            {
                _y += _entre / 2f;
                _g.DrawLine(_guiones, Margen, _y, Margen + _util, _y);
                _y += _entre / 2f;
            }

            public void Dispose()
            {
                _texto.Dispose();
                _encabezado.Dispose();
                _izquierda.Dispose();
                _centro.Dispose();
                _derecha.Dispose();
                _guiones.Dispose();
            }
        }
    }
}