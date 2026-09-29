namespace Presentacion.Forms.Reportes
{
    partial class FrmReportes
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
            tabControlReportes = new FlatTabControl();

            tabInventario = new TabPage();
            tabMembresias = new TabPage();
            tabSocios = new TabPage();
            tabRegistro = new TabPage();
            tabVentas = new TabPage();
            tabVisitas = new TabPage();
            tabPagos = new TabPage();
            tabMovimientos = new TabPage();

            dgvInventario = new DataGridView();
            dgvMembresias = new DataGridView();
            dgvSocios = new DataGridView();
            dgvRegistro = new DataGridView();
            dgvVentas = new DataGridView();
            dgvVisitas = new DataGridView();
            dgvPagos = new DataGridView();
            dgvMovimientos = new DataGridView();

            panelTop.SuspendLayout();
            tabControlReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();

            // 
            // panelTop
            // 
            panelTop.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 60);
            panelTop.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Bold", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(240, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Módulo de Reportes";

            // 
            // tabControlReportes
            // 
            tabControlReportes.Dock = DockStyle.Fill;
            tabControlReportes.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            tabControlReportes.Location = new Point(0, 60);
            tabControlReportes.Name = "tabControlReportes";
            tabControlReportes.SelectedIndex = 0;
            tabControlReportes.Size = new Size(914, 740);
            tabControlReportes.TabIndex = 1;

            // CONFIGURACIÓN PARA DIBUJADO PERSONALIZADO DE PESTAÑAS
            tabControlReportes.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlReportes.ItemSize = new Size(110, 32);
            tabControlReportes.SizeMode = TabSizeMode.Fixed;
            tabControlReportes.DrawItem += tabControlReportes_DrawItem;
            tabControlReportes.SelectedIndexChanged += tabControlReportes_SelectedIndexChanged;

            // Configurar Pestañas y DataGridViews
            ConfigurarTabPage(tabInventario, "tabInventario", "Inventario", dgvInventario);
            ConfigurarTabPage(tabMembresias, "tabMembresias", "Membresías", dgvMembresias);
            ConfigurarTabPage(tabSocios, "tabSocios", "Socios", dgvSocios);
            ConfigurarTabPage(tabRegistro, "tabRegistro", "Registro", dgvRegistro);
            ConfigurarTabPage(tabVentas, "tabVentas", "Venta Productos", dgvVentas);
            ConfigurarTabPage(tabVisitas, "tabVisitas", "Visitas", dgvVisitas);
            ConfigurarTabPage(tabPagos, "tabPagos", "Pagos Membresías", dgvPagos);
            ConfigurarTabPage(tabMovimientos, "tabMovimientos", "Movimientos", dgvMovimientos);

            tabControlReportes.Controls.Add(tabInventario);
            tabControlReportes.Controls.Add(tabMembresias);
            tabControlReportes.Controls.Add(tabSocios);
            tabControlReportes.Controls.Add(tabRegistro);
            tabControlReportes.Controls.Add(tabVentas);
            tabControlReportes.Controls.Add(tabVisitas);
            tabControlReportes.Controls.Add(tabPagos);
            tabControlReportes.Controls.Add(tabMovimientos);

            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(914, 800);
            Controls.Add(tabControlReportes);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmReportes";
            Text = "Reportes";
            Load += FrmReportes_Load;

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tabControlReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistro).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private FlatTabControl tabControlReportes;

        private TabPage tabInventario;
        private TabPage tabMembresias;
        private TabPage tabSocios;
        private TabPage tabRegistro;
        private TabPage tabVentas;
        private TabPage tabVisitas;
        private TabPage tabPagos;
        private TabPage tabMovimientos;

        private DataGridView dgvInventario;
        private DataGridView dgvMembresias;
        private DataGridView dgvSocios;
        private DataGridView dgvRegistro;
        private DataGridView dgvVentas;
        private DataGridView dgvVisitas;
        private DataGridView dgvPagos;
        private DataGridView dgvMovimientos;
    

        private void ConfigurarTabPage(TabPage page, string name, string text, DataGridView dgv)
        {
            page.Name = name;
            page.Text = text;
            page.BackColor = ColorTranslator.FromHtml("#0b0f1a");

            // Configuración del DataGridView al estilo oscuro
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Líneas divisorias solo horizontales (más limpio)
            dgv.EnableHeadersVisualStyles = false;

            // Encabezados (Más altos y estilizados)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Bold", 10F, FontStyle.Bold); // Fuente un poco más grande
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 40; // Altura fija para el encabezado
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Margen interno (Padding) superior e inferior para dar "aire" a las celdas
            Padding margenCelda = new Padding(10, 6, 10, 6);
            dgv.ColumnHeadersDefaultCellStyle.Padding = margenCelda;
            dgv.DefaultCellStyle.Padding = margenCelda;

            // Filas (Texto en blanco puro para mejor contraste)
            dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgv.DefaultCellStyle.ForeColor = Color.White; // Blanco puro mejora la fatiga visual
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Altura de las filas de datos
            dgv.RowTemplate.Height = 38; // Hace que las filas se vean más modernas y táctiles/espaciosas

            dgv.ScrollBars = ScrollBars.Both;
            dgv.GridColor = ColorTranslator.FromHtml("#161b26"); // Gris muy sutil para no saturar de líneas la pantalla
            dgv.Dock = DockStyle.Fill;
            dgv.Margin = new Padding(3, 4, 3, 4);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // EVENTO CLAVE: Formatear y alinear columnas numéricas automáticamente al cargar datos
            dgv.DataBindingComplete += (sender, e) =>
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string colName = col.Name.ToLower();

                    // Detecta automáticamente columnas de dinero o cantidades
                    if (colName.Contains("precio") || colName.Contains("costo") || colName.Contains("total") || colName.Contains("subtotal") || colName.Contains("pago"))
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.DefaultCellStyle.Format = "C2"; // Formato de moneda local (ej. $25.00)
                    }
                    else if (colName.Contains("stock") || colName.Contains("cantidad") || colName.Contains("id"))
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            };

            page.Controls.Add(dgv);
        }
    }
}