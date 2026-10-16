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
                MessageBox.Show($"Ocurrió un error al cargar la configuración del gimnasio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Por favor ingresa el nombre del gimnasio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Logo = _rutaLogoTemporal
                };

                await _configuracionController.GuardarConfigGimnasioAsync(model);

                MessageBox.Show("Datos del gimnasio guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}
