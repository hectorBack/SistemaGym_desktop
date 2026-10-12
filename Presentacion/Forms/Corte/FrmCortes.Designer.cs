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
            panelTop = new Panel();
            lblTitulo = new Label();
            flowAcciones = new FlowLayoutPanel();
            btnNuevo = new BotonTema();
            btnVerDetalle = new BotonTema();
            btnExportar = new BotonTema();
            panelFiltros = new Panel();
            flowFiltros = new FlowLayoutPanel();
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnFiltrar = new BotonTema();
            btnLimpiar = new BotonTema();
            lblEfectivoCaja = new Label();
            dgvCortes = new GridTema();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelFiltros.SuspendLayout();
            flowFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCortes).BeginInit();
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
            panelTop.Size = new Size(1257, 70);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(215, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Cortes";
            // 
            // flowAcciones
            // 
            flowAcciones.AutoSize = true;
            flowAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAcciones.Controls.Add(btnNuevo);
            flowAcciones.Controls.Add(btnVerDetalle);
            flowAcciones.Controls.Add(btnExportar);
            flowAcciones.Dock = DockStyle.Right;
            flowAcciones.Location = new Point(500, 0);
            flowAcciones.Name = "flowAcciones";
            flowAcciones.Padding = new Padding(0, 16, 12, 0);
            flowAcciones.Size = new Size(757, 70);
            flowAcciones.TabIndex = 1;
            flowAcciones.WrapContents = false;
            // 
            // btnNuevo
            // 
            btnNuevo.Estilo = EstiloBoton.Primario;
            btnNuevo.Margin = new Padding(0, 0, 8, 0);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(130, 38);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "+ Nuevo corte";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Enabled = false;
            btnVerDetalle.Margin = new Padding(0, 0, 8, 0);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(110, 38);
            btnVerDetalle.TabIndex = 1;
            btnVerDetalle.Text = "Ver detalle";
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnExportar
            // 
            btnExportar.Enabled = false;
            btnExportar.Margin = new Padding(0, 0, 8, 0);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(130, 38);
            btnExportar.TabIndex = 2;
            btnExportar.Text = "Exportar CSV";
            btnExportar.Click += btnExportar_Click;
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = Color.FromArgb(14, 20, 36);
            panelFiltros.Controls.Add(lblEfectivoCaja);
            panelFiltros.Controls.Add(flowFiltros);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 70);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(1257, 56);
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
            flowFiltros.Controls.Add(btnLimpiar);
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
            // btnLimpiar
            // 
            btnLimpiar.Margin = new Padding(0, 1, 0, 0);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(86, 32);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Hoy";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblEfectivoCaja
            // 
            lblEfectivoCaja.Dock = DockStyle.Right;
            lblEfectivoCaja.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEfectivoCaja.ForeColor = Color.FromArgb(45, 212, 255);
            lblEfectivoCaja.Location = new Point(757, 0);
            lblEfectivoCaja.Name = "lblEfectivoCaja";
            lblEfectivoCaja.Padding = new Padding(0, 0, 20, 0);
            lblEfectivoCaja.Size = new Size(500, 56);
            lblEfectivoCaja.TabIndex = 1;
            lblEfectivoCaja.Text = "Efectivo en Caja: $0.00";
            lblEfectivoCaja.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvCortes
            // 
            dgvCortes.Dock = DockStyle.Fill;
            dgvCortes.Location = new Point(0, 126);
            dgvCortes.Name = "dgvCortes";
            dgvCortes.Size = new Size(1257, 941);
            dgvCortes.TabIndex = 2;
            dgvCortes.CellDoubleClick += dgvCortes_CellDoubleClick;
            dgvCortes.CellFormatting += dgvCortes_CellFormatting;
            dgvCortes.SelectionChanged += dgvCortes_SelectionChanged;
            // 
            // FrmCortes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1257, 1067);
            Controls.Add(dgvCortes);
            Controls.Add(panelFiltros);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCortes";
            Text = "Cortes de Caja";
            Load += FrmCortes_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            flowFiltros.ResumeLayout(false);
            flowFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCortes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnNuevo;
        private BotonTema btnVerDetalle;
        private BotonTema btnExportar;
        private Panel panelFiltros;
        private FlowLayoutPanel flowFiltros;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private BotonTema btnFiltrar;
        private BotonTema btnLimpiar;
        private Label lblEfectivoCaja;
        private GridTema dgvCortes;
    }
}