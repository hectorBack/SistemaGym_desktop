namespace Presentacion.Forms.Compras
{
    partial class FrmCompraDetalleModal
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();

            panelHeader = new Panel();
            lblTitulo = new Label();
            panelInfo = new Panel();
            lblFechaEtiqueta = new Label();
            lblFechaValor = new Label();
            lblTotalEtiqueta = new Label();
            lblTotalCalculado = new Label();
            dgvDetalles = new DataGridView();
            btnCerrar = new Button();

            panelHeader.SuspendLayout();
            panelInfo.SuspendLayout();
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
            panelHeader.Size = new Size(620, 50);
            panelHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(160, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle de la Compra";

            // 
            // panelInfo
            // 
            panelInfo.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelInfo.Controls.Add(lblFechaEtiqueta);
            panelInfo.Controls.Add(lblFechaValor);
            panelInfo.Controls.Add(lblTotalEtiqueta);
            panelInfo.Controls.Add(lblTotalCalculado);
            panelInfo.Location = new Point(20, 65);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(580, 50);
            panelInfo.TabIndex = 1;

            // 
            // lblFechaEtiqueta
            // 
            lblFechaEtiqueta.AutoSize = true;
            lblFechaEtiqueta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblFechaEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblFechaEtiqueta.Location = new Point(15, 16);
            lblFechaEtiqueta.Name = "lblFechaEtiqueta";
            lblFechaEtiqueta.Size = new Size(46, 17);
            lblFechaEtiqueta.TabIndex = 0;
            lblFechaEtiqueta.Text = "Fecha:";

            // 
            // lblFechaValor
            // 
            lblFechaValor.AutoSize = true;
            lblFechaValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFechaValor.Location = new Point(65, 16);
            lblFechaValor.Name = "lblFechaValor";
            lblFechaValor.Size = new Size(118, 17);
            lblFechaValor.TabIndex = 1;
            lblFechaValor.Text = "dd/MM/yyyy HH:mm";

            // 
            // lblTotalEtiqueta
            // 
            lblTotalEtiqueta.AutoSize = true;
            lblTotalEtiqueta.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalEtiqueta.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTotalEtiqueta.Location = new Point(410, 15);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(43, 19);
            lblTotalEtiqueta.TabIndex = 2;
            lblTotalEtiqueta.Text = "Total:";

            // 
            // lblTotalCalculado
            // 
            lblTotalCalculado.AutoSize = true;
            lblTotalCalculado.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalCalculado.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTotalCalculado.Location = new Point(460, 14);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(45, 20);
            lblTotalCalculado.TabIndex = 3;
            lblTotalCalculado.Text = "$0.00";

            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.BackgroundColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvDetalles.BorderStyle = BorderStyle.None;

            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dataGridViewCellStyle1.SelectionBackColor = ColorTranslator.FromHtml("#0f2a4f");
            dataGridViewCellStyle1.SelectionForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dataGridViewCellStyle2.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvDetalles.DefaultCellStyle = dataGridViewCellStyle2;

            dgvDetalles.EnableHeadersVisualStyles = false;
            dgvDetalles.GridColor = ColorTranslator.FromHtml("#1f6feb");
            dgvDetalles.Location = new Point(20, 130);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(580, 240);
            dgvDetalles.TabIndex = 2;

            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCerrar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCerrar.Location = new Point(505, 385);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(95, 32);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            // 
            // FrmCompraDetalleModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(620, 435);
            Controls.Add(btnCerrar);
            Controls.Add(dgvDetalles);
            Controls.Add(panelInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCompraDetalleModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Compra";
            Load += FrmCompraDetalleModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelInfo;
        private Label lblFechaEtiqueta;
        private Label lblFechaValor;
        private Label lblTotalEtiqueta;
        private Label lblTotalCalculado;
        private DataGridView dgvDetalles;
        private Button btnCerrar;
    }
}