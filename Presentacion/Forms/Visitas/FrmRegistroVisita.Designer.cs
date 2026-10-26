namespace Presentacion.Forms.Visitas
{
    partial class FrmRegistroVisita
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
            panelTop = new Panel();
            lblTitulo = new Label();
            lblClavePrompt = new Label();
            txtClave = new TextBox();
            btnRegistrar = new BotonTema();
            panelCentral = new Panel();
            panelDatos = new Panel();
            lblLabelSocio = new Label();
            lblNombreSocio = new Label();
            lblLabelMembresia = new Label();
            lblMembresia = new Label();
            lblLabelVencimiento = new Label();
            lblVencimiento = new Label();
            lblDeuda = new Label();
            lblEstadoAcceso = new Label();
            panelBotones = new FlowLayoutPanel();
            btnInformacion = new BotonTema();
            btnMembresias = new BotonTema();
            btnCancelarVisita = new BotonTema();
            panelFoto = new Panel();
            picFoto = new PictureBox();
            lblSinFoto = new Label();
            panelBottom = new Panel();
            dgvAsistenciasSemana = new GridTema();
            lblTituloAsistencia = new Label();
            panelTop.SuspendLayout();
            panelCentral.SuspendLayout();
            panelDatos.SuspendLayout();
            panelBotones.SuspendLayout();
            panelFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
            picFoto.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAsistenciasSemana).BeginInit();
            SuspendLayout();
            //
            // panelTop
            //
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblClavePrompt);
            panelTop.Controls.Add(txtClave);
            panelTop.Controls.Add(btnRegistrar);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 110);
            panelTop.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Control de Acceso / Visitas";
            //
            // lblClavePrompt
            //
            lblClavePrompt.AutoSize = true;
            lblClavePrompt.Font = new Font("Segoe UI", 9.5F);
            lblClavePrompt.ForeColor = Color.FromArgb(230, 238, 252);
            lblClavePrompt.Location = new Point(20, 65);
            lblClavePrompt.Name = "lblClavePrompt";
            lblClavePrompt.Size = new Size(115, 21);
            lblClavePrompt.TabIndex = 1;
            lblClavePrompt.Text = "Clave / Código:";
            //
            // txtClave
            //
            txtClave.BackColor = Color.FromArgb(11, 15, 26);
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 12F);
            txtClave.ForeColor = Color.FromArgb(230, 238, 252);
            txtClave.Location = new Point(140, 59);
            txtClave.MaxLength = 50;
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(260, 34);
            txtClave.TabIndex = 0;
            txtClave.KeyDown += txtClave_KeyDown;
            //
            // btnRegistrar
            //
            btnRegistrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegistrar.Estilo = EstiloBoton.Primario;
            btnRegistrar.Location = new Point(764, 56);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(130, 40);
            btnRegistrar.TabIndex = 1;
            btnRegistrar.TabStop = false;
            btnRegistrar.Text = "Ingresar";
            btnRegistrar.Click += btnRegistrar_Click;
            //
            // panelCentral
            //
            panelCentral.BackColor = Color.FromArgb(11, 15, 26);
            panelCentral.Controls.Add(panelDatos);
            panelCentral.Controls.Add(panelFoto);
            panelCentral.Dock = DockStyle.Fill;
            panelCentral.Location = new Point(0, 110);
            panelCentral.Name = "panelCentral";
            panelCentral.Padding = new Padding(25, 20, 25, 10);
            panelCentral.Size = new Size(914, 515);
            panelCentral.TabIndex = 1;
            //
            // panelFoto
            //
            panelFoto.Controls.Add(picFoto);
            panelFoto.Dock = DockStyle.Left;
            panelFoto.Location = new Point(25, 20);
            panelFoto.Name = "panelFoto";
            panelFoto.Padding = new Padding(0, 0, 25, 0);
            panelFoto.Size = new Size(300, 485);
            panelFoto.TabIndex = 1;
            //
            // picFoto
            //
            picFoto.BackColor = Color.FromArgb(11, 15, 26);
            picFoto.BorderStyle = BorderStyle.None;
            picFoto.Controls.Add(lblSinFoto);
            picFoto.Location = new Point(0, 0);
            picFoto.Name = "picFoto";
            picFoto.Size = new Size(270, 360);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            picFoto.TabIndex = 0;
            picFoto.TabStop = false;
            //
            // lblSinFoto
            //
            lblSinFoto.BackColor = Color.Transparent;
            lblSinFoto.Dock = DockStyle.Fill;
            lblSinFoto.Font = new Font("Segoe UI", 11F);
            lblSinFoto.ForeColor = Color.FromArgb(124, 138, 165);
            lblSinFoto.Name = "lblSinFoto";
            lblSinFoto.TabIndex = 0;
            lblSinFoto.Text = "Sin foto";
            lblSinFoto.TextAlign = ContentAlignment.MiddleCenter;
            //
            // panelDatos
            //
            panelDatos.Controls.Add(lblLabelSocio);
            panelDatos.Controls.Add(lblNombreSocio);
            panelDatos.Controls.Add(lblLabelMembresia);
            panelDatos.Controls.Add(lblMembresia);
            panelDatos.Controls.Add(lblLabelVencimiento);
            panelDatos.Controls.Add(lblVencimiento);
            panelDatos.Controls.Add(lblDeuda);
            panelDatos.Controls.Add(lblEstadoAcceso);
            panelDatos.Controls.Add(panelBotones);
            panelDatos.Dock = DockStyle.Fill;
            panelDatos.Location = new Point(325, 20);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(564, 485);
            panelDatos.TabIndex = 0;
            //
            // lblLabelSocio
            //
            lblLabelSocio.AutoSize = true;
            lblLabelSocio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLabelSocio.ForeColor = Color.FromArgb(45, 212, 255);
            lblLabelSocio.Location = new Point(0, 84);
            lblLabelSocio.Name = "lblLabelSocio";
            lblLabelSocio.Size = new Size(67, 23);
            lblLabelSocio.TabIndex = 0;
            lblLabelSocio.Text = "SOCIO";
            //
            // lblNombreSocio
            //
            lblNombreSocio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNombreSocio.AutoEllipsis = true;
            lblNombreSocio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNombreSocio.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombreSocio.Location = new Point(0, 110);
            lblNombreSocio.Name = "lblNombreSocio";
            lblNombreSocio.Size = new Size(564, 40);
            lblNombreSocio.TabIndex = 1;
            lblNombreSocio.Text = "--- ESPERANDO LECTURA ---";
            lblNombreSocio.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblLabelMembresia
            //
            lblLabelMembresia.AutoSize = true;
            lblLabelMembresia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLabelMembresia.ForeColor = Color.FromArgb(45, 212, 255);
            lblLabelMembresia.Location = new Point(0, 168);
            lblLabelMembresia.Name = "lblLabelMembresia";
            lblLabelMembresia.Size = new Size(114, 23);
            lblLabelMembresia.TabIndex = 2;
            lblLabelMembresia.Text = "MEMBRESÍA";
            //
            // lblMembresia
            //
            lblMembresia.AutoEllipsis = true;
            lblMembresia.Font = new Font("Segoe UI", 13F);
            lblMembresia.ForeColor = Color.FromArgb(230, 238, 252);
            lblMembresia.Location = new Point(0, 194);
            lblMembresia.Name = "lblMembresia";
            lblMembresia.Size = new Size(240, 32);
            lblMembresia.TabIndex = 3;
            lblMembresia.Text = "N/A";
            lblMembresia.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblLabelVencimiento
            //
            lblLabelVencimiento.AutoSize = true;
            lblLabelVencimiento.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLabelVencimiento.ForeColor = Color.FromArgb(45, 212, 255);
            lblLabelVencimiento.Location = new Point(260, 168);
            lblLabelVencimiento.Name = "lblLabelVencimiento";
            lblLabelVencimiento.Size = new Size(129, 23);
            lblLabelVencimiento.TabIndex = 4;
            lblLabelVencimiento.Text = "VENCIMIENTO";
            //
            // lblVencimiento
            //
            lblVencimiento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblVencimiento.AutoEllipsis = true;
            lblVencimiento.Font = new Font("Segoe UI", 13F);
            lblVencimiento.ForeColor = Color.FromArgb(230, 238, 252);
            lblVencimiento.Location = new Point(260, 194);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(304, 32);
            lblVencimiento.TabIndex = 5;
            lblVencimiento.Text = "N/A";
            lblVencimiento.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblDeuda
            //
            lblDeuda.AutoSize = true;
            lblDeuda.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDeuda.ForeColor = Color.FromArgb(230, 238, 252);
            lblDeuda.Location = new Point(0, 246);
            lblDeuda.Name = "lblDeuda";
            lblDeuda.Size = new Size(154, 30);
            lblDeuda.TabIndex = 6;
            lblDeuda.Text = "Deuda: $0.00";
            //
            // lblEstadoAcceso
            //
            lblEstadoAcceso.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEstadoAcceso.AutoEllipsis = true;
            lblEstadoAcceso.BackColor = Color.FromArgb(11, 15, 26);
            lblEstadoAcceso.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblEstadoAcceso.ForeColor = Color.FromArgb(31, 111, 235);
            lblEstadoAcceso.Location = new Point(0, 0);
            lblEstadoAcceso.Name = "lblEstadoAcceso";
            lblEstadoAcceso.Size = new Size(564, 64);
            lblEstadoAcceso.TabIndex = 7;
            lblEstadoAcceso.Text = "ESCANEE CLAVE";
            lblEstadoAcceso.TextAlign = ContentAlignment.MiddleCenter;
            //
            // panelBotones
            //
            panelBotones.Controls.Add(btnInformacion);
            panelBotones.Controls.Add(btnMembresias);
            panelBotones.Controls.Add(btnCancelarVisita);
            panelBotones.Dock = DockStyle.Bottom;
            panelBotones.Location = new Point(0, 425);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(564, 60);
            panelBotones.TabIndex = 8;
            panelBotones.WrapContents = false;
            //
            // btnInformacion
            //
            btnInformacion.Enabled = false;
            btnInformacion.Margin = new Padding(0, 8, 12, 0);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.Size = new Size(165, 42);
            btnInformacion.TabIndex = 0;
            btnInformacion.TabStop = false;
            btnInformacion.Text = "Más información";
            btnInformacion.Click += btnInformacion_Click;
            //
            // btnMembresias
            //
            btnMembresias.Enabled = false;
            btnMembresias.Margin = new Padding(0, 8, 12, 0);
            btnMembresias.Name = "btnMembresias";
            btnMembresias.Size = new Size(165, 42);
            btnMembresias.TabIndex = 1;
            btnMembresias.TabStop = false;
            btnMembresias.Text = "Membresías";
            btnMembresias.Click += btnMembresias_Click;
            //
            // btnCancelarVisita
            //
            btnCancelarVisita.Enabled = false;
            btnCancelarVisita.Estilo = EstiloBoton.Peligro;
            btnCancelarVisita.Margin = new Padding(0, 8, 0, 0);
            btnCancelarVisita.Name = "btnCancelarVisita";
            btnCancelarVisita.Size = new Size(175, 42);
            btnCancelarVisita.TabIndex = 2;
            btnCancelarVisita.TabStop = false;
            btnCancelarVisita.Text = "Cancelar entrada";
            btnCancelarVisita.Click += btnCancelarVisita_Click;
            //
            // panelBottom
            //
            panelBottom.BackColor = Color.FromArgb(11, 15, 26);
            panelBottom.Controls.Add(dgvAsistenciasSemana);
            panelBottom.Controls.Add(lblTituloAsistencia);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 625);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(25, 5, 25, 20);
            panelBottom.Size = new Size(914, 175);
            panelBottom.TabIndex = 2;
            //
            // lblTituloAsistencia
            //
            lblTituloAsistencia.Dock = DockStyle.Top;
            lblTituloAsistencia.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTituloAsistencia.ForeColor = Color.FromArgb(45, 212, 255);
            lblTituloAsistencia.Location = new Point(25, 5);
            lblTituloAsistencia.Name = "lblTituloAsistencia";
            lblTituloAsistencia.Size = new Size(864, 30);
            lblTituloAsistencia.TabIndex = 0;
            lblTituloAsistencia.Text = "ASISTENCIA SEMANA ACTUAL";
            lblTituloAsistencia.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dgvAsistenciasSemana
            //
            dgvAsistenciasSemana.Dock = DockStyle.Fill;
            dgvAsistenciasSemana.Location = new Point(25, 35);
            dgvAsistenciasSemana.Name = "dgvAsistenciasSemana";
            dgvAsistenciasSemana.ScrollBars = ScrollBars.None;
            dgvAsistenciasSemana.Size = new Size(864, 120);
            dgvAsistenciasSemana.TabIndex = 1;
            dgvAsistenciasSemana.TabStop = false;
            dgvAsistenciasSemana.SelectionChanged += dgvAsistenciasSemana_SelectionChanged;
            //
            // FrmRegistroVisita
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(panelCentral);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRegistroVisita";
            Text = "Registro de Visita";
            Load += FrmRegistroVisita_Load;
            VisibleChanged += FrmRegistroVisita_VisibleChanged;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCentral.ResumeLayout(false);
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelBotones.ResumeLayout(false);
            panelFoto.ResumeLayout(false);
            picFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAsistenciasSemana).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblClavePrompt;
        private TextBox txtClave;
        private BotonTema btnRegistrar;
        private Panel panelCentral;
        private Panel panelDatos;
        private Panel panelFoto;
        private PictureBox picFoto;
        private Label lblSinFoto;
        private Label lblLabelSocio;
        private Label lblNombreSocio;
        private Label lblLabelMembresia;
        private Label lblMembresia;
        private Label lblLabelVencimiento;
        private Label lblVencimiento;
        private Label lblDeuda;
        private Label lblEstadoAcceso;
        private FlowLayoutPanel panelBotones;
        private BotonTema btnInformacion;
        private BotonTema btnMembresias;
        private BotonTema btnCancelarVisita;
        private Panel panelBottom;
        private Label lblTituloAsistencia;
        private GridTema dgvAsistenciasSemana;
    }
}