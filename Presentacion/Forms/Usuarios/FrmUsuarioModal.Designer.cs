namespace Presentacion.Forms.Usuarios
{
    partial class FrmUsuarioModal
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
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            lblNombreCompleto = new Label();
            txtNombreCompleto = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblPasswordOpcional = new Label();
            lblRol = new Label();
            cboRol = new ComboBox();
            chkActivo = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(380, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(119, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Usuario";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreUsuario.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblNombreUsuario.Location = new Point(25, 65);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(125, 17);
            lblNombreUsuario.TabIndex = 1;
            lblNombreUsuario.Text = "Nombre de Usuario:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtNombreUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtNombreUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreUsuario.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtNombreUsuario.Location = new Point(25, 85);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(330, 25);
            txtNombreUsuario.TabIndex = 2;
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreCompleto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblNombreCompleto.Location = new Point(25, 120);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(121, 17);
            lblNombreCompleto.TabIndex = 3;
            lblNombreCompleto.Text = "Nombre Completo:";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtNombreCompleto.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCompleto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreCompleto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtNombreCompleto.Location = new Point(25, 140);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(330, 25);
            txtNombreCompleto.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblPassword.Location = new Point(25, 175);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 17);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtPassword.Location = new Point(25, 195);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(330, 25);
            txtPassword.TabIndex = 6;
            // 
            // lblPasswordOpcional
            // 
            lblPasswordOpcional.AutoSize = true;
            lblPasswordOpcional.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lblPasswordOpcional.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblPasswordOpcional.Location = new Point(105, 178);
            lblPasswordOpcional.Name = "lblPasswordOpcional";
            lblPasswordOpcional.Size = new Size(183, 13);
            lblPasswordOpcional.TabIndex = 7;
            lblPasswordOpcional.Text = "(Dejar en blanco para mantener actual)";
            lblPasswordOpcional.Visible = false;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblRol.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblRol.Location = new Point(25, 230);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(99, 17);
            lblRol.TabIndex = 8;
            lblRol.Text = "Rol de Usuario:";
            // 
            // cboRol
            // 
            cboRol.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.FlatStyle = FlatStyle.Flat;
            cboRol.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboRol.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            cboRol.FormattingEnabled = true;
            cboRol.Location = new Point(25, 250);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(330, 25);
            cboRol.TabIndex = 9;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            chkActivo.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            chkActivo.Location = new Point(25, 290);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(113, 21);
            chkActivo.TabIndex = 10;
            chkActivo.Text = "Usuario Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Location = new Point(165, 330);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCancelar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnCancelar.Location = new Point(265, 330);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmUsuarioModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(380, 385);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkActivo);
            Controls.Add(cboRol);
            Controls.Add(lblRol);
            Controls.Add(lblPasswordOpcional);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtNombreCompleto);
            Controls.Add(lblNombreCompleto);
            Controls.Add(txtNombreUsuario);
            Controls.Add(lblNombreUsuario);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUsuarioModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Usuario";
            Load += FrmUsuarioModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private Label lblNombreCompleto;
        private TextBox txtNombreCompleto;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblPasswordOpcional;
        private Label lblRol;
        private ComboBox cboRol;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}