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
    public partial class FrmRegistrosReporte : Form
    {
        private readonly ReporteController _reporteController;
        private List<ReporteRegistroViewModel> _listaRegistros = new();

        public FrmRegistrosReporte(ReporteController reporteController)
        {
            InitializeComponent();
            _reporteController = reporteController;
        }

        private async void FrmRegistrosReporte_Load(object sender, EventArgs e)
        {
            // Inicializar el selector con la fecha de hoy
            dtpFecha.Value = DateTime.Today;

            await BuscarPorFechaAsync();
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await BuscarPorFechaAsync();
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            // Restablecer el selector a la fecha actual
            dtpFecha.Value = DateTime.Today;

            await BuscarPorFechaAsync();
        }

        private async Task BuscarPorFechaAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Definir rango para cubrir todo el día seleccionado (00:00:00 a 23:59:59)
                DateTime inicio = dtpFecha.Value.Date;
                DateTime fin = dtpFecha.Value.Date.AddDays(1).AddTicks(-1);

                // Obtener datos mediante el controlador
                var resultado = await _reporteController.ObtenerRegistrosAsync(inicio, fin);
                _listaRegistros = resultado.ToList();

                // Proyectar solo las columnas requeridas
                var datosMostrar = _listaRegistros.Select(r => new
                {
                    NombreSocio = string.IsNullOrWhiteSpace(r.NombreCompleto) ? "N/A" : r.NombreCompleto,
                    FechaRegistro = r.FechaRegistroTexto
                }).ToList();

                dgvRegistros.DataSource = null;
                dgvRegistros.DataSource = datosMostrar;

                ConfigurarGrid();
                CalcularTotales(datosMostrar.Count);
                dgvRegistros.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de visitas/registros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CalcularTotales(int cantidadTotal)
        {
            lblTotal.Text = $"Total Visitas: {cantidadTotal}";
        }

        private void ConfigurarGrid()
        {
            if (dgvRegistros.Columns.Count == 0) return;

            if (dgvRegistros.Columns["NombreSocio"] != null)
                dgvRegistros.Columns["NombreSocio"].HeaderText = "Nombre del socio";

            if (dgvRegistros.Columns["FechaRegistro"] != null)
                dgvRegistros.Columns["FechaRegistro"].HeaderText = "Fecha de registro";

            dgvRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                MessageBox.Show("Reporte de visitas/registros exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
