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
        private bool _guardando;

        public FrmConceptoModal(
            ConceptoController controller,
            int? conceptoId = null,
            string nombreActual = "",
            string tipoActual = "",
            string observacionActual = "")
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _conceptoId = conceptoId;

            InitializeComponent();

            cmbTipo.Items.AddRange(new object[] { "Ingreso", "Egreso" });

            if (_conceptoId.HasValue)
            {
                lblTitulo.Text = "Editar Concepto";
                txtNombre.Text = nombreActual;
                txtObservacion.Text = observacionActual;

                // FindStringExact ignora mayúsculas; si el tipo guardado no coincide con ninguno,
                // se deja sin seleccionar para obligar a elegirlo (antes quedaba vacío en silencio).
                cmbTipo.SelectedIndex = cmbTipo.FindStringExact(tipoActual);
            }
            else
            {
                lblTitulo.Text = "Nuevo Concepto";
                cmbTipo.SelectedIndex = 0;
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (_guardando) return;

            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                FormHelper.MostrarAdvertencia("Debe ingresar un nombre para el concepto.", "Validación");
                txtNombre.Focus();
                return;
            }

            if (cmbTipo.SelectedItem is not string tipo || string.IsNullOrWhiteSpace(tipo))
            {
                FormHelper.MostrarAdvertencia("Debe seleccionar un tipo para el concepto.", "Validación");
                cmbTipo.Focus();
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string observacion = txtObservacion.Text.Trim();

            _guardando = true;
            bool guardado = await FormHelper.EjecutarAsync(
                () => _controller.GuardarConceptoAsync(_conceptoId, nombre, tipo, observacion),
                "No se pudo guardar el concepto.",
                btnGuardar, btnCancelar);
            _guardando = false;

            // Sin mensaje de éxito: al cerrarse el diálogo y recargarse la lista, el resultado es evidente.
            if (guardado && !IsDisposed)
                DialogResult = DialogResult.OK;
        }

        // No permitir cerrar la ventana mientras se está guardando.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_guardando)
                e.Cancel = true;

            base.OnFormClosing(e);
        }
    }
}
