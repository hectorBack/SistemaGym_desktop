using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.Forms.Socios;
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

namespace Presentacion.Forms.Visitas
{
    public partial class FrmRegistroVisita : Form
    {
        // Orden de las columnas de la semana (la semana empieza en lunes).
        private static readonly (DayOfWeek Dia, string Nombre)[] DiasSemana =
        {
        (DayOfWeek.Monday, "Lunes"),
        (DayOfWeek.Tuesday, "Martes"),
        (DayOfWeek.Wednesday, "Miércoles"),
        (DayOfWeek.Thursday, "Jueves"),
        (DayOfWeek.Friday, "Viernes"),
        (DayOfWeek.Saturday, "Sábado"),
        (DayOfWeek.Sunday, "Domingo"),
    };

        private readonly VisitaController _visitaController;
        private readonly SocioController _socioController;
        private readonly SocioMembresiaController _socioMembresiaController;
        private readonly MembresiaController _membresiaController;
        private readonly PagoSocioMembresiaController _pagoSocioMembresiaController;
        private readonly ConfiguracionController _configuracionController;

        private int? _socioIdActual;
        private int? _ultimaVisitaId;
        private bool _procesando;

        // Tras unos segundos la pantalla vuelve a "esperando lectura" (no deja datos del socio anterior a la vista).
        private const int SegundosLimpiarPantalla = 10;
        private readonly System.Windows.Forms.Timer _timerLimpieza = new() { Interval = SegundosLimpiarPantalla * 1000 };

        // El usuario sale de la sesión: antes llegaba como parámetro con valor por defecto 1,
        // y si el llamador lo olvidaba, las visitas quedaban registradas a nombre del usuario 1.
        private static int UsuarioId => SesionUsuario.UsuarioID;

        public FrmRegistroVisita(
            VisitaController visitaController,
            SocioController socioController,
            SocioMembresiaController socioMembresiaController,
            MembresiaController membresiaController,
            PagoSocioMembresiaController pagoSocioMembresiaController,
            ConfiguracionController configuracionController)
        {
            _visitaController = visitaController ?? throw new ArgumentNullException(nameof(visitaController));
            _socioController = socioController ?? throw new ArgumentNullException(nameof(socioController));
            _socioMembresiaController = socioMembresiaController ?? throw new ArgumentNullException(nameof(socioMembresiaController));
            _membresiaController = membresiaController ?? throw new ArgumentNullException(nameof(membresiaController));
            _pagoSocioMembresiaController = pagoSocioMembresiaController ?? throw new ArgumentNullException(nameof(pagoSocioMembresiaController));
            _configuracionController = configuracionController ?? throw new ArgumentNullException(nameof(configuracionController));

            InitializeComponent();
            ConfigurarAsistencias();

            _timerLimpieza.Tick += (_, _) =>
            {
                _timerLimpieza.Stop();
                RestablecerPantalla("--- ESPERANDO LECTURA ---", "ESCANEE CLAVE", Tema.Primario);
            };
        }

        private async void FrmRegistroVisita_Load(object? sender, EventArgs e)
        {
            RestablecerPantalla("--- ESPERANDO LECTURA ---", "ESCANEE CLAVE", Tema.Primario);
            ActiveControl = txtClave;

            await CargarDatosGimnasioAsync();
        }

        // En recepción el cursor siempre debe estar en la clave:
        // también al volver a esta pantalla desde otro módulo del menú.
        private void FrmRegistroVisita_VisibleChanged(object? sender, EventArgs e)
        {
            if (Visible && !IsDisposed)
                txtClave.Focus();
        }

        private async Task CargarDatosGimnasioAsync()
        {
            try
            {
                var config = await _configuracionController.ObtenerConfigGimnasioAsync();
                if (config != null)
                {
                    // 1. Nombre del gimnasio (en el título o etiqueta principal)
                    if (!string.IsNullOrWhiteSpace(config.Nombre))
                    {
                        lblTitulo.Text = config.Nombre.Trim();
                    }

                    // 2. Logotipo / Imagen del gimnasio
                    if (!string.IsNullOrWhiteSpace(config.Logo))
                    {
                        // Asegúrate de tener un PictureBox llamado picLogoGimnasio en tu panel superior
                        ImagenHelper.MostrarEn(picLogoGimnasio, ImagenHelper.CargarFoto(config.Logo));
                    }

                    // 3. Mensaje del gimnasio (bajo el nombre)
                    lblMensaje.Text = config.Mensaje?.Trim() ?? string.Empty;

                    // 4. Datos de contacto en una sola línea al pie; los que no estén capturados se omiten.
                    var contacto = new List<string>();
                    if (!string.IsNullOrWhiteSpace(config.Domicilio)) contacto.Add($"Domicilio: {config.Domicilio.Trim()}");
                    if (!string.IsNullOrWhiteSpace(config.Telefono)) contacto.Add($"Tel: {config.Telefono.Trim()}");
                    if (!string.IsNullOrWhiteSpace(config.Rfc)) contacto.Add($"RFC: {config.Rfc.Trim()}");
                    lblContacto.Text = string.Join("   ·   ", contacto);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar datos del gimnasio en visitas: {ex.Message}");
            }
        }

        // ───────────── Asistencia de la semana ─────────────

        // La tabla se define una sola vez (antes se recreaba en cada carga).
        private void ConfigurarAsistencias()
        {
            dgvAsistenciasSemana.AutoGenerateColumns = false;

            foreach (var (dia, nombre) in DiasSemana)
            {
                var columna = dgvAsistenciasSemana.AgregarTexto(dia.ToString(), nombre, 100, 70);
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            int fila = dgvAsistenciasSemana.Rows.Add();
            dgvAsistenciasSemana.Rows[fila].Height = 50;
        }

        private DataGridViewCell CeldaDe(DayOfWeek dia) =>
            dgvAsistenciasSemana.Rows[0].Cells["col" + dia];

        private void PintarAsistenciasSemana(Dictionary<DayOfWeek, string>? asistencias)
        {
            foreach (var (dia, _) in DiasSemana)
            {
                var celda = CeldaDe(dia);

                if (asistencias != null && asistencias.TryGetValue(dia, out var texto) && !string.IsNullOrWhiteSpace(texto))
                {
                    celda.Value = texto;
                    celda.Style.ForeColor = Tema.Exito;
                }
                else
                {
                    celda.Value = string.Empty;
                    celda.Style.ForeColor = Tema.Texto;
                }
            }
        }

        // La tabla es solo informativa: no debe quedar nada seleccionado.
        private void dgvAsistenciasSemana_SelectionChanged(object? sender, EventArgs e) =>
            dgvAsistenciasSemana.ClearSelection();

        // ───────────── Registro de acceso ─────────────

        private async void txtClave_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;
            await ProcesarIngresoAsync();
        }

        private async void btnRegistrar_Click(object? sender, EventArgs e) => await ProcesarIngresoAsync();

        private async Task ProcesarIngresoAsync()
        {
            // El lector de códigos puede enviar el Enter dos veces o escanear de nuevo antes de
            // terminar: sin este candado se registraban visitas duplicadas.
            if (_procesando) return;

            string clave = txtClave.Text.Trim();
            if (clave.Length == 0) return;

            _procesando = true;
            AccesoResultadoViewModel? resultado = null;

            try
            {
                bool consultado = await FormHelper.EjecutarAsync(
                    async () => resultado = await _visitaController.ProcesarAccesoRapidoAsync(clave, UsuarioId),
                    "No se pudo registrar el acceso. Intente de nuevo.",
                    panelTop);

                if (IsDisposed) return;

                if (!consultado || resultado == null)
                {
                    RestablecerPantalla("—", "ERROR AL REGISTRAR", Tema.Peligro);
                    System.Media.SystemSounds.Hand.Play();
                }
                else if (!resultado.Exitoso)
                {
                    RestablecerPantalla("—", (resultado.MensajeError ?? "ACCESO DENEGADO").ToUpper(), Tema.Peligro);
                    System.Media.SystemSounds.Hand.Play();
                }
                else
                {
                    MostrarAcceso(resultado);
                }

                ReiniciarTemporizadorLimpieza();
            }
            finally
            {
                _procesando = false;
            }

            PrepararSiguienteLectura();
        }

        private void MostrarAcceso(AccesoResultadoViewModel resultado)
        {
            _socioIdActual = resultado.SocioID;
            _ultimaVisitaId = resultado.VisitaID;
            ActualizarEstadoBotones();

            lblNombreSocio.Text = resultado.NombreCompleto;
            lblMembresia.Text = resultado.NombreMembresia;
            MostrarVencimiento(resultado);
            PonerFoto(resultado.ObtenerImagenFoto());

            lblDeuda.Text = $"Deuda: {resultado.Deuda:C2}";
            lblDeuda.ForeColor = resultado.Deuda > 0 ? Tema.Peligro : Tema.Exito;

            bool permitido = resultado.MembresiaVigente || resultado.EsVisitaCasual;
            AplicarEstado(permitido ? "ACCESO PERMITIDO" : "MEMBRESÍA VENCIDA", permitido ? Tema.Exito : Tema.Advertencia);

            // Un tono distinto según el resultado: en recepción no siempre se está mirando la pantalla.
            if (permitido)
                System.Media.SystemSounds.Asterisk.Play();
            else
                System.Media.SystemSounds.Exclamation.Play();

            PintarAsistenciasSemana(resultado.AsistenciasSemana);
        }

        // Vencimiento; si la membresía vigente vence en 7 días o menos se avisa en ámbar (oportunidad de renovar).
        private void MostrarVencimiento(AccesoResultadoViewModel resultado)
        {
            lblVencimiento.Text = resultado.FechaVencimientoTexto;
            lblVencimiento.ForeColor = Tema.Texto;

            if (!resultado.MembresiaVigente || !resultado.FechaVencimiento.HasValue) return;

            int dias = (resultado.FechaVencimiento.Value.Date - DateTime.Today).Days;
            if (dias is < 0 or > 7) return;

            string aviso = dias == 0 ? "vence hoy" : dias == 1 ? "vence mañana" : $"vence en {dias} días";
            lblVencimiento.Text = $"{resultado.FechaVencimientoTexto} · {aviso}";
            lblVencimiento.ForeColor = Tema.Advertencia;
        }

        // Franja de estado: texto del color del resultado sobre un fondo suave del mismo color.
        private void AplicarEstado(string texto, Color color)
        {
            lblEstadoAcceso.Text = texto;
            lblEstadoAcceso.ForeColor = color;
            lblEstadoAcceso.BackColor = Mezclar(Tema.Fondo, color, 0.22f);
        }

        private static Color Mezclar(Color fondo, Color color, float cantidad) => Color.FromArgb(
            (int)(fondo.R + (color.R - fondo.R) * cantidad),
            (int)(fondo.G + (color.G - fondo.G) * cantidad),
            (int)(fondo.B + (color.B - fondo.B) * cantidad));

        private void ReiniciarTemporizadorLimpieza()
        {
            if (IsDisposed) return;

            _timerLimpieza.Stop();
            _timerLimpieza.Start();
        }

        // Deja la pantalla sin socio: lecturas fallidas, errores y visitas canceladas.
        private void RestablecerPantalla(string nombre, string estado, Color colorEstado)
        {
            _socioIdActual = null;
            _ultimaVisitaId = null;
            ActualizarEstadoBotones();

            lblNombreSocio.Text = nombre;
            lblMembresia.Text = "N/A";
            lblVencimiento.Text = "N/A";
            lblVencimiento.ForeColor = Tema.Texto;
            lblDeuda.Text = "Deuda: $0.00";
            lblDeuda.ForeColor = Tema.Texto;
            AplicarEstado(estado, colorEstado);

            PonerFoto(null);
            PintarAsistenciasSemana(null);
        }

        private void PrepararSiguienteLectura()
        {
            if (IsDisposed) return;

            txtClave.Clear();
            txtClave.Focus();
        }

        // Los botones solo se habilitan cuando hay un socio / una visita a la cual aplicarlos
        // (por eso ya no hacen falta los mensajes de "primero consulta un socio").
        private void ActualizarEstadoBotones()
        {
            bool haySocio = _socioIdActual is > 0;

            btnInformacion.Enabled = haySocio;
            btnMembresias.Enabled = haySocio;
            btnCancelarVisita.Enabled = _ultimaVisitaId is > 0;
        }

        // Libera la foto anterior (antes cada lectura dejaba una imagen sin liberar).
        private void PonerFoto(Image? nueva)
        {
            var anterior = picFoto.Image;
            picFoto.Image = nueva;
            anterior?.Dispose();

            lblSinFoto.Visible = nueva == null; // sin imagen, se muestra "Sin foto"
        }

        // ───────────── Información y membresías ─────────────

        private void btnInformacion_Click(object? sender, EventArgs e)
        {
            if (_socioIdActual is not > 0) return;

            _timerLimpieza.Stop(); // no limpiar la pantalla mientras hay una ventana abierta

            using (var modal = new FrmSocioInfoModal(_socioController, _visitaController, _socioIdActual.Value))
            {
                modal.ShowDialog(this);
            }

            ReiniciarTemporizadorLimpieza();
            txtClave.Focus();
        }

        private async void btnMembresias_Click(object? sender, EventArgs e)
        {
            if (_socioIdActual is not > 0) return;

            int socioId = _socioIdActual.Value;
            SocioViewModel? socio = null;

            bool cargado = await FormHelper.EjecutarAsync(async () =>
            {
                var dto = await _socioController.ObtenerPorIdAsync(socioId)
                          ?? throw new BusinessException("No se encontró la información detallada del socio.");

                socio = new SocioViewModel
                {
                    SocioID = dto.SocioID,
                    Clave = dto.Clave,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Telefono = dto.Telefono,
                    Email = dto.Email,
                    Foto = dto.Foto,
                    Activo = dto.Activo,
                    Observaciones = dto.Observaciones // antes no se copiaba y el modal mostraba siempre "Sin observaciones"
                };
            },
            "No se pudo abrir el módulo de membresías.",
            btnMembresias);

            if (!cargado || socio == null || IsDisposed) return;

            _timerLimpieza.Stop(); // no limpiar la pantalla mientras hay una ventana abierta

            using (var modal = new FrmSocioMembresiaModal(
                _socioMembresiaController,
                _membresiaController,
                _pagoSocioMembresiaController,
                socio,
                UsuarioId))
            {
                modal.ShowDialog(this);
            }

            ReiniciarTemporizadorLimpieza();
            txtClave.Focus();
        }

        // ───────────── Cancelar visita ─────────────

        private async void btnCancelarVisita_Click(object? sender, EventArgs e)
        {
            if (_ultimaVisitaId is not > 0) return;

            int visitaId = _ultimaVisitaId.Value;
            string socio = string.IsNullOrWhiteSpace(lblNombreSocio.Text) ? "este socio" : lblNombreSocio.Text;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea cancelar la entrada recién registrada de {socio}?",
                    "Cancelar entrada",
                    destructiva: true))
            {
                txtClave.Focus();
                return;
            }

            bool cancelada = await FormHelper.EjecutarAsync(
                () => _visitaController.CancelarVisitaAsync(visitaId, UsuarioId, "Cancelación desde pantalla de acceso"),
                "No se pudo cancelar la visita.",
                btnCancelarVisita);

            if (IsDisposed) return;

            // Sin mensaje de éxito: el cambio de estado en pantalla ya lo confirma.
            if (cancelada)
            {
                RestablecerPantalla("—", "VISITA CANCELADA", Tema.Advertencia);
                ReiniciarTemporizadorLimpieza();
            }

            PrepararSiguienteLectura();
        }

        // ───────────── Cierre ─────────────

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerLimpieza.Stop();
            _timerLimpieza.Dispose();
            PonerFoto(null); // libera la foto
            ImagenHelper.MostrarEn(picLogoGimnasio, null); // y el logotipo
            base.OnFormClosed(e);
        }

    }
}
