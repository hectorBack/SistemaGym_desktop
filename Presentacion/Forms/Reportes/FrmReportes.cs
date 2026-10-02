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
        private FrmPagosMembresias? _frmPagosMembresias;
        private FrmSociosReporte? _frmSociosReporte;
        private FrmRegistrosReporte? _frmRegistrosReporte;

        public FrmReportes(ReporteController reporteController)
        {
            InitializeComponent();
            _reporteController = reporteController;
            InicializarEstilosPestañas();
        }

        private void InicializarEstilosPestañas()
        {
            ConfigurarTabPage(tabInventario, "tabInventario", "Inventario", dgvInventario);
            ConfigurarTabPage(tabMembresias, "tabMembresias", "Membresías", dgvMembresias);
            ConfigurarTabPage(tabSocios, "tabSocios", "Socios", dgvSocios);
            ConfigurarTabPage(tabRegistro, "tabRegistro", "Registro", dgvRegistro);
            ConfigurarTabPage(tabVentas, "tabVentas", "Venta Productos", dgvVentas);
            ConfigurarTabPage(tabVisitas, "tabVisitas", "Visitas", dgvVisitas);
            ConfigurarTabPage(tabPagos, "tabPagos", "Pagos Membresías", dgvPagos);
            ConfigurarTabPage(tabMovimientos, "tabMovimientos", "Movimientos", dgvMovimientos);
        }

        private void ConfigurarTabPage(TabPage page, string name, string text, DataGridView dgv)
        {
            page.Name = name;
            page.Text = text;
            page.BackColor = ColorTranslator.FromHtml("#0b0f1a");

            // Configuración visual del DataGridView
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = ColorTranslator.FromHtml("#0b0f1a");
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;

            // Estilo de Encabezados
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0f2a4f");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2dd4ff");
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Bold", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Padding para celdas
            Padding margenCelda = new Padding(10, 6, 10, 6);
            dgv.ColumnHeadersDefaultCellStyle.Padding = margenCelda;
            dgv.DefaultCellStyle.Padding = margenCelda;

            // Filas de datos
            dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0b0f1a");
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1f6feb");
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.RowTemplate.Height = 38;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.GridColor = ColorTranslator.FromHtml("#161b26");
            dgv.Dock = DockStyle.Fill;
            dgv.Margin = new Padding(3, 4, 3, 4);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Alineación y formato automático según el nombre de la columna
            dgv.DataBindingComplete += (sender, e) =>
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string colName = col.Name.ToLower();

                    if (colName.Contains("precio") || colName.Contains("costo") || colName.Contains("total") || colName.Contains("subtotal") || colName.Contains("pago"))
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.DefaultCellStyle.Format = "C2";
                    }
                    else if (colName.Contains("stock") || colName.Contains("cantidad") || colName.Contains("id"))
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            };

            page.Controls.Add(dgv);
        }

        private async void FrmReportes_Load(object sender, EventArgs e)
        {
            tabControlReportes.Invalidate();
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
                        CargarFormularioSocios();
                        break;

                    case "tabRegistro":
                        CargarFormularioRegistros();
                        break;

                    case "tabVentas":
                        dgvVentas.DataSource = await _reporteController.ObtenerVentaProductosAsync(inicio, fin);
                        break;

                    case "tabVisitas":
                        dgvVisitas.DataSource = await _reporteController.ObtenerVisitasAsync(inicio, fin);
                        break;

                    case "tabPagos":
                        CargarFormularioPagos();
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

        private void CargarFormularioPagos()
        {
            if (_frmPagosMembresias != null && !_frmPagosMembresias.IsDisposed)
            {
                return;
            }
            tabPagos.Controls.Clear();

            _frmPagosMembresias = new FrmPagosMembresias(_reporteController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#0b0f1a")
            };

            tabPagos.Controls.Add(_frmPagosMembresias);
            _frmPagosMembresias.Show();
        }

        private void CargarFormularioSocios()
        {
            if (_frmSociosReporte != null && !_frmSociosReporte.IsDisposed)
            {
                return;
            }
            tabSocios.Controls.Clear();

            _frmSociosReporte = new FrmSociosReporte(_reporteController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#0b0f1a")
            };

            tabSocios.Controls.Add(_frmSociosReporte);
            _frmSociosReporte.Show();
        }

        private void CargarFormularioRegistros()
        {
            if (_frmRegistrosReporte != null && !_frmRegistrosReporte.IsDisposed)
            {
                return;
            }
            tabRegistro.Controls.Clear();

            _frmRegistrosReporte = new FrmRegistrosReporte(_reporteController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#0b0f1a")
            };

            tabRegistro.Controls.Add(_frmRegistrosReporte);
            _frmRegistrosReporte.Show();
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
