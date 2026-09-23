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

namespace Presentacion.Forms.Socios
{
    public partial class FrmSocioModal : Form
    {
        private readonly SocioController _controller;
        private readonly int? _socioId;
        private string? _rutaFoto;
        private static readonly Random _random = new Random();

        // AForge variables para webcam
        private FilterInfoCollection? _dispositivosVideo;
        private VideoCaptureDevice? _fuenteVideo;

        public FrmSocioModal(SocioController controller, int? socioId = null)
        {
            InitializeComponent();
            _controller = controller;
            _socioId = socioId;
        }

        private async void FrmSocioModal_Load(object sender, EventArgs e)
        {
            if (_socioId.HasValue)
            {
                lblTitulo.Text = "Editar Socio";
                await CargarDatosSocioAsync(_socioId.Value);
            }
            else
            {
                lblTitulo.Text = "Nuevo Socio";
                try
                {
                    txtClave.Text = await _controller.ObtenerSiguienteClaveAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar la clave: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CargarDatosSocioAsync(int socioId)
        {
            try
            {
                var socio = await _controller.ObtenerPorIdAsync(socioId);
                if (socio != null)
                {
                    txtClave.Text = socio.Clave;
                    txtNombre.Text = socio.Nombre;
                    txtApellido.Text = socio.Apellido;
                    txtTelefono.Text = socio.Telefono;
                    txtEmail.Text = socio.Email;
                    txtObservaciones.Text = socio.Observaciones;
                    chkActivo.Checked = socio.Activo;
                    _rutaFoto = socio.Foto;

                    // Cargar imagen en PictureBox si existe el archivo
                    if (!string.IsNullOrEmpty(_rutaFoto) && File.Exists(_rutaFoto))
                    {
                        picFoto.Image = Image.FromFile(_rutaFoto);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la información del socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del socio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Seleccionar Foto del Socio";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _rutaFoto = openFileDialog.FileName;
                picFoto.Image = Image.FromFile(_rutaFoto);
            }
        }

        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            // Si la cámara ya está activa, la foto se captura
            if (_fuenteVideo != null && _fuenteVideo.IsRunning)
            {
                if (picFoto.Image != null)
                {
                    // Guardar la foto capturada localmente
                    string carpetaFotos = Path.Combine(Application.StartupPath, "FotosSocios");
                    if (!Directory.Exists(carpetaFotos))
                    {
                        Directory.CreateDirectory(carpetaFotos);
                    }

                    string nombreArchivo = $"Socio_{Guid.NewGuid():N}.jpg";
                    _rutaFoto = Path.Combine(carpetaFotos, nombreArchivo);

                    using (Bitmap bmp = new Bitmap(picFoto.Image))
                    {
                        bmp.Save(_rutaFoto, ImageFormat.Jpeg);
                    }

                    DetenerCamara();
                    btnTomarFoto.Text = "📷 Tomar Foto";
                    MessageBox.Show("Foto capturada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Iniciar la transmisión de video desde la webcam
                _dispositivosVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (_dispositivosVideo.Count > 0)
                {
                    _fuenteVideo = new VideoCaptureDevice(_dispositivosVideo[0].MonikerString);
                    _fuenteVideo.NewFrame += FuenteVideo_NewFrame;
                    _fuenteVideo.Start();
                    btnTomarFoto.Text = "📸 Capturar";
                }
                else
                {
                    MessageBox.Show("No se detectó ninguna cámara conectada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FuenteVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            picFoto.Image = imagen;
        }

        private void DetenerCamara()
        {
            if (_fuenteVideo != null && _fuenteVideo.IsRunning)
            {
                _fuenteVideo.SignalToStop();
                _fuenteVideo.NewFrame -= FuenteVideo_NewFrame;
                _fuenteVideo = null;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.EsTextoVacio(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar la clave del socio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del socio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidationHelper.EsTextoVacio(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido del socio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DetenerCamara();

                await _controller.GuardarSocioAsync(
                    _socioId,
                    txtClave.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    string.IsNullOrWhiteSpace(_rutaFoto) ? null : _rutaFoto,
                    string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text.Trim(),
                    chkActivo.Checked
                );

                MessageBox.Show("Socio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DetenerCamara();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmSocioModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DetenerCamara();
        }
    }
}