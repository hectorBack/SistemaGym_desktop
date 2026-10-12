namespace Presentacion.Forms.Compras
{
    partial class FrmCompraDetalleModal
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
            panelInfo = new Panel();
            lblFechaEtiqueta = new Label();
            lblFechaValor = new Label();
            lblArticulos = new Label();
            lblTotalEtiqueta = new Label();
            lblTotalCalculado = new Label();
            dgvDetalles = new GridTema();
            panelPie = new Panel();
            btnCerrar = new Button();

            panelHeader.SuspendLayout();
            panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            panelPie.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(663, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle de la Compra";
            // 
            // panelInfo
            // 
            panelInfo.BackColor = ColorTranslator.FromHtml("#0e1424");
            panelInfo.Controls.Add(lblFechaEtiqueta);
            panelInfo.Controls.Add(lblFechaValor);
            panelInfo.Controls.Add(lblArticulos);
            panelInfo.Controls.Add(lblTotalEtiqueta);
            panelInfo.Controls.Add(lblTotalCalculado);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 67);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(663, 75);
            panelInfo.TabIndex = 1;
            // 
            // lblFechaEtiqueta
            // 
            lblFechaEtiqueta.AutoSize = true;
            lblFechaEtiqueta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblFechaEtiqueta.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblFechaEtiqueta.Location = new Point(25, 12);
            lblFechaEtiqueta.Name = "lblFechaEtiqueta";
            lblFechaEtiqueta.Size = new Size(58, 21);
            lblFechaEtiqueta.TabIndex = 0;
            lblFechaEtiqueta.Text = "Fecha:";
            // 
            // lblFechaValor
            // 
            lblFechaValor.AutoSize = true;
            lblFechaValor.Font = new Font("Segoe UI", 9.5F);
            lblFechaValor.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblFechaValor.Location = new Point(85, 12);
            lblFechaValor.Name = "lblFechaValor";
            lblFechaValor.Size = new Size(120, 21);
            lblFechaValor.TabIndex = 1;
            lblFechaValor.Text = "--/--/---- --:--";
            // 
            // lblArticulos
            // 
            lblArticulos.AutoSize = true;
            lblArticulos.Font = new Font("Segoe UI", 9F);
            lblArticulos.ForeColor = ColorTranslator.FromHtml("#7c8aa5");
            lblArticulos.Location = new Point(25, 42);
            lblArticulos.Name = "lblArticulos";
            lblArticulos.Size = new Size(120, 20);
            lblArticulos.TabIndex = 2;
            lblArticulos.Text = "0 artículo(s)";
            // 
            // lblTotalEtiqueta
            // 
            lblTotalEtiqueta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalEtiqueta.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalEtiqueta.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTotalEtiqueta.Location = new Point(390, 18);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(80, 35);
            lblTotalEtiqueta.TabIndex = 3;
            lblTotalEtiqueta.Text = "TOTAL:";
            lblTotalEtiqueta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalCalculado
            // 
            lblTotalCalculado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalCalculado.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalCalculado.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTotalCalculado.Location = new Point(475, 18);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(160, 35);
            lblTotalCalculado.TabIndex = 4;
            lblTotalCalculado.Text = "$0.00";
            lblTotalCalculado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvDetalles
            // 
            dgvDetalles.Dock = DockStyle.Fill;
            dgvDetalles.Location = new Point(0, 142);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(663, 336);
            dgvDetalles.TabIndex = 2;
            // 
            // panelPie
            // 
            panelPie.BackColor = ColorTranslator.FromHtml("#0e1424");
            panelPie.Controls.Add(btnCerrar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 478);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(663, 70);
            panelPie.TabIndex = 3;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9.5F);
            btnCerrar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCerrar.Location = new Point(521, 14);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(114, 40);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // FrmCompraDetalleModal
            // 
            AcceptButton = btnCerrar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            CancelButton = btnCerrar;
            ClientSize = new Size(663, 548);
            Controls.Add(dgvDetalles);
            Controls.Add(panelPie);
            Controls.Add(panelInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(560, 420);
            Name = "FrmCompraDetalleModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Compra";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            panelPie.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelInfo;
        private Label lblFechaEtiqueta;
        private Label lblFechaValor;
        private Label lblArticulos;
        private Label lblTotalEtiqueta;
        private Label lblTotalCalculado;
        private GridTema dgvDetalles;
        private Panel panelPie;
        private Button btnCerrar;
    }
}