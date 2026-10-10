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
            lblFechaEtiqueta = new Label();
            lblFechaValor = new Label();
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
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(663, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(187, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle de la Compra";
            // 
            // lblFechaEtiqueta
            // 
            lblFechaEtiqueta.AutoSize = true;
            lblFechaEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFechaEtiqueta.ForeColor = Color.FromArgb(45, 212, 255);
            lblFechaEtiqueta.Location = new Point(41, 118);
            lblFechaEtiqueta.Name = "lblFechaEtiqueta";
            lblFechaEtiqueta.Size = new Size(58, 21);
            lblFechaEtiqueta.TabIndex = 3;
            lblFechaEtiqueta.Text = "Fecha:";
            // 
            // lblFechaValor
            lblFechaValor.AutoSize = true;
            lblFechaValor.Font = new Font("Segoe UI", 9.5F);
            lblFechaValor.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaValor.Location = new Point(100, 118);
            lblFechaValor.Name = "lblFechaValor";
            lblFechaValor.Size = new Size(140, 21);
            lblFechaValor.TabIndex = 4;
            lblFechaValor.Text = "dd/MM/yyyy HH:mm";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.BackgroundColor = Color.FromArgb(15, 42, 79);
            dgvDetalles.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalles.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDetalles.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDetalles.EnableHeadersVisualStyles = false;
            dgvDetalles.GridColor = Color.FromArgb(11, 15, 26);
            dgvDetalles.Location = new Point(29, 213);
            dgvDetalles.Margin = new Padding(3, 4, 3, 4);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(606, 293);
            dgvDetalles.TabIndex = 11;
            // 
            // lblTotalEtiqueta
            // 
            lblTotalEtiqueta.AutoSize = true;
            lblTotalEtiqueta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblTotalEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotalEtiqueta.Location = new Point(403, 116);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(91, 25);
            lblTotalEtiqueta.TabIndex = 12;
            lblTotalEtiqueta.Text = "TOTAL:";
            // 
            // lblTotalCalculado
            // 
            lblTotalCalculado.AutoSize = true;
            lblTotalCalculado.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTotalCalculado.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotalCalculado.Location = new Point(483, 112);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(76, 29);
            lblTotalCalculado.TabIndex = 13;
            lblTotalCalculado.Text = "$0.00";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(31, 111, 235);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(520, 587);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(114, 43);
            btnCerrar.TabIndex = 14;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmCompraDetalleModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(663, 653);
            Controls.Add(btnCerrar);
            Controls.Add(lblTotalCalculado);
            Controls.Add(lblTotalEtiqueta);
            Controls.Add(dgvDetalles);
            Controls.Add(lblFechaValor);
            Controls.Add(lblFechaEtiqueta);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCompraDetalleModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de la Compra";
            Load += FrmCompraDetalleModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblFechaEtiqueta;
        private Label lblFechaValor;
        private DataGridView dgvDetalles;
        private Label lblTotalEtiqueta;
        private Label lblTotalCalculado;
        private Button btnCerrar;
    }
}