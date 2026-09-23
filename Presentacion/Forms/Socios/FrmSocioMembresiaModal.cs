using Negocio.DTOs;
using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.ViewModels;
using Presentacion.ViewModels.TuProyecto.Presentacion.ViewModels;
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
    public partial class FrmSocioMembresiaModal : Form
    {
        private readonly SocioMembresiaController _controller;
        private readonly MembresiaController _membresiaController;
        private readonly PagoSocioMembresiaController _pagoController;
        private readonly SocioViewModel _socio;
        private List<MembresiaViewModel> _listaMembresias = new();

        public FrmSocioMembresiaModal(
            SocioMembresiaController controller,
            MembresiaController membresiaController,
            PagoSocioMembresiaController pagoController,
            SocioViewModel socio)
        {
            InitializeComponent();
            _controller = controller;
            _membresiaController = membresiaController;
            _pagoController = pagoController;
            _socio = socio;
        }

        private async void FrmSocioMembresiaModal_Load(object sender, EventArgs e)
        {
            CargarDatosSocio();
            await CargarComboMembresiasAsync();
            await CargarHistorialMembresiasAsync();
            dtpFechaInicio.Value = DateTime.Now;
        }

        private void CargarDatosSocio()
        {
            lblNombreSocio.Text = _socio.NombreCompleto;
            lblTelefono.Text = string.IsNullOrEmpty(_socio.Telefono) ? "Sin Teléfono" : _socio.Telefono;
            txtObservaciones.Text = string.IsNullOrEmpty(_socio.Observaciones) ? "Sin observaciones registradas." : _socio.Observaciones;

            if (!string.IsNullOrEmpty(_socio.Foto) && File.Exists(_socio.Foto))
            {
                picFotoSocio.Image = Image.FromFile(_socio.Foto);
            }
            else
            {
                picFotoSocio.Image = null;
            }
        }

        private async Task CargarComboMembresiasAsync()
        {
            try
            {
                var membresias = await _membresiaController.ObtenerMembresiasAsync(true);
                _listaMembresias = membresias.ToList();

                cboMembresias.DataSource = _listaMembresias;
                cboMembresias.DisplayMember = "Nombre";
                cboMembresias.ValueMember = "MembresiaID";

                ActualizarPrecioYMembresia();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarHistorialMembresiasAsync()
        {
            try
            {
                var historial = await _controller.ObtenerHistorialPorSocioIdAsync(_socio.SocioID);
                dgvHistorial.DataSource = null;
                dgvHistorial.DataSource = historial.ToList();
                ConfigurarGridHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridHistorial()
        {
            // 1. Ocultar IDs, campos nativos sin formatear y propiedades internas
            if (dgvHistorial.Columns["SocioMembresiaID"] != null) dgvHistorial.Columns["SocioMembresiaID"].Visible = false;
            if (dgvHistorial.Columns["SocioID"] != null) dgvHistorial.Columns["SocioID"].Visible = false;
            if (dgvHistorial.Columns["MembresiaID"] != null) dgvHistorial.Columns["MembresiaID"].Visible = false;
            if (dgvHistorial.Columns["FechaInicio"] != null) dgvHistorial.Columns["FechaInicio"].Visible = false;
            if (dgvHistorial.Columns["FechaFin"] != null) dgvHistorial.Columns["FechaFin"].Visible = false;
            if (dgvHistorial.Columns["Precio"] != null) dgvHistorial.Columns["Precio"].Visible = false;
            if (dgvHistorial.Columns["TotalPagado"] != null) dgvHistorial.Columns["TotalPagado"].Visible = false;
            if (dgvHistorial.Columns["CreatedAtTexto"] != null) dgvHistorial.Columns["CreatedAtTexto"].Visible = false;
            if (dgvHistorial.Columns["UpdatedAt"] != null) dgvHistorial.Columns["UpdatedAt"].Visible = false;
            if (dgvHistorial.Columns["UpdatedAtTexto"] != null) dgvHistorial.Columns["UpdatedAtTexto"].Visible = false;

            // Ocultar la columna de Estado vieja ("Activa"/"Inactiva")
            if (dgvHistorial.Columns["Estado"] != null) dgvHistorial.Columns["Estado"].Visible = false;

            // 2. Configurar las columnas visibles
            if (dgvHistorial.Columns["NombreMembresia"] != null)
                dgvHistorial.Columns["NombreMembresia"].HeaderText = "Membresía";

            if (dgvHistorial.Columns["FechaInicioTexto"] != null)
                dgvHistorial.Columns["FechaInicioTexto"].HeaderText = "Fecha Inicio";

            if (dgvHistorial.Columns["FechaFinTexto"] != null)
                dgvHistorial.Columns["FechaFinTexto"].HeaderText = "Fecha Fin";

            if (dgvHistorial.Columns["PrecioTexto"] != null)
            {
                dgvHistorial.Columns["PrecioTexto"].Visible = true;
                dgvHistorial.Columns["PrecioTexto"].HeaderText = "Precio";
            }

            if (dgvHistorial.Columns["CreatedAt"] != null)
            {
                dgvHistorial.Columns["CreatedAt"].Visible = true;
                dgvHistorial.Columns["CreatedAt"].HeaderText = "Fecha Asignación";
                dgvHistorial.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // 3. Mostrar la nueva columna calculada "EstadoMembresia"
            if (dgvHistorial.Columns["EstadoMembresia"] != null)
            {
                dgvHistorial.Columns["EstadoMembresia"].Visible = true;
                dgvHistorial.Columns["EstadoMembresia"].HeaderText = "Estado Membresía";
            }
        }

        private void cboMembresias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecioYMembresia();
        }

        private void ActualizarPrecioYMembresia()
        {
            if (cboMembresias.SelectedItem is MembresiaViewModel membresiaSeleccionada)
            {
                // Muestra el precio formateado en el Label
                lblPrecioValor.Text = membresiaSeleccionada.Precio.ToString("C2");
            }
            else
            {
                lblPrecioValor.Text = "$0.00";
            }
        }

        private async void btnAgregarMembresia_Click(object sender, EventArgs e)
        {
            if (cboMembresias.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una membresía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int membresiaId = (int)cboMembresias.SelectedValue;

                var dto = new AsignarMembresiaDto
                {
                    SocioID = _socio.SocioID,
                    MembresiaID = membresiaId,
                    FechaInicio = dtpFechaInicio.Value
                };

                await _controller.AsignarMembresiaAsync(dto);

                MessageBox.Show("Membresía asignada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar el historial para visualización inmediata
                await CargarHistorialMembresiasAsync();
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

        private async void btnPagarMembresia_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null || dgvHistorial.CurrentRow.DataBoundItem is not SocioMembresiaViewModel membresiaSeleccionada)
            {
                MessageBox.Show("Por favor, seleccione una membresía del historial para gestionar sus pagos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frmPago = new FrmPagoSocioMembresiaModal(_pagoController, membresiaSeleccionada))
            {
                frmPago.ShowDialog();
            }

            // Recargar el historial tras cerrar el modal para reflejar posibles cambios de estado de pago
            await CargarHistorialMembresiasAsync();
        }

        private async void btnEliminarMembresia_Click(object sender, EventArgs e)
        {
            // 1. Validar selección en la grilla
            if (dgvHistorial.CurrentRow == null || dgvHistorial.CurrentRow.DataBoundItem is not SocioMembresiaViewModel membresiaSeleccionada)
            {
                MessageBox.Show("Por favor, seleccione una membresía del historial que desee eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Confirmación previa
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar la membresía '{membresiaSeleccionada.NombreMembresia}' asignada el {membresiaSeleccionada.FechaInicioTexto}?\n\nEsta acción no se podrá deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                // 3. Ejecutar eliminación mediante el controlador
                // (Asegúrate de que tu controlador contenga el método de eliminación por ID)
                await _controller.EliminarMembresiaAsync(membresiaSeleccionada.SocioMembresiaID);

                MessageBox.Show("Membresía eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Refrescar la grilla
                await CargarHistorialMembresiasAsync();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar eliminar la membresía: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
