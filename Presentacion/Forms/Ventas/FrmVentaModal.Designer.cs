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
            panelHeader = new Panel();
            lblTitulo = new Label();
            panelEntrada = new Panel();
            lblCodigoBarras = new Label();
            txtCodigoBarras = new TextBox();
            lblProducto = new Label();
            cmbProductos = new ComboBox();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            btnAgregar = new BotonTema();
            lblAviso = new Label();
            dgvCarrito = new GridTema();
            panelPie = new Panel();
            btnQuitar = new BotonTema();
            lblTotalEtiqueta = new Label();
            lblTotalCalculado = new Label();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader.SuspendLayout();
            panelEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            panelPie.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(760, 67);
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
            // panelEntrada
            //
            panelEntrada.Controls.Add(lblCodigoBarras);
            panelEntrada.Controls.Add(txtCodigoBarras);
            panelEntrada.Controls.Add(lblProducto);
            panelEntrada.Controls.Add(cmbProductos);
            panelEntrada.Controls.Add(lblCantidad);
            panelEntrada.Controls.Add(numCantidad);
            panelEntrada.Controls.Add(btnAgregar);
            panelEntrada.Controls.Add(lblAviso);
            panelEntrada.Dock = DockStyle.Top;
            panelEntrada.Location = new Point(0, 67);
            panelEntrada.Name = "panelEntrada";
            panelEntrada.Size = new Size(760, 120);
            panelEntrada.TabIndex = 1;
            //
            // lblCodigoBarras
            //
            lblCodigoBarras.AutoSize = true;
            lblCodigoBarras.Font = new Font("Segoe UI", 9.5F);
            lblCodigoBarras.ForeColor = Color.FromArgb(230, 238, 252);
            lblCodigoBarras.Location = new Point(29, 12);
            lblCodigoBarras.Name = "lblCodigoBarras";
            lblCodigoBarras.Size = new Size(108, 21);
            lblCodigoBarras.TabIndex = 0;
            lblCodigoBarras.Text = "Código Barras:";
            //
            // txtCodigoBarras
            //
            txtCodigoBarras.BackColor = Color.FromArgb(15, 42, 79);
            txtCodigoBarras.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoBarras.Font = new Font("Segoe UI", 10F);
            txtCodigoBarras.ForeColor = Color.FromArgb(230, 238, 252);
            txtCodigoBarras.Location = new Point(29, 38);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(170, 30);
            txtCodigoBarras.TabIndex = 1;
            txtCodigoBarras.KeyDown += EntradaProducto_KeyDown;
            //
            // lblProducto
            //
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI", 9.5F);
            lblProducto.ForeColor = Color.FromArgb(230, 238, 252);
            lblProducto.Location = new Point(215, 12);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(76, 21);
            lblProducto.TabIndex = 2;
            lblProducto.Text = "Producto:";
            //
            // cmbProductos
            //
            cmbProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProductos.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProductos.BackColor = Color.FromArgb(15, 42, 79);
            cmbProductos.Font = new Font("Segoe UI", 10F);
            cmbProductos.ForeColor = Color.FromArgb(230, 238, 252);
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(215, 38);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(275, 31);
            cmbProductos.TabIndex = 3;
            cmbProductos.KeyDown += EntradaProducto_KeyDown;
            //
            // lblCantidad
            //
            lblCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9.5F);
            lblCantidad.ForeColor = Color.FromArgb(230, 238, 252);
            lblCantidad.Location = new Point(510, 12);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(75, 21);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "Cantidad:";
            //
            // numCantidad
            //
            numCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numCantidad.BackColor = Color.FromArgb(15, 42, 79);
            numCantidad.BorderStyle = BorderStyle.FixedSingle;
            numCantidad.Font = new Font("Segoe UI", 10F);
            numCantidad.ForeColor = Color.FromArgb(230, 238, 252);
            numCantidad.Location = new Point(510, 38);
            numCantidad.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(90, 30);
            numCantidad.TabIndex = 5;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.KeyDown += EntradaProducto_KeyDown;
            //
            // btnAgregar
            //
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Estilo = EstiloBoton.Primario;
            btnAgregar.Location = new Point(620, 35);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(111, 37);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "+ Agregar";
            btnAgregar.Click += btnAgregar_Click;
            //
            // lblAviso
            //
            lblAviso.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAviso.Font = new Font("Segoe UI", 9.5F);
            lblAviso.ForeColor = Color.FromArgb(248, 113, 113);
            lblAviso.Location = new Point(29, 84);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(702, 24);
            lblAviso.TabIndex = 7;
            lblAviso.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dgvCarrito
            //
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.Location = new Point(0, 187);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new Size(760, 383);
            dgvCarrito.TabIndex = 2;
            dgvCarrito.SelectionChanged += dgvCarrito_SelectionChanged;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(btnQuitar);
            panelPie.Controls.Add(lblTotalEtiqueta);
            panelPie.Controls.Add(lblTotalCalculado);
            panelPie.Controls.Add(btnGuardar);
            panelPie.Controls.Add(btnCancelar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 570);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(760, 130);
            panelPie.TabIndex = 3;
            //
            // btnQuitar
            //
            btnQuitar.Enabled = false;
            btnQuitar.Location = new Point(29, 15);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(126, 43);
            btnQuitar.TabIndex = 0;
            btnQuitar.Text = "Quitar ítem";
            btnQuitar.Click += btnQuitar_Click;
            //
            // lblTotalEtiqueta
            //
            lblTotalEtiqueta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalEtiqueta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotalEtiqueta.Location = new Point(400, 12);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(110, 40);
            lblTotalEtiqueta.TabIndex = 1;
            lblTotalEtiqueta.Text = "TOTAL:";
            lblTotalEtiqueta.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTotalCalculado
            //
            lblTotalCalculado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalCalculado.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalCalculado.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotalCalculado.Location = new Point(515, 12);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(216, 40);
            lblTotalCalculado.TabIndex = 2;
            lblTotalCalculado.Text = "$0.00";
            lblTotalCalculado.TextAlign = ContentAlignment.MiddleRight;
            //
            // btnGuardar
            //
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Enabled = false;
            btnGuardar.Estilo = EstiloBoton.Exito;
            btnGuardar.Location = new Point(390, 70);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 48);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Completar venta";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(605, 70);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(126, 48);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            //
            // FrmVentaModal
            //
            // Sin AcceptButton a propósito: Enter en el lector de códigos debe agregar el producto,
            // no completar la venta. Para completarla: botón o Ctrl+Enter.
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(760, 700);
            Controls.Add(dgvCarrito);
            Controls.Add(panelPie);
            Controls.Add(panelEntrada);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = false;
            MinimumSize = new Size(700, 600);
            Name = "FrmVentaModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Punto de Venta";
            Load += FrmVentaModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelEntrada.ResumeLayout(false);
            panelEntrada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            panelPie.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelEntrada;
        private Label lblCodigoBarras;
        private TextBox txtCodigoBarras;
        private Label lblProducto;
        private ComboBox cmbProductos;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private BotonTema btnAgregar;
        private Label lblAviso;
        private GridTema dgvCarrito;
        private Panel panelPie;
        private BotonTema btnQuitar;
        private Label lblTotalEtiqueta;
        private Label lblTotalCalculado;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}