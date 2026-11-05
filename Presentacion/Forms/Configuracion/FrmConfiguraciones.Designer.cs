using Presentacion.Forms.Reportes;

namespace Presentacion.Forms.Configuracion
{
    partial class FrmConfiguraciones
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
            tabControlConfiguraciones = new FlatTabControl();
            tabCorteCaja = new TabPage();
            tabDatosGimnasio = new TabPage();
            tabCorreos = new TabPage();
            tabRespaldos = new TabPage();
            panelTop.SuspendLayout();
            tabControlConfiguraciones.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
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
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(306, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Módulo de Configuración";
            // 
            // tabControlConfiguraciones
            // 
            tabControlConfiguraciones.Controls.Add(tabDatosGimnasio);
            tabControlConfiguraciones.Controls.Add(tabCorteCaja);
            tabControlConfiguraciones.Controls.Add(tabCorreos);
            tabControlConfiguraciones.Controls.Add(tabRespaldos);
            tabControlConfiguraciones.Dock = DockStyle.Fill;
            tabControlConfiguraciones.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlConfiguraciones.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tabControlConfiguraciones.Location = new Point(0, 60);
            tabControlConfiguraciones.Name = "tabControlConfiguraciones";
            tabControlConfiguraciones.Padding = new Point(16, 6);
            tabControlConfiguraciones.SelectedIndex = 0;
            tabControlConfiguraciones.Size = new Size(914, 740);
            tabControlConfiguraciones.TabIndex = 1;
            tabControlConfiguraciones.SelectedIndexChanged += tabControlConfiguraciones_SelectedIndexChanged;
            // 
            // tabCorteCaja
            // 
            tabCorteCaja.Location = new Point(4, 35);
            tabCorteCaja.Name = "tabCorteCaja";
            tabCorteCaja.Size = new Size(906, 701);
            tabCorteCaja.TabIndex = 0;
            // 
            // tabDatosGimnasio
            // 
            tabDatosGimnasio.Location = new Point(4, 35);
            tabDatosGimnasio.Name = "tabDatosGimnasio";
            tabDatosGimnasio.Size = new Size(906, 701);
            tabDatosGimnasio.TabIndex = 1;
            // 
            // tabCorreos
            // 
            tabCorreos.Location = new Point(4, 35);
            tabCorreos.Name = "tabCorreos";
            tabCorreos.Size = new Size(906, 701);
            tabCorreos.TabIndex = 2;
            // 
            // tabRespaldos
            // 
            tabRespaldos.Location = new Point(4, 35);
            tabRespaldos.Name = "tabRespaldos";
            tabRespaldos.Size = new Size(906, 701);
            tabRespaldos.TabIndex = 3;
            // 
            // FrmConfiguraciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(tabControlConfiguraciones);
            Controls.Add(panelTop);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConfiguraciones";
            Text = "Configuraciones";
            Load += FrmConfiguraciones_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tabControlConfiguraciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlatTabControl tabControlConfiguraciones;

        private TabPage tabCorteCaja;
        private TabPage tabDatosGimnasio;
        private TabPage tabCorreos;
        private TabPage tabRespaldos;
    }
}