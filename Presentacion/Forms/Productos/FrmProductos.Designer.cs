namespace Presentacion.Forms.Productos
{
    partial class FrmProductos
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelTop = new Panel();
            flowAcciones = new FlowLayoutPanel();
            btnNuevo = new BotonTema();
            btnEditar = new BotonTema();
            btnDesactivar = new BotonTema();
            btnEliminarFisico = new BotonTema();
            lblTitulo = new Label();
            panelBusqueda = new Panel();
            lblConteo = new Label();
            txtBuscar = new TextBox();
            dgvProductos = new GridTema();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
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
            panelTop.Size = new Size(914, 70);
            panelTop.TabIndex = 0;
            // 
            // flowAcciones
            // 
            flowAcciones.AutoSize = true;
            flowAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAcciones.Controls.Add(btnNuevo);
            flowAcciones.Controls.Add(btnEditar);
            flowAcciones.Controls.Add(btnDesactivar);
            flowAcciones.Controls.Add(btnEliminarFisico);
            flowAcciones.Dock = DockStyle.Right;
            flowAcciones.Location = new Point(440, 0);
            flowAcciones.Name = "flowAcciones";
            flowAcciones.Padding = new Padding(0, 16, 12, 0);
            flowAcciones.Size = new Size(474, 70);
            flowAcciones.TabIndex = 1;
            flowAcciones.WrapContents = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(31, 111, 235);
            btnNuevo.Estilo = EstiloBoton.Primario;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnNuevo.FlatAppearance.MouseDownBackColor = Color.FromArgb(26, 95, 207);
            btnNuevo.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 139, 253);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(0, 16);
            btnNuevo.Margin = new Padding(0, 0, 8, 0);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(110, 38);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(11, 15, 26);
            btnEditar.Enabled = false;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.FromArgb(230, 238, 252);
            btnEditar.Location = new Point(118, 16);
            btnEditar.Margin = new Padding(0, 0, 8, 0);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 38);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.BackColor = Color.FromArgb(11, 15, 26);
            btnDesactivar.Enabled = false;
            btnDesactivar.Estilo = EstiloBoton.Advertencia;
            btnDesactivar.FlatAppearance.BorderColor = Color.FromArgb(245, 181, 61);
            btnDesactivar.FlatAppearance.MouseDownBackColor = Color.FromArgb(58, 44, 12);
            btnDesactivar.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 44, 12);
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDesactivar.ForeColor = Color.FromArgb(245, 181, 61);
            btnDesactivar.Location = new Point(226, 16);
            btnDesactivar.Margin = new Padding(0, 0, 8, 0);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(110, 38);
            btnDesactivar.TabIndex = 2;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnEliminarFisico
            // 
            btnEliminarFisico.BackColor = Color.FromArgb(11, 15, 26);
            btnEliminarFisico.Enabled = false;
            btnEliminarFisico.Estilo = EstiloBoton.Peligro;
            btnEliminarFisico.FlatAppearance.BorderColor = Color.FromArgb(248, 113, 113);
            btnEliminarFisico.FlatAppearance.MouseDownBackColor = Color.FromArgb(59, 18, 25);
            btnEliminarFisico.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 18, 25);
            btnEliminarFisico.FlatStyle = FlatStyle.Flat;
            btnEliminarFisico.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEliminarFisico.ForeColor = Color.FromArgb(248, 113, 113);
            btnEliminarFisico.Location = new Point(344, 16);
            btnEliminarFisico.Margin = new Padding(0, 0, 8, 0);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(110, 38);
            btnEliminarFisico.TabIndex = 3;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.UseVisualStyleBackColor = false;
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Productos";
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = Color.FromArgb(11, 15, 26);
            panelBusqueda.Controls.Add(lblConteo);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Dock = DockStyle.Top;
            panelBusqueda.Location = new Point(0, 70);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Padding = new Padding(0, 0, 20, 0);
            panelBusqueda.Size = new Size(914, 56);
            panelBusqueda.TabIndex = 1;
            // 
            // lblConteo
            // 
            lblConteo.Dock = DockStyle.Right;
            lblConteo.Font = new Font("Segoe UI", 9.5F);
            lblConteo.ForeColor = Color.FromArgb(124, 138, 165);
            lblConteo.Location = new Point(674, 0);
            lblConteo.Name = "lblConteo";
            lblConteo.Size = new Size(220, 56);
            lblConteo.TabIndex = 1;
            lblConteo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.FromArgb(15, 42, 79);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.ForeColor = Color.FromArgb(230, 238, 252);
            txtBuscar.Location = new Point(20, 14);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre, código o categoría…";
            txtBuscar.Size = new Size(380, 30);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(14, 20, 36);
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvProductos.BackgroundColor = Color.FromArgb(11, 15, 26);
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle2.Padding = new Padding(12, 0, 12, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle3.Padding = new Padding(12, 0, 12, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(15, 42, 79);
            dgvProductos.Location = new Point(0, 126);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(914, 674);
            dgvProductos.TabIndex = 2;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            dgvProductos.CellFormatting += dgvProductos_CellFormatting;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvProductos);
            Controls.Add(panelBusqueda);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProductos";
            Text = "Productos";
            Load += FrmProductos_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnNuevo;
        private BotonTema btnEditar;
        private BotonTema btnDesactivar;
        private BotonTema btnEliminarFisico;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Label lblConteo;
        private GridTema dgvProductos;
    }
}