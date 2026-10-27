using Negocio.Interfaces;
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

namespace Presentacion.Forms.Corte
{
    public partial class FrmCortes : Form
    {
        private readonly CorteController _corteController;
        private readonly MovimientoController _movimientoController;
        private readonly ConfiguracionController _configuracionController;
        private readonly IEmailService _emailService;
        private readonly int _usuarioId;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<CorteViewModel> _vista = new();

        // usuarioIdSesion se conserva por compatibilidad con FrmPrincipal, pero ya no hay un "1" de respaldo:
        // si no llega un valor válido se usa el usuario de la sesión activa.
        public FrmCortes(
            CorteController corteController,
            MovimientoController movimientoController,
            ConfiguracionController configuracionController,
            IEmailService emailService,
            int? usuarioIdSesion = null)
        {
            _corteController = corteController ?? throw new ArgumentNullException(nameof(corteController));
            _movimientoController = movimientoController ?? throw new ArgumentNullException(nameof(movimientoController));
            _configuracionController = configuracionController ?? throw new ArgumentNullException(nameof(configuracionController));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _usuarioId = usuarioIdSesion is > 0 ? usuarioIdSesion.Value : SesionUsuario.UsuarioID;

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Corte de la fila seleccionada, o null si no hay ninguno seleccionado.</summary>
        private CorteViewModel? CorteSeleccionado =>
            dgvCortes.SelectedRows.Count > 0
                ? dgvCortes.SelectedRows[0].DataBoundItem as CorteViewModel
                : null;

        // ───────────── Carga y columnas ─────────────

        private async void FrmCortes_Load(object? sender, EventArgs e)
        {
            btnEliminar.Visible = SesionUsuario.TienePermiso("Eliminar");

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await RecargarAsync();
        }

        // Las columnas se definen una sola vez con sus formatos reales.
        private void ConfigurarColumnas()
        {
            dgvCortes.AutoGenerateColumns = false;

            dgvCortes.AgregarTexto(nameof(CorteViewModel.FechaApertura), "Fecha Inicio", 130, 110, "dd/MM/yyyy hh:mm tt");
            dgvCortes.AgregarTexto(nameof(CorteViewModel.FechaCierre), "Fecha Final", 130, 110, "dd/MM/yyyy hh:mm tt");
            dgvCortes.AgregarTexto(nameof(CorteViewModel.TotalIngresos), "Ingresos", 90, 90, "C2", alinearDerecha: true);
            dgvCortes.AgregarTexto(nameof(CorteViewModel.TotalEgresos), "Egresos", 90, 90, "C2", alinearDerecha: true);
            dgvCortes.AgregarTexto(nameof(CorteViewModel.MontoInicial), "Caja Inicial", 90, 90, "C2", alinearDerecha: true);
            dgvCortes.AgregarTexto(nameof(CorteViewModel.MontoFinal), "Caja Final", 90, 90, "C2", alinearDerecha: true);
            dgvCortes.AgregarTexto(nameof(CorteViewModel.Usuario), "Usuario", 110, 120);
            dgvCortes.AgregarTexto(nameof(CorteViewModel.CreatedAt), "Fecha Registro", 130, 110, "dd/MM/yyyy hh:mm tt");
            dgvCortes.AgregarTexto(nameof(CorteViewModel.Observaciones), "Observación", 150, 150);
        }

        // Carga el historial y el efectivo en caja (los dos van siempre juntos).
        private async Task RecargarAsync(int? idASeleccionar = null)
        {
            await CargarCortesAsync(idASeleccionar);
            if (!IsDisposed)
                await ActualizarEfectivoEnCajaAsync();
        }

        private async Task CargarCortesAsync(int? idASeleccionar = null)
        {
            // El rango cubre todo el día "Hasta".
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

            if (inicio > fin)
            {
                FormHelper.MostrarAdvertencia("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango de fechas");
                return;
            }

            // Si no se pide otro, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? CorteSeleccionado?.CorteID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var cortes = await _corteController.ObtenerPorRangoFechasAsync(inicio, fin);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvCortes.SortedColumn;
                var sentidoOrden = dgvCortes.SortOrder;

                _vista = new ListaOrdenable<CorteViewModel>(cortes.ToList());
                dgvCortes.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvCortes.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }
                else
                {
                    // Primera carga: los cortes más recientes arriba.
                    var colFecha = dgvCortes.Columns["col" + nameof(CorteViewModel.CreatedAt)]
                                   ?? dgvCortes.Columns["col" + nameof(CorteViewModel.FechaApertura)];
                    if (colFecha != null)
                        dgvCortes.Sort(colFecha, ListSortDirection.Descending);
                }

                SeleccionarCorte(idObjetivo);
            },
            "No se pudieron cargar los cortes de caja.",
            panelTop, panelFiltros);
        }

        private async Task ActualizarEfectivoEnCajaAsync()
        {
            string texto = "Efectivo en Caja: no disponible";

            await FormHelper.EjecutarAsync(async () =>
            {
                // El servicio ya devuelve el efectivo completo (fondo + movimientos del corte abierto).
                // Antes aquí se le sumaba otra vez el efectivo inicial de la configuración.
                decimal efectivo = await _corteController.ObtenerEfectivoEnCajaAsync();

                texto = $"Efectivo en Caja: {efectivo:C2}";
            },
            "No se pudo consultar el efectivo en caja.");

            if (!IsDisposed)
                lblEfectivoCaja.Text = texto;
        }

        // ───────────── Filtros ─────────────

        private async void btnFiltrar_Click(object? sender, EventArgs e) => await RecargarAsync();

        // "Hoy": vuelve al día actual.
        private async void btnLimpiar_Click(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await RecargarAsync();
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarCorte(int? id)
        {
            dgvCortes.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].CorteID != id.Value) continue;

                    dgvCortes.Rows[i].Selected = true;
                    dgvCortes.CurrentCell = dgvCortes.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            btnVerDetalle.Enabled = CorteSeleccionado != null;
            btnEliminar.Enabled = CorteSeleccionado != null;
            btnExportar.Enabled = _vista.Count > 0;
        }

        private void dgvCortes_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Un corte sin fecha de cierre sigue abierto: se muestra "En proceso" en ámbar.
        private void dgvCortes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle is null) return;

            if (dgvCortes.Columns[e.ColumnIndex].DataPropertyName == nameof(CorteViewModel.FechaCierre) && e.Value == null)
            {
                e.Value = "En proceso";
                e.CellStyle.ForeColor = Tema.Advertencia;
                e.FormattingApplied = true;
            }
        }

        private async void dgvCortes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            await MostrarDetalleAsync(_vista[e.RowIndex]);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e)
        {
            decimal efectivoInicialPredeterminado = 0m;

            // Antes esta consulta no estaba protegida: si fallaba, el error se perdía en un async void.
            bool leida = await FormHelper.EjecutarAsync(async () =>
            {
                var configCaja = await _configuracionController.ObtenerConfigCorteCajaAsync();
                efectivoInicialPredeterminado = configCaja?.EfectivoInicial ?? 0m;
            },
            "No se pudo leer la configuración de caja.",
            panelTop, panelFiltros);

            if (!leida || IsDisposed) return;

            using var modal = new FrmCorteModal(_corteController, _movimientoController, _emailService, efectivoInicialPredeterminado, _usuarioId);

            if (modal.ShowDialog() == DialogResult.OK)
                await RecargarAsync();
        }

        private async void btnVerDetalle_Click(object? sender, EventArgs e)
        {
            var corte = CorteSeleccionado;
            if (corte == null) return;

            await MostrarDetalleAsync(corte);
        }

        private async void btnEliminar_Click(object? sender, EventArgs e)
        {
            var corte = CorteSeleccionado;
            if (corte == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar permanentemente el corte de caja del usuario '{corte.Usuario}' registrado el {corte.FechaApertura:dd/MM/yyyy hh:mm tt}?\n\nEsta acción no se puede deshacer.",
                    "Eliminar corte",
                    destructiva: true))
                return;

            bool eliminado = await FormHelper.EjecutarAsync(
                () => _corteController.EliminarFisicoAsync(corte.CorteID),
                "No se pudo eliminar el corte de caja.",
                panelTop, panelFiltros);

            if (eliminado)
                await RecargarAsync();
        }

        private async Task MostrarDetalleAsync(CorteViewModel corte)
        {
            // La consulta se hace con el manejo de errores estándar; el modal se abre DESPUÉS.
            Action? abrirDetalle = null;

            bool consultada = await FormHelper.EjecutarAsync(async () =>
            {
                var corteDto = await _corteController.ObtenerPorIdAsync(corte.CorteID);
                if (corteDto == null) return;

                abrirDetalle = () =>
                {
                    using var modal = new FrmCorteDetalleModal(corteDto, _movimientoController);
                    modal.ShowDialog();
                };
            },
            "No se pudo consultar el detalle del corte.",
            panelTop, panelFiltros);

            if (IsDisposed || !consultada) return;

            if (abrirDetalle == null)
                FormHelper.MostrarAviso("No se encontró el corte de caja seleccionado.");
            else
                abrirDetalle();
        }

        // Antes este botón mostraba "Exportación realizada con éxito" sin exportar nada.
        // Ahora genera un .csv que Excel abre directamente.
        private void btnExportar_Click(object? sender, EventArgs e)
        {
            if (_vista.Count == 0)
            {
                FormHelper.MostrarAviso("No hay datos disponibles para exportar.");
                return;
            }

            try
            {
                string? ruta = ExportadorCsv.Exportar(dgvCortes, "Cortes_de_Caja");
                if (ruta != null)
                    FormHelper.MostrarAviso($"Archivo guardado en:\n{ruta}", "Exportación completada");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                FormHelper.MostrarError("No se pudo guardar el archivo. Verifique que no esté abierto en Excel y que la carpeta permita escribir.");
            }
        }
    }
}
