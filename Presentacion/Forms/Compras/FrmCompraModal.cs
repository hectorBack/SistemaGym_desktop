using Negocio.DTOs;
using Negocio.Exceptions;
using Presentacion.Controller;
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

namespace Presentacion.Forms.Compras
{
    public partial class FrmCompraModal : Form
    {
        private readonly CompraController _compraController;
        private readonly ProductoController _productoController;
        private readonly List<DetalleCompraViewModel> _listaDetalles = new();
        private readonly BindingSource _detallesBindingSource = new();

        private List<ProductoViewModel> _productosDisponibles = new();

        private decimal _totalAcumulado = 0;
        private ProductoViewModel? _productoEncontrado = null; 

        public FrmCompraModal(
            CompraController compraController,
            ProductoController productoController)
        {
            InitializeComponent();
            _compraController = compraController;
            _productoController = productoController;
        }

        private async void FrmCompraModal_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Registrar Nueva Compra";
            cmbFormaPago.SelectedIndex = 0; // "Efectivo" por defecto

            // Prevenir que la grilla genere columnas automáticas adicionales
            dgvDetalles.AutoGenerateColumns = false;

            ConfigurarGridDetalles();
            _detallesBindingSource.DataSource = _listaDetalles;
            dgvDetalles.DataSource = _detallesBindingSource;

            InicializarLabelsInformativos();
            ActualizarGridYTotal();
            await CargarProductosAsync();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string codigoOBusqueda = txtBuscarProducto.Text.Trim();

            // Si el usuario seleccionó un producto del combo pero no hay texto en el buscador
            if (_productoEncontrado == null && cmbProductos.SelectedItem is ProductoViewModel prodCombo)
            {
                _productoEncontrado = prodCombo;
            }

            if (_productoEncontrado == null && string.IsNullOrWhiteSpace(codigoOBusqueda))
            {
                MessageBox.Show("Seleccione un producto o ingrese un código de barras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad (stock) debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Si se escribió/escaneó un código manual distinto al del objeto guardado
                if (_productoEncontrado == null ||
                    (_productoEncontrado.CodigoBarras != codigoOBusqueda && _productoEncontrado.ProductoID.ToString() != codigoOBusqueda))
                {
                    _productoEncontrado = _productosDisponibles.FirstOrDefault(p =>
                        (p.CodigoBarras != null && p.CodigoBarras.Equals(codigoOBusqueda, StringComparison.OrdinalIgnoreCase)) ||
                        p.ProductoID.ToString() == codigoOBusqueda);
                }

                if (_productoEncontrado == null)
                {
                    MessageBox.Show("Producto no encontrado o inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Mostrar la información en los Labels
                lblCostoValor.Text = _productoEncontrado.Costo.ToString("C2");
                lblPrecioValor.Text = _productoEncontrado.Precio.ToString("C2");

                // 3. Agregar o actualizar en la lista del detalle
                var existente = _listaDetalles.FirstOrDefault(d => d.ProductoID == _productoEncontrado.ProductoID);
                if (existente != null)
                {
                    existente.Cantidad += (int)numCantidad.Value;
                }
                else
                {
                    _listaDetalles.Add(new DetalleCompraViewModel
                    {
                        ProductoID = _productoEncontrado.ProductoID,
                        ProductoNombre = _productoEncontrado.Nombre,
                        CodigoBarras = _productoEncontrado.CodigoBarras ?? string.Empty,
                        Cantidad = (int)numCantidad.Value,
                        CostoUnitario = _productoEncontrado.Costo
                    });
                }

                // 4. Limpiar selección rápida
                txtBuscarProducto.Clear();

                cmbProductos.SelectedIndexChanged -= cmbProductos_SelectedIndexChanged;
                cmbProductos.SelectedIndex = -1;
                cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;

                numCantidad.Value = 1;
                _productoEncontrado = null;
                InicializarLabelsInformativos();
                txtBuscarProducto.Focus();

                ActualizarGridYTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento opcional para que al escribir/esccanear el código se muestren inmediatamente costo y precio
        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string codigo = txtBuscarProducto.Text.Trim();

                if (!string.IsNullOrWhiteSpace(codigo))
                {
                    var prod = _productosDisponibles.FirstOrDefault(p =>
                        (p.CodigoBarras != null && p.CodigoBarras.Equals(codigo, StringComparison.OrdinalIgnoreCase)) ||
                        p.ProductoID.ToString() == codigo);

                    if (prod != null)
                    {
                        _productoEncontrado = prod;

                        // Sincronizar ComboBox
                        cmbProductos.SelectedIndexChanged -= cmbProductos_SelectedIndexChanged;
                        cmbProductos.SelectedValue = prod.ProductoID;
                        cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;

                        lblCostoValor.Text = prod.Costo.ToString("C2");
                        lblPrecioValor.Text = prod.Precio.ToString("C2");
                    }
                    else
                    {
                        _productoEncontrado = null;
                        InicializarLabelsInformativos();
                        MessageBox.Show("Producto no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista para quitar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (DetalleCompraViewModel)dgvDetalles.CurrentRow.DataBoundItem;
            _listaDetalles.Remove(item);

            ActualizarGridYTotal();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!_listaDetalles.Any())
            {
                MessageBox.Show("Debe agregar al menos un producto a la compra.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string codigoGenerado = await _compraController.ObtenerSiguienteCodigoAsync();

                var createDto = new CompraCreateDto
                {
                    Codigo = codigoGenerado,
                    Observacion = string.Empty,
                    FormaPago = cmbFormaPago.SelectedItem?.ToString() ?? "Efectivo",
                    UsuarioID = SesionUsuario.UsuarioID,
                    Detalles = _listaDetalles.Select(d => new DetalleCompraCreateDto
                    {
                        ProductoID = d.ProductoID,
                        Cantidad = d.Cantidad,
                        CostoUnitario = d.CostoUnitario
                    }).ToList()
                };

                await _compraController.CrearCompraAsync(createDto);
                MessageBox.Show("Compra registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al procesar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await _productoController.ObtenerProductosAsync(incluirInactivos: false);
                _productosDisponibles = productos.ToList();

                CargarComboBoxProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar lista de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboBoxProductos()
        {
            // Se desvincula temporalmente el evento para evitar disparos en cascada al llenar los datos
            cmbProductos.SelectedIndexChanged -= cmbProductos_SelectedIndexChanged;

            cmbProductos.DataSource = null;
            cmbProductos.DataSource = _productosDisponibles;
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "ProductoID";
            cmbProductos.SelectedIndex = -1; // Inicia deseleccionado

            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
        }

        // Evento al seleccionar una opción dentro del ComboBox de productos
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs? e)
        {
            // 1. Validar que la selección no sea -1 o nula
            if (cmbProductos.SelectedIndex < 0 || cmbProductos.SelectedItem == null)
            {
                return;
            }

            if (cmbProductos.SelectedItem is ProductoViewModel prodCombo)
            {
                _productoEncontrado = prodCombo;

                // 2. Asignar el valor asegurando que no haya conflictos de selección en el TextBox
                string codigo = !string.IsNullOrEmpty(prodCombo.CodigoBarras)
                    ? prodCombo.CodigoBarras
                    : prodCombo.ProductoID.ToString();

                if (txtBuscarProducto.Text != codigo)
                {
                    txtBuscarProducto.Text = codigo;
                    txtBuscarProducto.SelectionStart = txtBuscarProducto.Text.Length; // Mover cursor al final sin seleccionar -1
                }

                lblCostoValor.Text = prodCombo.Costo.ToString("C2");
                lblPrecioValor.Text = prodCombo.Precio.ToString("C2");
            }
        }

        #region Métodos Privados
        private void InicializarLabelsInformativos()
        {
            lblCostoValor.Text = "$0.00";
            lblPrecioValor.Text = "$0.00";
        }

        private void ActualizarGridYTotal()
        {
            _detallesBindingSource.ResetBindings(false);

            _totalAcumulado = _listaDetalles.Sum(d => d.Cantidad * d.CostoUnitario);
            lblTotalCalculado.Text = _totalAcumulado.ToString("C2");
        }

        private void ConfigurarGridDetalles()
        {
            dgvDetalles.Columns.Clear();

            // 1. Columna: Stock (Cantidad comprada)
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Stock",
                Name = "Cantidad"
            });

            // 2. Columna: Nombre
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductoNombre",
                HeaderText = "Nombre",
                Name = "ProductoNombre"
            });

            // 3. Columna: Costo
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CostoUnitario",
                HeaderText = "Costo",
                Name = "CostoUnitario",
                DefaultCellStyle = { Format = "C2" }
            });

            // 4. Columna: Total
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Subtotal",
                HeaderText = "Total",
                Name = "Subtotal",
                DefaultCellStyle = { Format = "C2" }
            });

            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion
    }
}
