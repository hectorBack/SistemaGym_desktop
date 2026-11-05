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
    public partial class FrmInventarios : Form
    {
        private readonly ReporteController _reporteController;

        public FrmInventarios(ReporteController reporteController)
        {
            _reporteController = reporteController ?? throw new ArgumentNullException(nameof(reporteController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        private async void FrmInventarios_Load(object? sender, EventArgs e) => await CargarInventarioAsync();

        // Las columnas se definen una sola vez. Antes se generaban todas y se ocultaban 6 por nombre
        // (ProductoID, Codigo, Categoria, ValorTotalInventario, Activo, Estado); ahora solo existen las 4 que se muestran.
        private void ConfigurarColumnas()
        {
            dgvInventario.AutoGenerateColumns = false;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvInventario.RowTemplate.Height = 24;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvInventario.ColumnHeadersHeight = 48;

            var columnaNombre = dgvInventario.AgregarTexto(nameof(ReporteInventarioViewModel.Producto), "Nombre", 190, 130);
            var columnaPrecioCompra = dgvInventario.AgregarTexto(nameof(ReporteInventarioViewModel.PrecioCompra), "Costo", 70, 60, "C2");
            var columnaPrecioVenta = dgvInventario.AgregarTexto(nameof(ReporteInventarioViewModel.PrecioVenta), "Precio", 70, 60, "C2");
            var columnaStock = dgvInventario.AgregarTexto(nameof(ReporteInventarioViewModel.StockActual), "Stock", 888, 70);

            columnaNombre.FillWeight = 190;
            columnaPrecioCompra.FillWeight = 70;
            columnaPrecioVenta.FillWeight = 70;
            columnaStock.FillWeight = 888;  
        }

        private async Task CargarInventarioAsync()
        {
            await FormHelper.EjecutarAsync(async () =>
            {
                var inventario = await _reporteController.ObtenerInventarioAsync();
                if (IsDisposed) return; // el usuario cambió de pestaña o módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo si se vuelve a cargar.
                var columnaOrden = dgvInventario.SortedColumn;
                var sentidoOrden = dgvInventario.SortOrder;

                dgvInventario.DataSource = new ListaOrdenable<ReporteInventarioViewModel>(inventario);

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvInventario.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? System.ComponentModel.ListSortDirection.Descending
                        : System.ComponentModel.ListSortDirection.Ascending);
                }

                dgvInventario.ClearSelection();
                btnExportarExcel.Enabled = dgvInventario.Rows.Count > 0;
            },
            "No se pudo cargar el inventario.",
            panelTop);
        }

        // Antes este botón mostraba "Exportación realizada con éxito" sin exportar nada.
        // Ahora genera un .csv que Excel abre directamente.
        private void btnExportarExcel_Click(object? sender, EventArgs e)
        {
            if (dgvInventario.Rows.Count == 0)
            {
                FormHelper.MostrarAviso("No hay datos en la tabla para exportar.");
                return;
            }

            try
            {
                string? ruta = ExportadorCsv.Exportar(dgvInventario, "Inventario");
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
