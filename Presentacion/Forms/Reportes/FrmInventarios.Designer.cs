namespace Presentacion.Forms.Reportes
{
    partial class FrmInventarios
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
            dgvInventario = new GridTema();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
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
            lblTitulo.Size = new Size(430, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte del inventario existente";
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
            // dgvInventario
            //
            dgvInventario.Dock = DockStyle.Fill;
            dgvInventario.Location = new Point(0, 70);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.Size = new Size(914, 730);
            dgvInventario.TabIndex = 1;
            //
            // FrmInventarios
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvInventario);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInventarios";
            Text = "Inventario";
            Load += FrmInventarios_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnExportarExcel;
        private GridTema dgvInventario;
    }
}