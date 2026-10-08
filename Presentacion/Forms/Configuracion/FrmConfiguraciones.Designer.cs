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
            tabMasConfiguraciones = new TabPage();

            panelTop.SuspendLayout();
            tabControlConfiguraciones.SuspendLayout();
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
            lblTitulo.Size = new Size(300, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Módulo de Configuración";

            // 
            // tabControlConfiguraciones
            // 
            tabControlConfiguraciones.Dock = DockStyle.Fill;
            tabControlConfiguraciones.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tabControlConfiguraciones.Location = new Point(0, 60);
            tabControlConfiguraciones.Name = "tabControlConfiguraciones";
            tabControlConfiguraciones.SelectedIndex = 0;
            tabControlConfiguraciones.Size = new Size(914, 740);
            tabControlConfiguraciones.TabIndex = 1;
            tabControlConfiguraciones.SelectedIndexChanged += tabControlConfiguraciones_SelectedIndexChanged;

            // Agregar pestañas al TabControl
            tabControlConfiguraciones.Controls.Add(tabCorteCaja);
            tabControlConfiguraciones.Controls.Add(tabDatosGimnasio);
            tabControlConfiguraciones.Controls.Add(tabCorreos);
            tabControlConfiguraciones.Controls.Add(tabRespaldos);
            tabControlConfiguraciones.Controls.Add(tabMasConfiguraciones);

            // 
            // FrmConfiguraciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
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
        private TabPage tabMasConfiguraciones;
    }
}