namespace Presentacion.Forms.Configuracion
{
    partial class FrmConfiguracionDatosGimnasio
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
            panelContenido = new Panel();

            lblNombre = new Label();
            txtNombre = new TextBox();

            lblDomicilio = new Label();
            txtDomicilio = new TextBox();

            lblTelefono = new Label();
            txtTelefono = new TextBox();

            lblRfc = new Label();
            txtRfc = new TextBox();

            lblMensaje = new Label();
            txtMensaje = new TextBox();

            picLogo = new PictureBox();
            btnExaminarLogo = new Button();
            btnGuardar = new Button();

            panelTop.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();

            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 70);
            panelTop.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Bold", 13.5F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(330, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuración de Datos del Gimnasio";

            // 
            // panelContenido
            // 
            panelContenido.AutoScroll = true;
            panelContenido.Controls.Add(lblNombre);
            panelContenido.Controls.Add(txtNombre);
            panelContenido.Controls.Add(lblDomicilio);
            panelContenido.Controls.Add(txtDomicilio);
            panelContenido.Controls.Add(lblTelefono);
            panelContenido.Controls.Add(txtTelefono);
            panelContenido.Controls.Add(lblRfc);
            panelContenido.Controls.Add(txtRfc);
            panelContenido.Controls.Add(lblMensaje);
            panelContenido.Controls.Add(txtMensaje);
            panelContenido.Controls.Add(picLogo);
            panelContenido.Controls.Add(btnExaminarLogo);
            panelContenido.Controls.Add(btnGuardar);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 70);
            panelContenido.Margin = new Padding(3, 4, 3, 4);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(30);
            panelContenido.Size = new Size(914, 730);
            panelContenido.TabIndex = 1;

            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombre.Location = new Point(30, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(168, 23);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre del Gimnasio:";

            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(15, 42, 79);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10.5F);
            txtNombre.ForeColor = Color.FromArgb(230, 238, 252);
            txtNombre.Location = new Point(30, 55);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(420, 31);
            txtNombre.TabIndex = 1;

            // 
            // lblDomicilio
            // 
            lblDomicilio.AutoSize = true;
            lblDomicilio.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDomicilio.ForeColor = Color.FromArgb(230, 238, 252);
            lblDomicilio.Location = new Point(30, 95);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(88, 23);
            lblDomicilio.TabIndex = 2;
            lblDomicilio.Text = "Domicilio:";

            // 
            // txtDomicilio
            // 
            txtDomicilio.BackColor = Color.FromArgb(15, 42, 79);
            txtDomicilio.BorderStyle = BorderStyle.FixedSingle;
            txtDomicilio.Font = new Font("Segoe UI", 10.5F);
            txtDomicilio.ForeColor = Color.FromArgb(230, 238, 252);
            txtDomicilio.Location = new Point(30, 125);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(420, 31);
            txtDomicilio.TabIndex = 3;

            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(230, 238, 252);
            lblTelefono.Location = new Point(30, 165);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(79, 23);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.FromArgb(15, 42, 79);
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 10.5F);
            txtTelefono.ForeColor = Color.FromArgb(230, 238, 252);
            txtTelefono.Location = new Point(30, 195);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(420, 31);
            txtTelefono.TabIndex = 5;

            // 
            // lblRfc
            // 
            lblRfc.AutoSize = true;
            lblRfc.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblRfc.ForeColor = Color.FromArgb(230, 238, 252);
            lblRfc.Location = new Point(30, 235);
            lblRfc.Name = "lblRfc";
            lblRfc.Size = new Size(45, 23);
            lblRfc.TabIndex = 6;
            lblRfc.Text = "RFC:";

            // 
            // txtRfc
            // 
            txtRfc.BackColor = Color.FromArgb(15, 42, 79);
            txtRfc.BorderStyle = BorderStyle.FixedSingle;
            txtRfc.Font = new Font("Segoe UI", 10.5F);
            txtRfc.ForeColor = Color.FromArgb(230, 238, 252);
            txtRfc.Location = new Point(30, 265);
            txtRfc.Name = "txtRfc";
            txtRfc.Size = new Size(420, 31);
            txtRfc.TabIndex = 7;

            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblMensaje.ForeColor = Color.FromArgb(230, 238, 252);
            lblMensaje.Location = new Point(30, 305);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(77, 23);
            lblMensaje.TabIndex = 8;
            lblMensaje.Text = "Mensaje:";

            // 
            // txtMensaje
            // 
            txtMensaje.BackColor = Color.FromArgb(15, 42, 79);
            txtMensaje.BorderStyle = BorderStyle.FixedSingle;
            txtMensaje.Font = new Font("Segoe UI", 10.5F);
            txtMensaje.ForeColor = Color.FromArgb(230, 238, 252);
            txtMensaje.Location = new Point(30, 335);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(420, 31);
            txtMensaje.TabIndex = 9;

            // 
            // picLogo
            // 
            picLogo.BackColor = Color.FromArgb(15, 42, 79);
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new Point(500, 55);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(220, 220);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 10;
            picLogo.TabStop = false;

            // 
            // btnExaminarLogo
            // 
            btnExaminarLogo.BackColor = Color.FromArgb(31, 111, 235);
            btnExaminarLogo.FlatAppearance.BorderSize = 0;
            btnExaminarLogo.FlatStyle = FlatStyle.Flat;
            btnExaminarLogo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnExaminarLogo.ForeColor = Color.White;
            btnExaminarLogo.Location = new Point(500, 285);
            btnExaminarLogo.Name = "btnExaminarLogo";
            btnExaminarLogo.Size = new Size(220, 36);
            btnExaminarLogo.TabIndex = 11;
            btnExaminarLogo.Text = "Examinar Logotipo";
            btnExaminarLogo.UseVisualStyleBackColor = false;
            btnExaminarLogo.Click += btnExaminarLogo_Click;

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(31, 111, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 400);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 42);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // FrmConfiguracionDatosGimnasio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(panelContenido);
            Controls.Add(panelTop);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConfiguracionDatosGimnasio";
            Text = "Configuración Datos del Gimnasio";
            Load += FrmConfiguracionDatosGimnasio_Load;

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContenido.ResumeLayout(false);
            panelContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Panel panelContenido;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDomicilio;
        private TextBox txtDomicilio;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblRfc;
        private TextBox txtRfc;
        private Label lblMensaje;
        private TextBox txtMensaje;
        private PictureBox picLogo;
        private Button btnExaminarLogo;
        private Button btnGuardar;
    }
}