using Negocio.Exceptions;
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
    public partial class FrmSocioInfoModal : Form
    {
        // Las fuentes de las pestañas se crean una sola vez
        // (antes se creaba una nueva en cada repintado y nunca se liberaba).
        private static readonly Font FuenteTab = new("Segoe UI", 9.5F);
        private static readonly Font FuenteTabActiva = new("Segoe UI", 9.5F, FontStyle.Bold);

        private readonly SocioController _socioController;
        private readonly VisitaController _visitaController;
        private readonly int _socioId;

        public FrmSocioInfoModal(SocioController socioController, VisitaController visitaController, int socioId)
        {
            _socioController = socioController ?? throw new ArgumentNullException(nameof(socioController));
            _visitaController = visitaController ?? throw new ArgumentNullException(nameof(visitaController));
            _socioId = socioId;

            InitializeComponent();
            ConfigurarColumnas();
        }

        private VisitaViewModel? VisitaSeleccionada =>
            dgvHistorialVisitas.SelectedRows.Count > 0
                ? dgvHistorialVisitas.SelectedRows[0].DataBoundItem as VisitaViewModel
                : null;

        // ───────────── Columnas ─────────────

        // Se definen una sola vez. Los nombres del historial de membresías son los mismos que ya usabas;
        // si prefieres el estado calculado (vigente/vencida) en lugar de "Estado", cambia "Estado" por "EstadoMembresia".
        private void ConfigurarColumnas()
        {
            dgvHistorialMembresias.AutoGenerateColumns = false;
            dgvHistorialMembresias.AgregarTexto("NombreMembresia", "Membresía", 140, 100);
            dgvHistorialMembresias.AgregarTexto("FechaInicio", "Fecha inicio", 135, 115, "dd/MM/yyyy");
            dgvHistorialMembresias.AgregarTexto("FechaFin", "Fecha fin", 135, 115, "dd/MM/yyyy");
            dgvHistorialMembresias.AgregarTexto("Precio", "Precio", 85, 75, "C2", alinearDerecha: true);
            dgvHistorialMembresias.AgregarTexto("Estado", "Estado", 95, 80);

            dgvHistorialVisitas.AutoGenerateColumns = false;

            // FechaRegistro llega como texto ya formateado: ordenarlo alfabéticamente no tendría sentido,
            // así que se respeta el orden en que lo entrega el servidor.
            dgvHistorialVisitas.AgregarTexto(nameof(VisitaViewModel.FechaRegistro), "Fecha de visita", 160, 140)
                .SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvHistorialVisitas.AgregarTexto(nameof(VisitaViewModel.TipoAcceso), "Tipo de acceso", 130, 110);
            dgvHistorialVisitas.AgregarTexto(nameof(VisitaViewModel.NombreMembresia), "Membresía", 160, 110);
        }

        // ───────────── Carga ─────────────

        private async void FrmSocioInfoModal_Load(object? sender, EventArgs e)
        {
            // Por defecto se muestran las visitas del día.
            dtpVisitaDesde.Value = DateTime.Today;
            dtpVisitaHasta.Value = DateTime.Today;

            bool cargado = await FormHelper.EjecutarAsync(async () =>
            {
                var socio = await _socioController.ObtenerDetalleSocioAsync(_socioId)
                            ?? throw new BusinessException("No se encontró la información del socio.");

                if (IsDisposed) return;

                lblClave.Text = socio.Clave;
                lblNombreCompleto.Text = socio.NombreCompleto;
                lblTelefono.Text = string.IsNullOrWhiteSpace(socio.Telefono) ? "N/A" : socio.Telefono;
                lblEmail.Text = string.IsNullOrWhiteSpace(socio.Email) ? "N/A" : socio.Email;

                lblFechaNacimiento.Text = socio.FechaNacimiento.HasValue
                    ? socio.FechaNacimiento.Value.ToString("dd/MM/yyyy")
                    : "N/A";

                lblEstado.Text = socio.Activo ? "ACTIVO" : "INACTIVO";
                lblEstado.ForeColor = socio.Activo ? Tema.Exito : Tema.Peligro;

                ImagenHelper.MostrarEn(picFotoSocio, ImagenHelper.CargarFoto(socio.Foto));

                dgvHistorialMembresias.DataSource = Ordenable(socio.HistorialMembresias);
                dgvHistorialMembresias.ClearSelection();

                await ConsultarVisitasAsync();
            },
            "No se pudo cargar la información del socio.",
            tabControlDetalles);

            // Si no se pudo cargar, no tiene sentido dejar la ventana abierta.
            if (!cargado && !IsDisposed)
                DialogResult = DialogResult.Cancel;
        }

        // Permite crear la lista ordenable sin conocer el tipo de elemento del historial.
        private static ListaOrdenable<T> Ordenable<T>(IEnumerable<T> elementos) => new(elementos);

        // ───────────── Visitas ─────────────

        // Consulta y enlaza (sin manejo de errores propio: lo hacen quienes la llaman).
        private async Task ConsultarVisitasAsync()
        {
            DateTime desde = dtpVisitaDesde.Value.Date;
            DateTime hasta = dtpVisitaHasta.Value.Date.AddDays(1).AddTicks(-1);

            var visitas = await _visitaController.ObtenerPorSocioYFechasAsync(_socioId, desde, hasta);
            if (IsDisposed) return;

            dgvHistorialVisitas.DataSource = new ListaOrdenable<VisitaViewModel>(visitas);
            dgvHistorialVisitas.ClearSelection();
            ActualizarEstadoBotones();
        }

        private async Task CargarVisitasAsync()
        {
            await FormHelper.EjecutarAsync(
                ConsultarVisitasAsync,
                "No se pudieron cargar las visitas.",
                panelFiltrosVisitas);
        }

        private async void btnFiltrarVisitas_Click(object? sender, EventArgs e)
        {
            // Se comparan solo las fechas (antes se comparaba también la hora y podía dar falsos avisos).
            if (dtpVisitaDesde.Value.Date > dtpVisitaHasta.Value.Date)
            {
                FormHelper.MostrarAdvertencia("La fecha inicial no puede ser posterior a la fecha final.", "Rango de fechas");
                return;
            }

            await CargarVisitasAsync();
        }

        private void dgvHistorialVisitas_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        private void ActualizarEstadoBotones() => btnEliminarVisita.Enabled = VisitaSeleccionada != null;

        private async void btnEliminarVisita_Click(object? sender, EventArgs e)
        {
            var visita = VisitaSeleccionada;
            if (visita == null) return;

            string nombreSocio = string.IsNullOrWhiteSpace(visita.NombreCompleto) ? "este socio" : visita.NombreCompleto;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar permanentemente la visita de '{nombreSocio}' registrada el {visita.FechaRegistro}?\n\nEsta acción no se puede deshacer.",
                    "Eliminar visita",
                    destructiva: true))
                return;

            bool eliminada = await FormHelper.EjecutarAsync(
                () => _visitaController.EliminarFisicoAsync(visita.VisitaID),
                "No se pudo eliminar la visita.",
                panelFiltrosVisitas);

            if (eliminada)
                await CargarVisitasAsync();
        }

        // ───────────── Pestañas (dibujo) ─────────────

        private void tabControlDetalles_DrawItem(object? sender, DrawItemEventArgs e)
        {
            var pestanas = tabControlDetalles;
            var pestana = pestanas.TabPages[e.Index];
            Rectangle area = pestanas.GetTabRect(e.Index);
            bool seleccionada = pestanas.SelectedIndex == e.Index;

            // Una sola vez: limpiar la franja vacía a la derecha de las pestañas.
            if (e.Index == pestanas.TabCount - 1)
            {
                var ultima = pestanas.GetTabRect(pestanas.TabCount - 1);
                var franja = new Rectangle(ultima.Right, 0, pestanas.Width - ultima.Right, ultima.Height + 2);

                using var pincelFondo = new SolidBrush(Tema.Fondo);
                e.Graphics.FillRectangle(pincelFondo, franja);
            }

            Color fondo = seleccionada ? Tema.AzulBase : Tema.FilaAlterna;
            Color texto = seleccionada ? Tema.Acento : Tema.Texto;
            Color borde = seleccionada ? Tema.Acento : Tema.AzulBase;

            using (var pincel = new SolidBrush(fondo))
                e.Graphics.FillRectangle(pincel, area);

            using (var lapiz = new Pen(borde, 1))
                e.Graphics.DrawRectangle(lapiz, area.X, area.Y, area.Width - 1, area.Height - 1);

            TextRenderer.DrawText(
                e.Graphics,
                pestana.Text,
                seleccionada ? FuenteTabActiva : FuenteTab,
                area,
                texto,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // ───────────── Cierre ─────────────

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ImagenHelper.MostrarEn(picFotoSocio, null); // libera la foto
            base.OnFormClosed(e);
        }
    }
}