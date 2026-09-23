namespace Presentacion.Forms.Visitas
{
    partial class FrmVisitas
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
            flpFechas = new FlowLayoutPanel();
            lblDesde = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaFin = new DateTimePicker();
            btnFiltrarFechas = new Button();
            btnLimpiarFiltros = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnEliminarFisico = new Button();
            dgvVisitas = new DataGridView();
            panelTop.SuspendLayout();
            flpFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(flpFechas);
            panelTop.Controls.Add(lblBuscar);
            panelTop.Controls.Add(txtBuscar);
            panelTop.Controls.Add(btnNuevo);
            panelTop.Controls.Add(btnEditar);
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
            lblTitulo.Font = new Font("Segoe UI Bold", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Visitas";
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
            flpFechas.Location = new Point(20, 109);
            flpFechas.Margin = new Padding(3, 4, 3, 4);
            flpFechas.Name = "flpFechas";
            flpFechas.Size = new Size(620, 47);
            flpFechas.TabIndex = 1;
            flpFechas.WrapContents = false;
            // 
            // lblDesde
            // 
            lblDesde.Anchor = AnchorStyles.Left;
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 9.5F);
            lblDesde.ForeColor = ColorTranslator.FromHtml("#e6eefc");
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
            lblHasta.ForeColor = ColorTranslator.FromHtml("#e6eefc");
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
            btnFiltrarFechas.BackColor = ColorTranslator.FromHtml("#1f6feb");
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
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Anchor = AnchorStyles.Left;
            btnLimpiarFiltros.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnLimpiarFiltros.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnLimpiarFiltros.Location = new Point(498, 0);
            btnLimpiarFiltros.Margin = new Padding(8, 0, 0, 0);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(86, 36);
            btnLimpiarFiltros.TabIndex = 5;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F);
            lblBuscar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblBuscar.Location = new Point(20, 65);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(59, 21);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtBuscar.Location = new Point(85, 61);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(250, 30);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(886, 108);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(110, 38);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "+ Nueva";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnEditar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnEditar.Location = new Point(1002, 108);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 38);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminarFisico
            // 
            btnEliminarFisico.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminarFisico.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnEliminarFisico.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnEliminarFisico.FlatStyle = FlatStyle.Flat;
            btnEliminarFisico.Font = new Font("Segoe UI", 9F);
            btnEliminarFisico.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnEliminarFisico.Location = new Point(1108, 108);
            btnEliminarFisico.Margin = new Padding(3, 4, 3, 4);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(110, 38);
            btnEliminarFisico.TabIndex = 6;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.UseVisualStyleBackColor = false;
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            // 
            // dgvVisitas
            // 
            dgvVisitas.AllowUserToAddRows = false;
            dgvVisitas.AllowUserToDeleteRows = false;
            dgvVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisitas.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvVisitas.BorderStyle = BorderStyle.None;
            dgvVisitas.EnableHeadersVisualStyles = false;

            // Configuración estilo oscuro
            dgvVisitas.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvVisitas.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvVisitas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvVisitas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Padding margenCelda = new Padding(8, 0, 0, 0); // 8 píxeles a la izquierda
            dgvVisitas.ColumnHeadersDefaultCellStyle.Padding = margenCelda;
            dgvVisitas.DefaultCellStyle.Padding = margenCelda;

            dgvVisitas.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvVisitas.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvVisitas.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvVisitas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvVisitas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvVisitas.ScrollBars = ScrollBars.Both;

            dgvVisitas.GridColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvVisitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisitas.Dock = DockStyle.Fill;
            dgvVisitas.Location = new Point(0, 160);
            dgvVisitas.Margin = new Padding(3, 4, 3, 4);
            dgvVisitas.MultiSelect = false;
            dgvVisitas.Name = "dgvVisitas";
            dgvVisitas.ReadOnly = true;
            dgvVisitas.RowHeadersVisible = false;
            dgvVisitas.RowHeadersWidth = 51;
            dgvVisitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisitas.Size = new Size(1257, 640);
            dgvVisitas.TabIndex = 1;
            // 
            // FrmVisitas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(1257, 800);
            Controls.Add(dgvVisitas);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmVisitas";
            Text = "Visitas";
            Load += FrmVisitas_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flpFechas.ResumeLayout(false);
            flpFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelTop;
        private FlowLayoutPanel flpFechas;
        private Label lblDesde;
        private DateTimePicker dtpFechaInicio;
        private Label lblHasta;
        private DateTimePicker dtpFechaFin;
        private Button btnFiltrarFechas;
        private Button btnLimpiarFiltros;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnEliminarFisico;
        private DataGridView dgvVisitas;
    }
}