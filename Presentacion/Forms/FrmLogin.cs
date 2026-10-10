using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using Presentacion.Helpers;
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
        private bool _cargando;

        /// <summary>Usuario que inició sesión. Solo tiene valor si el diálogo terminó con DialogResult.OK.</summary>
        public UsuarioDto UsuarioAutenticado { get; private set; }

        public FrmLogin(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text; // sin Trim: los espacios pueden ser parte de la contraseña

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MostrarAviso("Escribe tu usuario.", txtUsuario);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MostrarAviso("Escribe tu contraseña.", txtPassword);
                return;
            }

            UsuarioDto usuarioDto;

            EstablecerEstadoCargando(true);
            try
            {
                var loginRequest = new LoginRequestDto
                {
                    Usuario = usuario,
                    Password = password
                };

                usuarioDto = await _usuarioService.LoginAsync(loginRequest);
            }
            catch (BusinessException ex)
            {
                // Errores controlados de regla de negocio (credenciales incorrectas, usuario inactivo...)
                MessageBox.Show(ex.Message, "No se pudo iniciar sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarPassword();
                return;
            }
            catch (Exception ex)
            {
                // Errores inesperados: conexión a la base de datos, fallas del sistema...
                Debug.WriteLine(ex); // TODO: registrar en archivo cuando exista logging en la aplicación

                string detalle = string.Empty;
#if DEBUG
                detalle = $"\n\nDetalle técnico: {ex.Message}"; // solo visible mientras desarrollas
#endif
                MessageBox.Show(
                    "Ocurrió un error inesperado al iniciar sesión. Verifica la conexión e inténtalo de nuevo." + detalle,
                    "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                // Se libera antes de cerrar el diálogo; si no, OnFormClosing cancelaría el cierre.
                EstablecerEstadoCargando(false);
            }

            CargarSesion(usuarioDto);

            UsuarioAutenticado = usuarioDto;
            DialogResult = DialogResult.OK; // cierra el diálogo; Program.cs abre FrmPrincipal
        }

        // ───────────── Sesión ─────────────

        private static void CargarSesion(UsuarioDto usuario)
        {
            // Clase estática de sesión. A futuro conviene reemplazarla por un servicio inyectable (ISesionActual).
            SesionUsuario.UsuarioID = usuario.UsuarioID;
            SesionUsuario.NombreUsuario = usuario.NombreUsuario;
            SesionUsuario.RolNombre = usuario.RolNombre ?? string.Empty;
            SesionUsuario.ModulosPermitidos = usuario.ModulosPermitidos ?? new List<string>();
        }

        // ───────────── Interfaz ─────────────

        private void EstablecerEstadoCargando(bool cargando)
        {
            _cargando = cargando;

            txtUsuario.Enabled = !cargando;
            txtPassword.Enabled = !cargando;
            chkMostrarPassword.Enabled = !cargando;
            btnLogin.Enabled = !cargando;
            btnCancelar.Enabled = !cargando;
            btnLogin.Text = cargando ? "Ingresando..." : "Ingresar";
            UseWaitCursor = cargando;
        }

        private void MostrarAviso(string mensaje, Control campoAEnfocar)
        {
            MessageBox.Show(mensaje, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            campoAEnfocar.Focus();
        }

        private void LimpiarPassword()
        {
            txtPassword.Clear();
            txtPassword.Focus();
        }

        // No permitir cerrar la ventana mientras se valida el acceso.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_cargando)
                e.Cancel = true;

            base.OnFormClosing(e);
        }

        private void chkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkMostrarPassword.Checked ? '\0' : '*';
        }

        // Aviso de Bloq Mayús mientras se escribe la contraseña.
        private void ActualizarAvisoMayus(object sender, EventArgs e)
        {
            lblAvisoMayus.Visible = IsKeyLocked(Keys.CapsLock);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            lblAvisoMayus.Visible = false;
        }
    }
}
