using Presentacion.Controller;
using Presentacion.Forms.Corte;
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

namespace Presentacion.Forms.Reportes
{
    public partial class FrmSociosReporte : Form
    {
        private const string Todos = "Todos";

        /// <summary>Una fila del reporte.</summary>
        private sealed record FilaSocio(
            int Id,
            string Clave,
            string NombreSocio,
            string FechaVencimiento,
            string Estatus);

        private readonly ReporteController _reporteController;

        // Lista completa traída del servidor; el filtro por estatus se hace en memoria sobre ella.
        private List<ReporteSocioViewModel> _listaSocios = new();

        public FrmSociosReporte(ReporteController reporteController)
        {
            _reporteController = reporteController ?? throw new ArgumentNullException(nameof(reporteController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void FrmSociosReporte_Load(object? sender, EventArgs e)
        {
            cboEstatus.Items.Clear();
            cboEstatus.Items.AddRange(new object[] { Todos, "Sin membresía", "Sin vencer", "Vencido" });
            cboEstatus.SelectedIndex = 0;

            await CargarSociosAsync();
        }

        // Las columnas se definen una sola vez.
        private void ConfigurarColumnas()
        {
            dgvSocios.AutoGenerateColumns = false;

            dgvSocios.AgregarTexto(nameof(FilaSocio.Id), "ID", 50, 55, alinearDerecha: true);
            dgvSocios.AgregarTexto(nameof(FilaSocio.Clave), "Clave", 80, 70);
            dgvSocios.AgregarTexto(nameof(FilaSocio.NombreSocio), "Nombre del Socio", 200, 130);
            dgvSocios.AgregarTexto(nameof(FilaSocio.FechaVencimiento), "Fecha de Vencimiento", 110, 110);
            dgvSocios.AgregarTexto(nameof(FilaSocio.Estatus), "Estatus", 100, 100);
        }

        // Filtrar solo vuelve a filtrar lo que ya está en memoria (no consulta al servidor).
        private void btnFiltrar_Click(object? sender, EventArgs e) => AplicarFiltro();

        // Limpiar vuelve a "Todos" y recarga desde el servidor.
        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            cboEstatus.SelectedIndex = 0;
            await CargarSociosAsync();
        }

        private async Task CargarSociosAsync()
        {
            await FormHelper.EjecutarAsync(async () =>
            {
                var socios = await _reporteController.ObtenerSociosAsync();
                if (IsDisposed) return; // el usuario cambió de pestaña o módulo mientras cargaba

                _listaSocios = socios.ToList();
                AplicarFiltro();
            },
            "No se pudo cargar el reporte de socios.",
            panelTop, panelFiltros);
        }

        private void AplicarFiltro()
        {
            string estatus = cboEstatus.SelectedItem?.ToString() ?? Todos;

            IEnumerable<ReporteSocioViewModel> filtrados = _listaSocios;
            if (estatus != Todos)
            {
                filtrados = filtrados.Where(s =>
                    string.Equals(s.Estatus, estatus, StringComparison.OrdinalIgnoreCase));
            }

            var filas = filtrados.Select(s => new FilaSocio(
                s.SocioID,
                string.IsNullOrWhiteSpace(s.Clave) ? "N/A" : s.Clave,
                string.IsNullOrWhiteSpace(s.NombreCompleto) ? "N/A" : s.NombreCompleto,
                s.FechaVencimientoTexto,
                s.Estatus)).ToList();

            // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
            var columnaOrden = dgvSocios.SortedColumn;
            var sentidoOrden = dgvSocios.SortOrder;

            dgvSocios.DataSource = new ListaOrdenable<FilaSocio>(filas);

            if (columnaOrden != null && sentidoOrden != SortOrder.None)
            {
                dgvSocios.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                    ? System.ComponentModel.ListSortDirection.Descending
                    : System.ComponentModel.ListSortDirection.Ascending);
            }

            dgvSocios.ClearSelection();
            lblTotal.Text = $"Total de Socios: {filas.Count}";
            btnExportarExcel.Enabled = filas.Count > 0;
        }

        // Estatus con color del tema: sin vencer en verde, vencido en rojo, sin membresía en ámbar.
        private void dgvSocios_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle is null) return;
            if (dgvSocios.Columns[e.ColumnIndex].DataPropertyName != nameof(FilaSocio.Estatus)) return;

            string estatus = (e.Value as string ?? string.Empty).Trim();

            if (string.Equals(estatus, "Sin vencer", StringComparison.OrdinalIgnoreCase))
                e.CellStyle.ForeColor = Tema.Exito;
            else if (string.Equals(estatus, "Vencido", StringComparison.OrdinalIgnoreCase))
                e.CellStyle.ForeColor = Tema.Peligro;
            else if (string.Equals(estatus, "Sin membresía", StringComparison.OrdinalIgnoreCase))
                e.CellStyle.ForeColor = Tema.Advertencia;
        }

        // Antes este botón mostraba "exportado con éxito" sin exportar nada.
        // Ahora genera un .csv que Excel abre directamente (con el filtro que esté aplicado).
        private void btnExportarExcel_Click(object? sender, EventArgs e)
        {
            if (dgvSocios.Rows.Count == 0)
            {
                FormHelper.MostrarAviso("No hay datos en la tabla para exportar.");
                return;
            }

            try
            {
                string? ruta = ExportadorCsv.Exportar(dgvSocios, "Socios");
                if (ruta != null)
                    FormHelper.MostrarAviso($"Archivo guardado en:\n{ruta}", "Exportación completada");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                FormHelper.MostrarError("No se pudo guardar el archivo. Verifique que no esté abierto en Excel y que la carpeta permita escribir.");
            }
        }
    }
}
