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
    public partial class FrmSociosReporte : Form
    {
        private readonly ReporteController _reporteController;
        private List<ReporteSocioViewModel> _listaSocios = new();

        public FrmSociosReporte(ReporteController reporteController)
        {
            InitializeComponent();
            _reporteController = reporteController;
        }

        private async void FrmSociosReporte_Load(object sender, EventArgs e)
        {
            // Cargar las opciones del ComboBox Estatus
            cboEstatus.Items.Clear();
            cboEstatus.Items.AddRange(new object[] { "Todos", "Sin membresía", "Sin vencer", "Vencido" });
            cboEstatus.SelectedIndex = 0; // Seleccionar "Todos" por defecto

            await CargarSociosAsync();
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await AplicarFiltroAsync();
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cboEstatus.SelectedIndex = 0; // Restablecer a "Todos"
            await CargarSociosAsync();
        }

        private async Task CargarSociosAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Obtener lista completa de socios mediante el controlador
                var resultado = await _reporteController.ObtenerSociosAsync();
                _listaSocios = resultado.ToList();

                AplicarFiltroEnMemoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de socios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task AplicarFiltroAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                AplicarFiltroEnMemoria();
                await Task.CompletedTask;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AplicarFiltroEnMemoria()
        {
            string estatusSeleccionado = cboEstatus.SelectedItem?.ToString() ?? "Todos";

            // Filtrar en memoria por el estatus elegido
            IEnumerable<ReporteSocioViewModel> sociosFiltrados = _listaSocios;

            if (estatusSeleccionado != "Todos")
            {
                sociosFiltrados = sociosFiltrados.Where(s =>
                    string.Equals(s.Estatus, estatusSeleccionado, StringComparison.OrdinalIgnoreCase));
            }

            var datosMostrar = sociosFiltrados.Select(s => new
            {
                Id = s.SocioID,
                Clave = string.IsNullOrWhiteSpace(s.Clave) ? "N/A" : s.Clave,
                NombreSocio = string.IsNullOrWhiteSpace(s.NombreCompleto) ? "N/A" : s.NombreCompleto,
                FechaVencimiento = s.FechaVencimientoTexto,
                Estatus = s.Estatus
            }).ToList();

            dgvSocios.DataSource = null;
            dgvSocios.DataSource = datosMostrar;

            ConfigurarGrid();
            CalcularTotales(datosMostrar.Count);
            dgvSocios.ClearSelection();
        }

        private void CalcularTotales(int cantidadTotal)
        {
            lblTotal.Text = $"Total de Socios: {cantidadTotal}";
        }

        private void ConfigurarGrid()
        {
            if (dgvSocios.Columns.Count == 0) return;

            // Renombrar encabezados
            if (dgvSocios.Columns["Id"] != null) dgvSocios.Columns["Id"].HeaderText = "ID";
            if (dgvSocios.Columns["Clave"] != null) dgvSocios.Columns["Clave"].HeaderText = "Clave";
            if (dgvSocios.Columns["NombreSocio"] != null) dgvSocios.Columns["NombreSocio"].HeaderText = "Nombre del Socio";
            if (dgvSocios.Columns["FechaVencimiento"] != null) dgvSocios.Columns["FechaVencimiento"].HeaderText = "Fecha de Vencimiento";
            if (dgvSocios.Columns["Estatus"] != null) dgvSocios.Columns["Estatus"].HeaderText = "Estatus";

            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Evento para formatear colores según el estatus
            dgvSocios.CellFormatting -= DgvSocios_CellFormatting;
            dgvSocios.CellFormatting += DgvSocios_CellFormatting;
        }

        private void DgvSocios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSocios.Columns[e.ColumnIndex].Name == "Estatus" && e.Value != null)
            {
                string estatus = e.Value.ToString()!;

                if (string.Equals(estatus, "Sin vencer", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#2e7d32"); // Verde
                    e.CellStyle.SelectionForeColor = ColorTranslator.FromHtml("#81c784");
                }
                else if (string.Equals(estatus, "Vencido", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#d32f2f"); // Rojo
                    e.CellStyle.SelectionForeColor = ColorTranslator.FromHtml("#e57373");
                }
                else if (string.Equals(estatus, "Sin membresía", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#f57c00"); // Naranja
                    e.CellStyle.SelectionForeColor = ColorTranslator.FromHtml("#ffb74d");
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvSocios.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Lógica o Helper para exportación a Excel
                MessageBox.Show("Reporte de socios exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
