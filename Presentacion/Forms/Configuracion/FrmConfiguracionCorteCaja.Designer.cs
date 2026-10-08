namespace Presentacion.Forms.Configuracion
{
    partial class FrmConfiguracionCorteCaja
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
            lblEfectivoInicial = new Label();
            txtEfectivoInicial = new TextBox();
            lblEmailNotificacion = new Label();
            txtEmailNotificacion = new TextBox();
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
            lblTitulo.Size = new Size(370, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuración de Corte de Caja";

            // 
            // panelContenido
            // 
            panelContenido.AutoScroll = true;
            panelContenido.Controls.Add(lblEfectivoInicial);
            panelContenido.Controls.Add(txtEfectivoInicial);
            panelContenido.Controls.Add(lblEmailNotificacion);
            panelContenido.Controls.Add(txtEmailNotificacion);
            panelContenido.Controls.Add(btnGuardar);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 70);
            panelContenido.Margin = new Padding(3, 4, 3, 4);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(30);
            panelContenido.Size = new Size(914, 730);
            panelContenido.TabIndex = 1;

            // 
            // lblEfectivoInicial
            // 
            lblEfectivoInicial.AutoSize = true;
            lblEfectivoInicial.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEfectivoInicial.ForeColor = Color.FromArgb(230, 238, 252);
            lblEfectivoInicial.Location = new Point(30, 35);
            lblEfectivoInicial.Name = "lblEfectivoInicial";
            lblEfectivoInicial.Size = new Size(205, 23);
            lblEfectivoInicial.TabIndex = 0;
            lblEfectivoInicial.Text = "Efectivo Inicial de Caja ($):";

            // 
            // txtEfectivoInicial
            // 
            txtEfectivoInicial.BackColor = Color.FromArgb(15, 42, 79);
            txtEfectivoInicial.BorderStyle = BorderStyle.FixedSingle;
            txtEfectivoInicial.Font = new Font("Segoe UI", 10.5F);
            txtEfectivoInicial.ForeColor = Color.FromArgb(230, 238, 252);
            txtEfectivoInicial.Location = new Point(30, 65);
            txtEfectivoInicial.Name = "txtEfectivoInicial";
            txtEfectivoInicial.Size = new Size(350, 31);
            txtEfectivoInicial.TabIndex = 1;

            // 
            // lblEmailNotificacion
            // 
            lblEmailNotificacion.AutoSize = true;
            lblEmailNotificacion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEmailNotificacion.ForeColor = Color.FromArgb(230, 238, 252);
            lblEmailNotificacion.Location = new Point(30, 125);
            lblEmailNotificacion.Name = "lblEmailNotificacion";
            lblEmailNotificacion.Size = new Size(276, 23);
            lblEmailNotificacion.TabIndex = 2;
            lblEmailNotificacion.Text = "Correo para envío de Notificaciones:";

            // 
            // txtEmailNotificacion
            // 
            txtEmailNotificacion.BackColor = Color.FromArgb(15, 42, 79);
            txtEmailNotificacion.BorderStyle = BorderStyle.FixedSingle;
            txtEmailNotificacion.Font = new Font("Segoe UI", 10.5F);
            txtEmailNotificacion.ForeColor = Color.FromArgb(230, 238, 252);
            txtEmailNotificacion.Location = new Point(30, 155);
            txtEmailNotificacion.Name = "txtEmailNotificacion";
            txtEmailNotificacion.Size = new Size(450, 31);
            txtEmailNotificacion.TabIndex = 3;

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(31, 111, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 220);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 42);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // FrmConfiguracionCorteCaja
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
            Name = "FrmConfiguracionCorteCaja";
            Text = "Configuración Corte de Caja";
            Load += FrmConfiguracionCorteCaja_Load;

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
        private Label lblEfectivoInicial;
        private TextBox txtEfectivoInicial;
        private Label lblEmailNotificacion;
        private TextBox txtEmailNotificacion;
        private Button btnGuardar;
    }
}