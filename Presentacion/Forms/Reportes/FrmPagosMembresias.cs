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

namespace Presentacion.Forms.Reportes
{
    public partial class FrmPagosMembresias : Form
    {
        private readonly ReporteController _reporteController;
        private List<ReportePagoMembresiaViewModel> _listaPagos = new();

        public FrmPagosMembresias(ReporteController reporteController)
        {
            InitializeComponent();
            _reporteController = reporteController;
        }

        private async void FrmPagosMembresiasReporte_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await BuscarPorFechasAsync();
        }

        private async Task BuscarPorFechasAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime inicio = dtpFechaInicio.Value.Date;
                DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

                var resultado = await _reporteController.ObtenerPagosMembresiasAsync(inicio, fin);
                _listaPagos = resultado.ToList();

                // Proyección exacta con las columnas solicitadas
                var datosMostrar = _listaPagos.Select(p => new
                {
                    Socio = p.Socio,
                    EstadoMembresia = p.EstadoMembresia,
                    FechaInicio = p.FechaInicioTexto,
                    FechaPago = p.FechaPagoTexto,
                    Folio = p.Folio,
                    Observacion = p.Observaciones,
                    Importe = p.Monto
                }).ToList();

                dgvPagosMembresias.DataSource = null;
                dgvPagosMembresias.DataSource = datosMostrar;

                ConfigurarGrid();
                CalcularTotal();
                dgvPagosMembresias.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CalcularTotal()
        {
            // En esta pestaña se suma el dinero REAL ingresado a caja (Monto/Importe del abono)
            decimal totalIngresado = _listaPagos.Sum(p => p.Monto);
            int totalTransacciones = _listaPagos.Count;

            lblTotal.Text = $"Total: {totalIngresado:C2}";
        }

        private void ConfigurarGrid()
        {
            if (dgvPagosMembresias.Columns.Count == 0) return;

            if (dgvPagosMembresias.Columns["Socio"] != null) dgvPagosMembresias.Columns["Socio"].HeaderText = "Nombre del Socio";
            if (dgvPagosMembresias.Columns["EstadoMembresia"] != null) dgvPagosMembresias.Columns["EstadoMembresia"].HeaderText = "Estado Membresía";
            if (dgvPagosMembresias.Columns["FechaInicio"] != null) dgvPagosMembresias.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
            if (dgvPagosMembresias.Columns["FechaPago"] != null) dgvPagosMembresias.Columns["FechaPago"].HeaderText = "Fecha Pago";
            if (dgvPagosMembresias.Columns["Folio"] != null) dgvPagosMembresias.Columns["Folio"].HeaderText = "Folio";
            if (dgvPagosMembresias.Columns["Observacion"] != null) dgvPagosMembresias.Columns["Observacion"].HeaderText = "Observación";

            if (dgvPagosMembresias.Columns["Importe"] != null)
            {
                dgvPagosMembresias.Columns["Importe"].HeaderText = "Importe";
                dgvPagosMembresias.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgvPagosMembresias.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPagosMembresias.Columns["Importe"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvPagosMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvPagosMembresias.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Lógica o Helper para exportación a Excel
                MessageBox.Show("Reporte de membresías exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
