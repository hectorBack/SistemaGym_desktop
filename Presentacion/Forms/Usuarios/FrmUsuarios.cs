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

namespace Presentacion.Forms.Usuarios
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioController _controller;
        private readonly RolController _rolController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<UsuarioViewModel> _vista = new();

        public FrmUsuarios(UsuarioController controller, RolController rolController)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _rolController = rolController ?? throw new ArgumentNullException(nameof(rolController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Usuario de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private UsuarioViewModel? UsuarioSeleccionado =>
            dgvUsuarios.SelectedRows.Count > 0
                ? dgvUsuarios.SelectedRows[0].DataBoundItem as UsuarioViewModel
                : null;

        private static bool EsUsuarioActual(UsuarioViewModel usuario) => usuario.UsuarioID == SesionUsuario.UsuarioID;

        // ───────────── Carga y columnas ─────────────

        private async void FrmUsuarios_Load(object? sender, EventArgs e)
        {
            // Estaba comentada; con ella, Eliminar queda oculto para quien no tenga el permiso, igual que en los demás módulos.
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            await CargarUsuariosAsync();
        }

        // Las columnas se definen una sola vez. Activo y RolID ya no se ocultan: no se definen.
        private void ConfigurarColumnas()
        {
            dgvUsuarios.AutoGenerateColumns = false;

            dgvUsuarios.AgregarTexto(nameof(UsuarioViewModel.UsuarioID), "ID", 40, 60);
            dgvUsuarios.AgregarTexto(nameof(UsuarioViewModel.NombreUsuario), "Usuario", 110, 90);
            dgvUsuarios.AgregarTexto(nameof(UsuarioViewModel.NombreCompleto), "Nombre", 180, 130);
            dgvUsuarios.AgregarTexto(nameof(UsuarioViewModel.RolNombre), "Rol", 110, 90);
            dgvUsuarios.AgregarTexto(nameof(UsuarioViewModel.Estado), "Estado", 80, 70);
            dgvUsuarios.AgregarTexto(nameof(UsuarioViewModel.CreatedAt), "Fecha de registro", 120, 100, "dd/MM/yyyy");
        }

        private async Task CargarUsuariosAsync(int? idASeleccionar = null)
        {
            // Si no se pide otro, se conserva la selección actual.
            int? idObjetivo = idASeleccionar ?? UsuarioSeleccionado?.UsuarioID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var usuarios = await _controller.ObtenerUsuariosAsync(true);
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvUsuarios.SortedColumn;
                var sentidoOrden = dgvUsuarios.SortOrder;

                _vista = new ListaOrdenable<UsuarioViewModel>(usuarios);
                dgvUsuarios.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvUsuarios.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }

                SeleccionarUsuario(idObjetivo);
            },
            "No se pudieron cargar los usuarios.",
            panelTop);
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarUsuario(int? id)
        {
            dgvUsuarios.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].UsuarioID != id.Value) continue;

                    dgvUsuarios.Rows[i].Selected = true;
                    dgvUsuarios.CurrentCell = dgvUsuarios.Rows[i].Cells[0]; // también hace scroll hasta la fila
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Reglas de protección:
        //  - Un usuario con rol de Administrador no se edita, desactiva ni elimina (regla original).
        //  - Nadie puede desactivarse ni eliminarse a sí mismo (nueva): evita quedarse fuera del sistema.
        private void ActualizarEstadoBotones()
        {
            var usuario = UsuarioSeleccionado;
            bool haySeleccion = usuario != null;
            bool esAdmin = usuario != null && RolesSistema.EsAdministrador(usuario.RolNombre);
            bool esYo = usuario != null && EsUsuarioActual(usuario);

            btnEditar.Enabled = haySeleccion && !esAdmin;
            btnDesactivar.Enabled = haySeleccion && !esAdmin && !esYo;
            btnEliminarFisico.Enabled = haySeleccion && !esAdmin && !esYo;

            bool inactivo = usuario is { Activo: false };
            btnDesactivar.Text = inactivo ? "Activar" : "Desactivar";
            btnDesactivar.Estilo = inactivo ? EstiloBoton.Exito : EstiloBoton.Advertencia;

            if (esAdmin)
                lblNotaProteccion.Text = "Usuario con rol de Administrador: no se puede editar, desactivar ni eliminar.";
            else if (esYo)
                lblNotaProteccion.Text = "Es tu propio usuario: no puedes desactivarlo ni eliminarlo.";

            lblNotaProteccion.Visible = esAdmin || esYo;
        }

        private void dgvUsuarios_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        // Usuarios inactivos en gris, y "Activo" en verde.
        private void dgvUsuarios_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            if (!_vista[e.RowIndex].Activo)
            {
                e.CellStyle.ForeColor = Tema.TextoAtenuado;
            }
            else if (dgvUsuarios.Columns[e.ColumnIndex].DataPropertyName == nameof(UsuarioViewModel.Estado))
            {
                e.CellStyle.ForeColor = Tema.Exito;
            }
        }

        private async void dgvUsuarios_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            var usuario = _vista[e.RowIndex];
            if (RolesSistema.EsAdministrador(usuario.RolNombre)) return; // la nota inferior ya explica por qué

            await AbrirModalAsync(usuario.UsuarioID);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e) => await AbrirModalAsync(null);

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            var usuario = UsuarioSeleccionado;
            if (usuario == null || RolesSistema.EsAdministrador(usuario.RolNombre)) return; // defensivo

            await AbrirModalAsync(usuario.UsuarioID);
        }

        private async Task AbrirModalAsync(int? usuarioId)
        {
            using var modal = new FrmUsuarioModal(_controller, _rolController, usuarioId);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarUsuariosAsync(usuarioId); // para uno nuevo (null) se conserva la selección actual
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var usuario = UsuarioSeleccionado;
            if (usuario == null || RolesSistema.EsAdministrador(usuario.RolNombre) || EsUsuarioActual(usuario)) return;

            string accion = usuario.Activo ? "desactivar" : "activar";

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de {accion} al usuario '{usuario.NombreUsuario}'?",
                    $"Confirmar {accion.ToUpper()}"))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.CambiarEstadoLogicoAsync(usuario.UsuarioID),
                "No se pudo cambiar el estado del usuario.",
                panelTop);

            if (correcto)
                await CargarUsuariosAsync(usuario.UsuarioID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var usuario = UsuarioSeleccionado;
            if (usuario == null || RolesSistema.EsAdministrador(usuario.RolNombre) || EsUsuarioActual(usuario)) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE al usuario '{usuario.NombreUsuario}' de la base de datos?\n\nEsta acción no se puede deshacer.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.EliminarFisicoAsync(usuario.UsuarioID),
                "No se pudo eliminar el usuario. Si ya tiene ventas o movimientos registrados, desactívalo en su lugar.",
                panelTop);

            if (correcto)
                await CargarUsuariosAsync();
        }
    }
}
