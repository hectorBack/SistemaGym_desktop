using Presentacion.Controller;
using Presentacion.Forms.Membresias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Reportes
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteController _reporteController;
        private FrmInventarios? _frmInventarios;
        private FrmMembresiasReporte? _frmMembresias;

        public FrmReportes(ReporteController reporteController)
        {
            InitializeComponent();
            _reporteController = reporteController;
        }

        private async void FrmReportes_Load(object sender, EventArgs e)
        {
            // Cargar la pestaña inicial (Inventario)
            await CargarReporteTabActualAsync();
        }

        private async void tabControlReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CargarReporteTabActualAsync();
        }

        private async Task CargarReporteTabActualAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime fin = DateTime.Now;

                switch (tabControlReportes.SelectedTab?.Name)
                {
                    case "tabInventario":
                        CargarFormularioInventario();
                        break;

                    case "tabMembresias":
                        CargarFormularioMembresias();
                        break;

                    case "tabSocios":
                        dgvSocios.DataSource = await _reporteController.ObtenerSociosAsync();
                        break;

                    case "tabRegistro":
                        dgvRegistro.DataSource = await _reporteController.ObtenerRegistrosAsync(inicio, fin);
                        break;

                    case "tabVentas":
                        dgvVentas.DataSource = await _reporteController.ObtenerVentaProductosAsync(inicio, fin);
                        break;

                    case "tabVisitas":
                        dgvVisitas.DataSource = await _reporteController.ObtenerVisitasAsync(inicio, fin);
                        break;

                    case "tabPagos":
                        dgvPagos.DataSource = await _reporteController.ObtenerPagosMembresiasAsync(inicio, fin);
                        break;

                    case "tabMovimientos":
                        dgvMovimientos.DataSource = await _reporteController.ObtenerMovimientosAsync(inicio, fin);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tabControlReportes_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControlReportes.TabPages[e.Index];
            Rectangle tabRect = tabControlReportes.GetTabRect(e.Index);
            bool isSelected = (tabControlReportes.SelectedIndex == e.Index);

            // 1. Limpiar el fondo del encabezado de la pestaña actual para evitar bordes claros defectuosos
            using (SolidBrush edgeBrush = new SolidBrush(ColorTranslator.FromHtml("#0b0f1a")))
            {
                // Creamos un rectángulo ligeramente más grande para limpiar imperfecciones visuales nativas
                Rectangle fillRect = new Rectangle(tabRect.X - 1, tabRect.Y - 1, tabRect.Width + 2, tabRect.Height + 2);
                e.Graphics.FillRectangle(edgeBrush, fillRect);
            }

            // 2. Definir colores según el estado (Activa: #0f2a4f | Inactiva: #161b26)
            Color backColor = isSelected ? ColorTranslator.FromHtml("#0f2a4f") : ColorTranslator.FromHtml("#161b26");
            Color textColor = isSelected ? ColorTranslator.FromHtml("#2dd4ff") : Color.White;

            // Pintar el fondo interno de la pestaña dejando un pequeño espacio para que se note la separación
            Rectangle innerTabRect = new Rectangle(tabRect.X + 2, tabRect.Y + 2, tabRect.Width - 4, tabRect.Height - 2);
            using (SolidBrush bgBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(bgBrush, innerTabRect);
            }

            // 3. Dibujar el texto perfectamente centrado
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabControlReportes.Font, innerTabRect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // 4. Limpiar la franja vacía que sobra a la derecha de la última pestaña
            if (e.Index == tabControlReportes.TabCount - 1)
            {
                Rectangle lastTabRect = tabControlReportes.GetTabRect(tabControlReportes.TabCount - 1);
                Rectangle headerArea = new Rectangle(
                    lastTabRect.Right,
                    0,
                    tabControlReportes.Width - lastTabRect.Right,
                    lastTabRect.Height + 5
                );

                using (SolidBrush bgBrush = new SolidBrush(ColorTranslator.FromHtml("#0b0f1a")))
                {
                    e.Graphics.FillRectangle(bgBrush, headerArea);
                }
            }
        }

        /// <summary>
        /// Instancia e incrusta el formulario FrmInventarios dentro de la pestaña tabInventario
        /// </summary>
        private void CargarFormularioInventario()
        {
            // Evitar recrear el formulario si ya está dentro de la pestaña
            if (_frmInventarios != null && !_frmInventarios.IsDisposed)
            {
                return;
            }

            // Limpiar controles previos (como dgvInventario si existía en la pestaña)
            tabInventario.Controls.Clear();

            // Instanciar el formulario pasando el controlador
            _frmInventarios = new FrmInventarios(_reporteController)
            {
                TopLevel = false,               // Desactiva el comportamiento de ventana independiente
                FormBorderStyle = FormBorderStyle.None, // Quita bordes y barra de título
                Dock = DockStyle.Fill,        // Hace que ocupe todo el espacio de la pestaña
                BackColor = ColorTranslator.FromHtml("#0b0f1a")
            };

            // Agregar el formulario al contenedor de la pestaña y mostrarlo
            tabInventario.Controls.Add(_frmInventarios);
            _frmInventarios.Show();
        }

        private void CargarFormularioMembresias()
        {
            if (_frmMembresias != null && !_frmMembresias.IsDisposed)
            {
                return;
            }
            tabMembresias.Controls.Clear();

            _frmMembresias = new FrmMembresiasReporte(_reporteController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#0b0f1a")
            };

            tabMembresias.Controls.Add(_frmMembresias);
            _frmMembresias.Show();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            // Si estás usando controles nativos, esto ayuda a forzar que los TabPages 
            // hereden correctamente el fondo oscuro y no pinten el borde interno de Windows.
            if (e.Control is TabControl tc)
            {
                foreach (TabPage page in tc.TabPages)
                {
                    page.BackColor = ColorTranslator.FromHtml("#0b0f1a");
                }
            }
        }
    }
}
