using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IServiceProvider _serviceProvider;

        // Constructor para inicio manual desde Program.cs
        public FrmLogin(IUsuarioService usuarioService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
        }

        public FrmLogin(IUsuarioService usuarioService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _serviceProvider = serviceProvider;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Deshabilitar botón durante la petición
                btnLogin.Enabled = false;

                // Armar DTO con los campos del formulario
                var loginRequest = new LoginRequestDto
                {
                    Usuario = txtUsuario.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                };

                // Petición asíncrona al servicio de negocio
                UsuarioDto usuario = await _usuarioService.LoginAsync(loginRequest);

                MessageBox.Show($"¡Bienvenido {usuario.NombreCompleto}!", "Acceso Concedido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario principal enviando la sesión del usuario y el serviceProvider
                FrmPrincipal principal = new FrmPrincipal(usuario, _serviceProvider);
                principal.Show();

                // Ocultar la pantalla de Login
                this.Hide();
            }
            catch (BusinessException ex)
            {
                // Errores controlados de regla de negocio
                MessageBox.Show(ex.Message, "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Errores inesperados de conexión o sistema
                MessageBox.Show($"Ocurrió un error al intentar iniciar sesión: {ex.Message}",
                    "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
