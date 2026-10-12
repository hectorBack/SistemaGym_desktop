namespace Presentacion.Forms.Conceptos
{
    partial class FrmConceptos
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
            dgvConceptos = new GridTema();
            panelPie = new Panel();
            lblNotaSistema = new Label();
            panelTop.SuspendLayout();
            flowAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConceptos).BeginInit();
            panelPie.SuspendLayout();
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
            lblTitulo.Size = new Size(240, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Conceptos";
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
            // dgvConceptos
            //
            dgvConceptos.Dock = DockStyle.Fill;
            dgvConceptos.Location = new Point(0, 70);
            dgvConceptos.Name = "dgvConceptos";
            dgvConceptos.Size = new Size(914, 696);
            dgvConceptos.TabIndex = 1;
            dgvConceptos.CellDoubleClick += dgvConceptos_CellDoubleClick;
            dgvConceptos.CellFormatting += dgvConceptos_CellFormatting;
            dgvConceptos.SelectionChanged += dgvConceptos_SelectionChanged;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(lblNotaSistema);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 766);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(914, 34);
            panelPie.TabIndex = 2;
            //
            // lblNotaSistema
            //
            lblNotaSistema.Dock = DockStyle.Fill;
            lblNotaSistema.Font = new Font("Segoe UI", 9F);
            lblNotaSistema.ForeColor = Color.FromArgb(124, 138, 165);
            lblNotaSistema.Location = new Point(0, 0);
            lblNotaSistema.Name = "lblNotaSistema";
            lblNotaSistema.Padding = new Padding(20, 0, 0, 0);
            lblNotaSistema.Size = new Size(914, 34);
            lblNotaSistema.TabIndex = 0;
            lblNotaSistema.Text = "Concepto del sistema: no se puede modificar, desactivar ni eliminar.";
            lblNotaSistema.TextAlign = ContentAlignment.MiddleLeft;
            lblNotaSistema.Visible = false;
            //
            // FrmConceptos
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(914, 800);
            Controls.Add(dgvConceptos);
            Controls.Add(panelPie);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmConceptos";
            Text = "Conceptos";
            Load += FrmConceptos_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConceptos).EndInit();
            panelPie.ResumeLayout(false);
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
        private GridTema dgvConceptos;
        private Panel panelPie;
        private Label lblNotaSistema;
    }
}