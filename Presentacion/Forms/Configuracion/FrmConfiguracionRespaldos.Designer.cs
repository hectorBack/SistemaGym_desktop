namespace Presentacion.Forms.Configuracion
{
    partial class FrmConfiguracionRespaldos
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
            panelContenido = new Panel();
            lblInstruccion = new Label();
            lblRecomendacion = new Label();
            txtRuta = new TextBox();
            btnSeleccionarCarpeta = new Button();
            btnGuardar = new Button();
            panelTop.SuspendLayout();
            panelContenido.SuspendLayout();
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
            panelTop.Size = new Size(914, 70);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Bold", 13.5F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(346, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuración de los Respaldos";
            // 
            // panelContenido
            // 
            panelContenido.AutoScroll = true;
            panelContenido.Controls.Add(lblInstruccion);
            panelContenido.Controls.Add(lblRecomendacion);
            panelContenido.Controls.Add(txtRuta);
            panelContenido.Controls.Add(btnSeleccionarCarpeta);
            panelContenido.Controls.Add(btnGuardar);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 70);
            panelContenido.Margin = new Padding(3, 4, 3, 4);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(30);
            panelContenido.Size = new Size(914, 730);
            panelContenido.TabIndex = 1;
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblInstruccion.ForeColor = Color.FromArgb(230, 238, 252);
            lblInstruccion.Location = new Point(30, 30);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(393, 23);
            lblInstruccion.TabIndex = 0;
            lblInstruccion.Text = "Selecciona la ruta donde deseas que se generen tus respaldos";
            // 
            // lblRecomendacion
            // 
            lblRecomendacion.AutoSize = true;
            lblRecomendacion.Font = new Font("Segoe UI", 9.5F);
            lblRecomendacion.ForeColor = Color.FromArgb(124, 138, 165);
            lblRecomendacion.Location = new Point(30, 65);
            lblRecomendacion.Name = "lblRecomendacion";
            lblRecomendacion.Size = new Size(399, 21);
            lblRecomendacion.TabIndex = 1;
            lblRecomendacion.Text = "Recomendado utilizar una carpeta sincronizada con dropbox o google drive";
            // 
            // txtRuta
            // 
            txtRuta.BackColor = Color.FromArgb(15, 42, 79);
            txtRuta.BorderStyle = BorderStyle.FixedSingle;
            txtRuta.Font = new Font("Segoe UI", 10.5F);
            txtRuta.ForeColor = Color.FromArgb(230, 238, 252);
            txtRuta.Location = new Point(30, 115);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(450, 31);
            txtRuta.TabIndex = 2;
            // 
            // btnSeleccionarCarpeta
            // 
            btnSeleccionarCarpeta.BackColor = Color.FromArgb(31, 111, 235);
            btnSeleccionarCarpeta.FlatAppearance.BorderSize = 0;
            btnSeleccionarCarpeta.FlatStyle = FlatStyle.Flat;
            btnSeleccionarCarpeta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSeleccionarCarpeta.ForeColor = Color.White;
            btnSeleccionarCarpeta.Location = new Point(495, 113);
            btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
            btnSeleccionarCarpeta.Size = new Size(160, 35);
            btnSeleccionarCarpeta.TabIndex = 3;
            btnSeleccionarCarpeta.Text = "Seleccionar carpeta";
            btnSeleccionarCarpeta.UseVisualStyleBackColor = false;
            btnSeleccionarCarpeta.Click += btnSeleccionarCarpeta_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(31, 111, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 190);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 42);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmConfiguracionRespaldos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(panelContenido);
            Controls.Add(panelTop);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConfiguracionRespaldos";
            Text = "Configuración de Respaldos";
            Load += FrmConfiguracionRespaldos_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContenido.ResumeLayout(false);
            panelContenido.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Panel panelContenido;
        private Label lblInstruccion;
        private Label lblRecomendacion;
        private TextBox txtRuta;
        private Button btnSeleccionarCarpeta;
        private Button btnGuardar;
    }
}