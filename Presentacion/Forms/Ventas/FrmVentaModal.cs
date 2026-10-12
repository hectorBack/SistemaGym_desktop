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

namespace Presentacion.Forms.Ventas
{
    public partial class FrmVentaModal : Form
    {
        /// <summary>Una línea del carrito. Es lo que muestra el grid; al guardar se convierte a DetalleVentaCreateDto.</summary>
        public sealed class LineaCarrito
        {
            public int ProductoID { get; init; }
            public string Producto { get; init; } = string.Empty;
            public decimal PrecioUnitario { get; init; }
            public int Stock { get; init; }
            public int Cantidad { get; set; }
            public decimal Subtotal => Cantidad * PrecioUnitario;
        }

        private readonly VentaController _ventaController;
        private readonly ProductoController _productoController;

        private readonly BindingList<LineaCarrito> _carrito = new();
        private List<ProductoViewModel> _productos = new();

        // Índices para encontrar un producto al escanear sin recorrer toda la lista.
        private readonly Dictionary<string, ProductoViewModel> _porCodigoBarras = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<int, ProductoViewModel> _porId = new();

        private bool _guardando;

        public FrmVentaModal(VentaController ventaController, ProductoController productoController)
        {
            _ventaController = ventaController ?? throw new ArgumentNullException(nameof(ventaController));
            _productoController = productoController ?? throw new ArgumentNullException(nameof(productoController));

            InitializeComponent();
            ConfigurarColumnas();

            dgvCarrito.DataSource = _carrito;
            _carrito.ListChanged += (_, _) => ActualizarResumen();
            ActualizarResumen();
        }

        private LineaCarrito? LineaSeleccionada =>
            dgvCarrito.SelectedRows.Count > 0
                ? dgvCarrito.SelectedRows[0].DataBoundItem as LineaCarrito
                : null;

        // ───────────── Carga ─────────────

        private async void FrmVentaModal_Load(object? sender, EventArgs e)
        {
            bool cargado = await FormHelper.EjecutarAsync(async () =>
            {
                var productos = await _productoController.ObtenerProductosAsync(incluirInactivos: false);
                if (IsDisposed) return;

                _productos = productos.ToList();

                _porCodigoBarras.Clear();
                _porId.Clear();
                foreach (var p in _productos)
                {
                    _porId[p.ProductoID] = p;
                    if (!string.IsNullOrWhiteSpace(p.CodigoBarras))
                        _porCodigoBarras.TryAdd(p.CodigoBarras.Trim(), p);
                }

                cmbProductos.DataSource = _productos;
                cmbProductos.DisplayMember = nameof(ProductoViewModel.Nombre);
                cmbProductos.ValueMember = nameof(ProductoViewModel.ProductoID);
                cmbProductos.SelectedIndex = -1;
            },
            "No se pudieron cargar los productos.",
            panelEntrada);

            // Sin productos no se puede vender: se cierra en lugar de dejar una caja inútil.
            if (!cargado && !IsDisposed)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            txtCodigoBarras.Focus();
        }

        private void ConfigurarColumnas()
        {
            dgvCarrito.AutoGenerateColumns = false;

            dgvCarrito.AgregarTexto(nameof(LineaCarrito.Producto), "Producto", 220, 120).SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCarrito.AgregarTexto(nameof(LineaCarrito.Cantidad), "Cant.", 55, 55, alinearDerecha: true).SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCarrito.AgregarTexto(nameof(LineaCarrito.PrecioUnitario), "Precio", 80, 75, "C2", alinearDerecha: true).SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCarrito.AgregarTexto(nameof(LineaCarrito.Subtotal), "Subtotal", 85, 80, "C2", alinearDerecha: true).SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        // ───────────── Agregar productos ─────────────

        private void btnAgregar_Click(object? sender, EventArgs e) => ProcesarAgregarProducto();

        // Enter en el código de barras, en el combo o en la cantidad agrega el producto
        // (el lector de códigos de barras envía Enter al terminar de escanear).
        private void EntradaProducto_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || e.Control) return;

            e.SuppressKeyPress = true; // evita el "beep" de Windows
            ProcesarAgregarProducto();
        }

        private ProductoViewModel? BuscarPorCodigo(string codigo)
        {
            // Primero el código de barras; solo si no existe se intenta como ID interno.
            if (_porCodigoBarras.TryGetValue(codigo, out var porCodigo))
                return porCodigo;

            return int.TryParse(codigo, out int id) && _porId.TryGetValue(id, out var porId)
                ? porId
                : null;
        }

        private void ProcesarAgregarProducto()
        {
            lblAviso.Text = string.Empty;

            ProductoViewModel? producto;
            string codigo = txtCodigoBarras.Text.Trim();

            if (codigo.Length > 0)
            {
                producto = BuscarPorCodigo(codigo);
                if (producto == null)
                {
                    Avisar($"No se encontró ningún producto con el código '{codigo}'.");
                    txtCodigoBarras.SelectAll(); // el siguiente escaneo reemplaza el texto
                    txtCodigoBarras.Focus();
                    return;
                }
            }
            else
            {
                producto = cmbProductos.SelectedItem as ProductoViewModel;
                if (producto == null)
                {
                    Avisar("Escanee un código o seleccione un producto.");
                    txtCodigoBarras.Focus();
                    return;
                }
            }

            int cantidad = (int)numCantidad.Value;
            var linea = _carrito.FirstOrDefault(l => l.ProductoID == producto.ProductoID);
            int yaEnCarrito = linea?.Cantidad ?? 0;
            int stock = Convert.ToInt32(producto.Stock);

            // Aviso rápido en pantalla; la validación definitiva la hace el servidor al registrar la venta.
            if (yaEnCarrito + cantidad > stock)
            {
                Avisar(stock <= 0
                    ? $"'{producto.Nombre}' no tiene existencias."
                    : $"Solo hay {stock} en existencia de '{producto.Nombre}' (ya en el carrito: {yaEnCarrito}).");
                return;
            }

            if (linea != null)
            {
                linea.Cantidad += cantidad;
                _carrito.ResetItem(_carrito.IndexOf(linea));
            }
            else
            {
                linea = new LineaCarrito
                {
                    ProductoID = producto.ProductoID,
                    Producto = producto.Nombre,
                    PrecioUnitario = producto.Precio,
                    Stock = stock,
                    Cantidad = cantidad
                };
                _carrito.Add(linea);
            }

            SeleccionarLinea(linea); // la última línea tocada queda lista para + / -

            // Listo para el siguiente producto.
            txtCodigoBarras.Clear();
            cmbProductos.SelectedIndex = -1;
            numCantidad.Value = 1;
            txtCodigoBarras.Focus();
        }

        private void Avisar(string mensaje)
        {
            lblAviso.Text = mensaje;
            System.Media.SystemSounds.Beep.Play();
        }

        // ───────────── Carrito ─────────────

        private void SeleccionarLinea(LineaCarrito linea)
        {
            int indice = _carrito.IndexOf(linea);
            if (indice < 0) return;

            dgvCarrito.ClearSelection();
            dgvCarrito.Rows[indice].Selected = true;
            dgvCarrito.CurrentCell = dgvCarrito.Rows[indice].Cells[0];
        }

        private void ModificarCantidadSeleccionada(int cambio)
        {
            var linea = LineaSeleccionada;
            if (linea == null) return;

            int nueva = linea.Cantidad + cambio;

            if (nueva > linea.Stock)
            {
                Avisar($"Solo hay {linea.Stock} en existencia de '{linea.Producto}'.");
                return;
            }

            lblAviso.Text = string.Empty;

            if (nueva <= 0)
            {
                QuitarLinea(linea);
                return;
            }

            linea.Cantidad = nueva;
            _carrito.ResetItem(_carrito.IndexOf(linea));
        }

        private void QuitarLinea(LineaCarrito linea)
        {
            int indice = _carrito.IndexOf(linea);
            if (indice < 0) return;

            _carrito.RemoveAt(indice);

            if (_carrito.Count > 0)
                SeleccionarLinea(_carrito[Math.Min(indice, _carrito.Count - 1)]);
        }

        private void btnQuitar_Click(object? sender, EventArgs e)
        {
            var linea = LineaSeleccionada;
            if (linea != null)
                QuitarLinea(linea);
        }

        private void dgvCarrito_SelectionChanged(object? sender, EventArgs e) => ActualizarResumen();

        // Total, y botones que solo tienen sentido con algo en el carrito / seleccionado.
        private void ActualizarResumen()
        {
            lblTotalCalculado.Text = _carrito.Sum(l => l.Subtotal).ToString("C2");
            btnQuitar.Enabled = LineaSeleccionada != null;
            btnGuardar.Enabled = _carrito.Count > 0;
        }

        // Atajos: + / - cambian la cantidad de la línea seleccionada, Supr la quita,
        // Ctrl+Enter completa la venta. Los signos solo actúan con el grid enfocado o con el
        // campo de código vacío, para no interferir cuando se está escribiendo.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                btnGuardar.PerformClick();
                return true;
            }

            bool enCarrito = ActiveControl == dgvCarrito
                             || (ActiveControl == txtCodigoBarras && txtCodigoBarras.TextLength == 0);

            if (enCarrito)
            {
                switch (keyData)
                {
                    case Keys.Add:
                    case Keys.Oemplus:
                    case Keys.Oemplus | Keys.Shift:
                        ModificarCantidadSeleccionada(1);
                        return true;

                    case Keys.Subtract:
                    case Keys.OemMinus:
                        ModificarCantidadSeleccionada(-1);
                        return true;

                    case Keys.Delete when ActiveControl == dgvCarrito:
                        btnQuitar.PerformClick();
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ───────────── Guardar / cerrar ─────────────

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (_guardando) return;

            if (_carrito.Count == 0)
            {
                FormHelper.MostrarAdvertencia("Debe agregar al menos un producto al carrito.", "Validación");
                return;
            }

            var detalles = _carrito.Select(l => new DetalleVentaCreateDto
            {
                ProductoID = l.ProductoID,
                Cantidad = l.Cantidad,
                PrecioUnitario = l.PrecioUnitario
            }).ToList();

            decimal total = _carrito.Sum(l => l.Subtotal);
            int usuarioId = SesionUsuario.UsuarioID; // el cajero real, ya no un 1 fijo
            int? socioId = null;

            _guardando = true;
            bool registrada = await FormHelper.EjecutarAsync(
                () => _ventaController.RegistrarVentaAsync(usuarioId, socioId, total, detalles),
                "No se pudo registrar la venta.",
                btnGuardar, btnCancelar, btnAgregar, btnQuitar, dgvCarrito);
            _guardando = false;

            if (registrada && !IsDisposed)
                DialogResult = DialogResult.OK; // cierra el diálogo; el historial se recarga solo
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // No cerrar mientras se está registrando la venta.
            if (_guardando)
            {
                e.Cancel = true;
            }
            // Evita perder un carrito armado por un Esc o un clic accidental.
            else if (DialogResult != DialogResult.OK
                     && _carrito.Count > 0
                     && !FormHelper.ConfirmarAccion(
                            "Hay productos en el carrito. ¿Desea descartar esta venta?",
                            "Cancelar venta",
                            destructiva: true))
            {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }
    }
}
