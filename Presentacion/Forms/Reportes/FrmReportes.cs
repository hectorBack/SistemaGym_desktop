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
        private readonly VisitaController _visitaController;
        private FrmInventarios? _frmInventarios;
        private FrmMembresiasReporte? _frmMembresias;
        private FrmPagosMembresias? _frmPagosMembresias;
        private FrmSociosReporte? _frmSociosReporte;
        private FrmRegistrosReporte? _frmRegistrosReporte;
        private FrmVisitasReporte? _frmVisitasReporte;
        private FrmVentasProductos? _frmVentasproductos;
        private FrmMovimientosReporte? _frmMovimientosReporte;

        public FrmReportes(ReporteController reporteController, VisitaController visitaController)
        {
            InitializeComponent();
            _reporteController = reporteController;
            _visitaController = visitaController;
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

        // Solo estilo: el aspecto del grid ya viene de GridTema; aquí se nombra la pestaña y se le da el fondo del tema.
        private void ConfigurarTabPage(TabPage page, string name, string text, GridTema dgv)
        {
            page.Name = name;
            page.Text = text;
            page.BackColor = Tema.Fondo;

            dgv.Dock = DockStyle.Fill;

            // Alineación y formato (dinero, cantidades) según el nombre de la columna: ver GridTemaExtensiones.cs
            dgv.FormatoAutomatico();

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
                        CargarFormularioVentas();
                        break;

                    case "tabVisitas":
                        CargarFormularioVisitas();
                        break;

                    case "tabPagos":
                        CargarFormularioPagos();
                        break;

                    case "tabMovimientos":
                        CargarFormularioMovimientos();
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
                BackColor = Tema.Fondo
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
                BackColor = Tema.Fondo
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
                BackColor = Tema.Fondo
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
                BackColor = Tema.Fondo
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
                BackColor = Tema.Fondo
            };

            tabRegistro.Controls.Add(_frmRegistrosReporte);
            _frmRegistrosReporte.Show();
        }

        private void CargarFormularioVisitas()
        {
            if (_frmVisitasReporte != null && !_frmVisitasReporte.IsDisposed)
            {
                return;
            }
            tabVisitas.Controls.Clear();

            _frmVisitasReporte = new FrmVisitasReporte(_reporteController, _visitaController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = Tema.Fondo
            };

            tabVisitas.Controls.Add(_frmVisitasReporte);
            _frmVisitasReporte.Show();
        }

        private void CargarFormularioVentas()
        {
            if (_frmVentasproductos != null && !_frmVentasproductos.IsDisposed)
            {
                return;
            }
            tabVentas.Controls.Clear();

            _frmVentasproductos = new FrmVentasProductos(_reporteController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = Tema.Fondo
            };

            tabVentas.Controls.Add(_frmVentasproductos);
            _frmVentasproductos.Show();
        }

        private void CargarFormularioMovimientos()
        {
            if (_frmMovimientosReporte != null && !_frmMovimientosReporte.IsDisposed)
            {
                return;
            }
            tabMovimientos.Controls.Clear();

            _frmMovimientosReporte = new FrmMovimientosReporte(_reporteController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = Tema.Fondo
            };

            tabMovimientos.Controls.Add(_frmMovimientosReporte);
            _frmMovimientosReporte.Show();
        }
    }
}
