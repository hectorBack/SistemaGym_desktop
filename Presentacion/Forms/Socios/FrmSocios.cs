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

namespace Presentacion.Forms.Socios
{
    public partial class FrmSocios : Form
    {
        private readonly VisitaController _visitaController;
        private readonly SocioController _controller;
        private readonly SocioMembresiaController _socioMembresiaController;
        private readonly MembresiaController _membresiaController;
        private readonly PagoSocioMembresiaController _pagoSocioMembresiaController;
        private List<SocioViewModel> _listaSocios = new();

        public FrmSocios(SocioController controller,
        SocioMembresiaController socioMembresiaController,
        MembresiaController membresiaController,
        PagoSocioMembresiaController pagoSocioMembresiaController,
        VisitaController visitaController)
        {
            InitializeComponent();
            _controller = controller;
            _socioMembresiaController = socioMembresiaController;
            _membresiaController = membresiaController;
            _visitaController = visitaController;
            _pagoSocioMembresiaController = pagoSocioMembresiaController;
            dgvSocios.SelectionChanged += dgvSocios_SelectionChanged;
        }

        private async void FrmSocios_Load(object sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            await CargarSociosAsync();
        }

        private async Task CargarSociosAsync()
        {
            try
            {
                var resultado = await _controller.ObtenerSociosAsync(true);
                _listaSocios = resultado.ToList();
                FiltrarBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar socios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarBusqueda()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var filtradas = _listaSocios
                .Where(s => string.IsNullOrEmpty(filtro) ||
                            s.Clave.ToLower().Contains(filtro) ||
                            s.Nombre.ToLower().Contains(filtro) ||
                            s.Apellido.ToLower().Contains(filtro) ||
                            s.NombreCompleto.ToLower().Contains(filtro))
                .ToList();

            dgvSocios.DataSource = null;
            dgvSocios.DataSource = filtradas;
            ConfigurarGrid();
            dgvSocios.ClearSelection();
        }

        private void ConfigurarGrid()
        {
            // Ocultar columnas que no deben verse
            if (dgvSocios.Columns["Foto"] != null) dgvSocios.Columns["Foto"].Visible = false;
            if (dgvSocios.Columns["Observaciones"] != null) dgvSocios.Columns["Observaciones"].Visible = false;
            if (dgvSocios.Columns["Activo"] != null) dgvSocios.Columns["Activo"].Visible = false;

            // Configurar encabezados
            if (dgvSocios.Columns["SocioID"] != null) dgvSocios.Columns["SocioID"].HeaderText = "ID";
            if (dgvSocios.Columns["Clave"] != null) dgvSocios.Columns["Clave"].HeaderText = "Clave";
            if (dgvSocios.Columns["Nombre"] != null) dgvSocios.Columns["Nombre"].HeaderText = "Nombre";
            if (dgvSocios.Columns["Apellido"] != null) dgvSocios.Columns["Apellido"].HeaderText = "Apellido";
            if (dgvSocios.Columns["NombreCompleto"] != null) dgvSocios.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            if (dgvSocios.Columns["Telefono"] != null) dgvSocios.Columns["Telefono"].HeaderText = "Teléfono";
            if (dgvSocios.Columns["Email"] != null) dgvSocios.Columns["Email"].HeaderText = "Correo";
            if (dgvSocios.Columns["Estado"] != null) dgvSocios.Columns["Estado"].HeaderText = "Estado";
            if (dgvSocios.Columns["CreatedAt"] != null) dgvSocios.Columns["CreatedAt"].HeaderText = "Fecha Registro";

            // Mismo esquema de ordenamiento y pesos estilo dgvVisitas
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
        "SocioID",
        "Clave",
        "NombreCompleto",
        "Nombre",
        "Apellido",
        "Telefono",
        "Email",
        "Estado",
        "CreatedAt"
    };

            var pesos = new Dictionary<string, float>
            {
                ["SocioID"] = 45,
                ["Clave"] = 75,
                ["NombreCompleto"] = 175,
                ["Nombre"] = 110,
                ["Apellido"] = 110,
                ["Telefono"] = 100,
                ["Email"] = 140,
                ["Estado"] = 80,
                ["CreatedAt"] = 120
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvSocios.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "NombreCompleto" or "Email" or "Nombre" or "Apellido" => 110,
                    "CreatedAt" => 95,
                    _ => 55
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmSocioModal(_controller);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarSociosAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un socio de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (SocioViewModel)dgvSocios.CurrentRow.DataBoundItem;
            using var modal = new FrmSocioModal(_controller, item.SocioID);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarSociosAsync();
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un socio de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (SocioViewModel)dgvSocios.CurrentRow.DataBoundItem;
            string accion = item.Activo ? "desactivar" : "activar";

            if (FormHelper.ConfirmarAccion($"¿Está seguro de {accion} al socio '{item.NombreCompleto}'?", $"Confirmar {accion.ToUpper()}"))
            {
                try
                {
                    await _controller.CambiarEstadoLogicoAsync(item.SocioID);
                    await CargarSociosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un socio de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (SocioViewModel)dgvSocios.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE al socio '{item.NombreCompleto}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.SocioID);
                    await CargarSociosAsync();
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

        private void dgvSocios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow != null && dgvSocios.CurrentRow.DataBoundItem is SocioViewModel item)
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

        private async void btnMembresia_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un socio de la lista para gestionar su membresía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var socioSeleccionado = (SocioViewModel)dgvSocios.CurrentRow.DataBoundItem;

            // Se pasa la instancia completa de socioSeleccionado (SocioViewModel)
            using var modal = new FrmSocioMembresiaModal(
                _socioMembresiaController,
                _membresiaController,
                _pagoSocioMembresiaController,
                socioSeleccionado);

            if (modal.ShowDialog() == DialogResult.OK)
            {
                // Recargamos la lista por si el estado o la membresía afectó los datos en pantalla
                await CargarSociosAsync();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un socio de la lista para ver su información.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var socioSeleccionado = (SocioViewModel)dgvSocios.CurrentRow.DataBoundItem;

            // Se pasan los dos controladores y el ID del socio
            using var modal = new FrmSocioInfoModal(_controller, _visitaController, socioSeleccionado.SocioID);
            modal.ShowDialog();
        }
    }
}
