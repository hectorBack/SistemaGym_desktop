using Presentacion.Controller;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Configuracion
{
    public partial class FrmConfiguracionTicket : Form
    {
        private readonly ConfiguracionController _configuracionController;

        public FrmConfiguracionTicket(ConfiguracionController configuracionController)
        {
            InitializeComponent();
            _configuracionController = configuracionController;

            // Solo fuentes instaladas: así el nombre guardado siempre existe en esta computadora.
            cmbFuente.Items.AddRange(FontFamily.Families.Select(f => f.Name).Cast<object>().ToArray());
        }

        private async void FrmConfiguracionTicket_Load(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var config = await _configuracionController.ObtenerConfigTicketAsync();

                chkHabilitarImpresora.Checked = config.HabilitarImpresora;
                txtTextoInferior.Text = config.TextoInferior;

                nudAnchoTicket.Value = Limitar(nudAnchoTicket, config.AnchoTicket);
                nudAnchoImagen.Value = Limitar(nudAnchoImagen, config.AnchoImagenPorcentaje);
                nudTamanoTexto.Value = Limitar(nudTamanoTexto, config.TamanoTexto);
                nudTamanoRenglon.Value = Limitar(nudTamanoRenglon, config.TamanoRenglon);
                nudTamanoTextoEncabezado.Value = Limitar(nudTamanoTextoEncabezado, config.TamanoTextoEncabezado);
                nudTamanoRenglonEncabezado.Value = Limitar(nudTamanoRenglonEncabezado, config.TamanoRenglonEncabezado);
                nudTamanoEntreSecciones.Value = Limitar(nudTamanoEntreSecciones, config.TamanoEntreSecciones);

                int indiceFuente = cmbFuente.FindStringExact(config.NombreFuente);
                if (indiceFuente < 0) indiceFuente = Math.Max(cmbFuente.FindStringExact("Arial"), 0);
                cmbFuente.SelectedIndex = indiceFuente;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar la configuración del ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Un NumericUpDown lanza error si se le asigna un valor fuera de su rango; así un dato viejo no rompe la pantalla.
        private static int Limitar(NumericUpDown control, int valor) =>
            Math.Min(Math.Max(valor, (int)control.Minimum), (int)control.Maximum);

        private TicketConfiguracionViewModel LeerFormulario()
        {
            return new TicketConfiguracionViewModel
            {
                HabilitarImpresora = chkHabilitarImpresora.Checked,
                TextoInferior = txtTextoInferior.Text.Trim(),
                AnchoTicket = (int)nudAnchoTicket.Value,
                AnchoImagenPorcentaje = (int)nudAnchoImagen.Value,
                NombreFuente = cmbFuente.Text,
                TamanoTexto = (int)nudTamanoTexto.Value,
                TamanoRenglon = (int)nudTamanoRenglon.Value,
                TamanoTextoEncabezado = (int)nudTamanoTextoEncabezado.Value,
                TamanoRenglonEncabezado = (int)nudTamanoRenglonEncabezado.Value,
                TamanoEntreSecciones = (int)nudTamanoEntreSecciones.Value
            };
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;
                btnGuardarImprimir.Enabled = false;

                await _configuracionController.GuardarConfigTicketAsync(LeerFormulario());

                MessageBox.Show("Configuración del ticket guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
                btnGuardarImprimir.Enabled = true;
            }
        }

        // Guarda y manda un ticket de prueba a la impresora predeterminada para ver cómo queda.
        private async void btnGuardarImprimir_Click(object sender, EventArgs e)
        {
            if (!chkHabilitarImpresora.Checked)
            {
                MessageBox.Show("Para imprimir, primero marca \"Habilitar impresora\".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkHabilitarImpresora.Focus();
                return;
            }

            Image? logo = null;
            try
            {
                btnGuardar.Enabled = false;
                btnGuardarImprimir.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var model = LeerFormulario();
                await _configuracionController.GuardarConfigTicketAsync(model);

                var gimnasio = await _configuracionController.ObtenerConfigGimnasioAsync();
                logo = CargarLogo(gimnasio.Logo);

                ImprimirTicketPrueba(model, string.IsNullOrWhiteSpace(gimnasio.Nombre) ? "Gimnasio" : gimnasio.Nombre, logo);

                MessageBox.Show("Configuración guardada. El ticket de prueba se envió a la impresora.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo completar la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                logo?.Dispose();
                Cursor = Cursors.Default;
                btnGuardar.Enabled = true;
                btnGuardarImprimir.Enabled = true;
            }
        }

        // El logo del gimnasio puede estar guardado como ruta de archivo o como Base64. Si no se puede leer, se imprime sin logo.
        private static Image? CargarLogo(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return null;

            try
            {
                string v = valor.Trim();
                byte[] bytes;

                if (File.Exists(v))
                {
                    bytes = File.ReadAllBytes(v);
                }
                else
                {
                    int marca = v.IndexOf("base64,", StringComparison.OrdinalIgnoreCase);
                    bytes = Convert.FromBase64String(marca >= 0 ? v.Substring(marca + 7) : v);
                }

                using var stream = new MemoryStream(bytes);
                using var original = Image.FromStream(stream);
                return new Bitmap(original);   // copia: no depende del stream
            }
            catch
            {
                return null;
            }
        }

        // Puntos tipográficos → centésimas de pulgada (la unidad con la que dibuja la impresora).
        private static float Pt(float puntos) => puntos / 72f * 100f;

        private static void ImprimirTicketPrueba(TicketConfiguracionViewModel m, string nombreGimnasio, Image? logo)
        {
            using var documento = new PrintDocument();

            float ancho = m.AnchoTicket / 25.4f * 100f;   // mm → centésimas de pulgada
            documento.DefaultPageSettings.PaperSize = new PaperSize("Ticket", (int)ancho, 1200);
            documento.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            if (!documento.PrinterSettings.IsValid)
                throw new InvalidOperationException("No hay una impresora predeterminada configurada en Windows.");

            documento.PrintPage += (s, e) =>
            {
                var g = e.Graphics!;
                float margen = 15f;
                float anchoUtil = ancho - margen * 2;
                float y = margen;

                using var fuenteTexto = new Font(m.NombreFuente, m.TamanoTexto);
                using var fuenteEncabezado = new Font(m.NombreFuente, m.TamanoTextoEncabezado, FontStyle.Bold);
                using var centro = new StringFormat { Alignment = StringAlignment.Center };
                using var derecha = new StringFormat { Alignment = StringAlignment.Far };

                // Logo
                if (logo != null)
                {
                    float w = anchoUtil * m.AnchoImagenPorcentaje / 100f;
                    float h = w * logo.Height / logo.Width;
                    g.DrawImage(logo, margen + (anchoUtil - w) / 2f, y, w, h);
                    y += h + Pt(m.TamanoEntreSecciones);
                }

                // Encabezado
                g.DrawString(nombreGimnasio, fuenteEncabezado, Brushes.Black,
                    new RectangleF(margen, y, anchoUtil, Pt(m.TamanoRenglonEncabezado)), centro);
                y += Pt(m.TamanoRenglonEncabezado);

                g.DrawString("TICKET DE PRUEBA", fuenteEncabezado, Brushes.Black,
                    new RectangleF(margen, y, anchoUtil, Pt(m.TamanoRenglonEncabezado)), centro);
                y += Pt(m.TamanoRenglonEncabezado) + Pt(m.TamanoEntreSecciones);

                // Cuerpo
                var lineas = new (string Etiqueta, string Valor)[]
                {
                    ("Fecha", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")),
                    ("Socio", "Socio de ejemplo"),
                    ("Membresía", "Mensual"),
                    ("Forma de pago", "Efectivo"),
                    ("Monto", 100m.ToString("C2"))
                };

                foreach (var (etiqueta, valor) in lineas)
                {
                    var rect = new RectangleF(margen, y, anchoUtil, Pt(m.TamanoRenglon));
                    g.DrawString(etiqueta, fuenteTexto, Brushes.Black, rect);
                    g.DrawString(valor, fuenteTexto, Brushes.Black, rect, derecha);
                    y += Pt(m.TamanoRenglon);
                }

                // Texto inferior
                if (!string.IsNullOrWhiteSpace(m.TextoInferior))
                {
                    y += Pt(m.TamanoEntreSecciones);
                    SizeF medida = g.MeasureString(m.TextoInferior, fuenteTexto, (int)anchoUtil);
                    g.DrawString(m.TextoInferior, fuenteTexto, Brushes.Black,
                        new RectangleF(margen, y, anchoUtil, medida.Height), centro);
                }

                e.HasMorePages = false;
            };

            documento.Print();
        }
    }
}
