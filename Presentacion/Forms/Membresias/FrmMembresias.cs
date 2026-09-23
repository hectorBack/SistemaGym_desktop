using Presentacion.Controller;
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

namespace Presentacion.Forms.Membresias
{
    public partial class FrmMembresias : Form
    {
        private readonly MembresiaController _controller;
        private List<MembresiaViewModel> _listaMembresias = new();

        public FrmMembresias(MembresiaController controller)
        {
            InitializeComponent();
            _controller = controller;
            dgvMembresias.SelectionChanged += dgvMembresias_SelectionChanged;
        }

        private async void FrmMembresias_Load(object sender, EventArgs e)
        {
            await CargarMembresiasAsync();
        }

        private async Task CargarMembresiasAsync()
        {
            try
            {
                var resultado = await _controller.ObtenerMembresiasAsync(true);
                _listaMembresias = resultado.ToList();
                FiltrarBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarBusqueda()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var filtradas = _listaMembresias
                .Where(m => string.IsNullOrEmpty(filtro) || m.Nombre.ToLower().Contains(filtro))
                .ToList();

            dgvMembresias.DataSource = null;
            dgvMembresias.DataSource = filtradas;
            ConfigurarGrid();
            dgvMembresias.ClearSelection();
        }

        private void ConfigurarGrid()
        {
            // 1. Ocultar columnas que no deben verse
            if (dgvMembresias.Columns["Precio"] != null) dgvMembresias.Columns["Precio"].Visible = false;
            if (dgvMembresias.Columns["DuracionDias"] != null) dgvMembresias.Columns["DuracionDias"].Visible = false;
            if (dgvMembresias.Columns["Activo"] != null) dgvMembresias.Columns["Activo"].Visible = false;

            // 2. Configurar encabezados
            if (dgvMembresias.Columns["MembresiaID"] != null) dgvMembresias.Columns["MembresiaID"].HeaderText = "ID";
            if (dgvMembresias.Columns["Nombre"] != null) dgvMembresias.Columns["Nombre"].HeaderText = "Membresía";
            if (dgvMembresias.Columns["PrecioFormateado"] != null) dgvMembresias.Columns["PrecioFormateado"].HeaderText = "Precio";
            if (dgvMembresias.Columns["DuracionTexto"] != null) dgvMembresias.Columns["DuracionTexto"].HeaderText = "Duración";
            if (dgvMembresias.Columns["Estado"] != null) dgvMembresias.Columns["Estado"].HeaderText = "Estado";
            if (dgvMembresias.Columns["CreatedAt"] != null) dgvMembresias.Columns["CreatedAt"].HeaderText = "Fecha Registro";

            // 3. Mismo esquema de ordenamiento y pesos estilo dgvVisitas / dgvSocios
            dgvMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
        "MembresiaID",
        "Nombre",
        "PrecioFormateado",
        "DuracionTexto",
        "Estado",
        "CreatedAt"
    };

            var pesos = new Dictionary<string, float>
            {
                ["MembresiaID"] = 45,
                ["Nombre"] = 180,
                ["PrecioFormateado"] = 90,
                ["DuracionTexto"] = 110,
                ["Estado"] = 80,
                ["CreatedAt"] = 120
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvMembresias.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "Nombre" or "DuracionTexto" => 110,
                    "CreatedAt" => 95,
                    _ => 55
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmMembresiaModal(_controller);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarMembresiasAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMembresias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una membresía de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (MembresiaViewModel)dgvMembresias.CurrentRow.DataBoundItem;
            using var modal = new FrmMembresiaModal(_controller, item.MembresiaID, item.Nombre, item.Precio, item.DuracionDias);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarMembresiasAsync();
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvMembresias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una membresía de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (MembresiaViewModel)dgvMembresias.CurrentRow.DataBoundItem;
            string accion = item.Activo ? "desactivar" : "activar";

            if (FormHelper.ConfirmarAccion($"¿Está seguro de {accion} la membresía '{item.Nombre}'?", $"Confirmar {accion.ToUpper()}"))
            {
                try
                {
                    await _controller.CambiarEstadoLogicoAsync(item.MembresiaID);
                    await CargarMembresiasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvMembresias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una membresía de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (MembresiaViewModel)dgvMembresias.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE la membresía '{item.Nombre}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.MembresiaID);
                    await CargarMembresiasAsync();
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

        private void dgvMembresias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembresias.CurrentRow != null && dgvMembresias.CurrentRow.DataBoundItem is MembresiaViewModel item)
            {
                if (item.Activo)
                {
                    btnDesactivar.Text = "Desactivar";
                    btnDesactivar.BackColor = Color.IndianRed;
                }
                else
                {
                    btnDesactivar.Text = "Activar";
                    btnDesactivar.BackColor = Color.ForestGreen;
                }
            }
        }
    }
}
