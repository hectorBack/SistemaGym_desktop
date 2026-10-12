using Negocio.Exceptions;
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

namespace Presentacion.Forms.Movimientos
{
    public partial class FrmMovimientoModal : Form
    {
        private readonly MovimientoController _controller;
        private readonly ConceptoController _conceptoController;
        private readonly int? _movimientoId;

        // Conceptos que se pueden elegir (sin los del sistema), de ambos tipos.
        private List<ConceptoViewModel> _conceptos = new();

        // Mientras se llenan los combos no se debe reaccionar a sus cambios.
        private bool _cargando = true;
        private bool _guardando;

        // El ConceptoController ahora es obligatorio (antes era opcional y, si faltaba, el modal
        // se abría sin conceptos). Al crear uno nuevo se pasa null como segundo argumento.
        public FrmMovimientoModal(
            MovimientoController controller,
            int? movimientoId,
            ConceptoController conceptoController)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _conceptoController = conceptoController ?? throw new ArgumentNullException(nameof(conceptoController));
            _movimientoId = movimientoId;

            InitializeComponent();

            cmbTipo.Items.AddRange(new object[] { "Ingreso", "Egreso" });
            cmbFormaPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbTipo.SelectedIndex = 0;
            cmbFormaPago.SelectedIndex = 0;

            lblTitulo.Text = _movimientoId.HasValue ? "Editar Movimiento" : "Nuevo Movimiento";

            // No se puede guardar hasta que termine de cargar: si falla la carga de un movimiento
            // existente, guardar con el formulario vacío lo sobrescribiría con datos por defecto.
            btnGuardar.Enabled = false;
        }

        private static bool EsConceptoDelSistema(ConceptoViewModel concepto) =>
            concepto.EsSistema
            || (!string.IsNullOrWhiteSpace(concepto.Observacion)
                && concepto.Observacion.Contains("No se puede modificar", StringComparison.OrdinalIgnoreCase));

        // ───────────── Carga ─────────────

        private async void FrmMovimientoModal_Load(object? sender, EventArgs e)
        {
            bool cargado = await FormHelper.EjecutarAsync(
                CargarDatosAsync,
                "No se pudieron cargar los datos del movimiento.");

            if (IsDisposed) return;

            // Sin datos no tiene sentido dejar el formulario abierto.
            if (!cargado)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            btnGuardar.Enabled = true;
        }

        private async Task CargarDatosAsync()
        {
            var movimiento = _movimientoId.HasValue
                ? await _controller.ObtenerPorIdAsync(_movimientoId.Value)
                : null;

            if (_movimientoId.HasValue && movimiento == null)
                throw new BusinessException("No se encontró el movimiento.");

            // Al editar se incluyen los conceptos inactivos, para no perder el concepto actual
            // del movimiento si fue desactivado después de registrarlo.
            var conceptos = await _conceptoController.ObtenerConceptosAsync(incluirInactivos: movimiento != null);
            if (IsDisposed) return;

            _conceptos = conceptos
                .Where(c => !EsConceptoDelSistema(c)
                            && (c.Activo || (movimiento != null && c.ConceptoID == movimiento.ConceptoID)))
                .ToList();

            // Antes, si el concepto era del sistema simplemente no aparecía en la lista, el combo quedaba
            // en otro concepto y al guardar se le cambiaba el concepto al movimiento sin avisar.
            if (movimiento != null && !_conceptos.Any(c => c.ConceptoID == movimiento.ConceptoID))
                throw new BusinessException("Este movimiento pertenece a un concepto del sistema y no se puede editar.");

            _cargando = true;

            if (movimiento != null)
            {
                int indiceTipo = cmbTipo.FindStringExact(movimiento.Tipo);
                if (indiceTipo >= 0) cmbTipo.SelectedIndex = indiceTipo;

                SeleccionarFormaPago(movimiento.FormaPago);

                numTotal.Value = Math.Clamp(movimiento.Total, numTotal.Minimum, numTotal.Maximum);
                txtObservacion.Text = movimiento.Observacion;
            }

            FiltrarConceptosPorTipo(movimiento?.ConceptoID);

            _cargando = false;
        }

        // Si la forma de pago guardada no está en la lista (p. ej. una antigua), se agrega
        // para no cambiarla en silencio a "Efectivo" al guardar.
        private void SeleccionarFormaPago(string? formaPago)
        {
            if (string.IsNullOrWhiteSpace(formaPago)) return;

            int indice = cmbFormaPago.FindStringExact(formaPago);
            if (indice < 0)
                indice = cmbFormaPago.Items.Add(formaPago);

            cmbFormaPago.SelectedIndex = indice;
        }

        private void FiltrarConceptosPorTipo(int? conceptoASeleccionar = null)
        {
            string tipo = cmbTipo.SelectedItem as string ?? "Ingreso";

            var filtrados = _conceptos
                .Where(c => string.Equals(c.Tipo?.Trim(), tipo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            cmbConcepto.DataSource = filtrados;
            cmbConcepto.DisplayMember = nameof(ConceptoViewModel.Nombre);
            cmbConcepto.ValueMember = nameof(ConceptoViewModel.ConceptoID);

            if (conceptoASeleccionar.HasValue)
                cmbConcepto.SelectedValue = conceptoASeleccionar.Value;
            else
                cmbConcepto.SelectedIndex = filtrados.Count > 0 ? 0 : -1;

            lblSinConceptos.Visible = filtrados.Count == 0;
        }

        private void cmbTipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_cargando) return;

            FiltrarConceptosPorTipo();
        }

        // Al entrar al monto se selecciona todo, para escribir encima sin borrar el "0.00".
        private void numTotal_Enter(object? sender, EventArgs e) =>
            numTotal.Select(0, numTotal.Text.Length);

        // ───────────── Guardar ─────────────

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (_guardando) return;

            if (cmbConcepto.SelectedItem is not ConceptoViewModel concepto)
            {
                FormHelper.MostrarAdvertencia(
                    lblSinConceptos.Visible
                        ? "No hay conceptos activos de este tipo. Cree uno en el módulo de Conceptos."
                        : "Debe seleccionar un concepto.",
                    "Validación");
                cmbConcepto.Focus();
                return;
            }

            if (numTotal.Value <= 0)
            {
                FormHelper.MostrarAdvertencia("El monto total debe ser mayor a cero.", "Validación");
                numTotal.Focus();
                return;
            }

            string tipo = cmbTipo.SelectedItem as string ?? "Ingreso";
            string formaPago = cmbFormaPago.SelectedItem as string ?? "Efectivo";
            decimal total = numTotal.Value;
            string? observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim();

            // Capturar el ID del usuario actual desde la capa de presentación
            int usuarioActualId = SesionUsuario.UsuarioID;

            _guardando = true;
            bool guardado = await FormHelper.EjecutarAsync(
                () => _controller.GuardarMovimientoAsync(
                    _movimientoId, tipo, concepto.ConceptoID, formaPago, total, observacion, usuarioId: usuarioActualId),
                "No se pudo guardar el movimiento.",
                btnGuardar, btnCancelar);
            _guardando = false;

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
