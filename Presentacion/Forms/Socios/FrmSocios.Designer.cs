namespace Presentacion.Forms.Socios
{
    partial class FrmSocios
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
            components = new System.ComponentModel.Container();
            panelTop = new Panel();
            lblTitulo = new Label();
            flowBusqueda = new FlowLayoutPanel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            panelAcciones = new Panel();
            flowAcciones = new FlowLayoutPanel();
            btnNuevo = new BotonTema();
            btnEditar = new BotonTema();
            btnInfo = new BotonTema();
            btnMembresia = new BotonTema();
            btnDesactivar = new BotonTema();
            btnEliminarFisico = new BotonTema();
            dgvSocios = new GridTema();
            panelPie = new Panel();
            lblResumen = new Label();
            temporizadorBusqueda = new System.Windows.Forms.Timer(components);
            panelTop.SuspendLayout();
            flowBusqueda.SuspendLayout();
            panelAcciones.SuspendLayout();
            flowAcciones.SuspendLayout();
            panelPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            //
            // panelTop
            //
            panelTop.BackColor = Color.FromArgb(15, 42, 79);
            panelTop.Controls.Add(flowBusqueda);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 64);
            panelTop.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Socios";
            //
            // flowBusqueda
            //
            flowBusqueda.AutoSize = true;
            flowBusqueda.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowBusqueda.Controls.Add(lblBuscar);
            flowBusqueda.Controls.Add(txtBuscar);
            flowBusqueda.Dock = DockStyle.Right;
            flowBusqueda.Location = new Point(600, 0);
            flowBusqueda.Name = "flowBusqueda";
            flowBusqueda.Padding = new Padding(0, 17, 20, 0);
            flowBusqueda.Size = new Size(314, 64);
            flowBusqueda.TabIndex = 1;
            flowBusqueda.WrapContents = false;
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F);
            lblBuscar.ForeColor = Color.FromArgb(230, 238, 252);
            lblBuscar.Margin = new Padding(0, 6, 8, 0);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(59, 21);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.BackColor = Color.FromArgb(11, 15, 26);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.ForeColor = Color.FromArgb(230, 238, 252);
            txtBuscar.Margin = new Padding(0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre, clave, teléfono o correo";
            txtBuscar.Size = new Size(227, 30);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            //
            // panelAcciones
            //
            panelAcciones.BackColor = Color.FromArgb(14, 20, 36);
            panelAcciones.Controls.Add(flowAcciones);
            panelAcciones.Dock = DockStyle.Top;
            panelAcciones.Location = new Point(0, 64);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Size = new Size(914, 58);
            panelAcciones.TabIndex = 1;
            //
            // flowAcciones
            //
            flowAcciones.AutoSize = true;
            flowAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowAcciones.Controls.Add(btnNuevo);
            flowAcciones.Controls.Add(btnEditar);
            flowAcciones.Controls.Add(btnInfo);
            flowAcciones.Controls.Add(btnMembresia);
            flowAcciones.Controls.Add(btnDesactivar);
            flowAcciones.Controls.Add(btnEliminarFisico);
            flowAcciones.Dock = DockStyle.Left;
            flowAcciones.Location = new Point(0, 0);
            flowAcciones.Name = "flowAcciones";
            flowAcciones.Padding = new Padding(20, 10, 0, 0);
            flowAcciones.Size = new Size(660, 58);
            flowAcciones.TabIndex = 0;
            flowAcciones.WrapContents = false;
            //
            // btnNuevo
            //
            btnNuevo.Estilo = EstiloBoton.Primario;
            btnNuevo.Margin = new Padding(0, 0, 8, 0);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 38);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnEditar
            //
            btnEditar.Enabled = false;
            btnEditar.Margin = new Padding(0, 0, 8, 0);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(80, 38);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            //
            // btnInfo
            //
            btnInfo.Enabled = false;
            btnInfo.Margin = new Padding(0, 0, 8, 0);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(105, 38);
            btnInfo.TabIndex = 2;
            btnInfo.Text = "Información";
            btnInfo.Click += btnInfo_Click;
            //
            // btnMembresia
            //
            btnMembresia.Enabled = false;
            btnMembresia.Margin = new Padding(0, 0, 8, 0);
            btnMembresia.Name = "btnMembresia";
            btnMembresia.Size = new Size(105, 38);
            btnMembresia.TabIndex = 3;
            btnMembresia.Text = "Membresía";
            btnMembresia.Click += btnMembresia_Click;
            //
            // btnDesactivar
            //
            btnDesactivar.Enabled = false;
            btnDesactivar.Estilo = EstiloBoton.Advertencia;
            btnDesactivar.Margin = new Padding(0, 0, 8, 0);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(105, 38);
            btnDesactivar.TabIndex = 4;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.Click += btnDesactivar_Click;
            //
            // btnEliminarFisico
            //
            btnEliminarFisico.Enabled = false;
            btnEliminarFisico.Estilo = EstiloBoton.Peligro;
            btnEliminarFisico.Margin = new Padding(0, 0, 8, 0);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(90, 38);
            btnEliminarFisico.TabIndex = 5;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            //
            // dgvSocios
            //
            dgvSocios.Dock = DockStyle.Fill;
            dgvSocios.Location = new Point(0, 122);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(914, 646);
            dgvSocios.TabIndex = 2;
            dgvSocios.CellDoubleClick += dgvSocios_CellDoubleClick;
            dgvSocios.CellFormatting += dgvSocios_CellFormatting;
            dgvSocios.SelectionChanged += dgvSocios_SelectionChanged;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(lblResumen);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 768);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(914, 32);
            panelPie.TabIndex = 3;
            //
            // lblResumen
            //
            lblResumen.Dock = DockStyle.Fill;
            lblResumen.Font = new Font("Segoe UI", 9.5F);
            lblResumen.ForeColor = Color.FromArgb(124, 138, 165);
            lblResumen.Name = "lblResumen";
            lblResumen.Padding = new Padding(20, 0, 0, 0);
            lblResumen.Size = new Size(914, 32);
            lblResumen.TabIndex = 0;
            lblResumen.TextAlign = ContentAlignment.MiddleLeft;
            //
            // temporizadorBusqueda
            //
            temporizadorBusqueda.Interval = 250;
            temporizadorBusqueda.Tick += temporizadorBusqueda_Tick;
            //
            // FrmSocios
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvSocios);
            Controls.Add(panelPie);
            Controls.Add(panelAcciones);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSocios";
            Text = "Socios";
            Load += FrmSocios_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowBusqueda.ResumeLayout(false);
            flowBusqueda.PerformLayout();
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            flowAcciones.ResumeLayout(false);
            panelPie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlowLayoutPanel flowBusqueda;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Panel panelAcciones;
        private FlowLayoutPanel flowAcciones;
        private BotonTema btnNuevo;
        private BotonTema btnEditar;
        private BotonTema btnInfo;
        private BotonTema btnMembresia;
        private BotonTema btnDesactivar;
        private BotonTema btnEliminarFisico;
        private GridTema dgvSocios;
        private Panel panelPie;
        private Label lblResumen;
        private System.Windows.Forms.Timer temporizadorBusqueda;
    }
}