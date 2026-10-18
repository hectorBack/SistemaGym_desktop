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
    public partial class FrmConfiguracionCorreos : Form
    {
        private readonly ConfiguracionController _configuracionController;

        public FrmConfiguracionCorreos(ConfiguracionController configuracionController)
        {
            InitializeComponent();
            _configuracionController = configuracionController;
        }

        private async void FrmConfiguracionCorreos_Load(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var config = await _configuracionController.ObtenerConfigCorreosAsync();

                txtEmail.Text = config.Email;
                txtPassword.Text = config.Password;
                chkRecordatorio.Checked = config.EnviarRecordatorioVencimiento;
                chkFelicitaciones.Checked = config.EnviarFelicitaciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar la configuración de correos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var model = new CorreoConfiguracionViewModel
                {
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text,
                    EnviarRecordatorioVencimiento = chkRecordatorio.Checked,
                    EnviarFelicitaciones = chkFelicitaciones.Checked
                };

                await _configuracionController.GuardarConfigCorreosAsync(model);

                MessageBox.Show("Configuración de correos guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // 🟢 Método para manejar la acción del botón de prueba de correo
        private async void btnProbarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                btnProbarCorreo.Enabled = false;
                Cursor = Cursors.WaitCursor;

                string emailDestino = txtEmail.Text.Trim();

                if (string.IsNullOrWhiteSpace(emailDestino))
                {
                    MessageBox.Show("Por favor ingresa un correo electrónico en el campo superior antes de realizar la prueba.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                await _configuracionController.EnviarCorreoPruebaAsync(emailDestino);

                MessageBox.Show($"Correo de prueba enviado exitosamente a: {emailDestino}\nRevisa tu bandeja de entrada o spam.", "Prueba Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo enviar el correo de prueba. Asegúrate de guardar los cambios primero, que la contraseña de aplicación de 16 caracteres de Gmail sea correcta y tengas conexión a internet.\n\nDetalle: {ex.Message}", "Error de Envío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnProbarCorreo.Enabled = true;
            }
        }
    }
}
