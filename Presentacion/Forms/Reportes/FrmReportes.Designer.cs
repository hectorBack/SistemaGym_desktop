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

            dgvInventario = new GridTema();
            dgvMembresias = new GridTema();
            dgvSocios = new GridTema();
            dgvRegistro = new GridTema();
            dgvVentas = new GridTema();
            dgvVisitas = new GridTema();
            dgvPagos = new GridTema();
            dgvMovimientos = new GridTema();

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
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
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
            lblTitulo.Size = new Size(240, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Módulo de Reportes";

            // 
            // tabControlReportes
            // 
            tabControlReportes.Dock = DockStyle.Fill;
            tabControlReportes.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tabControlReportes.Location = new Point(0, 70);
            tabControlReportes.Name = "tabControlReportes";
            tabControlReportes.SelectedIndex = 0;
            tabControlReportes.Size = new Size(914, 730);
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
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(tabControlReportes);
            Controls.Add(panelTop);
            DoubleBuffered = true; // Reduce el parpadeo en renderizado continuo
            FormBorderStyle = FormBorderStyle.None;
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

        private GridTema dgvInventario;
        private GridTema dgvMembresias;
        private GridTema dgvSocios;
        private GridTema dgvRegistro;
        private GridTema dgvVentas;
        private GridTema dgvVisitas;
        private GridTema dgvPagos;
        private GridTema dgvMovimientos;
    }
}