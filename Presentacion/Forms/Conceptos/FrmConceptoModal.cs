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

namespace Presentacion.Forms.Conceptos
{
    public partial class FrmConceptoModal : Form
    {
        private readonly ConceptoController _controller;
        private readonly int? _conceptoId;

        public FrmConceptoModal(ConceptoController controller, int? conceptoId = null, string nombreActual = "", string tipoActual = "", string observacionActual = "")
        {
            InitializeComponent();
            _controller = controller;
            _conceptoId = conceptoId;

            // Inicializar opciones del ComboBox de Tipo
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Ingreso");
            cmbTipo.Items.Add("Egreso");

            if (_conceptoId.HasValue)
            {
                lblTitulo.Text = "Editar Concepto";
                txtNombre.Text = nombreActual;
                cmbTipo.SelectedItem = tipoActual;
                txtObservacion.Text = observacionActual;
            }
            else
            {
                lblTitulo.Text = "Nuevo Concepto";
                if (cmbTipo.Items.Count > 0)
                {
                    cmbTipo.SelectedIndex = 0;
                }
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para el concepto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTipo.SelectedItem == null || string.IsNullOrWhiteSpace(cmbTipo.SelectedItem.ToString()))
            {
                MessageBox.Show("Debe seleccionar un tipo para el concepto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombre = txtNombre.Text.Trim();
                string tipo = cmbTipo.SelectedItem.ToString()!;
                string observacion = txtObservacion.Text.Trim();

                await _controller.GuardarConceptoAsync(_conceptoId, nombre, tipo, observacion);

                MessageBox.Show("Concepto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
