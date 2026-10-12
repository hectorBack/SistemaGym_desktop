namespace Presentacion.Forms.Movimientos
{
    partial class FrmMovimientos
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
            btnEditar = new BotonTema();
            btnDesactivar = new BotonTema();
            btnEliminarFisico = new BotonTema();
            panelFiltros = new Panel();
            flpFechas = new FlowLayoutPanel();
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnFiltrarFechas = new BotonTema();
            btnLimpiarFiltros = new BotonTema();
            dgvMovimientos = new GridTema();
            panelPie = new Panel();
            flpResumen = new FlowLayoutPanel();
            lblIngresos = new Label();
            lblEgresos = new Label();
            lblBalance = new Label();
            lblCantidad = new Label();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelFiltros.SuspendLayout();
            flpFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            panelPie.SuspendLayout();
            flpResumen.SuspendLayout();
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
            lblTitulo.Size = new Size(260, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Movimientos";
            //
            // flowAcciones
            //
            flowAcciones.AutoSize = true;
            flowAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAcciones.Controls.Add(btnNuevo);
            flowAcciones.Controls.Add(btnEditar);
            flowAcciones.Controls.Add(btnDesactivar);
            flowAcciones.Controls.Add(btnEliminarFisico);
            flowAcciones.Dock = DockStyle.Right;
            flowAcciones.Location = new Point(783, 0);
            flowAcciones.Name = "flowAcciones";
            flowAcciones.Padding = new Padding(0, 16, 12, 0);
            flowAcciones.Size = new Size(474, 70);
            flowAcciones.TabIndex = 1;
            flowAcciones.WrapContents = false;
            //
            // btnNuevo
            //
            btnNuevo.Estilo = EstiloBoton.Primario;
            btnNuevo.Margin = new Padding(0, 0, 8, 0);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(110, 38);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnEditar
            //
            btnEditar.Enabled = false;
            btnEditar.Margin = new Padding(0, 0, 8, 0);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 38);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            //
            // btnDesactivar
            //
            btnDesactivar.Enabled = false;
            btnDesactivar.Estilo = EstiloBoton.Advertencia;
            btnDesactivar.Margin = new Padding(0, 0, 8, 0);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(110, 38);
            btnDesactivar.TabIndex = 2;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.Click += btnDesactivar_Click;
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
            panelFiltros.Controls.Add(flpFechas);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 70);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Padding = new Padding(20, 8, 20, 8);
            panelFiltros.Size = new Size(1257, 56);
            panelFiltros.TabIndex = 1;
            //
            // flpFechas
            //
            flpFechas.AutoSize = true;
            flpFechas.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpFechas.Controls.Add(lblDesde);
            flpFechas.Controls.Add(dtpFechaInicio);
            flpFechas.Controls.Add(lblHasta);
            flpFechas.Controls.Add(dtpFechaFin);
            flpFechas.Controls.Add(btnFiltrarFechas);
            flpFechas.Controls.Add(btnLimpiarFiltros);
            flpFechas.Dock = DockStyle.Left;
            flpFechas.Location = new Point(20, 8);
            flpFechas.Name = "flpFechas";
            flpFechas.Size = new Size(600, 40);
            flpFechas.TabIndex = 0;
            flpFechas.WrapContents = false;
            //
            // lblDesde
            //
            lblDesde.Anchor = AnchorStyles.Left;
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 9.5F);
            lblDesde.ForeColor = Color.FromArgb(230, 238, 252);
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
            dtpFechaInicio.Margin = new Padding(0, 0, 17, 0);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(125, 27);
            dtpFechaInicio.TabIndex = 0;
            //
            // lblHasta
            //
            lblHasta.Anchor = AnchorStyles.Left;
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 9.5F);
            lblHasta.ForeColor = Color.FromArgb(230, 238, 252);
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
            dtpFechaFin.Margin = new Padding(0, 0, 17, 0);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(125, 27);
            dtpFechaFin.TabIndex = 1;
            //
            // btnFiltrarFechas
            //
            btnFiltrarFechas.Anchor = AnchorStyles.Left;
            btnFiltrarFechas.Estilo = EstiloBoton.Primario;
            btnFiltrarFechas.Margin = new Padding(0);
            btnFiltrarFechas.Name = "btnFiltrarFechas";
            btnFiltrarFechas.Size = new Size(86, 36);
            btnFiltrarFechas.TabIndex = 2;
            btnFiltrarFechas.Text = "Filtrar";
            btnFiltrarFechas.Click += btnFiltrarFechas_Click;
            //
            // btnLimpiarFiltros
            //
            btnLimpiarFiltros.Anchor = AnchorStyles.Left;
            btnLimpiarFiltros.Margin = new Padding(8, 0, 0, 0);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(86, 36);
            btnLimpiarFiltros.TabIndex = 3;
            btnLimpiarFiltros.Text = "Hoy";
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            //
            // dgvMovimientos
            //
            dgvMovimientos.Dock = DockStyle.Fill;
            dgvMovimientos.Location = new Point(0, 126);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(1257, 630);
            dgvMovimientos.TabIndex = 2;
            dgvMovimientos.CellDoubleClick += dgvMovimientos_CellDoubleClick;
            dgvMovimientos.CellFormatting += dgvMovimientos_CellFormatting;
            dgvMovimientos.SelectionChanged += dgvMovimientos_SelectionChanged;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(flpResumen);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 756);
            panelPie.Name = "panelPie";
            panelPie.Padding = new Padding(20, 0, 20, 0);
            panelPie.Size = new Size(1257, 44);
            panelPie.TabIndex = 3;
            //
            // flpResumen
            //
            flpResumen.Controls.Add(lblIngresos);
            flpResumen.Controls.Add(lblEgresos);
            flpResumen.Controls.Add(lblBalance);
            flpResumen.Controls.Add(lblCantidad);
            flpResumen.Dock = DockStyle.Fill;
            flpResumen.Location = new Point(20, 0);
            flpResumen.Name = "flpResumen";
            flpResumen.Size = new Size(1217, 44);
            flpResumen.TabIndex = 0;
            flpResumen.WrapContents = false;
            //
            // lblIngresos
            //
            lblIngresos.AutoSize = true;
            lblIngresos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblIngresos.ForeColor = Color.FromArgb(63, 185, 80);
            lblIngresos.Margin = new Padding(0, 11, 30, 0);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(120, 23);
            lblIngresos.TabIndex = 0;
            lblIngresos.Text = "Ingresos: $0.00";
            //
            // lblEgresos
            //
            lblEgresos.AutoSize = true;
            lblEgresos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEgresos.ForeColor = Color.FromArgb(248, 81, 73);
            lblEgresos.Margin = new Padding(0, 11, 30, 0);
            lblEgresos.Name = "lblEgresos";
            lblEgresos.Size = new Size(120, 23);
            lblEgresos.TabIndex = 1;
            lblEgresos.Text = "Egresos: $0.00";
            //
            // lblBalance
            //
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBalance.ForeColor = Color.FromArgb(230, 238, 252);
            lblBalance.Margin = new Padding(0, 11, 30, 0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(120, 23);
            lblBalance.TabIndex = 2;
            lblBalance.Text = "Balance: $0.00";
            //
            // lblCantidad
            //
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9.5F);
            lblCantidad.ForeColor = Color.FromArgb(124, 138, 165);
            lblCantidad.Margin = new Padding(0, 12, 0, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(110, 21);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "0 movimiento(s)";
            //
            // FrmMovimientos
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1257, 800);
            Controls.Add(dgvMovimientos);
            Controls.Add(panelPie);
            Controls.Add(panelFiltros);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMovimientos";
            Text = "Movimientos";
            Load += FrmMovimientos_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            flpFechas.ResumeLayout(false);
            flpFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            panelPie.ResumeLayout(false);
            flpResumen.ResumeLayout(false);
            flpResumen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnNuevo;
        private BotonTema btnEditar;
        private BotonTema btnDesactivar;
        private BotonTema btnEliminarFisico;
        private Panel panelFiltros;
        private FlowLayoutPanel flpFechas;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private BotonTema btnFiltrarFechas;
        private BotonTema btnLimpiarFiltros;
        private GridTema dgvMovimientos;
        private Panel panelPie;
        private FlowLayoutPanel flpResumen;
        private Label lblIngresos;
        private Label lblEgresos;
        private Label lblBalance;
        private Label lblCantidad;
    }
}