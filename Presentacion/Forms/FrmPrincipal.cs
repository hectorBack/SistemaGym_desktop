using Microsoft.Extensions.DependencyInjection;
using Negocio.DTOs;
using Presentacion.Forms.Productos;
using Presentacion.Forms.Ventas;
using Presentacion.Forms.Membresias;
using FontAwesome.Sharp;
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
using Negocio.Interfaces;
using Presentacion.Forms.Inicio;
using Negocio.Helpers;

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
            public const string Inicio = "Inicio";
            public const string Respaldos = "Respaldos";
            public const string Restaurar = "Restaurar";
        }

        // Un módulo del menú: su botón, el permiso necesario y el formulario que abre.
        // El aspecto del botón (icono, texto, colores) vive en el Designer.
        private sealed record ModuloMenu(IconButton Boton, string Permiso, Type Formulario);

        private readonly UsuarioDto _usuarioSesion;
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmailService _emailService;
        private readonly List<ModuloMenu> _modulos = new();

        private Form _formularioActivo;
        private IconButton _botonActivo;
        private System.Windows.Forms.Timer? _timerRespaldo;
        private NotifyIcon? _notifyIconRespaldo;

        // Cada módulo abierto trabaja con su propio scope (y por tanto su propio DbContext).
        // Se libera al cerrar el módulo, así no se arrastran datos viejos entre pantallas.
        private IServiceScope? _scopeActivo;

        /// <summary>
        /// Es true cuando el usuario eligió "Cerrar sesión". Program.cs lo revisa para volver
        /// a mostrar el login; si es false (se cerró la ventana con la X), la aplicación termina.
        /// </summary>
        public bool CerrarSesionSolicitado { get; private set; }

        public FrmPrincipal(UsuarioDto usuario, IServiceProvider serviceProvider, IEmailService emailService)
        {
            // Se validan una sola vez aquí, no en cada clic.
            _usuarioSesion = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));

            InitializeComponent();

            Text = $"Sistema Gimnasio - Usuario: {_usuarioSesion.NombreCompleto} ({_usuarioSesion.RolNombre})";
            btnUsuarioMenu.Text = $"{_usuarioSesion.NombreCompleto} ▾";

            ConfigurarMenu();
            _ = VerYEnviarFelicitacionesAsync();

            InicializarSistemaRespaldo();

            // Cuando exista el dashboard de inicio, ábrelo aquí:
            AbrirFormulario(typeof(FrmInicio), null);
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
         new(btnInicio,          Permiso.Inicio,        typeof(FrmInicio)),
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

            var scope = _serviceProvider.CreateScope();
            Form formulario;
            try
            {
                formulario = (Form)ActivatorUtilities.CreateInstance(scope.ServiceProvider, tipoFormulario);
            }
            catch
            {
                scope.Dispose();
                throw;
            }

            formulario.FormClosed += (_, _) =>
            {
                scope.Dispose();
                if (ReferenceEquals(_scopeActivo, scope)) _scopeActivo = null;
            };
            _scopeActivo = scope;

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

        private async Task VerYEnviarFelicitacionesAsync()
        {
            try
            {
                // Se ejecuta en segundo plano para no congelar la apertura de la ventana principal
                await Task.Run(async () =>
                {
                    // Nota: Si usas Scopes independientes en servicios EF Core, 
                    // puedes abrir un scope temporal aquí para evitar conflictos de concurrencia.
                    using var scope = _serviceProvider.CreateScope();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    await emailService.EnviarFelicitacionesCumpleanosAsync();
                    await emailService.EnviarRecordatorioVencimientoAsync();
                });
            }
            catch (Exception ex)
            {
                // Los errores de correo en segundo plano no deben interrumpir la apertura del sistema
                System.Diagnostics.Debug.WriteLine($"Error al enviar felicitaciones automáticas: {ex.Message}");
            }
        }

        private void InicializarSistemaRespaldo()
        {
            // Crear el NotifyIcon para las burbujas de notificación en la barra de tareas
            _notifyIconRespaldo = new NotifyIcon
            {
                Icon = SystemIcons.Information, // O puedes usar un ícono personalizado de tu aplicación
                Text = "Sistema Gimnasio - Respaldo",
                Visible = true
            };

            // Configurar el Timer para que revise cada 1 minuto (60,000 milisegundos)
            _timerRespaldo = new System.Windows.Forms.Timer
            {
                Interval = 60000
            };
            _timerRespaldo.Tick += TimerRespaldo_Tick;
            _timerRespaldo.Start();
        }

        private async void TimerRespaldo_Tick(object? sender, EventArgs e)
        {
            try
            {
                // Supongamos que deseas que el respaldo se ejecute automáticamente todos los días a las 20:00 hrs (8:00 PM)
                // Puedes cambiar la hora según lo prefieras.
                TimeSpan horaProgramada = new TimeSpan(20, 0, 0);
                TimeSpan horaActual = DateTime.Now.TimeOfDay;

                if (horaActual.Hours == horaProgramada.Hours && horaActual.Minutes >= horaProgramada.Minutes)
                {
                    // Creamos un scope para consultar el servicio de configuración de manera segura
                    using var scope = _serviceProvider.CreateScope();
                    var configuracionService = scope.ServiceProvider.GetRequiredService<IConfiguracionService>();

                    // Obtenemos la ruta configurada en la pestaña de Respaldos (OneDrive)
                    var configRespaldos = await configuracionService.ObtenerConfigRespaldosAsync();

                    if (configRespaldos != null && !string.IsNullOrWhiteSpace(configRespaldos.RutaRespaldo))
                    {
                        // Ejecutamos el respaldo mediante el Helper que creamos
                        await RespaldoHelper.EjecutarRespaldoAutomaticoAsync(configRespaldos.RutaRespaldo, _notifyIconRespaldo);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en el temporizador de respaldo automático: {ex.Message}");
            }
        }

        private async void btnRespaldos_Click(object? sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona la carpeta donde deseas guardar tu archivo gym.sql";
                folderDialog.UseDescriptionForTitle = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaSeleccionada = folderDialog.SelectedPath;

                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        // Creamos un scope para invocar el servicio de respaldos de forma segura
                        using var scope = _serviceProvider.CreateScope();
                        var respaldoService = scope.ServiceProvider.GetRequiredService<IRespaldoService>();

                        var dto = new RespaldoManualDto
                        {
                            RutaDestino = rutaSeleccionada
                        };

                        await respaldoService.GenerarRespaldoManualAsync(dto);

                        MessageBox.Show(
                            $"El respaldo de la base de datos se generó exitosamente como 'gym.sql' en:\n{rutaSeleccionada}",
                            "Respaldo Exitoso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"No se pudo completar el respaldo: {ex.Message}",
                            "Error de Respaldo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private async void btnRestaurar_Click(object? sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "ADVERTENCIA: Restaurar una base de datos reemplazará toda la información actual con los datos del respaldo seleccionado.\n\n¿Desea continuar?",
                "Confirmar Restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar archivo de respaldo SQL";
                openFileDialog.Filter = "Archivos SQL (*.sql)|*.sql|Todos los archivos (*.*)|*.*";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivoSeleccionado = openFileDialog.FileName;

                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        // Creamos un scope para invocar el servicio de respaldos/restauración de forma segura
                        using var scope = _serviceProvider.CreateScope();
                        var respaldoService = scope.ServiceProvider.GetRequiredService<IRespaldoService>();

                        var dto = new RestaurarManualDto
                        {
                            RutaArchivo = rutaArchivoSeleccionado
                        };

                        await respaldoService.RestaurarBaseDatosAsync(dto);

                        MessageBox.Show(
                            "La base de datos se ha restaurado exitosamente.",
                            "Restauración Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"No se pudo completar la restauración: {ex.Message}",
                            "Error de Restauración",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        // Si se cierra la ventana con un módulo abierto, también se libera su scope.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerRespaldo?.Stop();
            _timerRespaldo?.Dispose();

            if (_notifyIconRespaldo != null)
            {
                _notifyIconRespaldo.Visible = false;
                _notifyIconRespaldo.Dispose();
            }

            _scopeActivo?.Dispose();
            _scopeActivo = null;
            base.OnFormClosed(e);
        }
    }
}

