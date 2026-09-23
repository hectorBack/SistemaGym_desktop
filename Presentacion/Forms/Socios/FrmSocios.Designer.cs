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
            panelTop = new Panel();
            lblTitulo = new Label();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnInfo = new Button();
            btnMembresia = new Button();
            btnDesactivar = new Button();
            btnEliminarFisico = new Button();
            dgvSocios = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // panelTop (Contiene los controles y detalles en la parte superior)
            // 
            panelTop.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblBuscar);
            panelTop.Controls.Add(txtBuscar);
            panelTop.Controls.Add(btnNuevo);
            panelTop.Controls.Add(btnEditar);
            panelTop.Controls.Add(btnInfo);
            panelTop.Controls.Add(btnMembresia);
            panelTop.Controls.Add(btnDesactivar);
            panelTop.Controls.Add(btnEliminarFisico);
            panelTop.Dock = DockStyle.Top; // Permanece en la parte superior
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 150); // Se incrementa la altura si agregas más detalles
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Bold", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión Socios";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F);
            lblBuscar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblBuscar.Location = new Point(20, 105);
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
            txtBuscar.Location = new Point(85, 101);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(160, 30);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNuevo.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(260, 96);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 38);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnEditar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F);
            btnEditar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnEditar.Location = new Point(360, 96);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(90, 38);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnInfo
            // 
            btnInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnInfo.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnInfo.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#2dd4ff");
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.Font = new Font("Segoe UI", 9F);
            btnInfo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            btnInfo.Location = new Point(460, 96);
            btnInfo.Margin = new Padding(3, 4, 3, 4);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(100, 38);
            btnInfo.TabIndex = 5;
            btnInfo.Text = "Información";
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Click += btnInfo_Click;
            // 
            // btnMembresia
            // 
            btnMembresia.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMembresia.BackColor = ColorTranslator.FromHtml("#00b4d8");
            btnMembresia.FlatAppearance.BorderSize = 0;
            btnMembresia.FlatStyle = FlatStyle.Flat;
            btnMembresia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnMembresia.ForeColor = Color.White;
            btnMembresia.Location = new Point(570, 96);
            btnMembresia.Margin = new Padding(3, 4, 3, 4);
            btnMembresia.Name = "btnMembresia";
            btnMembresia.Size = new Size(105, 38);
            btnMembresia.TabIndex = 6;
            btnMembresia.Text = "Membresía";
            btnMembresia.UseVisualStyleBackColor = false;
            btnMembresia.Click += btnMembresia_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDesactivar.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnDesactivar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI", 9F);
            btnDesactivar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnDesactivar.Location = new Point(685, 96);
            btnDesactivar.Margin = new Padding(3, 4, 3, 4);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(100, 38);
            btnDesactivar.TabIndex = 7;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnEliminarFisico
            // 
            btnEliminarFisico.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminarFisico.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnEliminarFisico.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnEliminarFisico.FlatStyle = FlatStyle.Flat;
            btnEliminarFisico.Font = new Font("Segoe UI", 9F);
            btnEliminarFisico.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnEliminarFisico.Location = new Point(795, 96);
            btnEliminarFisico.Margin = new Padding(3, 4, 3, 4);
            btnEliminarFisico.Name = "btnEliminarFisico";
            btnEliminarFisico.Size = new Size(95, 38);
            btnEliminarFisico.TabIndex = 8;
            btnEliminarFisico.Text = "Eliminar";
            btnEliminarFisico.UseVisualStyleBackColor = false;
            btnEliminarFisico.Click += btnEliminarFisico_Click;
            // 
            // dgvSocios (Tabla acoplada abajo ocupando el resto de la pantalla)
            // 
            dgvSocios.AllowUserToAddRows = false;
            dgvSocios.AllowUserToDeleteRows = false;
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSocios.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvSocios.BorderStyle = BorderStyle.None;
            dgvSocios.EnableHeadersVisualStyles = false;

            // Encabezados
            dgvSocios.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvSocios.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvSocios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvSocios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            Padding margenCelda = new Padding(8, 0, 0, 0);
            dgvSocios.ColumnHeadersDefaultCellStyle.Padding = margenCelda;
            dgvSocios.DefaultCellStyle.Padding = margenCelda;

            // Celdas estándar y selección
            dgvSocios.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvSocios.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvSocios.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvSocios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSocios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvSocios.ScrollBars = ScrollBars.Both;

            dgvSocios.GridColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Dock = DockStyle.Fill; // Se expande en el espacio restante debajo del panel
            dgvSocios.Location = new Point(0, 150);
            dgvSocios.Margin = new Padding(3, 4, 3, 4);
            dgvSocios.MultiSelect = false;
            dgvSocios.Name = "dgvSocios";
            dgvSocios.ReadOnly = true;
            dgvSocios.RowHeadersVisible = false;
            dgvSocios.RowHeadersWidth = 51;
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.Size = new Size(914, 650);
            dgvSocios.TabIndex = 1;
            // 
            // FrmSocios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(914, 800);
            Controls.Add(dgvSocios); // dgvSocios se agrega primero para rellenar
            Controls.Add(panelTop);   // panelTop se acopla arriba
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmSocios";
            Text = "Socios";
            Load += FrmSocios_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelTop;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnInfo;
        private Button btnMembresia;
        private Button btnDesactivar;
        private Button btnEliminarFisico;
        private DataGridView dgvSocios;
    }
}