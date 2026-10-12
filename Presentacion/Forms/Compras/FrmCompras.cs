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
    public partial class FrmCompras : Form
    {
        private readonly CompraController _controller;
        private readonly ProductoController _productoController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<CompraViewModel> _vista = new();

        public FrmCompras(CompraController controller, ProductoController productoController)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _productoController = productoController ?? throw new ArgumentNullException(nameof(productoController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Compra de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private CompraViewModel? CompraSeleccionada =>
            dgvCompras.SelectedRows.Count > 0
                ? dgvCompras.SelectedRows[0].DataBoundItem as CompraViewModel
                : null;

        // Una compra está vigente si está activa y no marcada como cancelada.
        private static bool EstaVigente(CompraViewModel c) => c.Activo && c.Estado != "Cancelada";

        // ───────────── Carga y columnas ─────────────

        private async void FrmCompras_Load(object? sender, EventArgs e)
        {
            // El permiso se revisa una sola vez al abrir, no en cada recarga.
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await CargarComprasAsync();
        }

        // Las columnas se definen una sola vez. Antes se generaban solas y se ocultaban 10 por nombre;
        // ahora solo existen las que se muestran (y salen con su formato real, no como texto).
        private void ConfigurarColumnas()
        {
            dgvCompras.AutoGenerateColumns = false;

            dgvCompras.AgregarTexto(nameof(CompraViewModel.Codigo), "Folio", 90, 80);
            dgvCompras.AgregarTexto(nameof(CompraViewModel.CreatedAt), "Fecha de registro", 130, 130, "dd/MM/yyyy HH:mm");
            dgvCompras.AgregarTexto(nameof(CompraViewModel.UsuarioNombre), "Registró", 110, 90);
            dgvCompras.AgregarTexto(nameof(CompraViewModel.Total), "Total", 90, 80, "C2", alinearDerecha: true);
            dgvCompras.AgregarTexto(nameof(CompraViewModel.Estado), "Estado", 80, 80);
        }

        private async Task CargarComprasAsync(int? idASeleccionar = null)
        {
            // El rango cubre todo el día "Hasta".
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

            if (inicio > fin)
            {
                FormHelper.MostrarAdvertencia("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango de fechas");
                return;
            }

            // Si no se pide otra, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? CompraSeleccionada?.CompraID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var compras = await _controller.ObtenerPorRangoFechasAsync(inicio, fin);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvCompras.SortedColumn;
                var sentidoOrden = dgvCompras.SortOrder;

                _vista = new ListaOrdenable<CompraViewModel>(compras);
                dgvCompras.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvCompras.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }
                else
                {
                    // Primera carga: las compras más recientes arriba.
                    dgvCompras.Sort(dgvCompras.Columns["col" + nameof(CompraViewModel.CreatedAt)]!,
                        ListSortDirection.Descending);
                }

                SeleccionarCompra(idObjetivo);
                ActualizarResumen();
            },
            "No se pudieron cargar las compras.",
            panelTop, panelFiltros);
        }

        // Resumen del periodo mostrado. Las compras canceladas no suman al total.
        private void ActualizarResumen()
        {
            var vigentes = _vista.Where(EstaVigente).ToList();
            int canceladas = _vista.Count - vigentes.Count;

            string texto = $"{vigentes.Count} compra(s)  ·  Total {vigentes.Sum(c => c.Total):C2}";
            if (canceladas > 0)
                texto += $"  ·  {canceladas} cancelada(s)";

            lblResumen.Text = texto;
        }

        // ───────────── Filtros ─────────────

        private async void btnFiltrarFechas_Click(object? sender, EventArgs e) => await CargarComprasAsync();

        // "Hoy": vuelve al día actual.
        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await CargarComprasAsync();
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarCompra(int? id)
        {
            dgvCompras.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].CompraID != id.Value) continue;

                    dgvCompras.Rows[i].Selected = true;
                    dgvCompras.CurrentCell = dgvCompras.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Cada botón solo se habilita cuando la acción tiene sentido.
        private void ActualizarEstadoBotones()
        {
            var compra = CompraSeleccionada;

            btnVerDetalle.Enabled = compra != null;
            btnEliminarFisico.Enabled = compra != null;

            bool cancelada = compra != null && !EstaVigente(compra);
            btnCancelarCompra.Enabled = compra != null && !cancelada;
            btnCancelarCompra.Text = cancelada ? "Cancelada" : "Cancelar compra";
        }

        private void dgvCompras_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Compras canceladas en gris (con el estado en rojo); estado de las vigentes en verde.
        private void dgvCompras_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            bool esEstado = dgvCompras.Columns[e.ColumnIndex].DataPropertyName == nameof(CompraViewModel.Estado);

            if (!EstaVigente(_vista[e.RowIndex]))
                e.CellStyle.ForeColor = esEstado ? Tema.Peligro : Tema.TextoAtenuado;
            else if (esEstado)
                e.CellStyle.ForeColor = Tema.Exito;
        }

        private async void dgvCompras_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            await MostrarDetalleAsync(_vista[e.RowIndex]);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e)
        {
            using var modal = new FrmCompraModal(_controller, _productoController);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarComprasAsync();
        }

        private async void btnVerDetalle_Click(object? sender, EventArgs e)
        {
            var compra = CompraSeleccionada;
            if (compra == null) return; // el botón ya está deshabilitado sin selección; esto es solo defensivo

            await MostrarDetalleAsync(compra);
        }

        private async Task MostrarDetalleAsync(CompraViewModel compra)
        {
            // La consulta se hace con el manejo de errores estándar; el modal se abre DESPUÉS,
            // para que no quede abierto con los controles deshabilitados y el cursor de espera.
            Action? abrirDetalle = null;

            bool consultada = await FormHelper.EjecutarAsync(async () =>
            {
                var compraDto = await _controller.ObtenerPorIdAsync(compra.CompraID);
                if (compraDto == null) return;

                abrirDetalle = () =>
                {
                    using var modal = new FrmCompraDetalleModal(compraDto, compra.Codigo);
                    modal.ShowDialog();
                };
            },
            "No se pudo consultar el detalle de la compra.",
            panelTop, panelFiltros);

            if (IsDisposed || !consultada) return;

            if (abrirDetalle == null)
                FormHelper.MostrarAviso("No se encontró la compra. Es posible que ya haya sido eliminada.");
            else
                abrirDetalle();
        }

        private async void btnCancelarCompra_Click(object? sender, EventArgs e)
        {
            var compra = CompraSeleccionada;
            if (compra == null) return;

            if (!EstaVigente(compra))
            {
                FormHelper.MostrarAviso("Esta compra ya se encuentra cancelada.");
                return;
            }

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de cancelar la compra con folio '{compra.Codigo}' por {compra.Total:C2}?\n\n" +
                    "Se reajustará el stock y se registrará la devolución del importe en el corte de caja.",
                    "Confirmar cancelación",
                    destructiva: true))
                return;

            // El usuario se toma de la sesión activa.
            int usuarioId = SesionUsuario.UsuarioID;
            const string motivo = "Cancelado desde módulo de compras";

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.CancelarCompraAsync(compra.CompraID, usuarioId, motivo),
                "No se pudo cancelar la compra.",
                panelTop, panelFiltros);

            if (correcto)
                await CargarComprasAsync(compra.CompraID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var compra = CompraSeleccionada;
            if (compra == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE la compra '{compra.Codigo}' de la base de datos?\n\n" +
                    "Esta acción no se puede deshacer. Para corregir una compra normalmente conviene usar 'Cancelar compra', que sí reajusta el stock y la caja.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.EliminarFisicoAsync(compra.CompraID),
                "No se pudo eliminar la compra.",
                panelTop, panelFiltros);

            if (correcto)
                await CargarComprasAsync();
        }
    }
}
