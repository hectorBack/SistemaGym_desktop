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
    public partial class FrmConfiguracionRespaldos : Form
    {
        private readonly ConfiguracionController _configuracionController;

        public FrmConfiguracionRespaldos(ConfiguracionController configuracionController)
        {
            InitializeComponent();
            _configuracionController = configuracionController ?? throw new ArgumentNullException(nameof(configuracionController));
        }

        private async void FrmConfiguracionRespaldos_Load(object? sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var config = await _configuracionController.ObtenerConfigRespaldosAsync();
                txtRuta.Text = config.RutaRespaldo;
            }
            catch (Exception ex)
            {
                FormHelper.MostrarError($"Ocurrió un error al cargar la configuración de respaldos: {ex.Message}", "Error");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSeleccionarCarpeta_Click(object? sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona la ruta donde deseas que se generen tus respaldos";
                folderDialog.UseDescriptionForTitle = true;

                if (!string.IsNullOrWhiteSpace(txtRuta.Text) && Directory.Exists(txtRuta.Text))
                {
                    folderDialog.SelectedPath = txtRuta.Text;
                }

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = folderDialog.SelectedPath;
                }
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;

                if (string.IsNullOrWhiteSpace(txtRuta.Text))
                {
                    FormHelper.MostrarAdvertencia("Por favor selecciona o ingresa una ruta para los respaldos.", "Validación");
                    txtRuta.Focus();
                    return;
                }

                var model = new RespaldosConfiguracionViewModel
                {
                    RutaRespaldo = txtRuta.Text.Trim()
                };

                await _configuracionController.GuardarConfigRespaldosAsync(model);
                FormHelper.MostrarAviso("Configuración de respaldos guardada correctamente.", "Éxito");
            }
            catch (Exception ex)
            {
                FormHelper.MostrarError($"Ocurrió un error al guardar los cambios: {ex.Message}", "Error");
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}
