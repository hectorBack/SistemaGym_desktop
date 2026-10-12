namespace Presentacion.Forms.Corte
{
    partial class FrmCorteDetalleModal
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
            tablaInfo = new TableLayoutPanel();
            lblUsuarioEtiqueta = new Label();
            lblUsuarioValor = new Label();
            lblEstadoEtiqueta = new Label();
            lblEstadoValor = new Label();
            lblFechaInicioEtiqueta = new Label();
            lblFechaInicioValor = new Label();
            lblFechaFinEtiqueta = new Label();
            lblFechaFinValor = new Label();
            lblObservacionEtiqueta = new Label();
            lblObservacionValor = new Label();
            tablaTotales = new TableLayoutPanel();
            lblEfectivoInicialEtiqueta = new Label();
            lblTotalIngresosEtiqueta = new Label();
            lblTotalEgresosEtiqueta = new Label();
            lblEfectivoFinalEtiqueta = new Label();
            lblEfectivoInicialValor = new Label();
            lblTotalIngresosValor = new Label();
            lblTotalEgresosValor = new Label();
            lblEfectivoFinalValor = new Label();
            dgvMovimientos = new GridTema();
            panelPie = new Panel();
            lblConteo = new Label();
            btnCerrar = new BotonTema();
            panelHeader.SuspendLayout();
            tablaInfo.SuspendLayout();
            tablaTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
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
            lblTitulo.Size = new Size(228, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle del Corte de Caja";
            //
            // tablaInfo
            //
            tablaInfo.AutoSize = true;
            tablaInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tablaInfo.BackColor = Color.FromArgb(14, 20, 36);
            tablaInfo.ColumnCount = 4;
            tablaInfo.ColumnStyles.Add(new ColumnStyle());
            tablaInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablaInfo.ColumnStyles.Add(new ColumnStyle());
            tablaInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablaInfo.Controls.Add(lblUsuarioEtiqueta, 0, 0);
            tablaInfo.Controls.Add(lblUsuarioValor, 1, 0);
            tablaInfo.Controls.Add(lblEstadoEtiqueta, 2, 0);
            tablaInfo.Controls.Add(lblEstadoValor, 3, 0);
            tablaInfo.Controls.Add(lblFechaInicioEtiqueta, 0, 1);
            tablaInfo.Controls.Add(lblFechaInicioValor, 1, 1);
            tablaInfo.Controls.Add(lblFechaFinEtiqueta, 2, 1);
            tablaInfo.Controls.Add(lblFechaFinValor, 3, 1);
            tablaInfo.Controls.Add(lblObservacionEtiqueta, 0, 2);
            tablaInfo.Controls.Add(lblObservacionValor, 1, 2);
            tablaInfo.SetColumnSpan(lblObservacionValor, 3);
            tablaInfo.Dock = DockStyle.Top;
            tablaInfo.Location = new Point(0, 67);
            tablaInfo.Name = "tablaInfo";
            tablaInfo.Padding = new Padding(18, 10, 18, 10);
            tablaInfo.RowCount = 3;
            tablaInfo.RowStyles.Add(new RowStyle());
            tablaInfo.RowStyles.Add(new RowStyle());
            tablaInfo.RowStyles.Add(new RowStyle());
            tablaInfo.Size = new Size(760, 120);
            tablaInfo.TabIndex = 1;
            //
            // lblUsuarioEtiqueta
            //
            lblUsuarioEtiqueta.AutoSize = true;
            lblUsuarioEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsuarioEtiqueta.ForeColor = Color.FromArgb(45, 212, 255);
            lblUsuarioEtiqueta.Margin = new Padding(0, 4, 12, 4);
            lblUsuarioEtiqueta.Name = "lblUsuarioEtiqueta";
            lblUsuarioEtiqueta.TabIndex = 0;
            lblUsuarioEtiqueta.Text = "Usuario:";
            //
            // lblUsuarioValor
            //
            lblUsuarioValor.AutoSize = true;
            lblUsuarioValor.Font = new Font("Segoe UI", 9.5F);
            lblUsuarioValor.ForeColor = Color.FromArgb(230, 238, 252);
            lblUsuarioValor.Margin = new Padding(0, 4, 12, 4);
            lblUsuarioValor.Name = "lblUsuarioValor";
            lblUsuarioValor.TabIndex = 1;
            lblUsuarioValor.Text = "N/A";
            //
            // lblEstadoEtiqueta
            //
            lblEstadoEtiqueta.AutoSize = true;
            lblEstadoEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEstadoEtiqueta.ForeColor = Color.FromArgb(45, 212, 255);
            lblEstadoEtiqueta.Margin = new Padding(0, 4, 12, 4);
            lblEstadoEtiqueta.Name = "lblEstadoEtiqueta";
            lblEstadoEtiqueta.TabIndex = 2;
            lblEstadoEtiqueta.Text = "Estado:";
            //
            // lblEstadoValor
            //
            lblEstadoValor.AutoSize = true;
            lblEstadoValor.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEstadoValor.ForeColor = Color.FromArgb(52, 211, 153);
            lblEstadoValor.Margin = new Padding(0, 4, 0, 4);
            lblEstadoValor.Name = "lblEstadoValor";
            lblEstadoValor.TabIndex = 3;
            lblEstadoValor.Text = "Cerrado";
            //
            // lblFechaInicioEtiqueta
            //
            lblFechaInicioEtiqueta.AutoSize = true;
            lblFechaInicioEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFechaInicioEtiqueta.ForeColor = Color.FromArgb(45, 212, 255);
            lblFechaInicioEtiqueta.Margin = new Padding(0, 4, 12, 4);
            lblFechaInicioEtiqueta.Name = "lblFechaInicioEtiqueta";
            lblFechaInicioEtiqueta.TabIndex = 4;
            lblFechaInicioEtiqueta.Text = "Fecha inicio:";
            //
            // lblFechaInicioValor
            //
            lblFechaInicioValor.AutoSize = true;
            lblFechaInicioValor.Font = new Font("Segoe UI", 9.5F);
            lblFechaInicioValor.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaInicioValor.Margin = new Padding(0, 4, 12, 4);
            lblFechaInicioValor.Name = "lblFechaInicioValor";
            lblFechaInicioValor.TabIndex = 5;
            lblFechaInicioValor.Text = "--/--/---- --:--";
            //
            // lblFechaFinEtiqueta
            //
            lblFechaFinEtiqueta.AutoSize = true;
            lblFechaFinEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFechaFinEtiqueta.ForeColor = Color.FromArgb(45, 212, 255);
            lblFechaFinEtiqueta.Margin = new Padding(0, 4, 12, 4);
            lblFechaFinEtiqueta.Name = "lblFechaFinEtiqueta";
            lblFechaFinEtiqueta.TabIndex = 6;
            lblFechaFinEtiqueta.Text = "Fecha fin:";
            //
            // lblFechaFinValor
            //
            lblFechaFinValor.AutoSize = true;
            lblFechaFinValor.Font = new Font("Segoe UI", 9.5F);
            lblFechaFinValor.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaFinValor.Margin = new Padding(0, 4, 0, 4);
            lblFechaFinValor.Name = "lblFechaFinValor";
            lblFechaFinValor.TabIndex = 7;
            lblFechaFinValor.Text = "--/--/---- --:--";
            //
            // lblObservacionEtiqueta
            //
            lblObservacionEtiqueta.AutoSize = true;
            lblObservacionEtiqueta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblObservacionEtiqueta.ForeColor = Color.FromArgb(45, 212, 255);
            lblObservacionEtiqueta.Margin = new Padding(0, 4, 12, 4);
            lblObservacionEtiqueta.Name = "lblObservacionEtiqueta";
            lblObservacionEtiqueta.TabIndex = 8;
            lblObservacionEtiqueta.Text = "Observación:";
            //
            // lblObservacionValor
            //
            lblObservacionValor.AutoSize = true;
            lblObservacionValor.Font = new Font("Segoe UI", 9.5F);
            lblObservacionValor.ForeColor = Color.FromArgb(230, 238, 252);
            lblObservacionValor.Margin = new Padding(0, 4, 0, 4);
            lblObservacionValor.MaximumSize = new Size(560, 0);
            lblObservacionValor.Name = "lblObservacionValor";
            lblObservacionValor.TabIndex = 9;
            lblObservacionValor.Text = "Sin observaciones";
            //
            // tablaTotales
            //
            tablaTotales.ColumnCount = 4;
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaTotales.Controls.Add(lblEfectivoInicialEtiqueta, 0, 0);
            tablaTotales.Controls.Add(lblTotalIngresosEtiqueta, 1, 0);
            tablaTotales.Controls.Add(lblTotalEgresosEtiqueta, 2, 0);
            tablaTotales.Controls.Add(lblEfectivoFinalEtiqueta, 3, 0);
            tablaTotales.Controls.Add(lblEfectivoInicialValor, 0, 1);
            tablaTotales.Controls.Add(lblTotalIngresosValor, 1, 1);
            tablaTotales.Controls.Add(lblTotalEgresosValor, 2, 1);
            tablaTotales.Controls.Add(lblEfectivoFinalValor, 3, 1);
            tablaTotales.Dock = DockStyle.Top;
            tablaTotales.Location = new Point(0, 187);
            tablaTotales.Name = "tablaTotales";
            tablaTotales.Padding = new Padding(12, 8, 12, 4);
            tablaTotales.RowCount = 2;
            tablaTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tablaTotales.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tablaTotales.Size = new Size(760, 76);
            tablaTotales.TabIndex = 2;
            //
            // lblEfectivoInicialEtiqueta
            //
            lblEfectivoInicialEtiqueta.Dock = DockStyle.Fill;
            lblEfectivoInicialEtiqueta.Font = new Font("Segoe UI", 9F);
            lblEfectivoInicialEtiqueta.ForeColor = Color.FromArgb(124, 138, 165);
            lblEfectivoInicialEtiqueta.Name = "lblEfectivoInicialEtiqueta";
            lblEfectivoInicialEtiqueta.TabIndex = 0;
            lblEfectivoInicialEtiqueta.Text = "Efectivo inicial";
            lblEfectivoInicialEtiqueta.TextAlign = ContentAlignment.BottomCenter;
            //
            // lblTotalIngresosEtiqueta
            //
            lblTotalIngresosEtiqueta.Dock = DockStyle.Fill;
            lblTotalIngresosEtiqueta.Font = new Font("Segoe UI", 9F);
            lblTotalIngresosEtiqueta.ForeColor = Color.FromArgb(124, 138, 165);
            lblTotalIngresosEtiqueta.Name = "lblTotalIngresosEtiqueta";
            lblTotalIngresosEtiqueta.TabIndex = 1;
            lblTotalIngresosEtiqueta.Text = "Total ingresos";
            lblTotalIngresosEtiqueta.TextAlign = ContentAlignment.BottomCenter;
            //
            // lblTotalEgresosEtiqueta
            //
            lblTotalEgresosEtiqueta.Dock = DockStyle.Fill;
            lblTotalEgresosEtiqueta.Font = new Font("Segoe UI", 9F);
            lblTotalEgresosEtiqueta.ForeColor = Color.FromArgb(124, 138, 165);
            lblTotalEgresosEtiqueta.Name = "lblTotalEgresosEtiqueta";
            lblTotalEgresosEtiqueta.TabIndex = 2;
            lblTotalEgresosEtiqueta.Text = "Total egresos";
            lblTotalEgresosEtiqueta.TextAlign = ContentAlignment.BottomCenter;
            //
            // lblEfectivoFinalEtiqueta
            //
            lblEfectivoFinalEtiqueta.Dock = DockStyle.Fill;
            lblEfectivoFinalEtiqueta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEfectivoFinalEtiqueta.ForeColor = Color.FromArgb(230, 238, 252);
            lblEfectivoFinalEtiqueta.Name = "lblEfectivoFinalEtiqueta";
            lblEfectivoFinalEtiqueta.TabIndex = 3;
            lblEfectivoFinalEtiqueta.Text = "EFECTIVO FINAL";
            lblEfectivoFinalEtiqueta.TextAlign = ContentAlignment.BottomCenter;
            //
            // lblEfectivoInicialValor
            //
            lblEfectivoInicialValor.Dock = DockStyle.Fill;
            lblEfectivoInicialValor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEfectivoInicialValor.ForeColor = Color.FromArgb(230, 238, 252);
            lblEfectivoInicialValor.Name = "lblEfectivoInicialValor";
            lblEfectivoInicialValor.TabIndex = 4;
            lblEfectivoInicialValor.Text = "$0.00";
            lblEfectivoInicialValor.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTotalIngresosValor
            //
            lblTotalIngresosValor.Dock = DockStyle.Fill;
            lblTotalIngresosValor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTotalIngresosValor.ForeColor = Color.FromArgb(52, 211, 153);
            lblTotalIngresosValor.Name = "lblTotalIngresosValor";
            lblTotalIngresosValor.TabIndex = 5;
            lblTotalIngresosValor.Text = "$0.00";
            lblTotalIngresosValor.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTotalEgresosValor
            //
            lblTotalEgresosValor.Dock = DockStyle.Fill;
            lblTotalEgresosValor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTotalEgresosValor.ForeColor = Color.FromArgb(248, 113, 113);
            lblTotalEgresosValor.Name = "lblTotalEgresosValor";
            lblTotalEgresosValor.TabIndex = 6;
            lblTotalEgresosValor.Text = "$0.00";
            lblTotalEgresosValor.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblEfectivoFinalValor
            //
            lblEfectivoFinalValor.Dock = DockStyle.Fill;
            lblEfectivoFinalValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblEfectivoFinalValor.ForeColor = Color.FromArgb(45, 212, 255);
            lblEfectivoFinalValor.Name = "lblEfectivoFinalValor";
            lblEfectivoFinalValor.TabIndex = 7;
            lblEfectivoFinalValor.Text = "$0.00";
            lblEfectivoFinalValor.TextAlign = ContentAlignment.MiddleCenter;
            //
            // dgvMovimientos
            //
            dgvMovimientos.Dock = DockStyle.Fill;
            dgvMovimientos.Location = new Point(0, 263);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(760, 227);
            dgvMovimientos.TabIndex = 3;
            dgvMovimientos.CellFormatting += dgvMovimientos_CellFormatting;
            //
            // panelPie
            //
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(lblConteo);
            panelPie.Controls.Add(btnCerrar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 490);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(760, 70);
            panelPie.TabIndex = 4;
            //
            // lblConteo
            //
            lblConteo.Dock = DockStyle.Left;
            lblConteo.Font = new Font("Segoe UI", 9.5F);
            lblConteo.ForeColor = Color.FromArgb(124, 138, 165);
            lblConteo.Name = "lblConteo";
            lblConteo.Padding = new Padding(29, 0, 0, 0);
            lblConteo.Size = new Size(300, 70);
            lblConteo.TabIndex = 1;
            lblConteo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // btnCerrar
            //
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Estilo = EstiloBoton.Primario;
            btnCerrar.Location = new Point(617, 14);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(114, 43);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            //
            // FrmCorteDetalleModal
            //
            AcceptButton = btnCerrar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCerrar;
            ClientSize = new Size(760, 560);
            Controls.Add(dgvMovimientos);
            Controls.Add(panelPie);
            Controls.Add(tablaTotales);
            Controls.Add(tablaInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = false;
            MinimumSize = new Size(680, 520);
            Name = "FrmCorteDetalleModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle del Corte";
            Load += FrmCorteDetalleModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tablaInfo.ResumeLayout(false);
            tablaInfo.PerformLayout();
            tablaTotales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            panelPie.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private TableLayoutPanel tablaInfo;
        private Label lblUsuarioEtiqueta;
        private Label lblUsuarioValor;
        private Label lblEstadoEtiqueta;
        private Label lblEstadoValor;
        private Label lblFechaInicioEtiqueta;
        private Label lblFechaInicioValor;
        private Label lblFechaFinEtiqueta;
        private Label lblFechaFinValor;
        private Label lblObservacionEtiqueta;
        private Label lblObservacionValor;
        private TableLayoutPanel tablaTotales;
        private Label lblEfectivoInicialEtiqueta;
        private Label lblTotalIngresosEtiqueta;
        private Label lblTotalEgresosEtiqueta;
        private Label lblEfectivoFinalEtiqueta;
        private Label lblEfectivoInicialValor;
        private Label lblTotalIngresosValor;
        private Label lblTotalEgresosValor;
        private Label lblEfectivoFinalValor;
        private GridTema dgvMovimientos;
        private Panel panelPie;
        private Label lblConteo;
        private BotonTema btnCerrar;
    }
}