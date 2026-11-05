namespace Presentacion.Forms.Configuracion
{
    partial class FrmConfiguracionMasConfiguraciones
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

            lblMoneda = new Label();
            txtMoneda = new TextBox();

            chkEnviarPagoPorCorreo = new CheckBox();

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
            lblTitulo.Size = new Size(320, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Más Configuraciones";

            // 
            // panelContenido
            // 
            panelContenido.AutoScroll = true;
            panelContenido.Controls.Add(lblMoneda);
            panelContenido.Controls.Add(txtMoneda);
            panelContenido.Controls.Add(chkEnviarPagoPorCorreo);
            panelContenido.Controls.Add(btnGuardar);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 70);
            panelContenido.Margin = new Padding(3, 4, 3, 4);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(30);
            panelContenido.Size = new Size(914, 730);
            panelContenido.TabIndex = 1;

            // 
            // lblMoneda
            // 
            lblMoneda.AutoSize = true;
            lblMoneda.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblMoneda.ForeColor = Color.FromArgb(230, 238, 252);
            lblMoneda.Location = new Point(30, 35);
            lblMoneda.Name = "lblMoneda";
            lblMoneda.Size = new Size(80, 23);
            lblMoneda.TabIndex = 0;
            lblMoneda.Text = "Moneda:";

            // 
            // txtMoneda
            // 
            txtMoneda.BackColor = Color.FromArgb(15, 42, 79);
            txtMoneda.BorderStyle = BorderStyle.FixedSingle;
            txtMoneda.Font = new Font("Segoe UI", 10.5F);
            txtMoneda.ForeColor = Color.FromArgb(230, 238, 252);
            txtMoneda.Location = new Point(30, 65);
            txtMoneda.MaxLength = 10;
            txtMoneda.Name = "txtMoneda";
            txtMoneda.Size = new Size(250, 31);
            txtMoneda.TabIndex = 1;

            // 
            // chkEnviarPagoPorCorreo
            // 
            chkEnviarPagoPorCorreo.AutoSize = true;
            chkEnviarPagoPorCorreo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            chkEnviarPagoPorCorreo.ForeColor = Color.FromArgb(230, 238, 252);
            chkEnviarPagoPorCorreo.Location = new Point(30, 125);
            chkEnviarPagoPorCorreo.Name = "chkEnviarPagoPorCorreo";
            chkEnviarPagoPorCorreo.Size = new Size(320, 27);
            chkEnviarPagoPorCorreo.TabIndex = 2;
            chkEnviarPagoPorCorreo.Text = "Enviar pago por correo electrónico";
            chkEnviarPagoPorCorreo.UseVisualStyleBackColor = true;

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(31, 111, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 200);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 42);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // FrmConfiguracionMasConfiguraciones
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
            Name = "FrmConfiguracionMasConfiguraciones";
            Text = "Más Configuraciones";
            Load += FrmConfiguracionMasConfiguraciones_Load;

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
        private Label lblMoneda;
        private TextBox txtMoneda;
        private CheckBox chkEnviarPagoPorCorreo;
        private Button btnGuardar;
    }
}