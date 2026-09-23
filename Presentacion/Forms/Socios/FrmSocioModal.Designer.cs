namespace Presentacion.Forms.Socios
{
    partial class FrmSocioModal
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
            lblClave = new Label();
            txtClave = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            picFoto = new PictureBox();
            btnTomarFoto = new Button();
            btnCargarFoto = new Button();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            chkActivo = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(434, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(128, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Socio";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 9.5F);
            lblClave.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblClave.Location = new Point(29, 85);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(51, 21);
            lblClave.TabIndex = 1;
            lblClave.Text = "Clave:";
            // 
            // txtClave
            // 
            txtClave.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 10F);
            txtClave.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtClave.Location = new Point(29, 108);
            txtClave.Margin = new Padding(3, 4, 3, 4);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(377, 30);
            txtClave.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F);
            lblNombre.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblNombre.Location = new Point(29, 148);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtNombre.Location = new Point(29, 171);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(377, 30);
            txtNombre.TabIndex = 4;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9.5F);
            lblApellido.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblApellido.Location = new Point(29, 211);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(70, 21);
            lblApellido.TabIndex = 5;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 10F);
            txtApellido.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtApellido.Location = new Point(29, 234);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(377, 30);
            txtApellido.TabIndex = 6;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9.5F);
            lblTelefono.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTelefono.Location = new Point(29, 274);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 7;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 10F);
            txtTelefono.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtTelefono.Location = new Point(29, 297);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(377, 30);
            txtTelefono.TabIndex = 8;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F);
            lblEmail.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblEmail.Location = new Point(29, 337);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(141, 21);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Correo Electrónico:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtEmail.Location = new Point(29, 360);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(377, 30);
            txtEmail.TabIndex = 10;
            // 
            // picFoto
            // 
            picFoto.BorderStyle = BorderStyle.FixedSingle;
            picFoto.Location = new Point(29, 405);
            picFoto.Name = "picFoto";
            picFoto.Size = new Size(130, 130);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            picFoto.TabIndex = 11;
            picFoto.TabStop = false;
            // 
            // btnTomarFoto
            // 
            btnTomarFoto.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnTomarFoto.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnTomarFoto.FlatStyle = FlatStyle.Flat;
            btnTomarFoto.Font = new Font("Segoe UI", 9F);
            btnTomarFoto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnTomarFoto.Location = new Point(175, 420);
            btnTomarFoto.Name = "btnTomarFoto";
            btnTomarFoto.Size = new Size(231, 38);
            btnTomarFoto.TabIndex = 12;
            btnTomarFoto.Text = "📷 Tomar Foto";
            btnTomarFoto.UseVisualStyleBackColor = false;
            btnTomarFoto.Click += btnTomarFoto_Click;
            // 
            // btnCargarFoto
            // 
            btnCargarFoto.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCargarFoto.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnCargarFoto.FlatStyle = FlatStyle.Flat;
            btnCargarFoto.Font = new Font("Segoe UI", 9F);
            btnCargarFoto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCargarFoto.Location = new Point(175, 475);
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.Size = new Size(231, 38);
            btnCargarFoto.TabIndex = 13;
            btnCargarFoto.Text = "📁 Cargar Foto";
            btnCargarFoto.UseVisualStyleBackColor = false;
            btnCargarFoto.Click += btnCargarFoto_Click;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 9.5F);
            lblObservaciones.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblObservaciones.Location = new Point(29, 550);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(115, 21);
            lblObservaciones.TabIndex = 14;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.Font = new Font("Segoe UI", 10F);
            txtObservaciones.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtObservaciones.Location = new Point(29, 573);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(377, 60);
            txtObservaciones.TabIndex = 15;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F);
            chkActivo.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            chkActivo.Location = new Point(29, 645);
            chkActivo.Margin = new Padding(3, 4, 3, 4);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(75, 25);
            chkActivo.TabIndex = 16;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(189, 680);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 43);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCancelar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F);
            btnCancelar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCancelar.Location = new Point(303, 680);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 43);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmSocioModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(434, 745);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkActivo);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(btnCargarFoto);
            Controls.Add(btnTomarFoto);
            Controls.Add(picFoto);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtClave);
            Controls.Add(lblClave);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSocioModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Socio";
            FormClosing += FrmSocioModal_FormClosing;
            Load += FrmSocioModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblClave;
        private TextBox txtClave;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private PictureBox picFoto;
        private Button btnTomarFoto;
        private Button btnCargarFoto;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}