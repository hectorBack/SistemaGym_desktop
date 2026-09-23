using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.Helpers;
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

        public FrmUsuarioModal(UsuarioController controller, RolController rolController, int? usuarioId = null)
        {
            InitializeComponent();
            _controller = controller;
            _rolController = rolController;
            _usuarioId = usuarioId;
        }

        private async void FrmUsuarioModal_Load(object sender, EventArgs e)
        {
            await CargarRolesAsync();

            if (_usuarioId.HasValue)
            {
                lblTitulo.Text = "Editar Usuario";
                await CargarDatosUsuarioAsync(_usuarioId.Value);
            }
            else
            {
                lblTitulo.Text = "Nuevo Usuario";
            }
        }

        private async Task CargarRolesAsync()
        {
            try
            {
                var roles = await _rolController.ObtenerRolesAsync();
                cboRol.DataSource = roles.ToList();
                cboRol.DisplayMember = "Nombre";
                cboRol.ValueMember = "RolID";
                cboRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDatosUsuarioAsync(int id)
        {
            try
            {
                var usuario = await _controller.ObtenerPorIdAsync(id);
                if (usuario != null)
                {
                    txtNombreUsuario.Text = usuario.NombreUsuario;
                    txtNombreCompleto.Text = usuario.NombreCompleto;
                    cboRol.SelectedValue = usuario.RolID;
                    chkActivo.Checked = usuario.Activo;

                    // Al editar, la contraseña no es obligatoria a menos que se desee cambiar
                    lblPasswordOpcional.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de entrada
            if (ValidationHelper.EsTextoVacio(txtNombreUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return;
            }

            if (ValidationHelper.EsTextoVacio(txtNombreCompleto.Text))
            {
                MessageBox.Show("Debe ingresar el nombre completo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return;
            }

            if (cboRol.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un rol para el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRol.Focus();
                return;
            }

            // Para usuarios nuevos la contraseña es requerida
            if (!_usuarioId.HasValue && ValidationHelper.EsTextoVacio(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña para el nuevo usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                int rolId = Convert.ToInt32(cboRol.SelectedValue);
                string password = txtPassword.Text.Trim();

                await _controller.GuardarUsuarioAsync(
                    _usuarioId,
                    txtNombreUsuario.Text.Trim(),
                    txtNombreCompleto.Text.Trim(),
                    rolId,
                    password,
                    chkActivo.Checked
                );

                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            this.Close(); 
        }
    }
}
