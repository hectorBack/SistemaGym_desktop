using Negocio.Exceptions;
using Presentacion.Controls;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Categorias
{
    public partial class FrmCategoriaModal : Form
    {
        private readonly CategoriaController _controller;
        private readonly int? _categoriaId;

        public FrmCategoriaModal(CategoriaController controller, int? categoriaId = null, string nombreActual = "")
        {
            InitializeComponent();
            _controller = controller;
            _categoriaId = categoriaId;

            if (_categoriaId.HasValue)
            {
                lblTitulo.Text = "Editar Categoría";
                txtNombre.Text = nombreActual;
            }
            else
            {
                lblTitulo.Text = "Nueva Categoría";
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para la categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _controller.GuardarCategoriaAsync(_categoriaId, txtNombre.Text.Trim());
                MessageBox.Show("Categoría guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
