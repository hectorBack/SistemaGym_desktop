using Negocio.DTOs;
using Presentacion.Controller;
using Presentacion.Forms.Socios;
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
    public partial class FrmRegistroVisita : Form
    {
        private readonly VisitaController _visitaController;
        private readonly SocioController _socioController;
        private readonly SocioMembresiaController _socioMembresiaController;
        private readonly MembresiaController _membresiaController;
        private readonly PagoSocioMembresiaController _pagoSocioMembresiaController;
        private int? _socioIdActual; 
        private int? _ultimaVisitaId;

        public FrmRegistroVisita(VisitaController visitaController, 
            SocioController socioController,
            SocioMembresiaController socioMembresiaController,
            MembresiaController membresiaController,
            PagoSocioMembresiaController pagoSocioMembresiaController)
        {
            InitializeComponent();
            _visitaController = visitaController;
            _socioController = socioController;
            _socioMembresiaController = socioMembresiaController;
            _membresiaController = membresiaController;
            _pagoSocioMembresiaController = pagoSocioMembresiaController;
        }

        private void FrmRegistroVisita_Load(object sender, EventArgs e)
        {
            InicializarTablaAsistencias();
            btnInformacion.Enabled = false; // Deshabilitado por defecto hasta que exista un socio válido
            btnCancelarVisita.Enabled = false;
            btnMembresias.Enabled = false;

            lblDeuda.ForeColor = Color.White; // O el color visible deseado en reposo
            lblDeuda.BringToFront();
            txtClave.Focus();
        }

        private void InicializarTablaAsistencias()
        {
            dgvAsistenciasSemana.Columns.Clear();
            dgvAsistenciasSemana.Rows.Clear();

            dgvAsistenciasSemana.Columns.Add("colLunes", "Lunes");
            dgvAsistenciasSemana.Columns.Add("colMartes", "Martes");
            dgvAsistenciasSemana.Columns.Add("colMiercoles", "Miércoles");
            dgvAsistenciasSemana.Columns.Add("colJueves", "Jueves");
            dgvAsistenciasSemana.Columns.Add("colViernes", "Viernes");
            dgvAsistenciasSemana.Columns.Add("colSabado", "Sábado");
            dgvAsistenciasSemana.Columns.Add("colDomingo", "Domingo");

            dgvAsistenciasSemana.Rows.Add("", "", "", "", "", "", "");
        }

        private async void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await ProcesarIngresoAsync();
            }
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            await ProcesarIngresoAsync();
        }

        private async Task ProcesarIngresoAsync()
        {
            string clave = txtClave.Text.Trim();
            if (string.IsNullOrEmpty(clave)) return;

            var resultado = await _visitaController.ProcesarAccesoRapidoAsync(clave);

            if (!resultado.Exitoso)
            {
                MostrarEstadoError(resultado.MensajeError);
            }
            else
            {
                MostrarEstadoExito(resultado);
            }

            PrepararSiguienteLectura();
        }

        private void MostrarEstadoError(string mensajeError)
        {
            _socioIdActual = null; // Limpiar ID de socio
            _ultimaVisitaId = null;
            btnInformacion.Enabled = false; // Deshabilitar el botón de información
            btnCancelarVisita.Enabled = false;
            btnMembresias.Enabled = false;

            lblEstadoAcceso.Text = mensajeError.ToUpper();
            lblEstadoAcceso.ForeColor = Color.OrangeRed;
            lblNombreSocio.Text = "SOCIO NO ENCONTRADO";
            lblMembresia.Text = "N/A";
            lblVencimiento.Text = "N/A";
            lblDeuda.Text = "Deuda: $0.00";
            lblDeuda.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            picFoto.Image = null;
            LimpiarAsistenciasSemana();
        }

        private void MostrarEstadoExito(AccesoResultadoViewModel resultado)
        {
            _socioIdActual = resultado.SocioID; // Se guarda el SocioID retornado por la consulta
            _ultimaVisitaId = resultado.VisitaID;

            btnInformacion.Enabled = (_socioIdActual.HasValue && _socioIdActual.Value > 0); // Habilitar el botón
            btnMembresias.Enabled = (_socioIdActual.HasValue && _socioIdActual.Value > 0);
            btnCancelarVisita.Enabled = (_ultimaVisitaId.HasValue && _ultimaVisitaId.Value > 0); // Habilitar cancelación

            lblNombreSocio.Text = resultado.NombreCompleto;
            lblMembresia.Text = resultado.NombreMembresia;
            lblVencimiento.Text = resultado.FechaVencimientoTexto;
            picFoto.Image = resultado.ObtenerImagenFoto();

            lblDeuda.Text = $"Deuda: {resultado.Deuda:C2}";
            lblDeuda.ForeColor = resultado.Deuda > 0 ? Color.Red : Color.DarkGreen;

            if (resultado.MembresiaVigente || resultado.EsVisitaCasual)
            {
                lblEstadoAcceso.Text = "ACCESO PERMITIDO";
                lblEstadoAcceso.ForeColor = Color.LightGreen;
            }
            else
            {
                lblEstadoAcceso.Text = "MEMBRESÍA VENCIDA";
                lblEstadoAcceso.ForeColor = Color.OrangeRed;
            }

            PintarAsistenciasSemana(resultado.AsistenciasSemana);
        }

        private void PrepararSiguienteLectura()
        {
            txtClave.Clear();
            txtClave.Focus();
        }

        // Evento del Botón Información
        private void btnInformacion_Click(object sender, EventArgs e)
        {
            if (!_socioIdActual.HasValue || _socioIdActual.Value <= 0)
            {
                MessageBox.Show(
                    "Primero debes consultar un socio válido para ver su información.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            using (var modal = new FrmSocioInfoModal(_socioController, _visitaController, _socioIdActual.Value))
            {
                modal.ShowDialog(this);
            }
        }

        private void PintarAsistenciasSemana(Dictionary<DayOfWeek, string> asistencias)
        {
            LimpiarAsistenciasSemana();

            if (asistencias == null || asistencias.Count == 0) return;

            var fila = dgvAsistenciasSemana.Rows[0];

            if (asistencias.ContainsKey(DayOfWeek.Monday)) fila.Cells["colLunes"].Value = asistencias[DayOfWeek.Monday];
            if (asistencias.ContainsKey(DayOfWeek.Tuesday)) fila.Cells["colMartes"].Value = asistencias[DayOfWeek.Tuesday];
            if (asistencias.ContainsKey(DayOfWeek.Wednesday)) fila.Cells["colMiercoles"].Value = asistencias[DayOfWeek.Wednesday];
            if (asistencias.ContainsKey(DayOfWeek.Thursday)) fila.Cells["colJueves"].Value = asistencias[DayOfWeek.Thursday];
            if (asistencias.ContainsKey(DayOfWeek.Friday)) fila.Cells["colViernes"].Value = asistencias[DayOfWeek.Friday];
            if (asistencias.ContainsKey(DayOfWeek.Saturday)) fila.Cells["colSabado"].Value = asistencias[DayOfWeek.Saturday];
            if (asistencias.ContainsKey(DayOfWeek.Sunday)) fila.Cells["colDomingo"].Value = asistencias[DayOfWeek.Sunday];
        }

        private void LimpiarAsistenciasSemana()
        {
            if (dgvAsistenciasSemana.Rows.Count > 0)
            {
                for (int i = 0; i < dgvAsistenciasSemana.Columns.Count; i++)
                {
                    dgvAsistenciasSemana.Rows[0].Cells[i].Value = "";
                }
            }
        }

        private async void btnCancelarVisita_Click(object sender, EventArgs e)
        {
            if (!_ultimaVisitaId.HasValue || _ultimaVisitaId.Value <= 0)
            {
                MessageBox.Show("No hay ningún registro de visita reciente para cancelar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro de que desea cancelar esta visita recién registrada?",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await _visitaController.CancelarVisitaAsync(_ultimaVisitaId.Value, null);

                    MessageBox.Show("La visita se ha cancelado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Opcional: Limpiar la pantalla tras cancelar
                    MostrarEstadoError("VISITA CANCELADA");
                    lblEstadoAcceso.ForeColor = Color.Orange;
                    PrepararSiguienteLectura();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnMembresias_Click(object sender, EventArgs e)
        {
            if (!_socioIdActual.HasValue || _socioIdActual.Value <= 0)
            {
                MessageBox.Show(
                    "Primero debes consultar un socio válido para gestionar sus membresías.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            try
            {
                // 1. Obtener la información completa del socio (SocioViewModel)
                var socioDto = await _socioController.ObtenerPorIdAsync(_socioIdActual.Value);

                if (socioDto == null)
                {
                    MessageBox.Show("No se encontró la información detallada del socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Si ObtenerPorIdAsync retorna SocioDto, mapealo a SocioViewModel (o usa el ViewModel si tu controller ya lo devuelve)
                var socioViewModel = new SocioViewModel
                {
                    SocioID = socioDto.SocioID,
                    Clave = socioDto.Clave,
                    Nombre = socioDto.Nombre,
                    Apellido = socioDto.Apellido,
                    Telefono = socioDto.Telefono,
                    Email = socioDto.Email,
                    Foto = socioDto.Foto,
                    Activo = socioDto.Activo
                };

                // 2. Abrir el modal pasando todos los argumentos requeridos
                using (var modal = new FrmSocioMembresiaModal(
                    _socioMembresiaController,
                    _membresiaController,
                    _pagoSocioMembresiaController,
                    socioViewModel))
                {
                    modal.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al abrir el módulo de membresías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
