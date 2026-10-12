using Presentacion.Controller;
using Presentacion.Forms.Corte;
using Presentacion.Helpers;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Reportes
{
    public partial class FrmPagosMembresias : Form
    {
        /// <summary>Una fila del reporte. El importe se conserva como decimal (no como texto) para que ordene y sume bien.</summary>
        private sealed record FilaPago(
            string Socio,
            string EstadoMembresia,
            string FechaInicio,
            string FechaPago,
            string Folio,
            string Observacion,
            decimal Importe);

        private readonly ReporteController _reporteController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<FilaPago> _vista = new();

        public FrmPagosMembresias(ReporteController reporteController)
        {
            _reporteController = reporteController ?? throw new ArgumentNullException(nameof(reporteController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        // OJO: el Designer original no conectaba ningún evento Load, y el método se llamaba
        // FrmPagosMembresiasReporte_Load. Ahora ambos coinciden y el Designer lo suscribe.
        private async void FrmPagosMembresias_Load(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        // Las columnas se definen una sola vez, con su formato real.
        private void ConfigurarColumnas()
        {
            dgvPagosMembresias.AutoGenerateColumns = false;

            dgvPagosMembresias.AgregarTexto(nameof(FilaPago.Socio), "Nombre del Socio", 170, 120);
            dgvPagosMembresias.AgregarTexto(nameof(FilaPago.EstadoMembresia), "Estado Membresía", 100, 100);
            dgvPagosMembresias.AgregarTexto(nameof(FilaPago.FechaInicio), "Fecha Inicio", 100, 100);
            dgvPagosMembresias.AgregarTexto(nameof(FilaPago.FechaPago), "Fecha Pago", 120, 110);
            dgvPagosMembresias.AgregarTexto(nameof(FilaPago.Folio), "Folio", 80, 70);
            dgvPagosMembresias.AgregarTexto(nameof(FilaPago.Observacion), "Observación", 160, 120);
            dgvPagosMembresias.AgregarTexto(nameof(FilaPago.Importe), "Importe", 90, 85, "C2", alinearDerecha: true);

            // Las fechas llegan como texto del reporte: ordenarlas alfabéticamente daría un orden engañoso.
            foreach (DataGridViewColumn c in dgvPagosMembresias.Columns)
                if (c.DataPropertyName is nameof(FilaPago.FechaInicio) or nameof(FilaPago.FechaPago))
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
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
                var pagos = await _reporteController.ObtenerPagosMembresiasAsync(inicio, fin);
                if (IsDisposed) return; // el usuario cambió de pestaña o módulo mientras cargaba

                var filas = pagos.Select(p => new FilaPago(
                    string.IsNullOrWhiteSpace(p.Socio) ? "N/A" : p.Socio,
                    p.EstadoMembresia,
                    p.FechaInicioTexto,
                    p.FechaPagoTexto,
                    Convert.ToString(p.Folio, CultureInfo.CurrentCulture) ?? string.Empty,
                    p.Observaciones ?? string.Empty,
                    p.Monto)); // dinero real ingresado a caja (abono)

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvPagosMembresias.SortedColumn;
                var sentidoOrden = dgvPagosMembresias.SortOrder;

                _vista = new ListaOrdenable<FilaPago>(filas);
                dgvPagosMembresias.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvPagosMembresias.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                dgvPagosMembresias.ClearSelection();
                ActualizarResumen();
            },
            "No se pudo cargar el reporte de pagos de membresías.",
            panelTop, panelFiltros);
        }

        // En esta pestaña se suma el dinero REAL ingresado a caja (importe de cada abono).
        private void ActualizarResumen()
        {
            lblTotal.Text = $"{_vista.Count} pago(s)  ·  Total {_vista.Sum(f => f.Importe):C2}";
            btnExportarExcel.Enabled = _vista.Count > 0;
        }

        // Estado de pago con color: pagada en verde, parcial en ámbar, sin pagar en rojo.
        private void dgvPagosMembresias_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle is null) return;
            if (dgvPagosMembresias.Columns[e.ColumnIndex].DataPropertyName != nameof(FilaPago.EstadoMembresia)) return;

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
            if (_vista.Count == 0)
            {
                FormHelper.MostrarAviso("No hay datos en la tabla para exportar.");
                return;
            }

            try
            {
                string? ruta = ExportadorCsv.Exportar(dgvPagosMembresias, "Pagos_de_membresias");
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
