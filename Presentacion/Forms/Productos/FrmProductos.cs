using Presentacion.Controller;
using Presentacion.Controls;
using Presentacion.Helpers;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        // Todos los productos traídos de la BD, y la vista filtrada/ordenada que muestra el grid.
        private List<ProductoViewModel> _todos = new();
        private ListaOrdenable<ProductoViewModel> _vista = new();

        public FrmProductos(ProductoController productoController, CategoriaController categoriaController)
        {
            _productoController = productoController ?? throw new ArgumentNullException(nameof(productoController));
            _categoriaController = categoriaController ?? throw new ArgumentNullException(nameof(categoriaController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Producto de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private ProductoViewModel? ProductoSeleccionado =>
            dgvProductos.SelectedRows.Count > 0
                ? dgvProductos.SelectedRows[0].DataBoundItem as ProductoViewModel
                : null;

        // ───────────── Carga y columnas ─────────────

        private async void FrmProductos_Load(object? sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");

            // El foco queda en la búsqueda: un lector de código de barras filtra al instante.
            BeginInvoke(new Action(() => txtBuscar.Focus()));

            await CargarProductosAsync();
        }

        // Las columnas se definen una sola vez (no en cada recarga).
        private void ConfigurarColumnas()
        {
            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.AgregarTexto(nameof(ProductoViewModel.ProductoID), "ID", 45);
            dgvProductos.AgregarTexto(nameof(ProductoViewModel.CodigoBarras), "Código de barras", 100, 110);
            dgvProductos.AgregarTexto(nameof(ProductoViewModel.Nombre), "Producto", 175, 110);
            dgvProductos.AgregarTexto(nameof(ProductoViewModel.CategoriaNombre), "Categoría", 120, 110);
            dgvProductos.AgregarTexto(nameof(ProductoViewModel.Costo), "Costo", 80, 70, "C2", alinearDerecha: true);
            dgvProductos.AgregarTexto(nameof(ProductoViewModel.Precio), "Precio", 80, 70, "C2", alinearDerecha: true);
            dgvProductos.AgregarTexto(nameof(ProductoViewModel.Estado), "Estado", 80, 70);
            dgvProductos.AgregarTexto(nameof(ProductoViewModel.CreatedAt), "Fecha de registro", 120, 100, "dd/MM/yyyy");
        }

        private async Task CargarProductosAsync(int? idASeleccionar = null)
        {
            await FormHelper.EjecutarAsync(async () =>
            {
                var productos = await _productoController.ObtenerProductosAsync(true);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                _todos = productos.ToList();
                AplicarFiltro(idASeleccionar);
            },
            "No se pudieron cargar los productos.",
            panelTop);
        }

        // ───────────── Búsqueda, orden y selección ─────────────

        private void txtBuscar_TextChanged(object? sender, EventArgs e) => AplicarFiltro();

        private void AplicarFiltro(int? idASeleccionar = null)
        {
            // Si no se pide otra, se conserva la selección actual.
            idASeleccionar ??= ProductoSeleccionado?.ProductoID;

            string texto = txtBuscar.Text.Trim();
            IEnumerable<ProductoViewModel> filtrados = texto.Length == 0
                ? _todos
                : _todos.Where(p => Coincide(p.Nombre, texto)
                                 || Coincide(p.CodigoBarras, texto)
                                 || Coincide(p.CategoriaNombre, texto));

            // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
            var columnaOrden = dgvProductos.SortedColumn;
            var sentidoOrden = dgvProductos.SortOrder;

            _vista = new ListaOrdenable<ProductoViewModel>(filtrados);
            dgvProductos.DataSource = _vista;

            if (columnaOrden != null && sentidoOrden != SortOrder.None)
            {
                dgvProductos.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending);
            }

            SeleccionarProducto(idASeleccionar);
            ActualizarResumen();
        }

        // Búsqueda sin distinguir mayúsculas ni acentos: "cafe" encuentra "Café".
        private static bool Coincide(string? valor, string texto) =>
            !string.IsNullOrEmpty(valor)
            && CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                   valor, texto, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0;

        private void SeleccionarProducto(int? id)
        {
            dgvProductos.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].ProductoID != id.Value) continue;

                    dgvProductos.Rows[i].Selected = true;
                    dgvProductos.CurrentCell = dgvProductos.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        private void ActualizarResumen()
        {
            lblConteo.Text = _vista.Count == _todos.Count
                ? Plural(_todos.Count)
                : $"{_vista.Count} de {Plural(_todos.Count)}";
        }

        private static string Plural(int cantidad) => cantidad == 1 ? "1 producto" : $"{cantidad} productos";

        // Editar, Activar/Desactivar y Eliminar solo tienen sentido con una fila seleccionada.
        private void ActualizarEstadoBotones()
        {
            var producto = ProductoSeleccionado;
            bool haySeleccion = producto != null;

            btnEditar.Enabled = haySeleccion;
            btnDesactivar.Enabled = haySeleccion;
            btnEliminarFisico.Enabled = haySeleccion;

            bool inactivo = producto is { Activo: false };
            btnDesactivar.Text = inactivo ? "Activar" : "Desactivar";
            btnDesactivar.Estilo = inactivo ? EstiloBoton.Exito : EstiloBoton.Advertencia;
        }

        private void dgvProductos_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Productos inactivos en gris, y "Activo" en verde.
        private void dgvProductos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            if (!_vista[e.RowIndex].Activo)
            {
                e.CellStyle.ForeColor = Tema.TextoAtenuado;
            }
            else if (dgvProductos.Columns[e.ColumnIndex].DataPropertyName == nameof(ProductoViewModel.Estado))
            {
                e.CellStyle.ForeColor = Tema.Exito;
            }
        }

        private async void dgvProductos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            await AbrirModalAsync(_vista[e.RowIndex].ProductoID);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e) => await AbrirModalAsync(null);

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            var producto = ProductoSeleccionado;
            if (producto == null) return; // el botón ya está deshabilitado sin selección; esto es solo defensivo

            await AbrirModalAsync(producto.ProductoID);
        }

        private async Task AbrirModalAsync(int? productoId)
        {
            using var modal = new FrmProductoModal(_productoController, _categoriaController, productoId);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarProductosAsync(productoId); // para uno nuevo (null) se conserva la selección actual
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var producto = ProductoSeleccionado;
            if (producto == null) return;

            string accion = producto.Activo ? "desactivar" : "activar";

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de {accion} el producto '{producto.Nombre}'?",
                    $"Confirmar {accion.ToUpper()}"))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _productoController.CambiarEstadoLogicoAsync(producto.ProductoID),
                "No se pudo cambiar el estado del producto.",
                panelTop);

            if (correcto)
                await CargarProductosAsync(producto.ProductoID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var producto = ProductoSeleccionado;
            if (producto == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE el producto '{producto.Nombre}' de la base de datos?\n\nEsta acción no se puede deshacer.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _productoController.EliminarFisicoAsync(producto.ProductoID),
                "No se pudo eliminar el producto. Si ya tiene ventas o compras registradas, desactívalo en su lugar.",
                panelTop);

            if (correcto)
                await CargarProductosAsync();
        }
    }
}
