namespace Presentacion.Forms.Membresias
{
    partial class FrmMembresiaModal
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
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            numPrecio = new NumericUpDown();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblMeses = new Label();
            numMeses = new NumericUpDown();
            lblSemanas = new Label();
            numSemanas = new NumericUpDown();
            lblDias = new Label();
            numDias = new NumericUpDown();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSemanas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDias).BeginInit();
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
            lblTitulo.Size = new Size(134, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nueva Membresía";
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombre.Location = new Point(25, 65);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(125, 17);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre Membresía:";
            //
            // txtNombre
            //
            txtNombre.BackColor = Color.FromArgb(15, 42, 79);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.ForeColor = Color.FromArgb(230, 238, 252);
            txtNombre.Location = new Point(25, 85);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(330, 25);
            txtNombre.TabIndex = 2;
            //
            // lblPrecio
            //
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrecio.ForeColor = Color.FromArgb(230, 238, 252);
            lblPrecio.Location = new Point(25, 125);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(47, 17);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "Precio:";
            //
            // numPrecio
            //
            numPrecio.BackColor = Color.FromArgb(15, 42, 79);
            numPrecio.BorderStyle = BorderStyle.FixedSingle;
            numPrecio.DecimalPlaces = 2;
            numPrecio.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numPrecio.ForeColor = Color.FromArgb(230, 238, 252);
            numPrecio.Location = new Point(25, 145);
            numPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(330, 25);
            numPrecio.TabIndex = 4;
            numPrecio.ThousandsSeparator = true;
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipo.ForeColor = Color.FromArgb(230, 238, 252);
            lblTipo.Location = new Point(25, 185);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(36, 17);
            lblTipo.TabIndex = 5;
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
            cmbTipo.Location = new Point(25, 205);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(330, 25);
            cmbTipo.TabIndex = 6;
            //
            // lblMeses
            //
            lblMeses.AutoSize = true;
            lblMeses.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblMeses.ForeColor = Color.FromArgb(230, 238, 252);
            lblMeses.Location = new Point(25, 245);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(46, 17);
            lblMeses.TabIndex = 7;
            lblMeses.Text = "Meses:";
            //
            // numMeses
            //
            numMeses.BackColor = Color.FromArgb(15, 42, 79);
            numMeses.BorderStyle = BorderStyle.FixedSingle;
            numMeses.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numMeses.ForeColor = Color.FromArgb(230, 238, 252);
            numMeses.Location = new Point(25, 265);
            numMeses.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numMeses.Name = "numMeses";
            numMeses.Size = new Size(330, 25);
            numMeses.TabIndex = 8;
            //
            // lblSemanas
            //
            lblSemanas.AutoSize = true;
            lblSemanas.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSemanas.ForeColor = Color.FromArgb(230, 238, 252);
            lblSemanas.Location = new Point(25, 305);
            lblSemanas.Name = "lblSemanas";
            lblSemanas.Size = new Size(62, 17);
            lblSemanas.TabIndex = 9;
            lblSemanas.Text = "Semanas:";
            //
            // numSemanas
            //
            numSemanas.BackColor = Color.FromArgb(15, 42, 79);
            numSemanas.BorderStyle = BorderStyle.FixedSingle;
            numSemanas.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numSemanas.ForeColor = Color.FromArgb(230, 238, 252);
            numSemanas.Location = new Point(25, 325);
            numSemanas.Maximum = new decimal(new int[] { 52, 0, 0, 0 });
            numSemanas.Name = "numSemanas";
            numSemanas.Size = new Size(330, 25);
            numSemanas.TabIndex = 10;
            //
            // lblDias
            //
            lblDias.AutoSize = true;
            lblDias.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblDias.ForeColor = Color.FromArgb(230, 238, 252);
            lblDias.Location = new Point(25, 365);
            lblDias.Name = "lblDias";
            lblDias.Size = new Size(34, 17);
            lblDias.TabIndex = 11;
            lblDias.Text = "Días:";
            //
            // numDias
            //
            numDias.BackColor = Color.FromArgb(15, 42, 79);
            numDias.BorderStyle = BorderStyle.FixedSingle;
            numDias.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numDias.ForeColor = Color.FromArgb(230, 238, 252);
            numDias.Location = new Point(25, 385);
            numDias.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numDias.Name = "numDias";
            numDias.Size = new Size(330, 25);
            numDias.TabIndex = 12;
            //
            // btnGuardar
            //
            btnGuardar.Estilo = EstiloBoton.Primario;
            btnGuardar.Location = new Point(165, 435);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(265, 435);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            //
            // FrmMembresiaModal
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(380, 490);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(numDias);
            Controls.Add(lblDias);
            Controls.Add(numSemanas);
            Controls.Add(lblSemanas);
            Controls.Add(numMeses);
            Controls.Add(lblMeses);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(numPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMembresiaModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Membresía";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMeses).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSemanas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPrecio;
        private NumericUpDown numPrecio;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblMeses;
        private NumericUpDown numMeses;
        private Label lblSemanas;
        private NumericUpDown numSemanas;
        private Label lblDias;
        private NumericUpDown numDias;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}