namespace Presentacion.Forms.Compras
{
    partial class FrmCompras
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
            panelTop = new Panel();
            btnLimpiarFiltros = new Button();
            btnFiltrarFechas = new Button();
            btnVerDetalle = new Button();
            lblTitulo = new Label();
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnNuevo = new Button();
            btnDesactivar = new Button();
            btnEliminarFisico = new Button();
            dgvCompras = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(btnLimpiarFiltros);
            panelTop.Controls.Add(btnFiltrarFechas);
            panelTop.Controls.Add(btnVerDetalle);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblDesde);
            panelTop.Controls.Add(dtpFechaInicio);
            panelTop.Controls.Add(lblHasta);
            panelTop.Controls.Add(dtpFechaFin);
            panelTop.Controls.Add(btnNuevo);
            panelTop.Controls.Add(btnDesactivar);
            panelTop.Controls.Add(btnEliminarFisico);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1179, 110);
            panelTop.TabIndex = 0;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Anchor = AnchorStyles.Left;
            btnLimpiarFiltros.BackColor = Color.FromArgb(11, 15, 26);
            btnLimpiarFiltros.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = Color.FromArgb(230, 238, 252);
            btnLimpiarFiltros.Location = new Point(471, 58);
            btnLimpiarFiltros.Margin = new Padding(8, 0, 0, 0);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(86, 36);
            btnLimpiarFiltros.TabIndex = 11;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnFiltrarFechas
            // 
            btnFiltrarFechas.Anchor = AnchorStyles.Left;
            btnFiltrarFechas.BackColor = Color.FromArgb(31, 111, 235);
            btnFiltrarFechas.FlatAppearance.BorderSize = 0;
            btnFiltrarFechas.FlatStyle = FlatStyle.Flat;
            btnFiltrarFechas.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnFiltrarFechas.ForeColor = Color.White;
            btnFiltrarFechas.Location = new Point(377, 58);
            btnFiltrarFechas.Margin = new Padding(0);
            btnFiltrarFechas.Name = "btnFiltrarFechas";
            btnFiltrarFechas.Size = new Size(86, 36);
            btnFiltrarFechas.TabIndex = 10;
            btnFiltrarFechas.Text = "Filtrar";
            btnFiltrarFechas.UseVisualStyleBackColor = false;
            btnFiltrarFechas.Click += btnFiltrarFechas_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerDetalle.BackColor = Color.FromArgb(11, 15, 26);
            btnVerDetalle.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnVerDetalle.FlatStyle = FlatStyle.Flat;
            btnVerDetalle.Font = new Font("Segoe UI", 9F);
            btnVerDetalle.ForeColor = Color.FromArgb(230, 238, 252);
            btnVerDetalle.Location = new Point(759, 56);
            btnVerDetalle.Margin = new Padding(3, 4, 3, 4);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(110, 38);
            btnVerDetalle.TabIndex = 9;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = false;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(215, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión Compras";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 9F);
            lblDesde.ForeColor = Color.FromArgb(230, 238, 252);
            lblDesde.Location = new Point(20, 65);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(54, 20);
            lblDesde.TabIndex = 1;
            lblDesde.Text = "Desde:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(80, 61);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(110, 27);
            dtpFechaInicio.TabIndex = 2;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 9F);
            lblHasta.ForeColor = Color.FromArgb(230, 238, 252);
            lblHasta.Location = new Point(200, 65);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 20);
            lblHasta.TabIndex = 3;
            lblHasta.Text = "Hasta:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(255, 61);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(110, 27);
            dtpFechaFin.TabIndex = 4;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNuevo.BackColor = Color.FromArgb(31, 111, 235);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(633, 56);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(120, 38);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "+ Nueva Compra";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDesactivar.BackColor = Color.FromArgb(11, 15, 26);
            btnDesactivar.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI", 9F);
            btnDesactivar.ForeColor = Color.FromArgb(230, 238, 252);
            btnDesactivar.Location = new Point(875, 56);
            btnDesactivar.Margin = new Padding(3, 4, 3, 4);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(130, 38);
            btnDesactivar.TabIndex = 7;
            btnDesactivar.Text = "Cancelar Compra";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnCancelarCompra_Click;
            // 
            // btnEliminarFisico
            // 
            btnEliminarFisico.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminarFisico.BackColor = Color.FromArgb(11, 15, 26);
            btnEliminarFisico.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnEliminarFisico.FlatStyle = FlatStyle.Flat;
            btnEliminarFisico.Font = new Font("Segoe UI", 9F);
            btnEliminarFisico.ForeColor = Color.FromArgb(230, 238, 252);
            btnEliminarFisico.Location = new Point(1015, 56);
            btnEliminarFisico.Margin = new Padding(3, 4, 3, 4);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(110, 38);
            btnEliminarFisico.TabIndex = 8;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.UseVisualStyleBackColor = false;
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvCompras.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCompras.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCompras.Dock = DockStyle.Fill;
            dgvCompras.EnableHeadersVisualStyles = false;
            dgvCompras.GridColor = Color.FromArgb(15, 42, 79);
            dgvCompras.Location = new Point(0, 110);
            dgvCompras.Margin = new Padding(3, 4, 3, 4);
            dgvCompras.MultiSelect = false;
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.RowHeadersWidth = 51;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(1179, 690);
            dgvCompras.TabIndex = 1;
            // 
            // FrmCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1179, 800);
            Controls.Add(dgvCompras);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCompras";
            Text = "Compras";
            Load += FrmCompras_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private Panel panelTop;

        private Button btnNuevo;
        private Button btnDesactivar;
        private Button btnEliminarFisico;
        private DataGridView dgvCompras;
        private Button btnVerDetalle;
        private Button btnFiltrarFechas;
        private Button btnLimpiarFiltros;
    }
}