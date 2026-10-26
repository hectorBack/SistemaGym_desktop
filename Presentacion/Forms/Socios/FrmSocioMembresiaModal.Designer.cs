namespace Presentacion.Forms.Socios
{
    partial class FrmSocioMembresiaModal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitulo = new Label();
            panelContenido = new Panel();
            dgvHistorial = new GridTema();
            panelHistorialBarra = new Panel();
            lblHistorial = new Label();
            panelAccionesHistorial = new FlowLayoutPanel();
            btnPagarMembresia = new BotonTema();
            btnEliminarMembresia = new BotonTema();
            grpAsignarMembresia = new GroupBox();
            lblMembresia = new Label();
            cboMembresias = new ComboBox();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblPrecio = new Label();
            lblPrecioValor = new Label();
            btnAgregarMembresia = new BotonTema();
            grpDetallesSocio = new GroupBox();
            picFotoSocio = new PictureBox();
            lblSinFoto = new Label();
            lblNombreSocio = new Label();
            lblTelHeader = new Label();
            lblTelefono = new Label();
            lblObsHeader = new Label();
            txtObservaciones = new TextBox();
            panelPie = new Panel();
            btnCerrar = new BotonTema();
            panelHeader.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            panelHistorialBarra.SuspendLayout();
            panelAccionesHistorial.SuspendLayout();
            grpAsignarMembresia.SuspendLayout();
            grpDetallesSocio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFotoSocio).BeginInit();
            picFotoSocio.SuspendLayout();
            panelPie.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 67);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(274, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Membresías del Socio";
            //
            // panelContenido
            //
            panelContenido.Controls.Add(dgvHistorial);
            panelContenido.Controls.Add(panelHistorialBarra);
            panelContenido.Controls.Add(grpAsignarMembresia);
            panelContenido.Controls.Add(grpDetallesSocio);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 67);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(20, 10, 20, 10);
            panelContenido.Size = new Size(900, 548);
            panelContenido.TabIndex = 1;
            //
            // grpDetallesSocio
            //
            grpDetallesSocio.Controls.Add(picFotoSocio);
            grpDetallesSocio.Controls.Add(lblNombreSocio);
            grpDetallesSocio.Controls.Add(lblTelHeader);
            grpDetallesSocio.Controls.Add(lblTelefono);
            grpDetallesSocio.Controls.Add(lblObsHeader);
            grpDetallesSocio.Controls.Add(txtObservaciones);
            grpDetallesSocio.Dock = DockStyle.Top;
            grpDetallesSocio.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpDetallesSocio.ForeColor = Color.FromArgb(45, 212, 255);
            grpDetallesSocio.Location = new Point(20, 10);
            grpDetallesSocio.Name = "grpDetallesSocio";
            grpDetallesSocio.Size = new Size(860, 185);
            grpDetallesSocio.TabIndex = 0;
            grpDetallesSocio.TabStop = false;
            grpDetallesSocio.Text = "Detalles del socio";
            //
            // picFotoSocio
            //
            picFotoSocio.BackColor = Color.FromArgb(11, 15, 26);
            picFotoSocio.BorderStyle = BorderStyle.None;
            picFotoSocio.Controls.Add(lblSinFoto);
            picFotoSocio.Location = new Point(17, 30);
            picFotoSocio.Name = "picFotoSocio";
            picFotoSocio.Size = new Size(105, 140);
            picFotoSocio.SizeMode = PictureBoxSizeMode.Zoom;
            picFotoSocio.TabIndex = 0;
            picFotoSocio.TabStop = false;
            //
            // lblSinFoto
            //
            lblSinFoto.BackColor = Color.Transparent;
            lblSinFoto.Dock = DockStyle.Fill;
            lblSinFoto.Font = new Font("Segoe UI", 9F);
            lblSinFoto.ForeColor = Color.FromArgb(124, 138, 165);
            lblSinFoto.Name = "lblSinFoto";
            lblSinFoto.TabIndex = 0;
            lblSinFoto.Text = "Sin foto";
            lblSinFoto.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblNombreSocio
            //
            lblNombreSocio.AutoSize = true;
            lblNombreSocio.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNombreSocio.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombreSocio.Location = new Point(145, 30);
            lblNombreSocio.Name = "lblNombreSocio";
            lblNombreSocio.Size = new Size(167, 28);
            lblNombreSocio.TabIndex = 1;
            lblNombreSocio.Text = "Nombre del socio";
            //
            // lblTelHeader
            //
            lblTelHeader.AutoSize = true;
            lblTelHeader.Font = new Font("Segoe UI", 9F);
            lblTelHeader.ForeColor = Color.FromArgb(124, 138, 165);
            lblTelHeader.Location = new Point(145, 68);
            lblTelHeader.Name = "lblTelHeader";
            lblTelHeader.Size = new Size(70, 20);
            lblTelHeader.TabIndex = 2;
            lblTelHeader.Text = "Teléfono:";
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(230, 238, 252);
            lblTelefono.Location = new Point(220, 68);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(99, 20);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "0000000000";
            //
            // lblObsHeader
            //
            lblObsHeader.AutoSize = true;
            lblObsHeader.Font = new Font("Segoe UI", 9F);
            lblObsHeader.ForeColor = Color.FromArgb(124, 138, 165);
            lblObsHeader.Location = new Point(145, 98);
            lblObsHeader.Name = "lblObsHeader";
            lblObsHeader.Size = new Size(108, 20);
            lblObsHeader.TabIndex = 4;
            lblObsHeader.Text = "Observaciones:";
            //
            // txtObservaciones
            //
            txtObservaciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObservaciones.BackColor = Color.FromArgb(11, 15, 26);
            txtObservaciones.BorderStyle = BorderStyle.None;
            txtObservaciones.Font = new Font("Segoe UI", 9F);
            txtObservaciones.ForeColor = Color.FromArgb(230, 238, 252);
            txtObservaciones.Location = new Point(145, 122);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ReadOnly = true;
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(695, 48);
            txtObservaciones.TabIndex = 5;
            txtObservaciones.TabStop = false;
            //
            // grpAsignarMembresia
            //
            grpAsignarMembresia.Controls.Add(lblMembresia);
            grpAsignarMembresia.Controls.Add(cboMembresias);
            grpAsignarMembresia.Controls.Add(lblFechaInicio);
            grpAsignarMembresia.Controls.Add(dtpFechaInicio);
            grpAsignarMembresia.Controls.Add(lblPrecio);
            grpAsignarMembresia.Controls.Add(lblPrecioValor);
            grpAsignarMembresia.Controls.Add(btnAgregarMembresia);
            grpAsignarMembresia.Dock = DockStyle.Top;
            grpAsignarMembresia.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpAsignarMembresia.ForeColor = Color.FromArgb(45, 212, 255);
            grpAsignarMembresia.Location = new Point(20, 195);
            grpAsignarMembresia.Name = "grpAsignarMembresia";
            grpAsignarMembresia.Size = new Size(860, 105);
            grpAsignarMembresia.TabIndex = 1;
            grpAsignarMembresia.TabStop = false;
            grpAsignarMembresia.Text = "Asignar nueva membresía";
            //
            // lblMembresia
            //
            lblMembresia.AutoSize = true;
            lblMembresia.Font = new Font("Segoe UI", 8.5F);
            lblMembresia.ForeColor = Color.FromArgb(230, 238, 252);
            lblMembresia.Location = new Point(17, 28);
            lblMembresia.Name = "lblMembresia";
            lblMembresia.Size = new Size(86, 20);
            lblMembresia.TabIndex = 0;
            lblMembresia.Text = "Membresía:";
            //
            // cboMembresias
            //
            cboMembresias.BackColor = Color.FromArgb(15, 42, 79);
            cboMembresias.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMembresias.FlatStyle = FlatStyle.Flat;
            cboMembresias.Font = new Font("Segoe UI", 9F);
            cboMembresias.ForeColor = Color.FromArgb(230, 238, 252);
            cboMembresias.FormattingEnabled = true;
            cboMembresias.Location = new Point(17, 54);
            cboMembresias.Name = "cboMembresias";
            cboMembresias.Size = new Size(260, 28);
            cboMembresias.TabIndex = 0;
            cboMembresias.SelectedIndexChanged += cboMembresias_SelectedIndexChanged;
            //
            // lblFechaInicio
            //
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI", 8.5F);
            lblFechaInicio.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaInicio.Location = new Point(295, 28);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(90, 20);
            lblFechaInicio.TabIndex = 2;
            lblFechaInicio.Text = "Fecha de inicio:";
            //
            // dtpFechaInicio
            //
            dtpFechaInicio.CalendarMonthBackground = Color.FromArgb(15, 42, 79);
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(295, 54);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(150, 27);
            dtpFechaInicio.TabIndex = 1;
            //
            // lblPrecio
            //
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 8.5F);
            lblPrecio.ForeColor = Color.FromArgb(230, 238, 252);
            lblPrecio.Location = new Point(465, 28);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio y duración:";
            //
            // lblPrecioValor
            //
            lblPrecioValor.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblPrecioValor.ForeColor = Color.FromArgb(45, 212, 255);
            lblPrecioValor.Location = new Point(465, 54);
            lblPrecioValor.Name = "lblPrecioValor";
            lblPrecioValor.Size = new Size(185, 28);
            lblPrecioValor.TabIndex = 5;
            lblPrecioValor.Text = "$0.00";
            lblPrecioValor.TextAlign = ContentAlignment.MiddleLeft;
            //
            // btnAgregarMembresia
            //
            btnAgregarMembresia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarMembresia.Estilo = EstiloBoton.Primario;
            btnAgregarMembresia.Location = new Point(660, 50);
            btnAgregarMembresia.Name = "btnAgregarMembresia";
            btnAgregarMembresia.Size = new Size(185, 38);
            btnAgregarMembresia.TabIndex = 2;
            btnAgregarMembresia.Text = "+ Asignar membresía";
            btnAgregarMembresia.Click += btnAgregarMembresia_Click;
            //
            // panelHistorialBarra
            //
            panelHistorialBarra.Controls.Add(panelAccionesHistorial);
            panelHistorialBarra.Controls.Add(lblHistorial);
            panelHistorialBarra.Dock = DockStyle.Top;
            panelHistorialBarra.Location = new Point(20, 300);
            panelHistorialBarra.Name = "panelHistorialBarra";
            panelHistorialBarra.Size = new Size(860, 52);
            panelHistorialBarra.TabIndex = 2;
            //
            // lblHistorial
            //
            lblHistorial.AutoSize = true;
            lblHistorial.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblHistorial.ForeColor = Color.FromArgb(45, 212, 255);
            lblHistorial.Location = new Point(0, 17);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(160, 21);
            lblHistorial.TabIndex = 0;
            lblHistorial.Text = "Historial de membresías";
            //
            // panelAccionesHistorial
            //
            panelAccionesHistorial.AutoSize = true;
            panelAccionesHistorial.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelAccionesHistorial.Controls.Add(btnPagarMembresia);
            panelAccionesHistorial.Controls.Add(btnEliminarMembresia);
            panelAccionesHistorial.Dock = DockStyle.Right;
            panelAccionesHistorial.Location = new Point(620, 0);
            panelAccionesHistorial.Name = "panelAccionesHistorial";
            panelAccionesHistorial.Padding = new Padding(0, 8, 0, 0);
            panelAccionesHistorial.Size = new Size(240, 52);
            panelAccionesHistorial.TabIndex = 1;
            panelAccionesHistorial.WrapContents = false;
            //
            // btnPagarMembresia
            //
            btnPagarMembresia.Enabled = false;
            btnPagarMembresia.Estilo = EstiloBoton.Exito;
            btnPagarMembresia.Margin = new Padding(0, 0, 8, 0);
            btnPagarMembresia.Name = "btnPagarMembresia";
            btnPagarMembresia.Size = new Size(120, 36);
            btnPagarMembresia.TabIndex = 0;
            btnPagarMembresia.Text = "Pagos";
            btnPagarMembresia.Click += btnPagarMembresia_Click;
            //
            // btnEliminarMembresia
            //
            btnEliminarMembresia.Enabled = false;
            btnEliminarMembresia.Estilo = EstiloBoton.Peligro;
            btnEliminarMembresia.Margin = new Padding(0);
            btnEliminarMembresia.Name = "btnEliminarMembresia";
            btnEliminarMembresia.Size = new Size(110, 36);
            btnEliminarMembresia.TabIndex = 1;
            btnEliminarMembresia.Text = "Eliminar";
            btnEliminarMembresia.Click += btnEliminarMembresia_Click;
            //
            // dgvHistorial
            //
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(20, 352);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.Size = new Size(860, 186);
            dgvHistorial.TabIndex = 3;
            dgvHistorial.CellDoubleClick += dgvHistorial_CellDoubleClick;
            dgvHistorial.SelectionChanged += dgvHistorial_SelectionChanged;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(btnCerrar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 615);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(900, 60);
            panelPie.TabIndex = 2;
            //
            // btnCerrar
            //
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Location = new Point(780, 10);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 40);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            //
            // FrmSocioMembresiaModal
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCerrar;
            ClientSize = new Size(900, 675);
            Controls.Add(panelContenido);
            Controls.Add(panelPie);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = false;
            MinimumSize = new Size(860, 635);
            Name = "FrmSocioMembresiaModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Membresía de Socio";
            Load += FrmSocioMembresiaModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            panelHistorialBarra.ResumeLayout(false);
            panelHistorialBarra.PerformLayout();
            panelAccionesHistorial.ResumeLayout(false);
            grpAsignarMembresia.ResumeLayout(false);
            grpAsignarMembresia.PerformLayout();
            grpDetallesSocio.ResumeLayout(false);
            grpDetallesSocio.PerformLayout();
            picFotoSocio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picFotoSocio).EndInit();
            panelPie.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelContenido;
        private GridTema dgvHistorial;
        private Panel panelHistorialBarra;
        private Label lblHistorial;
        private FlowLayoutPanel panelAccionesHistorial;
        private BotonTema btnPagarMembresia;
        private BotonTema btnEliminarMembresia;
        private GroupBox grpAsignarMembresia;
        private Label lblMembresia;
        private ComboBox cboMembresias;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaInicio;
        private Label lblPrecio;
        private Label lblPrecioValor;
        private BotonTema btnAgregarMembresia;
        private GroupBox grpDetallesSocio;
        private PictureBox picFotoSocio;
        private Label lblSinFoto;
        private Label lblNombreSocio;
        private Label lblTelHeader;
        private Label lblTelefono;
        private Label lblObsHeader;
        private TextBox txtObservaciones;
        private Panel panelPie;
        private BotonTema btnCerrar;
    }
}