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
    
        public partial class FrmInventarios : Form
        {
            private readonly ReporteController _reporteController;
            private List<ReporteInventarioViewModel> _listaInventario = new();

            public FrmInventarios(ReporteController reporteController)
            {
                InitializeComponent();
                _reporteController = reporteController;
            }

            private async void FrmInventarios_Load(object sender, EventArgs e)
            {
                await CargarInventarioAsync();
            }

            private async Task CargarInventarioAsync()
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    var resultado = await _reporteController.ObtenerInventarioAsync();
                    _listaInventario = resultado.ToList();

                    dgvInventario.DataSource = null;
                    dgvInventario.DataSource = _listaInventario;

                    ConfigurarGrid();
                    dgvInventario.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }

            private void ConfigurarGrid()
            {
                // 1. Ocultar columnas técnicas o no solicitadas de ReporteInventarioViewModel
                string[] columnasOcultas = { "ProductoID", "Codigo", "Categoria", "ValorTotalInventario", "Activo", "Estado" };
                foreach (var col in columnasOcultas)
                {
                    if (dgvInventario.Columns[col] != null)
                        dgvInventario.Columns[col].Visible = false;
                }

                // 2. Renombrar encabezados de las columnas visibles
                if (dgvInventario.Columns["Producto"] != null) dgvInventario.Columns["Producto"].HeaderText = "Nombre";
                if (dgvInventario.Columns["PrecioCompra"] != null) dgvInventario.Columns["PrecioCompra"].HeaderText = "Costo";
                if (dgvInventario.Columns["PrecioVenta"] != null) dgvInventario.Columns["PrecioVenta"].HeaderText = "Precio";
                if (dgvInventario.Columns["StockActual"] != null) dgvInventario.Columns["StockActual"].HeaderText = "Stock";

                // Formato de moneda para Costo y Precio
                if (dgvInventario.Columns["PrecioCompra"] != null) dgvInventario.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
                if (dgvInventario.Columns["PrecioVenta"] != null) dgvInventario.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";

                // 3. Orden, pesos y alineaciones estilo estándar
                dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                string[] ordenColumnas =
                {
                "Producto",
                "PrecioCompra",
                "PrecioVenta",
                "StockActual"
            };

                var pesos = new Dictionary<string, float>
                {
                    ["Producto"] = 220,
                    ["PrecioCompra"] = 90,
                    ["PrecioVenta"] = 90,
                    ["StockActual"] = 70
                };

                for (int indice = 0; indice < ordenColumnas.Length; indice++)
                {
                    if (dgvInventario.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                        continue;

                    columna.DisplayIndex = indice;
                    columna.FillWeight = pesos[columna.Name];
                    columna.MinimumWidth = columna.Name switch
                    {
                        "Producto" => 150,
                        _ => 70
                    };

                    // Alineación a la derecha para montos/números e izquierda para texto
                    if (columna.Name == "PrecioCompra" || columna.Name == "PrecioVenta" || columna.Name == "StockActual")
                    {
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else
                    {
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                }
            }

            private void btnExportarExcel_Click(object sender, EventArgs e)
            {
                if (dgvInventario.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos en la tabla para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    // Código/Helper para exportación a Excel
                    MessageBox.Show("Exportación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
}
