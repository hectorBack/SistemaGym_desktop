namespace Presentacion.Forms.Ventas
{
    partial class FrmVentaModal
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
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblSocio = new Label();
            txtSocioId = new TextBox();
            lblCodigoBarras = new Label();
            txtCodigoBarras = new TextBox();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            btnAgregar = new Button();
            btnQuitar = new Button();
            dgvCarrito = new DataGridView();
            lblTotalEtiqueta = new Label();
            lblTotalCalculado = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(707, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(290, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nueva Venta / Punto de Venta";
            // 
            // lblSocio
            // 
            lblSocio.AutoSize = true;
            lblSocio.Font = new Font("Segoe UI", 9.5F);
            lblSocio.ForeColor = Color.FromArgb(230, 238, 252);
            lblSocio.Location = new Point(29, 87);
            lblSocio.Name = "lblSocio";
            lblSocio.Size = new Size(146, 21);
            lblSocio.TabIndex = 1;
            lblSocio.Text = "ID Socio (Opcional):";
            // 
            // txtSocioId
            // 
            txtSocioId.BackColor = Color.FromArgb(15, 42, 79);
            txtSocioId.BorderStyle = BorderStyle.FixedSingle;
            txtSocioId.Font = new Font("Segoe UI", 10F);
            txtSocioId.ForeColor = Color.FromArgb(230, 238, 252);
            txtSocioId.Location = new Point(29, 113);
            txtSocioId.Margin = new Padding(3, 4, 3, 4);
            txtSocioId.Name = "txtSocioId";
            txtSocioId.Size = new Size(148, 30);
            txtSocioId.TabIndex = 2;
            // 
            // lblCodigoBarras
            // 
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.Font = new Font("Segoe UI", 9.5F);
            lblCodigoBarras.ForeColor = Color.FromArgb(230, 238, 252);
            lblCodigoBarras.Location = new Point(200, 87);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(159, 21);
            lblCodigoBarras.TabIndex = 3;
            lblCodigoBarras.Text = "Codigo Barras";
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.BackColor = Color.FromArgb(15, 42, 79);
            txtCodigoBarras.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoBarras.Font = new Font("Segoe UI", 10F);
            txtCodigoBarras.ForeColor = Color.FromArgb(230, 238, 252);
            txtCodigoBarras.Location = new Point(200, 113);
            txtCodigoBarras.Margin = new Padding(3, 4, 3, 4);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(251, 30);
            txtCodigoBarras.TabIndex = 4;
            txtCodigoBarras.KeyDown += txtCodigoBarras_KeyDown;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9.5F);
            lblCantidad.ForeColor = Color.FromArgb(230, 238, 252);
            lblCantidad.Location = new Point(469, 87);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(75, 21);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.BackColor = Color.FromArgb(15, 42, 79);
            numCantidad.BorderStyle = BorderStyle.FixedSingle;
            numCantidad.Font = new Font("Segoe UI", 10F);
            numCantidad.ForeColor = Color.FromArgb(230, 238, 252);
            numCantidad.Location = new Point(469, 113);
            numCantidad.Margin = new Padding(3, 4, 3, 4);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(80, 30);
            numCantidad.TabIndex = 6;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(31, 111, 235);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(566, 111);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(114, 37);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "+ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.BackColor = Color.FromArgb(15, 42, 79);
            btnQuitar.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnQuitar.FlatStyle = FlatStyle.Flat;
            btnQuitar.Font = new Font("Segoe UI", 9F);
            btnQuitar.ForeColor = Color.FromArgb(230, 238, 252);
            btnQuitar.Location = new Point(29, 480);
            btnQuitar.Margin = new Padding(3, 4, 3, 4);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(126, 43);
            btnQuitar.TabIndex = 9;
            btnQuitar.Text = "Quitar Ítem";
            btnQuitar.UseVisualStyleBackColor = false;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.BackgroundColor = Color.FromArgb(15, 42, 79);
            dgvCarrito.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(11, 15, 26);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 212, 255);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCarrito.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 42, 79);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 238, 252);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(31, 111, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCarrito.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.GridColor = Color.FromArgb(11, 15, 26);
            dgvCarrito.Location = new Point(29, 167);
            dgvCarrito.Margin = new Padding(3, 4, 3, 4);
            dgvCarrito.MultiSelect = false;
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(651, 293);
            dgvCarrito.TabIndex = 8;
            dgvCarrito.KeyDown += dgvCarrito_KeyDown;
            // 
            // lblTotalEtiqueta
            // 
            lblTotalEtiqueta.AutoSize = true;
            lblTotalEtiqueta.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblTotalEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotalEtiqueta.Location = new Point(434, 484);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(91, 25);
            lblTotalEtiqueta.TabIndex = 10;
            lblTotalEtiqueta.Text = "TOTAL:";
            // 
            // lblTotalCalculado
            // 
            lblTotalCalculado.AutoSize = true;
            lblTotalCalculado.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTotalCalculado.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotalCalculado.Location = new Point(514, 480);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(76, 29);
            lblTotalCalculado.TabIndex = 11;
            lblTotalCalculado.Text = "$0.00";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(31, 111, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(411, 553);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(126, 47);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Completar Venta";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(15, 42, 79);
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(31, 111, 235);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F);
            btnCancelar.ForeColor = Color.FromArgb(230, 238, 252);
            btnCancelar.Location = new Point(554, 553);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(126, 47);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmVentaModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(707, 627);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblTotalCalculado);
            Controls.Add(lblTotalEtiqueta);
            Controls.Add(btnQuitar);
            Controls.Add(dgvCarrito);
            Controls.Add(btnAgregar);
            Controls.Add(numCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(txtCodigoBarras);
            Controls.Add(lblCodigoBarras);
            Controls.Add(txtSocioId);
            Controls.Add(lblSocio);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVentaModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Punto de Venta";
            KeyPreview = true;
            KeyDown += FrmVentaModal_KeyDown;
            Load += FrmVentaModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblSocio;
        private TextBox txtSocioId;
        private Label lblCodigoBarras;
        private TextBox txtCodigoBarras;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Button btnAgregar;
        private DataGridView dgvCarrito;
        private Button btnQuitar;
        private Label lblTotalEtiqueta;
        private Label lblTotalCalculado;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}