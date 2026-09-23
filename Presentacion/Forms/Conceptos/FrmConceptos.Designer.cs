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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnDesactivar = new Button();
            btnEliminarFisico = new Button();
            dgvConceptos = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConceptos).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblBuscar);
            panelTop.Controls.Add(txtBuscar);
            panelTop.Controls.Add(btnNuevo);
            panelTop.Controls.Add(btnEditar);
            panelTop.Controls.Add(btnDesactivar);
            panelTop.Controls.Add(btnEliminarFisico);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 110);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Bold", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(210, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión Conceptos";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F);
            lblBuscar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblBuscar.Location = new Point(20, 65);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(59, 21);
            lblBuscar.TabIndex = 1;
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
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNuevo.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.Location = new Point(400, 56);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(110, 38);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnEditar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnEditar.Location = new Point(520, 56);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 38);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDesactivar.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI", 9F);
            btnDesactivar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnDesactivar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnDesactivar.Location = new Point(630, 56);
            btnDesactivar.Margin = new Padding(3, 4, 3, 4);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(110, 38);
            btnDesactivar.TabIndex = 5;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnEliminarFisico
            // 
            btnEliminarFisico.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminarFisico.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnEliminarFisico.FlatStyle = FlatStyle.Flat;
            btnEliminarFisico.Font = new Font("Segoe UI", 9F);
            btnEliminarFisico.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnEliminarFisico.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnEliminarFisico.Location = new Point(750, 56);
            btnEliminarFisico.Margin = new Padding(3, 4, 3, 4);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(110, 38);
            btnEliminarFisico.TabIndex = 6;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.UseVisualStyleBackColor = false;
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            // 
            // dgvConceptos
            // 
            dgvConceptos.AllowUserToAddRows = false;
            dgvConceptos.AllowUserToDeleteRows = false;
            dgvConceptos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConceptos.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvConceptos.BorderStyle = BorderStyle.None;
            dgvConceptos.EnableHeadersVisualStyles = false;

            // Encabezados
            dgvConceptos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvConceptos.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvConceptos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvConceptos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Relleno de celdas estandarizado (8px a la izquierda)
            Padding margenCelda = new Padding(8, 0, 0, 0);
            dgvConceptos.ColumnHeadersDefaultCellStyle.Padding = margenCelda;
            dgvConceptos.DefaultCellStyle.Padding = margenCelda;

            // Celdas estándar y selección
            dgvConceptos.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvConceptos.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvConceptos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvConceptos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvConceptos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvConceptos.ScrollBars = ScrollBars.Both;

            dgvConceptos.GridColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvConceptos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConceptos.Dock = DockStyle.Fill;
            dgvConceptos.Location = new Point(0, 110);
            dgvConceptos.Margin = new Padding(3, 4, 3, 4);
            dgvConceptos.MultiSelect = false;
            dgvConceptos.Name = "dgvConceptos";
            dgvConceptos.ReadOnly = true;
            dgvConceptos.RowHeadersVisible = false;
            dgvConceptos.RowHeadersWidth = 51;
            dgvConceptos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConceptos.Size = new Size(914, 690);
            dgvConceptos.TabIndex = 1;
            // 
            // FrmConceptos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(914, 800);
            Controls.Add(dgvConceptos);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmConceptos";
            Text = "Conceptos";
            Load += FrmConceptos_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConceptos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelTop;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnDesactivar;
        private Button btnEliminarFisico;
        private DataGridView dgvConceptos;
    }
}