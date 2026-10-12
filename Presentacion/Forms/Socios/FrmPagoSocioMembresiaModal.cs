using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.ViewModels.TuProyecto.Presentacion.ViewModels;
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
using Presentacion.Helpers;

namespace Presentacion.Forms.Socios
{
    public partial class FrmPagoSocioMembresiaModal : Form
    {
        private readonly PagoSocioMembresiaController _controller;
        private readonly SocioMembresiaViewModel _socioMembresia;
        private readonly int _usuarioId;

        private ListaOrdenable<PagoSocioMembresiaViewModel> _vista = new();
        private decimal _saldoPendiente;
        private bool _guardando;

        public FrmPagoSocioMembresiaModal(
            PagoSocioMembresiaController controller,
            SocioMembresiaViewModel socioMembresia,
            int usuarioId)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _socioMembresia = socioMembresia ?? throw new ArgumentNullException(nameof(socioMembresia));
            _usuarioId = usuarioId;

            InitializeComponent();
            ConfigurarColumnas();

            lblFechaInicio.Text = _socioMembresia.FechaInicioTexto;
            lblPrecioMembresia.Text = _socioMembresia.Precio.ToString("C2");
            cmbTipoPago.SelectedIndex = 0;
        }

        private PagoSocioMembresiaViewModel? PagoSeleccionado =>
            dgvPagos.SelectedRows.Count > 0
                ? dgvPagos.SelectedRows[0].DataBoundItem as PagoSocioMembresiaViewModel
                : null;

        // ───────────── Columnas ─────────────

        private void ConfigurarColumnas()
        {
            dgvPagos.AutoGenerateColumns = false;

            // La fecha llega ya formateada como texto: no se ordena alfabéticamente.
            dgvPagos.AgregarTexto(nameof(PagoSocioMembresiaViewModel.FechaFormateada), "Fecha", 130, 110)
                .SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPagos.AgregarTexto(nameof(PagoSocioMembresiaViewModel.Monto), "Monto", 85, 80, "C2", alinearDerecha: true);
            dgvPagos.AgregarTexto(nameof(PagoSocioMembresiaViewModel.FormaPago), "Forma de pago", 110, 95);
            dgvPagos.AgregarTexto(nameof(PagoSocioMembresiaViewModel.Folio), "Folio", 90, 70);
            dgvPagos.AgregarTexto(nameof(PagoSocioMembresiaViewModel.Estado), "Estado", 90, 80);
            dgvPagos.AgregarTexto(nameof(PagoSocioMembresiaViewModel.Observacion), "Observación", 160, 100);
        }

        // ───────────── Carga ─────────────

        private async void FrmPagoSocioMembresiaModal_Load(object? sender, EventArgs e)
        {
            await CargarPagosAsync();
        }

        private async Task CargarPagosAsync()
        {
            int? idObjetivo = PagoSeleccionado?.PagoID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var pagos = await _controller.ObtenerPorSocioMembresiaIdAsync(_socioMembresia.SocioMembresiaID);
                if (IsDisposed) return;

                _vista = new ListaOrdenable<PagoSocioMembresiaViewModel>(pagos);
                dgvPagos.DataSource = _vista;

                ActualizarResumen();
                SeleccionarPago(idObjetivo);
            },
            "No se pudieron cargar los pagos.",
            grpRegistrarPago);
        }

        // Total pagado = suma de los pagos vigentes (los anulados no cuentan).
        private void ActualizarResumen()
        {
            decimal totalPagado = _vista.Where(p => p.Activo).Sum(p => p.Monto);
            _saldoPendiente = Math.Max(0, _socioMembresia.Precio - totalPagado);

            lblTotalPagado.Text = totalPagado.ToString("C2");

            if (_saldoPendiente == 0)
            {
                lblEstadoPago.Text = "PAGADA";
                lblEstadoPago.ForeColor = Tema.Exito;
            }
            else
            {
                lblEstadoPago.Text = totalPagado > 0
                    ? $"PARCIAL · Saldo {_saldoPendiente:C2}"
                    : $"PENDIENTE · Saldo {_saldoPendiente:C2}";
                lblEstadoPago.ForeColor = Tema.Advertencia;
            }

            // El monto sugerido es el saldo; si ya está liquidada no hay nada que registrar.
            nudMonto.Maximum = Math.Max(_saldoPendiente, 0.01m);
            nudMonto.Value = Math.Max(_saldoPendiente, 0.01m);

            bool puedePagar = _saldoPendiente > 0;
            nudMonto.Enabled = puedePagar;
            btnAgregarPago.Enabled = puedePagar;
        }

        private void SeleccionarPago(int? id)
        {
            dgvPagos.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].PagoID != id.Value) continue;

                    dgvPagos.Rows[i].Selected = true;
                    dgvPagos.CurrentCell = dgvPagos.Rows[i].Cells[0];
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Solo se puede anular un pago seleccionado que siga vigente.
        private void ActualizarEstadoBotones()
        {
            var pago = PagoSeleccionado;
            btnAnularPago.Enabled = pago != null && pago.Activo;
        }

        private void dgvPagos_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Los pagos anulados se ven atenuados.
        private void dgvPagos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            if (!_vista[e.RowIndex].Activo)
                e.CellStyle!.ForeColor = Tema.TextoAtenuado;
        }

        // ───────────── Registrar ─────────────

        private async void btnAgregarPago_Click(object? sender, EventArgs e)
        {
            if (_guardando) return;

            decimal monto = nudMonto.Value;

            if (monto <= 0)
            {
                FormHelper.MostrarAdvertencia("El monto debe ser mayor a cero.", "Validación");
                nudMonto.Focus();
                return;
            }

            if (monto > _saldoPendiente)
            {
                FormHelper.MostrarAdvertencia(
                    $"El monto no puede ser mayor al saldo pendiente ({_saldoPendiente:C2}).", "Validación");
                nudMonto.Focus();
                return;
            }

            string formaPago = cmbTipoPago.Text;
            if (string.IsNullOrWhiteSpace(formaPago))
            {
                FormHelper.MostrarAdvertencia("Seleccione la forma de pago.", "Validación");
                cmbTipoPago.Focus();
                return;
            }

            // Un pago afecta la caja: se confirma antes de registrarlo.
            if (!FormHelper.ConfirmarAccion(
                    $"¿Registrar un pago de {monto:C2} en {formaPago}?", "Registrar pago"))
                return;

            string folio = txtFolio.Text.Trim();
            string observacion = txtObservacion.Text.Trim();

            _guardando = true;
            bool guardado;
            try
            {
                guardado = await FormHelper.EjecutarAsync(
                    () => _controller.GuardarPagoAsync(
                        pagoId: null,
                        socioMembresiaId: _socioMembresia.SocioMembresiaID,
                        usuarioId: _usuarioId,
                        monto: monto,
                        folio: folio,
                        formaPago: formaPago,
                        observacion: observacion),
                    "No se pudo registrar el pago.",
                    grpRegistrarPago);
            }
            finally
            {
                _guardando = false;
            }

            if (!guardado || IsDisposed) return;

            txtFolio.Clear();
            txtObservacion.Clear();
            await CargarPagosAsync();
        }

        // ───────────── Anular ─────────────

        private async void btnAnularPago_Click(object? sender, EventArgs e)
        {
            if (_guardando) return;

            var pago = PagoSeleccionado;
            if (pago == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea anular el pago de {pago.Monto:C2} del {pago.FechaFormateada}?\n\nEl monto dejará de contar como pagado.",
                    "Anular pago",
                    destructiva: true))
                return;

            _guardando = true;
            bool anulado;
            try
            {
                anulado = await FormHelper.EjecutarAsync(
                    () => _controller.AnularPagoAsync(
                        pago.PagoID, _usuarioId, "Cancelación de pago realizada desde el modal."),
                    "No se pudo anular el pago.",
                    panelAccionesPagos);
            }
            finally
            {
                _guardando = false;
            }

            if (anulado && !IsDisposed)
                await CargarPagosAsync();
        }

        // ───────────── Cierre ─────────────

        // No se puede cerrar mientras se guarda o anula un pago.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_guardando)
            {
                e.Cancel = true;
                return;
            }

            base.OnFormClosing(e);
        }
    }
}
