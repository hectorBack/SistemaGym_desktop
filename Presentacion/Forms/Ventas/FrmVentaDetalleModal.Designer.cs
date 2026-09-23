namespace Presentacion.Forms.Ventas
{
    partial class FrmVentaDetalleModal
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
            lblFolioEtiqueta = new Label();
            lblFolioValor = new Label();
            lblFechaEtiqueta = new Label();
            lblFechaValor = new Label();
            lblAtendidoEtiqueta = new Label();
            lblAtendidoValor = new Label();
            lblSocioEtiqueta = new Label();
            lblSocioValor = new Label();
            lblEstadoEtiqueta = new Label();
            lblEstadoValor = new Label();
            dgvDetalles = new DataGridView();
            lblTotalEtiqueta = new Label();
            lblTotalCalculado = new Label();
            btnCerrar = new Button();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(580, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(185, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle de Venta";
            // 
            // lblFolioEtiqueta
            // 
            lblFolioEtiqueta.AutoSize = true;
            lblFolioEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblFolioEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblFolioEtiqueta.Location = new Point(25, 65);
            lblFolioEtiqueta.Name = "lblFolioEtiqueta";
            lblFolioEtiqueta.Size = new Size(61, 17);
            lblFolioEtiqueta.TabIndex = 1;
            lblFolioEtiqueta.Text = "N° Venta:";
            // 
            // lblFolioValor
            // 
            lblFolioValor.AutoSize = true;
            lblFolioValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblFolioValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFolioValor.Location = new Point(90, 65);
            lblFolioValor.Name = "lblFolioValor";
            lblFolioValor.Size = new Size(25, 17);
            lblFolioValor.TabIndex = 2;
            lblFolioValor.Text = "#0";
            // 
            // lblFechaEtiqueta
            // 
            lblFechaEtiqueta.AutoSize = true;
            lblFechaEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblFechaEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblFechaEtiqueta.Location = new Point(320, 65);
            lblFechaEtiqueta.Name = "lblFechaEtiqueta";
            lblFechaEtiqueta.Size = new Size(47, 17);
            lblFechaEtiqueta.TabIndex = 3;
            lblFechaEtiqueta.Text = "Fecha:";
            // 
            // lblFechaValor
            // 
            lblFechaValor.AutoSize = true;
            lblFechaValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFechaValor.Location = new Point(372, 65);
            lblFechaValor.Name = "lblFechaValor";
            lblFechaValor.Size = new Size(74, 17);
            lblFechaValor.TabIndex = 4;
            lblFechaValor.Text = "--/--/---- --:--";
            // 
            // lblAtendidoEtiqueta
            // 
            lblAtendidoEtiqueta.AutoSize = true;
            lblAtendidoEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblAtendidoEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblAtendidoEtiqueta.Location = new Point(25, 95);
            lblAtendidoEtiqueta.Name = "lblAtendidoEtiqueta";
            lblAtendidoEtiqueta.Size = new Size(96, 17);
            lblAtendidoEtiqueta.TabIndex = 5;
            lblAtendidoEtiqueta.Text = "Atendido Por:";
            // 
            // lblAtendidoValor
            // 
            lblAtendidoValor.AutoSize = true;
            lblAtendidoValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblAtendidoValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblAtendidoValor.Location = new Point(125, 95);
            lblAtendidoValor.Name = "lblAtendidoValor";
            lblAtendidoValor.Size = new Size(31, 17);
            lblAtendidoValor.TabIndex = 6;
            lblAtendidoValor.Text = "N/A";
            // 
            // lblSocioEtiqueta
            // 
            lblSocioEtiqueta.AutoSize = true;
            lblSocioEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblSocioEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblSocioEtiqueta.Location = new Point(320, 95);
            lblSocioEtiqueta.Name = "lblSocioEtiqueta";
            lblSocioEtiqueta.Size = new Size(55, 17);
            lblSocioEtiqueta.TabIndex = 7;
            lblSocioEtiqueta.Text = "Cliente:";
            // 
            // lblSocioValor
            // 
            lblSocioValor.AutoSize = true;
            lblSocioValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSocioValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblSocioValor.Location = new Point(380, 95);
            lblSocioValor.Name = "lblSocioValor";
            lblSocioValor.Size = new Size(89, 17);
            lblSocioValor.TabIndex = 8;
            lblSocioValor.Text = "Cliente Casual";
            // 
            // lblEstadoEtiqueta
            // 
            lblEstadoEtiqueta.AutoSize = true;
            lblEstadoEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblEstadoEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblEstadoEtiqueta.Location = new Point(25, 125);
            lblEstadoEtiqueta.Name = "lblEstadoEtiqueta";
            lblEstadoEtiqueta.Size = new Size(53, 17);
            lblEstadoEtiqueta.TabIndex = 9;
            lblEstadoEtiqueta.Text = "Estado:";
            // 
            // lblEstadoValor
            // 
            lblEstadoValor.AutoSize = true;
            lblEstadoValor.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblEstadoValor.ForeColor = Color.ForestGreen;
            lblEstadoValor.Location = new Point(85, 125);
            lblEstadoValor.Name = "lblEstadoValor";
            lblEstadoValor.Size = new Size(82, 17);
            lblEstadoValor.TabIndex = 10;
            lblEstadoValor.Text = "Completada";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.BackgroundColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvDetalles.BorderStyle = BorderStyle.None;
            dgvDetalles.EnableHeadersVisualStyles = false;
            dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvDetalles.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvDetalles.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvDetalles.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvDetalles.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDetalles.GridColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvDetalles.Location = new Point(25, 160);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(530, 220);
            dgvDetalles.TabIndex = 11;
            // 
            // lblTotalEtiqueta
            // 
            lblTotalEtiqueta.AutoSize = true;
            lblTotalEtiqueta.Font = new Font("Segoe UI Bold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalEtiqueta.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTotalEtiqueta.Location = new Point(340, 398);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(62, 21);
            lblTotalEtiqueta.TabIndex = 12;
            lblTotalEtiqueta.Text = "TOTAL:";
            // 
            // lblTotalCalculado
            // 
            lblTotalCalculado.AutoSize = true;
            lblTotalCalculado.Font = new Font("Segoe UI Bold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalCalculado.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTotalCalculado.Location = new Point(410, 395);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(61, 25);
            lblTotalCalculado.TabIndex = 13;
            lblTotalCalculado.Text = "$0.00";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Location = new Point(455, 440);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 32);
            btnCerrar.TabIndex = 14;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmVentaDetalleModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(580, 490);
            Controls.Add(btnCerrar);
            Controls.Add(lblTotalCalculado);
            Controls.Add(lblTotalEtiqueta);
            Controls.Add(dgvDetalles);
            Controls.Add(lblEstadoValor);
            Controls.Add(lblEstadoEtiqueta);
            Controls.Add(lblSocioValor);
            Controls.Add(lblSocioEtiqueta);
            Controls.Add(lblAtendidoValor);
            Controls.Add(lblAtendidoEtiqueta);
            Controls.Add(lblFechaValor);
            Controls.Add(lblFechaEtiqueta);
            Controls.Add(lblFolioValor);
            Controls.Add(lblFolioEtiqueta);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVentaDetalleModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Venta";
            Load += FrmVentaDetalleModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblFolioEtiqueta;
        private Label lblFolioValor;
        private Label lblFechaEtiqueta;
        private Label lblFechaValor;
        private Label lblAtendidoEtiqueta;
        private Label lblAtendidoValor;
        private Label lblSocioEtiqueta;
        private Label lblSocioValor;
        private Label lblEstadoEtiqueta;
        private Label lblEstadoValor;
        private DataGridView dgvDetalles;
        private Label lblTotalEtiqueta;
        private Label lblTotalCalculado;
        private Button btnCerrar;
    }
}