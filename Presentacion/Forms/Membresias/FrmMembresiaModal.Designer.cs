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
            lblDuracionDias = new Label();
            numDuracionDias = new NumericUpDown();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuracionDias).BeginInit();
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
            // lblDuracionDias
            //
            lblDuracionDias.AutoSize = true;
            lblDuracionDias.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblDuracionDias.ForeColor = Color.FromArgb(230, 238, 252);
            lblDuracionDias.Location = new Point(25, 185);
            lblDuracionDias.Name = "lblDuracionDias";
            lblDuracionDias.Size = new Size(100, 17);
            lblDuracionDias.TabIndex = 5;
            lblDuracionDias.Text = "Duración (Días):";
            //
            // numDuracionDias
            //
            numDuracionDias.BackColor = Color.FromArgb(15, 42, 79);
            numDuracionDias.BorderStyle = BorderStyle.FixedSingle;
            numDuracionDias.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numDuracionDias.ForeColor = Color.FromArgb(230, 238, 252);
            numDuracionDias.Location = new Point(25, 205);
            numDuracionDias.Maximum = new decimal(new int[] { 3650, 0, 0, 0 });
            numDuracionDias.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuracionDias.Name = "numDuracionDias";
            numDuracionDias.Size = new Size(330, 25);
            numDuracionDias.TabIndex = 6;
            numDuracionDias.Value = new decimal(new int[] { 30, 0, 0, 0 });
            //
            // btnGuardar
            //
            btnGuardar.Estilo = EstiloBoton.Primario;
            btnGuardar.Location = new Point(165, 255);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(265, 255);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            //
            // FrmMembresiaModal
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(380, 310);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(numDuracionDias);
            Controls.Add(lblDuracionDias);
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
            ((System.ComponentModel.ISupportInitialize)numDuracionDias).EndInit();
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
        private Label lblDuracionDias;
        private NumericUpDown numDuracionDias;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}