namespace Presentacion.Forms.Reportes
{
    partial class FrmVisitasReporte
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
            panelTop = new Panel();
            lblTotal = new Label();
            btnLimpiarFiltros = new Button();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            lblTitulo = new Label();
            lblFechaInicio = new Label();
            lblFechaFin = new Label();
            btnFiltrar = new Button();
            btnEliminarFisico = new Button();
            btnExportarExcel = new Button();
            dgvVisitas = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(lblTotal);
            panelTop.Controls.Add(btnLimpiarFiltros);
            panelTop.Controls.Add(dtpFechaFin);
            panelTop.Controls.Add(dtpFechaInicio);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblFechaInicio);
            panelTop.Controls.Add(lblFechaFin);
            panelTop.Controls.Add(btnFiltrar);
            panelTop.Controls.Add(btnEliminarFisico);
            panelTop.Controls.Add(btnExportarExcel);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 155);
            panelTop.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.AutoEllipsis = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotal.Location = new Point(77, 108);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(313, 25);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total: $0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Anchor = AnchorStyles.Left;
            btnLimpiarFiltros.BackColor = Color.FromArgb(11, 15, 26);
            btnLimpiarFiltros.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = Color.FromArgb(230, 238, 252);
            btnLimpiarFiltros.Location = new Point(500, 61);
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
            lblTitulo.Size = new Size(599, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de visitas casuales en un rango de fechas";
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
            btnFiltrar.Location = new Point(399, 59);
            btnFiltrar.Margin = new Padding(3, 4, 3, 4);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(90, 38);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnEliminarFisico
            // 
            btnEliminarFisico.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminarFisico.BackColor = Color.FromArgb(11, 15, 26);
            btnEliminarFisico.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnEliminarFisico.FlatStyle = FlatStyle.Flat;
            btnEliminarFisico.Font = new Font("Segoe UI", 9F);
            btnEliminarFisico.ForeColor = Color.FromArgb(230, 238, 252);
            btnEliminarFisico.Location = new Point(600, 61);
            btnEliminarFisico.Margin = new Padding(3, 4, 3, 4);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(110, 38);
            btnEliminarFisico.TabIndex = 6;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.UseVisualStyleBackColor = false;
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportarExcel.BackColor = Color.FromArgb(31, 111, 235);
            btnExportarExcel.FlatAppearance.BorderSize = 0;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(718, 61);
            btnExportarExcel.Margin = new Padding(3, 4, 3, 4);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(150, 38);
            btnExportarExcel.TabIndex = 7;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // dgvVisitas
            // 
            dgvVisitas.AllowUserToAddRows = false;
            dgvVisitas.AllowUserToDeleteRows = false;
            dgvVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisitas.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvVisitas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVisitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVisitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvVisitas.DefaultCellStyle = dataGridViewCellStyle2;
            dgvVisitas.Dock = DockStyle.Fill;
            dgvVisitas.EnableHeadersVisualStyles = false;
            dgvVisitas.GridColor = Color.FromArgb(15, 42, 79);
            dgvVisitas.Location = new Point(0, 155);
            dgvVisitas.Margin = new Padding(3, 4, 3, 4);
            dgvVisitas.MultiSelect = false;
            dgvVisitas.Name = "dgvVisitas";
            dgvVisitas.ReadOnly = true;
            dgvVisitas.RowHeadersVisible = false;
            dgvVisitas.RowHeadersWidth = 51;
            dgvVisitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisitas.Size = new Size(914, 645);
            dgvVisitas.TabIndex = 1;
            // 
            // FrmVisitasReporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvVisitas);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmVisitasReporte";
            Text = "Visitas Casuales";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblFechaInicio;
        private Label lblFechaFin;
        private Button btnFiltrar;
        private Button btnEliminarFisico;
        private Button btnExportarExcel;
        private DataGridView dgvVisitas;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Button btnLimpiarFiltros;
        private Label lblTotal;
    }
}