using Negocio.DTOs;
using Negocio.Exceptions;
using Presentacion.Controller;
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

namespace Presentacion.Forms.Visitas
{
    public partial class FrmVisitaModal : Form
    {
        private readonly VisitaController _controller;
        private readonly MembresiaController _membresiaController;
        private readonly int? _visitaId;

        public FrmVisitaModal(VisitaController controller, MembresiaController membresiaController, int? visitaId = null)
        {
            InitializeComponent();
            _controller = controller;
            _membresiaController = membresiaController;
            _visitaId = visitaId;
        }

        private async void FrmVisitaModal_Load(object sender, EventArgs e)
        {
            await CargarMembresiasAsync();

            if (_visitaId.HasValue)
            {
                lblTitulo.Text = "Editar Visita";
                txtClave.Enabled = false; // La clave no debe modificarse al editar
                cmbMembresias.Enabled = false; // Tampoco el tipo de pase/membresía
                await CargarDatosVisitaAsync(_visitaId.Value);
            }
            else
            {
                lblTitulo.Text = "Nueva Visita";
                txtClave.Text = "100"; // Valor por defecto para visita casual
                HabilitarCamposSegunClave();
            }
        }

        private async Task CargarMembresiasAsync()
        {
            try
            {
                var membresias = await _membresiaController.ObtenerMembresiasAsync(incluirInactivas: false);

                // CORRECCIÓN: Definir DisplayMember y ValueMember ANTES de asignar el DataSource
                cmbMembresias.DataSource = null;
                cmbMembresias.DisplayMember = "Nombre";
                cmbMembresias.ValueMember = "MembresiaID";
                cmbMembresias.DataSource = membresias.ToList();
                cmbMembresias.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDatosVisitaAsync(int id)
        {
            try
            {
                var visita = await _controller.ObtenerPorIdAsync(id);
                if (visita != null)
                {
                    txtClave.Text = visita.Clave;
                    txtNombre.Text = visita.Nombre;
                    txtApellido.Text = visita.Apellido;
                    txtTelefono.Text = visita.Telefono;
                    txtObservaciones.Text = visita.Observaciones;
                    chkActivo.Checked = visita.Activo;

                    if (visita.MembresiaID.HasValue)
                    {
                        cmbMembresias.SelectedValue = visita.MembresiaID.Value;
                    }

                    HabilitarCamposSegunClave();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la visita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            HabilitarCamposSegunClave();
        }

        private void HabilitarCamposSegunClave()
        {
            if (_visitaId.HasValue) return; // Si es edición, no cambia dinámicamente

            bool esCasual = txtClave.Text.Trim() == "100";

            // Si es pase casual ("100"), requiere datos del visitante y selección de pase/membresía
            txtNombre.Enabled = esCasual;
            txtApellido.Enabled = esCasual;
            txtTelefono.Enabled = esCasual;
            cmbMembresias.Enabled = esCasual;

            if (!esCasual)
            {
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();
                cmbMembresias.SelectedIndex = -1;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.EsTextoVacio(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar la clave del socio o '100' para visita casual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clave = txtClave.Text.Trim();

            if (clave == "100")
            {
                if (ValidationHelper.EsTextoVacio(txtNombre.Text))
                {
                    MessageBox.Show("Para visitas casuales es obligatorio ingresar un nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbMembresias.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una membresía o pase de visita.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                if (_visitaId.HasValue)
                {
                    var updateDto = new VisitaUpdateDto
                    {
                        VisitaID = _visitaId.Value,
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text.Trim(),
                        Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text.Trim(),
                        Activo = chkActivo.Checked
                    };

                    await _controller.ActualizarAsync(updateDto);
                }
                else
                {
                    // CORRECCIÓN: Extracción segura del ID seleccionado
                    int? idMembresiaSeleccionada = null;
                    if (cmbMembresias.SelectedValue is int idInt)
                    {
                        idMembresiaSeleccionada = idInt;
                    }
                    else if (cmbMembresias.SelectedValue != null && int.TryParse(cmbMembresias.SelectedValue.ToString(), out int idParsed))
                    {
                        idMembresiaSeleccionada = idParsed;
                    }

                    var createDto = new VisitaCreateDto
                    {
                        Clave = clave,
                        MembresiaID = idMembresiaSeleccionada,
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text.Trim(),
                        Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text.Trim()
                    };

                    await _controller.RegistrarVisitaAsync(createDto);
                }

                MessageBox.Show("Visita registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // CORRECCIÓN: Captura la excepción interna real de MySQL / Entity Framework
                string detalle = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Ocurrió un error inesperado: {detalle}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
