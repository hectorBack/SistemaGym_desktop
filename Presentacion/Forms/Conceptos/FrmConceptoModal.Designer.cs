namespace Presentacion.Forms.Conceptos
{
    partial class FrmConceptoModal
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
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
            lblTitulo.Size = new Size(125, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Concepto";
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombre.Location = new Point(25, 65);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(118, 17);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre Concepto:";
            //
            // txtNombre
            //
            txtNombre.BackColor = Color.FromArgb(15, 42, 79);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.ForeColor = Color.FromArgb(230, 238, 252);
            txtNombre.Location = new Point(25, 85);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(330, 25);
            txtNombre.TabIndex = 2;
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipo.ForeColor = Color.FromArgb(230, 238, 252);
            lblTipo.Location = new Point(25, 125);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(37, 17);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo:";
            //
            // cmbTipo
            //
            cmbTipo.BackColor = Color.FromArgb(15, 42, 79);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FlatStyle = FlatStyle.Flat;
            cmbTipo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTipo.ForeColor = Color.FromArgb(230, 238, 252);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(25, 145);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(330, 25);
            cmbTipo.TabIndex = 4;
            //
            // lblObservacion
            //
            lblObservacion.AutoSize = true;
            lblObservacion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblObservacion.ForeColor = Color.FromArgb(230, 238, 252);
            lblObservacion.Location = new Point(25, 185);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(83, 17);
            lblObservacion.TabIndex = 5;
            lblObservacion.Text = "Observación:";
            //
            // txtObservacion
            //
            txtObservacion.AcceptsReturn = true; // Enter escribe un salto de línea en lugar de pulsar "Guardar"
            txtObservacion.BackColor = Color.FromArgb(15, 42, 79);
            txtObservacion.BorderStyle = BorderStyle.FixedSingle;
            txtObservacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtObservacion.ForeColor = Color.FromArgb(230, 238, 252);
            txtObservacion.Location = new Point(25, 205);
            txtObservacion.MaxLength = 250;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.ScrollBars = ScrollBars.Vertical;
            txtObservacion.Size = new Size(330, 65);
            txtObservacion.TabIndex = 6;
            //
            // btnGuardar
            //
            btnGuardar.Estilo = EstiloBoton.Primario;
            btnGuardar.Location = new Point(165, 290);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(265, 290);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            //
            // FrmConceptoModal
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(380, 340);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservacion);
            Controls.Add(lblObservacion);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmConceptoModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Concepto";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblObservacion;
        private TextBox txtObservacion;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}