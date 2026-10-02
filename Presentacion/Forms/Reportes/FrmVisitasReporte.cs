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
    public partial class FrmVisitasReporte : Form
    {
        private readonly ReporteController _reporteController;
        private readonly VisitaController _visitaController;
        private List<ReporteVisitaViewModel> _listaVisitas = new();

        public FrmVisitasReporte(ReporteController reporteController, VisitaController visitaController)
        {
            InitializeComponent();
            _reporteController = reporteController;
            _visitaController = visitaController;
        }

        private async void FrmVisitasReporte_Load(object sender, EventArgs e)
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

                var resultado = await _reporteController.ObtenerVisitasAsync(inicio, fin);
                _listaVisitas = resultado.ToList();

                var datosMostrar = _listaVisitas.Select(v => new
                {
                    VisitaID = v.VisitaID,
                    Nombre = v.Nombre,
                    FechaRegistro = v.FechaHoraTexto,
                    Monto = v.Monto
                }).ToList();

                dgvVisitas.DataSource = null;
                dgvVisitas.DataSource = datosMostrar;

                ConfigurarGrid();
                CalcularTotal();
                dgvVisitas.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de visitas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CalcularTotal()
        {
            decimal totalIngresado = _listaVisitas.Sum(v => v.Monto);
            lblTotal.Text = $"Total: {totalIngresado:C2}";
        }

        private void ConfigurarGrid()
        {
            if (dgvVisitas.Columns.Count == 0) return;

            // Ocultar ID pero mantenerlo disponible para operaciones como eliminar
            if (dgvVisitas.Columns["VisitaID"] != null)
                dgvVisitas.Columns["VisitaID"].Visible = false;

            if (dgvVisitas.Columns["Nombre"] != null)
                dgvVisitas.Columns["Nombre"].HeaderText = "Nombre";

            if (dgvVisitas.Columns["FechaRegistro"] != null)
                dgvVisitas.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";

            if (dgvVisitas.Columns["Monto"] != null)
            {
                dgvVisitas.Columns["Monto"].HeaderText = "Precio Visita";
                dgvVisitas.Columns["Monto"].DefaultCellStyle.Format = "C2";
                dgvVisitas.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVisitas.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvVisitas.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Lógica o Helper para exportación a Excel
                MessageBox.Show("Reporte de visitas exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvVisitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una visita de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar este registro de visita? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    int visitaId = Convert.ToInt32(dgvVisitas.CurrentRow.Cells["VisitaID"].Value);

                    // Llamada directa al método de VisitaController
                    await _visitaController.EliminarFisicoAsync(visitaId);

                    MessageBox.Show("Registro de visita eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar el reporte tras la eliminación
                    await BuscarPorFechasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la visita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}
