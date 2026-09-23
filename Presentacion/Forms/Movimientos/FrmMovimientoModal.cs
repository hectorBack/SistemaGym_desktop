using Negocio.Exceptions;
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

namespace Presentacion.Forms.Movimientos
{
    public partial class FrmMovimientoModal : Form
    {
        private readonly MovimientoController _controller;
        private readonly ConceptoController? _conceptoController;
        private readonly int? _movimientoId;
        private List<ConceptoViewModel> _listaConceptos = new();

        public FrmMovimientoModal(
            MovimientoController controller,
            int? movimientoId = null,
            ConceptoController? conceptoController = null)
        {
            InitializeComponent();
            _controller = controller;
            _conceptoController = conceptoController;
            _movimientoId = movimientoId;
        }

        private async void FrmMovimientoModal_Load(object sender, EventArgs e)
        {
            CargarTipos();
            CargarFormasPago();
            await CargarConceptosAsync();

            if (_movimientoId.HasValue)
            {
                lblTitulo.Text = "Editar Movimiento";
                await CargarDatosMovimientoAsync(_movimientoId.Value);
            }
            else
            {
                lblTitulo.Text = "Nuevo Movimiento";
                FiltrarConceptosPorTipo();
            }
        }

        private async Task CargarConceptosAsync()
        {
            if (_conceptoController == null)
            {
                MessageBox.Show("El controlador de conceptos no fue inyectado correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var conceptos = await _conceptoController.ObtenerConceptosAsync(incluirInactivos: false);
                _listaConceptos = conceptos
                    .Where(c => !EsConceptoDelSistema(c))
                    .ToList();

                FiltrarConceptosPorTipo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar conceptos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool EsConceptoDelSistema(ConceptoViewModel concepto)
        {
            return concepto.EsSistema ||
                (!string.IsNullOrWhiteSpace(concepto.Observacion) &&
                 concepto.Observacion.Contains("No se puede modificar", StringComparison.OrdinalIgnoreCase));
        }

        private void FiltrarConceptosPorTipo()
        {
            string tipoSeleccionado = cmbTipo.SelectedItem?.ToString()?.Trim() ?? "Ingreso";

            // Filtramos la lista de conceptos según el tipo seleccionado en el combo
            var conceptosFiltrados = _listaConceptos
                .Where(c => !EsConceptoDelSistema(c) &&
                            string.Equals(c.Tipo?.Trim(), tipoSeleccionado, StringComparison.OrdinalIgnoreCase))
                .ToList();

            cmbConcepto.DataSource = null;
            cmbConcepto.Items.Clear();
            if (conceptosFiltrados.Any())
            {
                cmbConcepto.DataSource = conceptosFiltrados;
                cmbConcepto.DisplayMember = "Nombre";
                cmbConcepto.ValueMember = "ConceptoID";
                cmbConcepto.SelectedIndex = 0; // O -1 si prefieres que no haya nada seleccionado
            }
        }

        private void CargarFormasPago()
        {
            cmbFormaPago.Items.Clear();
            cmbFormaPago.Items.Add("Efectivo");
            cmbFormaPago.Items.Add("Tarjeta");
            cmbFormaPago.Items.Add("Transferencia");
            cmbFormaPago.SelectedIndex = 0;
        }

        private void CargarTipos()
        {
            // Desvincular temporalmente para evitar ejecuciones indeseadas durante la carga
            cmbTipo.SelectedIndexChanged -= cmbTipo_SelectedIndexChanged;

            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Ingreso");
            cmbTipo.Items.Add("Egreso");
            cmbTipo.SelectedIndex = 0; // Selecciona "Ingreso" por defecto

            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
        }

        private async Task CargarDatosMovimientoAsync(int id)
        {
            try
            {
                var movimiento = await _controller.ObtenerPorIdAsync(id);
                if (movimiento != null)
                {
                    cmbTipo.SelectedItem = movimiento.Tipo;
                    FiltrarConceptosPorTipo();

                    cmbConcepto.SelectedValue = movimiento.ConceptoID;
                    cmbFormaPago.SelectedItem = movimiento.FormaPago;
                    numTotal.Value = movimiento.Total;
                    txtObservacion.Text = movimiento.Observacion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbConcepto.SelectedValue == null || (int)cmbConcepto.SelectedValue <= 0)
            {
                MessageBox.Show("Debe seleccionar un concepto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numTotal.Value <= 0)
            {
                MessageBox.Show("El monto total debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tipo = cmbTipo.SelectedItem?.ToString() ?? "Ingreso";
                int conceptoId = (int)cmbConcepto.SelectedValue;
                string formaPago = cmbFormaPago.SelectedItem?.ToString() ?? "Efectivo";
                decimal total = numTotal.Value;
                string? observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim();

                await _controller.GuardarMovimientoAsync(
                    _movimientoId,
                    tipo,
                    conceptoId,
                    formaPago,
                    total,
                    observacion);

                MessageBox.Show("Movimiento guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbTipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FiltrarConceptosPorTipo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
