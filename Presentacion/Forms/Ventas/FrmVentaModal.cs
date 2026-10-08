using Negocio.DTOs;
using Negocio.Exceptions;
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

namespace Presentacion.Forms.Ventas
{
    public partial class FrmVentaModal : Form
    {
        private readonly VentaController _ventaController;
        private readonly ProductoController _productoController;

        private readonly List<DetalleVentaCreateDto> _carrito = new();
        private List<ProductoViewModel> _productosDisponibles = new();

        private readonly int _usuarioIdActual = 1;

        public FrmVentaModal(VentaController ventaController, ProductoController productoController)
        {
            InitializeComponent();
            _ventaController = ventaController;
            _productoController = productoController;

            lblTitulo.Text = "Nueva Venta / Punto de Venta";
        }

        private async void FrmVentaModal_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await _productoController.ObtenerProductosAsync(incluirInactivos: false);
                _productosDisponibles = productos.ToList();

                // 🟢 Llenar el ComboBox de productos al cargar
                CargarComboBoxProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboBoxProductos()
        {
            // Se suscribe temporalmente al evento para evitar disparos durante el llenado de datos
            cmbProductos.SelectedIndexChanged -= cmbProductos_SelectedIndexChanged;

            cmbProductos.DataSource = null;
            cmbProductos.DataSource = _productosDisponibles;
            cmbProductos.DisplayMember = "Nombre"; // Propiedad a mostrar en la lista
            cmbProductos.ValueMember = "ProductoID"; // Propiedad que representa el ID
            cmbProductos.SelectedIndex = -1; // Dejar sin selección inicial

            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
        }

        // 🟢 Evento al seleccionar un producto del desplegable ComboBox
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs? e)
        {
            if (cmbProductos.SelectedItem is ProductoViewModel productoSeleccionado)
            {
                // Sincroniza el código de barras del producto seleccionado en el TextBox
                txtCodigoBarras.Text = !string.IsNullOrEmpty(productoSeleccionado.CodigoBarras)
                    ? productoSeleccionado.CodigoBarras
                    : productoSeleccionado.ProductoID.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProcesarAgregarProducto();
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el 'beep' de Windows
                ProcesarAgregarProducto();
            }
        }

        private void ProcesarAgregarProducto()
        {
            string codigo = txtCodigoBarras.Text.Trim();
            ProductoViewModel? prodSeleccionado = null;

            // 1. Si hay texto en el código de barras, buscar coincidencia por código o ID
            if (!string.IsNullOrWhiteSpace(codigo))
            {
                prodSeleccionado = _productosDisponibles.FirstOrDefault(p =>
                    (p.CodigoBarras != null && p.CodigoBarras.Equals(codigo, StringComparison.OrdinalIgnoreCase)) ||
                    p.ProductoID.ToString() == codigo);
            }
            // 2. Si el código de barras está vacío, tomar la opción seleccionada en el ComboBox
            else if (cmbProductos.SelectedItem is ProductoViewModel prodCombo)
            {
                prodSeleccionado = prodCombo;
            }

            if (prodSeleccionado == null)
            {
                MessageBox.Show("Seleccione o ingrese un producto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.Focus();
                return;
            }

            int cantidad = (int)numCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el producto ya está en el carrito
            var itemExistente = _carrito.FirstOrDefault(d => d.ProductoID == prodSeleccionado.ProductoID);
            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                _carrito.Add(new DetalleVentaCreateDto
                {
                    ProductoID = prodSeleccionado.ProductoID,
                    Cantidad = cantidad,
                    PrecioUnitario = prodSeleccionado.Precio
                });
            }

            ActualizarGridCarrito();

            // Restablecer campos para el siguiente producto
            txtCodigoBarras.Clear();
            cmbProductos.SelectedIndexChanged -= cmbProductos_SelectedIndexChanged;
            cmbProductos.SelectedIndex = -1;
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;

            numCantidad.Value = 1;
            txtCodigoBarras.Focus();
        }

        #region Control de Teclado (+ / -)

        private void dgvCarrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                e.SuppressKeyPress = true;
                ModificarCantidadSeleccionada(1);
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                e.SuppressKeyPress = true;
                ModificarCantidadSeleccionada(-1);
            }
        }

        private void FrmVentaModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtCodigoBarras.Focused || string.IsNullOrEmpty(txtCodigoBarras.Text))
            {
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    e.SuppressKeyPress = true;
                    ModificarCantidadSeleccionada(1);
                }
                else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
                {
                    e.SuppressKeyPress = true;
                    ModificarCantidadSeleccionada(-1);
                }
            }
        }

        private void ModificarCantidadSeleccionada(int cambio)
        {
            if (dgvCarrito.CurrentRow == null) return;

            int index = dgvCarrito.CurrentRow.Index;
            if (index >= 0 && index < _carrito.Count)
            {
                var item = _carrito[index];
                item.Cantidad += cambio;

                if (item.Cantidad <= 0)
                {
                    _carrito.RemoveAt(index);
                }

                ActualizarGridCarrito();

                if (_carrito.Count > 0)
                {
                    int nuevoIndex = Math.Min(index, _carrito.Count - 1);
                    dgvCarrito.Rows[nuevoIndex].Selected = true;
                    dgvCarrito.CurrentCell = dgvCarrito.Rows[nuevoIndex].Cells[0];
                }
            }
        }

        #endregion

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto del carrito para quitar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = dgvCarrito.CurrentRow.Index;
            if (index >= 0 && index < _carrito.Count)
            {
                _carrito.RemoveAt(index);
                ActualizarGridCarrito();
            }
        }

        private void ActualizarGridCarrito()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = _carrito.Select(c => new
            {
                Producto = _productosDisponibles.FirstOrDefault(p => p.ProductoID == c.ProductoID)?.Nombre ?? "N/A",
                c.Cantidad,
                PrecioUnitario = c.PrecioUnitario.ToString("C2"),
                Subtotal = (c.Cantidad * c.PrecioUnitario).ToString("C2")
            }).ToList();

            decimal total = _carrito.Sum(c => c.Cantidad * c.PrecioUnitario);
            lblTotalCalculado.Text = total.ToString("C2");
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!_carrito.Any())
            {
                MessageBox.Show("Debe agregar al menos un producto al carrito de compras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? socioId = null;
            decimal totalVenta = _carrito.Sum(c => c.Cantidad * c.PrecioUnitario);

            try
            {
                await _ventaController.RegistrarVentaAsync(_usuarioIdActual, socioId, totalVenta, _carrito);

                MessageBox.Show("Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al procesar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
