namespace Presentacion.Forms.Configuracion
{
    partial class FrmConfiguracionCorreos
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

            lblEmail = new Label();
            txtEmail = new TextBox();

            lblPassword = new Label();
            txtPassword = new TextBox();

            chkRecordatorio = new CheckBox();
            chkFelicitaciones = new CheckBox();

            btnGuardar = new Button();

            panelTop.SuspendLayout();
            panelContenido.SuspendLayout();
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
            lblTitulo.Size = new Size(350, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuración de Correos";

            // 
            // panelContenido
            // 
            panelContenido.AutoScroll = true;
            panelContenido.Controls.Add(lblEmail);
            panelContenido.Controls.Add(txtEmail);
            panelContenido.Controls.Add(lblPassword);
            panelContenido.Controls.Add(txtPassword);
            panelContenido.Controls.Add(chkRecordatorio);
            panelContenido.Controls.Add(chkFelicitaciones);
            panelContenido.Controls.Add(btnGuardar);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 70);
            panelContenido.Margin = new Padding(3, 4, 3, 4);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(30);
            panelContenido.Size = new Size(914, 730);
            panelContenido.TabIndex = 1;

            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(230, 238, 252);
            lblEmail.Location = new Point(30, 35);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(203, 23);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Correo electrónico (gmail):";

            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(15, 42, 79);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.ForeColor = Color.FromArgb(230, 238, 252);
            txtEmail.Location = new Point(30, 65);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(450, 31);
            txtEmail.TabIndex = 1;

            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(230, 238, 252);
            lblPassword.Location = new Point(30, 125);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(101, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña:";

            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(15, 42, 79);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.ForeColor = Color.FromArgb(230, 238, 252);
            txtPassword.Location = new Point(30, 155);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(450, 31);
            txtPassword.TabIndex = 3;

            // 
            // chkRecordatorio
            // 
            chkRecordatorio.AutoSize = true;
            chkRecordatorio.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            chkRecordatorio.ForeColor = Color.FromArgb(230, 238, 252);
            chkRecordatorio.Location = new Point(30, 225);
            chkRecordatorio.Name = "chkRecordatorio";
            chkRecordatorio.Size = new Size(396, 27);
            chkRecordatorio.TabIndex = 4;
            chkRecordatorio.Text = "Enviar recordatorio de vencimiento de membresía";
            chkRecordatorio.UseVisualStyleBackColor = true;

            // 
            // chkFelicitaciones
            // 
            chkFelicitaciones.AutoSize = true;
            chkFelicitaciones.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            chkFelicitaciones.ForeColor = Color.FromArgb(230, 238, 252);
            chkFelicitaciones.Location = new Point(30, 275);
            chkFelicitaciones.Name = "chkFelicitaciones";
            chkFelicitaciones.Size = new Size(328, 27);
            chkFelicitaciones.TabIndex = 5;
            chkFelicitaciones.Text = "Enviar felicitaciones por correo electrónico";
            chkFelicitaciones.UseVisualStyleBackColor = true;

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(31, 111, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 350);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 42);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // FrmConfiguracionCorreos
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
            Name = "FrmConfiguracionCorreos";
            Text = "Configuración de Correos";
            Load += FrmConfiguracionCorreos_Load;

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContenido.ResumeLayout(false);
            panelContenido.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Panel panelContenido;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkRecordatorio;
        private CheckBox chkFelicitaciones;
        private Button btnGuardar;
    }
}