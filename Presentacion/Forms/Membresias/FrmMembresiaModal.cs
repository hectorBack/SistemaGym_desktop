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
        private bool _guardando;

        public FrmMembresiaModal(MembresiaController controller, int? membresiaId = null, string nombreActual = "", decimal precioActual = 0, int duracionDiasActual = 0)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _membresiaId = membresiaId;

            InitializeComponent();

            lblTitulo.Text = _membresiaId.HasValue ? "Editar Membresía" : "Nueva Membresía";

            if (_membresiaId.HasValue)
            {
                txtNombre.Text = nombreActual;

                // Math.Clamp evita que un valor fuera de rango en la base de datos
                // lance una excepción al abrir el formulario.
                numPrecio.Value = Math.Clamp(precioActual, numPrecio.Minimum, numPrecio.Maximum);
                numDuracionDias.Value = Math.Clamp(duracionDiasActual, (int)numDuracionDias.Minimum, (int)numDuracionDias.Maximum);
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                FormHelper.MostrarAdvertencia("Debe ingresar un nombre para la membresía.", "Validación");
                txtNombre.Focus();
                return;
            }

            if (numPrecio.Value <= 0)
            {
                FormHelper.MostrarAdvertencia("Debe ingresar un precio mayor a 0.", "Validación");
                numPrecio.Focus();
                return;
            }

            if (numDuracionDias.Value <= 0)
            {
                FormHelper.MostrarAdvertencia("Debe ingresar una duración en días mayor a 0.", "Validación");
                numDuracionDias.Focus();
                return;
            }

            string nombre = txtNombre.Text.Trim();
            decimal precio = numPrecio.Value;
            int duracionDias = (int)numDuracionDias.Value;

            _guardando = true;
            bool guardado = await FormHelper.EjecutarAsync(
                () => _controller.GuardarMembresiaAsync(_membresiaId, nombre, precio, duracionDias),
                "No se pudo guardar la membresía.",
                btnGuardar, btnCancelar);
            _guardando = false;

            if (guardado && !IsDisposed)
                DialogResult = DialogResult.OK; // cierra el diálogo; el grid se recarga solo
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
