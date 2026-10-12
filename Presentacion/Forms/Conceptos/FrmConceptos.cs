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

namespace Presentacion.Forms.Conceptos
{
    public partial class FrmConceptos : Form
    {
        private readonly ConceptoController _controller;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<ConceptoViewModel> _vista = new();

        public FrmConceptos(ConceptoController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Concepto de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private ConceptoViewModel? ConceptoSeleccionado =>
            dgvConceptos.SelectedRows.Count > 0
                ? dgvConceptos.SelectedRows[0].DataBoundItem as ConceptoViewModel
                : null;

        // La regla de "concepto del sistema" estaba copiada en tres métodos; ahora vive en un solo lugar.
        // Si tu ConceptoViewModel ya trae la propiedad EsSistema, añádela aquí con ||.
        private static bool EsConceptoDeSistema(ConceptoViewModel concepto) =>
            concepto.ConceptoID <= 8
            || (concepto.Observacion?.Contains("No se puede modificar", StringComparison.OrdinalIgnoreCase) ?? false);

        // ───────────── Carga y columnas ─────────────

        private async void FrmConceptos_Load(object? sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            await CargarConceptosAsync();
        }

        // Las columnas se definen una sola vez (no en cada recarga).
        // Activo y EsSistema ya no se ocultan: simplemente no se definen.
        private void ConfigurarColumnas()
        {
            dgvConceptos.AutoGenerateColumns = false;

            dgvConceptos.AgregarTexto(nameof(ConceptoViewModel.ConceptoID), "ID", 45);
            dgvConceptos.AgregarTexto(nameof(ConceptoViewModel.Nombre), "Nombre", 150, 100);
            dgvConceptos.AgregarTexto(nameof(ConceptoViewModel.Tipo), "Tipo", 100, 80);
            dgvConceptos.AgregarTexto(nameof(ConceptoViewModel.Observacion), "Observación", 200, 120);
            dgvConceptos.AgregarTexto(nameof(ConceptoViewModel.Estado), "Estado", 80, 70);
            dgvConceptos.AgregarTexto(nameof(ConceptoViewModel.CreatedAt), "Fecha de registro", 120, 100, "dd/MM/yyyy");
        }

        private async Task CargarConceptosAsync(int? idASeleccionar = null)
        {
            // Si no se pide otro, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? ConceptoSeleccionado?.ConceptoID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var conceptos = await _controller.ObtenerConceptosAsync(true);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvConceptos.SortedColumn;
                var sentidoOrden = dgvConceptos.SortOrder;

                _vista = new ListaOrdenable<ConceptoViewModel>(conceptos);
                dgvConceptos.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvConceptos.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                SeleccionarConcepto(idObjetivo);
            },
            "No se pudieron cargar los conceptos.",
            panelTop);
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarConcepto(int? id)
        {
            dgvConceptos.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].ConceptoID != id.Value) continue;

                    dgvConceptos.Rows[i].Selected = true;
                    dgvConceptos.CurrentCell = dgvConceptos.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Los botones solo se habilitan cuando la acción es posible; ya no hace falta
        // hacer clic para descubrir con un mensaje que un concepto del sistema está protegido.
        private void ActualizarEstadoBotones()
        {
            var concepto = ConceptoSeleccionado;
            bool haySeleccion = concepto != null;
            bool protegido = concepto != null && EsConceptoDeSistema(concepto);
            bool modificable = haySeleccion && !protegido;

            btnEditar.Enabled = modificable;
            btnDesactivar.Enabled = modificable;
            btnEliminarFisico.Enabled = modificable;

            bool inactivo = concepto is { Activo: false };
            btnDesactivar.Text = inactivo ? "Activar" : "Desactivar";
            btnDesactivar.Estilo = inactivo ? EstiloBoton.Exito : EstiloBoton.Advertencia;

            lblNotaSistema.Visible = protegido;
        }

        private void dgvConceptos_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Inactivos en gris; Ingreso en verde, Egreso en rojo y "Activo" en verde.
        private void dgvConceptos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            var concepto = _vista[e.RowIndex];

            if (!concepto.Activo)
            {
                e.CellStyle.ForeColor = Tema.TextoAtenuado;
                return;
            }

            string propiedad = dgvConceptos.Columns[e.ColumnIndex].DataPropertyName;

            if (propiedad == nameof(ConceptoViewModel.Estado))
            {
                e.CellStyle.ForeColor = Tema.Exito;
            }
            else if (propiedad == nameof(ConceptoViewModel.Tipo))
            {
                e.CellStyle.ForeColor = string.Equals(concepto.Tipo, "Egreso", StringComparison.OrdinalIgnoreCase)
                    ? Tema.Peligro
                    : Tema.Exito;
            }
        }

        private async void dgvConceptos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            var concepto = _vista[e.RowIndex];
            if (EsConceptoDeSistema(concepto)) return; // la nota inferior ya explica por qué no se edita

            await AbrirModalAsync(concepto);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e) => await AbrirModalAsync(null);

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            var concepto = ConceptoSeleccionado;
            if (concepto == null || EsConceptoDeSistema(concepto)) return; // defensivo: el botón ya está deshabilitado

            await AbrirModalAsync(concepto);
        }

        private async Task AbrirModalAsync(ConceptoViewModel? concepto)
        {
            using var modal = concepto == null
                ? new FrmConceptoModal(_controller)
                : new FrmConceptoModal(_controller, concepto.ConceptoID, concepto.Nombre, concepto.Tipo, concepto.Observacion);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarConceptosAsync(concepto?.ConceptoID); // para uno nuevo (null) se conserva la selección actual
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var concepto = ConceptoSeleccionado;
            if (concepto == null || EsConceptoDeSistema(concepto)) return;

            string accion = concepto.Activo ? "desactivar" : "activar";

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de {accion} el concepto '{concepto.Nombre}'?",
                    $"Confirmar {accion.ToUpper()}"))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.CambiarEstadoLogicoAsync(concepto.ConceptoID),
                "No se pudo cambiar el estado del concepto.",
                panelTop);

            if (correcto)
                await CargarConceptosAsync(concepto.ConceptoID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var concepto = ConceptoSeleccionado;
            if (concepto == null || EsConceptoDeSistema(concepto)) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE el concepto '{concepto.Nombre}' de la base de datos?\n\nEsta acción no se puede deshacer.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.EliminarFisicoAsync(concepto.ConceptoID),
                "No se pudo eliminar el concepto. Si ya tiene movimientos asociados, desactívalo en su lugar.",
                panelTop);

            if (correcto)
                await CargarConceptosAsync();
        }
    }
}
