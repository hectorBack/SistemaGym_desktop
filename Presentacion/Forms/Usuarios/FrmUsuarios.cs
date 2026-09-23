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

namespace Presentacion.Forms.Usuarios
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioController _controller;
        private readonly RolController _rolController; 
        private List<UsuarioViewModel> _listaUsuarios = new();

        public FrmUsuarios(UsuarioController controller, RolController rolController)
        {
            InitializeComponent();
            _controller = controller;
            _rolController = rolController;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
        }

        private async void FrmUsuarios_Load(object sender, EventArgs e)
        {
            await CargarUsuariosAsync();
        }

        private async Task CargarUsuariosAsync()
        {
            try
            {
                var resultado = await _controller.ObtenerUsuariosAsync(true);
                _listaUsuarios = resultado.ToList();
                FiltrarBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarBusqueda()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var filtrados = _listaUsuarios
                .Where(u => string.IsNullOrEmpty(filtro) ||
                            u.NombreUsuario.ToLower().Contains(filtro) ||
                            u.NombreCompleto.ToLower().Contains(filtro) ||
                            u.RolNombre.ToLower().Contains(filtro))
                .ToList();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = filtrados;
            ConfigurarGrid();
            dgvUsuarios.ClearSelection();
        }

        private void ConfigurarGrid()
        {
            // 1. Ocultar columnas técnicas o no requeridas explícitamente en la grilla
            if (dgvUsuarios.Columns["Activo"] != null) dgvUsuarios.Columns["Activo"].Visible = false;
            if (dgvUsuarios.Columns["RolID"] != null) dgvUsuarios.Columns["RolID"].Visible = false;

            // 2. Configurar encabezados
            if (dgvUsuarios.Columns["UsuarioID"] != null) dgvUsuarios.Columns["UsuarioID"].HeaderText = "ID";
            if (dgvUsuarios.Columns["NombreUsuario"] != null) dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
            if (dgvUsuarios.Columns["NombreCompleto"] != null) dgvUsuarios.Columns["NombreCompleto"].HeaderText = "Nombre";
            if (dgvUsuarios.Columns["RolNombre"] != null) dgvUsuarios.Columns["RolNombre"].HeaderText = "Rol";
            if (dgvUsuarios.Columns["Estado"] != null) dgvUsuarios.Columns["Estado"].HeaderText = "Estado";
            if (dgvUsuarios.Columns["CreatedAt"] != null) dgvUsuarios.Columns["CreatedAt"].HeaderText = "Fecha de registro";

            // 3. Estructura de ordenamiento y pesos estilo estándar
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
                "UsuarioID",
                "NombreUsuario",
                "NombreCompleto",
                "RolNombre",
                "Estado",
                "CreatedAt"
            };

            var pesos = new Dictionary<string, float>
            {
                ["UsuarioID"] = 40,
                ["NombreUsuario"] = 110,
                ["NombreCompleto"] = 180,
                ["RolNombre"] = 110,
                ["Estado"] = 80,
                ["CreatedAt"] = 120
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvUsuarios.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "NombreCompleto" => 130,
                    "NombreUsuario" => 90,
                    "CreatedAt" => 100,
                    _ => 60
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmUsuarioModal(_controller, _rolController);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarUsuariosAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (UsuarioViewModel)dgvUsuarios.CurrentRow.DataBoundItem;
            using var modal = new FrmUsuarioModal(_controller, _rolController, item.UsuarioID);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarUsuariosAsync();
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (UsuarioViewModel)dgvUsuarios.CurrentRow.DataBoundItem;
            string accion = item.Activo ? "desactivar" : "activar";

            if (FormHelper.ConfirmarAccion($"¿Está seguro de {accion} al usuario '{item.NombreUsuario}'?", $"Confirmar {accion.ToUpper()}"))
            {
                try
                {
                    await _controller.CambiarEstadoLogicoAsync(item.UsuarioID);
                    await CargarUsuariosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (UsuarioViewModel)dgvUsuarios.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE al usuario '{item.NombreUsuario}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.UsuarioID);
                    await CargarUsuariosAsync();
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

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.DataBoundItem is UsuarioViewModel item)
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
