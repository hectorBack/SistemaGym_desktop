namespace Presentacion.Forms.Ventas
{
    partial class FrmVentas
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
            lblTitulo = new Label();
            flpFechas = new FlowLayoutPanel();
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnFiltrarFechas = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnNuevaVenta = new Button();
            btnLimpiarFiltros = new Button();
            btnVerDetalle = new Button();
            btnAnular = new Button();
            btnEliminarFisico = new Button();
            dgvVentas = new DataGridView();
            panelTop.SuspendLayout();
            flpFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(flpFechas);
            panelTop.Controls.Add(lblBuscar);
            panelTop.Controls.Add(txtBuscar);
            panelTop.Controls.Add(btnNuevaVenta);
            panelTop.Controls.Add(btnVerDetalle);
            panelTop.Controls.Add(btnAnular);
            panelTop.Controls.Add(btnEliminarFisico);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1257, 160);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(245, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Ventas";
            // 
            // flpFechas
            // 
            flpFechas.AutoSize = true;
            flpFechas.Controls.Add(lblDesde);
            flpFechas.Controls.Add(dtpFechaInicio);
            flpFechas.Controls.Add(lblHasta);
            flpFechas.Controls.Add(dtpFechaFin);
            flpFechas.Controls.Add(btnFiltrarFechas);
            flpFechas.Controls.Add(btnLimpiarFiltros);
            flpFechas.Location = new Point(23, 109);
            flpFechas.Margin = new Padding(3, 4, 3, 4);
            flpFechas.Name = "flpFechas";
            flpFechas.Size = new Size(600, 47);
            flpFechas.TabIndex = 1;
            flpFechas.WrapContents = false;
            // 
            // lblDesde
            // 
            lblDesde.Anchor = AnchorStyles.Left;
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 9.5F);
            lblDesde.ForeColor = Color.FromArgb(230, 238, 252);
            lblDesde.Location = new Point(0, 7);
            lblDesde.Margin = new Padding(0, 0, 6, 0);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(56, 21);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Anchor = AnchorStyles.Left;
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(62, 4);
            dtpFechaInicio.Margin = new Padding(0, 0, 17, 0);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(125, 27);
            dtpFechaInicio.TabIndex = 1;
            // 
            // lblHasta
            // 
            lblHasta.Anchor = AnchorStyles.Left;
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 9.5F);
            lblHasta.ForeColor = Color.FromArgb(230, 238, 252);
            lblHasta.Location = new Point(204, 7);
            lblHasta.Margin = new Padding(0, 0, 6, 0);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(52, 21);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Anchor = AnchorStyles.Left;
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(262, 4);
            dtpFechaFin.Margin = new Padding(0, 0, 17, 0);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(125, 27);
            dtpFechaFin.TabIndex = 3;
            // 
            // btnFiltrarFechas
            // 
            btnFiltrarFechas.Anchor = AnchorStyles.Left;
            btnFiltrarFechas.BackColor = Color.FromArgb(31, 111, 235);
            btnFiltrarFechas.FlatAppearance.BorderSize = 0;
            btnFiltrarFechas.FlatStyle = FlatStyle.Flat;
            btnFiltrarFechas.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnFiltrarFechas.ForeColor = Color.White;
            btnFiltrarFechas.Location = new Point(404, 0);
            btnFiltrarFechas.Margin = new Padding(0);
            btnFiltrarFechas.Name = "btnFiltrarFechas";
            btnFiltrarFechas.Size = new Size(86, 36);
            btnFiltrarFechas.TabIndex = 4;
            btnFiltrarFechas.Text = "Filtrar";
            btnFiltrarFechas.UseVisualStyleBackColor = false;
            btnFiltrarFechas.Click += btnFiltrarFechas_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F);
            lblBuscar.ForeColor = Color.FromArgb(230, 238, 252);
            lblBuscar.Location = new Point(22, 76);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(59, 21);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.FromArgb(11, 15, 26);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.ForeColor = Color.FromArgb(230, 238, 252);
            txtBuscar.Location = new Point(85, 71);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(251, 30);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaVenta.BackColor = Color.FromArgb(31, 111, 235);
            btnNuevaVenta.FlatAppearance.BorderSize = 0;
            btnNuevaVenta.FlatStyle = FlatStyle.Flat;
            btnNuevaVenta.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevaVenta.ForeColor = Color.White;
            btnNuevaVenta.Location = new Point(686, 108);
            btnNuevaVenta.Margin = new Padding(3, 4, 3, 4);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(110, 38);
            btnNuevaVenta.TabIndex = 4;
            btnNuevaVenta.Text = "+ Nueva Venta";
            btnNuevaVenta.UseVisualStyleBackColor = false;
            btnNuevaVenta.Click += btnNuevaVenta_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Anchor = AnchorStyles.Left;
            btnLimpiarFiltros.BackColor = Color.FromArgb(11, 15, 26);
            btnLimpiarFiltros.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = Color.FromArgb(230, 238, 252);
            btnLimpiarFiltros.Location = new Point(533, 109);
            btnLimpiarFiltros.Margin = new Padding(8, 0, 0, 0);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(86, 36);
            btnLimpiarFiltros.TabIndex = 5;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerDetalle.BackColor = Color.FromArgb(11, 15, 26);
            btnVerDetalle.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnVerDetalle.FlatStyle = FlatStyle.Flat;
            btnVerDetalle.Font = new Font("Segoe UI", 9F);
            btnVerDetalle.ForeColor = Color.FromArgb(230, 238, 252);
            btnVerDetalle.Location = new Point(823, 108);
            btnVerDetalle.Margin = new Padding(3, 4, 3, 4);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(110, 38);
            btnVerDetalle.TabIndex = 5;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = false;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnAnular
            // 
            btnAnular.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnular.BackColor = Color.FromArgb(11, 15, 26);
            btnAnular.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnAnular.FlatStyle = FlatStyle.Flat;
            btnAnular.Font = new Font("Segoe UI", 9F);
            btnAnular.ForeColor = Color.FromArgb(230, 238, 252);
            btnAnular.Location = new Point(949, 108);
            btnAnular.Margin = new Padding(3, 4, 3, 4);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(110, 38);
            btnAnular.TabIndex = 6;
            btnAnular.Text = "Anular Venta";
            btnAnular.UseVisualStyleBackColor = false;
            btnAnular.Click += btnAnular_Click;
            // 
            // btnEliminarFisico
            // 
            btnEliminarFisico.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminarFisico.BackColor = Color.FromArgb(11, 15, 26);
            btnEliminarFisico.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnEliminarFisico.FlatStyle = FlatStyle.Flat;
            btnEliminarFisico.Font = new Font("Segoe UI", 9F);
            btnEliminarFisico.ForeColor = Color.FromArgb(230, 238, 252);
            btnEliminarFisico.Location = new Point(1086, 108);
            btnEliminarFisico.Margin = new Padding(3, 4, 3, 4);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(110, 38);
            btnEliminarFisico.TabIndex = 7;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.UseVisualStyleBackColor = false;
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            // Configuración estilo oscuro en dgvVentas
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.EnableHeadersVisualStyles = false;

            // Encabezados
            dgvVentas.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Relleno de celdas estandarizado (8px a la izquierda)
            Padding margenCelda = new Padding(8, 0, 0, 0);
            dgvVentas.ColumnHeadersDefaultCellStyle.Padding = margenCelda;
            dgvVentas.DefaultCellStyle.Padding = margenCelda;

            // Celdas estándar y selección
            dgvVentas.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvVentas.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvVentas.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvVentas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvVentas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvVentas.ScrollBars = ScrollBars.Both;

            dgvVentas.GridColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Dock = DockStyle.Fill;
            dgvVentas.Location = new Point(0, 160);
            dgvVentas.Margin = new Padding(3, 4, 3, 4);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(1257, 907);
            dgvVentas.TabIndex = 1;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1257, 1067);
            Controls.Add(dgvVentas);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmVentas";
            Text = "Ventas";
            Load += FrmVentas_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flpFechas.ResumeLayout(false);
            flpFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flpFechas;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private Button btnFiltrarFechas;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnNuevaVenta;
        private Button btnVerDetalle;
        private Button btnAnular;
        private Button btnEliminarFisico;
        private DataGridView dgvVentas;
        private Button btnLimpiarFiltros;
    }
}