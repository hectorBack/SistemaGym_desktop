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

namespace Presentacion.Forms.Membresias
{
    public partial class FrmMembresias : Form
    {
        private readonly MembresiaController _controller;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<MembresiaViewModel> _vista = new();

        public FrmMembresias(MembresiaController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Membresía de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private MembresiaViewModel? MembresiaSeleccionada =>
            dgvMembresias.SelectedRows.Count > 0
                ? dgvMembresias.SelectedRows[0].DataBoundItem as MembresiaViewModel
                : null;

        // ───────────── Carga y columnas ─────────────

        private async void FrmMembresias_Load(object? sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            await CargarMembresiasAsync();
        }

        // Las columnas se definen una sola vez (no en cada recarga).
        // Precio y duración se enlazan a los valores numéricos (no a texto ya formateado),
        // así ordenan correctamente: 7 días antes que 30, $99 antes que $1,200.
        private void ConfigurarColumnas()
        {
            dgvMembresias.AutoGenerateColumns = false;

            dgvMembresias.AgregarTexto(nameof(MembresiaViewModel.Nombre), "Nombre", 160, 110);
            dgvMembresias.AgregarTexto(nameof(MembresiaViewModel.Precio), "Precio", 90, 80, "C2", alinearDerecha: true);
            dgvMembresias.AgregarTexto(nameof(MembresiaViewModel.Tipo), "Tipo", 90, 80);
            dgvMembresias.AgregarTexto(nameof(MembresiaViewModel.Meses), "Meses", 70, 60, alinearDerecha: true);
            dgvMembresias.AgregarTexto(nameof(MembresiaViewModel.Semanas), "Semanas", 80, 70, alinearDerecha: true);
            dgvMembresias.AgregarTexto(nameof(MembresiaViewModel.Dias), "Dias", 70, 60, alinearDerecha: true);
            dgvMembresias.AgregarTexto(nameof(MembresiaViewModel.CreatedAt), "Fecha de creación", 130, 110, "dd/MM/yyyy hh:mm tt");
            dgvMembresias.AgregarTexto(nameof(MembresiaViewModel.Estado), "Estado", 90, 80);
        }

        private async Task CargarMembresiasAsync(int? idASeleccionar = null)
        {
            // Si no se pide otra, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? MembresiaSeleccionada?.MembresiaID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var membresias = await _controller.ObtenerMembresiasAsync(true);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvMembresias.SortedColumn;
                var sentidoOrden = dgvMembresias.SortOrder;

                _vista = new ListaOrdenable<MembresiaViewModel>(membresias);
                dgvMembresias.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvMembresias.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                SeleccionarMembresia(idObjetivo);
            },
            "No se pudieron cargar las membresías.",
            panelTop);
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarMembresia(int? id)
        {
            dgvMembresias.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].MembresiaID != id.Value) continue;

                    dgvMembresias.Rows[i].Selected = true;
                    dgvMembresias.CurrentCell = dgvMembresias.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Editar, Activar/Desactivar y Eliminar solo tienen sentido con una fila seleccionada.
        private void ActualizarEstadoBotones()
        {
            var membresia = MembresiaSeleccionada;
            bool haySeleccion = membresia != null;

            btnEditar.Enabled = haySeleccion;
            btnDesactivar.Enabled = haySeleccion;
            btnEliminarFisico.Enabled = haySeleccion;

            bool inactiva = membresia is { Activo: false };
            btnDesactivar.Text = inactiva ? "Activar" : "Desactivar";
            btnDesactivar.Estilo = inactiva ? EstiloBoton.Exito : EstiloBoton.Advertencia;
        }

        private void dgvMembresias_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Membresías inactivas en gris, y "Activo" en verde.
        private void dgvMembresias_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            if (!_vista[e.RowIndex].Activo)
            {
                e.CellStyle.ForeColor = Tema.TextoAtenuado;
            }
            else if (dgvMembresias.Columns[e.ColumnIndex].DataPropertyName == nameof(MembresiaViewModel.Estado))
            {
                e.CellStyle.ForeColor = Tema.Exito;
            }
        }

        private async void dgvMembresias_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            await AbrirModalAsync(_vista[e.RowIndex]);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e) => await AbrirModalAsync(null);

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            var membresia = MembresiaSeleccionada;
            if (membresia == null) return; // el botón ya está deshabilitado sin selección; esto es solo defensivo

            await AbrirModalAsync(membresia);
        }

        private async Task AbrirModalAsync(MembresiaViewModel? membresia)
        {
            using var modal = membresia == null
                ? new FrmMembresiaModal(_controller)
                : new FrmMembresiaModal(_controller, membresia.MembresiaID, membresia.Nombre, membresia.Precio, membresia.Tipo, membresia.Meses, membresia.Semanas, membresia.Dias);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarMembresiasAsync(membresia?.MembresiaID);
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var membresia = MembresiaSeleccionada;
            if (membresia == null) return;

            string accion = membresia.Activo ? "desactivar" : "activar";

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de {accion} la membresía '{membresia.Nombre}'?",
                    $"Confirmar {accion.ToUpper()}"))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.CambiarEstadoLogicoAsync(membresia.MembresiaID),
                "No se pudo cambiar el estado de la membresía.",
                panelTop);

            if (correcto)
                await CargarMembresiasAsync(membresia.MembresiaID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var membresia = MembresiaSeleccionada;
            if (membresia == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE la membresía '{membresia.Nombre}' de la base de datos?\n\nEsta acción no se puede deshacer.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.EliminarFisicoAsync(membresia.MembresiaID),
                "No se pudo eliminar la membresía. Si ya tiene socios asociados, desactívala en su lugar.",
                panelTop);

            if (correcto)
                await CargarMembresiasAsync();
        }
    }
}
