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

namespace Presentacion.Forms.Socios
{
    public partial class FrmPagoSocioMembresiaModal : Form
    {
        private readonly PagoSocioMembresiaController _controller;
        private readonly SocioMembresiaViewModel _socioMembresia;
        private decimal _montoTotalMembresia;

        public FrmPagoSocioMembresiaModal(
            PagoSocioMembresiaController controller,
            SocioMembresiaViewModel socioMembresia)
        {
            InitializeComponent();
            _controller = controller;
            _socioMembresia = socioMembresia;
        }

        private async void FrmPagoSocioMembresiaModal_Load(object sender, EventArgs e)
        {
            CargarComboTipoPago();
            CargarDatosMembresia();
            await CargarHistorialPagosAsync();
        }

        private void CargarComboTipoPago()
        {
            cmbTipoPago.Items.Clear();
            cmbTipoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbTipoPago.SelectedIndex = 0;
        }

        private void CargarDatosMembresia()
        {
            // Cargar fecha y precio desde el ViewModel de SocioMembresia
            lblFechaInicio.Text = _socioMembresia.FechaInicioTexto;
            _montoTotalMembresia = _socioMembresia.Precio;
            lblPrecioMembresia.Text = _montoTotalMembresia.ToString("C2");
        }

        private async Task CargarHistorialPagosAsync()
        {
            try
            {
                var pagos = await _controller.ObtenerPorSocioMembresiaIdAsync(_socioMembresia.SocioMembresiaID);
                var listaPagos = pagos.ToList();

                dgvPagos.DataSource = null;
                dgvPagos.DataSource = listaPagos;
                ConfigurarGridPagos();

                // Calcular Total Pagado y Saldo Pendiente
                decimal totalPagado = listaPagos.Where(p => p.Activo).Sum(p => p.Monto);
                decimal saldoPendiente = _montoTotalMembresia - totalPagado;

                lblTotalPagado.Text = totalPagado.ToString("C2");
                ActualizarEstadoPagoLabel(totalPagado, _montoTotalMembresia);

                // Asignar por defecto el resto pendiente en el campo de texto del importe
                txtImporte.Text = saldoPendiente > 0 ? saldoPendiente.ToString("F2") : "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial de pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadoPagoLabel(decimal totalPagado, decimal precioTotal)
        {
            if (totalPagado >= precioTotal)
            {
                lblEstadoPago.Text = "Pagado";
                lblEstadoPago.ForeColor = Color.ForestGreen;
            }
            else if (totalPagado > 0)
            {
                lblEstadoPago.Text = "Pago Parcial";
                lblEstadoPago.ForeColor = Color.Orange;
            }
            else
            {
                lblEstadoPago.Text = "Sin pagar";
                lblEstadoPago.ForeColor = Color.Red;
            }
        }

        private void ConfigurarGridPagos()
        {
            // Ocultar IDs y propiedades crudas/innecesarias
            if (dgvPagos.Columns["PagoID"] != null) dgvPagos.Columns["PagoID"].Visible = false;
            if (dgvPagos.Columns["SocioMembresiaID"] != null) dgvPagos.Columns["SocioMembresiaID"].Visible = false;
            if (dgvPagos.Columns["Monto"] != null) dgvPagos.Columns["Monto"].Visible = false; // Usamos MontoFormateado
            if (dgvPagos.Columns["CreatedAt"] != null) dgvPagos.Columns["CreatedAt"].Visible = false;

            // Configurar títulos de columnas
            if (dgvPagos.Columns["FechaFormateada"] != null)
            {
                dgvPagos.Columns["FechaFormateada"].HeaderText = "Fecha Pago";
                dgvPagos.Columns["FechaFormateada"].DisplayIndex = 0;
            }

            if (dgvPagos.Columns["MontoFormateado"] != null)
            {
                dgvPagos.Columns["MontoFormateado"].HeaderText = "Importe";
                dgvPagos.Columns["MontoFormateado"].DisplayIndex = 1;
            }

            if (dgvPagos.Columns["FormaPago"] != null)
            {
                dgvPagos.Columns["FormaPago"].HeaderText = "Tipo Pago";
                dgvPagos.Columns["FormaPago"].DisplayIndex = 2;
            }

            if (dgvPagos.Columns["Folio"] != null)
            {
                dgvPagos.Columns["Folio"].HeaderText = "Folio";
                dgvPagos.Columns["Folio"].DisplayIndex = 3;
            }

            if (dgvPagos.Columns["Observacion"] != null)
            {
                dgvPagos.Columns["Observacion"].HeaderText = "Observación";
                dgvPagos.Columns["Observacion"].DisplayIndex = 4;
            }

            if (dgvPagos.Columns["Estado"] != null)
            {
                dgvPagos.Columns["Estado"].HeaderText = "Estado";
                dgvPagos.Columns["Estado"].DisplayIndex = 5;
            }
        }

        private async void btnAgregarPago_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtImporte.Text.Trim(), out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un importe válido mayor a $0.00.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                return;
            }

            string formaPago = cmbTipoPago.SelectedItem?.ToString() ?? "Efectivo";
            string? folio = string.IsNullOrWhiteSpace(txtFolio.Text) ? null : txtFolio.Text.Trim();
            string? observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim();

            try
            {
                await _controller.GuardarPagoAsync(
                    pagoId: null,
                    socioMembresiaId: _socioMembresia.SocioMembresiaID,
                    monto: monto,
                    folio: folio,
                    formaPago: formaPago,
                    observacion: observacion
                );

                MessageBox.Show("Pago registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos de captura
                txtFolio.Clear();
                txtObservacion.Clear();

                // Recargar el historial de abonos y saldos
                await CargarHistorialPagosAsync();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminarPago_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow?.DataBoundItem is not PagoSocioMembresiaViewModel pagoSeleccionado)
            {
                MessageBox.Show("Seleccione un pago del historial para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el pago de {pagoSeleccionado.MontoFormateado}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await _controller.EliminarFisicoAsync(pagoSeleccionado.PagoID);
                    MessageBox.Show("El pago ha sido eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarHistorialPagosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
