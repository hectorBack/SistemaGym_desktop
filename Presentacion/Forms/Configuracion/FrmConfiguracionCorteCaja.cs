using Presentacion.Controller;
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
    public partial class FrmConfiguracionCorteCaja : Form
    {
        private readonly ConfiguracionController _configuracionController;

        public FrmConfiguracionCorteCaja(ConfiguracionController configuracionController)
        {
            InitializeComponent();
            _configuracionController = configuracionController;
        }

        private async void FrmConfiguracionCorteCaja_Load(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var config = await _configuracionController.ObtenerConfigCorteCajaAsync();

                txtEfectivoInicial.Text = config.EfectivoInicial.ToString("F2");
                txtEmailNotificacion.Text = config.EmailNotificacion;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar la configuración: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (!decimal.TryParse(txtEfectivoInicial.Text.Trim(), out decimal efectivoInicial))
                {
                    MessageBox.Show("Por favor ingresa un monto válido para el efectivo inicial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var model = new CorteConfiguracionViewModel
                {
                    EfectivoInicial = efectivoInicial,
                    EmailNotificacion = txtEmailNotificacion.Text.Trim()
                };

                await _configuracionController.GuardarConfigCorteCajaAsync(model);

                MessageBox.Show("Configuración de Corte de Caja guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
