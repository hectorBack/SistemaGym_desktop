using Negocio.DTOs;
using Negocio.Exceptions;
using Presentacion.Controller;
using Presentacion.Helpers;
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
        private readonly int _usuarioId;

        // Lo que muestra el historial (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<SocioMembresiaViewModel> _vista = new();

        public FrmSocioMembresiaModal(
            SocioMembresiaController controller,
            MembresiaController membresiaController,
            PagoSocioMembresiaController pagoController,
            SocioViewModel socio,
            int usuarioId)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _membresiaController = membresiaController ?? throw new ArgumentNullException(nameof(membresiaController));
            _pagoController = pagoController ?? throw new ArgumentNullException(nameof(pagoController));
            _socio = socio ?? throw new ArgumentNullException(nameof(socio));
            _usuarioId = usuarioId;

            InitializeComponent();
            ConfigurarColumnas();
            CargarDatosSocio();
        }

        private SocioMembresiaViewModel? MembresiaSeleccionada =>
            dgvHistorial.SelectedRows.Count > 0
                ? dgvHistorial.SelectedRows[0].DataBoundItem as SocioMembresiaViewModel
                : null;

        // ───────────── Carga ─────────────

        private async void FrmSocioMembresiaModal_Load(object? sender, EventArgs e)
        {
            btnEliminarMembresia.Visible = SesionUsuario.TienePermiso("Eliminar");

            // Se fija antes de las cargas asíncronas (antes se hacía al final, ya con la pantalla visible).
            dtpFechaInicio.Value = DateTime.Today;

            await CargarComboMembresiasAsync();
            await CargarHistorialAsync();
        }

        private void CargarDatosSocio()
        {
            lblNombreSocio.Text = _socio.NombreCompleto;
            lblTelefono.Text = string.IsNullOrWhiteSpace(_socio.Telefono) ? "Sin teléfono" : _socio.Telefono;
            txtObservaciones.Text = string.IsNullOrWhiteSpace(_socio.Observaciones)
                ? "Sin observaciones registradas."
                : _socio.Observaciones;

            ImagenHelper.MostrarEn(picFotoSocio, ImagenHelper.CargarFoto(_socio.Foto));
            lblSinFoto.Visible = picFotoSocio.Image == null; // sin imagen, se muestra "Sin foto"
        }

        private async Task CargarComboMembresiasAsync()
        {
            await FormHelper.EjecutarAsync(async () =>
            {
                // Obtener membresías activas
                var membresias = await _membresiaController.ObtenerMembresiasAsync(false);
                if (IsDisposed) return;

                // 🟢 Filtrar y excluir aquellas cuyo nombre contenga "Visita" (usadas solo para visitas casuales)
                var membresiasValidas = membresias
                    .Where(m => !m.Nombre.Contains("Visita", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                cboMembresias.DataSource = membresiasValidas;
                cboMembresias.DisplayMember = nameof(MembresiaViewModel.Nombre);
                cboMembresias.ValueMember = nameof(MembresiaViewModel.MembresiaID);

                ActualizarPrecioYMembresia();
            },
            "No se pudo cargar la lista de membresías.",
            grpAsignarMembresia);
        }

        // ───────────── Historial ─────────────

        // Las columnas se definen una sola vez. Fechas y dinero se enlazan a sus valores reales
        // (no a texto), así se ordenan correctamente.
        private void ConfigurarColumnas()
        {
            dgvHistorial.AutoGenerateColumns = false;

            dgvHistorial.AgregarTexto(nameof(SocioMembresiaViewModel.NombreMembresia), "Membresía", 150, 110);
            dgvHistorial.AgregarTexto(nameof(SocioMembresiaViewModel.FechaInicio), "Inicio", 90, 85, "dd/MM/yyyy");
            dgvHistorial.AgregarTexto(nameof(SocioMembresiaViewModel.FechaFin), "Fin", 90, 85, "dd/MM/yyyy");
            dgvHistorial.AgregarTexto(nameof(SocioMembresiaViewModel.Precio), "Precio", 80, 75, "C2", alinearDerecha: true);
            dgvHistorial.AgregarTexto(nameof(SocioMembresiaViewModel.TotalPagado), "Pagado", 80, 75, "C2", alinearDerecha: true);
            dgvHistorial.AgregarTexto(nameof(SocioMembresiaViewModel.EstadoMembresia), "Estado", 100, 85);
        }

        private async Task CargarHistorialAsync(bool seleccionarLaMasNueva = false)
        {
            int? idObjetivo = MembresiaSeleccionada?.SocioMembresiaID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var historial = await _controller.ObtenerHistorialPorSocioIdAsync(_socio.SocioID);
                if (IsDisposed) return;

                // Se recuerda el orden elegido; si no hay ninguno, lo más reciente primero.
                var columnaOrden = dgvHistorial.SortedColumn;
                var sentidoOrden = dgvHistorial.SortOrder;

                _vista = new ListaOrdenable<SocioMembresiaViewModel>(historial);
                dgvHistorial.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvHistorial.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }
                else
                {
                    dgvHistorial.Sort(dgvHistorial.Columns["col" + nameof(SocioMembresiaViewModel.FechaInicio)]!,
                        ListSortDirection.Descending);
                }

                if (seleccionarLaMasNueva && _vista.Count > 0)
                    idObjetivo = _vista.Max(m => m.SocioMembresiaID); // la que se acaba de asignar

                SeleccionarMembresia(idObjetivo);
            },
            "No se pudo cargar el historial de membresías.",
            panelAccionesHistorial);
        }

        private void SeleccionarMembresia(int? id)
        {
            dgvHistorial.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].SocioMembresiaID != id.Value) continue;

                    dgvHistorial.Rows[i].Selected = true;
                    dgvHistorial.CurrentCell = dgvHistorial.Rows[i].Cells[0];
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        // Pagos y Eliminar solo tienen sentido con una membresía seleccionada.
        private void ActualizarEstadoBotones()
        {
            bool haySeleccion = MembresiaSeleccionada != null;

            btnPagarMembresia.Enabled = haySeleccion;
            btnEliminarMembresia.Enabled = haySeleccion;
        }

        private void dgvHistorial_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        private void dgvHistorial_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            AbrirPagos(_vista[e.RowIndex]);
        }

        // ───────────── Asignar ─────────────

        private void cboMembresias_SelectedIndexChanged(object? sender, EventArgs e) => ActualizarPrecioYMembresia();

        private void ActualizarPrecioYMembresia()
        {
            if (cboMembresias.SelectedItem is MembresiaViewModel membresia)
            {
                // Construir el texto descriptivo dinámico combinando Meses, Semanas y Días según corresponda
                var partesDuracion = new List<string>();

                if (membresia.Meses > 0)
                    partesDuracion.Add($"{membresia.Meses} mes{(membresia.Meses == 1 ? "" : "es")}");

                if (membresia.Semanas > 0)
                    partesDuracion.Add($"{membresia.Semanas} semana{(membresia.Semanas == 1 ? "" : "s")}");

                if (membresia.Dias > 0)
                    partesDuracion.Add($"{membresia.Dias} día{(membresia.Dias == 1 ? "" : "s")}");

                string textoDuracion = partesDuracion.Count > 0
                    ? string.Join(", ", partesDuracion)
                    : $"{membresia.DuracionDias} días";

                // Mostrar precio y el desglose dinámico en la etiqueta
                lblPrecioValor.Text = $"{membresia.Precio:C2}  ·  {textoDuracion}";
                btnAgregarMembresia.Enabled = true;
            }
            else
            {
                lblPrecioValor.Text = "Sin membresías activas";
                btnAgregarMembresia.Enabled = false;
            }
        }

        private async void btnAgregarMembresia_Click(object? sender, EventArgs e)
        {
            if (cboMembresias.SelectedItem is not MembresiaViewModel membresia)
            {
                FormHelper.MostrarAdvertencia("Debe seleccionar una membresía.", "Validación");
                return;
            }

            DateTime fechaInicio = dtpFechaInicio.Value.Date;

            // Asignar genera un cobro pendiente: se confirma para evitar asignaciones por error.
            if (!FormHelper.ConfirmarAccion(
                    $"¿Asignar la membresía '{membresia.Nombre}' ({membresia.Precio:C2}) a {_socio.NombreCompleto} a partir del {fechaInicio:dd/MM/yyyy}?",
                    "Asignar membresía"))
                return;

            var dto = new AsignarMembresiaDto
            {
                SocioID = _socio.SocioID,
                MembresiaID = membresia.MembresiaID,
                FechaInicio = fechaInicio
            };

            bool asignada = await FormHelper.EjecutarAsync(
                () => _controller.AsignarMembresiaAsync(dto),
                "No se pudo asignar la membresía.",
                grpAsignarMembresia);

            if (asignada)
                await CargarHistorialAsync(seleccionarLaMasNueva: true);
        }

        // ───────────── Pagos y eliminación ─────────────

        private void btnPagarMembresia_Click(object? sender, EventArgs e)
        {
            var membresia = MembresiaSeleccionada;
            if (membresia != null)
                AbrirPagos(membresia);
        }

        private async void AbrirPagos(SocioMembresiaViewModel membresia)
        {
            using (var modal = new FrmPagoSocioMembresiaModal(_pagoController, membresia, _usuarioId))
            {
                modal.ShowDialog();
            }

            // Los pagos cambian el total pagado y el estado de la membresía.
            if (!IsDisposed)
                await CargarHistorialAsync();
        }

        private async void btnEliminarMembresia_Click(object? sender, EventArgs e)
        {
            var membresia = MembresiaSeleccionada;
            if (membresia == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de que desea eliminar la membresía '{membresia.NombreMembresia}' asignada el {membresia.FechaInicio:dd/MM/yyyy}?\n\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    destructiva: true))
                return;

            bool eliminada = await FormHelper.EjecutarAsync(
                () => _controller.EliminarMembresiaAsync(membresia.SocioMembresiaID),
                "No se pudo eliminar la membresía. Si ya tiene pagos registrados, anúlelos primero.",
                panelAccionesHistorial);

            if (eliminada)
                await CargarHistorialAsync();
        }

        // ───────────── Cierre ─────────────

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ImagenHelper.MostrarEn(picFotoSocio, null); // libera la foto
            base.OnFormClosed(e);
        }
    }
}
