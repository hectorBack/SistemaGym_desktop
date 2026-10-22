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
            panelLogo = new Panel();
            lblLogo = new Label();

            // Instanciación de los botones
            btnInicio = new FontAwesome.Sharp.IconButton();
            btnVentas = new FontAwesome.Sharp.IconButton();
            btnMembresias = new FontAwesome.Sharp.IconButton();
            btnSocios = new FontAwesome.Sharp.IconButton();
            btnRegistrarVisita = new FontAwesome.Sharp.IconButton();
            btnProductos = new FontAwesome.Sharp.IconButton();
            btnCategorias = new FontAwesome.Sharp.IconButton();
            btnCompras = new FontAwesome.Sharp.IconButton();
            btnConceptos = new FontAwesome.Sharp.IconButton();
            btnMovimientos = new FontAwesome.Sharp.IconButton();
            btnRoles = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new FontAwesome.Sharp.IconButton();
            btnReportes = new FontAwesome.Sharp.IconButton();
            btnCorte = new FontAwesome.Sharp.IconButton();
            btnConfiguracion = new FontAwesome.Sharp.IconButton();
            btnRespaldosManuales = new FontAwesome.Sharp.IconButton();
            btnRestaurar = new FontAwesome.Sharp.IconButton();

            panelSuperior = new Panel();
            btnUsuarioMenu = new FontAwesome.Sharp.IconButton();
            menuUsuario = new ContextMenuStrip(components);
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
            // 🟢 ORDEN CORRECTO DE APILAMIENTO (El último agregado en Controls.Add queda hasta arriba visualmente)
            panelSideMenu.Controls.Add(btnRestaurar);
            panelSideMenu.Controls.Add(btnRespaldosManuales);
            panelSideMenu.Controls.Add(btnConfiguracion);
            panelSideMenu.Controls.Add(btnCorte);
            panelSideMenu.Controls.Add(btnReportes);
            panelSideMenu.Controls.Add(btnUsuarios);
            panelSideMenu.Controls.Add(btnRoles);
            panelSideMenu.Controls.Add(btnMovimientos);
            panelSideMenu.Controls.Add(btnConceptos);
            panelSideMenu.Controls.Add(btnCompras);
            panelSideMenu.Controls.Add(btnCategorias);
            panelSideMenu.Controls.Add(btnProductos);
            panelSideMenu.Controls.Add(btnRegistrarVisita);
            panelSideMenu.Controls.Add(btnSocios);
            panelSideMenu.Controls.Add(btnMembresias);
            panelSideMenu.Controls.Add(btnVentas);
            panelSideMenu.Controls.Add(btnInicio);
            panelSideMenu.Controls.Add(panelLogo);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Margin = new Padding(3, 4, 3, 4);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(229, 733);
            panelSideMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(15, 42, 79);
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(3, 4, 3, 4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(229, 70);
            panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(45, 212, 255);
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(229, 70);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "GYM SYSTEM";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(15, 42, 79);
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatAppearance.MouseDownBackColor = Color.FromArgb(18, 48, 88);
            btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(23, 58, 105);
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInicio.ForeColor = Color.FromArgb(230, 238, 252);
            btnInicio.IconChar = FontAwesome.Sharp.IconChar.Home;
            btnInicio.IconColor = Color.FromArgb(230, 238, 252);
            btnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInicio.IconSize = 26;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(0, 70);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new Padding(15, 0, 0, 0);
            btnInicio.Size = new Size(229, 44);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "  Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInicio.UseVisualStyleBackColor = false;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(15, 42, 79);
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVentas.ForeColor = Color.FromArgb(230, 238, 252);
            btnVentas.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            btnVentas.IconColor = Color.FromArgb(230, 238, 252);
            btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas.IconSize = 26;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(0, 114);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(15, 0, 0, 0);
            btnVentas.Size = new Size(229, 44);
            btnVentas.TabIndex = 2;
            btnVentas.Text = "  Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseVisualStyleBackColor = false;
            // 
            // btnMembresias
            // 
            btnMembresias.BackColor = Color.FromArgb(15, 42, 79);
            btnMembresias.Dock = DockStyle.Top;
            btnMembresias.FlatAppearance.BorderSize = 0;
            btnMembresias.FlatStyle = FlatStyle.Flat;
            btnMembresias.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMembresias.ForeColor = Color.FromArgb(230, 238, 252);
            btnMembresias.IconChar = FontAwesome.Sharp.IconChar.DriversLicense;
            btnMembresias.IconColor = Color.FromArgb(230, 238, 252);
            btnMembresias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMembresias.IconSize = 26;
            btnMembresias.ImageAlign = ContentAlignment.MiddleLeft;
            btnMembresias.Location = new Point(0, 158);
            btnMembresias.Name = "btnMembresias";
            btnMembresias.Padding = new Padding(15, 0, 0, 0);
            btnMembresias.Size = new Size(229, 44);
            btnMembresias.TabIndex = 3;
            btnMembresias.Text = "  Membresías";
            btnMembresias.TextAlign = ContentAlignment.MiddleLeft;
            btnMembresias.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMembresias.UseVisualStyleBackColor = false;
            // 
            // btnSocios
            // 
            btnSocios.BackColor = Color.FromArgb(15, 42, 79);
            btnSocios.Dock = DockStyle.Top;
            btnSocios.FlatAppearance.BorderSize = 0;
            btnSocios.FlatStyle = FlatStyle.Flat;
            btnSocios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSocios.ForeColor = Color.FromArgb(230, 238, 252);
            btnSocios.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnSocios.IconColor = Color.FromArgb(230, 238, 252);
            btnSocios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSocios.IconSize = 26;
            btnSocios.ImageAlign = ContentAlignment.MiddleLeft;
            btnSocios.Location = new Point(0, 202);
            btnSocios.Name = "btnSocios";
            btnSocios.Padding = new Padding(15, 0, 0, 0);
            btnSocios.Size = new Size(229, 44);
            btnSocios.TabIndex = 4;
            btnSocios.Text = "  Socios";
            btnSocios.TextAlign = ContentAlignment.MiddleLeft;
            btnSocios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSocios.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarVisita
            // 
            btnRegistrarVisita.BackColor = Color.FromArgb(15, 42, 79);
            btnRegistrarVisita.Dock = DockStyle.Top;
            btnRegistrarVisita.FlatAppearance.BorderSize = 0;
            btnRegistrarVisita.FlatStyle = FlatStyle.Flat;
            btnRegistrarVisita.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistrarVisita.ForeColor = Color.FromArgb(230, 238, 252);
            btnRegistrarVisita.IconChar = FontAwesome.Sharp.IconChar.UserCheck;
            btnRegistrarVisita.IconColor = Color.FromArgb(230, 238, 252);
            btnRegistrarVisita.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRegistrarVisita.IconSize = 26;
            btnRegistrarVisita.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistrarVisita.Location = new Point(0, 246);
            btnRegistrarVisita.Name = "btnRegistrarVisita";
            btnRegistrarVisita.Padding = new Padding(15, 0, 0, 0);
            btnRegistrarVisita.Size = new Size(229, 44);
            btnRegistrarVisita.TabIndex = 5;
            btnRegistrarVisita.Text = "  Registrar Visita";
            btnRegistrarVisita.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarVisita.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistrarVisita.UseVisualStyleBackColor = false;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(15, 42, 79);
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProductos.ForeColor = Color.FromArgb(230, 238, 252);
            btnProductos.IconChar = FontAwesome.Sharp.IconChar.Box;
            btnProductos.IconColor = Color.FromArgb(230, 238, 252);
            btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProductos.IconSize = 26;
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(0, 290);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(15, 0, 0, 0);
            btnProductos.Size = new Size(229, 44);
            btnProductos.TabIndex = 6;
            btnProductos.Text = "  Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = Color.FromArgb(15, 42, 79);
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCategorias.ForeColor = Color.FromArgb(230, 238, 252);
            btnCategorias.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnCategorias.IconColor = Color.FromArgb(230, 238, 252);
            btnCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCategorias.IconSize = 26;
            btnCategorias.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategorias.Location = new Point(0, 334);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Padding = new Padding(15, 0, 0, 0);
            btnCategorias.Size = new Size(229, 44);
            btnCategorias.TabIndex = 7;
            btnCategorias.Text = "  Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategorias.UseVisualStyleBackColor = false;
            // 
            // btnCompras
            // 
            btnCompras.BackColor = Color.FromArgb(15, 42, 79);
            btnCompras.Dock = DockStyle.Top;
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCompras.ForeColor = Color.FromArgb(230, 238, 252);
            btnCompras.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            btnCompras.IconColor = Color.FromArgb(230, 238, 252);
            btnCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras.IconSize = 26;
            btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras.Location = new Point(0, 378);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(15, 0, 0, 0);
            btnCompras.Size = new Size(229, 44);
            btnCompras.TabIndex = 8;
            btnCompras.Text = "  Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras.UseVisualStyleBackColor = false;
            // 
            // btnConceptos
            // 
            btnConceptos.BackColor = Color.FromArgb(15, 42, 79);
            btnConceptos.Dock = DockStyle.Top;
            btnConceptos.FlatAppearance.BorderSize = 0;
            btnConceptos.FlatStyle = FlatStyle.Flat;
            btnConceptos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConceptos.ForeColor = Color.FromArgb(230, 238, 252);
            btnConceptos.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            btnConceptos.IconColor = Color.FromArgb(230, 238, 252);
            btnConceptos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnConceptos.IconSize = 26;
            btnConceptos.ImageAlign = ContentAlignment.MiddleLeft;
            btnConceptos.Location = new Point(0, 422);
            btnConceptos.Name = "btnConceptos";
            btnConceptos.Padding = new Padding(15, 0, 0, 0);
            btnConceptos.Size = new Size(229, 44);
            btnConceptos.TabIndex = 9;
            btnConceptos.Text = "  Conceptos";
            btnConceptos.TextAlign = ContentAlignment.MiddleLeft;
            btnConceptos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConceptos.UseVisualStyleBackColor = false;
            // 
            // btnMovimientos
            // 
            btnMovimientos.BackColor = Color.FromArgb(15, 42, 79);
            btnMovimientos.Dock = DockStyle.Top;
            btnMovimientos.FlatAppearance.BorderSize = 0;
            btnMovimientos.FlatStyle = FlatStyle.Flat;
            btnMovimientos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMovimientos.ForeColor = Color.FromArgb(230, 238, 252);
            btnMovimientos.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            btnMovimientos.IconColor = Color.FromArgb(230, 238, 252);
            btnMovimientos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMovimientos.IconSize = 26;
            btnMovimientos.ImageAlign = ContentAlignment.MiddleLeft;
            btnMovimientos.Location = new Point(0, 466);
            btnMovimientos.Name = "btnMovimientos";
            btnMovimientos.Padding = new Padding(15, 0, 0, 0);
            btnMovimientos.Size = new Size(229, 44);
            btnMovimientos.TabIndex = 10;
            btnMovimientos.Text = "  Movimientos";
            btnMovimientos.TextAlign = ContentAlignment.MiddleLeft;
            btnMovimientos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMovimientos.UseVisualStyleBackColor = false;
            // 
            // btnRoles
            // 
            btnRoles.BackColor = Color.FromArgb(15, 42, 79);
            btnRoles.Dock = DockStyle.Top;
            btnRoles.FlatAppearance.BorderSize = 0;
            btnRoles.FlatStyle = FlatStyle.Flat;
            btnRoles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRoles.ForeColor = Color.FromArgb(230, 238, 252);
            btnRoles.IconChar = FontAwesome.Sharp.IconChar.UserShield;
            btnRoles.IconColor = Color.FromArgb(230, 238, 252);
            btnRoles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRoles.IconSize = 26;
            btnRoles.ImageAlign = ContentAlignment.MiddleLeft;
            btnRoles.Location = new Point(0, 510);
            btnRoles.Name = "btnRoles";
            btnRoles.Padding = new Padding(15, 0, 0, 0);
            btnRoles.Size = new Size(229, 44);
            btnRoles.TabIndex = 11;
            btnRoles.Text = "  Roles";
            btnRoles.TextAlign = ContentAlignment.MiddleLeft;
            btnRoles.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRoles.UseVisualStyleBackColor = false;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(15, 42, 79);
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUsuarios.ForeColor = Color.FromArgb(230, 238, 252);
            btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            btnUsuarios.IconColor = Color.FromArgb(230, 238, 252);
            btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarios.IconSize = 26;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(0, 554);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(15, 0, 0, 0);
            btnUsuarios.Size = new Size(229, 44);
            btnUsuarios.TabIndex = 12;
            btnUsuarios.Text = "  Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(15, 42, 79);
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReportes.ForeColor = Color.FromArgb(230, 238, 252);
            btnReportes.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            btnReportes.IconColor = Color.FromArgb(230, 238, 252);
            btnReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReportes.IconSize = 26;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(0, 598);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(15, 0, 0, 0);
            btnReportes.Size = new Size(229, 44);
            btnReportes.TabIndex = 13;
            btnReportes.Text = "  Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes.UseVisualStyleBackColor = false;
            // 
            // btnCorte
            // 
            btnCorte.BackColor = Color.FromArgb(15, 42, 79);
            btnCorte.Dock = DockStyle.Top;
            btnCorte.FlatAppearance.BorderSize = 0;
            btnCorte.FlatStyle = FlatStyle.Flat;
            btnCorte.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCorte.ForeColor = Color.FromArgb(230, 238, 252);
            btnCorte.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            btnCorte.IconColor = Color.FromArgb(230, 238, 252);
            btnCorte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCorte.IconSize = 26;
            btnCorte.ImageAlign = ContentAlignment.MiddleLeft;
            btnCorte.Location = new Point(0, 642);
            btnCorte.Name = "btnCorte";
            btnCorte.Padding = new Padding(15, 0, 0, 0);
            btnCorte.Size = new Size(229, 44);
            btnCorte.TabIndex = 14;
            btnCorte.Text = "  Cortes";
            btnCorte.TextAlign = ContentAlignment.MiddleLeft;
            btnCorte.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCorte.UseVisualStyleBackColor = false;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.BackColor = Color.FromArgb(15, 42, 79);
            btnConfiguracion.Dock = DockStyle.Top;
            btnConfiguracion.FlatAppearance.BorderSize = 0;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfiguracion.ForeColor = Color.FromArgb(230, 238, 252);
            btnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnConfiguracion.IconColor = Color.FromArgb(230, 238, 252);
            btnConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnConfiguracion.IconSize = 26;
            btnConfiguracion.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.Location = new Point(0, 686);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Padding = new Padding(15, 0, 0, 0);
            btnConfiguracion.Size = new Size(229, 44);
            btnConfiguracion.TabIndex = 15;
            btnConfiguracion.Text = "  Configuraciones";
            btnConfiguracion.TextAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfiguracion.UseVisualStyleBackColor = false;
            // 
            // btnRespaldosManuales
            // 
            btnRespaldosManuales.BackColor = Color.FromArgb(15, 42, 79);
            btnRespaldosManuales.Dock = DockStyle.Top;
            btnRespaldosManuales.FlatAppearance.BorderSize = 0;
            btnRespaldosManuales.FlatStyle = FlatStyle.Flat;
            btnRespaldosManuales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRespaldosManuales.ForeColor = Color.FromArgb(230, 238, 252);
            btnRespaldosManuales.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnRespaldosManuales.IconColor = Color.FromArgb(230, 238, 252);
            btnRespaldosManuales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRespaldosManuales.IconSize = 26;
            btnRespaldosManuales.ImageAlign = ContentAlignment.MiddleLeft;
            btnRespaldosManuales.Location = new Point(0, 730);
            btnRespaldosManuales.Name = "btnRespaldosManuales";
            btnRespaldosManuales.Padding = new Padding(15, 0, 0, 0);
            btnRespaldosManuales.Size = new Size(229, 44);
            btnRespaldosManuales.TabIndex = 16;
            btnRespaldosManuales.Text = "  Respaldos";
            btnRespaldosManuales.TextAlign = ContentAlignment.MiddleLeft;
            btnRespaldosManuales.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRespaldosManuales.UseVisualStyleBackColor = false;
            btnRespaldosManuales.Click += btnRespaldos_Click;
            // 
            // btnRestaurar
            // 
            btnRestaurar.BackColor = Color.FromArgb(15, 42, 79);
            btnRestaurar.Dock = DockStyle.Top;
            btnRestaurar.FlatAppearance.BorderSize = 0;
            btnRestaurar.FlatStyle = FlatStyle.Flat;
            btnRestaurar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRestaurar.ForeColor = Color.FromArgb(230, 238, 252);
            btnRestaurar.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            btnRestaurar.IconColor = Color.FromArgb(230, 238, 252);
            btnRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestaurar.IconSize = 26;
            btnRestaurar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRestaurar.Location = new Point(0, 774);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Padding = new Padding(15, 0, 0, 0);
            btnRestaurar.Size = new Size(229, 44);
            btnRestaurar.TabIndex = 17;
            btnRestaurar.Text = "  Restaurar";
            btnRestaurar.TextAlign = ContentAlignment.MiddleLeft;
            btnRestaurar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRestaurar.UseVisualStyleBackColor = false;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(15, 42, 79);
            panelSuperior.Controls.Add(btnUsuarioMenu);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(229, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(971, 50);
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
            btnUsuarioMenu.Location = new Point(791, 0);
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
            menuUsuario.Items.AddRange(new ToolStripItem[] { itemCerrarSesion });
            menuUsuario.Name = "menuUsuario";
            menuUsuario.Size = new Size(164, 28);
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
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(971, 683);
            panelContenedor.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            ClientSize = new Size(1200, 733);
            Controls.Add(panelContenedor);
            Controls.Add(panelSuperior);
            Controls.Add(panelSideMenu);
            MinimumSize = new Size(1024, 600);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Gimnasio";
            WindowState = FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolStripMenuItem itemCerrarSesion;
        private FontAwesome.Sharp.IconButton btnCompras;
        private FontAwesome.Sharp.IconButton btnReportes;
        private FontAwesome.Sharp.IconButton btnCorte;
        private FontAwesome.Sharp.IconButton btnConfiguracion;
        private FontAwesome.Sharp.IconButton btnInicio;
        private FontAwesome.Sharp.IconButton btnRespaldosManuales;
        private FontAwesome.Sharp.IconButton btnRestaurar;
    }
}
