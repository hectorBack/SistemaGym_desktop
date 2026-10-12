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
    public partial class FrmRegistrosReporte : Form
    {
        /// <summary>Una fila del reporte.</summary>
        private sealed record FilaRegistro(string NombreSocio, string FechaRegistro);

        private readonly ReporteController _reporteController;

        public FrmRegistrosReporte(ReporteController reporteController)
        {
            _reporteController = reporteController ?? throw new ArgumentNullException(nameof(reporteController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void FrmRegistrosReporte_Load(object? sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            await BuscarPorFechaAsync();
        }

        // Las columnas se definen una sola vez.
        private void ConfigurarColumnas()
        {
            dgvRegistros.AutoGenerateColumns = false;

            dgvRegistros.AgregarTexto(nameof(FilaRegistro.NombreSocio), "Nombre del socio", 200, 130);
            dgvRegistros.AgregarTexto(nameof(FilaRegistro.FechaRegistro), "Fecha de registro", 120, 120);
        }

        private async void btnFiltrar_Click(object? sender, EventArgs e) => await BuscarPorFechaAsync();

        // "Hoy": vuelve al día actual.
        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            await BuscarPorFechaAsync();
        }

        private async Task BuscarPorFechaAsync()
        {
            // El rango cubre todo el día seleccionado (00:00:00 a 23:59:59).
            DateTime inicio = dtpFecha.Value.Date;
            DateTime fin = dtpFecha.Value.Date.AddDays(1).AddTicks(-1);

            await FormHelper.EjecutarAsync(async () =>
            {
                var registros = await _reporteController.ObtenerRegistrosAsync(inicio, fin);
                if (IsDisposed) return; // el usuario cambió de pestaña o módulo mientras cargaba

                var filas = registros.Select(r => new FilaRegistro(
                    string.IsNullOrWhiteSpace(r.NombreCompleto) ? "N/A" : r.NombreCompleto,
                    r.FechaRegistroTexto)).ToList();

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvRegistros.SortedColumn;
                var sentidoOrden = dgvRegistros.SortOrder;

                dgvRegistros.DataSource = new ListaOrdenable<FilaRegistro>(filas);

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvRegistros.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? System.ComponentModel.ListSortDirection.Descending
                        : System.ComponentModel.ListSortDirection.Ascending);
                }

                dgvRegistros.ClearSelection();
                lblTotal.Text = $"Total Visitas: {filas.Count}";
                btnExportarExcel.Enabled = filas.Count > 0;
            },
            "No se pudo cargar el reporte de registro de visitas.",
            panelTop, panelFiltros);
        }

        // Antes este botón mostraba "exportado con éxito" sin exportar nada.
        // Ahora genera un .csv que Excel abre directamente.
        private void btnExportarExcel_Click(object? sender, EventArgs e)
        {
            if (dgvRegistros.Rows.Count == 0)
            {
                FormHelper.MostrarAviso("No hay datos en la tabla para exportar.");
                return;
            }

            try
            {
                string? ruta = ExportadorCsv.Exportar(dgvRegistros, "Registro_de_visitas");
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
