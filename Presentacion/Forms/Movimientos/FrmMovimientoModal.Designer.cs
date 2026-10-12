namespace Presentacion.Forms.Movimientos
{
    partial class FrmMovimientoModal
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
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblConcepto = new Label();
            lblSinConceptos = new Label();
            cmbConcepto = new ComboBox();
            lblFormaPago = new Label();
            cmbFormaPago = new ComboBox();
            lblTotal = new Label();
            numTotal = new NumericUpDown();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTotal).BeginInit();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
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
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(150, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Movimiento";
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipo.ForeColor = Color.FromArgb(230, 238, 252);
            lblTipo.Location = new Point(25, 65);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(125, 17);
            lblTipo.TabIndex = 1;
            lblTipo.Text = "Tipo de Movimiento:";
            //
            // cmbTipo
            //
            cmbTipo.BackColor = Color.FromArgb(15, 42, 79);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FlatStyle = FlatStyle.Flat;
            cmbTipo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTipo.ForeColor = Color.FromArgb(230, 238, 252);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(25, 85);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(370, 25);
            cmbTipo.TabIndex = 2;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            //
            // lblConcepto
            //
            lblConcepto.AutoSize = true;
            lblConcepto.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblConcepto.ForeColor = Color.FromArgb(230, 238, 252);
            lblConcepto.Location = new Point(25, 120);
            lblConcepto.Name = "lblConcepto";
            lblConcepto.Size = new Size(66, 17);
            lblConcepto.TabIndex = 3;
            lblConcepto.Text = "Concepto:";
            //
            // lblSinConceptos
            //
            lblSinConceptos.AutoSize = true;
            lblSinConceptos.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSinConceptos.ForeColor = Color.FromArgb(210, 153, 34);
            lblSinConceptos.Location = new Point(100, 121);
            lblSinConceptos.Name = "lblSinConceptos";
            lblSinConceptos.Size = new Size(260, 15);
            lblSinConceptos.TabIndex = 13;
            lblSinConceptos.Text = "No hay conceptos activos de este tipo";
            lblSinConceptos.Visible = false;
            //
            // cmbConcepto
            //
            cmbConcepto.BackColor = Color.FromArgb(15, 42, 79);
            cmbConcepto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConcepto.FlatStyle = FlatStyle.Flat;
            cmbConcepto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbConcepto.ForeColor = Color.FromArgb(230, 238, 252);
            cmbConcepto.FormattingEnabled = true;
            cmbConcepto.Location = new Point(25, 140);
            cmbConcepto.Name = "cmbConcepto";
            cmbConcepto.Size = new Size(370, 25);
            cmbConcepto.TabIndex = 4;
            //
            // lblFormaPago
            //
            lblFormaPago.AutoSize = true;
            lblFormaPago.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblFormaPago.ForeColor = Color.FromArgb(230, 238, 252);
            lblFormaPago.Location = new Point(25, 175);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(101, 17);
            lblFormaPago.TabIndex = 5;
            lblFormaPago.Text = "Forma de Pago:";
            //
            // cmbFormaPago
            //
            cmbFormaPago.BackColor = Color.FromArgb(15, 42, 79);
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPago.FlatStyle = FlatStyle.Flat;
            cmbFormaPago.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFormaPago.ForeColor = Color.FromArgb(230, 238, 252);
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(25, 195);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(370, 25);
            cmbFormaPago.TabIndex = 6;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotal.Location = new Point(25, 230);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(80, 17);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Monto Total:";
            //
            // numTotal
            //
            numTotal.BackColor = Color.FromArgb(15, 42, 79);
            numTotal.BorderStyle = BorderStyle.FixedSingle;
            numTotal.DecimalPlaces = 2;
            numTotal.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numTotal.ForeColor = Color.FromArgb(230, 238, 252);
            numTotal.Location = new Point(25, 250);
            numTotal.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numTotal.Name = "numTotal";
            numTotal.Size = new Size(370, 25);
            numTotal.TabIndex = 8;
            numTotal.TextAlign = HorizontalAlignment.Right;
            numTotal.ThousandsSeparator = true;
            numTotal.Enter += numTotal_Enter;
            //
            // lblObservacion
            //
            lblObservacion.AutoSize = true;
            lblObservacion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblObservacion.ForeColor = Color.FromArgb(230, 238, 252);
            lblObservacion.Location = new Point(25, 285);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(160, 17);
            lblObservacion.TabIndex = 9;
            lblObservacion.Text = "Observaciones (Opcional):";
            //
            // txtObservacion
            //
            txtObservacion.AcceptsReturn = true; // Enter escribe un salto de línea en lugar de pulsar "Guardar"
            txtObservacion.BackColor = Color.FromArgb(15, 42, 79);
            txtObservacion.BorderStyle = BorderStyle.FixedSingle;
            txtObservacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtObservacion.ForeColor = Color.FromArgb(230, 238, 252);
            txtObservacion.Location = new Point(25, 305);
            txtObservacion.MaxLength = 250;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.ScrollBars = ScrollBars.Vertical;
            txtObservacion.Size = new Size(370, 60);
            txtObservacion.TabIndex = 10;
            //
            // btnGuardar
            //
            btnGuardar.Enabled = false;
            btnGuardar.Estilo = EstiloBoton.Primario;
            btnGuardar.Location = new Point(205, 385);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(305, 385);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            //
            // FrmMovimientoModal
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(420, 435);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservacion);
            Controls.Add(lblObservacion);
            Controls.Add(numTotal);
            Controls.Add(lblTotal);
            Controls.Add(cmbFormaPago);
            Controls.Add(lblFormaPago);
            Controls.Add(cmbConcepto);
            Controls.Add(lblSinConceptos);
            Controls.Add(lblConcepto);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMovimientoModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Movimiento";
            Load += FrmMovimientoModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTotal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblConcepto;
        private Label lblSinConceptos;
        private ComboBox cmbConcepto;
        private Label lblFormaPago;
        private ComboBox cmbFormaPago;
        private Label lblTotal;
        private NumericUpDown numTotal;
        private Label lblObservacion;
        private TextBox txtObservacion;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}