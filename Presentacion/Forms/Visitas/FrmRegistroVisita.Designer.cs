namespace Presentacion.Forms
{
    partial class FrmRegistroVisita
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTitulo = new Label();
            lblClavePrompt = new Label();
            txtClave = new TextBox();
            btnRegistrar = new Button();
            panelCentral = new Panel();
            picFoto = new PictureBox();
            lblLabelSocio = new Label();
            lblNombreSocio = new Label();
            lblLabelMembresia = new Label();
            lblMembresia = new Label();
            lblLabelVencimiento = new Label();
            lblVencimiento = new Label();
            lblDeuda = new Label();
            lblEstadoAcceso = new Label();
            btnInformacion = new Button();
            btnCancelarVisita = new Button();
            panelBottom = new Panel();
            lblTituloAsistencia = new Label();
            dgvAsistenciasSemana = new DataGridView();
            btnMembresias = new Button();
            panelTop.SuspendLayout();
            panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAsistenciasSemana).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblClavePrompt);
            panelTop.Controls.Add(txtClave);
            panelTop.Controls.Add(btnRegistrar);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 110);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(326, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Control de Acceso / Visitas";
            // 
            // lblClavePrompt
            // 
            lblClavePrompt.AutoSize = true;
            lblClavePrompt.Font = new Font("Segoe UI", 9.5F);
            lblClavePrompt.ForeColor = Color.FromArgb(230, 238, 252);
            lblClavePrompt.Location = new Point(20, 65);
            lblClavePrompt.Name = "lblClavePrompt";
            lblClavePrompt.Size = new Size(115, 21);
            lblClavePrompt.TabIndex = 1;
            lblClavePrompt.Text = "Clave / Código:";
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.FromArgb(11, 15, 26);
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 10F);
            txtClave.ForeColor = Color.FromArgb(230, 238, 252);
            txtClave.Location = new Point(135, 61);
            txtClave.Margin = new Padding(3, 4, 3, 4);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(250, 30);
            txtClave.TabIndex = 2;
            txtClave.KeyDown += txtClave_KeyDown;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegistrar.BackColor = Color.FromArgb(31, 111, 235);
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(750, 56);
            btnRegistrar.Margin = new Padding(3, 4, 3, 4);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(130, 38);
            btnRegistrar.TabIndex = 3;
            btnRegistrar.Text = "Ingresar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // panelCentral
            // 
            panelCentral.BackColor = Color.FromArgb(11, 15, 26);
            panelCentral.Controls.Add(btnMembresias);
            panelCentral.Controls.Add(picFoto);
            panelCentral.Controls.Add(lblLabelSocio);
            panelCentral.Controls.Add(lblNombreSocio);
            panelCentral.Controls.Add(lblLabelMembresia);
            panelCentral.Controls.Add(lblMembresia);
            panelCentral.Controls.Add(lblLabelVencimiento);
            panelCentral.Controls.Add(lblVencimiento);
            panelCentral.Controls.Add(lblDeuda);
            panelCentral.Controls.Add(lblEstadoAcceso);
            panelCentral.Controls.Add(btnInformacion);
            panelCentral.Controls.Add(btnCancelarVisita);
            panelCentral.Dock = DockStyle.Top;
            panelCentral.Location = new Point(0, 110);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(914, 450);
            panelCentral.TabIndex = 1;
            // 
            // picFoto
            // 
            picFoto.BorderStyle = BorderStyle.FixedSingle;
            picFoto.Location = new Point(25, 25);
            picFoto.Name = "picFoto";
            picFoto.Size = new Size(280, 350);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            picFoto.TabIndex = 0;
            picFoto.TabStop = false;
            // 
            // lblLabelSocio
            // 
            lblLabelSocio.AutoSize = true;
            lblLabelSocio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLabelSocio.ForeColor = Color.FromArgb(45, 212, 255);
            lblLabelSocio.Location = new Point(330, 25);
            lblLabelSocio.Name = "lblLabelSocio";
            lblLabelSocio.Size = new Size(67, 23);
            lblLabelSocio.TabIndex = 1;
            lblLabelSocio.Text = "SOCIO:";
            // 
            // lblNombreSocio
            // 
            lblNombreSocio.AutoSize = true;
            lblNombreSocio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNombreSocio.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombreSocio.Location = new Point(330, 55);
            lblNombreSocio.Name = "lblNombreSocio";
            lblNombreSocio.Size = new Size(380, 37);
            lblNombreSocio.TabIndex = 2;
            lblNombreSocio.Text = "--- ESPERANDO LECTURA ---";
            // 
            // lblLabelMembresia
            // 
            lblLabelMembresia.AutoSize = true;
            lblLabelMembresia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLabelMembresia.ForeColor = Color.FromArgb(45, 212, 255);
            lblLabelMembresia.Location = new Point(330, 120);
            lblLabelMembresia.Name = "lblLabelMembresia";
            lblLabelMembresia.Size = new Size(114, 23);
            lblLabelMembresia.TabIndex = 3;
            lblLabelMembresia.Text = "MEMBRESÍA:";
            // 
            // lblMembresia
            // 
            lblMembresia.AutoSize = true;
            lblMembresia.Font = new Font("Segoe UI", 13F);
            lblMembresia.ForeColor = Color.FromArgb(230, 238, 252);
            lblMembresia.Location = new Point(330, 148);
            lblMembresia.Name = "lblMembresia";
            lblMembresia.Size = new Size(52, 30);
            lblMembresia.TabIndex = 4;
            lblMembresia.Text = "N/A";
            // 
            // lblLabelVencimiento
            // 
            lblLabelVencimiento.AutoSize = true;
            lblLabelVencimiento.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLabelVencimiento.ForeColor = Color.FromArgb(45, 212, 255);
            lblLabelVencimiento.Location = new Point(330, 185);
            lblLabelVencimiento.Name = "lblLabelVencimiento";
            lblLabelVencimiento.Size = new Size(129, 23);
            lblLabelVencimiento.TabIndex = 5;
            lblLabelVencimiento.Text = "VENCIMIENTO:";
            // 
            // lblVencimiento
            // 
            lblVencimiento.AutoSize = true;
            lblVencimiento.Font = new Font("Segoe UI", 13F);
            lblVencimiento.ForeColor = Color.FromArgb(230, 238, 252);
            lblVencimiento.Location = new Point(330, 210);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(52, 30);
            lblVencimiento.TabIndex = 6;
            lblVencimiento.Text = "N/A";
            // 
            // lblDeuda
            // 
            lblDeuda.AutoSize = true;
            lblDeuda.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            lblDeuda.ForeColor = Color.FromArgb(230, 238, 252);
            lblDeuda.Location = new Point(330, 255);
            lblDeuda.Name = "lblDeuda";
            lblDeuda.Size = new Size(154, 26);
            lblDeuda.TabIndex = 10;
            lblDeuda.Text = "Deuda: $0.00";
            // 
            // lblEstadoAcceso
            // 
            lblEstadoAcceso.AutoSize = true;
            lblEstadoAcceso.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            lblEstadoAcceso.ForeColor = Color.FromArgb(31, 111, 235);
            lblEstadoAcceso.Location = new Point(330, 300);
            lblEstadoAcceso.Name = "lblEstadoAcceso";
            lblEstadoAcceso.Size = new Size(280, 36);
            lblEstadoAcceso.TabIndex = 11;
            lblEstadoAcceso.Text = "ESCANEE CLAVE";
            // 
            // btnInformacion
            // 
            btnInformacion.BackColor = Color.FromArgb(15, 42, 79);
            btnInformacion.FlatAppearance.BorderColor = Color.FromArgb(45, 212, 255);
            btnInformacion.FlatStyle = FlatStyle.Flat;
            btnInformacion.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnInformacion.ForeColor = Color.FromArgb(45, 212, 255);
            btnInformacion.Location = new Point(330, 360);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.Size = new Size(160, 40);
            btnInformacion.TabIndex = 8;
            btnInformacion.Text = "ℹ️ Más Información";
            btnInformacion.UseVisualStyleBackColor = false;
            btnInformacion.Click += btnInformacion_Click;
            // 
            // btnCancelarVisita
            // 
            btnCancelarVisita.BackColor = Color.FromArgb(58, 21, 25);
            btnCancelarVisita.FlatAppearance.BorderColor = Color.FromArgb(248, 81, 73);
            btnCancelarVisita.FlatStyle = FlatStyle.Flat;
            btnCancelarVisita.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelarVisita.ForeColor = Color.FromArgb(248, 81, 73);
            btnCancelarVisita.Location = new Point(505, 360);
            btnCancelarVisita.Name = "btnCancelarVisita";
            btnCancelarVisita.Size = new Size(160, 40);
            btnCancelarVisita.TabIndex = 9;
            btnCancelarVisita.Text = "🚫 Cancelar Entrada";
            btnCancelarVisita.UseVisualStyleBackColor = false;
            btnCancelarVisita.Click += btnCancelarVisita_Click;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(11, 15, 26);
            panelBottom.Controls.Add(lblTituloAsistencia);
            panelBottom.Controls.Add(dgvAsistenciasSemana);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(0, 560);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(20, 10, 20, 20);
            panelBottom.Size = new Size(914, 240);
            panelBottom.TabIndex = 2;
            // 
            // lblTituloAsistencia
            // 
            lblTituloAsistencia.AutoSize = true;
            lblTituloAsistencia.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblTituloAsistencia.ForeColor = Color.FromArgb(45, 212, 255);
            lblTituloAsistencia.Location = new Point(20, 10);
            lblTituloAsistencia.Name = "lblTituloAsistencia";
            lblTituloAsistencia.Size = new Size(309, 24);
            lblTituloAsistencia.TabIndex = 0;
            lblTituloAsistencia.Text = "ASISTENCIA SEMANA ACTUAL";
            // 
            // dgvAsistenciasSemana
            // 
            dgvAsistenciasSemana.AllowUserToAddRows = false;
            dgvAsistenciasSemana.AllowUserToDeleteRows = false;
            dgvAsistenciasSemana.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAsistenciasSemana.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvAsistenciasSemana.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvAsistenciasSemana.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvAsistenciasSemana.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle4.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAsistenciasSemana.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAsistenciasSemana.EnableHeadersVisualStyles = false;
            dgvAsistenciasSemana.GridColor = Color.FromArgb(15, 42, 79);
            dgvAsistenciasSemana.Location = new Point(20, 45);
            dgvAsistenciasSemana.Name = "dgvAsistenciasSemana";
            dgvAsistenciasSemana.ReadOnly = true;
            dgvAsistenciasSemana.RowHeadersVisible = false;
            dgvAsistenciasSemana.RowHeadersWidth = 51;
            dgvAsistenciasSemana.ScrollBars = ScrollBars.None;
            dgvAsistenciasSemana.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvAsistenciasSemana.Size = new Size(874, 160);
            dgvAsistenciasSemana.TabIndex = 1;
            // 
            // btnMembresias
            // 
            btnMembresias.BackColor = Color.FromArgb(15, 42, 79);
            btnMembresias.FlatAppearance.BorderColor = Color.FromArgb(45, 212, 255);
            btnMembresias.FlatStyle = FlatStyle.Flat;
            btnMembresias.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnMembresias.ForeColor = Color.FromArgb(45, 212, 255);
            btnMembresias.Location = new Point(680, 360);
            btnMembresias.Name = "btnMembresias";
            btnMembresias.Size = new Size(160, 40);
            btnMembresias.TabIndex = 12;
            btnMembresias.Text = "Membresias";
            btnMembresias.UseVisualStyleBackColor = false;
            btnMembresias.Click += btnMembresias_Click;
            // 
            // FrmRegistroVisita
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(panelBottom);
            Controls.Add(panelCentral);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRegistroVisita";
            Text = "Registro de Visita";
            Load += FrmRegistroVisita_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAsistenciasSemana).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblClavePrompt;
        private TextBox txtClave;
        private Button btnRegistrar;

        private Panel panelCentral;
        private PictureBox picFoto;
        private Label lblLabelSocio;
        private Label lblNombreSocio;
        private Label lblLabelMembresia;
        private Label lblMembresia;
        private Label lblLabelVencimiento;
        private Label lblVencimiento;
        private Label lblDeuda;
        private Label lblEstadoAcceso;
        private Button btnInformacion;
        private Button btnCancelarVisita;

        private Panel panelBottom;
        private Label lblTituloAsistencia;
        private DataGridView dgvAsistenciasSemana;
        private Button btnMembresias;
    }
}