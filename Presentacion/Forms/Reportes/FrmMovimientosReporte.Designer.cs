namespace Presentacion.Forms.Reportes
{
    partial class FrmMovimientosReporte
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
            panelTop = new Panel();
            lblTitulo = new Label();
            flowAcciones = new FlowLayoutPanel();
            btnExportarExcel = new BotonTema();
            panelFiltros = new Panel();
            flowFiltros = new FlowLayoutPanel();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnFiltrar = new BotonTema();
            btnLimpiarFiltros = new BotonTema();
            lblTotalIngresos = new Label();
            lblTotalEgresos = new Label();
            lblTotal = new Label();
            dgvMovimientos = new GridTema();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelFiltros.SuspendLayout();
            flowFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(flowAcciones);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1150, 70);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(462, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de Movimientos (Ingresos y Egresos)";
            // 
            // flowAcciones
            // 
            flowAcciones.AutoSize = true;
            flowAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAcciones.Controls.Add(btnExportarExcel);
            flowAcciones.Dock = DockStyle.Right;
            flowAcciones.Location = new Point(986, 0);
            flowAcciones.Name = "flowAcciones";
            flowAcciones.Padding = new Padding(0, 16, 12, 0);
            flowAcciones.Size = new Size(164, 70);
            flowAcciones.TabIndex = 1;
            flowAcciones.WrapContents = false;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Enabled = false;
            btnExportarExcel.Margin = new Padding(0, 0, 8, 0);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(140, 38);
            btnExportarExcel.TabIndex = 0;
            btnExportarExcel.Text = "Exportar CSV";
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = Color.FromArgb(14, 20, 36);
            panelFiltros.Controls.Add(lblTotal);
            panelFiltros.Controls.Add(lblTotalEgresos);
            panelFiltros.Controls.Add(lblTotalIngresos);
            panelFiltros.Controls.Add(flowFiltros);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 70);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(1150, 56);
            panelFiltros.TabIndex = 1;
            // 
            // flowFiltros
            // 
            flowFiltros.AutoSize = true;
            flowFiltros.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowFiltros.Controls.Add(lblTipo);
            flowFiltros.Controls.Add(cmbTipo);
            flowFiltros.Controls.Add(lblDesde);
            flowFiltros.Controls.Add(dtpFechaInicio);
            flowFiltros.Controls.Add(lblHasta);
            flowFiltros.Controls.Add(dtpFechaFin);
            flowFiltros.Controls.Add(btnFiltrar);
            flowFiltros.Controls.Add(btnLimpiarFiltros);
            flowFiltros.Dock = DockStyle.Left;
            flowFiltros.Location = new Point(0, 0);
            flowFiltros.Name = "flowFiltros";
            flowFiltros.Padding = new Padding(15, 10, 0, 0);
            flowFiltros.Size = new Size(735, 56);
            flowFiltros.TabIndex = 0;
            flowFiltros.WrapContents = false;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9.5F);
            lblTipo.ForeColor = Color.FromArgb(230, 238, 252);
            lblTipo.Margin = new Padding(0, 7, 6, 0);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(42, 21);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Segoe UI", 9F);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Margin = new Padding(0, 4, 16, 0);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(110, 28);
            cmbTipo.TabIndex = 1;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 9.5F);
            lblDesde.ForeColor = Color.FromArgb(230, 238, 252);
            lblDesde.Margin = new Padding(0, 7, 6, 0);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(56, 21);
            lblDesde.TabIndex = 2;
            lblDesde.Text = "Desde:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Margin = new Padding(0, 4, 16, 0);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(115, 27);
            dtpFechaInicio.TabIndex = 3;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 9.5F);
            lblHasta.ForeColor = Color.FromArgb(230, 238, 252);
            lblHasta.Margin = new Padding(0, 7, 6, 0);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(52, 21);
            lblHasta.TabIndex = 4;
            lblHasta.Text = "Hasta:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Margin = new Padding(0, 4, 16, 0);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(115, 27);
            dtpFechaFin.TabIndex = 5;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Estilo = EstiloBoton.Primario;
            btnFiltrar.Margin = new Padding(0, 1, 8, 0);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(76, 32);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Margin = new Padding(0, 1, 0, 0);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(76, 32);
            btnLimpiarFiltros.TabIndex = 7;
            btnLimpiarFiltros.Text = "Hoy";
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // lblTotalIngresos
            // 
            lblTotalIngresos.Dock = DockStyle.Right;
            lblTotalIngresos.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTotalIngresos.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalIngresos.Location = new Point(900, 0);
            lblTotalIngresos.Name = "lblTotalIngresos";
            lblTotalIngresos.Size = new Size(140, 56);
            lblTotalIngresos.TabIndex = 1;
            lblTotalIngresos.Text = "Ingresos: $0.00";
            lblTotalIngresos.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalEgresos
            // 
            lblTotalEgresos.Dock = DockStyle.Right;
            lblTotalEgresos.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTotalEgresos.ForeColor = Color.FromArgb(231, 76, 60);
            lblTotalEgresos.Location = new Point(760, 0);
            lblTotalEgresos.Name = "lblTotalEgresos";
            lblTotalEgresos.Size = new Size(140, 56);
            lblTotalEgresos.TabIndex = 2;
            lblTotalEgresos.Text = "Egresos: $0.00";
            lblTotalEgresos.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotal.Location = new Point(620, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Padding = new Padding(0, 0, 10, 0);
            lblTotal.Size = new Size(140, 56);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "0 movimiento(s)";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.Dock = DockStyle.Fill;
            dgvMovimientos.Location = new Point(0, 126);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(1150, 674);
            dgvMovimientos.TabIndex = 2;
            dgvMovimientos.CellFormatting += dgvMovimientos_CellFormatting;
            // 
            // FrmMovimientosReporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1150, 800);
            Controls.Add(dgvMovimientos);
            Controls.Add(panelFiltros);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMovimientosReporte";
            Text = "Reporte de Movimientos";
            Load += FrmMovimientosReporte_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            flowFiltros.ResumeLayout(false);
            flowFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnExportarExcel;
        private Panel panelFiltros;
        private FlowLayoutPanel flowFiltros;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private BotonTema btnFiltrar;
        private BotonTema btnLimpiarFiltros;
        private Label lblTotalIngresos;
        private Label lblTotalEgresos;
        private Label lblTotal;
        private GridTema dgvMovimientos;
    }
}