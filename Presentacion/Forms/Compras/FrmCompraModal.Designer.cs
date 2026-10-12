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
            lblInfoProducto = new Label();
            dgvDetalles = new GridTema();
            panelPie = new Panel();
            lblFormaPago = new Label();
            cmbFormaPago = new ComboBox();
            btnQuitar = new BotonTema();
            lblTotalEtiqueta = new Label();
            lblTotalCalculado = new Label();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader.SuspendLayout();
            panelEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
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
            lblTitulo.Size = new Size(181, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nueva Compra";
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
            panelEntrada.Controls.Add(lblInfoProducto);
            panelEntrada.Dock = DockStyle.Top;
            panelEntrada.Location = new Point(0, 67);
            panelEntrada.Name = "panelEntrada";
            panelEntrada.Size = new Size(760, 130);
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
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
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
            lblAviso.Font = new Font("Segoe UI", 9F);
            lblAviso.ForeColor = Color.FromArgb(248, 113, 113);
            lblAviso.Location = new Point(29, 74);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(702, 20);
            lblAviso.TabIndex = 7;
            lblAviso.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoProducto
            // 
            lblInfoProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfoProducto.Font = new Font("Segoe UI", 9F);
            lblInfoProducto.ForeColor = Color.FromArgb(45, 212, 255);
            lblInfoProducto.Location = new Point(29, 98);
            lblInfoProducto.Name = "lblInfoProducto";
            lblInfoProducto.Size = new Size(702, 20);
            lblInfoProducto.TabIndex = 8;
            lblInfoProducto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvDetalles
            // 
            dgvDetalles.Dock = DockStyle.Fill;
            dgvDetalles.Location = new Point(0, 197);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(760, 373);
            dgvDetalles.TabIndex = 2;
            dgvDetalles.SelectionChanged += dgvDetalles_SelectionChanged;
            // 
            // panelPie
            // 
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(lblFormaPago);
            panelPie.Controls.Add(cmbFormaPago);
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
            // lblFormaPago
            // 
            lblFormaPago.AutoSize = true;
            lblFormaPago.Font = new Font("Segoe UI", 9.5F);
            lblFormaPago.ForeColor = Color.FromArgb(230, 238, 252);
            lblFormaPago.Location = new Point(29, 18);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(118, 21);
            lblFormaPago.TabIndex = 0;
            lblFormaPago.Text = "Forma de pago:";
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.BackColor = Color.FromArgb(15, 42, 79);
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPago.Font = new Font("Segoe UI", 10F);
            cmbFormaPago.ForeColor = Color.FromArgb(230, 238, 252);
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(29, 44);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(160, 31);
            cmbFormaPago.TabIndex = 1;
            // 
            // btnQuitar
            // 
            btnQuitar.Enabled = false;
            btnQuitar.Location = new Point(205, 43);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(115, 33);
            btnQuitar.TabIndex = 2;
            btnQuitar.Text = "Quitar ítem";
            btnQuitar.Click += btnQuitar_Click;
            // 
            // lblTotalEtiqueta
            // 
            lblTotalEtiqueta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalEtiqueta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotalEtiqueta.Location = new Point(360, 12);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(110, 40);
            lblTotalEtiqueta.TabIndex = 3;
            lblTotalEtiqueta.Text = "TOTAL:";
            lblTotalEtiqueta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalCalculado
            // 
            lblTotalCalculado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalCalculado.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalCalculado.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotalCalculado.Location = new Point(475, 12);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(256, 40);
            lblTotalCalculado.TabIndex = 4;
            lblTotalCalculado.Text = "$0.00";
            lblTotalCalculado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Enabled = false;
            btnGuardar.Estilo = EstiloBoton.Exito;
            btnGuardar.Location = new Point(430, 70);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(160, 42);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Completar compra";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(605, 70);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(126, 42);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            // 
            // FrmCompraModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(760, 700);
            Controls.Add(dgvDetalles);
            Controls.Add(panelPie);
            Controls.Add(panelEntrada);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = false;
            MinimumSize = new Size(700, 600);
            Name = "FrmCompraModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registro de Compra";
            Load += FrmCompraModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelEntrada.ResumeLayout(false);
            panelEntrada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            panelPie.ResumeLayout(false);
            panelPie.PerformLayout();
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
        private Label lblInfoProducto;
        private GridTema dgvDetalles;
        private Panel panelPie;
        private Label lblFormaPago;
        private ComboBox cmbFormaPago;
        private BotonTema btnQuitar;
        private Label lblTotalEtiqueta;
        private Label lblTotalCalculado;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}