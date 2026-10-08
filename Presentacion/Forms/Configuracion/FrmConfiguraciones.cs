using Presentacion.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Configuracion
{
    public partial class FrmConfiguraciones : Form
    {
        private readonly ConfiguracionController _configuracionController;

        // Subformularios incrustados en las pestañas
        private FrmConfiguracionCorteCaja? _frmConfiguracionCorteCaja;

        public FrmConfiguraciones(ConfiguracionController configuracionController)
        {
            InitializeComponent();
            _configuracionController = configuracionController;
            InicializarEstilosPestañas();
        }

        private void InicializarEstilosPestañas()
        {
            ConfigurarTabPage(tabCorteCaja, "tabCorteCaja", "Corte de Caja");
            ConfigurarTabPage(tabDatosGimnasio, "tabDatosGimnasio", "Datos del Gimnasio");
            ConfigurarTabPage(tabCorreos, "tabCorreos", "Configuración de Correos");
            ConfigurarTabPage(tabRespaldos, "tabRespaldos", "Respaldos");
            ConfigurarTabPage(tabMasConfiguraciones, "tabMasConfiguraciones", "Más Configuraciones");
        }

        private void ConfigurarTabPage(TabPage page, string name, string text)
        {
            page.Name = name;
            page.Text = text;
            page.BackColor = ColorTranslator.FromHtml("#0b0f1a");
        }

        private async void FrmConfiguraciones_Load(object sender, EventArgs e)
        {
            tabControlConfiguraciones.Invalidate();
            await CargarConfiguracionTabActualAsync();
        }

        private async void tabControlConfiguraciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CargarConfiguracionTabActualAsync();
        }

        private async Task CargarConfiguracionTabActualAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                switch (tabControlConfiguraciones.SelectedTab?.Name)
                {
                    case "tabCorteCaja":
                        CargarFormularioCorteCaja();
                        break;

                    case "tabDatosGimnasio":
                        // Próximamente: CargarFormularioDatosGimnasio();
                        break;

                    case "tabCorreos":
                        // Próximamente: CargarFormularioCorreos();
                        break;

                    case "tabRespaldos":
                        // Próximamente: CargarFormularioRespaldos();
                        break;

                    case "tabMasConfiguraciones":
                        // Próximamente: CargarFormularioMasConfiguraciones();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la pestaña de configuración: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Instancia e incrusta el formulario FrmConfiguracionCorteCaja dentro de la pestaña tabCorteCaja
        /// </summary>
        private void CargarFormularioCorteCaja()
        {
            if (_frmConfiguracionCorteCaja != null && !_frmConfiguracionCorteCaja.IsDisposed)
            {
                return;
            }

            tabCorteCaja.Controls.Clear();

            _frmConfiguracionCorteCaja = new FrmConfiguracionCorteCaja(_configuracionController)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#0b0f1a")
            };

            tabCorteCaja.Controls.Add(_frmConfiguracionCorteCaja);
            _frmConfiguracionCorteCaja.Show();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

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
