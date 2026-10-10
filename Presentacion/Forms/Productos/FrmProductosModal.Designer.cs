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
            lblCosto = new Label();
            numCosto = new NumericUpDown();
            lblPrecio = new Label();
            numPrecio = new NumericUpDown();
            chkActivo = new CheckBox();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCosto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
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
            panelHeader.Size = new Size(434, 67);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(161, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Producto";
            //
            // lblCategoria
            //
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9.5F);
            lblCategoria.ForeColor = Color.FromArgb(230, 238, 252);
            lblCategoria.Location = new Point(29, 87);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(80, 21);
            lblCategoria.TabIndex = 20;
            lblCategoria.Text = "Categoría:";
            //
            // cmbCategoria
            //
            cmbCategoria.BackColor = Color.FromArgb(15, 42, 79);
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.Flat;
            cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            cmbCategoria.ForeColor = Color.FromArgb(230, 238, 252);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(29, 113);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(377, 29);
            cmbCategoria.TabIndex = 1;
            //
            // lblCodigoBarras
            //
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.Font = new Font("Segoe UI", 9.5F);
            lblCodigoBarras.ForeColor = Color.FromArgb(230, 238, 252);
            lblCodigoBarras.Location = new Point(29, 160);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(132, 21);
            lblCodigoBarras.TabIndex = 21;
            lblCodigoBarras.Text = "Código de Barras:";
            //
            // txtCodigoBarras
            //
            txtCodigoBarras.BackColor = Color.FromArgb(15, 42, 79);
            txtCodigoBarras.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoBarras.Font = new Font("Segoe UI", 10F);
            txtCodigoBarras.ForeColor = Color.FromArgb(230, 238, 252);
            txtCodigoBarras.Location = new Point(29, 187);
            txtCodigoBarras.Margin = new Padding(3, 4, 3, 4);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(377, 30);
            txtCodigoBarras.TabIndex = 2;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F);
            lblNombre.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombre.Location = new Point(29, 233);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(138, 21);
            lblNombre.TabIndex = 22;
            lblNombre.Text = "Nombre Producto:";
            //
            // txtNombre
            //
            txtNombre.BackColor = Color.FromArgb(15, 42, 79);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.ForeColor = Color.FromArgb(230, 238, 252);
            txtNombre.Location = new Point(29, 260);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(377, 30);
            txtNombre.TabIndex = 3;
            //
            // lblCosto
            //
            lblCosto.AutoSize = true;
            lblCosto.Font = new Font("Segoe UI", 9.5F);
            lblCosto.ForeColor = Color.FromArgb(230, 238, 252);
            lblCosto.Location = new Point(29, 307);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(53, 21);
            lblCosto.TabIndex = 23;
            lblCosto.Text = "Costo:";
            //
            // numCosto
            //
            numCosto.BackColor = Color.FromArgb(15, 42, 79);
            numCosto.BorderStyle = BorderStyle.FixedSingle;
            numCosto.DecimalPlaces = 2;
            numCosto.Font = new Font("Segoe UI", 10F);
            numCosto.ForeColor = Color.FromArgb(230, 238, 252);
            numCosto.Location = new Point(29, 333);
            numCosto.Margin = new Padding(3, 4, 3, 4);
            numCosto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numCosto.Name = "numCosto";
            numCosto.Size = new Size(177, 30);
            numCosto.TabIndex = 4;
            //
            // lblPrecio
            //
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 9.5F);
            lblPrecio.ForeColor = Color.FromArgb(230, 238, 252);
            lblPrecio.Location = new Point(229, 307);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 21);
            lblPrecio.TabIndex = 24;
            lblPrecio.Text = "Precio:";
            //
            // numPrecio
            //
            numPrecio.BackColor = Color.FromArgb(15, 42, 79);
            numPrecio.BorderStyle = BorderStyle.FixedSingle;
            numPrecio.DecimalPlaces = 2;
            numPrecio.Font = new Font("Segoe UI", 10F);
            numPrecio.ForeColor = Color.FromArgb(230, 238, 252);
            numPrecio.Location = new Point(229, 333);
            numPrecio.Margin = new Padding(3, 4, 3, 4);
            numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(177, 30);
            numPrecio.TabIndex = 5;
            //
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F);
            chkActivo.ForeColor = Color.FromArgb(230, 238, 252);
            chkActivo.Location = new Point(29, 385);
            chkActivo.Margin = new Padding(3, 4, 3, 4);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(75, 25);
            chkActivo.TabIndex = 6;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            //
            // btnGuardar
            //
            btnGuardar.Estilo = EstiloBoton.Primario;
            btnGuardar.Location = new Point(189, 435);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 43);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(303, 435);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(103, 43);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            //
            // FrmProductoModal
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(434, 510);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkActivo);
            Controls.Add(numPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(numCosto);
            Controls.Add(lblCosto);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtCodigoBarras);
            Controls.Add(lblCodigoBarras);
            Controls.Add(cmbCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmProductoModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Producto";
            Load += FrmProductoModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCosto).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
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
        private Label lblCosto;
        private NumericUpDown numCosto;
        private Label lblPrecio;
        private NumericUpDown numPrecio;
        private CheckBox chkActivo;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}