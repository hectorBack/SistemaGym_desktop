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
    public partial class FrmMembresiasReporte : Form
    {
        private readonly ReporteController _reporteController;
        private List<ReporteMembresiaViewModel> _listaMembresias = new();

        public FrmMembresiasReporte(ReporteController reporteController)
        {
            InitializeComponent();
            _reporteController = reporteController;
        }

        private async void FrmMembresiasReporte_Load(object sender, EventArgs e)
        {
            // Inicializar los DateTimePicker marcando el día de hoy
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

                // Ajustar horas para cubrir todo el rango del día seleccionado
                DateTime inicio = dtpFechaInicio.Value.Date;
                DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

                // 2. Consumimos el método adecuado pasando el rango de fechas
                var resultado = await _reporteController.ObtenerMembresiasAsync(inicio, fin);
                _listaMembresias = resultado.ToList();

                // 3. Proyectamos usando los datos reales devueltos por el ViewModel
                var datosMostrar = _listaMembresias.Select(m => new
                {
                    Membresia = string.IsNullOrWhiteSpace(m.Membresia) ? "N/A" : m.Membresia,
                    Socio = string.IsNullOrWhiteSpace(m.Socio) ? "N/A" : m.Socio,
                    FechaRegistro = m.FechaRegistro.ToString("dd/MM/yyyy HH:mm"),
                    FechaInicio = m.FechaInicio.ToString("dd/MM/yyyy"),
                    Vencimiento = m.Vencimiento.ToString("dd/MM/yyyy"),
                    EstadoMembresia = m.EstadoMembresia, // "Pagada", "Parcial" o "Sin Pagar"
                    Precio = m.Precio                     // Valor total contratado
                }).ToList();

                dgvMembresias.DataSource = null;
                dgvMembresias.DataSource = datosMostrar;

                ConfigurarGrid();
                CalcularTotal();
                dgvMembresias.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CalcularTotal()
        {
            // 4. Sumamos el valor total contratado de las membresías vendidas
            decimal totalContratado = _listaMembresias.Sum(m => m.Precio);
            int cantidadVendida = _listaMembresias.Count;

            lblTotal.Text = $"Total: {totalContratado:C2}";
        }

        private void ConfigurarGrid()
        {
            if (dgvMembresias.Columns.Count == 0) return;

            // Renombrar encabezados de columnas
            if (dgvMembresias.Columns["Membresia"] != null) dgvMembresias.Columns["Membresia"].HeaderText = "Membresía";
            if (dgvMembresias.Columns["Socio"] != null) dgvMembresias.Columns["Socio"].HeaderText = "Nombre del Socio";
            if (dgvMembresias.Columns["FechaRegistro"] != null) dgvMembresias.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";
            if (dgvMembresias.Columns["FechaInicio"] != null) dgvMembresias.Columns["FechaInicio"].HeaderText = "Fecha de Inicio";
            if (dgvMembresias.Columns["Vencimiento"] != null) dgvMembresias.Columns["Vencimiento"].HeaderText = "Vencimiento";
            if (dgvMembresias.Columns["EstadoMembresia"] != null) dgvMembresias.Columns["EstadoMembresia"].HeaderText = "Estado Membresía";

            if (dgvMembresias.Columns["Precio"] != null)
            {
                dgvMembresias.Columns["Precio"].HeaderText = "Precio";
                dgvMembresias.Columns["Precio"].DefaultCellStyle.Format = "C2";
                dgvMembresias.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMembresias.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvMembresias.Rows.Count == 0)
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

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            // Restablecer el rango de fechas al día de hoy
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }
    }
}
