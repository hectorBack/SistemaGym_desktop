namespace Presentacion.Forms
{
    partial class FrmPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelSideMenu = new Panel();
            btnConfiguracion = new FontAwesome.Sharp.IconButton();
            btnCorte = new FontAwesome.Sharp.IconButton();
            btnReportes = new FontAwesome.Sharp.IconButton();
            btnCompras = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new FontAwesome.Sharp.IconButton();
            btnRoles = new FontAwesome.Sharp.IconButton();
            btnMovimientos = new FontAwesome.Sharp.IconButton();
            btnConceptos = new FontAwesome.Sharp.IconButton();
            btnRegistrarVisita = new FontAwesome.Sharp.IconButton();
            btnSocios = new FontAwesome.Sharp.IconButton();
            btnMembresias = new FontAwesome.Sharp.IconButton();
            btnVentas = new FontAwesome.Sharp.IconButton();
            btnCategorias = new FontAwesome.Sharp.IconButton();
            btnProductos = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            lblLogo = new Label();
            panelSuperior = new Panel();
            btnUsuarioMenu = new FontAwesome.Sharp.IconButton();
            menuUsuario = new ContextMenuStrip(components);
            itemIniciarSesion = new ToolStripMenuItem();
            itemCerrarSesion = new ToolStripMenuItem();
            panelContenedor = new Panel();
            panelSideMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelSuperior.SuspendLayout();
            menuUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = Color.FromArgb(15, 42, 79);
            panelSideMenu.Controls.Add(btnConfiguracion);
            panelSideMenu.Controls.Add(btnCorte);
            panelSideMenu.Controls.Add(btnReportes);
            panelSideMenu.Controls.Add(btnCompras);
            panelSideMenu.Controls.Add(btnUsuarios);
            panelSideMenu.Controls.Add(btnRoles);
            panelSideMenu.Controls.Add(btnMovimientos);
            panelSideMenu.Controls.Add(btnConceptos);
            panelSideMenu.Controls.Add(btnRegistrarVisita);
            panelSideMenu.Controls.Add(btnSocios);
            panelSideMenu.Controls.Add(btnMembresias);
            panelSideMenu.Controls.Add(btnVentas);
            panelSideMenu.Controls.Add(btnCategorias);
            panelSideMenu.Controls.Add(btnProductos);
            panelSideMenu.Controls.Add(panelLogo);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Margin = new Padding(3, 4, 3, 4);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(229, 1055);
            panelSideMenu.TabIndex = 0;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.Dock = DockStyle.Top;
            btnConfiguracion.FlatAppearance.BorderSize = 0;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfiguracion.ForeColor = Color.FromArgb(230, 238, 252);
            btnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.None;
            btnConfiguracion.IconColor = Color.Black;
            btnConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnConfiguracion.Location = new Point(0, 971);
            btnConfiguracion.Margin = new Padding(3, 4, 3, 4);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Padding = new Padding(11, 0, 0, 0);
            btnConfiguracion.Size = new Size(229, 67);
            btnConfiguracion.TabIndex = 15;
            btnConfiguracion.Text = "Configuracion";
            btnConfiguracion.TextAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.UseVisualStyleBackColor = true;
            btnConfiguracion.Click += btnConfiguracion_Click;
            // 
            // btnCorte
            // 
            btnCorte.Dock = DockStyle.Top;
            btnCorte.FlatAppearance.BorderSize = 0;
            btnCorte.FlatStyle = FlatStyle.Flat;
            btnCorte.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCorte.ForeColor = Color.FromArgb(230, 238, 252);
            btnCorte.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCorte.IconColor = Color.Black;
            btnCorte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCorte.Location = new Point(0, 904);
            btnCorte.Margin = new Padding(3, 4, 3, 4);
            btnCorte.Name = "btnCorte";
            btnCorte.Padding = new Padding(11, 0, 0, 0);
            btnCorte.Size = new Size(229, 67);
            btnCorte.TabIndex = 14;
            btnCorte.Text = "Corte";
            btnCorte.TextAlign = ContentAlignment.MiddleLeft;
            btnCorte.UseVisualStyleBackColor = true;
            btnCorte.Click += btnCorte_Click;
            // 
            // btnReportes
            // 
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReportes.ForeColor = Color.FromArgb(230, 238, 252);
            btnReportes.IconChar = FontAwesome.Sharp.IconChar.None;
            btnReportes.IconColor = Color.Black;
            btnReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReportes.Location = new Point(0, 837);
            btnReportes.Margin = new Padding(3, 4, 3, 4);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(11, 0, 0, 0);
            btnReportes.Size = new Size(229, 67);
            btnReportes.TabIndex = 13;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnCompras
            // 
            btnCompras.Dock = DockStyle.Top;
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCompras.ForeColor = Color.FromArgb(230, 238, 252);
            btnCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCompras.IconColor = Color.Black;
            btnCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras.Location = new Point(0, 770);
            btnCompras.Margin = new Padding(3, 4, 3, 4);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(11, 0, 0, 0);
            btnCompras.Size = new Size(229, 67);
            btnCompras.TabIndex = 12;
            btnCompras.Text = "Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.UseVisualStyleBackColor = true;
            btnCompras.Click += btnCompras_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUsuarios.ForeColor = Color.FromArgb(230, 238, 252);
            btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.None;
            btnUsuarios.IconColor = Color.Black;
            btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarios.Location = new Point(0, 703);
            btnUsuarios.Margin = new Padding(3, 4, 3, 4);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(11, 0, 0, 0);
            btnUsuarios.Size = new Size(229, 67);
            btnUsuarios.TabIndex = 11;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnRoles
            // 
            btnRoles.Dock = DockStyle.Top;
            btnRoles.FlatAppearance.BorderSize = 0;
            btnRoles.FlatStyle = FlatStyle.Flat;
            btnRoles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRoles.ForeColor = Color.FromArgb(230, 238, 252);
            btnRoles.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRoles.IconColor = Color.Black;
            btnRoles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRoles.Location = new Point(0, 636);
            btnRoles.Margin = new Padding(3, 4, 3, 4);
            btnRoles.Name = "btnRoles";
            btnRoles.Padding = new Padding(11, 0, 0, 0);
            btnRoles.Size = new Size(229, 67);
            btnRoles.TabIndex = 10;
            btnRoles.Text = "Roles";
            btnRoles.TextAlign = ContentAlignment.MiddleLeft;
            btnRoles.UseVisualStyleBackColor = true;
            btnRoles.Click += btnRoles_Click;
            // 
            // btnMovimientos
            // 
            btnMovimientos.Dock = DockStyle.Top;
            btnMovimientos.FlatAppearance.BorderSize = 0;
            btnMovimientos.FlatStyle = FlatStyle.Flat;
            btnMovimientos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMovimientos.ForeColor = Color.FromArgb(230, 238, 252);
            btnMovimientos.IconChar = FontAwesome.Sharp.IconChar.None;
            btnMovimientos.IconColor = Color.Black;
            btnMovimientos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMovimientos.Location = new Point(0, 569);
            btnMovimientos.Margin = new Padding(3, 4, 3, 4);
            btnMovimientos.Name = "btnMovimientos";
            btnMovimientos.Padding = new Padding(11, 0, 0, 0);
            btnMovimientos.Size = new Size(229, 67);
            btnMovimientos.TabIndex = 9;
            btnMovimientos.Text = "Movimientos";
            btnMovimientos.TextAlign = ContentAlignment.MiddleLeft;
            btnMovimientos.UseVisualStyleBackColor = true;
            btnMovimientos.Click += btnMovimientos_Click;
            // 
            // btnConceptos
            // 
            btnConceptos.Dock = DockStyle.Top;
            btnConceptos.FlatAppearance.BorderSize = 0;
            btnConceptos.FlatStyle = FlatStyle.Flat;
            btnConceptos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConceptos.ForeColor = Color.FromArgb(230, 238, 252);
            btnConceptos.IconChar = FontAwesome.Sharp.IconChar.None;
            btnConceptos.IconColor = Color.Black;
            btnConceptos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnConceptos.Location = new Point(0, 502);
            btnConceptos.Margin = new Padding(3, 4, 3, 4);
            btnConceptos.Name = "btnConceptos";
            btnConceptos.Padding = new Padding(11, 0, 0, 0);
            btnConceptos.Size = new Size(229, 67);
            btnConceptos.TabIndex = 8;
            btnConceptos.Text = "Conceptos";
            btnConceptos.TextAlign = ContentAlignment.MiddleLeft;
            btnConceptos.UseVisualStyleBackColor = true;
            btnConceptos.Click += btnConceptos_Click;
            // 
            // btnRegistrarVisita
            // 
            btnRegistrarVisita.Dock = DockStyle.Top;
            btnRegistrarVisita.FlatAppearance.BorderSize = 0;
            btnRegistrarVisita.FlatStyle = FlatStyle.Flat;
            btnRegistrarVisita.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistrarVisita.ForeColor = Color.FromArgb(230, 238, 252);
            btnRegistrarVisita.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRegistrarVisita.IconColor = Color.Black;
            btnRegistrarVisita.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRegistrarVisita.Location = new Point(0, 435);
            btnRegistrarVisita.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarVisita.Name = "btnRegistrarVisita";
            btnRegistrarVisita.Padding = new Padding(11, 0, 0, 0);
            btnRegistrarVisita.Size = new Size(229, 67);
            btnRegistrarVisita.TabIndex = 7;
            btnRegistrarVisita.Text = "Registrar Visita";
            btnRegistrarVisita.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarVisita.UseVisualStyleBackColor = true;
            btnRegistrarVisita.Click += btnRegistrarVisita_Click;
            // 
            // btnSocios
            // 
            btnSocios.Dock = DockStyle.Top;
            btnSocios.FlatAppearance.BorderSize = 0;
            btnSocios.FlatStyle = FlatStyle.Flat;
            btnSocios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSocios.ForeColor = Color.FromArgb(230, 238, 252);
            btnSocios.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSocios.IconColor = Color.Black;
            btnSocios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSocios.Location = new Point(0, 368);
            btnSocios.Margin = new Padding(3, 4, 3, 4);
            btnSocios.Name = "btnSocios";
            btnSocios.Padding = new Padding(11, 0, 0, 0);
            btnSocios.Size = new Size(229, 67);
            btnSocios.TabIndex = 5;
            btnSocios.Text = "Socios";
            btnSocios.TextAlign = ContentAlignment.MiddleLeft;
            btnSocios.UseVisualStyleBackColor = true;
            btnSocios.Click += btnSocios_Click;
            // 
            // btnMembresias
            // 
            btnMembresias.Dock = DockStyle.Top;
            btnMembresias.FlatAppearance.BorderSize = 0;
            btnMembresias.FlatStyle = FlatStyle.Flat;
            btnMembresias.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMembresias.ForeColor = Color.FromArgb(230, 238, 252);
            btnMembresias.IconChar = FontAwesome.Sharp.IconChar.None;
            btnMembresias.IconColor = Color.Black;
            btnMembresias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMembresias.Location = new Point(0, 301);
            btnMembresias.Margin = new Padding(3, 4, 3, 4);
            btnMembresias.Name = "btnMembresias";
            btnMembresias.Padding = new Padding(11, 0, 0, 0);
            btnMembresias.Size = new Size(229, 67);
            btnMembresias.TabIndex = 4;
            btnMembresias.Text = "Membresías";
            btnMembresias.TextAlign = ContentAlignment.MiddleLeft;
            btnMembresias.UseVisualStyleBackColor = true;
            btnMembresias.Click += btnMembresias_Click;
            // 
            // btnVentas
            // 
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVentas.ForeColor = Color.FromArgb(230, 238, 252);
            btnVentas.IconChar = FontAwesome.Sharp.IconChar.None;
            btnVentas.IconColor = Color.Black;
            btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas.Location = new Point(0, 234);
            btnVentas.Margin = new Padding(3, 4, 3, 4);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(11, 0, 0, 0);
            btnVentas.Size = new Size(229, 67);
            btnVentas.TabIndex = 3;
            btnVentas.Text = "Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCategorias.ForeColor = Color.FromArgb(230, 238, 252);
            btnCategorias.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCategorias.IconColor = Color.Black;
            btnCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCategorias.Location = new Point(0, 167);
            btnCategorias.Margin = new Padding(3, 4, 3, 4);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Padding = new Padding(11, 0, 0, 0);
            btnCategorias.Size = new Size(229, 67);
            btnCategorias.TabIndex = 2;
            btnCategorias.Text = "Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnProductos
            // 
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProductos.ForeColor = Color.FromArgb(230, 238, 252);
            btnProductos.IconChar = FontAwesome.Sharp.IconChar.None;
            btnProductos.IconColor = Color.Black;
            btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProductos.Location = new Point(0, 100);
            btnProductos.Margin = new Padding(3, 4, 3, 4);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(11, 0, 0, 0);
            btnProductos.Size = new Size(229, 67);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(15, 42, 79);
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(3, 4, 3, 4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(229, 100);
            panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(45, 212, 255);
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(229, 100);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "GYM SYSTEM";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(15, 42, 79);
            panelSuperior.Controls.Add(btnUsuarioMenu);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(229, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(914, 50);
            panelSuperior.TabIndex = 2;
            // 
            // btnUsuarioMenu
            // 
            btnUsuarioMenu.Dock = DockStyle.Right;
            btnUsuarioMenu.FlatAppearance.BorderSize = 0;
            btnUsuarioMenu.FlatStyle = FlatStyle.Flat;
            btnUsuarioMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUsuarioMenu.ForeColor = Color.FromArgb(230, 238, 252);
            btnUsuarioMenu.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            btnUsuarioMenu.IconColor = Color.FromArgb(45, 212, 255);
            btnUsuarioMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarioMenu.IconSize = 30;
            btnUsuarioMenu.ImageAlign = ContentAlignment.MiddleRight;
            btnUsuarioMenu.Location = new Point(734, 0);
            btnUsuarioMenu.Name = "btnUsuarioMenu";
            btnUsuarioMenu.Size = new Size(180, 50);
            btnUsuarioMenu.TabIndex = 0;
            btnUsuarioMenu.Text = "Usuario ▾";
            btnUsuarioMenu.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnUsuarioMenu.UseVisualStyleBackColor = true;
            btnUsuarioMenu.Click += btnUsuarioMenu_Click;
            // 
            // menuUsuario
            // 
            menuUsuario.ImageScalingSize = new Size(20, 20);
            menuUsuario.Items.AddRange(new ToolStripItem[] { itemIniciarSesion, itemCerrarSesion });
            menuUsuario.Name = "menuUsuario";
            menuUsuario.Size = new Size(164, 52);
            // 
            // itemIniciarSesion
            // 
            itemIniciarSesion.Name = "itemIniciarSesion";
            itemIniciarSesion.Size = new Size(163, 24);
            itemIniciarSesion.Text = "Iniciar sesión";
            itemIniciarSesion.Click += itemIniciarSesion_Click;
            // 
            // itemCerrarSesion
            // 
            itemCerrarSesion.Name = "itemCerrarSesion";
            itemCerrarSesion.Size = new Size(163, 24);
            itemCerrarSesion.Text = "Cerrar sesión";
            itemCerrarSesion.Click += itemCerrarSesion_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(11, 15, 26);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(229, 50);
            panelContenedor.Margin = new Padding(3, 4, 3, 4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(914, 1005);
            panelContenedor.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1143, 1055);
            Controls.Add(panelContenedor);
            Controls.Add(panelSuperior);
            Controls.Add(panelSideMenu);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Gimnasio";
            panelSideMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelSuperior.ResumeLayout(false);
            menuUsuario.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private FontAwesome.Sharp.IconButton btnProductos;
        private FontAwesome.Sharp.IconButton btnCategorias;
        private FontAwesome.Sharp.IconButton btnVentas;
        private FontAwesome.Sharp.IconButton btnMembresias;
        private FontAwesome.Sharp.IconButton btnSocios;
        private FontAwesome.Sharp.IconButton btnRegistrarVisita;
        private FontAwesome.Sharp.IconButton btnConceptos;
        private FontAwesome.Sharp.IconButton btnMovimientos;
        private FontAwesome.Sharp.IconButton btnRoles;
        private FontAwesome.Sharp.IconButton btnUsuarios;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelSuperior;
        private FontAwesome.Sharp.IconButton btnUsuarioMenu;
        private System.Windows.Forms.ContextMenuStrip menuUsuario;
        private System.Windows.Forms.ToolStripMenuItem itemIniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem itemCerrarSesion;
        private FontAwesome.Sharp.IconButton btnCompras;
        private FontAwesome.Sharp.IconButton btnReportes;
        private FontAwesome.Sharp.IconButton btnCorte;
        private FontAwesome.Sharp.IconButton btnConfiguracion;
    }
}
