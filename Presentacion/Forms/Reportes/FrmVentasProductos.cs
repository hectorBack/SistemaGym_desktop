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
    public partial class FrmVentasProductos : Form
    {
        /// <summary>Una fila del reporte. Los importes se guardan como decimal (no como texto) para que ordenen y sumen bien.</summary>
        private sealed record FilaVentaProducto(
            string FechaRegistro,
            string Producto,
            decimal CostoUnitario,
            decimal PrecioUnitario,
            decimal Ganancia);

        private readonly ReporteController _reporteController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<FilaVentaProducto> _vista = new();

        public FrmVentasProductos(ReporteController reporteController)
        {
            _reporteController = reporteController ?? throw new ArgumentNullException(nameof(reporteController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void FrmVentasProductos_Load(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        // Las columnas se definen una sola vez, con su formato real.
        private void ConfigurarColumnas()
        {
            dgvVentasProductos.AutoGenerateColumns = false;

            dgvVentasProductos.AgregarTexto(nameof(FilaVentaProducto.FechaRegistro), "Fecha de Registro", 120, 120);
            dgvVentasProductos.AgregarTexto(nameof(FilaVentaProducto.Producto), "Nombre del producto", 200, 140);
            dgvVentasProductos.AgregarTexto(nameof(FilaVentaProducto.CostoUnitario), "Costo Unitario", 90, 90, "C2", alinearDerecha: true);
            dgvVentasProductos.AgregarTexto(nameof(FilaVentaProducto.PrecioUnitario), "Precio Unitario", 90, 90, "C2", alinearDerecha: true);
            dgvVentasProductos.AgregarTexto(nameof(FilaVentaProducto.Ganancia), "Ganancia", 90, 90, "C2", alinearDerecha: true);

            // La fecha llega como texto del reporte: ordenarla alfabéticamente daría un orden engañoso.
            foreach (DataGridViewColumn c in dgvVentasProductos.Columns)
                if (c.DataPropertyName == nameof(FilaVentaProducto.FechaRegistro))
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
                var ventas = await _reporteController.ObtenerVentaProductosAsync(inicio, fin);
                if (IsDisposed) return; // el usuario cambió de pestaña o módulo mientras cargaba

                var filas = ventas.Select(v => new FilaVentaProducto(
                    string.IsNullOrWhiteSpace(v.FechaRegistro) ? "N/A" : v.FechaRegistro,
                    string.IsNullOrWhiteSpace(v.Producto) ? "N/A" : v.Producto,
                    ADecimal(v.CostoUnitario),
                    ADecimal(v.PrecioUnitario),
                    ADecimal(v.Ganancia)));

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvVentasProductos.SortedColumn;
                var sentidoOrden = dgvVentasProductos.SortOrder;

                _vista = new ListaOrdenable<FilaVentaProducto>(filas);
                dgvVentasProductos.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvVentasProductos.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                dgvVentasProductos.ClearSelection();
                ActualizarResumen();
            },
            "No se pudo cargar el reporte de ventas de productos.",
            panelTop, panelFiltros);
        }

        // Acepta decimal o texto con formato de moneda ("$1,250.00"), sea cual sea el tipo del ViewModel.
        private static decimal ADecimal(object? valor) => valor switch
        {
            null => 0m,
            decimal d => d,
            string s when decimal.TryParse(s, NumberStyles.Currency, CultureInfo.CurrentCulture, out var r) => r,
            IConvertible c => TryConvertir(c),
            _ => 0m
        };

        private static decimal TryConvertir(IConvertible c)
        {
            try { return c.ToDecimal(CultureInfo.CurrentCulture); }
            catch (Exception ex) when (ex is FormatException or InvalidCastException or OverflowException) { return 0m; }
        }

        private void ActualizarResumen()
        {
            lblTotal.Text = $"{_vista.Count} registro(s)  ·  Total Ganancia {_vista.Sum(f => f.Ganancia):C2}";
            btnExportarExcel.Enabled = _vista.Count > 0;
        }

        // Ganancia en verde; si hubo pérdida (negativa), en rojo.
        private void dgvVentasProductos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle is null) return;
            if (dgvVentasProductos.Columns[e.ColumnIndex].DataPropertyName != nameof(FilaVentaProducto.Ganancia)) return;

            if (e.Value is decimal g)
                e.CellStyle.ForeColor = g < 0 ? Tema.Peligro : Tema.Exito;
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
                string? ruta = ExportadorCsv.Exportar(dgvVentasProductos, "Ventas_de_productos");
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
