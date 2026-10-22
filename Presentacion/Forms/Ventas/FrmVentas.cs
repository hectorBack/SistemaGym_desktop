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
    public partial class FrmVentas : Form
    {
        private readonly VentaController _ventaController;
        private readonly ProductoController _productoController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<VentaViewModel> _vista = new();

        public FrmVentas(VentaController ventaController, ProductoController productoController)
        {
            _ventaController = ventaController ?? throw new ArgumentNullException(nameof(ventaController));
            _productoController = productoController ?? throw new ArgumentNullException(nameof(productoController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Venta de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private VentaViewModel? VentaSeleccionada =>
            dgvVentas.SelectedRows.Count > 0
                ? dgvVentas.SelectedRows[0].DataBoundItem as VentaViewModel
                : null;

        // ───────────── Carga y columnas ─────────────

        private async void FrmVentas_Load(object? sender, EventArgs e)
        {
            // El permiso se revisa una sola vez al abrir, no en cada recarga.
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await CargarVentasAsync();
        }

        // Las columnas se definen una sola vez (no en cada recarga).
        // Si no quieres alguna (por ejemplo "Atendió" o "Artículos"), borra su línea.
        private void ConfigurarColumnas()
        {
            dgvVentas.AutoGenerateColumns = false;

            dgvVentas.AgregarTexto(nameof(VentaViewModel.Total), "Total", peso: 60, anchoMinimo: 80, formato: "C2", alinearDerecha: true);
            dgvVentas.AgregarTexto(nameof(VentaViewModel.FechaVenta), "Fecha de registro", peso: 120, anchoMinimo: 130, formato: "dd/MM/yyyy HH:mm");
            dgvVentas.AgregarTexto(nameof(VentaViewModel.Estado), "Estado", peso: 60, anchoMinimo: 80);
        }

        private async Task CargarVentasAsync(int? idASeleccionar = null)
        {
            // Mismo criterio de antes: el rango cubre todo el día "Hasta".
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

            if (inicio > fin)
            {
                FormHelper.MostrarAdvertencia("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango de fechas");
                return;
            }

            // Si no se pide otra, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? VentaSeleccionada?.VentaID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var ventas = await _ventaController.ObtenerPorRangoFechasAsync(inicio, fin);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvVentas.SortedColumn;
                var sentidoOrden = dgvVentas.SortOrder;

                _vista = new ListaOrdenable<VentaViewModel>(ventas);
                dgvVentas.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvVentas.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }
                else
                {
                    // Primera carga: las ventas más recientes arriba.
                    dgvVentas.Sort(dgvVentas.Columns["col" + nameof(VentaViewModel.FechaVenta)]!,
                        ListSortDirection.Descending);
                }

                SeleccionarVenta(idObjetivo);
                ActualizarResumen();
            },
            "No se pudieron cargar las ventas.",
            panelTop, panelFiltros);
        }

        // Resumen del periodo mostrado. Las ventas anuladas no suman al total.
        private void ActualizarResumen()
        {
            var vigentes = _vista.Where(v => v.Activo).ToList();
            int anuladas = _vista.Count - vigentes.Count;

            string texto = $"{vigentes.Count} venta(s)  ·  Total {vigentes.Sum(v => v.Total):C2}";
            if (anuladas > 0)
                texto += $"  ·  {anuladas} anulada(s)";

            lblResumen.Text = texto;
        }

        // ───────────── Filtros ─────────────

        private async void btnFiltrarFechas_Click(object? sender, EventArgs e) => await CargarVentasAsync();

        // "Hoy": vuelve al día actual.
        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await CargarVentasAsync();
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarVenta(int? id)
        {
            dgvVentas.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].VentaID != id.Value) continue;

                    dgvVentas.Rows[i].Selected = true;
                    dgvVentas.CurrentCell = dgvVentas.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Cada botón solo se habilita cuando la acción tiene sentido.
        private void ActualizarEstadoBotones()
        {
            var venta = VentaSeleccionada;

            btnVerDetalle.Enabled = venta != null;
            btnEliminarFisico.Enabled = venta != null;

            bool anulada = venta is { Activo: false };
            btnAnular.Enabled = venta is { Activo: true };
            btnAnular.Text = anulada ? "Anulada" : "Anular";
        }

        private void dgvVentas_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Ventas anuladas en gris (con el estado en rojo); estado de las vigentes en verde.
        private void dgvVentas_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            bool esEstado = dgvVentas.Columns[e.ColumnIndex].DataPropertyName == nameof(VentaViewModel.Estado);

            if (!_vista[e.RowIndex].Activo)
                e.CellStyle.ForeColor = esEstado ? Tema.Peligro : Tema.TextoAtenuado;
            else if (esEstado)
                e.CellStyle.ForeColor = Tema.Exito;
        }

        private async void dgvVentas_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            await MostrarDetalleAsync(_vista[e.RowIndex].VentaID);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevaVenta_Click(object? sender, EventArgs e)
        {
            using var modal = new FrmVentaModal(_ventaController, _productoController);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarVentasAsync();
        }

        private async void btnVerDetalle_Click(object? sender, EventArgs e)
        {
            var venta = VentaSeleccionada;
            if (venta == null) return; // el botón ya está deshabilitado sin selección; esto es solo defensivo

            await MostrarDetalleAsync(venta.VentaID);
        }

        private async Task MostrarDetalleAsync(int ventaId)
        {
            // La consulta se hace con el manejo de errores estándar; el modal se abre DESPUÉS,
            // para que no quede abierto con los controles deshabilitados y el cursor de espera.
            Action? abrirDetalle = null;

            bool consultada = await FormHelper.EjecutarAsync(async () =>
            {
                var ventaDto = await _ventaController.ObtenerPorIdAsync(ventaId);
                if (ventaDto == null) return;

                abrirDetalle = () =>
                {
                    using var modal = new FrmVentaDetalleModal(ventaDto);
                    modal.ShowDialog();
                };
            },
            "No se pudo consultar el detalle de la venta.",
            panelTop, panelFiltros);

            if (IsDisposed || !consultada) return;

            if (abrirDetalle == null)
                FormHelper.MostrarAviso("No se encontró la venta. Es posible que ya haya sido eliminada.");
            else
                abrirDetalle();
        }

        private async void btnAnular_Click(object? sender, EventArgs e)
        {
            var venta = VentaSeleccionada;
            if (venta == null) return;

            if (!venta.Activo)
            {
                FormHelper.MostrarAviso("Esta venta ya se encuentra anulada.");
                return;
            }

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de anular la venta N° {venta.VentaID} por un total de {venta.Total:C2}?\n\nSe reajustará el stock de los productos vendidos.",
                    "Confirmar anulación",
                    destructiva: true))
                return;

            // El usuario se toma de la sesión activa.
            int usuarioId = SesionUsuario.UsuarioID;
            const string motivo = "Anulación de venta desde el módulo de ventas";

            bool correcto = await FormHelper.EjecutarAsync(
                () => _ventaController.AnularVentaAsync(venta.VentaID, usuarioId, motivo),
                "No se pudo anular la venta.",
                panelTop, panelFiltros);

            if (correcto)
                await CargarVentasAsync(venta.VentaID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var venta = VentaSeleccionada;
            if (venta == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE la venta N° {venta.VentaID} de la base de datos?\n\n" +
                    "Esta acción no se puede deshacer. Para corregir una venta normalmente conviene usar 'Anular', que sí reajusta el stock.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _ventaController.EliminarFisicoAsync(venta.VentaID),
                "No se pudo eliminar la venta.",
                panelTop, panelFiltros);

            if (correcto)
                await CargarVentasAsync();
        }
    }
}
