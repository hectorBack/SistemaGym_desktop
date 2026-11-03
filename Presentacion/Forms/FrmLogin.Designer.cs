namespace Presentacion.Forms
{
    partial class FrmLogin
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            panelLateral = new Panel();
            lblSubtituloLogo = new Label();
            picLogo = new PictureBox();
            lblTituloLogin = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            lblAvisoMayus = new Label();
            txtPassword = new TextBox();
            chkMostrarPassword = new CheckBox();
            btnLogin = new Button();
            btnCancelar = new Button();
            panelLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // panelLateral
            // 
            panelLateral.BackColor = Color.FromArgb(15, 42, 79);
            panelLateral.Controls.Add(lblSubtituloLogo);
            panelLateral.Controls.Add(picLogo);
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Location = new Point(0, 0);
            panelLateral.Margin = new Padding(3, 4, 3, 4);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(297, 440);
            panelLateral.TabIndex = 0;
            // 
            // lblSubtituloLogo
            // 
            lblSubtituloLogo.Font = new Font("Segoe UI", 9.5F);
            lblSubtituloLogo.ForeColor = Color.FromArgb(230, 238, 252);
            lblSubtituloLogo.Location = new Point(29, 247);
            lblSubtituloLogo.Name = "lblSubtituloLogo";
            lblSubtituloLogo.Size = new Size(240, 60);
            lblSubtituloLogo.TabIndex = 1;
            lblSubtituloLogo.Text = "Gestiona tu gimnasio de forma simple y rápida";
            lblSubtituloLogo.TextAlign = ContentAlignment.TopCenter;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(17, 147);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(263, 83);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblTituloLogin
            // 
            lblTituloLogin.AutoSize = true;
            lblTituloLogin.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTituloLogin.ForeColor = Color.FromArgb(45, 212, 255);
            lblTituloLogin.Location = new Point(331, 33);
            lblTituloLogin.Name = "lblTituloLogin";
            lblTituloLogin.Size = new Size(179, 37);
            lblTituloLogin.TabIndex = 1;
            lblTituloLogin.Text = "Iniciar Sesión";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.5F);
            lblUsuario.ForeColor = Color.FromArgb(230, 238, 252);
            lblUsuario.Location = new Point(331, 100);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(64, 21);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(15, 42, 79);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 10.5F);
            txtUsuario.ForeColor = Color.FromArgb(230, 238, 252);
            txtUsuario.Location = new Point(331, 127);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(274, 31);
            txtUsuario.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F);
            lblPassword.ForeColor = Color.FromArgb(230, 238, 252);
            lblPassword.Location = new Point(331, 180);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(89, 21);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Contraseña";
            // 
            // lblAvisoMayus
            // 
            lblAvisoMayus.AutoSize = true;
            lblAvisoMayus.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblAvisoMayus.ForeColor = Color.FromArgb(245, 181, 61);
            lblAvisoMayus.Location = new Point(457, 183);
            lblAvisoMayus.Name = "lblAvisoMayus";
            lblAvisoMayus.Size = new Size(151, 20);
            lblAvisoMayus.TabIndex = 9;
            lblAvisoMayus.Text = "Bloq Mayús activado";
            lblAvisoMayus.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(15, 42, 79);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.ForeColor = Color.FromArgb(230, 238, 252);
            txtPassword.Location = new Point(331, 207);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(274, 31);
            txtPassword.TabIndex = 5;
            txtPassword.Enter += ActualizarAvisoMayus;
            txtPassword.KeyUp += ActualizarAvisoMayus;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // chkMostrarPassword
            // 
            chkMostrarPassword.AutoSize = true;
            chkMostrarPassword.Cursor = Cursors.Hand;
            chkMostrarPassword.Font = new Font("Segoe UI", 9F);
            chkMostrarPassword.ForeColor = Color.FromArgb(230, 238, 252);
            chkMostrarPassword.Location = new Point(331, 249);
            chkMostrarPassword.Margin = new Padding(3, 4, 3, 4);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(158, 24);
            chkMostrarPassword.TabIndex = 6;
            chkMostrarPassword.Text = "Mostrar contraseña";
            chkMostrarPassword.UseVisualStyleBackColor = true;
            chkMostrarPassword.CheckedChanged += chkMostrarPassword_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(31, 111, 235);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(331, 287);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(274, 51);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Ingresar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(15, 42, 79);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F);
            btnCancelar.ForeColor = Color.FromArgb(230, 238, 252);
            btnCancelar.Location = new Point(331, 351);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(274, 43);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FrmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(651, 440);
            Controls.Add(lblAvisoMayus);
            Controls.Add(chkMostrarPassword);
            Controls.Add(btnCancelar);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTituloLogin);
            Controls.Add(panelLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acceso al Sistema";
            panelLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSubtituloLogo;
        private System.Windows.Forms.Label lblTituloLogin;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblAvisoMayus;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkMostrarPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancelar;
    }
}
