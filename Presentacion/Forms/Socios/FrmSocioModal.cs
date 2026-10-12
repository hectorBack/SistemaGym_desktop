using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.Helpers;
using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Net.Mail;

namespace Presentacion.Forms.Socios
{
    public partial class FrmSocioModal : Form
    {
        private const string TextoTomarFoto = "📷 Tomar foto";
        private const string TextoCapturar = "📸 Capturar";
        private const int LadoMaximoFoto = 640; // las fotos se reducen a este tamaño antes de guardarse

        // Las fotos se guardan en una carpeta con permiso de escritura para todos los usuarios de Windows
        // (ProgramData). Antes se usaba la carpeta del programa, que si se instala en "Program Files" es de solo lectura.
        // Cuando tengas más de un módulo con archivos conviene mover esta ruta a una clase de configuración.
        private static readonly string CarpetaFotos = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "GymSystem", "FotosSocios");

        private readonly SocioController _controller;
        private readonly int? _socioId;

        private string? _rutaFoto;          // foto actual (la de la base de datos o la que eligió el usuario)
        private bool _fotoCambiada;         // true si el usuario cargó, tomó o quitó la foto en esta sesión
        private string? _fotoOrigenProcesada;   // evita crear copias duplicadas si el guardado se reintenta
        private string? _fotoDestinoProcesada;
        private bool _guardando;

        // Cámara (AForge)
        private VideoCaptureDevice? _fuenteVideo;
        private bool _hayFrame;

        public FrmSocioModal(SocioController controller, int? socioId = null)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _socioId = socioId;

            InitializeComponent();

            lblTitulo.Text = _socioId.HasValue ? "Editar Socio" : "Nuevo Socio";
            btnTomarFoto.Text = TextoTomarFoto;
        }

        // ───────────── Carga ─────────────

        private async void FrmSocioModal_Load(object? sender, EventArgs e)
        {
            if (_socioId.HasValue)
            {
                bool cargado = await FormHelper.EjecutarAsync(
                    () => CargarDatosSocioAsync(_socioId.Value),
                    "No se pudieron cargar los datos del socio.",
                    panelCampos, btnGuardar);

                // Si no se cargaron los datos no se deja editar: guardar un formulario vacío borraría los datos reales.
                if (!cargado && !IsDisposed)
                {
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            }
            else
            {
                await FormHelper.EjecutarAsync(async () =>
                {
                    string clave = await _controller.ObtenerSiguienteClaveAsync();
                    if (!IsDisposed) txtClave.Text = clave;
                },
                "No se pudo generar la clave automática. Puede escribirla manualmente.",
                panelCampos);
            }

            if (!IsDisposed)
                txtNombre.Focus();
        }

        private async Task CargarDatosSocioAsync(int socioId)
        {
            var socio = await _controller.ObtenerPorIdAsync(socioId)
                        ?? throw new BusinessException("No se encontró la información del socio.");

            if (IsDisposed) return;

            txtClave.Text = socio.Clave;
            txtNombre.Text = socio.Nombre;
            txtApellido.Text = socio.Apellido;
            txtTelefono.Text = socio.Telefono;
            txtEmail.Text = socio.Email;
            txtObservaciones.Text = socio.Observaciones;
            chkActivo.Checked = socio.Activo;
            _rutaFoto = socio.Foto;

            // Si el archivo ya no existe o está dañado, el socio se abre sin foto (y no se toca la referencia al guardar).
            if (!string.IsNullOrEmpty(_rutaFoto) && File.Exists(_rutaFoto))
            {
                try { MostrarImagen(CargarImagenSinBloqueo(_rutaFoto)); }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
            }
        }

        // ───────────── Foto ─────────────

        // Image.FromFile mantiene el archivo bloqueado mientras la imagen existe;
        // así se lee completo y se suelta el archivo de inmediato.
        private static Bitmap CargarImagenSinBloqueo(string ruta)
        {
            using var stream = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var original = Image.FromStream(stream);
            return new Bitmap(original);
        }

        // Cambia la imagen mostrada liberando la anterior (si no, cada cuadro de la cámara acumula memoria).
        private void MostrarImagen(Image? nueva)
        {
            var anterior = picFoto.Image;
            picFoto.Image = nueva;
            anterior?.Dispose();
        }

        private void btnCargarFoto_Click(object? sender, EventArgs e)
        {
            DetenerCamara();

            using var dialogo = new OpenFileDialog
            {
                Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Title = "Seleccionar foto del socio"
            };

            if (dialogo.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                MostrarImagen(CargarImagenSinBloqueo(dialogo.FileName));
                _rutaFoto = dialogo.FileName; // se copia a la carpeta de fotos al guardar
                _fotoCambiada = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                FormHelper.MostrarAdvertencia("No se pudo abrir la imagen seleccionada. Verifique que sea un archivo JPG o PNG válido.");
            }
        }

        private void btnQuitarFoto_Click(object? sender, EventArgs e)
        {
            DetenerCamara();
            MostrarImagen(null);
            _rutaFoto = null;
            _fotoCambiada = true;
        }

        private void btnTomarFoto_Click(object? sender, EventArgs e)
        {
            if (_fuenteVideo != null)
                CapturarFoto();
            else
                IniciarCamara();
        }

        private void IniciarCamara()
        {
            try
            {
                var dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (dispositivos.Count == 0)
                {
                    FormHelper.MostrarAdvertencia("No se detectó ninguna cámara conectada.", "Cámara");
                    return;
                }

                _hayFrame = false;
                _fuenteVideo = new VideoCaptureDevice(dispositivos[0].MonikerString);
                _fuenteVideo.NewFrame += FuenteVideo_NewFrame;
                _fuenteVideo.Start();

                btnTomarFoto.Text = TextoCapturar;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                DetenerCamara();
                FormHelper.MostrarError("No se pudo iniciar la cámara. Verifique que no la esté usando otra aplicación.");
            }
        }

        // Este evento llega desde el hilo de la cámara, no desde el de la pantalla:
        // por eso el cuadro se pasa al hilo de la interfaz antes de mostrarlo.
        private void FuenteVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap cuadro = (Bitmap)eventArgs.Frame.Clone();

            try
            {
                if (IsDisposed || !IsHandleCreated)
                {
                    cuadro.Dispose();
                    return;
                }

                BeginInvoke(() => MostrarCuadro(cuadro));
            }
            catch (Exception ex) when (ex is ObjectDisposedException or InvalidOperationException)
            {
                cuadro.Dispose(); // el formulario se cerró justo ahora
            }
        }

        private void MostrarCuadro(Bitmap cuadro)
        {
            // Si la cámara ya se detuvo, el cuadro que venía en camino se descarta
            // para no pisar la foto capturada.
            if (IsDisposed || _fuenteVideo == null)
            {
                cuadro.Dispose();
                return;
            }

            _hayFrame = true;
            MostrarImagen(cuadro);
        }

        private void CapturarFoto()
        {
            if (!_hayFrame || picFoto.Image == null)
            {
                FormHelper.MostrarAviso("Espere a que la cámara muestre la imagen e intente de nuevo.", "Cámara");
                return;
            }

            // Primero se detiene la cámara (así la imagen ya no cambia) y luego se guarda lo que se ve.
            DetenerCamara();

            try
            {
                string temporal = Path.Combine(Path.GetTempPath(), $"Socio_{Guid.NewGuid():N}.jpg");
                using (var copia = new Bitmap(picFoto.Image))
                    copia.Save(temporal, ImageFormat.Jpeg);

                _rutaFoto = temporal; // se copia a la carpeta de fotos al guardar
                _fotoCambiada = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                FormHelper.MostrarError("No se pudo capturar la foto.");
            }
        }

        private void DetenerCamara()
        {
            if (_fuenteVideo == null) return;

            _fuenteVideo.NewFrame -= FuenteVideo_NewFrame;

            if (_fuenteVideo.IsRunning)
                _fuenteVideo.SignalToStop();

            _fuenteVideo = null;

            if (!btnTomarFoto.IsDisposed)
                btnTomarFoto.Text = TextoTomarFoto;
        }

        // Copia la foto elegida a la carpeta de la aplicación, reducida y en JPEG.
        // Así no depende de que el archivo original (USB, Descargas...) siga existiendo
        // y no se guardan fotos de varios MB. No toca la interfaz: se ejecuta en otro hilo.
        private static string? PrepararFoto(string? origen)
        {
            if (string.IsNullOrWhiteSpace(origen) || !File.Exists(origen))
                return origen;

            Directory.CreateDirectory(CarpetaFotos);
            string destino = Path.Combine(CarpetaFotos, $"Socio_{Guid.NewGuid():N}.jpg");

            using (var original = CargarImagenSinBloqueo(origen))
            {
                double escala = Math.Min(1.0, (double)LadoMaximoFoto / Math.Max(original.Width, original.Height));
                int ancho = Math.Max(1, (int)(original.Width * escala));
                int alto = Math.Max(1, (int)(original.Height * escala));

                using var reducida = new Bitmap(ancho, alto);
                using (var g = Graphics.FromImage(reducida))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(original, 0, 0, ancho, alto);
                }

                reducida.Save(destino, ImageFormat.Jpeg);
            }

            // Si venía de una captura de la cámara (archivo temporal), se limpia.
            if (origen.StartsWith(Path.GetTempPath(), StringComparison.OrdinalIgnoreCase))
            {
                try { File.Delete(origen); } catch { /* no es crítico */ }
            }

            return destino;
        }

        // ───────────── Guardar ─────────────

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (_guardando) return;

            if (ValidationHelper.EsTextoVacio(txtClave.Text))
            {
                Invalido("Debe ingresar la clave del socio.", txtClave);
                return;
            }

            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                Invalido("Debe ingresar el nombre del socio.", txtNombre);
                return;
            }

            if (ValidationHelper.EsTextoVacio(txtApellido.Text))
            {
                Invalido("Debe ingresar el apellido del socio.", txtApellido);
                return;
            }

            string? telefono = NullSiVacio(txtTelefono.Text);
            if (telefono != null && telefono.Count(char.IsDigit) < 7)
            {
                Invalido("El teléfono debe tener al menos 7 dígitos.", txtTelefono);
                return;
            }

            string? email = NullSiVacio(txtEmail.Text);
            if (email != null && !EsCorreoValido(email))
            {
                Invalido("El correo electrónico no tiene un formato válido.", txtEmail);
                return;
            }

            DetenerCamara();

            // Se copian los valores antes de la operación asíncrona.
            string clave = txtClave.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string? observaciones = NullSiVacio(txtObservaciones.Text);
            bool activo = chkActivo.Checked;
            string? fotoActual = NullSiVacio(_rutaFoto);
            bool fotoCambiada = _fotoCambiada;

            _guardando = true;
            bool guardado = await FormHelper.EjecutarAsync(async () =>
            {
                string? foto = fotoActual;

                // Solo se procesa la foto si el usuario la cambió; una foto existente se deja como está.
                if (fotoCambiada)
                {
                    if (fotoActual != _fotoOrigenProcesada)
                    {
                        _fotoDestinoProcesada = await Task.Run(() => PrepararFoto(fotoActual));
                        _fotoOrigenProcesada = fotoActual;
                    }

                    foto = _fotoDestinoProcesada;
                }

                await _controller.GuardarSocioAsync(
                    _socioId, clave, nombre, apellido, telefono, email, foto, observaciones, activo);
            },
            "No se pudo guardar el socio.",
            panelCampos, btnGuardar, btnCancelar);
            _guardando = false;

            if (guardado && !IsDisposed)
                DialogResult = DialogResult.OK; // cierra el diálogo; el grid se recarga solo
        }

        private static void Invalido(string mensaje, Control campo)
        {
            FormHelper.MostrarAdvertencia(mensaje, "Validación");
            campo.Focus();
        }

        private static string? NullSiVacio(string? texto) =>
            string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();

        private static bool EsCorreoValido(string correo)
        {
            try
            {
                return new MailAddress(correo).Address == correo;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // ───────────── Cierre ─────────────

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_guardando)
            {
                e.Cancel = true; // no cerrar mientras se está guardando
            }
            else
            {
                DetenerCamara(); // libera la cámara siempre que se cierre el formulario
            }

            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MostrarImagen(null); // libera la imagen que tenía el PictureBox
            base.OnFormClosed(e);
        }
    }
}