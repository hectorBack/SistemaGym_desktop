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

        public FrmMembresiaModal(
            MembresiaController controller,
            int? membresiaId = null,
            string nombreActual = "",
            decimal precioActual = 0,
            string tipoActual = "Mensual",
            int mesesActual = 0,
            int semanasActual = 0,
            int diasActual = 0)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _membresiaId = membresiaId;

            InitializeComponent();

            lblTitulo.Text = _membresiaId.HasValue ? "Editar Membresía" : "Nueva Membresía";

            // Inicializar el ComboBox de Tipos si lo requieres
            if (cmbTipo.Items.Count == 0)
            {
                cmbTipo.Items.Add("Mensual");
                cmbTipo.Items.Add("Semanal");
                cmbTipo.Items.Add("Dias");
            }

            if (_membresiaId.HasValue)
            {
                txtNombre.Text = nombreActual;
                numPrecio.Value = Math.Clamp(precioActual, numPrecio.Minimum, numPrecio.Maximum);

                if (cmbTipo.Items.Contains(tipoActual))
                    cmbTipo.SelectedItem = tipoActual;
                else
                    cmbTipo.SelectedIndex = 0;

                numMeses.Value = Math.Clamp(mesesActual, numMeses.Minimum, numMeses.Maximum);
                numSemanas.Value = Math.Clamp(semanasActual, numSemanas.Minimum, numSemanas.Maximum);
                numDias.Value = Math.Clamp(diasActual, numDias.Minimum, numDias.Maximum);
            }
            else
            {
                cmbTipo.SelectedIndex = 0;
                numMeses.Value = 1; // Por defecto 1 mes
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

            string tipo = cmbTipo.SelectedItem?.ToString() ?? "Mensual";
            int meses = (int)numMeses.Value;
            int semanas = (int)numSemanas.Value;
            int dias = (int)numDias.Value;

            if ((meses * 30) + (semanas * 7) + dias <= 0)
            {
                FormHelper.MostrarAdvertencia("La duración total debe ser mayor a 0 (configure meses, semanas o días).", "Validación");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            decimal precio = numPrecio.Value;

            _guardando = true;
            bool guardado = await FormHelper.EjecutarAsync(
                () => _controller.GuardarMembresiaAsync(_membresiaId, nombre, precio, tipo, meses, semanas, dias),
                "No se pudo guardar la membresía.",
                btnGuardar, btnCancelar);
            _guardando = false;

            if (guardado && !IsDisposed)
                DialogResult = DialogResult.OK;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_guardando)
                e.Cancel = true;

            base.OnFormClosing(e);
        }
    }
}
