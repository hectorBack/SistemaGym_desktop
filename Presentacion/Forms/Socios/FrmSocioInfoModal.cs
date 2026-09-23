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
        private readonly SocioController _socioController;
        private readonly VisitaController _visitaController;
        private readonly int _socioId;

        public FrmSocioInfoModal(SocioController socioController, VisitaController visitaController, int socioId)
        {
            InitializeComponent();
            _socioController = socioController;
            _visitaController = visitaController;
            _socioId = socioId;

            ConfigurarFormularioModal();
        }

        private void ConfigurarFormularioModal()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void ConfigurarDisenoGrid(DataGridView dgv)
        {
            // Forzar la visibilidad del encabezado
            dgv.ColumnHeadersVisible = true;
            dgv.EnableHeadersVisualStyles = false;

            // Estilos del Encabezado (Header)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Altura y redimensionamiento
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 34;
            dgv.RowTemplate.Height = 28;

            // Estilos de Celdas
            dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#e6eefc");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void FrmSocioInfoModal_Load(object sender, EventArgs e)
        {
            // Mostrar inicialmente las visitas registradas durante el día actual.
            dtpVisitaDesde.Value = DateTime.Today;
            dtpVisitaHasta.Value = DateTime.Today;

            await CargarInformacionSocioAsync();
        }

        private async Task CargarInformacionSocioAsync()
        {
            var socioDetalle = await _socioController.ObtenerDetalleSocioAsync(_socioId);

            if (socioDetalle == null)
            {
                MessageBox.Show("No se encontró la información del socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Cargar Datos Generales
            lblClave.Text = socioDetalle.Clave;
            lblNombreCompleto.Text = socioDetalle.NombreCompleto;
            lblTelefono.Text = socioDetalle.Telefono ?? "N/A";
            lblEmail.Text = socioDetalle.Email ?? "N/A";
            lblEstado.Text = socioDetalle.Activo ? "ACTIVO" : "INACTIVO";
            lblEstado.ForeColor = socioDetalle.Activo ? Color.Green : Color.Red;

            CargarFoto(socioDetalle.Foto);

            // Cargar Pestaña 1: Membresías
            dgvHistorialMembresias.DataSource = socioDetalle.HistorialMembresias;
            ConfigurarHistorialMembresias();

            // Cargar Pestaña 2: Visitas / Asistencias mediante el controlador de visitas
            await CargarVisitasPorFechasAsync();
        }

        private async Task CargarVisitasPorFechasAsync()
        {
            DateTime desde = dtpVisitaDesde.Value.Date;
            DateTime hasta = dtpVisitaHasta.Value.Date.AddDays(1).AddTicks(-1);

            var visitas = (await _visitaController.ObtenerPorSocioYFechasAsync(_socioId, desde, hasta)).ToList();

            // 1. Asignar datos primero
            dgvHistorialVisitas.AutoGenerateColumns = true;
            dgvHistorialVisitas.DataSource = null;
            dgvHistorialVisitas.DataSource = visitas;

            // 2. Aplicar estilos y diseño de encabezados DESPUÉS de cargar los datos
            ConfigurarDisenoGrid(dgvHistorialVisitas);
            ConfigurarHistorialVisitas();

            dgvHistorialVisitas.Refresh();
        }

        private void ConfigurarHistorialVisitas()
        {
            ConfigurarDisenoGrid(dgvHistorialVisitas);

            // Estas propiedades pertenecen a VisitaViewModel y se muestran con nombres legibles.
            ConfigurarColumna(dgvHistorialVisitas, "FechaRegistro", "Fecha de visita", 130, 120);
            ConfigurarColumna(dgvHistorialVisitas, "TipoAcceso", "Tipo de acceso", 120, 110);
            ConfigurarColumna(dgvHistorialVisitas, "NombreMembresia", "Membresía", 150, 110);

            MostrarSoloColumnas(dgvHistorialVisitas,
                "FechaRegistro", "TipoAcceso", "NombreMembresia");

            OrdenarColumnas(dgvHistorialVisitas,
                "FechaRegistro", "TipoAcceso", "NombreMembresia");
        }

        private async void btnFiltrarVisitas_Click(object sender, EventArgs e)
        {
            if (dtpVisitaDesde.Value > dtpVisitaHasta.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await CargarVisitasPorFechasAsync();
        }

        private async void btnEliminarVisita_Click(object sender, EventArgs e)
        {
            if (dgvHistorialVisitas.CurrentRow?.DataBoundItem is not VisitaViewModel visita)
            {
                MessageBox.Show(
                    "Seleccione una visita del historial para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string fechaVisita = visita.FechaRegistro;
            string nombreSocio = string.IsNullOrWhiteSpace(visita.NombreCompleto)
                ? "este socio"
                : visita.NombreCompleto;

            if (!FormHelper.ConfirmarAccion(
                $"¿Desea eliminar permanentemente la visita de '{nombreSocio}' registrada el {fechaVisita}?",
                "Eliminar visita"))
            {
                return;
            }

            try
            {
                await _visitaController.EliminarFisicoAsync(visita.VisitaID);
                await CargarVisitasPorFechasAsync();
                MessageBox.Show(
                    "La visita se eliminó correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al eliminar la visita: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigurarHistorialMembresias()
        {
            ConfigurarDisenoGrid(dgvHistorialMembresias);
            ConfigurarColumna(dgvHistorialMembresias, "NombreMembresia", "Membresía", 150, 110);
            ConfigurarColumna(dgvHistorialMembresias, "FechaInicioTexto", "Fecha inicio", 95, 85);
            ConfigurarColumna(dgvHistorialMembresias, "FechaFinTexto", "Fecha fin", 95, 85);
            ConfigurarColumna(dgvHistorialMembresias, "PrecioTexto", "Precio", 80, 70);
            ConfigurarColumna(dgvHistorialMembresias, "Estado", "Estado", 90, 75);

            OcultarColumnas(dgvHistorialMembresias, "FechaInicio", "FechaFin", "Precio");
            OrdenarColumnas(dgvHistorialMembresias,
                "NombreMembresia", "FechaInicioTexto", "FechaFinTexto", "PrecioTexto", "Estado");
        }

        private static void ConfigurarColumna(
            DataGridView dgv, string nombre, string encabezado, float peso, int anchoMinimo)
        {
            if (dgv.Columns[nombre] is not DataGridViewColumn columna)
                return;

            columna.HeaderText = encabezado;
            columna.FillWeight = peso;
            columna.MinimumWidth = anchoMinimo;
            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private static void OcultarColumnas(DataGridView dgv, params string[] nombres)
        {
            foreach (string nombre in nombres)
            {
                if (dgv.Columns[nombre] is DataGridViewColumn columna)
                    columna.Visible = false;
            }
        }

        private static void MostrarSoloColumnas(DataGridView dgv, params string[] visibles)
        {
            var nombresVisibles = new HashSet<string>(visibles, StringComparer.OrdinalIgnoreCase);

            foreach (DataGridViewColumn columna in dgv.Columns)
                columna.Visible = nombresVisibles.Contains(columna.Name);
        }

        private static void OrdenarColumnas(DataGridView dgv, params string[] nombres)
        {
            for (int indice = 0; indice < nombres.Length; indice++)
            {
                if (dgv.Columns[nombres[indice]] is DataGridViewColumn columna)
                    columna.DisplayIndex = indice;
            }
        }

        private void CargarFoto(string? fotoBase64OrPath)
        {
            if (string.IsNullOrEmpty(fotoBase64OrPath))
            {
                picFotoSocio.Image = null;
                return;
            }

            try
            {
                byte[] bytes = Convert.FromBase64String(fotoBase64OrPath);
                using (var ms = new MemoryStream(bytes))
                {
                    picFotoSocio.Image = Image.FromStream(ms);
                }
            }
            catch
            {
                if (File.Exists(fotoBase64OrPath))
                {
                    picFotoSocio.Image = Image.FromFile(fotoBase64OrPath);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControlDetalles_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControlDetalles.TabPages[e.Index];
            Rectangle tabRect = tabControlDetalles.GetTabRect(e.Index);
            bool isSelected = (tabControlDetalles.SelectedIndex == e.Index);

            // 1. Limpiar únicamente la franja vacía a la derecha de las pestañas (solo una vez)
            if (e.Index == tabControlDetalles.TabCount - 1)
            {
                Rectangle lastTabRect = tabControlDetalles.GetTabRect(tabControlDetalles.TabCount - 1);
                Rectangle headerArea = new Rectangle(
                    lastTabRect.Right,
                    0,
                    tabControlDetalles.Width - lastTabRect.Right,
                    lastTabRect.Height + 2
                );

                using (SolidBrush bgBrush = new SolidBrush(ColorTranslator.FromHtml("#0b0f1a")))
                {
                    e.Graphics.FillRectangle(bgBrush, headerArea);
                }
            }

            // 2. Colores para pestaña activa e inactiva
            Color backColor = isSelected ? ColorTranslator.FromHtml("#0f2a4f") : ColorTranslator.FromHtml("#161b26");
            Color textColor = isSelected ? ColorTranslator.FromHtml("#2dd4ff") : Color.White;

            // 3. Pintar fondo individual de la pestaña actual
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            // 4. Dibujar borde
            using (Pen pen = new Pen(isSelected ? ColorTranslator.FromHtml("#2dd4ff") : ColorTranslator.FromHtml("#0f2a4f"), 1))
            {
                e.Graphics.DrawRectangle(pen, tabRect.X, tabRect.Y, tabRect.Width - 1, tabRect.Height - 1);
            }

            // 5. Dibujar el texto centrado
            TextRenderer.DrawText(
                e.Graphics,
                tabPage.Text,
                new Font("Segoe UI", 9.5F, isSelected ? FontStyle.Bold : FontStyle.Regular),
                tabRect,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }
    }
}