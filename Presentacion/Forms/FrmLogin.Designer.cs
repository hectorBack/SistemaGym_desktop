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
            lblLogoGym = new Label();
            lblTituloLogin = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancelar = new Button();
            panelLateral.SuspendLayout();
            SuspendLayout();
            // 
            // panelLateral
            // 
            panelLateral.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelLateral.Controls.Add(lblSubtituloLogo);
            panelLateral.Controls.Add(lblLogoGym);
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Location = new Point(0, 0);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(200, 330);
            panelLateral.TabIndex = 0;
            // 
            // lblSubtituloLogo
            // 
            lblSubtituloLogo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtituloLogo.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblSubtituloLogo.Location = new Point(10, 175);
            lblSubtituloLogo.Name = "lblSubtituloLogo";
            lblSubtituloLogo.Size = new Size(180, 40);
            lblSubtituloLogo.TabIndex = 1;
            lblSubtituloLogo.Text = "Gestión de Socios y Membresías";
            lblSubtituloLogo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblLogoGym
            // 
            lblLogoGym.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblLogoGym.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblLogoGym.Location = new Point(10, 110);
            lblLogoGym.Name = "lblLogoGym";
            lblLogoGym.Size = new Size(180, 60);
            lblLogoGym.TabIndex = 0;
            lblLogoGym.Text = "GYM\r\nSYSTEM";
            lblLogoGym.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloLogin
            // 
            lblTituloLogin.AutoSize = true;
            lblTituloLogin.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTituloLogin.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTituloLogin.Location = new Point(230, 25);
            lblTituloLogin.Name = "lblTituloLogin";
            lblTituloLogin.Size = new Size(160, 30);
            lblTituloLogin.TabIndex = 1;
            lblTituloLogin.Text = "Iniciar Sesión";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblUsuario.Location = new Point(230, 75);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 17);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtUsuario.Location = new Point(230, 95);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(240, 26);
            txtUsuario.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblPassword.Location = new Point(230, 135);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(74, 17);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtPassword.Location = new Point(230, 155);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(240, 26);
            txtPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(230, 215);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(240, 38);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Ingresar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCancelar.Location = new Point(230, 263);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(240, 32);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(510, 330);
            Controls.Add(btnCancelar);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTituloLogin);
            Controls.Add(panelLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acceso al Sistema";
            panelLateral.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Label lblLogoGym;
        private System.Windows.Forms.Label lblSubtituloLogo;
        private System.Windows.Forms.Label lblTituloLogin;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancelar;
    }
}
