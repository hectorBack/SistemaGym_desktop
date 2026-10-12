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
            lblPasswordOpcional = new Label();
            txtPassword = new TextBox();
            lblConfirmarPassword = new Label();
            txtConfirmarPassword = new TextBox();
            chkMostrarPassword = new CheckBox();
            lblRol = new Label();
            cboRol = new ComboBox();
            chkActivo = new CheckBox();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
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
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
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
            lblNombreUsuario.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombreUsuario.Location = new Point(25, 65);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(125, 17);
            lblNombreUsuario.TabIndex = 1;
            lblNombreUsuario.Text = "Nombre de Usuario:";
            //
            // txtNombreUsuario
            //
            txtNombreUsuario.BackColor = Color.FromArgb(15, 42, 79);
            txtNombreUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtNombreUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreUsuario.ForeColor = Color.FromArgb(230, 238, 252);
            txtNombreUsuario.Location = new Point(25, 85);
            txtNombreUsuario.MaxLength = 50;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(330, 25);
            txtNombreUsuario.TabIndex = 2;
            //
            // lblNombreCompleto
            //
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreCompleto.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombreCompleto.Location = new Point(25, 120);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(121, 17);
            lblNombreCompleto.TabIndex = 3;
            lblNombreCompleto.Text = "Nombre Completo:";
            //
            // txtNombreCompleto
            //
            txtNombreCompleto.BackColor = Color.FromArgb(15, 42, 79);
            txtNombreCompleto.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCompleto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreCompleto.ForeColor = Color.FromArgb(230, 238, 252);
            txtNombreCompleto.Location = new Point(25, 140);
            txtNombreCompleto.MaxLength = 100;
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(330, 25);
            txtNombreCompleto.TabIndex = 4;
            //
            // lblPassword
            //
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(230, 238, 252);
            lblPassword.Location = new Point(25, 175);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 17);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Contraseña:";
            //
            // lblPasswordOpcional
            //
            lblPasswordOpcional.AutoSize = true;
            lblPasswordOpcional.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lblPasswordOpcional.ForeColor = Color.FromArgb(45, 212, 255);
            lblPasswordOpcional.Location = new Point(105, 178);
            lblPasswordOpcional.Name = "lblPasswordOpcional";
            lblPasswordOpcional.Size = new Size(183, 13);
            lblPasswordOpcional.TabIndex = 6;
            lblPasswordOpcional.Text = "(Dejar en blanco para mantener actual)";
            lblPasswordOpcional.Visible = false;
            //
            // txtPassword
            //
            txtPassword.BackColor = Color.FromArgb(15, 42, 79);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = Color.FromArgb(230, 238, 252);
            txtPassword.Location = new Point(25, 195);
            txtPassword.MaxLength = 100;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(330, 25);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            //
            // lblConfirmarPassword
            //
            lblConfirmarPassword.AutoSize = true;
            lblConfirmarPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblConfirmarPassword.ForeColor = Color.FromArgb(230, 238, 252);
            lblConfirmarPassword.Location = new Point(25, 230);
            lblConfirmarPassword.Name = "lblConfirmarPassword";
            lblConfirmarPassword.Size = new Size(121, 17);
            lblConfirmarPassword.TabIndex = 8;
            lblConfirmarPassword.Text = "Confirmar contraseña:";
            //
            // txtConfirmarPassword
            //
            txtConfirmarPassword.BackColor = Color.FromArgb(15, 42, 79);
            txtConfirmarPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtConfirmarPassword.ForeColor = Color.FromArgb(230, 238, 252);
            txtConfirmarPassword.Location = new Point(25, 250);
            txtConfirmarPassword.MaxLength = 100;
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.Size = new Size(330, 25);
            txtConfirmarPassword.TabIndex = 9;
            txtConfirmarPassword.UseSystemPasswordChar = true;
            //
            // chkMostrarPassword
            //
            chkMostrarPassword.AutoSize = true;
            chkMostrarPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkMostrarPassword.ForeColor = Color.FromArgb(124, 138, 165);
            chkMostrarPassword.Location = new Point(25, 282);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(150, 19);
            chkMostrarPassword.TabIndex = 10;
            chkMostrarPassword.Text = "Mostrar contraseñas";
            chkMostrarPassword.UseVisualStyleBackColor = true;
            chkMostrarPassword.CheckedChanged += chkMostrarPassword_CheckedChanged;
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblRol.ForeColor = Color.FromArgb(230, 238, 252);
            lblRol.Location = new Point(25, 317);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(99, 17);
            lblRol.TabIndex = 11;
            lblRol.Text = "Rol de Usuario:";
            //
            // cboRol
            //
            cboRol.BackColor = Color.FromArgb(15, 42, 79);
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.FlatStyle = FlatStyle.Flat;
            cboRol.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboRol.ForeColor = Color.FromArgb(230, 238, 252);
            cboRol.FormattingEnabled = true;
            cboRol.Location = new Point(25, 337);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(330, 25);
            cboRol.TabIndex = 12;
            //
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            chkActivo.ForeColor = Color.FromArgb(230, 238, 252);
            chkActivo.Location = new Point(25, 378);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(113, 21);
            chkActivo.TabIndex = 13;
            chkActivo.Text = "Usuario Activo";
            chkActivo.UseVisualStyleBackColor = true;
            //
            // btnGuardar
            //
            btnGuardar.Enabled = false;
            btnGuardar.Estilo = EstiloBoton.Primario;
            btnGuardar.Location = new Point(165, 418);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(265, 418);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            //
            // FrmUsuarioModal
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(380, 470);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkActivo);
            Controls.Add(cboRol);
            Controls.Add(lblRol);
            Controls.Add(chkMostrarPassword);
            Controls.Add(txtConfirmarPassword);
            Controls.Add(lblConfirmarPassword);
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
        private Label lblPasswordOpcional;
        private TextBox txtPassword;
        private Label lblConfirmarPassword;
        private TextBox txtConfirmarPassword;
        private CheckBox chkMostrarPassword;
        private Label lblRol;
        private ComboBox cboRol;
        private CheckBox chkActivo;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}