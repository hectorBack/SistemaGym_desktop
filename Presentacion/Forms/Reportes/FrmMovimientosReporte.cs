using Presentacion.Controller;
using Presentacion.Forms.Corte;
using Presentacion.Helpers;
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
    public partial class FrmMovimientosReporte : Form
    {
        /// <summary>Una fila del reporte de movimientos. El total se conserva como decimal para ordenar y sumar correctamente.</summary>
        private sealed record FilaMovimiento(
            string Fecha,
            string Concepto,
            string Tipo,
            decimal Total,
            string FormaPago,
            string Corte,
            string Usuario,
            string Observacion);

        private readonly ReporteController _reporteController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<FilaMovimiento> _vista = new();

        public FrmMovimientosReporte(ReporteController reporteController)
        {
            _reporteController = reporteController ?? throw new ArgumentNullException(nameof(reporteController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void FrmMovimientosReporte_Load(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            // Configurar ComboBox de Tipo de Movimiento (Todos, Ingreso, Egreso)
            if (cmbTipo != null && cmbTipo.Items.Count == 0)
            {
                cmbTipo.Items.AddRange(new object[] { "Todos", "Ingreso", "Egreso" });
                cmbTipo.SelectedIndex = 0; // "Todos" por defecto
            }

            await BuscarPorFechasAsync();
        }

        // Las columnas se definen una sola vez con su formato real.
        private void ConfigurarColumnas()
        {
            dgvMovimientos.AutoGenerateColumns = false;

            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Fecha), "Fecha", 150, 120);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Concepto), "Concepto", 220, 150); 
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Tipo), "Tipo", 80, 70);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Total), "Total", 85, 80, "C2", alinearDerecha: true);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.FormaPago), "Tipo de Pago", 100, 90);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Corte), "Corte", 260, 200);      
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Usuario), "Usuario", 90, 80);  
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Observacion), "Observación", 150, 100);

            // La fecha llega como texto: evitar ordenamiento alfabético impreciso.
            foreach (DataGridViewColumn c in dgvMovimientos.Columns)
            {
                if (c.DataPropertyName == nameof(FilaMovimiento.Fecha))
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private async void btnFiltrar_Click(object? sender, EventArgs e) => await BuscarPorFechasAsync();

        // "Hoy": restablece los filtros al día actual y "Todos" en el tipo.
        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            if (cmbTipo != null)
                cmbTipo.SelectedIndex = 0;

            await BuscarPorFechasAsync();
        }

        private async Task BuscarPorFechasAsync()
        {
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

            if (inicio > fin)
            {
                FormHelper.MostrarAdvertencia("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango de fechas");
                return;
            }

            await FormHelper.EjecutarAsync(async () =>
            {
                var movimientos = await _reporteController.ObtenerMovimientosAsync(inicio, fin);
                if (IsDisposed) return;

                string tipoSeleccionado = cmbTipo?.SelectedItem?.ToString() ?? "Todos";

                // Filtrar en memoria por tipo si se seleccionó Ingreso o Egreso
                var filtrados = movimientos.Where(m =>
                    tipoSeleccionado == "Todos" || string.Equals(m.Tipo, tipoSeleccionado, StringComparison.OrdinalIgnoreCase));

                var filas = filtrados.Select(m => new FilaMovimiento(
                    m.FechaTexto,
                    m.Concepto,
                    m.Tipo,
                    m.Total,
                    m.FormaPago,
                    m.CorteInfo,
                    string.IsNullOrWhiteSpace(m.Usuario) ? "N/A" : m.Usuario,
                    m.Observacion ?? string.Empty));

                var columnaOrden = dgvMovimientos.SortedColumn;
                var sentidoOrden = dgvMovimientos.SortOrder;

                _vista = new ListaOrdenable<FilaMovimiento>(filas);
                dgvMovimientos.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvMovimientos.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                dgvMovimientos.ClearSelection();
                ActualizarResumen();
            },
            "No se pudo cargar el reporte de movimientos.",
            panelTop, panelFiltros);
        }

        // Actualiza los totales independientes de Ingresos y Egresos
        private void ActualizarResumen()
        {
            decimal totalIngresos = _vista.Where(f => f.Tipo.Equals("Ingreso", StringComparison.OrdinalIgnoreCase)).Sum(f => f.Total);
            decimal totalEgresos = _vista.Where(f => f.Tipo.Equals("Egreso", StringComparison.OrdinalIgnoreCase)).Sum(f => f.Total);

            // Asume que tienes labels en tu diseño para mostrar estos valores (ej. lblTotalIngresos, lblTotalEgresos)
            if (lblTotalIngresos != null) lblTotalIngresos.Text = $"Ingresos: {totalIngresos:C2}";
            if (lblTotalEgresos != null) lblTotalEgresos.Text = $"Egresos: {totalEgresos:C2}";
            if (lblTotal != null) lblTotal.Text = $"{_vista.Count} movimiento(s)";

            btnExportarExcel.Enabled = _vista.Count > 0;
        }

        // Colorea la columna "Tipo" (Verde para Ingresos, Rojo para Egresos)
        private void dgvMovimientos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle is null) return;
            if (dgvMovimientos.Columns[e.ColumnIndex].DataPropertyName != nameof(FilaMovimiento.Tipo)) return;

            e.CellStyle.ForeColor = (e.Value as string)?.Trim().ToLowerInvariant() switch
            {
                "ingreso" => Tema.Exito,
                "egreso" => Tema.Peligro,
                _ => e.CellStyle.ForeColor
            };
        }

        private void btnExportarExcel_Click(object? sender, EventArgs e)
        {
            if (_vista.Count == 0)
            {
                FormHelper.MostrarAviso("No hay datos en la tabla para exportar.");
                return;
            }

            try
            {
                string? ruta = ExportadorCsv.Exportar(dgvMovimientos, "Reporte_Movimientos");
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
