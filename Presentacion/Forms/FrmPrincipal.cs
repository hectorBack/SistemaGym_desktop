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
        // Nombres de módulo ordenados y limpios
        private static class Permiso
        {
            public const string Inicio = "Inicio";
            public const string Ventas = "Ventas";
            public const string Membresias = "Membresias";
            public const string Socios = "Socios";
            public const string Registro = "Registro";
            public const string Productos = "Productos";
            public const string Categorias = "Categorias";
            public const string Compras = "Compras";
            public const string Conceptos = "Conceptos";
            public const string Movimientos = "Movimientos";
            public const string Roles = "Roles";
            public const string Usuarios = "Usuarios";
            public const string Reportes = "Reportes";
            public const string CorteDeCaja = "Corte de Caja";
            public const string Configuracion = "Configuracion";
            public const string Respaldos = "Respaldos";
            public const string Restaurar = "Restaurar";
        }

        // Un módulo del menú: su botón, el permiso necesario y el formulario que abre.
        private sealed record ModuloMenu(IconButton Boton, string Permiso, Type Formulario);

        private readonly UsuarioDto _usuarioSesion;
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmailService _emailService;
        private readonly List<ModuloMenu> _modulos = new();

        private Form _formularioActivo;
        private IconButton _botonActivo;
        private System.Windows.Forms.Timer? _timerRespaldo;
        private NotifyIcon? _notifyIconRespaldo;

        private IServiceScope? _scopeActivo;

        public bool CerrarSesionSolicitado { get; private set; }

        public FrmPrincipal(UsuarioDto usuario, IServiceProvider serviceProvider, IEmailService emailService)
        {
            _usuarioSesion = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));

            InitializeComponent();

            Text = $"Sistema Gimnasio - Usuario: {_usuarioSesion.NombreCompleto} ({_usuarioSesion.RolNombre})";
            btnUsuarioMenu.Text = $"{_usuarioSesion.NombreCompleto} ▾";

            ConfigurarMenu();
            _ = VerYEnviarFelicitacionesAsync();

            InicializarSistemaRespaldo();

            // Abrir el inicio por defecto al arrancar
            AbrirFormulario(typeof(FrmInicio), btnInicio);
        }

        // ───────────── Menú lateral ordenado ─────────────

        private void ConfigurarMenu()
        {
            // 🟢 El botón de registro de visitas ya no va dentro de los formularios internos del contenedor
            _modulos.AddRange(new ModuloMenu[]
            {
        new(btnInicio,          Permiso.Inicio,        typeof(FrmInicio)),
        new(btnVentas,          Permiso.Ventas,        typeof(FrmVentas)),
        new(btnMembresias,      Permiso.Membresias,    typeof(FrmMembresias)),
        new(btnSocios,          Permiso.Socios,        typeof(FrmSocios)),
        new(btnProductos,       Permiso.Productos,     typeof(FrmProductos)),
        new(btnCategorias,      Permiso.Categorias,    typeof(FrmCategorias)),
        new(btnCompras,         Permiso.Compras,       typeof(FrmCompras)),
        new(btnConceptos,       Permiso.Conceptos,     typeof(FrmConceptos)),
        new(btnMovimientos,     Permiso.Movimientos,   typeof(FrmMovimientos)),
        new(btnRoles,           Permiso.Roles,         typeof(FrmRoles)),
        new(btnUsuarios,        Permiso.Usuarios,      typeof(FrmUsuarios)),
        new(btnReportes,        Permiso.Reportes,      typeof(FrmReportes)),
        new(btnCorte,           Permiso.CorteDeCaja,   typeof(FrmCortes)),
        new(btnConfiguracion,   Permiso.Configuracion, typeof(FrmConfiguraciones)),
        new(btnRespaldosManuales, Permiso.Respaldos,   null),
        new(btnRestaurar,       Permiso.Restaurar,     null)
            });

            var permitidos = new HashSet<string>(
                _usuarioSesion.ModulosPermitidos ?? new List<string>(),
                StringComparer.OrdinalIgnoreCase);

            foreach (var modulo in _modulos)
            {
                modulo.Boton.Visible = permitidos.Contains(modulo.Permiso);

                if (modulo.Formulario != null)
                {
                    modulo.Boton.Click += (s, e) => AbrirFormulario(modulo.Formulario, modulo.Boton);
                }
            }

            // 🟢 Configurar de forma independiente el botón de Registrar Visita
            bool tienePermisoVisita = permitidos.Contains(Permiso.Registro);
            btnRegistrarVisita.Visible = tienePermisoVisita;

            if (tienePermisoVisita)
            {
                btnRegistrarVisita.Click += BtnRegistrarVisita_Click_Independiente;
            }
        }

        // Método que oculta el menú principal y abre el control de visitas como ventana independiente
        private void BtnRegistrarVisita_Click_Independiente(object? sender, EventArgs e)
        {
            MarcarBotonActivo(btnRegistrarVisita);

            var scope = _serviceProvider.CreateScope();
            try
            {
                var frmVisitas = ActivatorUtilities.CreateInstance<FrmRegistroVisita>(scope.ServiceProvider);

                // Opcional: Detectar si hay un segundo monitor conectado y moverlo ahí
                if (Screen.AllScreens.Length > 1)
                {
                    var segundoMonitor = Screen.AllScreens[1]; // El índice 1 es el segundo monitor
                    frmVisitas.StartPosition = FormStartPosition.Manual;
                    frmVisitas.Location = segundoMonitor.WorkingArea.Location;
                    frmVisitas.WindowState = FormWindowState.Maximized; // Pantalla completa en el monitor secundario
                }
                else
                {
                    frmVisitas.WindowState = FormWindowState.Maximized;
                }

                // Usamos Show() en lugar de ShowDialog() para que NO bloquee la ventana principal.
                // Así el recepcionista podrá seguir usando FrmPrincipal en el monitor 1 mientras 
                // el módulo de visitas opera de forma exclusiva en el monitor 2.
                frmVisitas.Show();

                // Limpiamos el scope cuando se cierre la ventana de visitas
                frmVisitas.FormClosed += (s, args) =>
                {
                    scope.Dispose();
                };
            }
            catch
            {
                scope.Dispose();
                throw;
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

        private void AbrirFormulario(Type tipoFormulario, IconButton botonOrigen)
        {
            if (_formularioActivo != null
                && !_formularioActivo.IsDisposed
                && _formularioActivo.GetType() == tipoFormulario)
            {
                return;
            }

            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
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

            CerrarSesionSolicitado = true;
            Close();
        }

        private async Task VerYEnviarFelicitacionesAsync()
        {
            try
            {
                await Task.Run(async () =>
                {
                    using var scope = _serviceProvider.CreateScope();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    await emailService.EnviarFelicitacionesCumpleanosAsync();
                    await emailService.EnviarRecordatorioVencimientoAsync();
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al enviar felicitaciones automáticas: {ex.Message}");
            }
        }

        private void InicializarSistemaRespaldo()
        {
            _notifyIconRespaldo = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Text = "Sistema Gimnasio - Respaldo",
                Visible = true
            };

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
                TimeSpan horaProgramada = new TimeSpan(20, 0, 0);
                TimeSpan horaActual = DateTime.Now.TimeOfDay;

                if (horaActual.Hours == horaProgramada.Hours && horaActual.Minutes >= horaProgramada.Minutes)
                {
                    using var scope = _serviceProvider.CreateScope();
                    var configuracionService = scope.ServiceProvider.GetRequiredService<IConfiguracionService>();

                    var configRespaldos = await configuracionService.ObtenerConfigRespaldosAsync();

                    if (configRespaldos != null && !string.IsNullOrWhiteSpace(configRespaldos.RutaRespaldo))
                    {
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

