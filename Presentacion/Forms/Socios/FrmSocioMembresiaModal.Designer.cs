namespace Presentacion.Forms.Socios
{
    partial class FrmSocioMembresiaModal
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitulo = new Label();
            grpDetallesSocio = new GroupBox();
            picFotoSocio = new PictureBox();
            lblNombreSocio = new Label();
            lblTelHeader = new Label();
            lblTelefono = new Label();
            lblObsHeader = new Label();
            txtObservaciones = new TextBox();
            grpAsignarMembresia = new GroupBox();
            lblMembresia = new Label();
            cboMembresias = new ComboBox();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblPrecio = new Label();
            lblPrecioValor = new Label();
            btnAgregarMembresia = new Button();
            dgvHistorial = new DataGridView();
            btnPagarMembresia = new Button();
            btnEliminarMembresia = new Button();
            panelHeader.SuspendLayout();
            grpDetallesSocio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFotoSocio).BeginInit();
            grpAsignarMembresia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(914, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(274, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Membresías del Socio";
            // 
            // grpDetallesSocio
            // 
            grpDetallesSocio.Controls.Add(picFotoSocio);
            grpDetallesSocio.Controls.Add(lblNombreSocio);
            grpDetallesSocio.Controls.Add(lblTelHeader);
            grpDetallesSocio.Controls.Add(lblTelefono);
            grpDetallesSocio.Controls.Add(lblObsHeader);
            grpDetallesSocio.Controls.Add(txtObservaciones);
            grpDetallesSocio.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpDetallesSocio.ForeColor = Color.FromArgb(45, 212, 255);
            grpDetallesSocio.Location = new Point(23, 80);
            grpDetallesSocio.Margin = new Padding(3, 4, 3, 4);
            grpDetallesSocio.Name = "grpDetallesSocio";
            grpDetallesSocio.Padding = new Padding(3, 4, 3, 4);
            grpDetallesSocio.Size = new Size(869, 187);
            grpDetallesSocio.TabIndex = 1;
            grpDetallesSocio.TabStop = false;
            grpDetallesSocio.Text = "Detalles del Socio";
            // 
            // picFotoSocio
            // 
            picFotoSocio.BorderStyle = BorderStyle.FixedSingle;
            picFotoSocio.Location = new Point(17, 33);
            picFotoSocio.Margin = new Padding(3, 4, 3, 4);
            picFotoSocio.Name = "picFotoSocio";
            picFotoSocio.Size = new Size(114, 133);
            picFotoSocio.SizeMode = PictureBoxSizeMode.Zoom;
            picFotoSocio.TabIndex = 0;
            picFotoSocio.TabStop = false;
            // 
            // lblNombreSocio
            // 
            lblNombreSocio.AutoSize = true;
            lblNombreSocio.Font = new Font("Microsoft Sans Serif", 12F);
            lblNombreSocio.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombreSocio.Location = new Point(149, 33);
            lblNombreSocio.Name = "lblNombreSocio";
            lblNombreSocio.Size = new Size(167, 25);
            lblNombreSocio.TabIndex = 1;
            lblNombreSocio.Text = "Nombre del Socio";
            // 
            // lblTelHeader
            // 
            lblTelHeader.AutoSize = true;
            lblTelHeader.Font = new Font("Segoe UI", 9F);
            lblTelHeader.ForeColor = Color.FromArgb(230, 238, 252);
            lblTelHeader.Location = new Point(149, 73);
            lblTelHeader.Name = "lblTelHeader";
            lblTelHeader.Size = new Size(70, 20);
            lblTelHeader.TabIndex = 2;
            lblTelHeader.Text = "Teléfono:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(230, 238, 252);
            lblTelefono.Location = new Point(217, 73);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(99, 20);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "0000000000";
            // 
            // lblObsHeader
            // 
            lblObsHeader.AutoSize = true;
            lblObsHeader.Font = new Font("Segoe UI", 9F);
            lblObsHeader.ForeColor = Color.FromArgb(230, 238, 252);
            lblObsHeader.Location = new Point(149, 107);
            lblObsHeader.Name = "lblObsHeader";
            lblObsHeader.Size = new Size(108, 20);
            lblObsHeader.TabIndex = 4;
            lblObsHeader.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = Color.FromArgb(11, 15, 26);
            txtObservaciones.BorderStyle = BorderStyle.None;
            txtObservaciones.Font = new Font("Segoe UI", 8.5F);
            txtObservaciones.ForeColor = Color.FromArgb(230, 238, 252);
            txtObservaciones.Location = new Point(251, 107);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ReadOnly = true;
            txtObservaciones.Size = new Size(594, 60);
            txtObservaciones.TabIndex = 5;
            // 
            // grpAsignarMembresia
            // 
            grpAsignarMembresia.Controls.Add(lblMembresia);
            grpAsignarMembresia.Controls.Add(cboMembresias);
            grpAsignarMembresia.Controls.Add(lblFechaInicio);
            grpAsignarMembresia.Controls.Add(dtpFechaInicio);
            grpAsignarMembresia.Controls.Add(lblPrecio);
            grpAsignarMembresia.Controls.Add(lblPrecioValor);
            grpAsignarMembresia.Controls.Add(btnAgregarMembresia);
            grpAsignarMembresia.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpAsignarMembresia.ForeColor = Color.FromArgb(45, 212, 255);
            grpAsignarMembresia.Location = new Point(23, 280);
            grpAsignarMembresia.Margin = new Padding(3, 4, 3, 4);
            grpAsignarMembresia.Name = "grpAsignarMembresia";
            grpAsignarMembresia.Padding = new Padding(3, 4, 3, 4);
            grpAsignarMembresia.Size = new Size(869, 120);
            grpAsignarMembresia.TabIndex = 2;
            grpAsignarMembresia.TabStop = false;
            grpAsignarMembresia.Text = "Asignar Nueva Membresía";
            // 
            // lblMembresia
            // 
            lblMembresia.AutoSize = true;
            lblMembresia.Font = new Font("Segoe UI", 8.5F);
            lblMembresia.ForeColor = Color.FromArgb(230, 238, 252);
            lblMembresia.Location = new Point(17, 33);
            lblMembresia.Name = "lblMembresia";
            lblMembresia.Size = new Size(86, 20);
            lblMembresia.TabIndex = 0;
            lblMembresia.Text = "Membresía:";
            // 
            // cboMembresias
            // 
            cboMembresias.BackColor = Color.FromArgb(15, 42, 79);
            cboMembresias.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMembresias.FlatStyle = FlatStyle.Flat;
            cboMembresias.Font = new Font("Segoe UI", 9F);
            cboMembresias.ForeColor = Color.FromArgb(230, 238, 252);
            cboMembresias.FormattingEnabled = true;
            cboMembresias.Location = new Point(17, 60);
            cboMembresias.Margin = new Padding(3, 4, 3, 4);
            cboMembresias.Name = "cboMembresias";
            cboMembresias.Size = new Size(239, 28);
            cboMembresias.TabIndex = 1;
            cboMembresias.SelectedIndexChanged += cboMembresias_SelectedIndexChanged;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI", 8.5F);
            lblFechaInicio.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaInicio.Location = new Point(274, 33);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(90, 20);
            lblFechaInicio.TabIndex = 2;
            lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.CalendarMonthBackground = Color.FromArgb(15, 42, 79);
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(274, 60);
            dtpFechaInicio.Margin = new Padding(3, 4, 3, 4);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(148, 27);
            dtpFechaInicio.TabIndex = 3;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 8.5F);
            lblPrecio.ForeColor = Color.FromArgb(230, 238, 252);
            lblPrecio.Location = new Point(440, 33);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio:";
            // 
            // lblPrecioValor
            // 
            lblPrecioValor.AutoSize = true;
            lblPrecioValor.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblPrecioValor.ForeColor = Color.FromArgb(45, 212, 255);
            lblPrecioValor.Location = new Point(440, 61);
            lblPrecioValor.Name = "lblPrecioValor";
            lblPrecioValor.Size = new Size(60, 24);
            lblPrecioValor.TabIndex = 5;
            lblPrecioValor.Text = "$0.00";
            // 
            // btnAgregarMembresia
            // 
            btnAgregarMembresia.BackColor = Color.FromArgb(31, 111, 235);
            btnAgregarMembresia.FlatAppearance.BorderSize = 0;
            btnAgregarMembresia.FlatStyle = FlatStyle.Flat;
            btnAgregarMembresia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAgregarMembresia.ForeColor = Color.White;
            btnAgregarMembresia.Location = new Point(588, 51);
            btnAgregarMembresia.Margin = new Padding(3, 4, 3, 4);
            btnAgregarMembresia.Name = "btnAgregarMembresia";
            btnAgregarMembresia.Size = new Size(257, 37);
            btnAgregarMembresia.TabIndex = 6;
            btnAgregarMembresia.Text = "+ Agregar Membresía";
            btnAgregarMembresia.UseVisualStyleBackColor = false;
            btnAgregarMembresia.Click += btnAgregarMembresia_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvHistorial.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistorial.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvHistorial.DefaultCellStyle = dataGridViewCellStyle2;
            dgvHistorial.EnableHeadersVisualStyles = false;
            dgvHistorial.GridColor = Color.FromArgb(15, 42, 79);
            dgvHistorial.Location = new Point(23, 465);
            dgvHistorial.Margin = new Padding(3, 4, 3, 4);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(869, 267);
            dgvHistorial.TabIndex = 3;
            // 
            // btnPagarMembresia
            // 
            btnPagarMembresia.BackColor = Color.FromArgb(46, 125, 50);
            btnPagarMembresia.FlatAppearance.BorderSize = 0;
            btnPagarMembresia.FlatStyle = FlatStyle.Flat;
            btnPagarMembresia.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnPagarMembresia.ForeColor = Color.White;
            btnPagarMembresia.Location = new Point(444, 408);
            btnPagarMembresia.Margin = new Padding(3, 4, 3, 4);
            btnPagarMembresia.Name = "btnPagarMembresia";
            btnPagarMembresia.Size = new Size(245, 35);
            btnPagarMembresia.TabIndex = 4;
            btnPagarMembresia.Text = "+ Pagar Membresia";
            btnPagarMembresia.UseVisualStyleBackColor = false;
            btnPagarMembresia.Click += btnPagarMembresia_Click;
            // 
            // btnEliminarMembresia
            // 
            btnEliminarMembresia.BackColor = ColorTranslator.FromHtml("#c62828");
            btnEliminarMembresia.FlatAppearance.BorderSize = 0;
            btnEliminarMembresia.FlatStyle = FlatStyle.Flat;
            btnEliminarMembresia.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnEliminarMembresia.ForeColor = Color.White;
            btnEliminarMembresia.Location = new Point(712, 408);
            btnEliminarMembresia.Margin = new Padding(3, 4, 3, 4);
            btnEliminarMembresia.Name = "btnEliminarMembresia";
            btnEliminarMembresia.Size = new Size(180, 35);
            btnEliminarMembresia.TabIndex = 5;
            btnEliminarMembresia.Text = "Eliminar";
            btnEliminarMembresia.UseVisualStyleBackColor = false;
            btnEliminarMembresia.Click += btnEliminarMembresia_Click;
            // 
            // FrmSocioMembresiaModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 773);
            Controls.Add(btnEliminarMembresia);
            Controls.Add(btnPagarMembresia);
            Controls.Add(dgvHistorial);
            Controls.Add(grpAsignarMembresia);
            Controls.Add(grpDetallesSocio);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSocioMembresiaModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Membresía de Socio";
            Load += FrmSocioMembresiaModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpDetallesSocio.ResumeLayout(false);
            grpDetallesSocio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picFotoSocio).EndInit();
            grpAsignarMembresia.ResumeLayout(false);
            grpAsignarMembresia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private GroupBox grpDetallesSocio;
        private PictureBox picFotoSocio;
        private Label lblNombreSocio;
        private Label lblTelHeader;
        private Label lblTelefono;
        private Label lblObsHeader;
        private TextBox txtObservaciones;
        private GroupBox grpAsignarMembresia;
        private Label lblMembresia;
        private ComboBox cboMembresias;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaInicio;
        private Label lblPrecio;
        private Label lblPrecioValor;
        private Button btnAgregarMembresia;
        private DataGridView dgvHistorial;
        private Button btnPagarMembresia;
        private Button btnEliminarMembresia;
    }
}