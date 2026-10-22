using Negocio.Exceptions;
using Presentacion.Controls;
using Presentacion.Forms.Categorias;
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

namespace Presentacion.Forms
{
    public partial class FrmCategorias : Form
    {
        private readonly CategoriaController _controller;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<CategoriaViewModel> _vista = new();

        public FrmCategorias(CategoriaController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Categoría de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private CategoriaViewModel? CategoriaSeleccionada =>
            dgvCategorias.SelectedRows.Count > 0
                ? dgvCategorias.SelectedRows[0].DataBoundItem as CategoriaViewModel
                : null;

        // ───────────── Carga y columnas ─────────────

        private async void FrmCategorias_Load(object? sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            await CargarCategoriasAsync();
        }

        // Las columnas se definen una sola vez (no en cada recarga).
        private void ConfigurarColumnas()
        {
            dgvCategorias.AutoGenerateColumns = false;

            dgvCategorias.AgregarTexto(nameof(CategoriaViewModel.Nombre), "Categoría", 200, 120);
            dgvCategorias.AgregarTexto(nameof(CategoriaViewModel.Estado), "Estado", 80, 70);
            dgvCategorias.AgregarTexto(nameof(CategoriaViewModel.CreatedAt), "Fecha de registro", 120, 100, "dd/MM/yyyy");
        }

        private async Task CargarCategoriasAsync(int? idASeleccionar = null)
        {
            // Si no se pide otra, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? CategoriaSeleccionada?.CategoriaID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var categorias = await _controller.ObtenerCategoriasAsync(true);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvCategorias.SortedColumn;
                var sentidoOrden = dgvCategorias.SortOrder;

                _vista = new ListaOrdenable<CategoriaViewModel>(categorias);
                dgvCategorias.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvCategorias.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                SeleccionarCategoria(idObjetivo);
            },
            "No se pudieron cargar las categorías.",
            panelTop);
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarCategoria(int? id)
        {
            dgvCategorias.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].CategoriaID != id.Value) continue;

                    dgvCategorias.Rows[i].Selected = true;
                    dgvCategorias.CurrentCell = dgvCategorias.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Editar, Activar/Desactivar y Eliminar solo tienen sentido con una fila seleccionada.
        private void ActualizarEstadoBotones()
        {
            var categoria = CategoriaSeleccionada;
            bool haySeleccion = categoria != null;

            btnEditar.Enabled = haySeleccion;
            btnDesactivar.Enabled = haySeleccion;
            btnEliminarFisico.Enabled = haySeleccion;

            bool inactiva = categoria is { Activo: false };
            btnDesactivar.Text = inactiva ? "Activar" : "Desactivar";
            btnDesactivar.Estilo = inactiva ? EstiloBoton.Exito : EstiloBoton.Advertencia;
        }

        private void dgvCategorias_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Categorías inactivas en gris, y "Activo" en verde.
        private void dgvCategorias_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            if (!_vista[e.RowIndex].Activo)
            {
                e.CellStyle.ForeColor = Tema.TextoAtenuado;
            }
            else if (dgvCategorias.Columns[e.ColumnIndex].DataPropertyName == nameof(CategoriaViewModel.Estado))
            {
                e.CellStyle.ForeColor = Tema.Exito;
            }
        }

        private async void dgvCategorias_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            var categoria = _vista[e.RowIndex];
            await AbrirModalAsync(categoria.CategoriaID, categoria.Nombre);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e) => await AbrirModalAsync(null, string.Empty);

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            var categoria = CategoriaSeleccionada;
            if (categoria == null) return; // el botón ya está deshabilitado sin selección; esto es solo defensivo

            await AbrirModalAsync(categoria.CategoriaID, categoria.Nombre);
        }

        private async Task AbrirModalAsync(int? categoriaId, string nombreActual)
        {
            using var modal = new FrmCategoriaModal(_controller, categoriaId, nombreActual);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarCategoriasAsync(categoriaId); // para una nueva (null) se conserva la selección actual
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var categoria = CategoriaSeleccionada;
            if (categoria == null) return;

            string accion = categoria.Activo ? "desactivar" : "activar";

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de {accion} la categoría '{categoria.Nombre}'?",
                    $"Confirmar {accion.ToUpper()}"))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.CambiarEstadoLogicoAsync(categoria.CategoriaID),
                "No se pudo cambiar el estado de la categoría.",
                panelTop);

            if (correcto)
                await CargarCategoriasAsync(categoria.CategoriaID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var categoria = CategoriaSeleccionada;
            if (categoria == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE la categoría '{categoria.Nombre}' de la base de datos?\n\nEsta acción no se puede deshacer.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.EliminarFisicoAsync(categoria.CategoriaID),
                "No se pudo eliminar la categoría. Si ya tiene productos asociados, desactívala en su lugar.",
                panelTop);

            if (correcto)
                await CargarCategoriasAsync();
        }
    }
}
