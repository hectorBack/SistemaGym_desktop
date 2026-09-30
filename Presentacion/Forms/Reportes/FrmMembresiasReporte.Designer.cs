namespace Presentacion.Forms.Reportes
{
    partial class FrmMembresiasReporte
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelTop = new Panel();
            btnLimpiarFiltros = new Button();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            lblTitulo = new Label();
            lblFechaInicio = new Label();
            lblFechaFin = new Label();
            btnFiltrar = new Button();
            btnExportarExcel = new Button();
            dgvMembresias = new DataGridView();
            panelBottom = new Panel();
            lblReporteInfo = new Label();
            lblTotal = new Label();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(btnLimpiarFiltros);
            panelTop.Controls.Add(dtpFechaFin);
            panelTop.Controls.Add(dtpFechaInicio);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblFechaInicio);
            panelTop.Controls.Add(lblFechaFin);
            panelTop.Controls.Add(btnFiltrar);
            panelTop.Controls.Add(btnExportarExcel);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 110);
            panelTop.TabIndex = 0;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Anchor = AnchorStyles.Left;
            btnLimpiarFiltros.BackColor = Color.FromArgb(11, 15, 26);
            btnLimpiarFiltros.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = Color.FromArgb(230, 238, 252);
            btnLimpiarFiltros.Location = new Point(511, 61);
            btnLimpiarFiltros.Margin = new Padding(8, 0, 0, 0);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(90, 38);
            btnLimpiarFiltros.TabIndex = 10;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Anchor = AnchorStyles.Left;
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(265, 65);
            dtpFechaFin.Margin = new Padding(0, 0, 17, 0);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(125, 27);
            dtpFechaFin.TabIndex = 9;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Anchor = AnchorStyles.Left;
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(77, 65);
            dtpFechaInicio.Margin = new Padding(0, 0, 17, 0);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(125, 27);
            dtpFechaInicio.TabIndex = 8;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(671, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de membresías vendidas en un rango de fechas";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI", 9F);
            lblFechaInicio.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaInicio.Location = new Point(20, 68);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(54, 20);
            lblFechaInicio.TabIndex = 1;
            lblFechaInicio.Text = "Desde:";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Font = new Font("Segoe UI", 9F);
            lblFechaFin.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaFin.Location = new Point(215, 68);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(50, 20);
            lblFechaFin.TabIndex = 3;
            lblFechaFin.Text = "Hasta:";
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(31, 111, 235);
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(410, 60);
            btnFiltrar.Margin = new Padding(3, 4, 3, 4);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(90, 38);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportarExcel.BackColor = Color.FromArgb(31, 111, 235);
            btnExportarExcel.FlatAppearance.BorderSize = 0;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(734, 60);
            btnExportarExcel.Margin = new Padding(3, 4, 3, 4);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(150, 38);
            btnExportarExcel.TabIndex = 7;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // dgvMembresias
            // 
            dgvMembresias.AllowUserToAddRows = false;
            dgvMembresias.AllowUserToDeleteRows = false;
            dgvMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembresias.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvMembresias.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMembresias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle4.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvMembresias.DefaultCellStyle = dataGridViewCellStyle4;
            dgvMembresias.Dock = DockStyle.Fill;
            dgvMembresias.EnableHeadersVisualStyles = false;
            dgvMembresias.GridColor = Color.FromArgb(15, 42, 79);
            dgvMembresias.Location = new Point(0, 110);
            dgvMembresias.Margin = new Padding(3, 4, 3, 4);
            dgvMembresias.MultiSelect = false;
            dgvMembresias.Name = "dgvMembresias";
            dgvMembresias.ReadOnly = true;
            dgvMembresias.RowHeadersVisible = false;
            dgvMembresias.RowHeadersWidth = 51;
            dgvMembresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembresias.Size = new Size(914, 640);
            dgvMembresias.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(15, 42, 79);
            panelBottom.Controls.Add(lblReporteInfo);
            panelBottom.Controls.Add(lblTotal);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 750);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(914, 50);
            panelBottom.TabIndex = 2;
            // 
            // lblReporteInfo
            // 
            lblReporteInfo.AutoSize = true;
            lblReporteInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblReporteInfo.ForeColor = Color.FromArgb(230, 238, 252);
            lblReporteInfo.Location = new Point(20, 14);
            lblReporteInfo.Name = "lblReporteInfo";
            lblReporteInfo.Size = new Size(285, 23);
            lblReporteInfo.TabIndex = 0;
            lblReporteInfo.Text = "Membresías vendidas en el rango: 0";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotal.Location = new Point(734, 12);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(128, 25);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: $0.00";
            // 
            // FrmMembresiasReporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvMembresias);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMembresiasReporte";
            Text = "Membresías";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblFechaInicio;
        private Label lblFechaFin;
        private Button btnFiltrar;
        private Button btnExportarExcel;
        private DataGridView dgvMembresias;
        private Panel panelBottom;
        private Label lblReporteInfo;
        private Label lblTotal;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Button btnLimpiarFiltros;
    }
}