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
        private bool _guardando;

        public FrmCategoriaModal(CategoriaController controller, int? categoriaId = null, string nombreActual = "")
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _categoriaId = categoriaId;

            InitializeComponent();

            lblTitulo.Text = _categoriaId.HasValue ? "Editar Categoría" : "Nueva Categoría";
            txtNombre.Text = nombreActual;
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (ValidationHelper.EsTextoVacio(txtNombre.Text))
            {
                FormHelper.MostrarAdvertencia("Debe ingresar un nombre para la categoría.", "Validación");
                txtNombre.Focus();
                return;
            }

            string nombre = txtNombre.Text.Trim();

            _guardando = true;
            bool guardado = await FormHelper.EjecutarAsync(
                () => _controller.GuardarCategoriaAsync(_categoriaId, nombre),
                "No se pudo guardar la categoría.",
                btnGuardar, btnCancelar);
            _guardando = false;

            if (guardado && !IsDisposed)
                DialogResult = DialogResult.OK; // cierra el diálogo; el grid se recarga solo
        }

        // No permitir cerrar la ventana mientras se está guardando.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_guardando)
                e.Cancel = true;

            base.OnFormClosing(e);
        }
    }
}
