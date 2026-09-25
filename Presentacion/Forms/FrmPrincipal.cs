using Microsoft.Extensions.DependencyInjection;
using Negocio.DTOs;
using Presentacion.Forms.Productos;
using Presentacion.Forms.Ventas;
using Presentacion.Forms.Membresias;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Forms.Socios;
using Presentacion.Forms.Visitas;
using Presentacion.Forms.Conceptos;
using Presentacion.Forms.Movimientos;
using Presentacion.Forms.Roles;
using Presentacion.Forms.Usuarios;

namespace Presentacion.Forms
{
    public partial class FrmPrincipal : Form
    {
        private readonly UsuarioDto _usuarioSesion;
        private readonly IServiceProvider _serviceProvider;
        private Form _formularioActivo = null;

        // Constructor por defecto
        public FrmPrincipal()
        {
            InitializeComponent();
            ConfigurarFormularioPrincipal();
        }

        // Constructor que recibe la sesión del usuario logueado
        public FrmPrincipal(UsuarioDto usuario, IServiceProvider serviceProvider = null)
        {
            InitializeComponent();
            _usuarioSesion = usuario;
            _serviceProvider = serviceProvider;

            ConfigurarFormularioPrincipal();

            if (_usuarioSesion != null)
            {
                this.Text = $"Sistema Gimnasio - Usuario: {_usuarioSesion.NombreCompleto} ({_usuarioSesion.RolNombre})";

                // APLICAR PERMISOS DE ROL
                AplicarPermisosDeRol();
            }
        }

        private void ConfigurarFormularioPrincipal()
        {
            // Forzar a que la ventana principal abra siempre en pantalla completa
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            ConfigurarIconosMenu();
        }

        private void ConfigurarIconosMenu()
        {
            ConfigurarBotonMenu(btnProductos, IconChar.Box, "Productos");
            ConfigurarBotonMenu(btnCategorias, IconChar.Tags, "Categorías");
            ConfigurarBotonMenu(btnVentas, IconChar.ShoppingCart, "Ventas");
            ConfigurarBotonMenu(btnMembresias, IconChar.IdCard, "Membresías");
            ConfigurarBotonMenu(btnSocios, IconChar.Users, "Socios");
            ConfigurarBotonMenu(btnVisitas, IconChar.ClipboardList, "Visitas");
            ConfigurarBotonMenu(btnRegistrarVisita, IconChar.UserCheck, "Registrar Visita");
            ConfigurarBotonMenu(btnConceptos, IconChar.FileInvoice, "Conceptos");
            ConfigurarBotonMenu(btnMovimientos, IconChar.ChartLine, "Movimientos");
            ConfigurarBotonMenu(btnRoles, IconChar.UserShield, "Roles");
            ConfigurarBotonMenu(btnUsuarios, IconChar.UserGear, "Usuarios");
        }

        private void ConfigurarBotonMenu(IconButton btn, IconChar icon, string texto)
        {
            if (btn == null) return;

            btn.IconChar = icon;
            btn.IconColor = Color.FromArgb(230, 238, 252);
            btn.IconSize = 26;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Text = $"  {texto}";
            btn.Padding = new Padding(15, 0, 0, 0);
        }

        private void AplicarPermisosDeRol()
        {
            // Se obtiene la lista de módulos del rol (o una lista vacía si viene nula)
            List<string> modulosPermitidos = _usuarioSesion?.ModulosPermitidos ?? new List<string>();

            // Configurar la visibilidad de cada botón del menú
            // Ajusta los nombres de los botones y de los módulos según tu base de datos / FrmRolModal
            if (btnUsuarios != null) btnUsuarios.Visible = modulosPermitidos.Contains("Usuarios");
            if (btnRoles != null) btnRoles.Visible = modulosPermitidos.Contains("Roles");
            if (btnSocios != null) btnSocios.Visible = modulosPermitidos.Contains("Socios");
            if (btnMembresias != null) btnMembresias.Visible = modulosPermitidos.Contains("Membresias");
            if (btnProductos != null) btnProductos.Visible = modulosPermitidos.Contains("Productos");
            if (btnVentas != null) btnVentas.Visible = modulosPermitidos.Contains("Ventas");
            if (btnCategorias != null) btnCategorias.Visible = modulosPermitidos.Contains("Productos");
            if (btnVisitas != null) btnVisitas.Visible = modulosPermitidos.Contains("Registro");
            if (btnRegistrarVisita != null) btnRegistrarVisita.Visible = modulosPermitidos.Contains("Registro");
            if (btnConceptos != null) btnConceptos.Visible = modulosPermitidos.Contains("Conceptos");
            if (btnMovimientos != null) btnMovimientos.Visible = modulosPermitidos.Contains("Movimientos");
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmCategorias>();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmProductos>();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmVentas>();
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmMembresias>();
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmSocios>();
        }

        private void btnVisitas_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmVisitas>();
        }

        private void btnRegistrarVisita_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmRegistroVisita>();
        }

        private void btnConceptos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmConceptos>();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmMovimientos>();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmRoles>();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnContenedor<FrmUsuarios>();
        }

        private void btnUsuarioMenu_Click(object sender, EventArgs e)
        {
            // Si hay un usuario activo, habilitamos Cerrar Sesión y deshabilitamos Iniciar Sesión (o viceversa)
            bool haySesionActiva = _usuarioSesion != null;

            itemCerrarSesion.Enabled = haySesionActiva;
            itemIniciarSesion.Enabled = !haySesionActiva;

            // Cambiar el texto del botón para mostrar el nombre del usuario logueado
            if (haySesionActiva)
            {
                btnUsuarioMenu.Text = $"{_usuarioSesion.NombreCompleto} ▾";
            }
            else
            {
                btnUsuarioMenu.Text = "Invitado ▾";
            }

            // Desplegar el menú debajo del botón
            menuUsuario.Show(btnUsuarioMenu, new Point(0, btnUsuarioMenu.Height));
        }

        private void itemIniciarSesion_Click(object sender, EventArgs e)
        {
            // Si ya hay un usuario logueado, advertir que se cerrará la sesión actual para iniciar con otra cuenta
            if (_usuarioSesion != null)
            {
                var resultado = MessageBox.Show(
                    "Ya hay una sesión activa. ¿Desea cerrar la sesión actual para iniciar con otro usuario?",
                    "Iniciar nueva sesión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    EjecutarCierreDeSesion();
                }
            }
            else
            {
                // Si no había usuario activo
                EjecutarCierreDeSesion();
            }
        }

        private void itemCerrarSesion_Click(object sender, EventArgs e)
        {
            // Confirmación opcional antes de cerrar sesión
            var resultado = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión actual?",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                EjecutarCierreDeSesion();
            }
        }

        private void EjecutarCierreDeSesion()
        {
            if (_serviceProvider == null)
            {
                throw new InvalidOperationException(
                    "No se puede cerrar la sesión porque el proveedor de servicios (IServiceProvider) es nulo."
                );
            }

            // Resolvemos la instancia de FrmLogin con sus dependencias requeridas usando Inyección de Dependencias
            FrmLogin frmLogin = Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance<FrmLogin>(_serviceProvider);

            // Mostrar la pantalla de Login
            frmLogin.Show();

            // Limpiar o cerrar la ventana principal
            this.Close(); // O este.Hide() según la gestión de ciclo de vida de tu aplicación
        }

        /// <summary>
        /// Método genérico para abrir formularios internos incrustados dentro de panelContenedor.
        /// </summary>
        private void AbrirFormularioEnContenedor<TForm>() where TForm : Form
        {
            // Cierra el formulario activo previo
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
            }

            // Instanciación resuelta por inyección de dependencias
            if (_serviceProvider != null)
            {
                _formularioActivo = ActivatorUtilities.CreateInstance<TForm>(_serviceProvider);
            }
            else
            {
                throw new InvalidOperationException(
                    "El proveedor de servicios (IServiceProvider) no ha sido inicializado en FrmPrincipal."
                );
            }

            // Configuración para incrustar el Form dentro del panelContenedor
            _formularioActivo.TopLevel = false;
            _formularioActivo.FormBorderStyle = FormBorderStyle.None;
            _formularioActivo.Dock = DockStyle.Fill; // Asegura que llene todo el panel disponible

            panelContenedor.Controls.Add(_formularioActivo);
            panelContenedor.Tag = _formularioActivo;

            _formularioActivo.BringToFront();
            _formularioActivo.Show();


        }
    }
}

