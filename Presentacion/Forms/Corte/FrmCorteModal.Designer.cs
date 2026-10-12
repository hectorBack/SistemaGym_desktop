namespace Presentacion.Forms.Corte
{
    partial class FrmCorteModal
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
            panelHeader = new Panel();
            lblTitulo = new Label();
            panelFiltros = new Panel();
            flowFiltros = new FlowLayoutPanel();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            btnConsultar = new BotonTema();
            lblConteo = new Label();
            dgvMovimientos = new GridTema();
            panelPie = new Panel();
            tablaTotales = new TableLayoutPanel();
            lblEfectivoInicialEtiqueta = new Label();
            lblTotalIngresosEtiqueta = new Label();
            lblTotalEgresosEtiqueta = new Label();
            lblEfectivoFinalEtiqueta = new Label();
            lblEfectivoInicialValue = new Label();
            lblTotalIngresosValue = new Label();
            lblTotalEgresosValue = new Label();
            lblEfectivoFinalValue = new Label();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            btnRealizarCorte = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader.SuspendLayout();
            panelFiltros.SuspendLayout();
            flowFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            panelPie.SuspendLayout();
            tablaTotales.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 67);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(304, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Corte de Caja / Flujo de Efectivo";
            //
            // panelFiltros
            //
            panelFiltros.BackColor = Color.FromArgb(14, 20, 36);
            panelFiltros.Controls.Add(lblConteo);
            panelFiltros.Controls.Add(flowFiltros);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 67);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(800, 60);
            panelFiltros.TabIndex = 1;
            //
            // flowFiltros
            //
            flowFiltros.AutoSize = true;
            flowFiltros.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowFiltros.Controls.Add(lblFechaInicio);
            flowFiltros.Controls.Add(dtpFechaInicio);
            flowFiltros.Controls.Add(lblFechaFin);
            flowFiltros.Controls.Add(dtpFechaFin);
            flowFiltros.Controls.Add(btnConsultar);
            flowFiltros.Dock = DockStyle.Left;
            flowFiltros.Location = new Point(0, 0);
            flowFiltros.Name = "flowFiltros";
            flowFiltros.Padding = new Padding(23, 12, 0, 0);
            flowFiltros.Size = new Size(620, 60);
            flowFiltros.TabIndex = 0;
            flowFiltros.WrapContents = false;
            //
            // lblFechaInicio
            //
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI", 9.5F);
            lblFechaInicio.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaInicio.Margin = new Padding(0, 7, 6, 0);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(56, 21);
            lblFechaInicio.TabIndex = 0;
            lblFechaInicio.Text = "Desde:";
            //
            // dtpFechaInicio
            //
            dtpFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.Margin = new Padding(0, 4, 16, 0);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(160, 27);
            dtpFechaInicio.TabIndex = 1;
            //
            // lblFechaFin
            //
            lblFechaFin.AutoSize = true;
            lblFechaFin.Font = new Font("Segoe UI", 9.5F);
            lblFechaFin.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaFin.Margin = new Padding(0, 7, 6, 0);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(52, 21);
            lblFechaFin.TabIndex = 2;
            lblFechaFin.Text = "Hasta:";
            //
            // dtpFechaFin
            //
            dtpFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.Margin = new Padding(0, 4, 16, 0);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(160, 27);
            dtpFechaFin.TabIndex = 3;
            dtpFechaFin.ValueChanged += dtpFechaFin_ValueChanged;
            //
            // btnConsultar
            //
            btnConsultar.Estilo = EstiloBoton.Primario;
            btnConsultar.Margin = new Padding(0, 1, 0, 0);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(100, 32);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "Consultar";
            btnConsultar.Click += btnConsultar_Click;
            //
            // lblConteo
            //
            lblConteo.Dock = DockStyle.Right;
            lblConteo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblConteo.ForeColor = Color.FromArgb(45, 212, 255);
            lblConteo.Location = new Point(620, 0);
            lblConteo.Name = "lblConteo";
            lblConteo.Padding = new Padding(0, 0, 20, 0);
            lblConteo.Size = new Size(180, 60);
            lblConteo.TabIndex = 1;
            lblConteo.TextAlign = ContentAlignment.MiddleRight;
            //
            // dgvMovimientos
            //
            dgvMovimientos.Dock = DockStyle.Fill;
            dgvMovimientos.Location = new Point(0, 127);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(800, 273);
            dgvMovimientos.TabIndex = 2;
            dgvMovimientos.CellFormatting += dgvMovimientos_CellFormatting;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(tablaTotales);
            panelPie.Controls.Add(lblObservaciones);
            panelPie.Controls.Add(txtObservaciones);
            panelPie.Controls.Add(btnRealizarCorte);
            panelPie.Controls.Add(btnCancelar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 400);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(800, 220);
            panelPie.TabIndex = 3;
            //
            // tablaTotales
            //
            tablaTotales.ColumnCount = 4;
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaTotales.Controls.Add(lblEfectivoInicialEtiqueta, 0, 0);
            tablaTotales.Controls.Add(lblTotalIngresosEtiqueta, 1, 0);
            tablaTotales.Controls.Add(lblTotalEgresosEtiqueta, 2, 0);
            tablaTotales.Controls.Add(lblEfectivoFinalEtiqueta, 3, 0);
            tablaTotales.Controls.Add(lblEfectivoInicialValue, 0, 1);
            tablaTotales.Controls.Add(lblTotalIngresosValue, 1, 1);
            tablaTotales.Controls.Add(lblTotalEgresosValue, 2, 1);
            tablaTotales.Controls.Add(lblEfectivoFinalValue, 3, 1);
            tablaTotales.Dock = DockStyle.Top;
            tablaTotales.Location = new Point(0, 0);
            tablaTotales.Name = "tablaTotales";
            tablaTotales.Padding = new Padding(12, 8, 12, 0);
            tablaTotales.RowCount = 2;
            tablaTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tablaTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tablaTotales.Size = new Size(800, 76);
            tablaTotales.TabIndex = 0;
            //
            // lblEfectivoInicialEtiqueta
            //
            lblEfectivoInicialEtiqueta.Dock = DockStyle.Fill;
            lblEfectivoInicialEtiqueta.Font = new Font("Segoe UI", 9F);
            lblEfectivoInicialEtiqueta.ForeColor = Color.FromArgb(124, 138, 165);
            lblEfectivoInicialEtiqueta.Name = "lblEfectivoInicialEtiqueta";
            lblEfectivoInicialEtiqueta.TabIndex = 0;
            lblEfectivoInicialEtiqueta.Text = "Efectivo inicial";
            lblEfectivoInicialEtiqueta.TextAlign = ContentAlignment.BottomCenter;
            //
            // lblTotalIngresosEtiqueta
            //
            lblTotalIngresosEtiqueta.Dock = DockStyle.Fill;
            lblTotalIngresosEtiqueta.Font = new Font("Segoe UI", 9F);
            lblTotalIngresosEtiqueta.ForeColor = Color.FromArgb(124, 138, 165);
            lblTotalIngresosEtiqueta.Name = "lblTotalIngresosEtiqueta";
            lblTotalIngresosEtiqueta.TabIndex = 1;
            lblTotalIngresosEtiqueta.Text = "Total ingresos";
            lblTotalIngresosEtiqueta.TextAlign = ContentAlignment.BottomCenter;
            //
            // lblTotalEgresosEtiqueta
            //
            lblTotalEgresosEtiqueta.Dock = DockStyle.Fill;
            lblTotalEgresosEtiqueta.Font = new Font("Segoe UI", 9F);
            lblTotalEgresosEtiqueta.ForeColor = Color.FromArgb(124, 138, 165);
            lblTotalEgresosEtiqueta.Name = "lblTotalEgresosEtiqueta";
            lblTotalEgresosEtiqueta.TabIndex = 2;
            lblTotalEgresosEtiqueta.Text = "Total egresos";
            lblTotalEgresosEtiqueta.TextAlign = ContentAlignment.BottomCenter;
            //
            // lblEfectivoFinalEtiqueta
            //
            lblEfectivoFinalEtiqueta.Dock = DockStyle.Fill;
            lblEfectivoFinalEtiqueta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEfectivoFinalEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblEfectivoFinalEtiqueta.Name = "lblEfectivoFinalEtiqueta";
            lblEfectivoFinalEtiqueta.TabIndex = 3;
            lblEfectivoFinalEtiqueta.Text = "TOTAL EN CAJA";
            lblEfectivoFinalEtiqueta.TextAlign = ContentAlignment.BottomCenter;
            //
            // lblEfectivoInicialValue
            //
            lblEfectivoInicialValue.Dock = DockStyle.Fill;
            lblEfectivoInicialValue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEfectivoInicialValue.ForeColor = Color.FromArgb(230, 238, 252);
            lblEfectivoInicialValue.Name = "lblEfectivoInicialValue";
            lblEfectivoInicialValue.TabIndex = 4;
            lblEfectivoInicialValue.Text = "$0.00";
            lblEfectivoInicialValue.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTotalIngresosValue
            //
            lblTotalIngresosValue.Dock = DockStyle.Fill;
            lblTotalIngresosValue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTotalIngresosValue.ForeColor = Color.FromArgb(52, 211, 153);
            lblTotalIngresosValue.Name = "lblTotalIngresosValue";
            lblTotalIngresosValue.TabIndex = 5;
            lblTotalIngresosValue.Text = "$0.00";
            lblTotalIngresosValue.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTotalEgresosValue
            //
            lblTotalEgresosValue.Dock = DockStyle.Fill;
            lblTotalEgresosValue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTotalEgresosValue.ForeColor = Color.FromArgb(248, 113, 113);
            lblTotalEgresosValue.Name = "lblTotalEgresosValue";
            lblTotalEgresosValue.TabIndex = 6;
            lblTotalEgresosValue.Text = "$0.00";
            lblTotalEgresosValue.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblEfectivoFinalValue
            //
            lblEfectivoFinalValue.Dock = DockStyle.Fill;
            lblEfectivoFinalValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblEfectivoFinalValue.ForeColor = Color.FromArgb(45, 212, 255);
            lblEfectivoFinalValue.Name = "lblEfectivoFinalValue";
            lblEfectivoFinalValue.TabIndex = 7;
            lblEfectivoFinalValue.Text = "$0.00";
            lblEfectivoFinalValue.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblObservaciones
            //
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 9.5F);
            lblObservaciones.ForeColor = Color.FromArgb(230, 238, 252);
            lblObservaciones.Location = new Point(29, 88);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(115, 21);
            lblObservaciones.TabIndex = 1;
            lblObservaciones.Text = "Observaciones:";
            //
            // txtObservaciones
            //
            txtObservaciones.BackColor = Color.FromArgb(15, 42, 79);
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.Font = new Font("Segoe UI", 9.5F);
            txtObservaciones.ForeColor = Color.FromArgb(230, 238, 252);
            txtObservaciones.Location = new Point(29, 114);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(430, 80);
            txtObservaciones.TabIndex = 2;
            //
            // btnRealizarCorte
            //
            btnRealizarCorte.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRealizarCorte.Estilo = EstiloBoton.Exito;
            btnRealizarCorte.Location = new Point(487, 147);
            btnRealizarCorte.Name = "btnRealizarCorte";
            btnRealizarCorte.Size = new Size(150, 47);
            btnRealizarCorte.TabIndex = 3;
            btnRealizarCorte.Text = "Realizar corte";
            btnRealizarCorte.Click += btnRealizarCorte_Click;
            //
            // btnCancelar
            //
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(646, 147);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(125, 47);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            //
            // FrmCorteModal
            //
            // Sin AcceptButton: las observaciones son multilínea y un Enter accidental no debe cerrar la caja.
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(800, 620);
            Controls.Add(dgvMovimientos);
            Controls.Add(panelPie);
            Controls.Add(panelFiltros);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = false;
            MinimumSize = new Size(816, 620);
            Name = "FrmCorteModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Corte de Caja";
            Load += FrmCorteModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            flowFiltros.ResumeLayout(false);
            flowFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            panelPie.ResumeLayout(false);
            panelPie.PerformLayout();
            tablaTotales.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelFiltros;
        private FlowLayoutPanel flowFiltros;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaFin;
        private BotonTema btnConsultar;
        private Label lblConteo;
        private GridTema dgvMovimientos;
        private Panel panelPie;
        private TableLayoutPanel tablaTotales;
        private Label lblEfectivoInicialEtiqueta;
        private Label lblTotalIngresosEtiqueta;
        private Label lblTotalEgresosEtiqueta;
        private Label lblEfectivoFinalEtiqueta;
        private Label lblEfectivoInicialValue;
        private Label lblTotalIngresosValue;
        private Label lblTotalEgresosValue;
        private Label lblEfectivoFinalValue;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private BotonTema btnRealizarCorte;
        private BotonTema btnCancelar;
    }
}