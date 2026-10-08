namespace Presentacion.Forms.Corte
{
    partial class FrmCorteModal
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            btnConsultar = new Button();
            dgvMovimientos = new DataGridView();
            lblEfectivoInicialEtiqueta = new Label();
            lblEfectivoInicialValue = new Label();
            lblTotalIngresosEtiqueta = new Label();
            lblTotalIngresosValue = new Label();
            lblTotalEgresosEtiqueta = new Label();
            lblTotalEgresosValue = new Label();
            lblEfectivoFinalEtiqueta = new Label();
            lblEfectivoFinalValue = new Label();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            btnRealizarCorte = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(304, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Corte de Caja / Flujo de Efectivo";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI", 9.5F);
            lblFechaInicio.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaInicio.Location = new Point(29, 87);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(94, 21);
            lblFechaInicio.TabIndex = 1;
            lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.CalendarForeColor = Color.FromArgb(230, 238, 252);
            dtpFechaInicio.CalendarMonthBackground = Color.FromArgb(15, 42, 79);
            dtpFechaInicio.Font = new Font("Segoe UI", 10F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(29, 113);
            dtpFechaInicio.Margin = new Padding(3, 4, 3, 4);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(204, 30);
            dtpFechaInicio.TabIndex = 2;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Font = new Font("Segoe UI", 9.5F);
            lblFechaFin.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaFin.Location = new Point(249, 87);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(78, 21);
            lblFechaFin.TabIndex = 3;
            lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.CalendarForeColor = Color.FromArgb(230, 238, 252);
            dtpFechaFin.CalendarMonthBackground = Color.FromArgb(15, 42, 79);
            dtpFechaFin.Font = new Font("Segoe UI", 10F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(250, 113);
            dtpFechaFin.Margin = new Padding(3, 4, 3, 4);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(195, 30);
            dtpFechaFin.TabIndex = 4;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.FromArgb(31, 111, 235);
            btnConsultar.FlatAppearance.BorderSize = 0;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnConsultar.ForeColor = Color.White;
            btnConsultar.Location = new Point(511, 108);
            btnConsultar.Margin = new Padding(3, 4, 3, 4);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(120, 35);
            btnConsultar.TabIndex = 5;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = Color.FromArgb(15, 42, 79);
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMovimientos.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.GridColor = Color.FromArgb(11, 15, 26);
            dgvMovimientos.Location = new Point(29, 160);
            dgvMovimientos.Margin = new Padding(3, 4, 3, 4);
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.RowHeadersWidth = 51;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(742, 260);
            dgvMovimientos.TabIndex = 6;
            // 
            // lblEfectivoInicialEtiqueta
            // 
            lblEfectivoInicialEtiqueta.AutoSize = true;
            lblEfectivoInicialEtiqueta.Font = new Font("Segoe UI", 9F);
            lblEfectivoInicialEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblEfectivoInicialEtiqueta.Location = new Point(29, 435);
            lblEfectivoInicialEtiqueta.Name = "lblEfectivoInicialEtiqueta";
            lblEfectivoInicialEtiqueta.Size = new Size(108, 20);
            lblEfectivoInicialEtiqueta.TabIndex = 7;
            lblEfectivoInicialEtiqueta.Text = "Efectivo Inicial:";
            // 
            // lblEfectivoInicialValue
            // 
            lblEfectivoInicialValue.AutoSize = true;
            lblEfectivoInicialValue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEfectivoInicialValue.ForeColor = Color.FromArgb(230, 238, 252);
            lblEfectivoInicialValue.Location = new Point(145, 433);
            lblEfectivoInicialValue.Name = "lblEfectivoInicialValue";
            lblEfectivoInicialValue.Size = new Size(50, 23);
            lblEfectivoInicialValue.TabIndex = 8;
            lblEfectivoInicialValue.Text = "$0.00";
            // 
            // lblTotalIngresosEtiqueta
            // 
            lblTotalIngresosEtiqueta.AutoSize = true;
            lblTotalIngresosEtiqueta.Font = new Font("Segoe UI", 9F);
            lblTotalIngresosEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotalIngresosEtiqueta.Location = new Point(250, 435);
            lblTotalIngresosEtiqueta.Name = "lblTotalIngresosEtiqueta";
            lblTotalIngresosEtiqueta.Size = new Size(104, 20);
            lblTotalIngresosEtiqueta.TabIndex = 9;
            lblTotalIngresosEtiqueta.Text = "Total Ingresos:";
            // 
            // lblTotalIngresosValue
            // 
            lblTotalIngresosValue.AutoSize = true;
            lblTotalIngresosValue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTotalIngresosValue.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotalIngresosValue.Location = new Point(358, 433);
            lblTotalIngresosValue.Name = "lblTotalIngresosValue";
            lblTotalIngresosValue.Size = new Size(50, 23);
            lblTotalIngresosValue.TabIndex = 10;
            lblTotalIngresosValue.Text = "$0.00";
            // 
            // lblTotalEgresosEtiqueta
            // 
            lblTotalEgresosEtiqueta.AutoSize = true;
            lblTotalEgresosEtiqueta.Font = new Font("Segoe UI", 9F);
            lblTotalEgresosEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotalEgresosEtiqueta.Location = new Point(455, 435);
            lblTotalEgresosEtiqueta.Name = "lblTotalEgresosEtiqueta";
            lblTotalEgresosEtiqueta.Size = new Size(100, 20);
            lblTotalEgresosEtiqueta.TabIndex = 11;
            lblTotalEgresosEtiqueta.Text = "Total Egresos:";
            // 
            // lblTotalEgresosValue
            // 
            lblTotalEgresosValue.AutoSize = true;
            lblTotalEgresosValue.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTotalEgresosValue.ForeColor = Color.FromArgb(255, 100, 100);
            lblTotalEgresosValue.Location = new Point(559, 433);
            lblTotalEgresosValue.Name = "lblTotalEgresosValue";
            lblTotalEgresosValue.Size = new Size(50, 23);
            lblTotalEgresosValue.TabIndex = 12;
            lblTotalEgresosValue.Text = "$0.00";
            // 
            // lblEfectivoFinalEtiqueta
            // 
            lblEfectivoFinalEtiqueta.AutoSize = true;
            lblEfectivoFinalEtiqueta.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblEfectivoFinalEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblEfectivoFinalEtiqueta.Location = new Point(455, 471);
            lblEfectivoFinalEtiqueta.Name = "lblEfectivoFinalEtiqueta";
            lblEfectivoFinalEtiqueta.Size = new Size(176, 24);
            lblEfectivoFinalEtiqueta.TabIndex = 13;
            lblEfectivoFinalEtiqueta.Text = "TOTAL EN CAJA:";
            // 
            // lblEfectivoFinalValue
            // 
            lblEfectivoFinalValue.AutoSize = true;
            lblEfectivoFinalValue.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblEfectivoFinalValue.ForeColor = Color.FromArgb(45, 212, 255);
            lblEfectivoFinalValue.Location = new Point(637, 469);
            lblEfectivoFinalValue.Name = "lblEfectivoFinalValue";
            lblEfectivoFinalValue.Size = new Size(76, 29);
            lblEfectivoFinalValue.TabIndex = 14;
            lblEfectivoFinalValue.Text = "$0.00";
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 9.5F);
            lblObservaciones.ForeColor = Color.FromArgb(230, 238, 252);
            lblObservaciones.Location = new Point(29, 475);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(115, 21);
            lblObservaciones.TabIndex = 15;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = Color.FromArgb(15, 42, 79);
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.Font = new Font("Segoe UI", 9.5F);
            txtObservaciones.ForeColor = Color.FromArgb(230, 238, 252);
            txtObservaciones.Location = new Point(29, 502);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(480, 50);
            txtObservaciones.TabIndex = 16;
            // 
            // btnRealizarCorte
            // 
            btnRealizarCorte.BackColor = Color.FromArgb(31, 111, 235);
            btnRealizarCorte.FlatAppearance.BorderSize = 0;
            btnRealizarCorte.FlatStyle = FlatStyle.Flat;
            btnRealizarCorte.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnRealizarCorte.ForeColor = Color.White;
            btnRealizarCorte.Location = new Point(500, 570);
            btnRealizarCorte.Margin = new Padding(3, 4, 3, 4);
            btnRealizarCorte.Name = "btnRealizarCorte";
            btnRealizarCorte.Size = new Size(135, 47);
            btnRealizarCorte.TabIndex = 17;
            btnRealizarCorte.Text = "Realizar Corte";
            btnRealizarCorte.UseVisualStyleBackColor = false;
            btnRealizarCorte.Click += btnRealizarCorte_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(15, 42, 79);
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F);
            btnCancelar.ForeColor = Color.FromArgb(230, 238, 252);
            btnCancelar.Location = new Point(646, 570);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(125, 47);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmCorteModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(800, 640);
            Controls.Add(btnCancelar);
            Controls.Add(btnRealizarCorte);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(lblEfectivoFinalValue);
            Controls.Add(lblEfectivoFinalEtiqueta);
            Controls.Add(lblTotalEgresosValue);
            Controls.Add(lblTotalEgresosEtiqueta);
            Controls.Add(lblTotalIngresosValue);
            Controls.Add(lblTotalIngresosEtiqueta);
            Controls.Add(lblEfectivoInicialValue);
            Controls.Add(lblEfectivoInicialEtiqueta);
            Controls.Add(dgvMovimientos);
            Controls.Add(btnConsultar);
            Controls.Add(dtpFechaFin);
            Controls.Add(lblFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(lblFechaInicio);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCorteModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Corte de Caja";
            Load += FrmCorteModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;

        private Label lblFechaInicio;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaFin;
        private Button btnConsultar;

        private DataGridView dgvMovimientos;

        private Label lblEfectivoInicialEtiqueta;
        private Label lblEfectivoInicialValue;
        private Label lblTotalIngresosEtiqueta;
        private Label lblTotalIngresosValue;
        private Label lblTotalEgresosEtiqueta;
        private Label lblTotalEgresosValue;
        private Label lblEfectivoFinalEtiqueta;
        private Label lblEfectivoFinalValue;

        private Label lblObservaciones;
        private TextBox txtObservaciones;

        private Button btnRealizarCorte;
        private Button btnCancelar;
    }
}