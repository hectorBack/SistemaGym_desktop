namespace Presentacion.Forms.Reportes
{
    partial class FrmReportes
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
            tabControlReportes = new FlatTabControl();

            tabInventario = new TabPage();
            tabMembresias = new TabPage();
            tabSocios = new TabPage();
            tabRegistro = new TabPage();
            tabVentas = new TabPage();
            tabVisitas = new TabPage();
            tabPagos = new TabPage();
            tabMovimientos = new TabPage();

            dgvInventario = new DataGridView();
            dgvMembresias = new DataGridView();
            dgvSocios = new DataGridView();
            dgvRegistro = new DataGridView();
            dgvVentas = new DataGridView();
            dgvVisitas = new DataGridView();
            dgvPagos = new DataGridView();
            dgvMovimientos = new DataGridView();

            panelTop.SuspendLayout();
            tabControlReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();

            // 
            // panelTop
            // 
            panelTop.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 60);
            panelTop.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Bold", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(240, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Módulo de Reportes";

            // 
            // tabControlReportes
            // 
            tabControlReportes.Dock = DockStyle.Fill;
            tabControlReportes.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tabControlReportes.Location = new Point(0, 60);
            tabControlReportes.Name = "tabControlReportes";
            tabControlReportes.SelectedIndex = 0;
            tabControlReportes.Size = new Size(914, 740);
            tabControlReportes.TabIndex = 1;
            tabControlReportes.SelectedIndexChanged += tabControlReportes_SelectedIndexChanged;

            // Agregar pestañas al TabControl
            tabControlReportes.Controls.Add(tabInventario);
            tabControlReportes.Controls.Add(tabMembresias);
            tabControlReportes.Controls.Add(tabSocios);
            tabControlReportes.Controls.Add(tabRegistro);
            tabControlReportes.Controls.Add(tabVentas);
            tabControlReportes.Controls.Add(tabVisitas);
            tabControlReportes.Controls.Add(tabPagos);
            tabControlReportes.Controls.Add(tabMovimientos);

            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(914, 800);
            Controls.Add(tabControlReportes);
            Controls.Add(panelTop);
            DoubleBuffered = true; // Reduce el parpadeo en renderizado continuo
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmReportes";
            Text = "Reportes";
            Load += FrmReportes_Load;

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tabControlReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistro).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlatTabControl tabControlReportes;

        private TabPage tabInventario;
        private TabPage tabMembresias;
        private TabPage tabSocios;
        private TabPage tabRegistro;
        private TabPage tabVentas;
        private TabPage tabVisitas;
        private TabPage tabPagos;
        private TabPage tabMovimientos;

        private DataGridView dgvInventario;
        private DataGridView dgvMembresias;
        private DataGridView dgvSocios;
        private DataGridView dgvRegistro;
        private DataGridView dgvVentas;
        private DataGridView dgvVisitas;
        private DataGridView dgvPagos;
        private DataGridView dgvMovimientos;
    }
}