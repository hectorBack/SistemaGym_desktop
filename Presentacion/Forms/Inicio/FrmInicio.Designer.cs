namespace Presentacion.Forms.Inicio
{
    partial class FrmInicio
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
            btnInformacion = new BotonTema();
            panelContenido = new Panel();
            dgvVisitantes = new GridTema();
            panelImagen = new Panel();
            picBanner = new PictureBox();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitantes).BeginInit();
            panelImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBanner).BeginInit();
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
            panelTop.Size = new Size(1100, 70);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(211, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Visitantes del día";
            // 
            // flowAcciones
            // 
            flowAcciones.AutoSize = true;
            flowAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAcciones.Controls.Add(btnInformacion);
            flowAcciones.Dock = DockStyle.Right;
            flowAcciones.Location = new Point(948, 0);
            flowAcciones.Name = "flowAcciones";
            flowAcciones.Padding = new Padding(0, 16, 12, 0);
            flowAcciones.Size = new Size(152, 70);
            flowAcciones.TabIndex = 1;
            flowAcciones.WrapContents = false;
            // 
            // btnInformacion
            // 
            btnInformacion.Estilo = EstiloBoton.Exito;
            btnInformacion.Margin = new Padding(0, 0, 8, 0);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.Size = new Size(130, 38);
            btnInformacion.TabIndex = 0;
            btnInformacion.Text = "Información";
            btnInformacion.Click += btnInformacion_Click;
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvVisitantes);
            panelContenido.Controls.Add(panelImagen);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 70);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(15);
            panelContenido.Size = new Size(1100, 730);
            panelContenido.TabIndex = 1;
            // 
            // dgvVisitantes
            // 
            dgvVisitantes.Dock = DockStyle.Fill;
            dgvVisitantes.Location = new Point(15, 15);
            dgvVisitantes.Name = "dgvVisitantes";
            dgvVisitantes.Size = new Size(655, 700);
            dgvVisitantes.TabIndex = 0;
            // 
            // panelImagen
            // 
            panelImagen.Controls.Add(picBanner);
            panelImagen.Dock = DockStyle.Right;
            panelImagen.Location = new Point(685, 15);
            panelImagen.Name = "panelImagen";
            panelImagen.Padding = new Padding(15, 0, 0, 0);
            panelImagen.Size = new Size(400, 700);
            panelImagen.TabIndex = 1;
            // 
            // picBanner
            // 
            picBanner.BackColor = Color.FromArgb(15, 42, 79);
            picBanner.BorderStyle = BorderStyle.FixedSingle;
            picBanner.Dock = DockStyle.Fill;
            picBanner.Location = new Point(15, 0);
            picBanner.Name = "picBanner";
            picBanner.Size = new Size(385, 700);
            picBanner.SizeMode = PictureBoxSizeMode.Zoom;
            picBanner.TabIndex = 0;
            picBanner.TabStop = false;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1100, 800);
            Controls.Add(panelContenido);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInicio";
            Text = "Inicio";
            Load += FrmInicio_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVisitantes).EndInit();
            panelImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBanner).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnInformacion;
        private Panel panelContenido;
        private GridTema dgvVisitantes;
        private Panel panelImagen;
        private PictureBox picBanner;
    }
}