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
            }
        }

        private void ConfigurarFormularioPrincipal()
        {
            // Forzar a que la ventana principal abra siempre en pantalla completa
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
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

