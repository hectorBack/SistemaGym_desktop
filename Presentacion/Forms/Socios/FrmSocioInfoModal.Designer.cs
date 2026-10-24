using Presentacion.Forms.Reportes;

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
            panelDatos = new Panel();
            picFotoSocio = new PictureBox();
            lblClaveTag = new Label();
            lblClave = new Label();
            lblNombreTag = new Label();
            lblNombreCompleto = new Label();
            lblTelefonoTag = new Label();
            lblTelefono = new Label();
            lblEmailTag = new Label();
            lblEmail = new Label();
            lblNacimientoTag = new Label();
            lblFechaNacimiento = new Label();
            lblEstadoTag = new Label();
            lblEstado = new Label();
            panelTabs = new Panel();
            tabControlDetalles = new FlatTabControl();
            tabMembresias = new TabPage();
            dgvHistorialMembresias = new GridTema();
            tabVisitas = new TabPage();
            dgvHistorialVisitas = new GridTema();
            panelFiltrosVisitas = new Panel();
            lblVisitaDesdeTag = new Label();
            dtpVisitaDesde = new DateTimePicker();
            lblVisitaHastaTag = new Label();
            dtpVisitaHasta = new DateTimePicker();
            btnFiltrarVisitas = new BotonTema();
            btnEliminarVisita = new BotonTema();
            panelPie = new Panel();
            btnCerrar = new BotonTema();
            panelHeader.SuspendLayout();
            panelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFotoSocio).BeginInit();
            panelTabs.SuspendLayout();
            tabControlDetalles.SuspendLayout();
            tabMembresias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialMembresias).BeginInit();
            tabVisitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialVisitas).BeginInit();
            panelFiltrosVisitas.SuspendLayout();
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
            panelHeader.Size = new Size(780, 67);
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(23, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(208, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Información del Socio";
            // 
            // panelDatos
            // 
            panelDatos.Controls.Add(picFotoSocio);
            panelDatos.Controls.Add(lblClaveTag);
            panelDatos.Controls.Add(lblClave);
            panelDatos.Controls.Add(lblNombreTag);
            panelDatos.Controls.Add(lblNombreCompleto);
            panelDatos.Controls.Add(lblTelefonoTag);
            panelDatos.Controls.Add(lblTelefono);
            panelDatos.Controls.Add(lblEmailTag);
            panelDatos.Controls.Add(lblEmail);
            panelDatos.Controls.Add(lblNacimientoTag);
            panelDatos.Controls.Add(lblFechaNacimiento);
            panelDatos.Controls.Add(lblEstadoTag);
            panelDatos.Controls.Add(lblEstado);
            panelDatos.Dock = DockStyle.Top;
            panelDatos.Location = new Point(0, 67);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(700, 205);
            panelDatos.TabIndex = 1;
            // 
            // picFotoSocio
            // 
            picFotoSocio.BackColor = Color.FromArgb(15, 42, 79);
            picFotoSocio.BorderStyle = BorderStyle.FixedSingle;
            picFotoSocio.Location = new Point(23, 15);
            picFotoSocio.Name = "picFotoSocio";
            picFotoSocio.Size = new Size(140, 140);
            picFotoSocio.SizeMode = PictureBoxSizeMode.Zoom;
            picFotoSocio.TabIndex = 0;
            picFotoSocio.TabStop = false;
            // 
            // lblClaveTag
            // 
            lblClaveTag.AutoSize = true;
            lblClaveTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblClaveTag.ForeColor = Color.FromArgb(45, 212, 255);
            lblClaveTag.Location = new Point(185, 12);
            lblClaveTag.Name = "lblClaveTag";
            lblClaveTag.Size = new Size(52, 21);
            lblClaveTag.TabIndex = 1;
            lblClaveTag.Text = "Clave:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 10F);
            lblClave.ForeColor = Color.FromArgb(230, 238, 252);
            lblClave.Location = new Point(295, 11);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(39, 23);
            lblClave.TabIndex = 2;
            lblClave.Text = "N/A";
            // 
            // lblNombreTag
            // 
            lblNombreTag.AutoSize = true;
            lblNombreTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNombreTag.ForeColor = Color.FromArgb(45, 212, 255);
            lblNombreTag.Location = new Point(185, 38);
            lblNombreTag.Name = "lblNombreTag";
            lblNombreTag.Size = new Size(75, 21);
            lblNombreTag.TabIndex = 3;
            lblNombreTag.Text = "Nombre:";
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font = new Font("Segoe UI", 10F);
            lblNombreCompleto.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombreCompleto.Location = new Point(295, 37);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(39, 23);
            lblNombreCompleto.TabIndex = 4;
            lblNombreCompleto.Text = "N/A";
            // 
            // lblTelefonoTag
            // 
            lblTelefonoTag.AutoSize = true;
            lblTelefonoTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTelefonoTag.ForeColor = Color.FromArgb(45, 212, 255);
            lblTelefonoTag.Location = new Point(185, 64);
            lblTelefonoTag.Name = "lblTelefonoTag";
            lblTelefonoTag.Size = new Size(77, 21);
            lblTelefonoTag.TabIndex = 5;
            lblTelefonoTag.Text = "Teléfono:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 10F);
            lblTelefono.ForeColor = Color.FromArgb(230, 238, 252);
            lblTelefono.Location = new Point(295, 63);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(39, 23);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "N/A";
            // 
            // lblEmailTag
            // 
            lblEmailTag.AutoSize = true;
            lblEmailTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEmailTag.ForeColor = Color.FromArgb(45, 212, 255);
            lblEmailTag.Location = new Point(185, 90);
            lblEmailTag.Name = "lblEmailTag";
            lblEmailTag.Size = new Size(52, 21);
            lblEmailTag.TabIndex = 7;
            lblEmailTag.Text = "Email:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.FromArgb(230, 238, 252);
            lblEmail.Location = new Point(295, 89);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "N/A";
            // 
            // lblNacimientoTag
            // 
            lblNacimientoTag.AutoSize = true;
            lblNacimientoTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNacimientoTag.ForeColor = Color.FromArgb(45, 212, 255);
            lblNacimientoTag.Location = new Point(185, 116);
            lblNacimientoTag.Name = "lblNacimientoTag";
            lblNacimientoTag.Size = new Size(100, 21);
            lblNacimientoTag.TabIndex = 9;
            lblNacimientoTag.Text = "Nacimiento:";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Font = new Font("Segoe UI", 10F);
            lblFechaNacimiento.ForeColor = Color.FromArgb(230, 238, 252);
            lblFechaNacimiento.Location = new Point(295, 115);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(39, 23);
            lblFechaNacimiento.TabIndex = 10;
            lblFechaNacimiento.Text = "N/A";
            // 
            // lblEstadoTag
            // 
            lblEstadoTag.AutoSize = true;
            lblEstadoTag.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEstadoTag.ForeColor = Color.FromArgb(45, 212, 255);
            lblEstadoTag.Location = new Point(185, 142);
            lblEstadoTag.Name = "lblEstadoTag";
            lblEstadoTag.Size = new Size(63, 21);
            lblEstadoTag.TabIndex = 11;
            lblEstadoTag.Text = "Estado:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(52, 211, 153);
            lblEstado.Location = new Point(295, 141);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(71, 23);
            lblEstado.TabIndex = 12;
            lblEstado.Text = "ACTIVO";
            // 
            // panelTabs
            // 
            panelTabs.Controls.Add(tabControlDetalles);
            panelTabs.Dock = DockStyle.Fill;
            panelTabs.Location = new Point(0, 272);
            panelTabs.Name = "panelTabs";
            panelTabs.Padding = new Padding(20, 0, 20, 10);
            panelTabs.Size = new Size(780, 328);
            panelTabs.TabIndex = 2;
            // 
            // tabControlDetalles
            // 
            tabControlDetalles.BackColor = Color.FromArgb(11, 15, 26);
            tabControlDetalles.Controls.Add(tabMembresias);
            tabControlDetalles.Controls.Add(tabVisitas);
            tabControlDetalles.Dock = DockStyle.Fill;
            tabControlDetalles.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlDetalles.Font = new Font("Segoe UI", 9.5F);
            tabControlDetalles.ItemSize = new Size(190, 32);
            tabControlDetalles.Location = new Point(20, 0);
            tabControlDetalles.Name = "tabControlDetalles";
            tabControlDetalles.SelectedIndex = 0;
            tabControlDetalles.Size = new Size(740, 318);
            tabControlDetalles.SizeMode = TabSizeMode.Fixed;
            tabControlDetalles.TabIndex = 0;
            tabControlDetalles.DrawItem += tabControlDetalles_DrawItem;
            // 
            // tabMembresias
            // 
            tabMembresias.BackColor = Color.FromArgb(11, 15, 26);
            tabMembresias.Controls.Add(dgvHistorialMembresias);
            tabMembresias.ForeColor = Color.FromArgb(230, 238, 252);
            tabMembresias.Location = new Point(4, 36);
            tabMembresias.Name = "tabMembresias";
            tabMembresias.Padding = new Padding(3);
            tabMembresias.Size = new Size(652, 258);
            tabMembresias.TabIndex = 0;
            tabMembresias.Text = "Historial de membresías";
            // 
            // dgvHistorialMembresias
            // 
            dgvHistorialMembresias.Dock = DockStyle.Fill;
            dgvHistorialMembresias.Location = new Point(3, 3);
            dgvHistorialMembresias.Name = "dgvHistorialMembresias";
            dgvHistorialMembresias.Size = new Size(646, 252);
            dgvHistorialMembresias.TabIndex = 0;
            // 
            // tabVisitas
            // 
            tabVisitas.BackColor = Color.FromArgb(11, 15, 26);
            tabVisitas.Controls.Add(dgvHistorialVisitas);
            tabVisitas.Controls.Add(panelFiltrosVisitas);
            tabVisitas.ForeColor = Color.FromArgb(230, 238, 252);
            tabVisitas.Location = new Point(4, 36);
            tabVisitas.Name = "tabVisitas";
            tabVisitas.Padding = new Padding(3);
            tabVisitas.Size = new Size(652, 258);
            tabVisitas.TabIndex = 1;
            tabVisitas.Text = "Historial de visitas";
            // 
            // panelFiltrosVisitas
            // 
            panelFiltrosVisitas.BackColor = Color.FromArgb(11, 15, 26);
            panelFiltrosVisitas.Controls.Add(lblVisitaDesdeTag);
            panelFiltrosVisitas.Controls.Add(dtpVisitaDesde);
            panelFiltrosVisitas.Controls.Add(lblVisitaHastaTag);
            panelFiltrosVisitas.Controls.Add(dtpVisitaHasta);
            panelFiltrosVisitas.Controls.Add(btnFiltrarVisitas);
            panelFiltrosVisitas.Controls.Add(btnEliminarVisita);
            panelFiltrosVisitas.Dock = DockStyle.Top;
            panelFiltrosVisitas.Location = new Point(3, 3);
            panelFiltrosVisitas.Name = "panelFiltrosVisitas";
            panelFiltrosVisitas.Size = new Size(646, 46);
            panelFiltrosVisitas.TabIndex = 0;
            // 
            // lblVisitaDesdeTag
            // 
            lblVisitaDesdeTag.AutoSize = true;
            lblVisitaDesdeTag.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblVisitaDesdeTag.ForeColor = Color.FromArgb(45, 212, 255);
            lblVisitaDesdeTag.Location = new Point(8, 13);
            lblVisitaDesdeTag.Name = "lblVisitaDesdeTag";
            lblVisitaDesdeTag.Size = new Size(54, 20);
            lblVisitaDesdeTag.TabIndex = 0;
            lblVisitaDesdeTag.Text = "Desde:";
            // 
            // dtpVisitaDesde
            // 
            dtpVisitaDesde.Format = DateTimePickerFormat.Short;
            dtpVisitaDesde.Location = new Point(68, 9);
            dtpVisitaDesde.Name = "dtpVisitaDesde";
            dtpVisitaDesde.Size = new Size(125, 27);
            dtpVisitaDesde.TabIndex = 1;
            // 
            // lblVisitaHastaTag
            // 
            lblVisitaHastaTag.AutoSize = true;
            lblVisitaHastaTag.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblVisitaHastaTag.ForeColor = Color.FromArgb(45, 212, 255);
            lblVisitaHastaTag.Location = new Point(208, 13);
            lblVisitaHastaTag.Name = "lblVisitaHastaTag";
            lblVisitaHastaTag.Size = new Size(50, 20);
            lblVisitaHastaTag.TabIndex = 2;
            lblVisitaHastaTag.Text = "Hasta:";
            // 
            // dtpVisitaHasta
            // 
            dtpVisitaHasta.Format = DateTimePickerFormat.Short;
            dtpVisitaHasta.Location = new Point(264, 9);
            dtpVisitaHasta.Name = "dtpVisitaHasta";
            dtpVisitaHasta.Size = new Size(125, 27);
            dtpVisitaHasta.TabIndex = 3;
            // 
            // btnFiltrarVisitas
            // 
            btnFiltrarVisitas.Estilo = EstiloBoton.Primario;
            btnFiltrarVisitas.Location = new Point(405, 7);
            btnFiltrarVisitas.Name = "btnFiltrarVisitas";
            btnFiltrarVisitas.Size = new Size(85, 32);
            btnFiltrarVisitas.TabIndex = 4;
            btnFiltrarVisitas.Text = "Buscar";
            btnFiltrarVisitas.Click += btnFiltrarVisitas_Click;
            // 
            // btnEliminarVisita
            // 
            btnEliminarVisita.Enabled = false;
            btnEliminarVisita.Estilo = EstiloBoton.Peligro;
            btnEliminarVisita.Location = new Point(498, 7);
            btnEliminarVisita.Name = "btnEliminarVisita";
            btnEliminarVisita.Size = new Size(85, 32);
            btnEliminarVisita.TabIndex = 5;
            btnEliminarVisita.Text = "Eliminar";
            btnEliminarVisita.Click += btnEliminarVisita_Click;
            // 
            // dgvHistorialVisitas
            // 
            dgvHistorialVisitas.Dock = DockStyle.Fill;
            dgvHistorialVisitas.Location = new Point(3, 49);
            dgvHistorialVisitas.Name = "dgvHistorialVisitas";
            dgvHistorialVisitas.Size = new Size(646, 206);
            dgvHistorialVisitas.TabIndex = 1;
            dgvHistorialVisitas.SelectionChanged += dgvHistorialVisitas_SelectionChanged;
            // 
            // panelPie
            // 
            panelPie.BackColor = Color.FromArgb(14, 20, 36);
            panelPie.Controls.Add(btnCerrar);
            panelPie.Dock = DockStyle.Bottom;
            panelPie.Location = new Point(0, 580);
            panelPie.Name = "panelPie";
            panelPie.Size = new Size(700, 60);
            panelPie.TabIndex = 3;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Estilo = EstiloBoton.Primario;
            btnCerrar.Location = new Point(577, 10);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(103, 40);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            // 
            // FrmSocioInfoModal
            // 
            AcceptButton = btnCerrar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCerrar;
            ClientSize = new Size(700, 640);
            Controls.Add(panelTabs);
            Controls.Add(panelPie);
            Controls.Add(panelDatos);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(680, 560);
            Name = "FrmSocioInfoModal";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Información del Socio";
            Load += FrmSocioInfoModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picFotoSocio).EndInit();
            panelTabs.ResumeLayout(false);
            tabControlDetalles.ResumeLayout(false);
            tabMembresias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorialMembresias).EndInit();
            tabVisitas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorialVisitas).EndInit();
            panelFiltrosVisitas.ResumeLayout(false);
            panelFiltrosVisitas.PerformLayout();
            panelPie.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelDatos;
        private PictureBox picFotoSocio;
        private Label lblClaveTag;
        private Label lblClave;
        private Label lblNombreTag;
        private Label lblNombreCompleto;
        private Label lblTelefonoTag;
        private Label lblTelefono;
        private Label lblEmailTag;
        private Label lblEmail;
        private Label lblNacimientoTag;
        private Label lblFechaNacimiento;
        private Label lblEstadoTag;
        private Label lblEstado;
        private Panel panelTabs;
        private FlatTabControl tabControlDetalles;
        private TabPage tabMembresias;
        private GridTema dgvHistorialMembresias;
        private TabPage tabVisitas;
        private GridTema dgvHistorialVisitas;
        private Panel panelFiltrosVisitas;
        private Label lblVisitaDesdeTag;
        private DateTimePicker dtpVisitaDesde;
        private Label lblVisitaHastaTag;
        private DateTimePicker dtpVisitaHasta;
        private BotonTema btnFiltrarVisitas;
        private BotonTema btnEliminarVisita;
        private Panel panelPie;
        private BotonTema btnCerrar;
    }
}