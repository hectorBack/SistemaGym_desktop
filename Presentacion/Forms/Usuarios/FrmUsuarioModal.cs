using Negocio.Exceptions;
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
    public partial class FrmUsuarioModal : Form
    {
        private readonly UsuarioController _controller;
        private readonly RolController _rolController;
        private readonly int? _usuarioId;
        private bool _guardando;

        public FrmUsuarioModal(UsuarioController controller, RolController rolController, int? usuarioId = null)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _rolController = rolController ?? throw new ArgumentNullException(nameof(rolController));
            _usuarioId = usuarioId;

            InitializeComponent();

            lblTitulo.Text = _usuarioId.HasValue ? "Editar Usuario" : "Nuevo Usuario";
            lblPasswordOpcional.Visible = _usuarioId.HasValue; // al editar la contraseña solo se cambia si se escribe una

            // No se puede guardar hasta que termine de cargar: si la carga de un usuario existente falla,
            // guardar con el formulario vacío lo sobrescribiría con datos por defecto.
            btnGuardar.Enabled = false;
        }

        // ───────────── Carga ─────────────

        private async void FrmUsuarioModal_Load(object? sender, EventArgs e)
        {
            bool cargado = await FormHelper.EjecutarAsync(
                CargarDatosAsync,
                "No se pudieron cargar los datos del usuario.");

            if (IsDisposed) return;

            // Sin datos no tiene sentido dejar el formulario abierto.
            if (!cargado)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            btnGuardar.Enabled = true;
            txtNombreUsuario.Focus();
        }

        private async Task CargarDatosAsync()
        {
            var usuario = _usuarioId.HasValue
                ? await _controller.ObtenerPorIdAsync(_usuarioId.Value)
                : null;

            if (_usuarioId.HasValue && usuario == null)
                throw new BusinessException("No se encontró el usuario.");

            // Al editar se incluyen los roles inactivos, para no perder el rol actual del usuario
            // si fue desactivado después de asignárselo (antes el combo quedaba vacío).
            var roles = await _rolController.ObtenerRolesAsync(true);
            if (IsDisposed) return;

            var disponibles = roles
                .Where(r => r.Activo || (usuario != null && r.RolID == usuario.RolID))
                .ToList();

            cboRol.DataSource = disponibles;
            cboRol.DisplayMember = nameof(RolViewModel.Nombre);
            cboRol.ValueMember = nameof(RolViewModel.RolID);
            cboRol.SelectedIndex = -1;

            if (usuario == null) return;

            string? rolActual = disponibles.FirstOrDefault(r => r.RolID == usuario.RolID)?.Nombre;
            if (RolesSistema.EsAdministrador(rolActual))
                throw new BusinessException("No se permite editar a un usuario con el rol de Administrador.");

            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtNombreCompleto.Text = usuario.NombreCompleto;
            cboRol.SelectedValue = usuario.RolID;
            chkActivo.Checked = usuario.Activo;

            // Nadie puede desactivarse a sí mismo: se quedaría fuera del sistema.
            if (usuario.UsuarioID == SesionUsuario.UsuarioID)
                chkActivo.Enabled = false;
        }

        // ───────────── Contraseña ─────────────

        private void chkMostrarPassword_CheckedChanged(object? sender, EventArgs e)
        {
            bool ocultar = !chkMostrarPassword.Checked;
            txtPassword.UseSystemPasswordChar = ocultar;
            txtConfirmarPassword.UseSystemPasswordChar = ocultar;
        }

        // ───────────── Guardar ─────────────

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (_guardando) return;

            if (ValidationHelper.EsTextoVacio(txtNombreUsuario.Text))
            {
                FormHelper.MostrarAdvertencia("Debe ingresar un nombre de usuario.", "Validación");
                txtNombreUsuario.Focus();
                return;
            }

            if (ValidationHelper.EsTextoVacio(txtNombreCompleto.Text))
            {
                FormHelper.MostrarAdvertencia("Debe ingresar el nombre completo.", "Validación");
                txtNombreCompleto.Focus();
                return;
            }

            if (cboRol.SelectedItem is not RolViewModel rol)
            {
                FormHelper.MostrarAdvertencia("Debe seleccionar un rol para el usuario.", "Validación");
                cboRol.Focus();
                return;
            }

            // Se conserva el Trim original para seguir siendo coherente con lo que ya hay guardado.
            string password = txtPassword.Text.Trim();

            // Para usuarios nuevos la contraseña es requerida; al editar solo si se quiere cambiar.
            if (!_usuarioId.HasValue && password.Length == 0)
            {
                FormHelper.MostrarAdvertencia("Debe ingresar una contraseña para el nuevo usuario.", "Validación");
                txtPassword.Focus();
                return;
            }

            if (password.Length > 0 && password != txtConfirmarPassword.Text.Trim())
            {
                FormHelper.MostrarAdvertencia("Las contraseñas no coinciden.", "Validación");
                txtConfirmarPassword.Focus();
                return;
            }

            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string nombreCompleto = txtNombreCompleto.Text.Trim();
            bool activo = chkActivo.Checked;

            _guardando = true;
            bool guardado = await FormHelper.EjecutarAsync(
                () => _controller.GuardarUsuarioAsync(
                    _usuarioId, nombreUsuario, nombreCompleto, rol.RolID, password, activo),
                "No se pudo guardar el usuario.",
                btnGuardar, btnCancelar);
            _guardando = false;

            // Sin mensaje de éxito: al cerrarse el diálogo y recargarse la lista, el resultado es evidente.
            if (guardado && !IsDisposed)
                DialogResult = DialogResult.OK;
        }

        // No permitir cerrar la ventana mientras se está guardando.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_guardando)
                e.Cancel = true;

            base.OnFormClosing(e);
        }
    }
}
