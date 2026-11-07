using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public enum TipoMensaje
    {
        Aviso,
        Advertencia,
        Error,
        Pregunta
    }

    /// <summary>
    /// Cuadro de mensaje con el estilo de la aplicación. Se construye todo por código
    /// (no necesita Designer). Úselo a través de FormHelper.
    /// </summary>
    public sealed class FrmMensaje : Form
    {
        // Paleta de la aplicación
        private static readonly Color Fondo = Color.FromArgb(11, 15, 26);
        private static readonly Color Marino = Color.FromArgb(15, 42, 79);
        private static readonly Color Cian = Color.FromArgb(45, 212, 255);
        private static readonly Color Azul = Color.FromArgb(31, 111, 235);
        private static readonly Color Texto = Color.FromArgb(230, 238, 252);
        private static readonly Color Ambar = Color.FromArgb(245, 176, 65);
        private static readonly Color Rojo = Color.FromArgb(220, 53, 69);

        private readonly TipoMensaje _tipo;
        private readonly bool _destructiva;
        private Color _colorIcono;
        private Button? _btnPrincipal;
        private string _glifo = "i";

        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private FrmMensaje(string mensaje, string titulo, TipoMensaje tipo, bool confirmar, bool destructiva)
        {
            _tipo = tipo;
            _destructiva = destructiva;

            ConfigurarIcono();

            Font = new Font("Segoe UI", 9F);
            BackColor = Azul;            // se ve como borde de 1 px
            Padding = new Padding(1);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            ShowIcon = false;
            MinimizeBox = false;
            MaximizeBox = false;
            Text = titulo;

            // ── Contenedor raíz: encabezado / cuerpo / botones ──
            var raiz = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Fondo,
                ColumnCount = 1,
                RowCount = 3
            };
            raiz.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            raiz.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 64));

            // Encabezado
            var encabezado = new Panel { Dock = DockStyle.Fill, BackColor = Marino, Margin = Padding.Empty };
            var lblTitulo = new Label
            {
                Dock = DockStyle.Fill,
                Text = titulo,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Cian,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(16, 0, 0, 0),
                UseMnemonic = false
            };
            encabezado.Controls.Add(lblTitulo);
            encabezado.MouseDown += Arrastrar;
            lblTitulo.MouseDown += Arrastrar;

            // Cuerpo: icono + mensaje
            var cuerpo = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(24),
                Margin = Padding.Empty
            };
            cuerpo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            cuerpo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            var pnlIcono = new Panel { Size = new Size(48, 48), Margin = new Padding(0, 0, 16, 0) };
            pnlIcono.Paint += PintarIcono;

            var lblMensaje = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(360, 0),
                Text = mensaje,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Texto,
                UseMnemonic = false,
                Margin = Padding.Empty,
                Anchor = AnchorStyles.Left
            };
            cuerpo.Controls.Add(pnlIcono, 0, 0);
            cuerpo.Controls.Add(lblMensaje, 1, 0);

            // Botones (alineados a la derecha)
            var pie = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(16, 14, 16, 0),
                Margin = Padding.Empty,
                WrapContents = false
            };

            Button btnPrincipal;
            if (confirmar)
            {
                var btnNo = CrearBoton("No", DialogResult.No, Marino, Cian);
                btnNo.FlatAppearance.BorderSize = 1;
                btnNo.FlatAppearance.BorderColor = Cian;
                var btnSi = CrearBoton("Sí", DialogResult.Yes, destructiva ? Rojo : Azul, Color.White);
                pie.Controls.Add(btnNo);
                pie.Controls.Add(btnSi);

                // En acciones destructivas Enter equivale a "No".
                btnPrincipal = destructiva ? btnNo : btnSi;
                CancelButton = btnNo;
            }
            else
            {
                var btnOk = CrearBoton("Aceptar", DialogResult.OK, Azul, Color.White);
                pie.Controls.Add(btnOk);
                btnPrincipal = btnOk;
                CancelButton = btnOk;
            }
            AcceptButton = btnPrincipal;
            _btnPrincipal = btnPrincipal;

            raiz.Controls.Add(encabezado, 0, 0);
            raiz.Controls.Add(cuerpo, 0, 1);
            raiz.Controls.Add(pie, 0, 2);
            Controls.Add(raiz);

            // Tamaño según el contenido
            var preferido = raiz.GetPreferredSize(Size.Empty);
            ClientSize = new Size(Math.Max(preferido.Width, 420) + 2, preferido.Height + 2);
        }

        // El foco se asigna ya con el formulario visible; antes lanza ArgumentException.
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _btnPrincipal?.Focus();
        }

        private void ConfigurarIcono()
        {
            switch (_tipo)
            {
                case TipoMensaje.Error:
                    _colorIcono = Rojo; _glifo = "X"; break;
                case TipoMensaje.Advertencia:
                    _colorIcono = Ambar; _glifo = "!"; break;
                case TipoMensaje.Pregunta:
                    _colorIcono = _destructiva ? Ambar : Cian;
                    _glifo = _destructiva ? "!" : "?"; break;
                default:
                    _colorIcono = Cian; _glifo = "i"; break;
            }
        }

        private static Button CrearBoton(string texto, DialogResult resultado, Color fondo, Color colorTexto)
        {
            var b = new Button
            {
                Text = texto,
                DialogResult = resultado,
                Size = new Size(104, 36),
                Margin = new Padding(8, 0, 0, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = fondo,
                ForeColor = colorTexto,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = ControlPaint.Light(fondo, 0.15F);
            b.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(fondo, 0.1F);
            return b;
        }

        private void PintarIcono(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var area = new Rectangle(2, 2, 43, 43);
            using (var relleno = new SolidBrush(Color.FromArgb(40, _colorIcono)))
                e.Graphics.FillEllipse(relleno, area);
            using (var borde = new Pen(_colorIcono, 2.5F))
                e.Graphics.DrawEllipse(borde, area);

            using var fuente = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            using var pincel = new SolidBrush(_colorIcono);
            var formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(_glifo, fuente, pincel, new RectangleF(2, 2, 43, 44), formato);
        }

        private void Arrastrar(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0); // WM_NCLBUTTONDOWN, HTCAPTION
        }

        /// <summary>Muestra el cuadro sobre el formulario activo y devuelve el botón elegido.</summary>
        public static DialogResult Mostrar(
            string mensaje, string titulo, TipoMensaje tipo, bool confirmar = false, bool destructiva = false)
        {
            using var frm = new FrmMensaje(mensaje, titulo, tipo, confirmar, destructiva);
            var propietario = Form.ActiveForm;
            return propietario != null ? frm.ShowDialog(propietario) : frm.ShowDialog();
        }
    }
}
