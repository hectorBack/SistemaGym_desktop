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
            panelSideMenu = new Panel();
            btnUsuarios = new FontAwesome.Sharp.IconButton();
            btnRoles = new FontAwesome.Sharp.IconButton();
            btnMovimientos = new FontAwesome.Sharp.IconButton();
            btnConceptos = new FontAwesome.Sharp.IconButton();
            btnRegistrarVisita = new FontAwesome.Sharp.IconButton();
            btnVisitas = new FontAwesome.Sharp.IconButton();
            btnSocios = new FontAwesome.Sharp.IconButton();
            btnMembresias = new FontAwesome.Sharp.IconButton();
            btnVentas = new FontAwesome.Sharp.IconButton();
            btnCategorias = new FontAwesome.Sharp.IconButton();
            btnProductos = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            lblLogo = new Label();

            panelSuperior = new Panel();
            btnUsuarioMenu = new FontAwesome.Sharp.IconButton();
            menuUsuario = new ContextMenuStrip();
            itemIniciarSesion = new ToolStripMenuItem();
            itemCerrarSesion = new ToolStripMenuItem();

            // 1. INSTANCIACIÓN REQUERIDA
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
            panelSideMenu.Controls.Add(btnUsuarios);
            panelSideMenu.Controls.Add(btnRoles);
            panelSideMenu.Controls.Add(btnMovimientos);
            panelSideMenu.Controls.Add(btnConceptos);
            panelSideMenu.Controls.Add(btnRegistrarVisita);
            panelSideMenu.Controls.Add(btnVisitas);
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
            panelSideMenu.Size = new Size(229, 842);
            panelSideMenu.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUsuarios.ForeColor = Color.FromArgb(230, 238, 252);
            btnUsuarios.Location = new Point(0, 770);
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
            btnRoles.Location = new Point(0, 703);
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
            btnMovimientos.Location = new Point(0, 636);
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
            btnConceptos.Location = new Point(0, 569);
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
            btnRegistrarVisita.Location = new Point(0, 502);
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
            // btnVisitas
            // 
            btnVisitas.Dock = DockStyle.Top;
            btnVisitas.FlatAppearance.BorderSize = 0;
            btnVisitas.FlatStyle = FlatStyle.Flat;
            btnVisitas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVisitas.ForeColor = Color.FromArgb(230, 238, 252);
            btnVisitas.Location = new Point(0, 435);
            btnVisitas.Margin = new Padding(3, 4, 3, 4);
            btnVisitas.Name = "btnVisitas";
            btnVisitas.Padding = new Padding(11, 0, 0, 0);
            btnVisitas.Size = new Size(229, 67);
            btnVisitas.TabIndex = 6;
            btnVisitas.Text = "Visitas";
            btnVisitas.TextAlign = ContentAlignment.MiddleLeft;
            btnVisitas.UseVisualStyleBackColor = true;
            btnVisitas.Click += btnVisitas_Click;
            // 
            // btnSocios
            // 
            btnSocios.Dock = DockStyle.Top;
            btnSocios.FlatAppearance.BorderSize = 0;
            btnSocios.FlatStyle = FlatStyle.Flat;
            btnSocios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSocios.ForeColor = Color.FromArgb(230, 238, 252);
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
            // menuUsuario (Menú desplegable)
            // 
            menuUsuario.Items.AddRange(new ToolStripItem[] { itemIniciarSesion, itemCerrarSesion });
            menuUsuario.Name = "menuUsuario";
            menuUsuario.Size = new Size(150, 52);

            // itemIniciarSesion
            itemIniciarSesion.Name = "itemIniciarSesion";
            itemIniciarSesion.Size = new Size(149, 24);
            itemIniciarSesion.Text = "Iniciar sesión";
            itemIniciarSesion.Click += itemIniciarSesion_Click;

            // itemCerrarSesion
            itemCerrarSesion.Name = "itemCerrarSesion";
            itemCerrarSesion.Size = new Size(149, 24);
            itemCerrarSesion.Text = "Cerrar sesión";
            itemCerrarSesion.Click += itemCerrarSesion_Click;

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
            // 2. CONFIGURACIÓN DEL PANEL CONTENEDOR
            // 
            panelContenedor.BackColor = Color.FromArgb(11, 15, 26);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(229, 0);
            panelContenedor.Margin = new Padding(3, 4, 3, 4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(914, 842);
            panelContenedor.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1143, 842);

            // AGREGAR LOS CONTROLES AL FORMULARIO
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
        private FontAwesome.Sharp.IconButton btnVisitas;
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
    }
}
