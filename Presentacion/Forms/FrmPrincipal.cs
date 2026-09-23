using Microsoft.Extensions.DependencyInjection;
using Negocio.DTOs;
using Presentacion.Forms.Productos;
using Presentacion.Forms.Ventas;
using Presentacion.Forms.Membresias;
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
            if (btnCategorias != null) btnCategorias.Visible = modulosPermitidos.Contains("Productos"); // O el módulo asignado a Categorías
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

