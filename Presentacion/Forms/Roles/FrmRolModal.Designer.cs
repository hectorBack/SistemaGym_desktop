namespace Presentacion.Forms.Roles
{
    partial class FrmRolModal
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblModulos = new Label();
            btnSeleccionarTodos = new BotonTema();
            btnSeleccionarNinguno = new BotonTema();
            clbModulos = new CheckedListBox();
            lblContador = new Label();
            btnGuardar = new BotonTema();
            btnCancelar = new BotonTema();
            panelHeader.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(15, 42, 79);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(420, 50);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(45, 212, 255);
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(88, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Rol";
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.FromArgb(230, 238, 252);
            lblNombre.Location = new Point(25, 65);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(109, 17);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre del Rol:";
            //
            // txtNombre
            //
            txtNombre.BackColor = Color.FromArgb(15, 42, 79);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.ForeColor = Color.FromArgb(230, 238, 252);
            txtNombre.Location = new Point(25, 85);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(370, 25);
            txtNombre.TabIndex = 2;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.ForeColor = Color.FromArgb(230, 238, 252);
            lblDescripcion.Location = new Point(25, 120);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(79, 17);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            //
            // txtDescripcion
            //
            txtDescripcion.AcceptsReturn = true; // Enter escribe un salto de línea en lugar de pulsar "Guardar"
            txtDescripcion.BackColor = Color.FromArgb(15, 42, 79);
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescripcion.ForeColor = Color.FromArgb(230, 238, 252);
            txtDescripcion.Location = new Point(25, 140);
            txtDescripcion.MaxLength = 200;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(370, 50);
            txtDescripcion.TabIndex = 4;
            //
            // lblModulos
            //
            lblModulos.AutoSize = true;
            lblModulos.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblModulos.ForeColor = Color.FromArgb(230, 238, 252);
            lblModulos.Location = new Point(25, 208);
            lblModulos.Name = "lblModulos";
            lblModulos.Size = new Size(134, 17);
            lblModulos.TabIndex = 5;
            lblModulos.Text = "Módulos Permitidos:";
            //
            // btnSeleccionarTodos
            //
            btnSeleccionarTodos.Location = new Point(255, 202);
            btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            btnSeleccionarTodos.Size = new Size(68, 26);
            btnSeleccionarTodos.TabIndex = 5;
            btnSeleccionarTodos.Text = "Todos";
            //
            // btnSeleccionarNinguno
            //
            btnSeleccionarNinguno.Location = new Point(327, 202);
            btnSeleccionarNinguno.Name = "btnSeleccionarNinguno";
            btnSeleccionarNinguno.Size = new Size(68, 26);
            btnSeleccionarNinguno.TabIndex = 6;
            btnSeleccionarNinguno.Text = "Ninguno";
            //
            // clbModulos
            //
            clbModulos.BackColor = Color.FromArgb(15, 42, 79);
            clbModulos.BorderStyle = BorderStyle.FixedSingle;
            clbModulos.CheckOnClick = true;
            clbModulos.ColumnWidth = 180;
            clbModulos.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            clbModulos.ForeColor = Color.FromArgb(230, 238, 252);
            clbModulos.FormattingEnabled = true;
            clbModulos.Location = new Point(25, 234);
            clbModulos.MultiColumn = true; // 2 columnas: caben los 17 módulos sin desplazarse
            clbModulos.Name = "clbModulos";
            clbModulos.Size = new Size(370, 190);
            clbModulos.TabIndex = 7;
            //
            // lblContador
            //
            lblContador.AutoSize = true;
            lblContador.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblContador.ForeColor = Color.FromArgb(124, 138, 165);
            lblContador.Location = new Point(25, 430);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(160, 15);
            lblContador.TabIndex = 8;
            lblContador.Text = "0 de 0 módulos seleccionados";
            //
            // btnGuardar
            //
            btnGuardar.Estilo = EstiloBoton.Primario;
            btnGuardar.Location = new Point(205, 460);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(305, 460);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            //
            // FrmRolModal
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 15, 26);
            CancelButton = btnCancelar;
            ClientSize = new Size(420, 510);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblContador);
            Controls.Add(clbModulos);
            Controls.Add(btnSeleccionarNinguno);
            Controls.Add(btnSeleccionarTodos);
            Controls.Add(lblModulos);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRolModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rol";
            Load += FrmRolModal_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblModulos;
        private BotonTema btnSeleccionarTodos;
        private BotonTema btnSeleccionarNinguno;
        private CheckedListBox clbModulos;
        private Label lblContador;
        private BotonTema btnGuardar;
        private BotonTema btnCancelar;
    }
}