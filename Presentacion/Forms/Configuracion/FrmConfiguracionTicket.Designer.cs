namespace Presentacion.Forms.Configuracion
{
    partial class FrmConfiguracionTicket
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

            chkHabilitarImpresora = new CheckBox();
            lblTextoInferior = new Label();
            txtTextoInferior = new TextBox();

            lblAnchoTicket = new Label();
            nudAnchoTicket = new NumericUpDown();
            lblAnchoImagen = new Label();
            nudAnchoImagen = new NumericUpDown();
            lblFuente = new Label();
            cmbFuente = new ComboBox();
            lblTamanoTexto = new Label();
            nudTamanoTexto = new NumericUpDown();
            lblTamanoRenglon = new Label();
            nudTamanoRenglon = new NumericUpDown();
            lblTamanoEntreSecciones = new Label();
            nudTamanoEntreSecciones = new NumericUpDown();
            lblTamanoTextoEncabezado = new Label();
            nudTamanoTextoEncabezado = new NumericUpDown();
            lblTamanoRenglonEncabezado = new Label();
            nudTamanoRenglonEncabezado = new NumericUpDown();

            btnGuardar = new Button();
            btnGuardarImprimir = new Button();

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
            lblTitulo.Size = new Size(350, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Configuración del Ticket";

            // 
            // panelContenido
            // 
            panelContenido.AutoScroll = true;
            panelContenido.Controls.Add(chkHabilitarImpresora);
            panelContenido.Controls.Add(lblTextoInferior);
            panelContenido.Controls.Add(txtTextoInferior);
            panelContenido.Controls.Add(lblAnchoTicket);
            panelContenido.Controls.Add(nudAnchoTicket);
            panelContenido.Controls.Add(lblAnchoImagen);
            panelContenido.Controls.Add(nudAnchoImagen);
            panelContenido.Controls.Add(lblFuente);
            panelContenido.Controls.Add(cmbFuente);
            panelContenido.Controls.Add(lblTamanoTexto);
            panelContenido.Controls.Add(nudTamanoTexto);
            panelContenido.Controls.Add(lblTamanoRenglon);
            panelContenido.Controls.Add(nudTamanoRenglon);
            panelContenido.Controls.Add(lblTamanoEntreSecciones);
            panelContenido.Controls.Add(nudTamanoEntreSecciones);
            panelContenido.Controls.Add(lblTamanoTextoEncabezado);
            panelContenido.Controls.Add(nudTamanoTextoEncabezado);
            panelContenido.Controls.Add(lblTamanoRenglonEncabezado);
            panelContenido.Controls.Add(nudTamanoRenglonEncabezado);
            panelContenido.Controls.Add(btnGuardar);
            panelContenido.Controls.Add(btnGuardarImprimir);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 70);
            panelContenido.Margin = new Padding(3, 4, 3, 4);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(30);
            panelContenido.Size = new Size(914, 730);
            panelContenido.TabIndex = 1;

            // 
            // chkHabilitarImpresora
            // 
            chkHabilitarImpresora.AutoSize = true;
            chkHabilitarImpresora.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            chkHabilitarImpresora.ForeColor = Color.FromArgb(230, 238, 252);
            chkHabilitarImpresora.Location = new Point(30, 35);
            chkHabilitarImpresora.Name = "chkHabilitarImpresora";
            chkHabilitarImpresora.Size = new Size(170, 27);
            chkHabilitarImpresora.TabIndex = 1;
            chkHabilitarImpresora.Text = "Habilitar impresora";
            chkHabilitarImpresora.UseVisualStyleBackColor = true;

            // 
            // lblTextoInferior
            // 
            lblTextoInferior.AutoSize = true;
            lblTextoInferior.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTextoInferior.ForeColor = Color.FromArgb(230, 238, 252);
            lblTextoInferior.Location = new Point(30, 85);
            lblTextoInferior.Name = "lblTextoInferior";
            lblTextoInferior.TabIndex = 2;
            lblTextoInferior.Text = "Texto inferior:";

            // 
            // txtTextoInferior
            // 
            txtTextoInferior.BackColor = Color.FromArgb(15, 42, 79);
            txtTextoInferior.BorderStyle = BorderStyle.FixedSingle;
            txtTextoInferior.Font = new Font("Segoe UI", 10.5F);
            txtTextoInferior.ForeColor = Color.FromArgb(230, 238, 252);
            txtTextoInferior.Location = new Point(30, 115);
            txtTextoInferior.MaxLength = 300;
            txtTextoInferior.Multiline = true;
            txtTextoInferior.Name = "txtTextoInferior";
            txtTextoInferior.ScrollBars = ScrollBars.Vertical;
            txtTextoInferior.Size = new Size(490, 80);
            txtTextoInferior.TabIndex = 3;

            // 
            // lblAnchoTicket
            // 
            lblAnchoTicket.AutoSize = true;
            lblAnchoTicket.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAnchoTicket.ForeColor = Color.FromArgb(230, 238, 252);
            lblAnchoTicket.Location = new Point(30, 225);
            lblAnchoTicket.Name = "lblAnchoTicket";
            lblAnchoTicket.TabIndex = 3;
            lblAnchoTicket.Text = "Ancho del ticket (mm):";

            // 
            // nudAnchoTicket
            // 
            nudAnchoTicket.BackColor = Color.FromArgb(15, 42, 79);
            nudAnchoTicket.BorderStyle = BorderStyle.FixedSingle;
            nudAnchoTicket.Font = new Font("Segoe UI", 10.5F);
            nudAnchoTicket.ForeColor = Color.FromArgb(230, 238, 252);
            nudAnchoTicket.Location = new Point(30, 255);
            nudAnchoTicket.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudAnchoTicket.Minimum = new decimal(new int[] { 40, 0, 0, 0 });
            nudAnchoTicket.Name = "nudAnchoTicket";
            nudAnchoTicket.Size = new Size(220, 31);
            nudAnchoTicket.TabIndex = 4;
            nudAnchoTicket.Value = new decimal(new int[] { 40, 0, 0, 0 });

            // 
            // lblAnchoImagen
            // 
            lblAnchoImagen.AutoSize = true;
            lblAnchoImagen.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAnchoImagen.ForeColor = Color.FromArgb(230, 238, 252);
            lblAnchoImagen.Location = new Point(300, 225);
            lblAnchoImagen.Name = "lblAnchoImagen";
            lblAnchoImagen.TabIndex = 5;
            lblAnchoImagen.Text = "Ancho de imagen (%):";

            // 
            // nudAnchoImagen
            // 
            nudAnchoImagen.BackColor = Color.FromArgb(15, 42, 79);
            nudAnchoImagen.BorderStyle = BorderStyle.FixedSingle;
            nudAnchoImagen.Font = new Font("Segoe UI", 10.5F);
            nudAnchoImagen.ForeColor = Color.FromArgb(230, 238, 252);
            nudAnchoImagen.Location = new Point(300, 255);
            nudAnchoImagen.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            nudAnchoImagen.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudAnchoImagen.Name = "nudAnchoImagen";
            nudAnchoImagen.Size = new Size(220, 31);
            nudAnchoImagen.TabIndex = 6;
            nudAnchoImagen.Value = new decimal(new int[] { 10, 0, 0, 0 });

            // 
            // lblFuente
            // 
            lblFuente.AutoSize = true;
            lblFuente.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFuente.ForeColor = Color.FromArgb(230, 238, 252);
            lblFuente.Location = new Point(30, 305);
            lblFuente.Name = "lblFuente";
            lblFuente.TabIndex = 7;
            lblFuente.Text = "Nombre de fuente:";

            // 
            // cmbFuente
            // 
            cmbFuente.BackColor = Color.FromArgb(15, 42, 79);
            cmbFuente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuente.FlatStyle = FlatStyle.Flat;
            cmbFuente.Font = new Font("Segoe UI", 10.5F);
            cmbFuente.ForeColor = Color.FromArgb(230, 238, 252);
            cmbFuente.Location = new Point(30, 335);
            cmbFuente.Name = "cmbFuente";
            cmbFuente.Size = new Size(220, 31);
            cmbFuente.TabIndex = 8;

            // 
            // lblTamanoTexto
            // 
            lblTamanoTexto.AutoSize = true;
            lblTamanoTexto.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTamanoTexto.ForeColor = Color.FromArgb(230, 238, 252);
            lblTamanoTexto.Location = new Point(300, 305);
            lblTamanoTexto.Name = "lblTamanoTexto";
            lblTamanoTexto.TabIndex = 9;
            lblTamanoTexto.Text = "Tamaño del texto:";

            // 
            // nudTamanoTexto
            // 
            nudTamanoTexto.BackColor = Color.FromArgb(15, 42, 79);
            nudTamanoTexto.BorderStyle = BorderStyle.FixedSingle;
            nudTamanoTexto.Font = new Font("Segoe UI", 10.5F);
            nudTamanoTexto.ForeColor = Color.FromArgb(230, 238, 252);
            nudTamanoTexto.Location = new Point(300, 335);
            nudTamanoTexto.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudTamanoTexto.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            nudTamanoTexto.Name = "nudTamanoTexto";
            nudTamanoTexto.Size = new Size(220, 31);
            nudTamanoTexto.TabIndex = 10;
            nudTamanoTexto.Value = new decimal(new int[] { 6, 0, 0, 0 });

            // 
            // lblTamanoRenglon
            // 
            lblTamanoRenglon.AutoSize = true;
            lblTamanoRenglon.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTamanoRenglon.ForeColor = Color.FromArgb(230, 238, 252);
            lblTamanoRenglon.Location = new Point(30, 385);
            lblTamanoRenglon.Name = "lblTamanoRenglon";
            lblTamanoRenglon.TabIndex = 11;
            lblTamanoRenglon.Text = "Tamaño del renglón:";

            // 
            // nudTamanoRenglon
            // 
            nudTamanoRenglon.BackColor = Color.FromArgb(15, 42, 79);
            nudTamanoRenglon.BorderStyle = BorderStyle.FixedSingle;
            nudTamanoRenglon.Font = new Font("Segoe UI", 10.5F);
            nudTamanoRenglon.ForeColor = Color.FromArgb(230, 238, 252);
            nudTamanoRenglon.Location = new Point(30, 415);
            nudTamanoRenglon.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            nudTamanoRenglon.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            nudTamanoRenglon.Name = "nudTamanoRenglon";
            nudTamanoRenglon.Size = new Size(220, 31);
            nudTamanoRenglon.TabIndex = 12;
            nudTamanoRenglon.Value = new decimal(new int[] { 6, 0, 0, 0 });

            // 
            // lblTamanoEntreSecciones
            // 
            lblTamanoEntreSecciones.AutoSize = true;
            lblTamanoEntreSecciones.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTamanoEntreSecciones.ForeColor = Color.FromArgb(230, 238, 252);
            lblTamanoEntreSecciones.Location = new Point(300, 385);
            lblTamanoEntreSecciones.Name = "lblTamanoEntreSecciones";
            lblTamanoEntreSecciones.TabIndex = 13;
            lblTamanoEntreSecciones.Text = "Tamaño entre secciones:";

            // 
            // nudTamanoEntreSecciones
            // 
            nudTamanoEntreSecciones.BackColor = Color.FromArgb(15, 42, 79);
            nudTamanoEntreSecciones.BorderStyle = BorderStyle.FixedSingle;
            nudTamanoEntreSecciones.Font = new Font("Segoe UI", 10.5F);
            nudTamanoEntreSecciones.ForeColor = Color.FromArgb(230, 238, 252);
            nudTamanoEntreSecciones.Location = new Point(300, 415);
            nudTamanoEntreSecciones.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            nudTamanoEntreSecciones.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nudTamanoEntreSecciones.Name = "nudTamanoEntreSecciones";
            nudTamanoEntreSecciones.Size = new Size(220, 31);
            nudTamanoEntreSecciones.TabIndex = 14;
            nudTamanoEntreSecciones.Value = new decimal(new int[] { 0, 0, 0, 0 });

            // 
            // lblTamanoTextoEncabezado
            // 
            lblTamanoTextoEncabezado.AutoSize = true;
            lblTamanoTextoEncabezado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTamanoTextoEncabezado.ForeColor = Color.FromArgb(230, 238, 252);
            lblTamanoTextoEncabezado.Location = new Point(30, 465);
            lblTamanoTextoEncabezado.Name = "lblTamanoTextoEncabezado";
            lblTamanoTextoEncabezado.TabIndex = 15;
            lblTamanoTextoEncabezado.Text = "Tamaño texto encabezado:";

            // 
            // nudTamanoTextoEncabezado
            // 
            nudTamanoTextoEncabezado.BackColor = Color.FromArgb(15, 42, 79);
            nudTamanoTextoEncabezado.BorderStyle = BorderStyle.FixedSingle;
            nudTamanoTextoEncabezado.Font = new Font("Segoe UI", 10.5F);
            nudTamanoTextoEncabezado.ForeColor = Color.FromArgb(230, 238, 252);
            nudTamanoTextoEncabezado.Location = new Point(30, 495);
            nudTamanoTextoEncabezado.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            nudTamanoTextoEncabezado.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            nudTamanoTextoEncabezado.Name = "nudTamanoTextoEncabezado";
            nudTamanoTextoEncabezado.Size = new Size(220, 31);
            nudTamanoTextoEncabezado.TabIndex = 16;
            nudTamanoTextoEncabezado.Value = new decimal(new int[] { 6, 0, 0, 0 });

            // 
            // lblTamanoRenglonEncabezado
            // 
            lblTamanoRenglonEncabezado.AutoSize = true;
            lblTamanoRenglonEncabezado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTamanoRenglonEncabezado.ForeColor = Color.FromArgb(230, 238, 252);
            lblTamanoRenglonEncabezado.Location = new Point(300, 465);
            lblTamanoRenglonEncabezado.Name = "lblTamanoRenglonEncabezado";
            lblTamanoRenglonEncabezado.TabIndex = 17;
            lblTamanoRenglonEncabezado.Text = "Tamaño renglón encabezado:";

            // 
            // nudTamanoRenglonEncabezado
            // 
            nudTamanoRenglonEncabezado.BackColor = Color.FromArgb(15, 42, 79);
            nudTamanoRenglonEncabezado.BorderStyle = BorderStyle.FixedSingle;
            nudTamanoRenglonEncabezado.Font = new Font("Segoe UI", 10.5F);
            nudTamanoRenglonEncabezado.ForeColor = Color.FromArgb(230, 238, 252);
            nudTamanoRenglonEncabezado.Location = new Point(300, 495);
            nudTamanoRenglonEncabezado.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudTamanoRenglonEncabezado.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            nudTamanoRenglonEncabezado.Name = "nudTamanoRenglonEncabezado";
            nudTamanoRenglonEncabezado.Size = new Size(220, 31);
            nudTamanoRenglonEncabezado.TabIndex = 18;
            nudTamanoRenglonEncabezado.Value = new decimal(new int[] { 6, 0, 0, 0 });

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(31, 111, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 560);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 42);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // btnGuardarImprimir
            // 
            btnGuardarImprimir.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardarImprimir.FlatAppearance.BorderSize = 0;
            btnGuardarImprimir.FlatStyle = FlatStyle.Flat;
            btnGuardarImprimir.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnGuardarImprimir.ForeColor = Color.White;
            btnGuardarImprimir.Location = new Point(230, 560);
            btnGuardarImprimir.Margin = new Padding(3, 4, 3, 4);
            btnGuardarImprimir.Name = "btnGuardarImprimir";
            btnGuardarImprimir.Size = new Size(200, 42);
            btnGuardarImprimir.TabIndex = 20;
            btnGuardarImprimir.Text = "Guardar e imprimir";
            btnGuardarImprimir.UseVisualStyleBackColor = false;
            btnGuardarImprimir.Click += btnGuardarImprimir_Click;

            // 
            // FrmConfiguracionTicket
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
            Name = "FrmConfiguracionTicket";
            Text = "Configuración del Ticket";
            Load += FrmConfiguracionTicket_Load;

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
        private CheckBox chkHabilitarImpresora;
        private Label lblTextoInferior;
        private TextBox txtTextoInferior;
        private Label lblAnchoTicket;
        private NumericUpDown nudAnchoTicket;
        private Label lblAnchoImagen;
        private NumericUpDown nudAnchoImagen;
        private Label lblFuente;
        private ComboBox cmbFuente;
        private Label lblTamanoTexto;
        private NumericUpDown nudTamanoTexto;
        private Label lblTamanoRenglon;
        private NumericUpDown nudTamanoRenglon;
        private Label lblTamanoEntreSecciones;
        private NumericUpDown nudTamanoEntreSecciones;
        private Label lblTamanoTextoEncabezado;
        private NumericUpDown nudTamanoTextoEncabezado;
        private Label lblTamanoRenglonEncabezado;
        private NumericUpDown nudTamanoRenglonEncabezado;
        private Button btnGuardar;
        private Button btnGuardarImprimir;
    }
}