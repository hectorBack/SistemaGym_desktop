namespace Presentacion.Forms.Reportes
{
    partial class FrmSociosReporte
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
            cboEstatus = new ComboBox();
            lblEstatus = new Label();
            lblTitulo = new Label();
            dgvSocios = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(lblTotal);
            panelTop.Controls.Add(btnExportarExcel);
            panelTop.Controls.Add(btnLimpiarFiltros);
            panelTop.Controls.Add(btnFiltrar);
            panelTop.Controls.Add(cboEstatus);
            panelTop.Controls.Add(lblEstatus);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 155);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(330, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte general de socios";
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Font = new Font("Segoe UI", 9F);
            lblEstatus.ForeColor = Color.FromArgb(230, 238, 252);
            lblEstatus.Location = new Point(20, 68);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(59, 20);
            lblEstatus.TabIndex = 1;
            lblEstatus.Text = "Estatus:";
            // 
            // cboEstatus
            // 
            cboEstatus.Anchor = AnchorStyles.Left;
            cboEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstatus.Font = new Font("Segoe UI", 9F);
            cboEstatus.FormattingEnabled = true;
            cboEstatus.Location = new Point(85, 64);
            cboEstatus.Name = "cboEstatus";
            cboEstatus.Size = new Size(180, 28);
            cboEstatus.TabIndex = 2;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(31, 111, 235);
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(280, 59);
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
            btnLimpiarFiltros.Location = new Point(378, 59);
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
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.AutoEllipsis = true;
            lblTotal.AutoSize = false;
            lblTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotal.Location = new Point(85, 108);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(400, 25);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total de Socios: 0";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
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
            btnExportarExcel.TabIndex = 6;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // dgvSocios
            // 
            dgvSocios.AllowUserToAddRows = false;
            dgvSocios.AllowUserToDeleteRows = false;
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSocios.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvSocios.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSocios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSocios.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSocios.Dock = DockStyle.Fill;
            dgvSocios.EnableHeadersVisualStyles = false;
            dgvSocios.GridColor = Color.FromArgb(15, 42, 79);
            dgvSocios.Location = new Point(0, 110);
            dgvSocios.Margin = new Padding(3, 4, 3, 4);
            dgvSocios.MultiSelect = false;
            dgvSocios.Name = "dgvSocios";
            dgvSocios.ReadOnly = true;
            dgvSocios.RowHeadersVisible = false;
            dgvSocios.RowHeadersWidth = 51;
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.Size = new Size(914, 690);
            dgvSocios.TabIndex = 1;
            // 
            // FrmSociosReporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvSocios);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmSociosReporte";
            Text = "Socios";
            Load += FrmSociosReporte_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblEstatus;
        private ComboBox cboEstatus;
        private Button btnFiltrar;
        private Button btnLimpiarFiltros;
        private Label lblTotal;
        private Button btnExportarExcel;
        private DataGridView dgvSocios;
    }
}