namespace Presentacion.Forms.Reportes
{
    partial class FrmRegistrosReporte
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
            btnExportarExcel = new Button();
            btnLimpiarFiltros = new Button();
            btnFiltrar = new Button();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            lblTitulo = new Label();
            dgvRegistros = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(lblTotal);
            panelTop.Controls.Add(btnExportarExcel);
            panelTop.Controls.Add(btnLimpiarFiltros);
            panelTop.Controls.Add(btnFiltrar);
            panelTop.Controls.Add(dtpFecha);
            panelTop.Controls.Add(lblFecha);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 110);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(340, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de registro de visitas";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F);
            lblFecha.ForeColor = Color.FromArgb(230, 238, 252);
            lblFecha.Location = new Point(20, 68);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Anchor = AnchorStyles.Left;
            dtpFecha.Font = new Font("Segoe UI", 9F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(75, 64);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(130, 27);
            dtpFecha.TabIndex = 2;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(31, 111, 235);
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(220, 59);
            btnFiltrar.Margin = new Padding(3, 4, 3, 4);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(90, 38);
            btnFiltrar.TabIndex = 3;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Anchor = AnchorStyles.Left;
            btnLimpiarFiltros.BackColor = Color.FromArgb(11, 15, 26);
            btnLimpiarFiltros.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = Color.FromArgb(230, 238, 252);
            btnLimpiarFiltros.Location = new Point(318, 59);
            btnLimpiarFiltros.Margin = new Padding(8, 0, 0, 0);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(90, 38);
            btnLimpiarFiltros.TabIndex = 4;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotal.Location = new Point(540, 68);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(155, 25);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total Visitas: 0";
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportarExcel.BackColor = Color.FromArgb(31, 111, 235);
            btnExportarExcel.FlatAppearance.BorderSize = 0;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(752, 60);
            btnExportarExcel.Margin = new Padding(3, 4, 3, 4);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(150, 38);
            btnExportarExcel.TabIndex = 6;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // dgvRegistros
            // 
            dgvRegistros.AllowUserToAddRows = false;
            dgvRegistros.AllowUserToDeleteRows = false;
            dgvRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegistros.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvRegistros.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRegistros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRegistros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRegistros.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRegistros.Dock = DockStyle.Fill;
            dgvRegistros.EnableHeadersVisualStyles = false;
            dgvRegistros.GridColor = Color.FromArgb(15, 42, 79);
            dgvRegistros.Location = new Point(0, 110);
            dgvRegistros.Margin = new Padding(3, 4, 3, 4);
            dgvRegistros.MultiSelect = false;
            dgvRegistros.Name = "dgvRegistros";
            dgvRegistros.ReadOnly = true;
            dgvRegistros.RowHeadersVisible = false;
            dgvRegistros.RowHeadersWidth = 51;
            dgvRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistros.Size = new Size(914, 690);
            dgvRegistros.TabIndex = 1;
            // 
            // FrmRegistrosReporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvRegistros);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmRegistrosReporte";
            Text = "Registro de Visitas";
            Load += FrmRegistrosReporte_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Button btnFiltrar;
        private Button btnLimpiarFiltros;
        private Label lblTotal;
        private Button btnExportarExcel;
        private DataGridView dgvRegistros;
    }
}