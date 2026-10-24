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
    public partial class FrmMembresiasReporte : Form
    {
        /// <summary>Una fila del reporte. Fechas e importe se conservan como DateTime/decimal (no como texto) para que ordenen bien.</summary>
        private sealed record FilaMembresia(
            string Membresia,
            string Socio,
            DateTime FechaRegistro,
            DateTime FechaInicio,
            DateTime Vencimiento,
            string EstadoMembresia,
            decimal Precio);

        private readonly ReporteController _reporteController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<FilaMembresia> _vista = new();

        public FrmMembresiasReporte(ReporteController reporteController)
        {
            _reporteController = reporteController ?? throw new ArgumentNullException(nameof(reporteController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void FrmMembresiasReporte_Load(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        // Las columnas se definen una sola vez, con su formato real.
        private void ConfigurarColumnas()
        {
            dgvMembresias.AutoGenerateColumns = false;

            dgvMembresias.AgregarTexto(nameof(FilaMembresia.Membresia), "Membresía", 120, 100);
            dgvMembresias.AgregarTexto(nameof(FilaMembresia.Socio), "Nombre del Socio", 160, 120);
            dgvMembresias.AgregarTexto(nameof(FilaMembresia.FechaRegistro), "Fecha de Registro", 120, 120, "dd/MM/yyyy hh:mm tt");
            dgvMembresias.AgregarTexto(nameof(FilaMembresia.FechaInicio), "Fecha de Inicio", 100, 100, "dd/MM/yyyy");
            dgvMembresias.AgregarTexto(nameof(FilaMembresia.Vencimiento), "Vencimiento", 100, 100, "dd/MM/yyyy");
            dgvMembresias.AgregarTexto(nameof(FilaMembresia.EstadoMembresia), "Estado Membresía", 100, 100);
            dgvMembresias.AgregarTexto(nameof(FilaMembresia.Precio), "Precio", 90, 85, "C2", alinearDerecha: true);
        }

        private async void btnFiltrar_Click(object? sender, EventArgs e) => await BuscarPorFechasAsync();

        // "Hoy": vuelve al día actual.
        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        private async Task BuscarPorFechasAsync()
        {
            // El rango cubre todo el día "Hasta".
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

            if (inicio > fin)
            {
                FormHelper.MostrarAdvertencia("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango de fechas");
                return;
            }

            await FormHelper.EjecutarAsync(async () =>
            {
                var membresias = await _reporteController.ObtenerMembresiasAsync(inicio, fin);
                if (IsDisposed) return; // el usuario cambió de pestaña o módulo mientras cargaba

                var filas = membresias.Select(m => new FilaMembresia(
                    string.IsNullOrWhiteSpace(m.Membresia) ? "N/A" : m.Membresia,
                    string.IsNullOrWhiteSpace(m.Socio) ? "N/A" : m.Socio,
                    m.FechaRegistro,
                    m.FechaInicio,
                    m.Vencimiento,
                    m.EstadoMembresia, // "Pagada", "Parcial" o "Sin Pagar"
                    m.Precio));        // valor total contratado

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvMembresias.SortedColumn;
                var sentidoOrden = dgvMembresias.SortOrder;

                _vista = new ListaOrdenable<FilaMembresia>(filas);
                dgvMembresias.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvMembresias.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? System.ComponentModel.ListSortDirection.Descending
                        : System.ComponentModel.ListSortDirection.Ascending);
                }

                dgvMembresias.ClearSelection();
                ActualizarResumen();
            },
            "No se pudo cargar el reporte de membresías.",
            panelTop, panelFiltros);
        }

        // Suma el valor total contratado de las membresías vendidas en el periodo.
        private void ActualizarResumen()
        {
            lblTotal.Text = $"{_vista.Count} membresía(s)  ·  Total {_vista.Sum(f => f.Precio):C2}";
            btnExportarExcel.Enabled = _vista.Count > 0;
        }

        // Estado de pago con color: pagada en verde, parcial en ámbar, sin pagar en rojo.
        private void dgvMembresias_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle is null) return;
            if (dgvMembresias.Columns[e.ColumnIndex].DataPropertyName != nameof(FilaMembresia.EstadoMembresia)) return;

            e.CellStyle.ForeColor = (e.Value as string)?.Trim().ToLowerInvariant() switch
            {
                "pagada" => Tema.Exito,
                "parcial" => Tema.Advertencia,
                "sin pagar" => Tema.Peligro,
                _ => e.CellStyle.ForeColor
            };
        }

        // Antes este botón mostraba "exportado con éxito" sin exportar nada.
        // Ahora genera un .csv que Excel abre directamente.
        private void btnExportarExcel_Click(object? sender, EventArgs e)
        {
            if (dgvMembresias.Rows.Count == 0)
            {
                FormHelper.MostrarAviso("No hay datos en la tabla para exportar.");
                return;
            }

            try
            {
                string? ruta = ExportadorCsv.Exportar(dgvMembresias, "Membresias_vendidas");
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
