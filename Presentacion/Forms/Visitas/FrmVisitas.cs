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

namespace Presentacion.Forms.Visitas
{
    public partial class FrmVisitas : Form
    {
        private readonly VisitaController _controller;
        private readonly MembresiaController _membresiaController; 
        private List<VisitaViewModel> _listaVisitas = new();

        public FrmVisitas(VisitaController controller, MembresiaController membresiaController)
        {
            InitializeComponent();
            _controller = controller;
            _membresiaController = membresiaController;
        }

        private async void FrmVisitas_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        private async Task CargarVisitasAsync()
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            await BuscarPorFechasAsync();
        }

        private async Task BuscarPorFechasAsync()
        {
            try
            {
                // Cubre las 24 horas del día final (hasta las 23:59:59.999)
                DateTime inicio = dtpFechaInicio.Value.Date;
                DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

                var resultado = await _controller.ObtenerPorRangoFechasAsync(inicio, fin);
                _listaVisitas = resultado.ToList();
                FiltrarBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar visitas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            await BuscarPorFechasAsync();
        }

        private void FiltrarBusqueda()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var filtradas = _listaVisitas
                .Where(v => string.IsNullOrEmpty(filtro) ||
                            v.Clave.ToLower().Contains(filtro) ||
                            v.NombreCompleto.ToLower().Contains(filtro) ||
                            v.TipoAcceso.ToLower().Contains(filtro) ||
                            (v.NombreMembresia != null && v.NombreMembresia.ToLower().Contains(filtro)))
                .ToList();

            dgvVisitas.DataSource = null;
            dgvVisitas.DataSource = filtradas;
            ConfigurarGrid();
            dgvVisitas.ClearSelection();
        }

        private void ConfigurarGrid()
        {
            if (dgvVisitas.Columns["VisitaID"] != null)
                dgvVisitas.Columns["VisitaID"].HeaderText = "ID";

            if (dgvVisitas.Columns["Clave"] != null)
                dgvVisitas.Columns["Clave"].HeaderText = "Clave";

            if (dgvVisitas.Columns["NombreCompleto"] != null)
                dgvVisitas.Columns["NombreCompleto"].HeaderText = "Nombre / Socio";

            if (dgvVisitas.Columns["TipoAcceso"] != null)
                dgvVisitas.Columns["TipoAcceso"].HeaderText = "Tipo Acceso";

            if (dgvVisitas.Columns["NombreMembresia"] != null)
                dgvVisitas.Columns["NombreMembresia"].HeaderText = "Membresía / Pase";

            if (dgvVisitas.Columns["MontoPagado"] != null)
            {
                dgvVisitas.Columns["MontoPagado"].HeaderText = "Monto Pagado";
                dgvVisitas.Columns["MontoPagado"].DefaultCellStyle.Format = "C2";
            }

            if (dgvVisitas.Columns["FechaRegistro"] != null)
                dgvVisitas.Columns["FechaRegistro"].HeaderText = "Fecha Entrada";

            if (dgvVisitas.Columns["Observaciones"] != null)
                dgvVisitas.Columns["Observaciones"].HeaderText = "Observaciones";

            // Ocultar columnas secundarias, auxiliares o repetidas
            if (dgvVisitas.Columns["SocioID"] != null) dgvVisitas.Columns["SocioID"].Visible = false;
            if (dgvVisitas.Columns["MembresiaID"] != null) dgvVisitas.Columns["MembresiaID"].Visible = false;
            if (dgvVisitas.Columns["Nombre"] != null) dgvVisitas.Columns["Nombre"].Visible = false;
            if (dgvVisitas.Columns["Apellido"] != null) dgvVisitas.Columns["Apellido"].Visible = false;
            if (dgvVisitas.Columns["Telefono"] != null) dgvVisitas.Columns["Telefono"].Visible = false;
            if (dgvVisitas.Columns["Activo"] != null) dgvVisitas.Columns["Activo"].Visible = false;
            if (dgvVisitas.Columns["Estado"] != null) dgvVisitas.Columns["Estado"].Visible = false;
            if (dgvVisitas.Columns["CreatedAt"] != null) dgvVisitas.Columns["CreatedAt"].Visible = false;

            // --- COLUMNAS SOBRANTES A OCULTAR ---
            if (dgvVisitas.Columns["FechaTexto"] != null) dgvVisitas.Columns["FechaTexto"].Visible = false;
            if (dgvVisitas.Columns["HoraEntrada"] != null) dgvVisitas.Columns["HoraEntrada"].Visible = false;
            if (dgvVisitas.Columns["DiaSemana"] != null) dgvVisitas.Columns["DiaSemana"].Visible = false;
            if (dgvVisitas.Columns["DiaSen"] != null) dgvVisitas.Columns["DiaSen"].Visible = false; // Según el encabezado de tu imagen anterior

            ConfigurarColumnasVisibles();
        }

        private void ConfigurarColumnasVisibles()
        {
            dgvVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
                "VisitaID",
                "Clave",
                "NombreCompleto",
                "TipoAcceso",
                "NombreMembresia",
                "MontoPagado",
                "FechaRegistro",
                "Estado",
                "Observaciones"
            };

            var pesos = new Dictionary<string, float>
            {
                ["VisitaID"] = 45,
                ["Clave"] = 75,
                ["NombreCompleto"] = 175,
                ["TipoAcceso"] = 105,
                ["NombreMembresia"] = 155,
                ["MontoPagado"] = 95,
                ["FechaRegistro"] = 135,
                ["Estado"] = 80,
                ["Observaciones"] = 120
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvVisitas.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "NombreCompleto" or "NombreMembresia" or "Observaciones" => 110,
                    "FechaRegistro" => 95,
                    _ => 55
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmVisitaModal(_controller, _membresiaController);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarVisitasAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVisitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro de visita para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (VisitaViewModel)dgvVisitas.CurrentRow.DataBoundItem;
            using var modal = new FrmVisitaModal(_controller, _membresiaController, item.VisitaID);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarVisitasAsync();
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvVisitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una visita de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (VisitaViewModel)dgvVisitas.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE el registro de acceso de '{item.NombreCompleto}'?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.VisitaID);
                    await CargarVisitasAsync();
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

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }
    }
}
