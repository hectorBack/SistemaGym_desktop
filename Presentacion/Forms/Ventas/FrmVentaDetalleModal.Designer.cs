namespace Presentacion.Forms.Ventas
{
    partial class FrmVentaDetalleModal
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
            btnCerrar = new BotonTema();
            panelHeader.SuspendLayout();
            panelInfo.SuspendLayout();
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
            panelHeader.Size = new Size(663, 67);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(162, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle de Venta";
            //
            // panelInfo
            //
            panelInfo.BackColor = Color.FromArgb(14, 20, 36);
            panelInfo.Controls.Add(lblFechaEtiqueta);
            panelInfo.Controls.Add(lblFechaValor);
            panelInfo.Controls.Add(lblArticulos);
            panelInfo.Controls.Add(lblTotalEtiqueta);
            panelInfo.Controls.Add(lblTotalCalculado);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 67);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(663, 90);
            panelInfo.TabIndex = 1;
            //
            // lblFechaEtiqueta
            //
            lblFechaEtiqueta.AutoSize = true;
            lblFechaEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFechaEtiqueta.ForeColor = Color.FromArgb(45, 212, 255);
            lblFechaEtiqueta.Location = new Point(29, 18);
            lblFechaEtiqueta.Name = "lblFechaEtiqueta";
            lblFechaEtiqueta.Size = new Size(58, 21);
            lblFechaEtiqueta.TabIndex = 0;
            lblFechaEtiqueta.Text = "Fecha:";
            //
            // lblFechaValor
            //
            lblFechaValor.AutoSize = true;
            lblFechaValor.Font = new Font("Segoe UI", 9.5F);
            lblFechaValor.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaValor.Location = new Point(90, 18);
            lblFechaValor.Name = "lblFechaValor";
            lblFechaValor.Size = new Size(101, 21);
            lblFechaValor.TabIndex = 1;
            lblFechaValor.Text = "--/--/---- --:--";
            //
            // lblArticulos
            //
            lblArticulos.AutoSize = true;
            lblArticulos.Font = new Font("Segoe UI", 9.5F);
            lblArticulos.ForeColor = Color.FromArgb(124, 138, 165);
            lblArticulos.Location = new Point(29, 50);
            lblArticulos.Name = "lblArticulos";
            lblArticulos.Size = new Size(0, 21);
            lblArticulos.TabIndex = 2;
            //
            // lblTotalEtiqueta
            //
            lblTotalEtiqueta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalEtiqueta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblTotalEtiqueta.Location = new Point(300, 20);
            lblTotalEtiqueta.Name = "lblTotalEtiqueta";
            lblTotalEtiqueta.Size = new Size(110, 45);
            lblTotalEtiqueta.TabIndex = 3;
            lblTotalEtiqueta.Text = "TOTAL:";
            lblTotalEtiqueta.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTotalCalculado
            //
            lblTotalCalculado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalCalculado.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalCalculado.ForeColor = Color.FromArgb(45, 212, 255);
            lblTotalCalculado.Location = new Point(415, 20);
            lblTotalCalculado.Name = "lblTotalCalculado";
            lblTotalCalculado.Size = new Size(220, 45);
            lblTotalCalculado.TabIndex = 4;
            lblTotalCalculado.Text = "$0.00";
            lblTotalCalculado.TextAlign = ContentAlignment.MiddleRight;
            //
            // dgvDetalles
            //
            dgvDetalles.Dock = DockStyle.Fill;
            dgvDetalles.Location = new Point(0, 157);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(663, 346);
            dgvDetalles.TabIndex = 2;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(btnCerrar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 503);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(663, 70);
            panelPie.TabIndex = 3;
            //
            // btnCerrar
            //
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Estilo = EstiloBoton.Primario;
            btnCerrar.Location = new Point(521, 14);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(114, 43);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            //
            // FrmVentaDetalleModal
            //
            AcceptButton = btnCerrar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCerrar;
            ClientSize = new Size(663, 573);
            Controls.Add(dgvDetalles);
            Controls.Add(panelPie);
            Controls.Add(panelInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(560, 420);
            Name = "FrmVentaDetalleModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Venta";
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
        private BotonTema btnCerrar;
    }
}