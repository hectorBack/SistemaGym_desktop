using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.Controls;
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

namespace Presentacion.Forms.Productos
{
    public partial class FrmProductoModal : Form
    {
        private readonly ProductoController _productoController;
        private readonly CategoriaController _categoriaController;
        private readonly int? _productoId;

        public FrmProductoModal(ProductoController productoController, CategoriaController categoriaController, int? productoId = null)
        {
            InitializeComponent();
            _productoController = productoController;
            _categoriaController = categoriaController;
            _productoId = productoId;
        }

        private async void FrmProductoModal_Load(object sender, EventArgs e)
        {
            await CargarCategoriasAsync();

            if (_productoId.HasValue)
            {
                lblTitulo.Text = "Editar Producto";
                await CargarDatosProductoAsync(_productoId.Value);
            }
            else
            {
                lblTitulo.Text = "Nuevo Producto";
            }
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var categorias = await _categoriaController.ObtenerCategoriasAsync(false); // Carga solo activas
                cmbCategoria.DataSource = categorias.ToList();
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "CategoriaID";
                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDatosProductoAsync(int id)
        {
            try
            {
                var producto = await _productoController.ObtenerPorIdAsync(id);
                if (producto != null)
                {
                    cmbCategoria.SelectedValue = producto.CategoriaID;
                    txtCodigoBarras.Text = producto.CodigoBarras;
                    txtNombre.Text = producto.Nombre;
                    numPrecio.Value = producto.Precio;
                    numStock.Value = producto.Stock;
                    chkActivo.Checked = producto.Activo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una categoría para el producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return;
            }

            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para el producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                int categoriaId = Convert.ToInt32(cmbCategoria.SelectedValue);
                string? codigoBarras = ValidationHelper.EsTextoVacio(txtCodigoBarras.Text) ? null : txtCodigoBarras.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                decimal precio = numPrecio.Value;
                int stock = Convert.ToInt32(numStock.Value);
                bool activo = chkActivo.Checked;

                await _productoController.GuardarProductoAsync(_productoId, categoriaId, codigoBarras, nombre, precio, stock, activo);

                MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
