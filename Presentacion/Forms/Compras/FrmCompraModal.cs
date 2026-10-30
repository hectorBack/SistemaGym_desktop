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
        /// <summary>Una línea de la compra. Es lo que muestra el grid; al guardar se convierte a DetalleCompraCreateDto.</summary>
        public sealed class LineaCompra
        {
            public int ProductoID { get; init; }
            public string Producto { get; init; } = string.Empty;
            public decimal CostoUnitario { get; init; }
            public int Cantidad { get; set; }
            public decimal Subtotal => Cantidad * CostoUnitario;
        }

        private static readonly string[] FormasPago = { "Efectivo", "Tarjeta", "Otro" };

        private readonly CompraController _compraController;
        private readonly ProductoController _productoController;

        private readonly BindingList<LineaCompra> _lineas = new();
        private List<ProductoViewModel> _productos = new();

        // Índices para encontrar un producto al escanear sin recorrer toda la lista.
        private readonly Dictionary<string, ProductoViewModel> _porCodigoBarras = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<int, ProductoViewModel> _porId = new();

        private bool _guardando;

        public FrmCompraModal(CompraController compraController, ProductoController productoController)
        {
            _compraController = compraController ?? throw new ArgumentNullException(nameof(compraController));
            _productoController = productoController ?? throw new ArgumentNullException(nameof(productoController));

            InitializeComponent();
            ConfigurarColumnas();

            cmbFormaPago.Items.AddRange(FormasPago);
            cmbFormaPago.SelectedIndex = 0; // Efectivo por defecto

            dgvDetalles.DataSource = _lineas;
            _lineas.ListChanged += (_, _) => ActualizarResumen();
            ActualizarResumen();
        }

        private LineaCompra? LineaSeleccionada =>
            dgvDetalles.SelectedRows.Count > 0
                ? dgvDetalles.SelectedRows[0].DataBoundItem as LineaCompra
                : null;

        // ───────────── Carga ─────────────

        private async void FrmCompraModal_Load(object? sender, EventArgs e)
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

            // Sin productos no se puede comprar: se cierra en lugar de dejar una pantalla inútil.
            if (!cargado && !IsDisposed)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            txtCodigoBarras.Focus();
        }

        private void ConfigurarColumnas()
        {
            dgvDetalles.AutoGenerateColumns = false;

            dgvDetalles.AgregarTexto(nameof(LineaCompra.Producto), "Producto", 220, 120).SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetalles.AgregarTexto(nameof(LineaCompra.Cantidad), "Cant.", 55, 55, alinearDerecha: true).SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetalles.AgregarTexto(nameof(LineaCompra.CostoUnitario), "Costo", 80, 75, "C2", alinearDerecha: true).SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetalles.AgregarTexto(nameof(LineaCompra.Subtotal), "Subtotal", 85, 80, "C2", alinearDerecha: true).SortMode = DataGridViewColumnSortMode.NotSortable;
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

        // Al elegir un producto en el combo se muestran su costo y precio de venta registrados.
        private void cmbProductos_SelectedIndexChanged(object? sender, EventArgs e)
        {
            lblInfoProducto.Text = cmbProductos.SelectedItem is ProductoViewModel p
                ? $"Costo registrado: {p.Costo:C2}   ·   Precio de venta: {p.Precio:C2}"
                : string.Empty;
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

        // Lee la cantidad desde el texto del control: dentro de un KeyDown (Enter) el .Value
        // todavía puede traer el número anterior si el usuario aún no ha salido del campo.
        private int CantidadIngresada()
        {
            if (int.TryParse(numCantidad.Text.Trim(), out int cantidad))
                return Math.Clamp(cantidad, (int)numCantidad.Minimum, (int)numCantidad.Maximum);

            return (int)numCantidad.Value;
        }

        private void ReiniciarCantidad()
        {
            numCantidad.Value = 1;
            numCantidad.Text = "1"; // por si el texto tecleado no había llegado a Value
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

            // La compra usa el costo registrado del producto; sin costo el total saldría mal.
            if (producto.Costo <= 0)
            {
                Avisar($"'{producto.Nombre}' no tiene costo registrado. Capture su costo en el módulo de Productos.");
                return;
            }

            int cantidad = CantidadIngresada();
            var linea = _lineas.FirstOrDefault(l => l.ProductoID == producto.ProductoID);

            if (linea != null)
            {
                linea.Cantidad += cantidad;
                _lineas.ResetItem(_lineas.IndexOf(linea));
            }
            else
            {
                linea = new LineaCompra
                {
                    ProductoID = producto.ProductoID,
                    Producto = producto.Nombre,
                    CostoUnitario = producto.Costo,
                    Cantidad = cantidad
                };
                _lineas.Add(linea);
            }

            SeleccionarLinea(linea); // la última línea tocada queda lista para + / -

            SonidoHelper.ReproducirEscaner();

            // Listo para el siguiente producto.
            txtCodigoBarras.Clear();
            cmbProductos.SelectedIndex = -1;
            ReiniciarCantidad();
            lblInfoProducto.Text = $"Agregado: {producto.Nombre} × {cantidad}";
            txtCodigoBarras.Focus();
        }

        private void Avisar(string mensaje)
        {
            lblAviso.Text = mensaje;
            System.Media.SystemSounds.Beep.Play();
        }

        // ───────────── Detalle de la compra ─────────────

        private void SeleccionarLinea(LineaCompra linea)
        {
            int indice = _lineas.IndexOf(linea);
            if (indice < 0) return;

            dgvDetalles.ClearSelection();
            dgvDetalles.Rows[indice].Selected = true;
            dgvDetalles.CurrentCell = dgvDetalles.Rows[indice].Cells[0];
        }

        private void ModificarCantidadSeleccionada(int cambio)
        {
            var linea = LineaSeleccionada;
            if (linea == null) return;

            int nueva = linea.Cantidad + cambio;
            if (nueva > (int)numCantidad.Maximum)
            {
                Avisar($"La cantidad máxima por producto es {(int)numCantidad.Maximum}.");
                return;
            }

            lblAviso.Text = string.Empty;

            if (nueva <= 0)
            {
                QuitarLinea(linea);
                return;
            }

            linea.Cantidad = nueva;
            _lineas.ResetItem(_lineas.IndexOf(linea));
        }

        private void QuitarLinea(LineaCompra linea)
        {
            int indice = _lineas.IndexOf(linea);
            if (indice < 0) return;

            _lineas.RemoveAt(indice);

            if (_lineas.Count > 0)
                SeleccionarLinea(_lineas[Math.Min(indice, _lineas.Count - 1)]);
        }

        private void btnQuitar_Click(object? sender, EventArgs e)
        {
            var linea = LineaSeleccionada;
            if (linea != null)
                QuitarLinea(linea);
        }

        private void dgvDetalles_SelectionChanged(object? sender, EventArgs e) => ActualizarResumen();

        // Total, y botones que solo tienen sentido con algo en la lista / seleccionado.
        private void ActualizarResumen()
        {
            lblTotalCalculado.Text = _lineas.Sum(l => l.Subtotal).ToString("C2");
            btnQuitar.Enabled = LineaSeleccionada != null;
            btnGuardar.Enabled = _lineas.Count > 0;
        }

        // Atajos: + / - cambian la cantidad de la línea seleccionada, Supr la quita,
        // Ctrl+Enter registra la compra. Los signos solo actúan con el grid enfocado o con el
        // campo de código vacío, para no interferir cuando se está escribiendo.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                btnGuardar.PerformClick();
                return true;
            }

            bool enLista = ActiveControl == dgvDetalles
                           || (ActiveControl == txtCodigoBarras && txtCodigoBarras.TextLength == 0);

            if (enLista)
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

                    case Keys.Delete when ActiveControl == dgvDetalles:
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

            if (_lineas.Count == 0)
            {
                FormHelper.MostrarAdvertencia("Debe agregar al menos un producto a la compra.", "Validación");
                return;
            }

            var detalles = _lineas.Select(l => new DetalleCompraCreateDto
            {
                ProductoID = l.ProductoID,
                Cantidad = l.Cantidad,
                CostoUnitario = l.CostoUnitario
            }).ToList();

            string formaPago = cmbFormaPago.SelectedItem?.ToString() ?? "Efectivo";
            int usuarioId = SesionUsuario.UsuarioID;

            _guardando = true;
            bool registrada = await FormHelper.EjecutarAsync(async () =>
            {
                // El folio se pide justo antes de guardar para que sea lo más actual posible.
                string codigo = await _compraController.ObtenerSiguienteCodigoAsync();

                await _compraController.CrearCompraAsync(new CompraCreateDto
                {
                    Codigo = codigo,
                    Observacion = string.Empty,
                    FormaPago = formaPago,
                    UsuarioID = usuarioId,
                    Detalles = detalles
                });
            },
            "No se pudo registrar la compra.",
            btnGuardar, btnCancelar, btnAgregar, btnQuitar, dgvDetalles, cmbFormaPago);
            _guardando = false;

            if (registrada && !IsDisposed)
                DialogResult = DialogResult.OK; // cierra el diálogo; el historial se recarga solo
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // No cerrar mientras se está registrando la compra.
            if (_guardando)
            {
                e.Cancel = true;
            }
            // Evita perder una compra armada por un Esc o un clic accidental.
            else if (DialogResult != DialogResult.OK
                     && _lineas.Count > 0
                     && !FormHelper.ConfirmarAccion(
                            "Hay productos en la compra. ¿Desea descartarla?",
                            "Cancelar compra",
                            destructiva: true))
            {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }
    }
}
