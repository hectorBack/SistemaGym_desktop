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

namespace Presentacion.Forms.Roles
{
    public partial class FrmRoles : Form
    {
        private readonly RolController _controller;
        private List<RolViewModel> _listaRoles = new();

        public FrmRoles(RolController controller)
        {
            InitializeComponent();
            _controller = controller;
            dgvRoles.SelectionChanged += dgvRoles_SelectionChanged;
        }

        private async void FrmRoles_Load(object sender, EventArgs e)
        {
            await CargarRolesAsync();
        }

        private async Task CargarRolesAsync()
        {
            try
            {
                var resultado = await _controller.ObtenerRolesAsync(true);
                _listaRoles = resultado.ToList();
                FiltrarBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarBusqueda()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var filtradas = _listaRoles
                .Where(r => string.IsNullOrEmpty(filtro) ||
                            r.Nombre.ToLower().Contains(filtro) ||
                            (!string.IsNullOrEmpty(r.Descripcion) && r.Descripcion.ToLower().Contains(filtro)))
                .ToList();

            dgvRoles.DataSource = null;
            dgvRoles.DataSource = filtradas;
            ConfigurarGrid();
            dgvRoles.ClearSelection();
        }

        private void ConfigurarGrid()
        {
            // 1. Ocultar columnas técnicas y complejas
            if (dgvRoles.Columns["Activo"] != null) dgvRoles.Columns["Activo"].Visible = false;
            if (dgvRoles.Columns["ModulosPermitidos"] != null) dgvRoles.Columns["ModulosPermitidos"].Visible = false;

            // 2. Configurar encabezados
            if (dgvRoles.Columns["RolID"] != null) dgvRoles.Columns["RolID"].HeaderText = "ID";
            if (dgvRoles.Columns["Nombre"] != null) dgvRoles.Columns["Nombre"].HeaderText = "Rol";
            if (dgvRoles.Columns["Descripcion"] != null) dgvRoles.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvRoles.Columns["ModulosTexto"] != null) dgvRoles.Columns["ModulosTexto"].HeaderText = "Módulos Permitidos";
            if (dgvRoles.Columns["Estado"] != null) dgvRoles.Columns["Estado"].HeaderText = "Estado";
            if (dgvRoles.Columns["CreatedAt"] != null) dgvRoles.Columns["CreatedAt"].HeaderText = "Fecha Registro";

            // 3. Estructura de ordenamiento y pesos estilo estándar
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
                "RolID",
                "Nombre",
                "Descripcion",
                "ModulosTexto",
                "Estado",
                "CreatedAt"
            };

            var pesos = new Dictionary<string, float>
            {
                ["RolID"] = 40,
                ["Nombre"] = 100,
                ["Descripcion"] = 150,
                ["ModulosTexto"] = 200,
                ["Estado"] = 70,
                ["CreatedAt"] = 100
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvRoles.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "Nombre" => 100,
                    "ModulosTexto" => 150,
                    "CreatedAt" => 95,
                    _ => 55
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmRolModal(_controller);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarRolesAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un rol de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (RolViewModel)dgvRoles.CurrentRow.DataBoundItem;
            if (item.Nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                item.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No se permite editar el rol de Administrador.",
                                "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var modal = new FrmRolModal(_controller, item.RolID);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarRolesAsync();
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un rol de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (RolViewModel)dgvRoles.CurrentRow.DataBoundItem;
            if (item.Nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                item.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No se permite desactivar el rol de Administrador.",
                                "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accion = item.Activo ? "desactivar" : "activar";

            if (FormHelper.ConfirmarAccion($"¿Está seguro de {accion} el rol '{item.Nombre}'?", $"Confirmar {accion.ToUpper()}"))
            {
                try
                {
                    await _controller.CambiarEstadoLogicoAsync(item.RolID);
                    await CargarRolesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un rol de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (RolViewModel)dgvRoles.CurrentRow.DataBoundItem;

            if (item.Nombre.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                item.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No se permite eliminar el rol de Administrador.",
                                "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE el rol '{item.Nombre}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.RolID);
                    await CargarRolesAsync();
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

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow != null && dgvRoles.CurrentRow.DataBoundItem is RolViewModel item)
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
