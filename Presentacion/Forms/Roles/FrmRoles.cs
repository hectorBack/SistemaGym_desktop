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

namespace Presentacion.Forms.Roles
{
    public partial class FrmRoles : Form
    {
        private readonly RolController _controller;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<RolViewModel> _vista = new();

        public FrmRoles(RolController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Rol de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private RolViewModel? RolSeleccionado =>
            dgvRoles.SelectedRows.Count > 0
                ? dgvRoles.SelectedRows[0].DataBoundItem as RolViewModel
                : null;

        // ───────────── Carga y columnas ─────────────

        private async void FrmRoles_Load(object? sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            await CargarRolesAsync();
        }

        // Las columnas se definen una sola vez. Activo y ModulosPermitidos ya no se ocultan: no se definen.
        private void ConfigurarColumnas()
        {
            dgvRoles.AutoGenerateColumns = false;

            dgvRoles.AgregarTexto(nameof(RolViewModel.Nombre), "Rol", 100, 100);
            dgvRoles.AgregarTexto(nameof(RolViewModel.Descripcion), "Descripción", 150, 100);
            dgvRoles.AgregarTexto(nameof(RolViewModel.ModulosTexto), "Módulos permitidos", 200, 150);
            dgvRoles.AgregarTexto(nameof(RolViewModel.Estado), "Estado", 70, 65);
            dgvRoles.AgregarTexto(nameof(RolViewModel.CreatedAt), "Fecha de registro", 100, 95, "dd/MM/yyyy");
        }

        private async Task CargarRolesAsync(int? idASeleccionar = null)
        {
            // Si no se pide otro, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? RolSeleccionado?.RolID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var roles = await _controller.ObtenerRolesAsync(true);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvRoles.SortedColumn;
                var sentidoOrden = dgvRoles.SortOrder;

                _vista = new ListaOrdenable<RolViewModel>(roles);
                dgvRoles.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvRoles.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                SeleccionarRol(idObjetivo);
            },
            "No se pudieron cargar los roles.",
            panelTop);
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarRol(int? id)
        {
            dgvRoles.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].RolID != id.Value) continue;

                    dgvRoles.Rows[i].Selected = true;
                    dgvRoles.CurrentCell = dgvRoles.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // El rol de Administrador está protegido: sus botones quedan deshabilitados
        // y una nota explica por qué (antes había que hacer clic para ver el aviso).
        private void ActualizarEstadoBotones()
        {
            var rol = RolSeleccionado;
            bool haySeleccion = rol != null;
            bool protegido = rol != null && RolesSistema.EsAdministrador(rol.Nombre);
            bool modificable = haySeleccion && !protegido;

            btnEditar.Enabled = modificable;
            btnDesactivar.Enabled = modificable;
            btnEliminarFisico.Enabled = modificable;

            bool inactivo = rol is { Activo: false };
            btnDesactivar.Text = inactivo ? "Activar" : "Desactivar";
            btnDesactivar.Estilo = inactivo ? EstiloBoton.Exito : EstiloBoton.Advertencia;

            lblNotaProteccion.Visible = protegido;
        }

        private void dgvRoles_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Roles inactivos en gris, y "Activo" en verde.
        private void dgvRoles_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            if (!_vista[e.RowIndex].Activo)
            {
                e.CellStyle.ForeColor = Tema.TextoAtenuado;
            }
            else if (dgvRoles.Columns[e.ColumnIndex].DataPropertyName == nameof(RolViewModel.Estado))
            {
                e.CellStyle.ForeColor = Tema.Exito;
            }
        }

        private async void dgvRoles_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            var rol = _vista[e.RowIndex];
            if (RolesSistema.EsAdministrador(rol.Nombre)) return; // la nota inferior ya explica por qué

            await AbrirModalAsync(rol.RolID);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e) => await AbrirModalAsync(null);

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            var rol = RolSeleccionado;
            if (rol == null || RolesSistema.EsAdministrador(rol.Nombre)) return; // defensivo: el botón ya está deshabilitado

            await AbrirModalAsync(rol.RolID);
        }

        private async Task AbrirModalAsync(int? rolId)
        {
            using var modal = new FrmRolModal(_controller, rolId);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarRolesAsync(rolId); // para uno nuevo (null) se conserva la selección actual
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var rol = RolSeleccionado;
            if (rol == null || RolesSistema.EsAdministrador(rol.Nombre)) return;

            string accion = rol.Activo ? "desactivar" : "activar";

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de {accion} el rol '{rol.Nombre}'?",
                    $"Confirmar {accion.ToUpper()}"))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.CambiarEstadoLogicoAsync(rol.RolID),
                "No se pudo cambiar el estado del rol.",
                panelTop);

            if (correcto)
                await CargarRolesAsync(rol.RolID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var rol = RolSeleccionado;
            if (rol == null || RolesSistema.EsAdministrador(rol.Nombre)) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE el rol '{rol.Nombre}' de la base de datos?\n\nEsta acción no se puede deshacer.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.EliminarFisicoAsync(rol.RolID),
                "No se pudo eliminar el rol. Si ya tiene usuarios asignados, reasígnelos o desactive el rol en su lugar.",
                panelTop);

            if (correcto)
                await CargarRolesAsync();
        }
    }
}
