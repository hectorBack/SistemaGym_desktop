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
    public partial class FrmConfiguracionMasConfiguraciones : Form
    {
        private readonly ConfiguracionController _configuracionController;

        public FrmConfiguracionMasConfiguraciones(ConfiguracionController configuracionController)
        {
            InitializeComponent();
            _configuracionController = configuracionController;
        }

        private async void FrmConfiguracionMasConfiguraciones_Load(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var config = await _configuracionController.ObtenerConfigMasConfiguracionesAsync();

                txtMoneda.Text = config.Moneda;
                chkEnviarPagoPorCorreo.Checked = config.EnviarPagoPorCorreo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al cargar la configuración adicional: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;

                var model = new MasConfiguracionesViewModel
                {
                    Moneda = txtMoneda.Text.Trim(),
                    EnviarPagoPorCorreo = chkEnviarPagoPorCorreo.Checked
                };

                await _configuracionController.GuardarConfigMasConfiguracionesAsync(model);
                MonedaHelper.ConfigurarSimbolo(model.Moneda);

                MessageBox.Show(
                    "Configuración adicional guardada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al guardar los cambios: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}
