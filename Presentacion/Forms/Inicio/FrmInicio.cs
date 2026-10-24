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

        private async void FrmInicio_Load(object? sender, EventArgs e)
        {
            await CargarVisitantesAsync();
            await CargarLogotipoAsync();
        }

        // Las columnas se definen una sola vez (se omitió la columna Identificador).
        private void ConfigurarColumnas()
        {
            dgvVisitantes.AutoGenerateColumns = false;

            dgvVisitantes.AgregarTexto(nameof(InicioViewModel.Nombre), "Nombre", 180, 140);
            dgvVisitantes.AgregarTexto(nameof(InicioViewModel.Apellido), "Apellido", 180, 140);
            dgvVisitantes.AgregarTexto(nameof(InicioViewModel.CreatedAt), "Fecha", 160, 120, "dd/MM/yyyy hh:mm tt");
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
                if (!string.IsNullOrWhiteSpace(rutaLogo))
                {
                    // Carga la imagen de forma segura utilizando el helper existente en el sistema
                    ImagenHelper.MostrarEn(picBanner, ImagenHelper.CargarFoto(rutaLogo));
                }
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
