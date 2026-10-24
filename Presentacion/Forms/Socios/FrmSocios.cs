using Presentacion.Controller;
using Presentacion.Helpers;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Socios
{
    public partial class FrmSocios : Form
    {
        private readonly SocioController _controller;
        private readonly SocioMembresiaController _socioMembresiaController;
        private readonly MembresiaController _membresiaController;
        private readonly PagoSocioMembresiaController _pagoSocioMembresiaController;
        private readonly VisitaController _visitaController;

        private List<SocioViewModel> _todos = new();                 // todos los socios cargados
        private ListaOrdenable<SocioViewModel> _vista = new();       // lo que muestra el grid (ya filtrado)

        public FrmSocios(
            SocioController controller,
            SocioMembresiaController socioMembresiaController,
            MembresiaController membresiaController,
            PagoSocioMembresiaController pagoSocioMembresiaController,
            VisitaController visitaController)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _socioMembresiaController = socioMembresiaController ?? throw new ArgumentNullException(nameof(socioMembresiaController));
            _membresiaController = membresiaController ?? throw new ArgumentNullException(nameof(membresiaController));
            _pagoSocioMembresiaController = pagoSocioMembresiaController ?? throw new ArgumentNullException(nameof(pagoSocioMembresiaController));
            _visitaController = visitaController ?? throw new ArgumentNullException(nameof(visitaController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        /// <summary>Socio de la fila seleccionada, o null si no hay ninguna seleccionada.</summary>
        private SocioViewModel? SocioSeleccionado =>
            dgvSocios.SelectedRows.Count > 0
                ? dgvSocios.SelectedRows[0].DataBoundItem as SocioViewModel
                : null;

        // ───────────── Carga y columnas ─────────────

        private async void FrmSocios_Load(object? sender, EventArgs e)
        {
            btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");
            ActiveControl = txtBuscar;

            await CargarSociosAsync();
        }

        // Las columnas se definen una sola vez (no en cada recarga).
        private void ConfigurarColumnas()
        {
            dgvSocios.AutoGenerateColumns = false;

            dgvSocios.AgregarTexto(nameof(SocioViewModel.Clave), "Clave", 75, 70);
            dgvSocios.AgregarTexto(nameof(SocioViewModel.NombreCompleto), "Nombre completo", 190, 130);
            dgvSocios.AgregarTexto(nameof(SocioViewModel.Telefono), "Teléfono", 100, 90);
            dgvSocios.AgregarTexto(nameof(SocioViewModel.Email), "Correo", 140, 110);
            dgvSocios.AgregarTexto(nameof(SocioViewModel.Estado), "Estado", 80, 70);
            dgvSocios.AgregarTexto(nameof(SocioViewModel.CreatedAt), "Registro", 110, 90, "dd/MM/yyyy hh:mm tt");
        }

        private async Task CargarSociosAsync(int? idASeleccionar = null)
        {
            int? idObjetivo = idASeleccionar ?? SocioSeleccionado?.SocioID;

            await FormHelper.EjecutarAsync(async () =>
            {
                var socios = await _controller.ObtenerSociosAsync(true);
                if (IsDisposed) return;

                _todos = socios.ToList();
                AplicarFiltro(idObjetivo);
            },
            "No se pudieron cargar los socios.",
            flowAcciones);
        }

        // ───────────── Búsqueda ─────────────

        private void txtBuscar_TextChanged(object? sender, EventArgs e)
        {
            temporizadorBusqueda.Stop();
            temporizadorBusqueda.Start();
        }

        private void temporizadorBusqueda_Tick(object? sender, EventArgs e)
        {
            temporizadorBusqueda.Stop();
            AplicarFiltro();
        }

        private void txtBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && txtBuscar.TextLength > 0)
            {
                e.SuppressKeyPress = true;
                txtBuscar.Clear();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                temporizadorBusqueda.Stop();
                AplicarFiltro();
            }
        }

        private void AplicarFiltro(int? idASeleccionar = null)
        {
            int? idObjetivo = idASeleccionar ?? SocioSeleccionado?.SocioID;

            var palabras = Normalizar(txtBuscar.Text)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var filtrados = palabras.Length == 0
                ? _todos
                : _todos.Where(s =>
                {
                    string texto = Normalizar($"{s.Clave} {s.Nombre} {s.Apellido} {s.NombreCompleto} {s.Telefono} {s.Email}");
                    return palabras.All(texto.Contains);
                }).ToList();

            var columnaOrden = dgvSocios.SortedColumn;
            var sentidoOrden = dgvSocios.SortOrder;

            _vista = new ListaOrdenable<SocioViewModel>(filtrados);
            dgvSocios.DataSource = _vista;

            if (columnaOrden != null && sentidoOrden != SortOrder.None)
            {
                dgvSocios.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending);
            }

            SeleccionarSocio(idObjetivo);
            ActualizarResumen();
        }

        private static string Normalizar(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;

            string descompuesto = texto.Trim().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(descompuesto.Length);

            foreach (char c in descompuesto)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();
        }

        private void ActualizarResumen()
        {
            int activos = _todos.Count(s => s.Activo);

            lblResumen.Text = _vista.Count == _todos.Count
                ? $"{_todos.Count} socio(s)  ·  {activos} activo(s)"
                : $"{_vista.Count} de {_todos.Count} socio(s)";
        }

        // ───────────── Selección y aspecto ─────────────

        private void SeleccionarSocio(int? id)
        {
            dgvSocios.ClearSelection();

            if (id.HasValue)
            {
                for (int i = 0; i < _vista.Count; i++)
                {
                    if (_vista[i].SocioID != id.Value) continue;

                    dgvSocios.Rows[i].Selected = true;
                    dgvSocios.CurrentCell = dgvSocios.Rows[i].Cells[0];
                    break;
                }
            }

            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            var socio = SocioSeleccionado;
            bool haySeleccion = socio != null;

            btnEditar.Enabled = haySeleccion;
            btnInfo.Enabled = haySeleccion;
            btnMembresia.Enabled = haySeleccion;
            btnDesactivar.Enabled = haySeleccion;
            btnEliminarFisico.Enabled = haySeleccion;

            bool inactivo = socio is { Activo: false };
            btnDesactivar.Text = inactivo ? "Activar" : "Desactivar";
            btnDesactivar.Estilo = inactivo ? EstiloBoton.Exito : EstiloBoton.Advertencia;
        }

        private void dgvSocios_SelectionChanged(object? sender, EventArgs e) => ActualizarEstadoBotones();

        private void dgvSocios_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count || e.CellStyle is null) return;

            if (!_vista[e.RowIndex].Activo)
            {
                e.CellStyle.ForeColor = Tema.TextoAtenuado;
            }
            else if (dgvSocios.Columns[e.ColumnIndex].DataPropertyName == nameof(SocioViewModel.Estado))
            {
                e.CellStyle.ForeColor = Tema.Exito;
            }
        }

        private async void dgvSocios_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _vista.Count) return;

            await AbrirModalSocioAsync(_vista[e.RowIndex].SocioID);
        }

        // ───────────── Acciones ─────────────

        private async void btnNuevo_Click(object? sender, EventArgs e) => await AbrirModalSocioAsync(null);

        private async void btnEditar_Click(object? sender, EventArgs e)
        {
            var socio = SocioSeleccionado;
            if (socio == null) return;

            await AbrirModalSocioAsync(socio.SocioID);
        }

        private async Task AbrirModalSocioAsync(int? socioId)
        {
            using var modal = new FrmSocioModal(_controller, socioId);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarSociosAsync(socioId);
        }

        private void btnInfo_Click(object? sender, EventArgs e)
        {
            var socio = SocioSeleccionado;
            if (socio == null) return;

            using var modal = new FrmSocioInfoModal(_controller, _visitaController, socio.SocioID);
            modal.ShowDialog();
        }

        private async void btnMembresia_Click(object? sender, EventArgs e)
        {
            var socio = SocioSeleccionado;
            if (socio == null) return;

            using var modal = new FrmSocioMembresiaModal(
                _socioMembresiaController,
                _membresiaController,
                _pagoSocioMembresiaController,
                socio,
                SesionUsuario.UsuarioID);

            if (modal.ShowDialog() == DialogResult.OK)
                await CargarSociosAsync(socio.SocioID);
        }

        private async void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var socio = SocioSeleccionado;
            if (socio == null) return;

            string accion = socio.Activo ? "desactivar" : "activar";

            if (!FormHelper.ConfirmarAccion(
                    $"¿Está seguro de {accion} al socio '{socio.NombreCompleto}'?",
                    $"Confirmar {accion.ToUpper()}"))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.CambiarEstadoLogicoAsync(socio.SocioID),
                "No se pudo cambiar el estado del socio.",
                flowAcciones);

            if (correcto)
                await CargarSociosAsync(socio.SocioID);
        }

        private async void btnEliminarFisico_Click(object? sender, EventArgs e)
        {
            var socio = SocioSeleccionado;
            if (socio == null) return;

            if (!FormHelper.ConfirmarAccion(
                    $"¿Desea eliminar PERMANENTEMENTE al socio '{socio.NombreCompleto}' de la base de datos?\n\n" +
                    "Esta acción no se puede deshacer. Si el socio ya tiene visitas, pagos o membresías, lo normal es desactivarlo en su lugar.",
                    "Eliminación definitiva",
                    destructiva: true))
                return;

            bool correcto = await FormHelper.EjecutarAsync(
                () => _controller.EliminarFisicoAsync(socio.SocioID),
                "No se pudo eliminar al socio. Si tiene historial asociado, desactívalo en su lugar.",
                flowAcciones);

            if (correcto)
                await CargarSociosAsync();
        }
    }
}
