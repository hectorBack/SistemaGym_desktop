using Presentacion.Controller;
using Presentacion.Helpers;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Configuracion
{
    public partial class FrmConfiguracionDatosGimnasio : Form
    {
        private readonly ConfiguracionController _configuracionController;
        private string _rutaLogoTemporal = string.Empty;

        public FrmConfiguracionDatosGimnasio(ConfiguracionController configuracionController)
        {
            InitializeComponent();
            _configuracionController = configuracionController;
        }

        private async void FrmConfiguracionDatosGimnasio_Load(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var config = await _configuracionController.ObtenerConfigGimnasioAsync();

                txtNombre.Text = config.Nombre;
                txtDomicilio.Text = config.Domicilio;
                txtTelefono.Text = config.Telefono;
                txtRfc.Text = config.Rfc;
                txtMensaje.Text = config.Mensaje;
                _rutaLogoTemporal = config.Logo;

                // Mostrar el logotipo si existe ruta o imagen guardada
                ImagenHelper.MostrarEn(picLogo, ImagenHelper.CargarFoto(_rutaLogoTemporal));
            }
            catch (Exception ex)
            {
                FormHelper.MostrarError($"Ocurrió un error al cargar la configuración del gimnasio: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnExaminarLogo_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar Logotipo del Gimnasio";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _rutaLogoTemporal = openFileDialog.FileName;
                    ImagenHelper.MostrarEn(picLogo, ImagenHelper.CargarFoto(_rutaLogoTemporal));
                }
            }
        }

        // El logo se guarda en la base de datos como imagen reducida en Base64 (PNG, máx. 500 px por lado):
        // así viaja con la base y los respaldos y no depende de que el archivo original siga existiendo.
        private static string ConvertirLogoABase64(string ruta)
        {
            using var original = ImagenHelper.CargarFoto(ruta)
                ?? throw new InvalidOperationException("No se pudo leer la imagen del logotipo.");

            const int maximo = 500;
            double escala = Math.Min(1.0, (double)maximo / Math.Max(original.Width, original.Height));
            int ancho = Math.Max(1, (int)(original.Width * escala));
            int alto = Math.Max(1, (int)(original.Height * escala));

            using var reducida = new Bitmap(ancho, alto);
            using (var g = Graphics.FromImage(reducida))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, ancho, alto);
            }

            using var memoria = new MemoryStream();
            reducida.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
            return Convert.ToBase64String(memoria.ToArray());
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    FormHelper.MostrarAdvertencia("Por favor ingresa el nombre del gimnasio.", "Validación");
                    txtNombre.Focus();
                    return;
                }

                var model = new GimnasioConfiguracionViewModel
                {
                    Nombre = txtNombre.Text.Trim(),
                    Domicilio = txtDomicilio.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Rfc = txtRfc.Text.Trim(),
                    Mensaje = txtMensaje.Text.Trim(),
                    Logo = File.Exists(_rutaLogoTemporal) ? ConvertirLogoABase64(_rutaLogoTemporal) : _rutaLogoTemporal
                };

                await _configuracionController.GuardarConfigGimnasioAsync(model);
                _rutaLogoTemporal = model.Logo; // ya guardado como Base64
                Inicio.FrmInicio.InvalidarLogo(); // Inicio volverá a leer el logo

                FormHelper.MostrarAviso("Datos del gimnasio guardados correctamente.", "Éxito");
            }
            catch (Exception ex)
            {
                FormHelper.MostrarError($"Ocurrió un error al guardar los cambios: {ex.Message}");
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}
