using Presentacion.Controller;
using Presentacion.Controls;
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

namespace Presentacion.Forms.Productos
{
    public partial class FrmProductos : Form
    {
        private readonly ProductoController _productoController;
        private readonly CategoriaController _categoriaController;
        private List<ProductoViewModel> _listaProductos = new();

        public FrmProductos(ProductoController productoController, CategoriaController categoriaController)
        {
            InitializeComponent();
            _productoController = productoController;
            _categoriaController = categoriaController;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
        }

        private async void FrmProductos_Load(object sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            await CargarProductosAsync();
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var resultado = await _productoController.ObtenerProductosAsync(true);
                _listaProductos = resultado.ToList();
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = _listaProductos;
                ConfigurarGrid();
                dgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            // 1. Ocultar columnas secundarias/técnicas
            if (dgvProductos.Columns["CategoriaID"] != null) dgvProductos.Columns["CategoriaID"].Visible = false;
            if (dgvProductos.Columns["Activo"] != null) dgvProductos.Columns["Activo"].Visible = false;

            // 2. Configurar encabezados y formatos
            if (dgvProductos.Columns["ProductoID"] != null) dgvProductos.Columns["ProductoID"].HeaderText = "ID";
            if (dgvProductos.Columns["CodigoBarras"] != null) dgvProductos.Columns["CodigoBarras"].HeaderText = "Código Barras";
            if (dgvProductos.Columns["Nombre"] != null) dgvProductos.Columns["Nombre"].HeaderText = "Producto";
            if (dgvProductos.Columns["CategoriaNombre"] != null) dgvProductos.Columns["CategoriaNombre"].HeaderText = "Categoría";

            if (dgvProductos.Columns["Precio"] != null)
            {
                dgvProductos.Columns["Precio"].HeaderText = "Precio";
                dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
            }

            if (dgvProductos.Columns["Stock"] != null) dgvProductos.Columns["Stock"].HeaderText = "Stock";
            if (dgvProductos.Columns["Estado"] != null) dgvProductos.Columns["Estado"].HeaderText = "Estado";
            if (dgvProductos.Columns["CreatedAt"] != null) dgvProductos.Columns["CreatedAt"].HeaderText = "Fecha Registro";

            // 3. Estructura de ordenamiento y pesos estilo estándar
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
        "ProductoID",
        "CodigoBarras",
        "Nombre",
        "CategoriaNombre",
        "Precio",
        "Stock",
        "Estado",
        "CreatedAt"
    };

            var pesos = new Dictionary<string, float>
            {
                ["ProductoID"] = 45,
                ["CodigoBarras"] = 100,
                ["Nombre"] = 175,
                ["CategoriaNombre"] = 120,
                ["Precio"] = 80,
                ["Stock"] = 65,
                ["Estado"] = 80,
                ["CreatedAt"] = 120
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvProductos.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "Nombre" or "CategoriaNombre" or "CodigoBarras" => 110,
                    "CreatedAt" => 95,
                    _ => 55
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmProductoModal(_productoController, _categoriaController);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarProductosAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (ProductoViewModel)dgvProductos.CurrentRow.DataBoundItem;
            using var modal = new FrmProductoModal(_productoController, _categoriaController, item.ProductoID);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarProductosAsync();
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (ProductoViewModel)dgvProductos.CurrentRow.DataBoundItem;
            string accion = item.Activo ? "desactivar" : "activar";

            if (FormHelper.ConfirmarAccion($"¿Está seguro de {accion} el producto '{item.Nombre}'?", $"Confirmar {accion.ToUpper()}"))
            {
                try
                {
                    await _productoController.CambiarEstadoLogicoAsync(item.ProductoID);
                    await CargarProductosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (ProductoViewModel)dgvProductos.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE el producto '{item.Nombre}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _productoController.EliminarFisicoAsync(item.ProductoID);
                    await CargarProductosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is ProductoViewModel item)
            {
                if (item.Activo)
                {
                    btnDesactivar.Text = "Desactivar";
                    btnDesactivar.BackColor = System.Drawing.Color.IndianRed;
                }
                else
                {
                    btnDesactivar.Text = "Activar";
                    btnDesactivar.BackColor = System.Drawing.Color.ForestGreen;
                }
            }
        }
    }
}
