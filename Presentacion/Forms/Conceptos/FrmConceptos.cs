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

namespace Presentacion.Forms.Conceptos
{
    public partial class FrmConceptos : Form
    {
        private readonly ConceptoController _controller;
        private List<ConceptoViewModel> _listaConceptos = new();

        public FrmConceptos(ConceptoController controller)
        {
            InitializeComponent();
            _controller = controller;
            dgvConceptos.SelectionChanged += dgvConceptos_SelectionChanged;
        }

        private async void FrmConceptos_Load(object sender, EventArgs e)
        {
            await CargarConceptosAsync();
        }

        private async Task CargarConceptosAsync()
        {
            try
            {
                var resultado = await _controller.ObtenerConceptosAsync(true);
                _listaConceptos = resultado.ToList();
                dgvConceptos.DataSource = null;
                dgvConceptos.DataSource = _listaConceptos;
                ConfigurarGrid();
                dgvConceptos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar conceptos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            // 1. Ocultar columnas técnicas
            if (dgvConceptos.Columns["Activo"] != null) dgvConceptos.Columns["Activo"].Visible = false;
            if (dgvConceptos.Columns["EsSistema"] != null) dgvConceptos.Columns["EsSistema"].Visible = false;

            // 2. Configurar encabezados
            if (dgvConceptos.Columns["ConceptoID"] != null) dgvConceptos.Columns["ConceptoID"].HeaderText = "ID";
            if (dgvConceptos.Columns["Nombre"] != null) dgvConceptos.Columns["Nombre"].HeaderText = "Nombre";
            if (dgvConceptos.Columns["Tipo"] != null) dgvConceptos.Columns["Tipo"].HeaderText = "Tipo";
            if (dgvConceptos.Columns["Observacion"] != null) dgvConceptos.Columns["Observacion"].HeaderText = "Observación";
            if (dgvConceptos.Columns["Estado"] != null) dgvConceptos.Columns["Estado"].HeaderText = "Estado";
            if (dgvConceptos.Columns["CreatedAt"] != null) dgvConceptos.Columns["CreatedAt"].HeaderText = "Fecha Registro";

            // 3. Estructura de ordenamiento y pesos estilo estándar
            dgvConceptos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
                "ConceptoID",
                "Nombre",
                "Tipo",
                "Observacion",
                "Estado",
                "CreatedAt"
            };

            var pesos = new Dictionary<string, float>
            {
                ["ConceptoID"] = 45,
                ["Nombre"] = 150,
                ["Tipo"] = 100,
                ["Observacion"] = 200,
                ["Estado"] = 80,
                ["CreatedAt"] = 120
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvConceptos.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "Nombre" => 100,
                    "Tipo" => 80,
                    "Observacion" => 120,
                    "CreatedAt" => 95,
                    _ => 55
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmConceptoModal(_controller);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarConceptosAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvConceptos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un concepto de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (ConceptoViewModel)dgvConceptos.CurrentRow.DataBoundItem;

            // Validación por ID (1 al 8) o texto en Observación
            if (item.ConceptoID <= 8 || (item.Observacion != null && item.Observacion.Contains("No se puede modificar")))
            {
                MessageBox.Show("Este concepto no se puede modificar por el modelo de negocio del sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var modal = new FrmConceptoModal(_controller, item.ConceptoID, item.Nombre, item.Tipo, item.Observacion);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarConceptosAsync();
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvConceptos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un concepto de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (ConceptoViewModel)dgvConceptos.CurrentRow.DataBoundItem;

            // Validación para prevenir desactivar conceptos del sistema
            if (item.ConceptoID <= 8 || (item.Observacion != null && item.Observacion.Contains("No se puede modificar")))
            {
                MessageBox.Show("Este concepto no se puede modificar por el modelo de negocio del sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accion = item.Activo ? "desactivar" : "activar";

            if (FormHelper.ConfirmarAccion($"¿Está seguro de {accion} el concepto '{item.Nombre}'?", $"Confirmar {accion.ToUpper()}"))
            {
                try
                {
                    await _controller.CambiarEstadoLogicoAsync(item.ConceptoID);
                    await CargarConceptosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvConceptos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un concepto de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (ConceptoViewModel)dgvConceptos.CurrentRow.DataBoundItem;

            // Validación para prevenir eliminar conceptos del sistema
            if (item.ConceptoID <= 8 || (item.Observacion != null && item.Observacion.Contains("No se puede modificar")))
            {
                MessageBox.Show("Este concepto no se puede eliminar por el modelo de negocio del sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE el concepto '{item.Nombre}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.ConceptoID);
                    await CargarConceptosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvConceptos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConceptos.CurrentRow != null && dgvConceptos.CurrentRow.DataBoundItem is ConceptoViewModel item)
            {
         


                if (item.Activo)
                {
                    btnDesactivar.Text = "Desactivar";
                    btnDesactivar.BackColor = System.Drawing.Color.IndianRed;
                }
                else
                {
                    btnDesactivar.Text = "Activar";
                    btnDesactivar.BackColor = System.Drawing.Color.ForestGreen;
                }
            }
        }
    }
}
