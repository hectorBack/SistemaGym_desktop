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

        // El stock no se edita aquí: se conserva el que tenía el producto al abrir (0 si es nuevo).
        // ⚠ Riesgo: ese valor se reenvía al guardar. Si otra terminal vende o compra mientras este
        // formulario está abierto, al guardar se pisa el stock con el valor viejo. Lo ideal es que
        // GuardarProductoAsync (y el servicio de actualización) NO reciban ni modifiquen el stock:
        // que solo cambie por ventas, compras o ajustes de inventario.
        private int _stockActual;

        private bool _guardando;

        public FrmProductoModal(ProductoController productoController, CategoriaController categoriaController, int? productoId = null)
        {
            _productoController = productoController ?? throw new ArgumentNullException(nameof(productoController));
            _categoriaController = categoriaController ?? throw new ArgumentNullException(nameof(categoriaController));
            _productoId = productoId;

            InitializeComponent();
        }

        // ───────────── Carga ─────────────

        private async void FrmProductoModal_Load(object? sender, EventArgs e)
        {
            lblTitulo.Text = _productoId.HasValue ? "Editar Producto" : "Nuevo Producto";
            btnGuardar.Enabled = false; // no se puede guardar hasta que termine de cargar

            bool productoEncontrado = true;

            bool cargado = await FormHelper.EjecutarAsync(async () =>
            {
                await CargarCategoriasAsync();

                if (_productoId.HasValue)
                    productoEncontrado = await CargarDatosProductoAsync(_productoId.Value);
            },
            "No se pudieron cargar los datos del formulario.");

            if (IsDisposed) return;

            if (cargado && !productoEncontrado)
                FormHelper.MostrarAdvertencia("El producto ya no existe. Es posible que otro usuario lo haya eliminado.");

            // Si algo falló al cargar, no se deja editar: guardar con datos a medias podría pisar costo y stock.
            if (!cargado || !productoEncontrado)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            btnGuardar.Enabled = true;
            txtNombre.Focus();
        }

        private async Task CargarCategoriasAsync()
        {
            var categorias = (await _categoriaController.ObtenerCategoriasAsync(false)).ToList();
            if (IsDisposed) return;

            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaID";
            cmbCategoria.DataSource = categorias;
            cmbCategoria.SelectedIndex = -1;
        }

        /// <summary>Devuelve false si el producto ya no existe.</summary>
        private async Task<bool> CargarDatosProductoAsync(int id)
        {
            var producto = await _productoController.ObtenerPorIdAsync(id);
            if (IsDisposed) return true;
            if (producto == null) return false;

            cmbCategoria.SelectedValue = producto.CategoriaID;
            txtCodigoBarras.Text = producto.CodigoBarras;
            txtNombre.Text = producto.Nombre;
            numCosto.Value = producto.Costo;
            numPrecio.Value = producto.Precio;
            chkActivo.Checked = producto.Activo;

            _stockActual = producto.Stock;
            return true;
        }

        // ───────────── Guardado ─────────────

        private bool ValidarCampos()
        {
            if (cmbCategoria.SelectedValue == null)
            {
                FormHelper.MostrarAdvertencia("Debe seleccionar una categoría para el producto.", "Validación");
                cmbCategoria.Focus();
                return false;
            }

            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                FormHelper.MostrarAdvertencia("Debe ingresar un nombre para el producto.", "Validación");
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            int categoriaId = Convert.ToInt32(cmbCategoria.SelectedValue);
            string? codigoBarras = ValidationHelper.EsTextoVacio(txtCodigoBarras.Text) ? null : txtCodigoBarras.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            decimal costo = numCosto.Value;
            decimal precio = numPrecio.Value;
            bool activo = chkActivo.Checked;
            int stock = _stockActual;

            _guardando = true;
            bool guardado = await FormHelper.EjecutarAsync(
                () => _productoController.GuardarProductoAsync(_productoId, categoriaId, codigoBarras, nombre, costo, precio, stock, activo),
                "No se pudo guardar el producto.",
                btnGuardar, btnCancelar);
            _guardando = false;

            if (guardado && !IsDisposed)
                DialogResult = DialogResult.OK; // cierra el diálogo; el grid se recarga solo
        }

        // ───────────── Teclado y cierre ─────────────

        // Los lectores de código de barras terminan con Enter. Sin esto, escanear en el campo
        // de código de barras dispararía "Guardar" (AcceptButton) antes de capturar el nombre.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ActiveControl == txtCodigoBarras)
            {
                txtNombre.Focus();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // No permitir cerrar la ventana mientras se está guardando.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_guardando)
                e.Cancel = true;

            base.OnFormClosing(e);
        }
    }
}
