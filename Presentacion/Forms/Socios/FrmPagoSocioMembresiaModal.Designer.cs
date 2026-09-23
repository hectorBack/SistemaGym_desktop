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
            grpDetallesMembresia = new GroupBox();
            lblFechaInicioHeader = new Label();
            lblFechaInicio = new Label();
            lblPrecioHeader = new Label();
            lblPrecioMembresia = new Label();
            lblTotalPagadoHeader = new Label();
            lblTotalPagado = new Label();
            lblEstadoHeader = new Label();
            lblEstadoPago = new Label();
            grpRegistrarPago = new GroupBox();
            lblImporte = new Label();
            txtImporte = new TextBox();
            lblTipoPago = new Label();
            cmbTipoPago = new ComboBox();
            lblFolio = new Label();
            txtFolio = new TextBox();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            btnAgregarPago = new Button();
            btnEliminarPago = new Button();
            dgvPagos = new DataGridView();

            panelHeader.SuspendLayout();
            grpDetallesMembresia.SuspendLayout();
            grpRegistrarPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Bold", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Pagos de Membresía";
            // 
            // grpDetallesMembresia
            // 
            grpDetallesMembresia.Controls.Add(lblFechaInicioHeader);
            grpDetallesMembresia.Controls.Add(lblFechaInicio);
            grpDetallesMembresia.Controls.Add(lblPrecioHeader);
            grpDetallesMembresia.Controls.Add(lblPrecioMembresia);
            grpDetallesMembresia.Controls.Add(lblTotalPagadoHeader);
            grpDetallesMembresia.Controls.Add(lblTotalPagado);
            grpDetallesMembresia.Controls.Add(lblEstadoHeader);
            grpDetallesMembresia.Controls.Add(lblEstadoPago);
            grpDetallesMembresia.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpDetallesMembresia.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            grpDetallesMembresia.Location = new Point(20, 60);
            grpDetallesMembresia.Name = "grpDetallesMembresia";
            grpDetallesMembresia.Size = new Size(760, 80);
            grpDetallesMembresia.TabIndex = 1;
            grpDetallesMembresia.TabStop = false;
            grpDetallesMembresia.Text = "Información de la Membresía";
            // 
            // lblFechaInicioHeader
            // 
            lblFechaInicioHeader.AutoSize = true;
            lblFechaInicioHeader.Font = new Font("Segoe UI", 8.5F);
            lblFechaInicioHeader.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFechaInicioHeader.Location = new Point(20, 25);
            lblFechaInicioHeader.Name = "lblFechaInicioHeader";
            lblFechaInicioHeader.Size = new Size(73, 15);
            lblFechaInicioHeader.TabIndex = 0;
            lblFechaInicioHeader.Text = "Fecha Inicio:";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI Bold", 10F);
            lblFechaInicio.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFechaInicio.Location = new Point(20, 45);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(85, 19);
            lblFechaInicio.TabIndex = 1;
            lblFechaInicio.Text = "--/--/----";
            // 
            // lblPrecioHeader
            // 
            lblPrecioHeader.AutoSize = true;
            lblPrecioHeader.Font = new Font("Segoe UI", 8.5F);
            lblPrecioHeader.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblPrecioHeader.Location = new Point(210, 25);
            lblPrecioHeader.Name = "lblPrecioHeader";
            lblPrecioHeader.Size = new Size(73, 15);
            lblPrecioHeader.TabIndex = 2;
            lblPrecioHeader.Text = "Precio Total:";
            // 
            // lblPrecioMembresia
            // 
            lblPrecioMembresia.AutoSize = true;
            lblPrecioMembresia.Font = new Font("Segoe UI Bold", 11F);
            lblPrecioMembresia.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblPrecioMembresia.Location = new Point(210, 44);
            lblPrecioMembresia.Name = "lblPrecioMembresia";
            lblPrecioMembresia.Size = new Size(47, 20);
            lblPrecioMembresia.TabIndex = 3;
            lblPrecioMembresia.Text = "$0.00";
            // 
            // lblTotalPagadoHeader
            // 
            lblTotalPagadoHeader.AutoSize = true;
            lblTotalPagadoHeader.Font = new Font("Segoe UI", 8.5F);
            lblTotalPagadoHeader.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTotalPagadoHeader.Location = new Point(400, 25);
            lblTotalPagadoHeader.Name = "lblTotalPagadoHeader";
            lblTotalPagadoHeader.Size = new Size(78, 15);
            lblTotalPagadoHeader.TabIndex = 4;
            lblTotalPagadoHeader.Text = "Total Pagado:";
            // 
            // lblTotalPagado
            // 
            lblTotalPagado.AutoSize = true;
            lblTotalPagado.Font = new Font("Segoe UI Bold", 11F);
            lblTotalPagado.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTotalPagado.Location = new Point(400, 44);
            lblTotalPagado.Name = "lblTotalPagado";
            lblTotalPagado.Size = new Size(47, 20);
            lblTotalPagado.TabIndex = 5;
            lblTotalPagado.Text = "$0.00";
            // 
            // lblEstadoHeader
            // 
            lblEstadoHeader.AutoSize = true;
            lblEstadoHeader.Font = new Font("Segoe UI", 8.5F);
            lblEstadoHeader.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblEstadoHeader.Location = new Point(600, 25);
            lblEstadoHeader.Name = "lblEstadoHeader";
            lblEstadoHeader.Size = new Size(45, 15);
            lblEstadoHeader.TabIndex = 6;
            lblEstadoHeader.Text = "Estado:";
            // 
            // lblEstadoPago
            // 
            lblEstadoPago.AutoSize = true;
            lblEstadoPago.Font = new Font("Segoe UI Bold", 11F);
            lblEstadoPago.ForeColor = Color.ForestGreen;
            lblEstadoPago.Location = new Point(600, 44);
            lblEstadoPago.Name = "lblEstadoPago";
            lblEstadoPago.Size = new Size(62, 20);
            lblEstadoPago.TabIndex = 7;
            lblEstadoPago.Text = "Pendiente";
            // 
            // grpRegistrarPago
            // 
            grpRegistrarPago.Controls.Add(lblImporte);
            grpRegistrarPago.Controls.Add(txtImporte);
            grpRegistrarPago.Controls.Add(lblTipoPago);
            grpRegistrarPago.Controls.Add(cmbTipoPago);
            grpRegistrarPago.Controls.Add(lblFolio);
            grpRegistrarPago.Controls.Add(txtFolio);
            grpRegistrarPago.Controls.Add(lblObservacion);
            grpRegistrarPago.Controls.Add(txtObservacion);
            grpRegistrarPago.Controls.Add(btnAgregarPago);
            grpRegistrarPago.Controls.Add(btnEliminarPago);
            grpRegistrarPago.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            grpRegistrarPago.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            grpRegistrarPago.Location = new Point(20, 150);
            grpRegistrarPago.Name = "grpRegistrarPago";
            grpRegistrarPago.Size = new Size(760, 130);
            grpRegistrarPago.TabIndex = 2;
            grpRegistrarPago.TabStop = false;
            grpRegistrarPago.Text = "Registrar Nuevo Abono / Pago";
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Font = new Font("Segoe UI", 8.5F);
            lblImporte.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblImporte.Location = new Point(15, 25);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(52, 15);
            lblImporte.TabIndex = 0;
            lblImporte.Text = "Monto ($):";
            // 
            // txtImporte
            // 
            txtImporte.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtImporte.BorderStyle = BorderStyle.FixedSingle;
            txtImporte.Font = new Font("Segoe UI", 9F);
            txtImporte.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtImporte.Location = new Point(15, 45);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(110, 23);
            txtImporte.TabIndex = 1;
            // 
            // lblTipoPago
            // 
            lblTipoPago.AutoSize = true;
            lblTipoPago.Font = new Font("Segoe UI", 8.5F);
            lblTipoPago.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTipoPago.Location = new Point(140, 25);
            lblTipoPago.Name = "lblTipoPago";
            lblTipoPago.Size = new Size(89, 15);
            lblTipoPago.TabIndex = 2;
            lblTipoPago.Text = "Forma de Pago:";
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            cmbTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPago.FlatStyle = FlatStyle.Flat;
            cmbTipoPago.Font = new Font("Segoe UI", 9F);
            cmbTipoPago.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Location = new Point(140, 45);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(140, 23);
            cmbTipoPago.TabIndex = 3;
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.Font = new Font("Segoe UI", 8.5F);
            lblFolio.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFolio.Location = new Point(295, 25);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(36, 15);
            lblFolio.TabIndex = 4;
            lblFolio.Text = "Folio:";
            // 
            // txtFolio
            // 
            txtFolio.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F);
            txtFolio.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtFolio.Location = new Point(295, 45);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(130, 23);
            txtFolio.TabIndex = 5;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Font = new Font("Segoe UI", 8.5F);
            lblObservacion.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblObservacion.Location = new Point(15, 78);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(75, 15);
            lblObservacion.TabIndex = 6;
            lblObservacion.Text = "Observación:";
            // 
            // txtObservacion
            // 
            txtObservacion.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtObservacion.BorderStyle = BorderStyle.FixedSingle;
            txtObservacion.Font = new Font("Segoe UI", 9F);
            txtObservacion.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtObservacion.Location = new Point(95, 76);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(330, 23);
            txtObservacion.TabIndex = 7;
            // 
            // btnAgregarPago
            // 
            btnAgregarPago.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnAgregarPago.FlatAppearance.BorderSize = 0;
            btnAgregarPago.FlatStyle = FlatStyle.Flat;
            btnAgregarPago.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAgregarPago.ForeColor = Color.White;
            btnAgregarPago.Location = new Point(450, 42);
            btnAgregarPago.Name = "btnAgregarPago";
            btnAgregarPago.Size = new Size(140, 58);
            btnAgregarPago.TabIndex = 8;
            btnAgregarPago.Text = "+ Registrar\r\nPago";
            btnAgregarPago.UseVisualStyleBackColor = false;
            btnAgregarPago.Click += btnAgregarPago_Click;
            // 
            // btnEliminarPago
            // 
            btnEliminarPago.BackColor = ColorTranslator.FromHtml("#d32f2f");
            btnEliminarPago.FlatAppearance.BorderSize = 0;
            btnEliminarPago.FlatStyle = FlatStyle.Flat;
            btnEliminarPago.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEliminarPago.ForeColor = Color.White;
            btnEliminarPago.Location = new Point(600, 42);
            btnEliminarPago.Name = "btnEliminarPago";
            btnEliminarPago.Size = new Size(140, 58);
            btnEliminarPago.TabIndex = 9;
            btnEliminarPago.Text = "Cancelar\r\nPago Sel.";
            btnEliminarPago.UseVisualStyleBackColor = false;
            btnEliminarPago.Click += btnEliminarPago_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvPagos.BorderStyle = BorderStyle.None;
            dgvPagos.EnableHeadersVisualStyles = false;
            dgvPagos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvPagos.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvPagos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPagos.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvPagos.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvPagos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvPagos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPagos.GridColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvPagos.Location = new Point(20, 295);
            dgvPagos.MultiSelect = false;
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersVisible = false;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.Size = new Size(760, 270);
            dgvPagos.TabIndex = 3;
            // 
            // FrmPagoSocioMembresiaModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(800, 580);
            Controls.Add(dgvPagos);
            Controls.Add(grpRegistrarPago);
            Controls.Add(grpDetallesMembresia);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPagoSocioMembresiaModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Historial y Registro de Pagos";
            Load += FrmPagoSocioMembresiaModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpDetallesMembresia.ResumeLayout(false);
            grpDetallesMembresia.PerformLayout();
            grpRegistrarPago.ResumeLayout(false);
            grpRegistrarPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private GroupBox grpDetallesMembresia;
        private Label lblFechaInicioHeader;
        private Label lblFechaInicio;
        private Label lblPrecioHeader;
        private Label lblPrecioMembresia;
        private Label lblTotalPagadoHeader;
        private Label lblTotalPagado;
        private Label lblEstadoHeader;
        private Label lblEstadoPago;
        private GroupBox grpRegistrarPago;
        private Label lblImporte;
        private TextBox txtImporte;
        private Label lblTipoPago;
        private ComboBox cmbTipoPago;
        private Label lblFolio;
        private TextBox txtFolio;
        private Label lblObservacion;
        private TextBox txtObservacion;
        private Button btnAgregarPago;
        private Button btnEliminarPago;
        private DataGridView dgvPagos;
    }
}