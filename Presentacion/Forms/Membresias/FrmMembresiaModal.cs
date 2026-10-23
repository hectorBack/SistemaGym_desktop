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

            // 1. Inicializar ComboBox de Tipos
            if (cmbTipo.Items.Count == 0)
            {
                cmbTipo.Items.Add("Mensual");
                cmbTipo.Items.Add("Semanal");
                cmbTipo.Items.Add("Dias");
            }

            // 2. Inicializar ComboBox de Meses del 0 al 12
            if (cmbMeses.Items.Count == 0)
            {
                for (int i = 0; i <= 12; i++)
                {
                    cmbMeses.Items.Add(i);
                }
            }

            // Suscribir el evento de cambio de tipo para controlar habilitaciones
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;

            if (_membresiaId.HasValue)
            {
                txtNombre.Text = nombreActual;
                numPrecio.Value = Math.Clamp(precioActual, numPrecio.Minimum, numPrecio.Maximum);

                if (cmbTipo.Items.Contains(tipoActual))
                    cmbTipo.SelectedItem = tipoActual;
                else
                    cmbTipo.SelectedIndex = 0;

                cmbMeses.SelectedItem = Math.Clamp(mesesActual, 0, 12);
                numSemanas.Value = Math.Clamp(semanasActual, numSemanas.Minimum, numSemanas.Maximum);
                numDias.Value = Math.Clamp(diasActual, numDias.Minimum, numDias.Maximum);
            }
            else
            {
                cmbTipo.SelectedIndex = 0; // Por defecto "Mensual"
                cmbMeses.SelectedItem = 1;  // Por defecto 1 mes
            }

            // Ajustar estado inicial de habilitación según el tipo seleccionado
            ActualizarEstadoCamposDuracion();
        }

        private void cmbTipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ActualizarEstadoCamposDuracion();
        }

        private void ActualizarEstadoCamposDuracion()
        {
            string tipo = cmbTipo.SelectedItem?.ToString() ?? "Mensual";

            // Habilitar / Deshabilitar según el tipo elegido
            bool esMensual = tipo.Equals("Mensual", StringComparison.OrdinalIgnoreCase);
            bool esSemanal = tipo.Equals("Semanal", StringComparison.OrdinalIgnoreCase);
            bool esDias = tipo.Equals("Dias", StringComparison.OrdinalIgnoreCase) || tipo.Equals("Días", StringComparison.OrdinalIgnoreCase);

            cmbMeses.Enabled = esMensual;
            numSemanas.Enabled = esSemanal;
            numDias.Enabled = esDias;

            // Opcional: limpiar los campos que queden deshabilitados para evitar confusiones en datos
            if (!esMensual) cmbMeses.SelectedIndex = 0;
            if (!esSemanal) numSemanas.Value = 0;
            if (!esDias) numDias.Value = 0;
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
            int meses = cmbMeses.SelectedItem != null ? Convert.ToInt32(cmbMeses.SelectedItem) : 0;
            int semanas = (int)numSemanas.Value;
            int dias = (int)numDias.Value;

            if ((meses * 30) + (semanas * 7) + dias <= 0)
            {
                FormHelper.MostrarAdvertencia("La duración total debe ser mayor a 0.", "Validación");
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
