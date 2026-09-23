using Negocio.Exceptions;
using Presentacion.Controls;
using Presentacion.Forms.Categorias;
using Presentacion.Helpers;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmCategorias : Form
    {
        private readonly CategoriaController _controller;
        private List<CategoriaViewModel> _listaCategorias = new();

        public FrmCategorias(CategoriaController controller)
        {
            InitializeComponent();
            _controller = controller;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
        }

        private async void FrmCategorias_Load(object sender, EventArgs e)
        {
            await CargarCategoriasAsync();
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var resultado = await _controller.ObtenerCategoriasAsync(true);
                _listaCategorias = resultado.ToList();
                FiltrarBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarBusqueda()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var filtradas = _listaCategorias
                .Where(c => string.IsNullOrEmpty(filtro) || c.Nombre.ToLower().Contains(filtro))
                .ToList();

            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = filtradas;
            ConfigurarGrid();
            dgvCategorias.ClearSelection();
        }

        private void ConfigurarGrid()
        {
            // 1. Ocultar columnas técnicas
            if (dgvCategorias.Columns["Activo"] != null) dgvCategorias.Columns["Activo"].Visible = false;

            // 2. Configurar encabezados
            if (dgvCategorias.Columns["CategoriaID"] != null) dgvCategorias.Columns["CategoriaID"].HeaderText = "ID";
            if (dgvCategorias.Columns["Nombre"] != null) dgvCategorias.Columns["Nombre"].HeaderText = "Categoría";
            if (dgvCategorias.Columns["Estado"] != null) dgvCategorias.Columns["Estado"].HeaderText = "Estado";
            if (dgvCategorias.Columns["CreatedAt"] != null) dgvCategorias.Columns["CreatedAt"].HeaderText = "Fecha Registro";

            // 3. Estructura de ordenamiento y pesos estilo estándar
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
        "CategoriaID",
        "Nombre",
        "Estado",
        "CreatedAt"
    };

            var pesos = new Dictionary<string, float>
            {
                ["CategoriaID"] = 45,
                ["Nombre"] = 200,
                ["Estado"] = 80,
                ["CreatedAt"] = 120
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvCategorias.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "Nombre" => 120,
                    "CreatedAt" => 95,
                    _ => 55
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmCategoriaModal(_controller);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarCategoriasAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una categoría de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (CategoriaViewModel)dgvCategorias.CurrentRow.DataBoundItem;
            using var modal = new FrmCategoriaModal(_controller, item.CategoriaID, item.Nombre);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarCategoriasAsync();
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una categoría de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (CategoriaViewModel)dgvCategorias.CurrentRow.DataBoundItem;
            string accion = item.Activo ? "desactivar" : "activar";

            if (FormHelper.ConfirmarAccion($"¿Está seguro de {accion} la categoría '{item.Nombre}'?", $"Confirmar {accion.ToUpper()}"))
            {
                try
                {
                    await _controller.CambiarEstadoLogicoAsync(item.CategoriaID);
                    await CargarCategoriasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una categoría de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (CategoriaViewModel)dgvCategorias.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE la categoría '{item.Nombre}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.CategoriaID);
                    await CargarCategoriasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarBusqueda();
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null && dgvCategorias.CurrentRow.DataBoundItem is CategoriaViewModel item)
            {
                if (item.Activo)
                {
                    btnDesactivar.Text = "Desactivar";
                    btnDesactivar.BackColor = System.Drawing.Color.IndianRed;
                }
                else
                {
                    btnDesactivar.Text = "Activar";
                    btnDesactivar.BackColor = System.Drawing.Color.ForestGreen;
                }
            }
        }
    }
}
