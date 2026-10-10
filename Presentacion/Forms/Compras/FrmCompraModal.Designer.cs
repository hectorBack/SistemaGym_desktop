namespace Presentacion.Forms.Compras
{
    partial class FrmCompraModal
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
            lblFormaPago = new Label();
            cmbFormaPago = new ComboBox();
            lblProducto = new Label();
            cmbProductos = new ComboBox();
            lblBuscarProducto = new Label();
            txtBuscarProducto = new TextBox();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            lblCostoEtiqueta = new Label();
            lblCostoValor = new Label();
            lblPrecioEtiqueta = new Label();
            lblPrecioValor = new Label();
            btnAgregarProducto = new Button();
            btnQuitarProducto = new Button();
            dgvDetalles = new DataGridView();
            lblTotalEtiqueta = new Label();
            lblTotalCalculado = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 50);
            panelHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(183, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Nueva Compra";

            // 
            // lblFormaPago
            // 
            lblFormaPago.AutoSize = true;
            lblFormaPago.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblFormaPago.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFormaPago.Location = new Point(25, 65);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(101, 17);
            lblFormaPago.TabIndex = 1;
            lblFormaPago.Text = "Forma de Pago:";

            // 
            // cmbFormaPago
            // 
            cmbFormaPago.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPago.FlatStyle = FlatStyle.Flat;
            cmbFormaPago.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFormaPago.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbFormaPago.Location = new Point(25, 87);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(200, 25);
            cmbFormaPago.TabIndex = 2;

            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblProducto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblProducto.Location = new Point(245, 65);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(130, 17);
            lblProducto.TabIndex = 18;
            lblProducto.Text = "Seleccionar Producto:";

            // 
            // cmbProductos
            // 
            cmbProductos.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductos.FlatStyle = FlatStyle.Flat;
            cmbProductos.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cmbProductos.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(245, 87);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(355, 25);
            cmbProductos.TabIndex = 19;
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;

            // 
            // lblBuscarProducto
            // 
            lblBuscarProducto.AutoSize = true;
            lblBuscarProducto.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblBuscarProducto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblBuscarProducto.Location = new Point(25, 125);
            lblBuscarProducto.Name = "lblBuscarProducto";
            lblBuscarProducto.Size = new Size(111, 17);
            lblBuscarProducto.TabIndex = 3;
            lblBuscarProducto.Text = "Código de Barras:";

            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtBuscarProducto.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtBuscarProducto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtBuscarProducto.Location = new Point(25, 147);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(180, 25);
            txtBuscarProducto.TabIndex = 4;
            txtBuscarProducto.KeyDown += txtBuscarProducto_KeyDown;

            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantidad.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblCantidad.Location = new Point(220, 125);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(63, 17);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";

            // 
            // numCantidad
            // 
            numCantidad.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            numCantidad.BorderStyle = BorderStyle.FixedSingle;
            numCantidad.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            numCantidad.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            numCantidad.Location = new Point(220, 147);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(75, 24);
            numCantidad.TabIndex = 6;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // lblCostoEtiqueta
            // 
            lblCostoEtiqueta.AutoSize = true;
            lblCostoEtiqueta.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCostoEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblCostoEtiqueta.Location = new Point(310, 127);
            lblCostoEtiqueta.Name = "lblCostoEtiqueta";
            lblCostoEtiqueta.Size = new Size(40, 15);
            lblCostoEtiqueta.TabIndex = 7;
            lblCostoEtiqueta.Text = "Costo:";

            // 
            // lblCostoValor
            // 
            lblCostoValor.AutoSize = true;
            lblCostoValor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCostoValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblCostoValor.Location = new Point(310, 149);
            lblCostoValor.Name = "lblCostoValor";
            lblCostoValor.Size = new Size(43, 19);
            lblCostoValor.TabIndex = 8;
            lblCostoValor.Text = "$0.00";

            // 
            // lblPrecioEtiqueta
            // 
            lblPrecioEtiqueta.AutoSize = true;
            lblPrecioEtiqueta.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecioEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblPrecioEtiqueta.Location = new Point(380, 127);
            lblPrecioEtiqueta.Name = "lblPrecioEtiqueta";
            lblPrecioEtiqueta.Size = new Size(43, 15);
            lblPrecioEtiqueta.TabIndex = 9;
            lblPrecioEtiqueta.Text = "Precio:";

            // 
            // lblPrecioValor
            // 
            lblPrecioValor.AutoSize = true;
            lblPrecioValor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrecioValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblPrecioValor.Location = new Point(380, 149);
            lblPrecioValor.Name = "lblPrecioValor";
            lblPrecioValor.Size = new Size(43, 19);
            lblPrecioValor.TabIndex = 10;
            lblPrecioValor.Text = "$0.00";

            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnAgregarProducto.FlatAppearance.BorderSize = 0;
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregarProducto.ForeColor = Color.White;
            btnAgregarProducto.Location = new Point(460, 144);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(140, 28);
            btnAgregarProducto.TabIndex = 11;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;

            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnQuitarProducto.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnQuitarProducto.FlatStyle = FlatStyle.Flat;
            btnQuitarProducto.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnQuitarProducto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnQuitarProducto.Location = new Point(610, 144);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(165, 28);
            btnQuitarProducto.TabIndex = 12;
            btnQuitarProducto.Text = "Quitar Seleccionado";
            btnQuitarProducto.UseVisualStyleBackColor = false;
            btnQuitarProducto.Click += btnQuitarProducto_Click;

            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.BackgroundColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvDetalles.BorderStyle = BorderStyle.None;

            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dataGridViewCellStyle1.SelectionBackColor = ColorTranslator.FromHtml("#0f2a4f");
            dataGridViewCellStyle1.SelectionForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dataGridViewCellStyle2.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDetalles.DefaultCellStyle = dataGridViewCellStyle2;

            dgvDetalles.EnableHeadersVisualStyles = false;
            dgvDetalles.GridColor = ColorTranslator.FromHtml("#1f6feb");
            dgvDetalles.Location = new Point(25, 190);
            dgvDetalles.MultiSelect = false;
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(750, 230);
            dgvDetalles.TabIndex = 13;

            // 
            // lblTotalEtiqueta
            // 
            lblTotalEtiqueta.AutoSize = true;
            lblTotalEtiqueta.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalEtiqueta.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTotalEtiqueta.Location = new Point(25, 440);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(49, 21);
            lblTotalEtiqueta.TabIndex = 14;
            lblTotalEtiqueta.Text = "Total:";

            // 
            // lblTotalCalculado
            // 
            lblTotalCalculado.AutoSize = true;
            lblTotalCalculado.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalCalculado.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTotalCalculado.Location = new Point(80, 438);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(57, 25);
            lblTotalCalculado.TabIndex = 15;
            lblTotalCalculado.Text = "$0.00";

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(570, 437);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 32);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCancelar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCancelar.Location = new Point(680, 437);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(95, 32);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            // 
            // FrmCompraModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(800, 490);
            Controls.Add(cmbProductos);
            Controls.Add(lblProducto);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblTotalCalculado);
            Controls.Add(lblTotalEtiqueta);
            Controls.Add(dgvDetalles);
            Controls.Add(btnQuitarProducto);
            Controls.Add(btnAgregarProducto);
            Controls.Add(lblPrecioValor);
            Controls.Add(lblPrecioEtiqueta);
            Controls.Add(lblCostoValor);
            Controls.Add(lblCostoEtiqueta);
            Controls.Add(numCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(txtBuscarProducto);
            Controls.Add(lblBuscarProducto);
            Controls.Add(cmbFormaPago);
            Controls.Add(lblFormaPago);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCompraModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Compra";
            Load += FrmCompraModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblFormaPago;
        private ComboBox cmbFormaPago;
        private Label lblProducto;
        private ComboBox cmbProductos;
        private Label lblBuscarProducto;
        private TextBox txtBuscarProducto;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Label lblCostoEtiqueta;
        private Label lblCostoValor;
        private Label lblPrecioEtiqueta;
        private Label lblPrecioValor;
        private Button btnAgregarProducto;
        private Button btnQuitarProducto;
        private DataGridView dgvDetalles;
        private Label lblTotalEtiqueta;
        private Label lblTotalCalculado;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}