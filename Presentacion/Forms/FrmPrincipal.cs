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
using Presentacion.Forms.Compras;
using Presentacion.Forms.Reportes;
using Presentacion.Forms.Corte;
using Presentacion.Forms.Configuracion;

namespace Presentacion.Forms
{
    public partial class FrmPrincipal : Form
    {
        // Nombres de módulo tal como se guardan en la BD (los mismos de FrmRolModal).
        // Si alguno cambia, se corrige solo aquí.
        private static class Permiso
        {
            public const string Productos = "Productos";
            public const string Categorias = "Categorias";
            public const string Ventas = "Ventas";
            public const string Membresias = "Membresias";
            public const string Socios = "Socios";
            public const string Registro = "Registro";
            public const string Conceptos = "Conceptos";
            public const string Movimientos = "Movimientos";
            public const string Roles = "Roles";
            public const string Usuarios = "Usuarios";
            public const string Compras = "Compras";
            public const string Reportes = "Reportes";
            public const string CorteDeCaja = "Corte de Caja";
            public const string Configuracion = "Configuracion";
        }

        // Un módulo del menú: su botón, el permiso necesario y el formulario que abre.
        // El aspecto del botón (icono, texto, colores) vive en el Designer.
        private sealed record ModuloMenu(IconButton Boton, string Permiso, Type Formulario);

        private readonly UsuarioDto _usuarioSesion;
        private readonly IServiceProvider _serviceProvider;
        private readonly List<ModuloMenu> _modulos = new();

        private Form _formularioActivo;
        private IconButton _botonActivo;

        /// <summary>
        /// Es true cuando el usuario eligió "Cerrar sesión". Program.cs lo revisa para volver
        /// a mostrar el login; si es false (se cerró la ventana con la X), la aplicación termina.
        /// </summary>
        public bool CerrarSesionSolicitado { get; private set; }

        public FrmPrincipal(UsuarioDto usuario, IServiceProvider serviceProvider)
        {
            // Se validan una sola vez aquí, no en cada clic.
            _usuarioSesion = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            InitializeComponent();

            Text = $"Sistema Gimnasio - Usuario: {_usuarioSesion.NombreCompleto} ({_usuarioSesion.RolNombre})";
            btnUsuarioMenu.Text = $"{_usuarioSesion.NombreCompleto} ▾";

            ConfigurarMenu();

            // Cuando exista el dashboard de inicio, ábrelo aquí:
            // AbrirFormulario(typeof(FrmDashboard), null);
        }

        // ───────────── Menú lateral ─────────────

        private void ConfigurarMenu()
        {
            // Para agregar un módulo nuevo: botón en el Designer + una línea aquí.
            _modulos.AddRange(new ModuloMenu[]
            {
            new(btnProductos,       Permiso.Productos,     typeof(FrmProductos)),
            new(btnCategorias,      Permiso.Categorias,    typeof(FrmCategorias)),
            new(btnVentas,          Permiso.Ventas,        typeof(FrmVentas)),
            new(btnMembresias,      Permiso.Membresias,    typeof(FrmMembresias)),
            new(btnSocios,          Permiso.Socios,        typeof(FrmSocios)),
            new(btnRegistrarVisita, Permiso.Registro,      typeof(FrmRegistroVisita)),
            new(btnConceptos,       Permiso.Conceptos,     typeof(FrmConceptos)),
            new(btnMovimientos,     Permiso.Movimientos,   typeof(FrmMovimientos)),
            new(btnRoles,           Permiso.Roles,         typeof(FrmRoles)),
            new(btnUsuarios,        Permiso.Usuarios,      typeof(FrmUsuarios)),
            new(btnCompras,         Permiso.Compras,       typeof(FrmCompras)),
            new(btnReportes,        Permiso.Reportes,      typeof(FrmReportes)),
            new(btnCorte,           Permiso.CorteDeCaja,   typeof(FrmCortes)),
            new(btnConfiguracion,   Permiso.Configuracion, typeof(FrmConfiguraciones)),
            });

            // Búsqueda rápida y sin distinguir mayúsculas de minúsculas.
            var permitidos = new HashSet<string>(
                _usuarioSesion.ModulosPermitidos ?? new List<string>(),
                StringComparer.OrdinalIgnoreCase);

            foreach (var modulo in _modulos)
            {
                // Ojo: ocultar el botón solo protege la interfaz.
                // La capa de Negocio también debe validar el permiso en acciones sensibles.
                modulo.Boton.Visible = permitidos.Contains(modulo.Permiso);

                modulo.Boton.Click += (s, e) => AbrirFormulario(modulo.Formulario, modulo.Boton);
            }
        }

        private void MarcarBotonActivo(IconButton boton)
        {
            if (boton == null) return;

            if (_botonActivo != null)
                _botonActivo.BackColor = Tema.AzulBase;

            boton.BackColor = Tema.AzulHover;
            _botonActivo = boton;
        }

        // ───────────── Formularios dentro del contenedor ─────────────

        /// <summary>
        /// Abre un formulario interno incrustado en panelContenedor, resuelto por inyección de dependencias.
        /// </summary>
        private void AbrirFormulario(Type tipoFormulario, IconButton botonOrigen)
        {
            // Si ya está abierto ese módulo, no lo cierres y reabras.
            if (_formularioActivo != null
                && !_formularioActivo.IsDisposed
                && _formularioActivo.GetType() == tipoFormulario)
            {
                return;
            }

            if (_formularioActivo != null)
            {
                _formularioActivo.Close();

                // Si el formulario canceló su cierre (por ejemplo, cambios sin guardar), no se abre el nuevo.
                if (!_formularioActivo.IsDisposed) return;
            }

            var formulario = (Form)ActivatorUtilities.CreateInstance(_serviceProvider, tipoFormulario);
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formulario);
            formulario.BringToFront();
            formulario.Show();

            _formularioActivo = formulario;
            MarcarBotonActivo(botonOrigen);
        }

        // ───────────── Sesión de usuario ─────────────

        private void btnUsuarioMenu_Click(object sender, EventArgs e)
        {
            menuUsuario.Show(btnUsuarioMenu, new Point(0, btnUsuarioMenu.Height));
        }

        private void itemCerrarSesion_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión actual?",
                "Confirmar cierre de sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            // Ya no se crea el login aquí: solo se avisa y se cierra.
            // Program.cs vuelve a mostrar el login al ver CerrarSesionSolicitado = true.
            CerrarSesionSolicitado = true;
            Close();
        }
    }
}

