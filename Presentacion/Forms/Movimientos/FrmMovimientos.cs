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

namespace Presentacion.Forms.Movimientos
{
    public partial class FrmMovimientos : Form
    {
        private readonly MovimientoController _controller;
        private readonly ConceptoController _conceptoController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<MovimientoViewModel> _vista = new();

        // Rango que se aplicó en la última búsqueda. Al recargar tras editar o eliminar se usa este,
        // no lo que haya en los selectores (el usuario pudo moverlos sin pulsar "Filtrar").
        private DateTime _inicioAplicado = DateTime.Today;
        private DateTime _finAplicado = DateTime.Today.AddDays(1).AddTicks(-1);

        public FrmMovimientos(MovimientoController controller, ConceptoController conceptoController)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _conceptoController = conceptoController ?? throw new ArgumentNullException(nameof(conceptoController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Movimiento de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private MovimientoViewModel? MovimientoSeleccionado =>
            dgvMovimientos.SelectedRows.Count > 0
                ? dgvMovimientos.SelectedRows[0].DataBoundItem as MovimientoViewModel
                : null;

        private static bool EsEgreso(MovimientoViewModel m) =>
            string.Equals(m.Tipo?.Trim(), "Egreso", StringComparison.OrdinalIgnoreCase);

        // Texto para identificar un movimiento en los mensajes (antes se mostraba solo el ID interno).
        private static string Describir(MovimientoViewModel m) => $"{m.Tipo} de {m.Total:C2} ({m.ConceptoNombre})";

        // ───────────── Carga y columnas ─────────────

        private async void FrmMovimientos_Load(object? sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await FiltrarAsync();
        }

        // Las columnas se definen una sola vez. ConceptoID, CorteID, UsuarioID y Activo ya no se ocultan:
        // simplemente no se definen. Total y fechas se enlazan como valores reales para que ordenen bien.
        private void ConfigurarColumnas()
        {
            dgvMovimientos.AutoGenerateColumns = false;

            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.Tipo), "Tipo", 70, 60);
            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.ConceptoNombre), "Concepto", 140, 100);
            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.FormaPago), "Forma de pago", 90, 80);
            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.Total), "Total", 85, 80, "C2", alinearDerecha: true);
            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.Observacion), "Observaciones", 150, 100);
            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.RangoCorteTexto), "Corte", 280, 180);
            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.UsuarioNombre), "Usuario", 100, 90);
            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.Estado), "Estado", 70, 65);
            dgvMovimientos.AgregarTexto(nameof(MovimientoViewModel.CreatedAt), "Fecha de registro", 120, 110, "dd/MM/yyyy hh:mm tt");
        }

        // Lee y valida el rango de los selectores; si es válido lo aplica y busca.
        private async Task FiltrarAsync()
        {
            DateTime desde = dtpFechaInicio.Value.Date;
            DateTime hasta = dtpFechaFin.Value.Date;

            if (desde > hasta)
            {
                FormHelper.MostrarAdvertencia("La fecha inicial no puede ser posterior a la fecha final.", "Rango de fechas");
                return;
            }

            _inicioAplicado = desde;
            _finAplicado = hasta.AddDays(1).AddTicks(-1); // cubre todo el día final

            await CargarMovimientosAsync();
        }

        private async Task CargarMovimientosAsync(int? idASeleccionar = null)
        {
            // Si no se pide otro, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? MovimientoSeleccionado?.MovimientoID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var movimientos = await _controller.ObtenerPorRangoFechasAsync(_inicioAplicado, _finAplicado);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvMovimientos.SortedColumn;
                var sentidoOrden = dgvMovimientos.SortOrder;

                _vista = new ListaOrdenable<MovimientoViewModel>(movimientos);
                dgvMovimientos.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvMovimientos.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                ActualizarResumen();
                SeleccionarMovimiento(idObjetivo);
            },
            "No se pudieron cargar los movimientos.",
            panelTop, panelFiltros);
        }

        // Totales del rango mostrado. Solo cuentan los movimientos activos (los desactivados no afectan la caja).
        private void ActualizarResumen()
        {
            var activos = _vista.Where(m => m.Activo).ToList();

            decimal ingresos = activos.Where(m => !EsEgreso(m)).Sum(m => m.Total);
            decimal egresos = activos.Where(EsEgreso).Sum(m => m.Total);
            decimal balance = ingresos - egresos;

            lblIngresos.Text = $"Ingresos: {ingresos:C2}";
            lblEgresos.Text = $"Egresos: {egresos:C2}";
            lblBalance.Text = $"Balance: {balance:C2}";
            lblBalance.ForeColor = balance >= 0 ? Tema.Exito : Tema.Peligro;
            lblCantidad.Text = $"{_vista.Count} movimiento(s)";
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarMovimiento(int? id)
        {
            dgvMovimientos.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].MovimientoID != id.Value) continue;

                    dgvMovimientos.Rows[i].Selected = true;
                    dgvMovimientos.CurrentCell = dgvMovimientos.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Editar, Activar/Desactivar y Eliminar solo tienen sentido con una fila seleccionada.
        private void ActualizarEstadoBotones()
        {
            var movimiento = MovimientoSeleccionado;
            bool haySeleccion = movimiento != null;

            btnEditar.Enabled = haySeleccion;
            btnDesactivar.Enabled = haySeleccion;
            btnEliminarFisico.Enabled = haySeleccion;

            bool inactivo = movimiento is { Activo: false };
            btnDesactivar.Text = inactivo ? "Activar" : "Desactivar";
            btnDesactivar.Estilo = inactivo ? EstiloBoton.Exito : EstiloBoton.Advertencia;
        }

        private void dgvMovimientos_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Inactivos en gris; Tipo y Total en verde (ingreso) o rojo (egreso); "Activo" en verde.
        private void dgvMovimientos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            var movimiento = _vista[e.RowIndex];

            if (!movimiento.Activo)
            {
                e.CellStyle.ForeColor = Tema.TextoAtenuado;
                return;
            }

            string propiedad = dgvMovimientos.Columns[e.ColumnIndex].DataPropertyName;

            if (propiedad is nameof(MovimientoViewModel.Tipo) or nameof(MovimientoViewModel.Total))
                e.CellStyle.ForeColor = EsEgreso(movimiento) ? Tema.Peligro : Tema.Exito;
            else if (propiedad == nameof(MovimientoViewModel.Estado))
                e.CellStyle.ForeColor = Tema.Exito;
        }

        private async void dgvMovimientos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            await AbrirModalAsync(_vista[e.RowIndex].MovimientoID);
        }

        // ───────────── Filtros ─────────────

        private async void btnFiltrarFechas_Click(object? sender, EventArgs e) => await FiltrarAsync();

        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await FiltrarAsync();
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e) => await AbrirModalAsync(null);

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            var movimiento = MovimientoSeleccionado;
            if (movimiento == null) return; // el botón ya está deshabilitado sin selección; esto es solo defensivo

            await AbrirModalAsync(movimiento.MovimientoID);
        }

        private async Task AbrirModalAsync(int? movimientoId)
        {
            using var modal = new FrmMovimientoModal(_controller, movimientoId, _conceptoController);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarMovimientosAsync(movimientoId); // para uno nuevo (null) se conserva la selección actual
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var movimiento = MovimientoSeleccionado;
            if (movimiento == null) return;

            string accion = movimiento.Activo ? "desactivar" : "activar";

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de {accion} el movimiento: {Describir(movimiento)}?",
                    $"Confirmar {accion.ToUpper()}"))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.CambiarEstadoLogicoAsync(movimiento.MovimientoID),
                "No se pudo cambiar el estado del movimiento.",
                panelTop);

            if (correcto)
                await CargarMovimientosAsync(movimiento.MovimientoID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var movimiento = MovimientoSeleccionado;
            if (movimiento == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE el movimiento: {Describir(movimiento)}?\n\nEsta acción no se puede deshacer.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.EliminarFisicoAsync(movimiento.MovimientoID),
                "No se pudo eliminar el movimiento.",
                panelTop);

            if (correcto)
                await CargarMovimientosAsync();
        }
    }
}
