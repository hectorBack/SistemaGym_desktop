using Presentacion.Controller;
using Presentacion.Forms.Corte;
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

namespace Presentacion.Forms.Reportes
{
    public partial class FrmVisitasReporte : Form
    {
        /// <summary>Una fila del reporte. El ID viaja en la fila pero no se muestra en el grid.</summary>
        private sealed record FilaVisita(int VisitaID, string Nombre, string FechaRegistro, decimal Monto);

        private readonly ReporteController _reporteController;
        private readonly VisitaController _visitaController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<FilaVisita> _vista = new();

        public FrmVisitasReporte(ReporteController reporteController, VisitaController visitaController)
        {
            _reporteController = reporteController ?? throw new ArgumentNullException(nameof(reporteController));
            _visitaController = visitaController ?? throw new ArgumentNullException(nameof(visitaController));

            InitializeComponent();
            ConfigurarColumnas();

            // Borrar físicamente es irreversible: solo quien tenga el permiso ve el botón.
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
        }

        /// <summary>Visita de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private FilaVisita? VisitaSeleccionada =>
            dgvVisitas.SelectedRows.Count > 0
                ? dgvVisitas.SelectedRows[0].DataBoundItem as FilaVisita
                : null;

        private async void FrmVisitasReporte_Load(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        // Las columnas se definen una sola vez, con su formato real.
        private void ConfigurarColumnas()
        {
            dgvVisitas.AutoGenerateColumns = false;

            dgvVisitas.AgregarTexto(nameof(FilaVisita.Nombre), "Nombre", 200, 140);
            dgvVisitas.AgregarTexto(nameof(FilaVisita.FechaRegistro), "Fecha de Registro", 140, 120);
            dgvVisitas.AgregarTexto(nameof(FilaVisita.Monto), "Precio Visita", 90, 90, "C2", alinearDerecha: true);

            // La fecha llega como texto del reporte: ordenarla alfabéticamente daría un orden engañoso.
            foreach (DataGridViewColumn c in dgvVisitas.Columns)
                if (c.DataPropertyName == nameof(FilaVisita.FechaRegistro))
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private async void btnFiltrar_Click(object? sender, EventArgs e) => await BuscarPorFechasAsync();

        // "Hoy": vuelve al día actual.
        private async void btnLimpiarFiltros_Click(object? sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        private async Task BuscarPorFechasAsync()
        {
            // El rango cubre todo el día "Hasta".
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

            if (inicio > fin)
            {
                FormHelper.MostrarAdvertencia("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango de fechas");
                return;
            }

            // Se conserva la selección actual al recargar.
            int? idObjetivo = VisitaSeleccionada?.VisitaID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var visitas = await _reporteController.ObtenerVisitasAsync(inicio, fin);
                if (IsDisposed) return; // el usuario cambió de pestaña o módulo mientras cargaba

                var filas = visitas.Select(v => new FilaVisita(
                    v.VisitaID,
                    string.IsNullOrWhiteSpace(v.Nombre) ? "N/A" : v.Nombre,
                    v.FechaHoraTexto,
                    v.Monto));

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvVisitas.SortedColumn;
                var sentidoOrden = dgvVisitas.SortOrder;

                _vista = new ListaOrdenable<FilaVisita>(filas);
                dgvVisitas.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvVisitas.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                SeleccionarVisita(idObjetivo);
                ActualizarResumen();
            },
            "No se pudo cargar el reporte de visitas.",
            panelTop, panelFiltros);
        }

        private void SeleccionarVisita(int? id)
        {
            dgvVisitas.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].VisitaID != id.Value) continue;

                    dgvVisitas.Rows[i].Selected = true;
                    dgvVisitas.CurrentCell = dgvVisitas.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        private void ActualizarResumen()
        {
            lblTotal.Text = $"{_vista.Count} visita(s)  ·  Total {_vista.Sum(f => f.Monto):C2}";
            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            btnEliminarFisico.Enabled = VisitaSeleccionada != null;
            btnExportarExcel.Enabled = _vista.Count > 0;
        }

        private void dgvVisitas_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Antes se eliminaba la fila "actual" aunque no se viera seleccionada; ahora solo la seleccionada.
        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var visita = VisitaSeleccionada;
            if (visita == null)
            {
                FormHelper.MostrarAdvertencia("Seleccione una visita de la lista para eliminar.", "Eliminar visita");
                return;
            }

            if (!FormHelper.ConfirmarAccion(
                    $"¿Eliminar definitivamente la visita de \"{visita.Nombre}\" del {visita.FechaRegistro}?\n\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    destructiva: true))
                return;

            bool eliminada = await FormHelper.EjecutarAsync(
                async () => await _visitaController.EliminarFisicoAsync(visita.VisitaID),
                "No se pudo eliminar la visita.",
                panelTop, panelFiltros);

            if (eliminada && !IsDisposed)
                await BuscarPorFechasAsync();
        }

        // Antes este botón mostraba "exportado con éxito" sin exportar nada.
        // Ahora genera un .csv que Excel abre directamente.
        private void btnExportarExcel_Click(object? sender, EventArgs e)
        {
            if (_vista.Count == 0)
            {
                FormHelper.MostrarAviso("No hay datos en la tabla para exportar.");
                return;
            }

            try
            {
                string? ruta = ExportadorCsv.Exportar(dgvVisitas, "Visitas_casuales");
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
