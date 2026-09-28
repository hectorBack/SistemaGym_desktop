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
        private decimal _totalAcumulado = 0;
        private ProductoDto? _productoEncontrado = null; // Guardar temporalmente el producto escaneado

        public FrmCompraModal(
            CompraController compraController,
            ProductoController productoController)
        {
            InitializeComponent();
            _compraController = compraController;
            _productoController = productoController;
        }

        private void FrmCompraModal_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Registrar Nueva Compra";
            cmbFormaPago.SelectedIndex = 0; // "Efectivo" por defecto

            // Prevenir que la grilla genere columnas automáticas adicionales
            dgvDetalles.AutoGenerateColumns = false;

            InicializarLabelsInformativos();
            ActualizarGridYTotal();
        }

        private async void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string codigoOBusqueda = txtBuscarProducto.Text.Trim();

            if (ValidationHelper.EsTextoVacio(codigoOBusqueda))
            {
                MessageBox.Show("Ingrese un código de barras o nombre de producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad (stock) debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Obtener producto por código de barras si no ha sido buscado previamente
                if (_productoEncontrado == null || _productoEncontrado.CodigoBarras != codigoOBusqueda)
                {
                    _productoEncontrado = await _productoController.ObtenerPorCodigoBarrasAsync(codigoOBusqueda);
                }

                if (_productoEncontrado == null)
                {
                    MessageBox.Show("Producto no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                numCantidad.Value = 1;
                _productoEncontrado = null;
                txtBuscarProducto.Focus();

                ActualizarGridYTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento opcional para que al escribir/esccanear el código se muestren inmediatamente costo y precio
        private async void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtBuscarProducto.Text))
            {
                e.SuppressKeyPress = true;
                _productoEncontrado = await _productoController.ObtenerPorCodigoBarrasAsync(txtBuscarProducto.Text.Trim());
                if (_productoEncontrado != null)
                {
                    lblCostoValor.Text = _productoEncontrado.Costo.ToString("C2");
                    lblPrecioValor.Text = _productoEncontrado.Precio.ToString("C2");
                }
                else
                {
                    InicializarLabelsInformativos();
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

        #region Métodos Privados
        private void InicializarLabelsInformativos()
        {
            lblCostoValor.Text = "$0.00";
            lblPrecioValor.Text = "$0.00";
        }

        private void ActualizarGridYTotal()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _listaDetalles;

            _totalAcumulado = _listaDetalles.Sum(d => d.Cantidad * d.CostoUnitario);
            lblTotalCalculado.Text = _totalAcumulado.ToString("C2");

            ConfigurarGridDetalles();
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
