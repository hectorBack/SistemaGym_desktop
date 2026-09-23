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
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblModulos = new Label();
            clbModulos = new CheckedListBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelHeader = new Panel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = ColorTranslator.FromHtml("#0f2a4f");
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
            lblTitulo.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
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
            lblNombre.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblNombre.Location = new Point(25, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(109, 17);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre del Rol:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtNombre.Location = new Point(25, 90);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(370, 25);
            txtNombre.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblDescripcion.Location = new Point(25, 130);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(79, 17);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescripcion.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            txtDescripcion.Location = new Point(25, 150);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(370, 50);
            txtDescripcion.TabIndex = 4;
            // 
            // lblModulos
            // 
            lblModulos.AutoSize = true;
            lblModulos.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblModulos.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            lblModulos.Location = new Point(25, 215);
            lblModulos.Name = "lblModulos";
            lblModulos.Size = new Size(134, 17);
            lblModulos.TabIndex = 5;
            lblModulos.Text = "Módulos Permitidos:";
            // 
            // clbModulos
            // 
            clbModulos.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            clbModulos.BorderStyle = BorderStyle.FixedSingle;
            clbModulos.CheckOnClick = true;
            clbModulos.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            clbModulos.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            clbModulos.FormattingEnabled = true;
            clbModulos.Location = new Point(25, 235);
            clbModulos.Name = "clbModulos";
            clbModulos.Size = new Size(370, 150);
            clbModulos.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = ColorTranslator.FromHtml("#1f6feb");
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(205, 410);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            btnCancelar.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#1f6feb");
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            btnCancelar.Location = new Point(305, 410);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 32);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmRolModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#0b0f1a");
            ClientSize = new Size(420, 460);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(clbModulos);
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
        private CheckedListBox clbModulos;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}