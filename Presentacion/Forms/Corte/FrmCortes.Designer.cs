namespace Presentacion.Forms.Corte
{
    partial class FrmCortes
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
            lblTitulo = new Label();
            lblEfectivoCaja = new Label();
            flpFechas = new FlowLayoutPanel();
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnFiltrar = new Button();
            btnLimpiar = new Button();
            btnNuevo = new Button();
            btnVerDetalle = new Button();
            btnExportarExcel = new Button();
            dgvCortes = new DataGridView();
            panelTop.SuspendLayout();
            flpFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCortes).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblEfectivoCaja);
            panelTop.Controls.Add(flpFechas);
            panelTop.Controls.Add(btnNuevo);
            panelTop.Controls.Add(btnVerDetalle);
            panelTop.Controls.Add(btnExportarExcel);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1257, 160);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(195, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cortes de Caja";
            // 
            // lblEfectivoCaja
            // 
            lblEfectivoCaja.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEfectivoCaja.AutoSize = true;
            lblEfectivoCaja.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEfectivoCaja.ForeColor = Color.FromArgb(45, 212, 255);
            lblEfectivoCaja.Location = new Point(949, 21);
            lblEfectivoCaja.Name = "lblEfectivoCaja";
            lblEfectivoCaja.Size = new Size(215, 28);
            lblEfectivoCaja.TabIndex = 1;
            lblEfectivoCaja.Text = "Efectivo en Caja: $0.00";
            // 
            // flpFechas
            // 
            flpFechas.AutoSize = true;
            flpFechas.Controls.Add(lblDesde);
            flpFechas.Controls.Add(dtpFechaInicio);
            flpFechas.Controls.Add(lblHasta);
            flpFechas.Controls.Add(dtpFechaFin);
            flpFechas.Controls.Add(btnFiltrar);
            flpFechas.Controls.Add(btnLimpiar);
            flpFechas.Location = new Point(23, 109);
            flpFechas.Margin = new Padding(3, 4, 3, 4);
            flpFechas.Name = "flpFechas";
            flpFechas.Size = new Size(600, 47);
            flpFechas.TabIndex = 2;
            flpFechas.WrapContents = false;
            // 
            // lblDesde
            // 
            lblDesde.Anchor = AnchorStyles.Left;
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 9.5F);
            lblDesde.ForeColor = Color.FromArgb(230, 238, 252);
            lblDesde.Location = new Point(0, 7);
            lblDesde.Margin = new Padding(0, 0, 6, 0);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(56, 21);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Anchor = AnchorStyles.Left;
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(62, 4);
            dtpFechaInicio.Margin = new Padding(0, 0, 17, 0);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(125, 27);
            dtpFechaInicio.TabIndex = 1;
            // 
            // lblHasta
            // 
            lblHasta.Anchor = AnchorStyles.Left;
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 9.5F);
            lblHasta.ForeColor = Color.FromArgb(230, 238, 252);
            lblHasta.Location = new Point(204, 7);
            lblHasta.Margin = new Padding(0, 0, 6, 0);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(52, 21);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Anchor = AnchorStyles.Left;
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(262, 4);
            dtpFechaFin.Margin = new Padding(0, 0, 17, 0);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(125, 27);
            dtpFechaFin.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Anchor = AnchorStyles.Left;
            btnFiltrar.BackColor = Color.FromArgb(31, 111, 235);
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(404, 0);
            btnFiltrar.Margin = new Padding(0);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(86, 36);
            btnFiltrar.TabIndex = 4;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Left;
            btnLimpiar.BackColor = Color.FromArgb(11, 15, 26);
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.FromArgb(230, 238, 252);
            btnLimpiar.Location = new Point(498, 0);
            btnLimpiar.Margin = new Padding(8, 0, 0, 0);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(86, 36);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.BackColor = Color.FromArgb(31, 111, 235);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(810, 108);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(125, 38);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerDetalle.BackColor = Color.FromArgb(11, 15, 26);
            btnVerDetalle.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnVerDetalle.FlatStyle = FlatStyle.Flat;
            btnVerDetalle.Font = new Font("Segoe UI", 9F);
            btnVerDetalle.ForeColor = Color.FromArgb(230, 238, 252);
            btnVerDetalle.Location = new Point(949, 108);
            btnVerDetalle.Margin = new Padding(3, 4, 3, 4);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(110, 38);
            btnVerDetalle.TabIndex = 4;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = false;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarExcel.BackColor = Color.FromArgb(11, 15, 26);
            btnExportarExcel.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.Font = new Font("Segoe UI", 9F);
            btnExportarExcel.ForeColor = Color.FromArgb(230, 238, 252);
            btnExportarExcel.Location = new Point(1073, 108);
            btnExportarExcel.Margin = new Padding(3, 4, 3, 4);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(125, 38);
            btnExportarExcel.TabIndex = 5;
            btnExportarExcel.Text = "Exportar Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // dgvCortes
            // 
            dgvCortes.AllowUserToAddRows = false;
            dgvCortes.AllowUserToDeleteRows = false;
            dgvCortes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCortes.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvCortes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCortes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCortes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCortes.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCortes.Dock = DockStyle.Fill;
            dgvCortes.EnableHeadersVisualStyles = false;
            dgvCortes.GridColor = Color.FromArgb(15, 42, 79);
            dgvCortes.Location = new Point(0, 160);
            dgvCortes.Margin = new Padding(3, 4, 3, 4);
            dgvCortes.MultiSelect = false;
            dgvCortes.Name = "dgvCortes";
            dgvCortes.ReadOnly = true;
            dgvCortes.RowHeadersVisible = false;
            dgvCortes.RowHeadersWidth = 51;
            dgvCortes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCortes.Size = new Size(1257, 907);
            dgvCortes.TabIndex = 1;
            // 
            // FrmCortes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1257, 1067);
            Controls.Add(dgvCortes);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCortes";
            Text = "Cortes de Caja";
            Load += FrmCortes_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flpFechas.ResumeLayout(false);
            flpFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCortes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblEfectivoCaja;
        private FlowLayoutPanel flpFechas;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private Button btnFiltrar;
        private Button btnLimpiar;
        private Button btnNuevo;
        private Button btnVerDetalle;
        private Button btnExportarExcel;
        private DataGridView dgvCortes;
    }
}