namespace Presentacion.Forms.Productos
{
    partial class FrmProductoModal
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
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblCodigoBarras = new Label();
            txtCodigoBarras = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            numPrecio = new NumericUpDown();
            lblStock = new Label();
            numStock = new NumericUpDown();
            chkActivo = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(380, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(128, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Producto";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategoria.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblCategoria.Location = new Point(25, 65);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(68, 17);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.Flat;
            cmbCategoria.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            cmbCategoria.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(25, 85);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(330, 25);
            cmbCategoria.TabIndex = 2;
            // 
            // lblCodigoBarras
            // 
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblCodigoBarras.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblCodigoBarras.Location = new Point(25, 120);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(113, 17);
            lblCodigoBarras.TabIndex = 3;
            lblCodigoBarras.Text = "Código de Barras:";
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtCodigoBarras.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoBarras.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoBarras.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtCodigoBarras.Location = new Point(25, 140);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(330, 25);
            txtCodigoBarras.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblNombre.Location = new Point(25, 175);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(118, 17);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre Producto:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtNombre.Location = new Point(25, 195);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(330, 25);
            txtNombre.TabIndex = 6;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrecio.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblPrecio.Location = new Point(25, 230);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(47, 17);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio:";
            // 
            // numPrecio
            // 
            numPrecio.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            numPrecio.BorderStyle = BorderStyle.FixedSingle;
            numPrecio.DecimalPlaces = 2;
            numPrecio.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numPrecio.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            numPrecio.Location = new Point(25, 250);
            numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(155, 25);
            numPrecio.TabIndex = 8;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblStock.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblStock.Location = new Point(200, 230);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(42, 17);
            lblStock.TabIndex = 9;
            lblStock.Text = "Stock:";
            // 
            // numStock
            // 
            numStock.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            numStock.BorderStyle = BorderStyle.FixedSingle;
            numStock.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            numStock.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            numStock.Location = new Point(200, 250);
            numStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(155, 25);
            numStock.TabIndex = 10;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            chkActivo.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            chkActivo.Location = new Point(25, 290);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(62, 21);
            chkActivo.TabIndex = 11;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Location = new Point(165, 330);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCancelar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnCancelar.Location = new Point(265, 330);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmProductoModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(380, 385);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkActivo);
            Controls.Add(numStock);
            Controls.Add(lblStock);
            Controls.Add(numPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtCodigoBarras);
            Controls.Add(lblCodigoBarras);
            Controls.Add(cmbCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmProductoModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Producto";
            Load += FrmProductoModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblCodigoBarras;
        private TextBox txtCodigoBarras;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPrecio;
        private NumericUpDown numPrecio;
        private Label lblStock;
        private NumericUpDown numStock;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}