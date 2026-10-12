namespace Presentacion.Forms.Reportes
{
    partial class FrmPagosMembresias
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
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnFiltrar = new BotonTema();
            btnLimpiarFiltros = new BotonTema();
            lblTotal = new Label();
            dgvPagosMembresias = new GridTema();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelFiltros.SuspendLayout();
            flowFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagosMembresias).BeginInit();
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
            panelTop.Size = new Size(914, 70);
            panelTop.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(671, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de pagos de membresías en un rango de fechas";
            //
            // flowAcciones
            //
            flowAcciones.AutoSize = true;
            flowAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAcciones.Controls.Add(btnExportarExcel);
            flowAcciones.Dock = DockStyle.Right;
            flowAcciones.Location = new Point(750, 0);
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
            panelFiltros.Controls.Add(flowFiltros);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 70);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(914, 56);
            panelFiltros.TabIndex = 1;
            //
            // flowFiltros
            //
            flowFiltros.AutoSize = true;
            flowFiltros.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowFiltros.Controls.Add(lblDesde);
            flowFiltros.Controls.Add(dtpFechaInicio);
            flowFiltros.Controls.Add(lblHasta);
            flowFiltros.Controls.Add(dtpFechaFin);
            flowFiltros.Controls.Add(btnFiltrar);
            flowFiltros.Controls.Add(btnLimpiarFiltros);
            flowFiltros.Dock = DockStyle.Left;
            flowFiltros.Location = new Point(0, 0);
            flowFiltros.Name = "flowFiltros";
            flowFiltros.Padding = new Padding(20, 10, 0, 0);
            flowFiltros.Size = new Size(640, 56);
            flowFiltros.TabIndex = 0;
            flowFiltros.WrapContents = false;
            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 9.5F);
            lblDesde.ForeColor = Color.FromArgb(230, 238, 252);
            lblDesde.Margin = new Padding(0, 7, 6, 0);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(56, 21);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            //
            // dtpFechaInicio
            //
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Margin = new Padding(0, 4, 16, 0);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(125, 27);
            dtpFechaInicio.TabIndex = 1;
            //
            // lblHasta
            //
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 9.5F);
            lblHasta.ForeColor = Color.FromArgb(230, 238, 252);
            lblHasta.Margin = new Padding(0, 7, 6, 0);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(52, 21);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            //
            // dtpFechaFin
            //
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Margin = new Padding(0, 4, 16, 0);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(125, 27);
            dtpFechaFin.TabIndex = 3;
            //
            // btnFiltrar
            //
            btnFiltrar.Estilo = EstiloBoton.Primario;
            btnFiltrar.Margin = new Padding(0, 1, 8, 0);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(86, 32);
            btnFiltrar.TabIndex = 4;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            //
            // btnLimpiarFiltros
            //
            btnLimpiarFiltros.Margin = new Padding(0, 1, 0, 0);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(86, 32);
            btnLimpiarFiltros.TabIndex = 5;
            btnLimpiarFiltros.Text = "Hoy";
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            //
            // lblTotal
            //
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotal.Location = new Point(414, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Padding = new Padding(0, 0, 20, 0);
            lblTotal.Size = new Size(500, 56);
            lblTotal.TabIndex = 1;
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // dgvPagosMembresias
            //
            dgvPagosMembresias.Dock = DockStyle.Fill;
            dgvPagosMembresias.Location = new Point(0, 126);
            dgvPagosMembresias.Name = "dgvPagosMembresias";
            dgvPagosMembresias.Size = new Size(914, 674);
            dgvPagosMembresias.TabIndex = 2;
            dgvPagosMembresias.CellFormatting += dgvPagosMembresias_CellFormatting;

            //
            // FrmPagosMembresias
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvPagosMembresias);
            Controls.Add(panelFiltros);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPagosMembresias";
            Text = "Pagos de Membresías";
            Load += FrmPagosMembresias_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            flowFiltros.ResumeLayout(false);
            flowFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagosMembresias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnExportarExcel;
        private Panel panelFiltros;
        private FlowLayoutPanel flowFiltros;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private BotonTema btnFiltrar;
        private BotonTema btnLimpiarFiltros;
        private Label lblTotal;
        private GridTema dgvPagosMembresias;
    }
}