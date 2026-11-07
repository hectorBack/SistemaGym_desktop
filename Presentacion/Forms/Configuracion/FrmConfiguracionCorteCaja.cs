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
                FormHelper.MostrarError($"Ocurrió un error al cargar la configuración: {ex.Message}");
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
                    FormHelper.MostrarAdvertencia("Por favor ingresa un monto válido para el efectivo inicial.", "Validación");
                    return;
                }

                var model = new CorteConfiguracionViewModel
                {
                    EfectivoInicial = efectivoInicial,
                    EmailNotificacion = txtEmailNotificacion.Text.Trim()
                };

                await _configuracionController.GuardarConfigCorteCajaAsync(model);

                FormHelper.MostrarAviso("Configuración de Corte de Caja guardada correctamente.", "Éxito");
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
