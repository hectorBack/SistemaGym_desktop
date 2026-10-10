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
            panelTop = new Panel();
            lblTitulo = new Label();
            flowAcciones = new FlowLayoutPanel();
            btnNuevo = new BotonTema();
            btnEditar = new BotonTema();
            btnDesactivar = new BotonTema();
            btnEliminarFisico = new BotonTema();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            lblConteo = new Label();
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
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Productos";
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
            btnNuevo.Estilo = EstiloBoton.Primario;
            btnNuevo.Margin = new Padding(0, 0, 8, 0);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(110, 38);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnEditar
            //
            btnEditar.Enabled = false;
            btnEditar.Margin = new Padding(0, 0, 8, 0);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 38);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            //
            // btnDesactivar
            //
            btnDesactivar.Enabled = false;
            btnDesactivar.Estilo = EstiloBoton.Advertencia;
            btnDesactivar.Margin = new Padding(0, 0, 8, 0);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(110, 38);
            btnDesactivar.TabIndex = 2;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.Click += btnDesactivar_Click;
            //
            // btnEliminarFisico
            //
            btnEliminarFisico.Enabled = false;
            btnEliminarFisico.Estilo = EstiloBoton.Peligro;
            btnEliminarFisico.Margin = new Padding(0, 0, 8, 0);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(110, 38);
            btnEliminarFisico.TabIndex = 3;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.Click += btnEliminarFisico_Click;
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
            // dgvProductos
            //
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(0, 126);
            dgvProductos.Name = "dgvProductos";
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