namespace Presentacion.Forms.Ventas
{
    partial class FrmVentas
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
            btnNuevaVenta = new BotonTema();
            btnVerDetalle = new BotonTema();
            btnAnular = new BotonTema();
            btnEliminarFisico = new BotonTema();
            panelFiltros = new Panel();
            flowFiltros = new FlowLayoutPanel();
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnFiltrarFechas = new BotonTema();
            btnLimpiarFiltros = new BotonTema();
            lblResumen = new Label();
            dgvVentas = new GridTema();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelFiltros.SuspendLayout();
            flowFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
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
            lblTitulo.Size = new Size(213, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Ventas";
            //
            // flowAcciones
            //
            flowAcciones.AutoSize = true;
            flowAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAcciones.Controls.Add(btnNuevaVenta);
            flowAcciones.Controls.Add(btnVerDetalle);
            flowAcciones.Controls.Add(btnAnular);
            flowAcciones.Controls.Add(btnEliminarFisico);
            flowAcciones.Dock = DockStyle.Right;
            flowAcciones.Location = new Point(500, 0);
            flowAcciones.Name = "flowAcciones";
            flowAcciones.Padding = new Padding(0, 16, 12, 0);
            flowAcciones.Size = new Size(757, 70);
            flowAcciones.TabIndex = 1;
            flowAcciones.WrapContents = false;
            //
            // btnNuevaVenta
            //
            btnNuevaVenta.Estilo = EstiloBoton.Primario;
            btnNuevaVenta.Margin = new Padding(0, 0, 8, 0);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(130, 38);
            btnNuevaVenta.TabIndex = 0;
            btnNuevaVenta.Text = "+ Nueva venta";
            btnNuevaVenta.Click += btnNuevaVenta_Click;
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
            // btnAnular
            //
            btnAnular.Enabled = false;
            btnAnular.Estilo = EstiloBoton.Advertencia;
            btnAnular.Margin = new Padding(0, 0, 8, 0);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(110, 38);
            btnAnular.TabIndex = 2;
            btnAnular.Text = "Anular";
            btnAnular.Click += btnAnular_Click;
            //
            // btnEliminarFisico
            //
            btnEliminarFisico.Enabled = false;
            btnEliminarFisico.Estilo = EstiloBoton.Peligro;
            btnEliminarFisico.Margin = new Padding(0, 0, 8, 0);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(110, 38);
            btnEliminarFisico.TabIndex = 3;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            //
            // panelFiltros
            //
            panelFiltros.BackColor = Color.FromArgb(14, 20, 36);
            panelFiltros.Controls.Add(lblResumen);
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
            flowFiltros.Controls.Add(btnFiltrarFechas);
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
            // btnFiltrarFechas
            //
            btnFiltrarFechas.Estilo = EstiloBoton.Primario;
            btnFiltrarFechas.Margin = new Padding(0, 1, 8, 0);
            btnFiltrarFechas.Name = "btnFiltrarFechas";
            btnFiltrarFechas.Size = new Size(86, 32);
            btnFiltrarFechas.TabIndex = 4;
            btnFiltrarFechas.Text = "Filtrar";
            btnFiltrarFechas.Click += btnFiltrarFechas_Click;
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
            // lblResumen
            //
            lblResumen.Dock = DockStyle.Right;
            lblResumen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResumen.ForeColor = Color.FromArgb(45, 212, 255);
            lblResumen.Location = new Point(757, 0);
            lblResumen.Name = "lblResumen";
            lblResumen.Padding = new Padding(0, 0, 20, 0);
            lblResumen.Size = new Size(500, 56);
            lblResumen.TabIndex = 1;
            lblResumen.TextAlign = ContentAlignment.MiddleRight;
            //
            // dgvVentas
            //
            dgvVentas.Dock = DockStyle.Fill;
            dgvVentas.Location = new Point(0, 126);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(1257, 941);
            dgvVentas.TabIndex = 2;
            dgvVentas.CellDoubleClick += dgvVentas_CellDoubleClick;
            dgvVentas.CellFormatting += dgvVentas_CellFormatting;
            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
            //
            // FrmVentas
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1257, 1067);
            Controls.Add(dgvVentas);
            Controls.Add(panelFiltros);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmVentas";
            Text = "Ventas";
            Load += FrmVentas_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            flowFiltros.ResumeLayout(false);
            flowFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnNuevaVenta;
        private BotonTema btnVerDetalle;
        private BotonTema btnAnular;
        private BotonTema btnEliminarFisico;
        private Panel panelFiltros;
        private FlowLayoutPanel flowFiltros;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private BotonTema btnFiltrarFechas;
        private BotonTema btnLimpiarFiltros;
        private Label lblResumen;
        private GridTema dgvVentas;
    }
}