namespace Presentacion.Forms.Socios
{
    partial class FrmSocioInfoModal
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
            picFotoSocio = new PictureBox();
            lblClaveTag = new Label();
            lblClave = new Label();
            lblNombreTag = new Label();
            lblNombreCompleto = new Label();
            lblTelefonoTag = new Label();
            lblTelefono = new Label();
            lblEmailTag = new Label();
            lblEmail = new Label();
            lblEstadoTag = new Label();
            lblEstado = new Label();
            tabControlDetalles = new TabControl();
            tabMembresias = new TabPage();
            dgvHistorialMembresias = new DataGridView();
            tabVisitas = new TabPage();
            panelFiltrosVisitas = new Panel();
            lblVisitaDesdeTag = new Label();
            dtpVisitaDesde = new DateTimePicker();
            lblVisitaHastaTag = new Label();
            dtpVisitaHasta = new DateTimePicker();
            btnFiltrarVisitas = new Button();
            btnEliminarVisita = new Button();
            dgvHistorialVisitas = new DataGridView();
            btnCerrar = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFotoSocio).BeginInit();
            tabControlDetalles.SuspendLayout();
            tabMembresias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialMembresias).BeginInit();
            tabVisitas.SuspendLayout();
            panelFiltrosVisitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialVisitas).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(680, 67);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(208, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Información del Socio";
            // 
            // picFotoSocio
            // 
            picFotoSocio.BorderStyle = BorderStyle.FixedSingle;
            picFotoSocio.Location = new Point(23, 85);
            picFotoSocio.Name = "picFotoSocio";
            picFotoSocio.Size = new Size(140, 140);
            picFotoSocio.SizeMode = PictureBoxSizeMode.Zoom;
            picFotoSocio.TabIndex = 1;
            picFotoSocio.TabStop = false;
            // 
            // lblClaveTag
            // 
            lblClaveTag.AutoSize = true;
            lblClaveTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblClaveTag.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblClaveTag.Location = new Point(180, 85);
            lblClaveTag.Name = "lblClaveTag";
            lblClaveTag.Size = new Size(52, 21);
            lblClaveTag.TabIndex = 2;
            lblClaveTag.Text = "Clave:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 10F);
            lblClave.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblClave.Location = new Point(290, 85);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(39, 23);
            lblClave.TabIndex = 3;
            lblClave.Text = "N/A";
            // 
            // lblNombreTag
            // 
            lblNombreTag.AutoSize = true;
            lblNombreTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreTag.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblNombreTag.Location = new Point(180, 115);
            lblNombreTag.Name = "lblNombreTag";
            lblNombreTag.Size = new Size(75, 21);
            lblNombreTag.TabIndex = 4;
            lblNombreTag.Text = "Nombre:";
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font = new Font("Segoe UI", 10F);
            lblNombreCompleto.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblNombreCompleto.Location = new Point(290, 115);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(39, 23);
            lblNombreCompleto.TabIndex = 5;
            lblNombreCompleto.Text = "N/A";
            // 
            // lblTelefonoTag
            // 
            lblTelefonoTag.AutoSize = true;
            lblTelefonoTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTelefonoTag.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblTelefonoTag.Location = new Point(180, 145);
            lblTelefonoTag.Name = "lblTelefonoTag";
            lblTelefonoTag.Size = new Size(77, 21);
            lblTelefonoTag.TabIndex = 6;
            lblTelefonoTag.Text = "Teléfono:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 10F);
            lblTelefono.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblTelefono.Location = new Point(290, 145);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(39, 23);
            lblTelefono.TabIndex = 7;
            lblTelefono.Text = "N/A";
            // 
            // lblEmailTag
            // 
            lblEmailTag.AutoSize = true;
            lblEmailTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEmailTag.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblEmailTag.Location = new Point(180, 175);
            lblEmailTag.Name = "lblEmailTag";
            lblEmailTag.Size = new Size(52, 21);
            lblEmailTag.TabIndex = 8;
            lblEmailTag.Text = "Email:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblEmail.Location = new Point(290, 175);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 23);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "N/A";
            // 
            // lblEstadoTag
            // 
            lblEstadoTag.AutoSize = true;
            lblEstadoTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEstadoTag.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblEstadoTag.Location = new Point(180, 204);
            lblEstadoTag.Name = "lblEstadoTag";
            lblEstadoTag.Size = new Size(63, 21);
            lblEstadoTag.TabIndex = 10;
            lblEstadoTag.Text = "Estado:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEstado.ForeColor = Color.Green;
            lblEstado.Location = new Point(290, 204);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(71, 23);
            lblEstado.TabIndex = 11;
            lblEstado.Text = "ACTIVO";
            // 
            // tabControlDetalles
            // 
            tabControlDetalles.Controls.Add(tabMembresias);
            tabControlDetalles.Controls.Add(tabVisitas);
            tabControlDetalles.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            tabControlDetalles.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlDetalles.Font = new Font("Segoe UI", 9.5F);
            tabControlDetalles.ItemSize = new Size(190, 32);
            tabControlDetalles.Location = new Point(23, 245);
            tabControlDetalles.Name = "tabControlDetalles";
            tabControlDetalles.SelectedIndex = 0;
            tabControlDetalles.SizeMode = TabSizeMode.Fixed;
            tabControlDetalles.Size = new Size(634, 280);
            tabControlDetalles.TabIndex = 12;
            tabControlDetalles.DrawItem += tabControlDetalles_DrawItem;
            // 
            // tabMembresias
            // 
            tabMembresias.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            tabMembresias.Controls.Add(dgvHistorialMembresias);
            tabMembresias.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            tabMembresias.Location = new Point(4, 36);
            tabMembresias.Name = "tabMembresias";
            tabMembresias.Padding = new Padding(3);
            tabMembresias.Size = new Size(626, 240);
            tabMembresias.TabIndex = 0;
            tabMembresias.Text = "Historial Membresías";
            // 
            // dgvHistorialMembresias
            // 
            dgvHistorialMembresias.AllowUserToAddRows = false;
            dgvHistorialMembresias.AllowUserToDeleteRows = false;
            dgvHistorialMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialMembresias.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvHistorialMembresias.BorderStyle = BorderStyle.None;
            dgvHistorialMembresias.EnableHeadersVisualStyles = false;
            dgvHistorialMembresias.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvHistorialMembresias.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvHistorialMembresias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvHistorialMembresias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistorialMembresias.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHistorialMembresias.ColumnHeadersHeight = 34;
            dgvHistorialMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistorialMembresias.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvHistorialMembresias.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvHistorialMembresias.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvHistorialMembresias.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvHistorialMembresias.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistorialMembresias.GridColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvHistorialMembresias.Dock = DockStyle.Fill;
            dgvHistorialMembresias.Location = new Point(3, 3);
            dgvHistorialMembresias.MultiSelect = false;
            dgvHistorialMembresias.Name = "dgvHistorialMembresias";
            dgvHistorialMembresias.ReadOnly = true;
            dgvHistorialMembresias.RowHeadersVisible = false;
            dgvHistorialMembresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialMembresias.Size = new Size(620, 234);
            dgvHistorialMembresias.TabIndex = 0;
            // 
            // tabVisitas
            // 
            tabVisitas.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            tabVisitas.Controls.Add(panelFiltrosVisitas);
            tabVisitas.Controls.Add(dgvHistorialVisitas);
            tabVisitas.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            tabVisitas.Location = new Point(4, 36);
            tabVisitas.Name = "tabVisitas";
            tabVisitas.Padding = new Padding(3);
            tabVisitas.Size = new Size(626, 240);
            tabVisitas.TabIndex = 1;
            tabVisitas.Text = "Historial Visitas";
            // 
            // panelFiltrosVisitas
            // 
            panelFiltrosVisitas.Controls.Add(btnFiltrarVisitas);
            panelFiltrosVisitas.Controls.Add(btnEliminarVisita);
            panelFiltrosVisitas.Controls.Add(dtpVisitaHasta);
            panelFiltrosVisitas.Controls.Add(lblVisitaHastaTag);
            panelFiltrosVisitas.Controls.Add(dtpVisitaDesde);
            panelFiltrosVisitas.Controls.Add(lblVisitaDesdeTag);
            panelFiltrosVisitas.Dock = DockStyle.Top;
            panelFiltrosVisitas.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            panelFiltrosVisitas.Location = new Point(3, 3);
            panelFiltrosVisitas.Name = "panelFiltrosVisitas";
            panelFiltrosVisitas.Size = new Size(620, 42);
            panelFiltrosVisitas.TabIndex = 0;
            // 
            // lblVisitaDesdeTag
            // 
            lblVisitaDesdeTag.AutoSize = true;
            lblVisitaDesdeTag.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblVisitaDesdeTag.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblVisitaDesdeTag.Location = new Point(8, 11);
            lblVisitaDesdeTag.Name = "lblVisitaDesdeTag";
            lblVisitaDesdeTag.Size = new Size(54, 20);
            lblVisitaDesdeTag.TabIndex = 0;
            lblVisitaDesdeTag.Text = "Desde:";
            // 
            // dtpVisitaDesde
            // 
            dtpVisitaDesde.Format = DateTimePickerFormat.Short;
            dtpVisitaDesde.Location = new Point(68, 7);
            dtpVisitaDesde.Name = "dtpVisitaDesde";
            dtpVisitaDesde.Size = new Size(125, 29);
            dtpVisitaDesde.TabIndex = 1;
            // 
            // lblVisitaHastaTag
            // 
            lblVisitaHastaTag.AutoSize = true;
            lblVisitaHastaTag.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblVisitaHastaTag.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            lblVisitaHastaTag.Location = new Point(208, 11);
            lblVisitaHastaTag.Name = "lblVisitaHastaTag";
            lblVisitaHastaTag.Size = new Size(50, 20);
            lblVisitaHastaTag.TabIndex = 2;
            lblVisitaHastaTag.Text = "Hasta:";
            // 
            // dtpVisitaHasta
            // 
            dtpVisitaHasta.Format = DateTimePickerFormat.Short;
            dtpVisitaHasta.Location = new Point(264, 7);
            dtpVisitaHasta.Name = "dtpVisitaHasta";
            dtpVisitaHasta.Size = new Size(125, 29);
            dtpVisitaHasta.TabIndex = 3;
            // 
            // btnFiltrarVisitas
            // 
            btnFiltrarVisitas.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnFiltrarVisitas.FlatAppearance.BorderSize = 0;
            btnFiltrarVisitas.FlatStyle = FlatStyle.Flat;
            btnFiltrarVisitas.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnFiltrarVisitas.ForeColor = Color.White;
            btnFiltrarVisitas.Location = new Point(405, 6);
            btnFiltrarVisitas.Name = "btnFiltrarVisitas";
            btnFiltrarVisitas.Size = new Size(85, 30);
            btnFiltrarVisitas.TabIndex = 4;
            btnFiltrarVisitas.Text = "Buscar";
            btnFiltrarVisitas.UseVisualStyleBackColor = false;
            btnFiltrarVisitas.Click += btnFiltrarVisitas_Click;
            // 
            // btnEliminarVisita
            // 
            btnEliminarVisita.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            btnEliminarVisita.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnEliminarVisita.FlatStyle = FlatStyle.Flat;
            btnEliminarVisita.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnEliminarVisita.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnEliminarVisita.Location = new Point(495, 6);
            btnEliminarVisita.Name = "btnEliminarVisita";
            btnEliminarVisita.Size = new Size(85, 30);
            btnEliminarVisita.TabIndex = 5;
            btnEliminarVisita.Text = "Eliminar";
            btnEliminarVisita.UseVisualStyleBackColor = false;
            btnEliminarVisita.Click += btnEliminarVisita_Click;
            // 
            // dgvHistorialVisitas
            // 
            dgvHistorialVisitas.AllowUserToAddRows = false;
            dgvHistorialVisitas.AllowUserToDeleteRows = false;
            dgvHistorialVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialVisitas.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvHistorialVisitas.BorderStyle = BorderStyle.None;
            dgvHistorialVisitas.EnableHeadersVisualStyles = false;
            dgvHistorialVisitas.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvHistorialVisitas.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgvHistorialVisitas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvHistorialVisitas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistorialVisitas.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHistorialVisitas.ColumnHeadersHeight = 34;
            dgvHistorialVisitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistorialVisitas.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgvHistorialVisitas.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgvHistorialVisitas.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgvHistorialVisitas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvHistorialVisitas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistorialVisitas.GridColor = ColorTranslator.FromHtml("#0f2a4f");
            dgvHistorialVisitas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistorialVisitas.Dock = DockStyle.None;
            dgvHistorialVisitas.Location = new Point(3, 45);
            dgvHistorialVisitas.MultiSelect = false;
            dgvHistorialVisitas.Name = "dgvHistorialVisitas";
            dgvHistorialVisitas.ReadOnly = true;
            dgvHistorialVisitas.RowHeadersVisible = false;
            dgvHistorialVisitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialVisitas.Size = new Size(620, 192);
            dgvHistorialVisitas.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(554, 540);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(103, 43);
            btnCerrar.TabIndex = 13;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmSocioInfoModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(680, 600);
            Controls.Add(btnCerrar);
            Controls.Add(tabControlDetalles);
            Controls.Add(lblEstado);
            Controls.Add(lblEstadoTag);
            Controls.Add(lblEmail);
            Controls.Add(lblEmailTag);
            Controls.Add(lblTelefono);
            Controls.Add(lblTelefonoTag);
            Controls.Add(lblNombreCompleto);
            Controls.Add(lblNombreTag);
            Controls.Add(lblClave);
            Controls.Add(lblClaveTag);
            Controls.Add(picFotoSocio);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSocioInfoModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Información del Socio";
            Load += FrmSocioInfoModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picFotoSocio).EndInit();
            tabControlDetalles.ResumeLayout(false);
            tabMembresias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorialMembresias).EndInit();
            tabVisitas.ResumeLayout(false);
            panelFiltrosVisitas.ResumeLayout(false);
            panelFiltrosVisitas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialVisitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private PictureBox picFotoSocio;
        private Label lblClaveTag;
        private Label lblClave;
        private Label lblNombreTag;
        private Label lblNombreCompleto;
        private Label lblTelefonoTag;
        private Label lblTelefono;
        private Label lblEmailTag;
        private Label lblEmail;
        private Label lblEstadoTag;
        private Label lblEstado;
        private TabControl tabControlDetalles;
        private TabPage tabMembresias;
        private DataGridView dgvHistorialMembresias;
        private TabPage tabVisitas;
        private Panel panelFiltrosVisitas;
        private Label lblVisitaDesdeTag;
        private DateTimePicker dtpVisitaDesde;
        private Label lblVisitaHastaTag;
        private DateTimePicker dtpVisitaHasta;
        private Button btnFiltrarVisitas;
        private Button btnEliminarVisita;
        private DataGridView dgvHistorialVisitas;
        private Button btnCerrar;
    }
}