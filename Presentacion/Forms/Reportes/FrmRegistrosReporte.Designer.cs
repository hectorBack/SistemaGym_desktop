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
            panelTop = new Panel();
            lblTitulo = new Label();
            flowAcciones = new FlowLayoutPanel();
            btnExportarExcel = new BotonTema();
            panelFiltros = new Panel();
            flowFiltros = new FlowLayoutPanel();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            btnFiltrar = new BotonTema();
            btnLimpiarFiltros = new BotonTema();
            lblTotal = new Label();
            dgvRegistros = new GridTema();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelFiltros.SuspendLayout();
            flowFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).BeginInit();
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
            lblTitulo.Size = new Size(340, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de registro de visitas";
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
            btnExportarExcel.Margin = new Padding(0);
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
            flowFiltros.Controls.Add(lblFecha);
            flowFiltros.Controls.Add(dtpFecha);
            flowFiltros.Controls.Add(btnFiltrar);
            flowFiltros.Controls.Add(btnLimpiarFiltros);
            flowFiltros.Dock = DockStyle.Left;
            flowFiltros.Location = new Point(0, 0);
            flowFiltros.Name = "flowFiltros";
            flowFiltros.Padding = new Padding(20, 10, 0, 0);
            flowFiltros.Size = new Size(520, 56);
            flowFiltros.TabIndex = 0;
            flowFiltros.WrapContents = false;
            //
            // lblFecha
            //
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9.5F);
            lblFecha.ForeColor = Color.FromArgb(230, 238, 252);
            lblFecha.Margin = new Padding(0, 7, 6, 0);
            lblFecha.Text = "Fecha:";
            lblFecha.Name = "lblFecha";
            lblFecha.TabIndex = 0;
            //
            // dtpFecha
            //
            dtpFecha.Font = new Font("Segoe UI", 9F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Margin = new Padding(0, 4, 16, 0);
            dtpFecha.Size = new Size(130, 27);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.TabIndex = 1;
            //
            // btnFiltrar
            //
            btnFiltrar.Estilo = EstiloBoton.Primario;
            btnFiltrar.Margin = new Padding(0, 1, 8, 0);
            btnFiltrar.Size = new Size(86, 32);
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.TabIndex = 2;
            //
            // btnLimpiarFiltros
            //
            btnLimpiarFiltros.Margin = new Padding(0, 1, 0, 0);
            btnLimpiarFiltros.Size = new Size(86, 32);
            btnLimpiarFiltros.Text = "Hoy";
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.TabIndex = 3;
            //
            // lblTotal
            //
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotal.Location = new Point(514, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Padding = new Padding(0, 0, 20, 0);
            lblTotal.Size = new Size(400, 56);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total Visitas: 0";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // dgvRegistros
            //
            dgvRegistros.Dock = DockStyle.Fill;
            dgvRegistros.Location = new Point(0, 126);
            dgvRegistros.Name = "dgvRegistros";
            dgvRegistros.Size = new Size(914, 674);
            dgvRegistros.TabIndex = 2;
            //
            // FrmRegistrosReporte
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvRegistros);
            Controls.Add(panelFiltros);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRegistrosReporte";
            Text = "Registro de Visitas";
            Load += FrmRegistrosReporte_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            flowFiltros.ResumeLayout(false);
            flowFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnExportarExcel;
        private Panel panelFiltros;
        private FlowLayoutPanel flowFiltros;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private BotonTema btnFiltrar;
        private BotonTema btnLimpiarFiltros;
        private Label lblTotal;
        private GridTema dgvRegistros;
    }
}