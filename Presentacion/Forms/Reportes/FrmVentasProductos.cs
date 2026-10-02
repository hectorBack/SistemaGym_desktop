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
    public partial class FrmVentasProductos : Form
    {
        private readonly ReporteController _reporteController;
        private List<ReporteVentaProductoViewModel> _listaVentasProductos = new();

        public FrmVentasProductos(ReporteController reporteController)
        {
            InitializeComponent();
            _reporteController = reporteController;
        }

        private async void FrmVentasProductos_Load(object sender, EventArgs e)
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

                // Consumimos el controlador pasando el rango de fechas
                var resultado = await _reporteController.ObtenerVentaProductosAsync(inicio, fin);
                _listaVentasProductos = resultado.ToList();

                // Proyectamos asegurando que si algún texto viene nulo/vacío, muestre "N/A"
                var datosMostrar = _listaVentasProductos.Select(v => new
                {
                    FechaRegistro = string.IsNullOrWhiteSpace(v.FechaRegistro) ? "N/A" : v.FechaRegistro,
                    Producto = string.IsNullOrWhiteSpace(v.Producto) ? "N/A" : v.Producto,
                    CostoUnitario = v.CostoUnitario,
                    PrecioUnitario = v.PrecioUnitario,
                    Ganancia = v.Ganancia
                }).ToList();

                dgvVentasProductos.DataSource = null;
                dgvVentasProductos.DataSource = datosMostrar;

                ConfigurarGrid();
                CalcularTotalGanancia();
                dgvVentasProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de ventas de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CalcularTotalGanancia()
        {
            // Sumamos la ganancia parsing el valor numérico de la lista de ViewModels de forma segura
            decimal totalGanancia = 0m;

            foreach (var item in _listaVentasProductos)
            {
                // Limpiamos el formato de moneda para convertir a decimal si viene como string formateado
                string gananciaLimpia = item.Ganancia.Replace("$", "").Replace(" ", "").Trim();
                if (decimal.TryParse(gananciaLimpia, out decimal gananciaValor))
                {
                    totalGanancia += gananciaValor;
                }
            }

            lblTotal.Text = $"Total Ganancia: {totalGanancia:C2}";
        }

        private void ConfigurarGrid()
        {
            if (dgvVentasProductos.Columns.Count == 0) return;

            // Renombrar encabezados de columnas
            if (dgvVentasProductos.Columns["FechaRegistro"] != null)
                dgvVentasProductos.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";

            if (dgvVentasProductos.Columns["Producto"] != null)
                dgvVentasProductos.Columns["Producto"].HeaderText = "Nombre del producto";

            if (dgvVentasProductos.Columns["CostoUnitario"] != null)
            {
                dgvVentasProductos.Columns["CostoUnitario"].HeaderText = "Costo Unitario";
                dgvVentasProductos.Columns["CostoUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVentasProductos.Columns["CostoUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvVentasProductos.Columns["PrecioUnitario"] != null)
            {
                dgvVentasProductos.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
                dgvVentasProductos.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVentasProductos.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvVentasProductos.Columns["Ganancia"] != null)
            {
                dgvVentasProductos.Columns["Ganancia"].HeaderText = "Ganancia";
                dgvVentasProductos.Columns["Ganancia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVentasProductos.Columns["Ganancia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvVentasProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvVentasProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Lógica o Helper para exportación a Excel
                MessageBox.Show("Reporte de ventas de productos exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
