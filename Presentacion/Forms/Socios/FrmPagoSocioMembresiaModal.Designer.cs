namespace Presentacion.Forms.Socios
{
    partial class FrmPagoSocioMembresiaModal
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
            panelContenido = new Panel();
            dgvPagos = new GridTema();
            panelPagosBarra = new Panel();
            lblPagos = new Label();
            panelAccionesPagos = new FlowLayoutPanel();
            btnAnularPago = new BotonTema();
            grpRegistrarPago = new GroupBox();
            lblMonto = new Label();
            nudMonto = new NumericUpDown();
            lblTipoPago = new Label();
            cmbTipoPago = new ComboBox();
            lblFolio = new Label();
            txtFolio = new TextBox();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            btnAgregarPago = new BotonTema();
            grpDetallesMembresia = new GroupBox();
            lblInicioHeader = new Label();
            lblFechaInicio = new Label();
            lblPrecioHeader = new Label();
            lblPrecioMembresia = new Label();
            lblPagadoHeader = new Label();
            lblTotalPagado = new Label();
            lblEstadoHeader = new Label();
            lblEstadoPago = new Label();
            panelPie = new Panel();
            btnCerrar = new BotonTema();
            panelHeader.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            panelPagosBarra.SuspendLayout();
            panelAccionesPagos.SuspendLayout();
            grpRegistrarPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            grpDetallesMembresia.SuspendLayout();
            panelPie.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(780, 67);
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Pagos de la Membresía";
            //
            // panelContenido
            //
            panelContenido.Controls.Add(dgvPagos);
            panelContenido.Controls.Add(panelPagosBarra);
            panelContenido.Controls.Add(grpRegistrarPago);
            panelContenido.Controls.Add(grpDetallesMembresia);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 67);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(20, 10, 20, 10);
            panelContenido.Size = new Size(780, 513);
            panelContenido.TabIndex = 1;
            //
            // grpDetallesMembresia
            //
            grpDetallesMembresia.Controls.Add(lblInicioHeader);
            grpDetallesMembresia.Controls.Add(lblFechaInicio);
            grpDetallesMembresia.Controls.Add(lblPrecioHeader);
            grpDetallesMembresia.Controls.Add(lblPrecioMembresia);
            grpDetallesMembresia.Controls.Add(lblPagadoHeader);
            grpDetallesMembresia.Controls.Add(lblTotalPagado);
            grpDetallesMembresia.Controls.Add(lblEstadoHeader);
            grpDetallesMembresia.Controls.Add(lblEstadoPago);
            grpDetallesMembresia.Dock = DockStyle.Top;
            grpDetallesMembresia.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpDetallesMembresia.ForeColor = Color.FromArgb(45, 212, 255);
            grpDetallesMembresia.Location = new Point(20, 10);
            grpDetallesMembresia.Name = "grpDetallesMembresia";
            grpDetallesMembresia.Size = new Size(740, 95);
            grpDetallesMembresia.TabIndex = 0;
            grpDetallesMembresia.TabStop = false;
            grpDetallesMembresia.Text = "Detalles de la membresía";
            //
            // lblInicioHeader
            //
            lblInicioHeader.AutoSize = true;
            lblInicioHeader.Font = new Font("Segoe UI", 9F);
            lblInicioHeader.ForeColor = Color.FromArgb(124, 138, 165);
            lblInicioHeader.Location = new Point(17, 30);
            lblInicioHeader.Name = "lblInicioHeader";
            lblInicioHeader.Size = new Size(95, 20);
            lblInicioHeader.TabIndex = 0;
            lblInicioHeader.Text = "Fecha de inicio";
            //
            // lblFechaInicio
            //
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblFechaInicio.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaInicio.Location = new Point(17, 54);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(80, 25);
            lblFechaInicio.TabIndex = 1;
            lblFechaInicio.Text = "--/--/----";
            //
            // lblPrecioHeader
            //
            lblPrecioHeader.AutoSize = true;
            lblPrecioHeader.Font = new Font("Segoe UI", 9F);
            lblPrecioHeader.ForeColor = Color.FromArgb(124, 138, 165);
            lblPrecioHeader.Location = new Point(190, 30);
            lblPrecioHeader.Name = "lblPrecioHeader";
            lblPrecioHeader.Size = new Size(46, 20);
            lblPrecioHeader.TabIndex = 2;
            lblPrecioHeader.Text = "Precio";
            //
            // lblPrecioMembresia
            //
            lblPrecioMembresia.AutoSize = true;
            lblPrecioMembresia.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblPrecioMembresia.ForeColor = Color.FromArgb(230, 238, 252);
            lblPrecioMembresia.Location = new Point(190, 54);
            lblPrecioMembresia.Name = "lblPrecioMembresia";
            lblPrecioMembresia.Size = new Size(58, 25);
            lblPrecioMembresia.TabIndex = 3;
            lblPrecioMembresia.Text = "$0.00";
            //
            // lblPagadoHeader
            //
            lblPagadoHeader.AutoSize = true;
            lblPagadoHeader.Font = new Font("Segoe UI", 9F);
            lblPagadoHeader.ForeColor = Color.FromArgb(124, 138, 165);
            lblPagadoHeader.Location = new Point(330, 30);
            lblPagadoHeader.Name = "lblPagadoHeader";
            lblPagadoHeader.Size = new Size(88, 20);
            lblPagadoHeader.TabIndex = 4;
            lblPagadoHeader.Text = "Total pagado";
            //
            // lblTotalPagado
            //
            lblTotalPagado.AutoSize = true;
            lblTotalPagado.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblTotalPagado.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotalPagado.Location = new Point(330, 54);
            lblTotalPagado.Name = "lblTotalPagado";
            lblTotalPagado.Size = new Size(58, 25);
            lblTotalPagado.TabIndex = 5;
            lblTotalPagado.Text = "$0.00";
            //
            // lblEstadoHeader
            //
            lblEstadoHeader.AutoSize = true;
            lblEstadoHeader.Font = new Font("Segoe UI", 9F);
            lblEstadoHeader.ForeColor = Color.FromArgb(124, 138, 165);
            lblEstadoHeader.Location = new Point(490, 30);
            lblEstadoHeader.Name = "lblEstadoHeader";
            lblEstadoHeader.Size = new Size(88, 20);
            lblEstadoHeader.TabIndex = 6;
            lblEstadoHeader.Text = "Estado del pago";
            //
            // lblEstadoPago
            //
            lblEstadoPago.AutoSize = true;
            lblEstadoPago.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblEstadoPago.ForeColor = Color.FromArgb(230, 238, 252);
            lblEstadoPago.Location = new Point(490, 54);
            lblEstadoPago.Name = "lblEstadoPago";
            lblEstadoPago.Size = new Size(90, 25);
            lblEstadoPago.TabIndex = 7;
            lblEstadoPago.Text = "PENDIENTE";
            //
            // grpRegistrarPago
            //
            grpRegistrarPago.Controls.Add(lblMonto);
            grpRegistrarPago.Controls.Add(nudMonto);
            grpRegistrarPago.Controls.Add(lblTipoPago);
            grpRegistrarPago.Controls.Add(cmbTipoPago);
            grpRegistrarPago.Controls.Add(lblFolio);
            grpRegistrarPago.Controls.Add(txtFolio);
            grpRegistrarPago.Controls.Add(lblObservacion);
            grpRegistrarPago.Controls.Add(txtObservacion);
            grpRegistrarPago.Controls.Add(btnAgregarPago);
            grpRegistrarPago.Dock = DockStyle.Top;
            grpRegistrarPago.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpRegistrarPago.ForeColor = Color.FromArgb(45, 212, 255);
            grpRegistrarPago.Location = new Point(20, 105);
            grpRegistrarPago.Name = "grpRegistrarPago";
            grpRegistrarPago.Size = new Size(740, 145);
            grpRegistrarPago.TabIndex = 1;
            grpRegistrarPago.TabStop = false;
            grpRegistrarPago.Text = "Registrar nuevo pago";
            //
            // lblMonto
            //
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Segoe UI", 8.5F);
            lblMonto.ForeColor = Color.FromArgb(230, 238, 252);
            lblMonto.Location = new Point(17, 28);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(52, 20);
            lblMonto.TabIndex = 0;
            lblMonto.Text = "Monto:";
            //
            // nudMonto
            //
            nudMonto.BackColor = Color.FromArgb(15, 42, 79);
            nudMonto.DecimalPlaces = 2;
            nudMonto.Font = new Font("Segoe UI", 9F);
            nudMonto.ForeColor = Color.FromArgb(230, 238, 252);
            nudMonto.Location = new Point(17, 52);
            nudMonto.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMonto.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(140, 27);
            nudMonto.TabIndex = 0;
            nudMonto.TextAlign = HorizontalAlignment.Right;
            nudMonto.ThousandsSeparator = true;
            nudMonto.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            //
            // lblTipoPago
            //
            lblTipoPago.AutoSize = true;
            lblTipoPago.Font = new Font("Segoe UI", 8.5F);
            lblTipoPago.ForeColor = Color.FromArgb(230, 238, 252);
            lblTipoPago.Location = new Point(177, 28);
            lblTipoPago.Name = "lblTipoPago";
            lblTipoPago.Size = new Size(98, 20);
            lblTipoPago.TabIndex = 1;
            lblTipoPago.Text = "Forma de pago:";
            //
            // cmbTipoPago
            //
            cmbTipoPago.BackColor = Color.FromArgb(15, 42, 79);
            cmbTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPago.FlatStyle = FlatStyle.Flat;
            cmbTipoPago.Font = new Font("Segoe UI", 9F);
            cmbTipoPago.ForeColor = Color.FromArgb(230, 238, 252);
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbTipoPago.Location = new Point(177, 52);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(160, 28);
            cmbTipoPago.TabIndex = 1;
            //
            // lblFolio
            //
            lblFolio.AutoSize = true;
            lblFolio.Font = new Font("Segoe UI", 8.5F);
            lblFolio.ForeColor = Color.FromArgb(230, 238, 252);
            lblFolio.Location = new Point(357, 28);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(46, 20);
            lblFolio.TabIndex = 2;
            lblFolio.Text = "Folio:";
            //
            // txtFolio
            //
            txtFolio.BackColor = Color.FromArgb(15, 42, 79);
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F);
            txtFolio.ForeColor = Color.FromArgb(230, 238, 252);
            txtFolio.Location = new Point(357, 52);
            txtFolio.MaxLength = 50;
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(160, 27);
            txtFolio.TabIndex = 2;
            //
            // lblObservacion
            //
            lblObservacion.AutoSize = true;
            lblObservacion.Font = new Font("Segoe UI", 8.5F);
            lblObservacion.ForeColor = Color.FromArgb(230, 238, 252);
            lblObservacion.Location = new Point(17, 88);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(88, 20);
            lblObservacion.TabIndex = 3;
            lblObservacion.Text = "Observación:";
            //
            // txtObservacion
            //
            txtObservacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObservacion.BackColor = Color.FromArgb(15, 42, 79);
            txtObservacion.BorderStyle = BorderStyle.FixedSingle;
            txtObservacion.Font = new Font("Segoe UI", 9F);
            txtObservacion.ForeColor = Color.FromArgb(230, 238, 252);
            txtObservacion.Location = new Point(17, 110);
            txtObservacion.MaxLength = 200;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(488, 27);
            txtObservacion.TabIndex = 3;
            //
            // btnAgregarPago
            //
            btnAgregarPago.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarPago.Estilo = EstiloBoton.Primario;
            btnAgregarPago.Location = new Point(525, 98);
            btnAgregarPago.Name = "btnAgregarPago";
            btnAgregarPago.Size = new Size(200, 40);
            btnAgregarPago.TabIndex = 4;
            btnAgregarPago.Text = "+ Registrar pago";
            btnAgregarPago.Click += btnAgregarPago_Click;
            //
            // panelPagosBarra
            //
            panelPagosBarra.Controls.Add(panelAccionesPagos);
            panelPagosBarra.Controls.Add(lblPagos);
            panelPagosBarra.Dock = DockStyle.Top;
            panelPagosBarra.Location = new Point(20, 250);
            panelPagosBarra.Name = "panelPagosBarra";
            panelPagosBarra.Size = new Size(740, 52);
            panelPagosBarra.TabIndex = 2;
            //
            // lblPagos
            //
            lblPagos.AutoSize = true;
            lblPagos.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPagos.ForeColor = Color.FromArgb(45, 212, 255);
            lblPagos.Location = new Point(0, 17);
            lblPagos.Name = "lblPagos";
            lblPagos.Size = new Size(125, 21);
            lblPagos.TabIndex = 0;
            lblPagos.Text = "Pagos registrados";
            //
            // panelAccionesPagos
            //
            panelAccionesPagos.AutoSize = true;
            panelAccionesPagos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelAccionesPagos.Controls.Add(btnAnularPago);
            panelAccionesPagos.Dock = DockStyle.Right;
            panelAccionesPagos.Location = new Point(620, 0);
            panelAccionesPagos.Name = "panelAccionesPagos";
            panelAccionesPagos.Padding = new Padding(0, 8, 0, 0);
            panelAccionesPagos.Size = new Size(120, 52);
            panelAccionesPagos.TabIndex = 1;
            panelAccionesPagos.WrapContents = false;
            //
            // btnAnularPago
            //
            btnAnularPago.Enabled = false;
            btnAnularPago.Estilo = EstiloBoton.Peligro;
            btnAnularPago.Margin = new Padding(0);
            btnAnularPago.Name = "btnAnularPago";
            btnAnularPago.Size = new Size(120, 36);
            btnAnularPago.TabIndex = 0;
            btnAnularPago.Text = "Anular pago";
            btnAnularPago.Click += btnAnularPago_Click;
            //
            // dgvPagos
            //
            dgvPagos.Dock = DockStyle.Fill;
            dgvPagos.Location = new Point(20, 302);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.Size = new Size(740, 201);
            dgvPagos.TabIndex = 3;
            dgvPagos.CellFormatting += dgvPagos_CellFormatting;
            dgvPagos.SelectionChanged += dgvPagos_SelectionChanged;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(btnCerrar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 580);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(780, 60);
            panelPie.TabIndex = 2;
            //
            // btnCerrar
            //
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Location = new Point(660, 10);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 40);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            //
            // FrmPagoSocioMembresiaModal
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCerrar;
            ClientSize = new Size(780, 640);
            Controls.Add(panelContenido);
            Controls.Add(panelPie);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(740, 560);
            Name = "FrmPagoSocioMembresiaModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pagos de Membresía";
            Load += FrmPagoSocioMembresiaModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            panelPagosBarra.ResumeLayout(false);
            panelPagosBarra.PerformLayout();
            panelAccionesPagos.ResumeLayout(false);
            grpRegistrarPago.ResumeLayout(false);
            grpRegistrarPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
            grpDetallesMembresia.ResumeLayout(false);
            grpDetallesMembresia.PerformLayout();
            panelPie.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelContenido;
        private GridTema dgvPagos;
        private Panel panelPagosBarra;
        private Label lblPagos;
        private FlowLayoutPanel panelAccionesPagos;
        private BotonTema btnAnularPago;
        private GroupBox grpRegistrarPago;
        private Label lblMonto;
        private NumericUpDown nudMonto;
        private Label lblTipoPago;
        private ComboBox cmbTipoPago;
        private Label lblFolio;
        private TextBox txtFolio;
        private Label lblObservacion;
        private TextBox txtObservacion;
        private BotonTema btnAgregarPago;
        private GroupBox grpDetallesMembresia;
        private Label lblInicioHeader;
        private Label lblFechaInicio;
        private Label lblPrecioHeader;
        private Label lblPrecioMembresia;
        private Label lblPagadoHeader;
        private Label lblTotalPagado;
        private Label lblEstadoHeader;
        private Label lblEstadoPago;
        private Panel panelPie;
        private BotonTema btnCerrar;
    }
}