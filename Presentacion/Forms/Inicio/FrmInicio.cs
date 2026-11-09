using Presentacion.Controller;
using Presentacion.Forms.Socios;
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

namespace Presentacion.Forms.Inicio
{
    public partial class FrmInicio : Form
    {
        private readonly InicioController _controller;
        private readonly SocioController _socioController;
        private readonly VisitaController _visitaController;

        // Lo que muestra el grid (ordenable al hacer clic en los encabezados).
        private ListaOrdenable<InicioViewModel> _vista = new();

        public FrmInicio(InicioController controller, SocioController socioController, VisitaController visitaController)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _socioController = socioController ?? throw new ArgumentNullException(nameof(socioController));
            _visitaController = visitaController ?? throw new ArgumentNullException(nameof(visitaController));

            InitializeComponent();
            ConfigurarColumnas();
        }

        // ───────────── Carga y columnas ─────────────

        // El logo no cambia entre visitas: se decodifica una sola vez y se reutiliza.
        // Es compartido, por eso nunca se libera ni se pasa por ImagenHelper.MostrarEn (que lo liberaría).
        private static Bitmap? _logoCache;
        private static bool _logoCargado;

        /// <summary>Llamar al guardar los datos del gimnasio para que Inicio vuelva a leer el logo.</summary>
        public static void InvalidarLogo()
        {
            _logoCache = null;
            _logoCargado = false;
        }

        private async void FrmInicio_Load(object? sender, EventArgs e)
        {
            // Si ya está en caché el logo aparece al instante, antes de consultar las visitas.
            if (_logoCargado) picBanner.Image = _logoCache;

            await CargarVisitantesAsync();
            if (!_logoCargado) await CargarLogotipoAsync();
        }

        // Las columnas se definen una sola vez (se omitió la columna Identificador).
        private void ConfigurarColumnas()
        {
            dgvVisitantes.AutoGenerateColumns = false;
            dgvVisitantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisitantes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvVisitantes.RowTemplate.Height = 24;
            dgvVisitantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVisitantes.ColumnHeadersHeight = 48;

            var columnaNombre = dgvVisitantes.AgregarTexto(nameof(InicioViewModel.Nombre), "Nombre", 320, 140);
            var columnaApellido = dgvVisitantes.AgregarTexto(nameof(InicioViewModel.Apellido), "Apellido", 320, 140);
            var columnaFecha = dgvVisitantes.AgregarTexto(
                nameof(InicioViewModel.CreatedAt), "Fecha", 888, 120, "dd/MM/yyyy hh:mm tt");
            columnaFecha.MinimumWidth = 130;
            columnaFecha.HeaderCell.Style.WrapMode = DataGridViewTriState.True;

            // En modo Fill, al agregar las columnas el grid puede reemplazar los pesos por los anchos del momento
            // (por eso se veían casi iguales). Se fijan aquí, con todas las columnas ya agregadas.
            columnaNombre.FillWeight = 320;
            columnaApellido.FillWeight = 320;
            columnaFecha.FillWeight = 888;
        }

        private async Task CargarVisitantesAsync()
        {
            await FormHelper.EjecutarAsync(async () =>
            {
                var visitantes = await _controller.ObtenerVisitantesDelDiaAsync();
                if (IsDisposed) return; // el usuario cambió de módulo mientras cargaba

                // Se recuerda el orden elegido para reaplicarlo tras volver a enlazar.
                var columnaOrden = dgvVisitantes.SortedColumn;
                var sentidoOrden = dgvVisitantes.SortOrder;

                _vista = new ListaOrdenable<InicioViewModel>(visitantes.ToList());
                dgvVisitantes.DataSource = _vista;

                if (columnaOrden != null && sentidoOrden != SortOrder.None)
                {
                    dgvVisitantes.Sort(columnaOrden, sentidoOrden == SortOrder.Descending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending);
                }
            },
            "No se pudieron cargar los visitantes del día.",
            panelTop);
        }

        private async Task CargarLogotipoAsync()
        {
            try
            {
                string rutaLogo = await _controller.ObtenerLogoGimnasioAsync();

                // La decodificación de la imagen se hace fuera del hilo de la interfaz.
                var logo = await Task.Run(() => ImagenHelper.CargarFoto(rutaLogo));

                if (IsDisposed)
                {
                    logo?.Dispose();
                    return;
                }

                _logoCache = logo;
                _logoCargado = true;
                picBanner.Image = logo;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"No se pudo cargar el logotipo en el inicio: {ex.Message}");
            }
        }

        // ───────────── Acciones ─────────────

        private void btnInformacion_Click(object? sender, EventArgs e)
        {
            // 1. Verificar si hay una fila seleccionada en el grid
            if (dgvVisitantes.SelectedRows.Count == 0)
            {
                FormHelper.MostrarAviso("Por favor, selecciona un visitante de la lista para ver su información.", "Aviso");
                return;
            }

            // 2. Obtener el objeto vinculado a la fila
            var seleccionado = dgvVisitantes.SelectedRows[0].DataBoundItem as InicioViewModel;
            if (seleccionado == null) return;

            // 3. Validar si es un socio registrado o una visita casual
            if (!seleccionado.SocioID.HasValue)
            {
                FormHelper.MostrarAviso("El registro seleccionado corresponde a una Visita Casual, por lo que no cuenta con un expediente de socio.", "Información");
                return;
            }

            try
            {
                // 4. Instanciar y mostrar el modal del socio pasando los controladores requeridos
                using (var frmModal = new FrmSocioInfoModal(_socioController, _visitaController, seleccionado.SocioID.Value))
                {
                    frmModal.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                FormHelper.MostrarError($"No se pudo abrir la información del socio: {ex.Message}", "Error");
            }
        }
    }
}
