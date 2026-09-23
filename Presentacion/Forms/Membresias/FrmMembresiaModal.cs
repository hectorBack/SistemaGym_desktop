using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Membresias
{
    public partial class FrmMembresiaModal : Form
    {
        private readonly MembresiaController _controller;
        private readonly int? _membresiaId;

        public FrmMembresiaModal(MembresiaController controller, int? membresiaId = null, string nombreActual = "", decimal precioActual = 0, int duracionDiasActual = 0)
        {
            InitializeComponent();
            _controller = controller;
            _membresiaId = membresiaId;

            if (_membresiaId.HasValue)
            {
                lblTitulo.Text = "Editar Membresía";
                txtNombre.Text = nombreActual;
                numPrecio.Value = precioActual;
                numDuracionDias.Value = duracionDiasActual;
            }
            else
            {
                lblTitulo.Text = "Nueva Membresía";
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para la membresía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("Debe ingresar un precio mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numDuracionDias.Value <= 0)
            {
                MessageBox.Show("Debe ingresar una duración en días mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _controller.GuardarMembresiaAsync(
                    _membresiaId,
                    txtNombre.Text.Trim(),
                    numPrecio.Value,
                    (int)numDuracionDias.Value
                );

                MessageBox.Show("Membresía guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
