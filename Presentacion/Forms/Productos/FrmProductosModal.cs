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
        private int _stockActual = 0; // Guardará el stock existente en caso de edición

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
                _stockActual = 0; // Todo producto nuevo inicia con stock en cero
            }
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var categorias = await _categoriaController.ObtenerCategoriasAsync(false);
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
                    numCosto.Value = producto.Costo;
                    numPrecio.Value = producto.Precio;
                    chkActivo.Checked = producto.Activo;

                    // Conservamos el stock que tiene registrado en BD
                    _stockActual = producto.Stock;
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
                decimal costo = numCosto.Value;
                decimal precio = numPrecio.Value;
                bool activo = chkActivo.Checked;

                // Se envía _stockActual (0 si es nuevo, o su stock original si es edición)
                await _productoController.GuardarProductoAsync(_productoId, categoriaId, codigoBarras, nombre, costo, precio, _stockActual, activo);

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
