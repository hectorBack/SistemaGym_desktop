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
            panelCampos = new Panel();
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
            lblFechaNacimiento = new Label(); // 🟢 Etiqueta de Fecha de Nacimiento
            dtpFechaNacimiento = new DateTimePicker(); // 🟢 Selector de Fecha de Nacimiento
            chkActivo = new CheckBox();
            picFoto = new PictureBox();
            btnTomarFoto = new BotonTema();
            btnCargarFoto = new BotonTema();
            btnQuitarFoto = new BotonTema();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            panelPie = new Panel();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader.SuspendLayout();
            panelCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
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
            panelHeader.Size = new Size(760, 67);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(128, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Socio";
            //
            // panelCampos
            //
            panelCampos.Controls.Add(lblClave);
            panelCampos.Controls.Add(txtClave);
            panelCampos.Controls.Add(lblNombre);
            panelCampos.Controls.Add(txtNombre);
            panelCampos.Controls.Add(lblApellido);
            panelCampos.Controls.Add(txtApellido);
            panelCampos.Controls.Add(lblTelefono);
            panelCampos.Controls.Add(txtTelefono);
            panelCampos.Controls.Add(lblEmail);
            panelCampos.Controls.Add(txtEmail);
            panelCampos.Controls.Add(lblFechaNacimiento); // 🟢 Añadido al panel
            panelCampos.Controls.Add(dtpFechaNacimiento); // 🟢 Añadido al panel
            panelCampos.Controls.Add(chkActivo);
            panelCampos.Controls.Add(picFoto);
            panelCampos.Controls.Add(btnTomarFoto);
            panelCampos.Controls.Add(btnCargarFoto);
            panelCampos.Controls.Add(btnQuitarFoto);
            panelCampos.Controls.Add(lblObservaciones);
            panelCampos.Controls.Add(txtObservaciones);
            panelCampos.Dock = DockStyle.Fill;
            panelCampos.Location = new Point(0, 67);
            panelCampos.Name = "panelCampos";
            panelCampos.Size = new Size(760, 415);
            panelCampos.TabIndex = 1;
            //
            // lblClave
            //
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 9.5F);
            lblClave.ForeColor = Color.FromArgb(230, 238, 252);
            lblClave.Location = new Point(29, 15);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(51, 21);
            lblClave.TabIndex = 0;
            lblClave.Text = "Clave:";
            //
            // txtClave
            //
            txtClave.BackColor = Color.FromArgb(15, 42, 79);
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 10F);
            txtClave.ForeColor = Color.FromArgb(230, 238, 252);
            txtClave.Location = new Point(29, 38);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(340, 30);
            txtClave.TabIndex = 1;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F);
            lblNombre.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombre.Location = new Point(29, 73);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.BackColor = Color.FromArgb(15, 42, 79);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.ForeColor = Color.FromArgb(230, 238, 252);
            txtNombre.Location = new Point(29, 96);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(340, 30);
            txtNombre.TabIndex = 2;
            //
            // lblApellido
            //
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9.5F);
            lblApellido.ForeColor = Color.FromArgb(230, 238, 252);
            lblApellido.Location = new Point(29, 131);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(70, 21);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido:";
            //
            // txtApellido
            //
            txtApellido.BackColor = Color.FromArgb(15, 42, 79);
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 10F);
            txtApellido.ForeColor = Color.FromArgb(230, 238, 252);
            txtApellido.Location = new Point(29, 154);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(340, 30);
            txtApellido.TabIndex = 3;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9.5F);
            lblTelefono.ForeColor = Color.FromArgb(230, 238, 252);
            lblTelefono.Location = new Point(29, 189);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono:";
            //
            // txtTelefono
            //
            txtTelefono.BackColor = Color.FromArgb(15, 42, 79);
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 10F);
            txtTelefono.ForeColor = Color.FromArgb(230, 238, 252);
            txtTelefono.Location = new Point(29, 212);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(340, 30);
            txtTelefono.TabIndex = 4;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F);
            lblEmail.ForeColor = Color.FromArgb(230, 238, 252);
            lblEmail.Location = new Point(29, 247);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(141, 21);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Correo electrónico:";
            //
            // txtEmail
            //
            txtEmail.BackColor = Color.FromArgb(15, 42, 79);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.FromArgb(230, 238, 252);
            txtEmail.Location = new Point(29, 270);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(340, 30);
            txtEmail.TabIndex = 5;
            //
            // lblFechaNacimiento
            //
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Font = new Font("Segoe UI", 9.5F);
            lblFechaNacimiento.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaNacimiento.Location = new Point(29, 305);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(150, 21);
            lblFechaNacimiento.TabIndex = 10;
            lblFechaNacimiento.Text = "Fecha de nacimiento:";
            //
            // dtpFechaNacimiento
            //
            dtpFechaNacimiento.CalendarForeColor = Color.FromArgb(230, 238, 252);
            dtpFechaNacimiento.CalendarMonthBackground = Color.FromArgb(15, 42, 79);
            dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Font = new Font("Segoe UI", 10F);
            dtpFechaNacimiento.Location = new Point(29, 328);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.ShowCheckBox = true;
            dtpFechaNacimiento.Checked = false;
            dtpFechaNacimiento.Size = new Size(340, 30);
            dtpFechaNacimiento.TabIndex = 6;
            //
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F);
            chkActivo.ForeColor = Color.FromArgb(230, 238, 252);
            chkActivo.Location = new Point(29, 372);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(75, 25);
            chkActivo.TabIndex = 7;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            //
            // picFoto
            //
            picFoto.BackColor = Color.FromArgb(15, 42, 79);
            picFoto.BorderStyle = BorderStyle.FixedSingle;
            picFoto.Location = new Point(400, 21);
            picFoto.Name = "picFoto";
            picFoto.Size = new Size(150, 150);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            picFoto.TabIndex = 20;
            picFoto.TabStop = false;
            //
            // btnTomarFoto
            //
            btnTomarFoto.Location = new Point(565, 21);
            btnTomarFoto.Name = "btnTomarFoto";
            btnTomarFoto.Size = new Size(165, 38);
            btnTomarFoto.TabIndex = 8;
            btnTomarFoto.Text = "📷 Tomar foto";
            btnTomarFoto.Click += btnTomarFoto_Click;
            //
            // btnCargarFoto
            //
            btnCargarFoto.Location = new Point(565, 67);
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.Size = new Size(165, 38);
            btnCargarFoto.TabIndex = 9;
            btnCargarFoto.Text = "📁 Cargar foto";
            btnCargarFoto.Click += btnCargarFoto_Click;
            //
            // btnQuitarFoto
            //
            btnQuitarFoto.Location = new Point(565, 113);
            btnQuitarFoto.Name = "btnQuitarFoto";
            btnQuitarFoto.Size = new Size(165, 38);
            btnQuitarFoto.TabIndex = 10;
            btnQuitarFoto.Text = "Quitar foto";
            btnQuitarFoto.Click += btnQuitarFoto_Click;
            //
            // lblObservaciones
            //
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 9.5F);
            lblObservaciones.ForeColor = Color.FromArgb(230, 238, 252);
            lblObservaciones.Location = new Point(400, 190);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(115, 21);
            lblObservaciones.TabIndex = 21;
            lblObservaciones.Text = "Observaciones:";
            //
            // txtObservaciones
            //
            txtObservaciones.AcceptsReturn = true;
            txtObservaciones.BackColor = Color.FromArgb(15, 42, 79);
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.Font = new Font("Segoe UI", 10F);
            txtObservaciones.ForeColor = Color.FromArgb(230, 238, 252);
            txtObservaciones.Location = new Point(400, 213);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(330, 145);
            txtObservaciones.TabIndex = 11;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(btnGuardar);
            panelPie.Controls.Add(btnCancelar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 482);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(760, 70);
            panelPie.TabIndex = 2;
            //
            // btnGuardar
            //
            btnGuardar.Estilo = EstiloBoton.Primario;
            btnGuardar.Location = new Point(509, 14);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 43);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(627, 14);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 43);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            //
            // FrmSocioModal
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(760, 552);
            Controls.Add(panelCampos);
            Controls.Add(panelPie);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSocioModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Socio";
            Load += FrmSocioModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCampos.ResumeLayout(false);
            panelCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
            panelPie.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelCampos;
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
        private Label lblFechaNacimiento;       
        private DateTimePicker dtpFechaNacimiento; 
        private CheckBox chkActivo;
        private PictureBox picFoto;
        private BotonTema btnTomarFoto;
        private BotonTema btnCargarFoto;
        private BotonTema btnQuitarFoto;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Panel panelPie;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}