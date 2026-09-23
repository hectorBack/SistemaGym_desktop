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

        // Puedes simular o inyectar el ID del usuario/cajero actual
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese o escanee un código de barras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.Focus();
                return;
            }

            // Busca coincidencia por Código de Barras (o por ProductoID en caso de que coincida)
            var prodSeleccionado = _productosDisponibles.FirstOrDefault(p =>
                (p.CodigoBarras != null && p.CodigoBarras.Equals(codigo, StringComparison.OrdinalIgnoreCase)) ||
                p.ProductoID.ToString() == codigo);

            if (prodSeleccionado == null)
            {
                MessageBox.Show("Producto no encontrado o inactivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.SelectAll();
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

            // Limpia el campo para la siguiente lectura del escáner
            txtCodigoBarras.Clear();
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
            // Solo incrementa/decremanta si el foco no está escribiendo un texto en el buscador
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

                // Si la cantidad disminuye a 0 o menos, elimina el registro
                if (item.Cantidad <= 0)
                {
                    _carrito.RemoveAt(index);
                }

                ActualizarGridCarrito();

                // Mantiene el foco en la fila correcta del DataGridView tras refrescar
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
                c.ProductoID,
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

            int? socioId = string.IsNullOrWhiteSpace(txtSocioId.Text) ? null : int.Parse(txtSocioId.Text.Trim());
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
