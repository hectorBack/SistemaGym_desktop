namespace Presentacion.Forms.Visitas
{
    partial class FrmVisitaModal
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
            lblMembresia = new Label();
            cmbMembresias = new ComboBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
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
            panelHeader.Size = new Size(420, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(100, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nueva Visita";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblClave.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblClave.Location = new Point(25, 65);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(174, 17);
            lblClave.TabIndex = 1;
            lblClave.Text = "Clave Socio (\"100\" p/ casual):";
            // 
            // txtClave
            // 
            txtClave.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtClave.Location = new Point(25, 85);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(370, 25);
            txtClave.TabIndex = 2;
            txtClave.TextChanged += txtClave_TextChanged;
            // 
            // lblMembresia
            // 
            lblMembresia.AutoSize = true;
            lblMembresia.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblMembresia.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblMembresia.Location = new Point(25, 120);
            lblMembresia.Name = "lblMembresia";
            lblMembresia.Size = new Size(130, 17);
            lblMembresia.TabIndex = 3;
            lblMembresia.Text = "Membresía / Pase:";
            // 
            // cmbMembresias
            // 
            cmbMembresias.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            cmbMembresias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMembresias.FlatStyle = FlatStyle.Flat;
            cmbMembresias.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbMembresias.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            cmbMembresias.FormattingEnabled = true;
            cmbMembresias.Location = new Point(25, 140);
            cmbMembresias.Name = "cmbMembresias";
            cmbMembresias.Size = new Size(370, 25);
            cmbMembresias.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblNombre.Location = new Point(25, 175);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(60, 17);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtNombre.Location = new Point(25, 195);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(180, 25);
            txtNombre.TabIndex = 6;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblApellido.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblApellido.Location = new Point(215, 175);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(59, 17);
            lblApellido.TabIndex = 7;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtApellido.Location = new Point(215, 195);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(180, 25);
            txtApellido.TabIndex = 8;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefono.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTelefono.Location = new Point(25, 230);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(61, 17);
            lblTelefono.TabIndex = 9;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtTelefono.Location = new Point(25, 250);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(370, 25);
            txtTelefono.TabIndex = 10;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblObservaciones.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblObservaciones.Location = new Point(25, 285);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(97, 17);
            lblObservaciones.TabIndex = 11;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtObservaciones.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtObservaciones.Location = new Point(25, 305);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(370, 60);
            txtObservaciones.TabIndex = 12;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            chkActivo.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            chkActivo.Location = new Point(25, 380);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(62, 21);
            chkActivo.TabIndex = 13;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Location = new Point(205, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 14;
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
            btnCancelar.Location = new Point(305, 415);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmVisitaModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(420, 470);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkActivo);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(cmbMembresias);
            Controls.Add(lblMembresia);
            Controls.Add(txtClave);
            Controls.Add(lblClave);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVisitaModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Visita";
            Load += FrmVisitaModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblClave;
        private TextBox txtClave;
        private Label lblMembresia;
        private ComboBox cmbMembresias;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}