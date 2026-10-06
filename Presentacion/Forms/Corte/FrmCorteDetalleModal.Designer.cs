namespace Presentacion.Forms.Corte
{
    partial class FrmCorteDetalleModal
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
            panelHeader = new Panel();
            lblTitulo = new Label();

            // Metadatos
            lblUsuarioEtiqueta = new Label();
            lblUsuarioValor = new Label();
            lblEstadoEtiqueta = new Label();
            lblEstadoValor = new Label();
            lblFechaInicioEtiqueta = new Label();
            lblFechaInicioValor = new Label();
            lblFechaFinEtiqueta = new Label();
            lblFechaFinValor = new Label();
            lblObservacionEtiqueta = new Label();
            lblObservacionValor = new Label();

            // Totales
            lblEfectivoInicialEtiqueta = new Label();
            lblEfectivoInicialValor = new Label();
            lblTotalIngresosEtiqueta = new Label();
            lblTotalIngresosValor = new Label();
            lblTotalEgresosEtiqueta = new Label();
            lblTotalEgresosValor = new Label();
            lblEfectivoFinalEtiqueta = new Label();
            lblEfectivoFinalValor = new Label();

            // Grid y Botón
            dgvMovimientos = new DataGridView();
            btnCerrar = new Button();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(680, 50);
            panelHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle del Corte de Caja";

            // 
            // lblUsuarioEtiqueta
            // 
            lblUsuarioEtiqueta.AutoSize = true;
            lblUsuarioEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuarioEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblUsuarioEtiqueta.Location = new Point(25, 65);
            lblUsuarioEtiqueta.Name = "lblUsuarioEtiqueta";
            lblUsuarioEtiqueta.Size = new Size(60, 17);
            lblUsuarioEtiqueta.TabIndex = 1;
            lblUsuarioEtiqueta.Text = "Usuario:";

            // 
            // lblUsuarioValor
            // 
            lblUsuarioValor.AutoSize = true;
            lblUsuarioValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuarioValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblUsuarioValor.Location = new Point(90, 65);
            lblUsuarioValor.Name = "lblUsuarioValor";
            lblUsuarioValor.Size = new Size(31, 17);
            lblUsuarioValor.TabIndex = 2;
            lblUsuarioValor.Text = "N/A";

            // 
            // lblEstadoEtiqueta
            // 
            lblEstadoEtiqueta.AutoSize = true;
            lblEstadoEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblEstadoEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblEstadoEtiqueta.Location = new Point(360, 65);
            lblEstadoEtiqueta.Name = "lblEstadoEtiqueta";
            lblEstadoEtiqueta.Size = new Size(53, 17);
            lblEstadoEtiqueta.TabIndex = 3;
            lblEstadoEtiqueta.Text = "Estado:";

            // 
            // lblEstadoValor
            // 
            lblEstadoValor.AutoSize = true;
            lblEstadoValor.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblEstadoValor.ForeColor = Color.ForestGreen;
            lblEstadoValor.Location = new Point(420, 65);
            lblEstadoValor.Name = "lblEstadoValor";
            lblEstadoValor.Size = new Size(58, 17);
            lblEstadoValor.TabIndex = 4;
            lblEstadoValor.Text = "Cerrado";

            // 
            // lblFechaInicioEtiqueta
            // 
            lblFechaInicioEtiqueta.AutoSize = true;
            lblFechaInicioEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblFechaInicioEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblFechaInicioEtiqueta.Location = new Point(25, 95);
            lblFechaInicioEtiqueta.Name = "lblFechaInicioEtiqueta";
            lblFechaInicioEtiqueta.Size = new Size(83, 17);
            lblFechaInicioEtiqueta.TabIndex = 5;
            lblFechaInicioEtiqueta.Text = "Fecha Inicio:";

            // 
            // lblFechaInicioValor
            // 
            lblFechaInicioValor.AutoSize = true;
            lblFechaInicioValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaInicioValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFechaInicioValor.Location = new Point(112, 95);
            lblFechaInicioValor.Name = "lblFechaInicioValor";
            lblFechaInicioValor.Size = new Size(110, 17);
            lblFechaInicioValor.TabIndex = 6;
            lblFechaInicioValor.Text = "--/--/---- --:--";

            // 
            // lblFechaFinEtiqueta
            // 
            lblFechaFinEtiqueta.AutoSize = true;
            lblFechaFinEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblFechaFinEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblFechaFinEtiqueta.Location = new Point(360, 95);
            lblFechaFinEtiqueta.Name = "lblFechaFinEtiqueta";
            lblFechaFinEtiqueta.Size = new Size(68, 17);
            lblFechaFinEtiqueta.TabIndex = 7;
            lblFechaFinEtiqueta.Text = "Fecha Fin:";

            // 
            // lblFechaFinValor
            // 
            lblFechaFinValor.AutoSize = true;
            lblFechaFinValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaFinValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFechaFinValor.Location = new Point(432, 95);
            lblFechaFinValor.Name = "lblFechaFinValor";
            lblFechaFinValor.Size = new Size(110, 17);
            lblFechaFinValor.TabIndex = 8;
            lblFechaFinValor.Text = "--/--/---- --:--";

            // 
            // lblObservacionEtiqueta
            // 
            lblObservacionEtiqueta.AutoSize = true;
            lblObservacionEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblObservacionEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblObservacionEtiqueta.Location = new Point(25, 125);
            lblObservacionEtiqueta.Name = "lblObservacionEtiqueta";
            lblObservacionEtiqueta.Size = new Size(99, 17);
            lblObservacionEtiqueta.TabIndex = 9;
            lblObservacionEtiqueta.Text = "Observación:";

            // 
            // lblObservacionValor
            // 
            lblObservacionValor.AutoSize = true;
            lblObservacionValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblObservacionValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblObservacionValor.Location = new Point(130, 125);
            lblObservacionValor.Name = "lblObservacionValor";
            lblObservacionValor.Size = new Size(114, 17);
            lblObservacionValor.TabIndex = 10;
            lblObservacionValor.Text = "Sin observaciones";

            // 
            // lblEfectivoInicialEtiqueta
            // 
            lblEfectivoInicialEtiqueta.AutoSize = true;
            lblEfectivoInicialEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblEfectivoInicialEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblEfectivoInicialEtiqueta.Location = new Point(25, 160);
            lblEfectivoInicialEtiqueta.Name = "lblEfectivoInicialEtiqueta";
            lblEfectivoInicialEtiqueta.Size = new Size(100, 17);
            lblEfectivoInicialEtiqueta.TabIndex = 11;
            lblEfectivoInicialEtiqueta.Text = "Efectivo Inicial:";

            // 
            // lblEfectivoInicialValor
            // 
            lblEfectivoInicialValor.AutoSize = true;
            lblEfectivoInicialValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblEfectivoInicialValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblEfectivoInicialValor.Location = new Point(130, 160);
            lblEfectivoInicialValor.Name = "lblEfectivoInicialValor";
            lblEfectivoInicialValor.Size = new Size(41, 17);
            lblEfectivoInicialValor.TabIndex = 12;
            lblEfectivoInicialValor.Text = "$0.00";

            // 
            // lblTotalIngresosEtiqueta
            // 
            lblTotalIngresosEtiqueta.AutoSize = true;
            lblTotalIngresosEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalIngresosEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTotalIngresosEtiqueta.Location = new Point(25, 188);
            lblTotalIngresosEtiqueta.Name = "lblTotalIngresosEtiqueta";
            lblTotalIngresosEtiqueta.Size = new Size(100, 17);
            lblTotalIngresosEtiqueta.TabIndex = 13;
            lblTotalIngresosEtiqueta.Text = "Total Ingresos:";

            // 
            // lblTotalIngresosValor
            // 
            lblTotalIngresosValor.AutoSize = true;
            lblTotalIngresosValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalIngresosValor.ForeColor = Color.LimeGreen;
            lblTotalIngresosValor.Location = new Point(130, 188);
            lblTotalIngresosValor.Name = "lblTotalIngresosValor";
            lblTotalIngresosValor.Size = new Size(41, 17);
            lblTotalIngresosValor.TabIndex = 14;
            lblTotalIngresosValor.Text = "$0.00";

            // 
            // lblTotalEgresosEtiqueta
            // 
            lblTotalEgresosEtiqueta.AutoSize = true;
            lblTotalEgresosEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalEgresosEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTotalEgresosEtiqueta.Location = new Point(360, 188);
            lblTotalEgresosEtiqueta.Name = "lblTotalEgresosEtiqueta";
            lblTotalEgresosEtiqueta.Size = new Size(95, 17);
            lblTotalEgresosEtiqueta.TabIndex = 15;
            lblTotalEgresosEtiqueta.Text = "Total Egresos:";

            // 
            // lblTotalEgresosValor
            // 
            lblTotalEgresosValor.AutoSize = true;
            lblTotalEgresosValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalEgresosValor.ForeColor = Color.IndianRed;
            lblTotalEgresosValor.Location = new Point(460, 188);
            lblTotalEgresosValor.Name = "lblTotalEgresosValor";
            lblTotalEgresosValor.Size = new Size(41, 17);
            lblTotalEgresosValor.TabIndex = 16;
            lblTotalEgresosValor.Text = "$0.00";

            // 
            // lblEfectivoFinalEtiqueta
            // 
            lblEfectivoFinalEtiqueta.AutoSize = true;
            lblEfectivoFinalEtiqueta.Font = new Font("Segoe UI Bold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblEfectivoFinalEtiqueta.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblEfectivoFinalEtiqueta.Location = new Point(360, 157);
            lblEfectivoFinalEtiqueta.Name = "lblEfectivoFinalEtiqueta";
            lblEfectivoFinalEtiqueta.Size = new Size(106, 20);
            lblEfectivoFinalEtiqueta.TabIndex = 17;
            lblEfectivoFinalEtiqueta.Text = "Efectivo Final:";

            // 
            // lblEfectivoFinalValor
            // 
            lblEfectivoFinalValor.AutoSize = true;
            lblEfectivoFinalValor.Font = new Font("Segoe UI Bold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblEfectivoFinalValor.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblEfectivoFinalValor.Location = new Point(472, 154);
            lblEfectivoFinalValor.Name = "lblEfectivoFinalValor";
            lblEfectivoFinalValor.Size = new Size(57, 25);
            lblEfectivoFinalValor.TabIndex = 18;
            lblEfectivoFinalValor.Text = "$0.00";

            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvMovimientos.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvMovimientos.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvMovimientos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvMovimientos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMovimientos.GridColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvMovimientos.Location = new Point(25, 225);
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(630, 250);
            dgvMovimientos.TabIndex = 19;

            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Location = new Point(555, 490);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 32);
            btnCerrar.TabIndex = 20;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            // 
            // FrmCorteDetalleModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(680, 540);
            Controls.Add(btnCerrar);
            Controls.Add(dgvMovimientos);
            Controls.Add(lblEfectivoFinalValor);
            Controls.Add(lblEfectivoFinalEtiqueta);
            Controls.Add(lblTotalEgresosValor);
            Controls.Add(lblTotalEgresosEtiqueta);
            Controls.Add(lblTotalIngresosValor);
            Controls.Add(lblTotalIngresosEtiqueta);
            Controls.Add(lblEfectivoInicialValor);
            Controls.Add(lblEfectivoInicialEtiqueta);
            Controls.Add(lblObservacionValor);
            Controls.Add(lblObservacionEtiqueta);
            Controls.Add(lblFechaFinValor);
            Controls.Add(lblFechaFinEtiqueta);
            Controls.Add(lblFechaInicioValor);
            Controls.Add(lblFechaInicioEtiqueta);
            Controls.Add(lblEstadoValor);
            Controls.Add(lblEstadoEtiqueta);
            Controls.Add(lblUsuarioValor);
            Controls.Add(lblUsuarioEtiqueta);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCorteDetalleModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle del Corte";
            Load += FrmCorteDetalleModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblUsuarioEtiqueta;
        private Label lblUsuarioValor;
        private Label lblEstadoEtiqueta;
        private Label lblEstadoValor;
        private Label lblFechaInicioEtiqueta;
        private Label lblFechaInicioValor;
        private Label lblFechaFinEtiqueta;
        private Label lblFechaFinValor;
        private Label lblObservacionEtiqueta;
        private Label lblObservacionValor;
        private Label lblEfectivoInicialEtiqueta;
        private Label lblEfectivoInicialValor;
        private Label lblTotalIngresosEtiqueta;
        private Label lblTotalIngresosValor;
        private Label lblTotalEgresosEtiqueta;
        private Label lblTotalEgresosValor;
        private Label lblEfectivoFinalEtiqueta;
        private Label lblEfectivoFinalValor;
        private DataGridView dgvMovimientos;
        private Button btnCerrar;
    }
}