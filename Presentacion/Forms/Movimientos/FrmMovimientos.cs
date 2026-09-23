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

namespace Presentacion.Forms.Movimientos
{
    public partial class FrmMovimientos : Form
    {
        private readonly MovimientoController _controller;
        private readonly ConceptoController _conceptoController;
        private List<MovimientoViewModel> _listaMovimientos = new();

        public FrmMovimientos(MovimientoController controller,
            ConceptoController conceptoController)
        {
            InitializeComponent();
            _controller = controller;
            _conceptoController = conceptoController;
            dgvMovimientos.SelectionChanged += dgvMovimientos_SelectionChanged;
        }

        private async void FrmMovimientos_Load(object sender, EventArgs e)
        {
            // Inicializar selectores de fecha con la fecha de hoy
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            // Cargar inicialmente los datos según el rango de fechas actual
            await BuscarPorFechasAsync();
        }

        private async Task CargarMovimientosAsync()
        {
            await BuscarPorFechasAsync();
            
        }

        private async void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            await BuscarPorFechasAsync();
        }

        private async Task BuscarPorFechasAsync()
        {
            try
            {
                // Cubre las 24 horas del día final (hasta las 23:59:59.999)
                DateTime inicio = dtpFechaInicio.Value.Date;
                DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

                var resultado = await _controller.ObtenerPorRangoFechasAsync(inicio, fin);
                _listaMovimientos = resultado.ToList();

                // 🟢 VINCULAR DATOS AL DATAGRIDVIEW Y APLICAR FORMATO
                dgvMovimientos.DataSource = null;
                dgvMovimientos.DataSource = _listaMovimientos;

                ConfigurarGrid();
                dgvMovimientos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar movimientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            // 1. Ocultar columnas técnicas y de FKs brutas
            if (dgvMovimientos.Columns["Activo"] != null) dgvMovimientos.Columns["Activo"].Visible = false;
            if (dgvMovimientos.Columns["ConceptoID"] != null) dgvMovimientos.Columns["ConceptoID"].Visible = false;

            // 2. Configurar encabezados
            if (dgvMovimientos.Columns["MovimientoID"] != null) dgvMovimientos.Columns["MovimientoID"].HeaderText = "ID";
            if (dgvMovimientos.Columns["Tipo"] != null) dgvMovimientos.Columns["Tipo"].HeaderText = "Tipo";
            if (dgvMovimientos.Columns["ConceptoNombre"] != null) dgvMovimientos.Columns["ConceptoNombre"].HeaderText = "Concepto";
            if (dgvMovimientos.Columns["FormaPago"] != null) dgvMovimientos.Columns["FormaPago"].HeaderText = "Forma Pago";
            if (dgvMovimientos.Columns["Total"] != null) dgvMovimientos.Columns["Total"].HeaderText = "Total";
            if (dgvMovimientos.Columns["Observacion"] != null) dgvMovimientos.Columns["Observacion"].HeaderText = "Observaciones";
            if (dgvMovimientos.Columns["CorteID"] != null) dgvMovimientos.Columns["CorteID"].HeaderText = "Corte ID";
            if (dgvMovimientos.Columns["UsuarioID"] != null) dgvMovimientos.Columns["UsuarioID"].HeaderText = "Usuario ID";
            if (dgvMovimientos.Columns["Estado"] != null) dgvMovimientos.Columns["Estado"].HeaderText = "Estado";
            if (dgvMovimientos.Columns["CreatedAt"] != null) dgvMovimientos.Columns["CreatedAt"].HeaderText = "Fecha Registro";

            // Formato de moneda para el Total
            if (dgvMovimientos.Columns["Total"] != null)
            {
                dgvMovimientos.Columns["Total"].DefaultCellStyle.Format = "C2";
            }

            // 3. Estructura de ordenamiento y pesos
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
                "MovimientoID",
                "Tipo",
                "ConceptoNombre",
                "FormaPago",
                "Total",
                "Observacion",
                "CorteID",
                "UsuarioID",
                "Estado",
                "CreatedAt"
            };

            var pesos = new Dictionary<string, float>
            {
                ["MovimientoID"] = 45,
                ["Tipo"] = 70,
                ["ConceptoNombre"] = 140,
                ["FormaPago"] = 90,
                ["Total"] = 85,
                ["Observacion"] = 150,
                ["CorteID"] = 60,
                ["UsuarioID"] = 60,
                ["Estado"] = 70,
                ["CreatedAt"] = 110
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvMovimientos.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "ConceptoNombre" => 100,
                    "Observacion" => 100,
                    "CreatedAt" => 95,
                    _ => 50
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            // Nota: Pasar la instancia del controller de movimientos y el de conceptos en la modal cuando se construya el FrmMovimientoModal
            using var modal = new FrmMovimientoModal(_controller, null, _conceptoController);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarMovimientosAsync();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMovimientos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un movimiento de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (MovimientoViewModel)dgvMovimientos.CurrentRow.DataBoundItem;
            using var modal = new FrmMovimientoModal(_controller, item.MovimientoID, _conceptoController);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarMovimientosAsync();
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvMovimientos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un movimiento de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (MovimientoViewModel)dgvMovimientos.CurrentRow.DataBoundItem;
            string accion = item.Activo ? "desactivar" : "activar";

            if (FormHelper.ConfirmarAccion($"¿Está seguro de {accion} el movimiento con ID '{item.MovimientoID}'?", $"Confirmar {accion.ToUpper()}"))
            {
                try
                {
                    await _controller.CambiarEstadoLogicoAsync(item.MovimientoID);
                    await CargarMovimientosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvMovimientos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un movimiento de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (MovimientoViewModel)dgvMovimientos.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE el movimiento con ID '{item.MovimientoID}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.MovimientoID);
                    await CargarMovimientosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        private void dgvMovimientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMovimientos.CurrentRow != null && dgvMovimientos.CurrentRow.DataBoundItem is MovimientoViewModel item)
            {
                if (item.Activo)
                {
                    btnDesactivar.Text = "Desactivar";
                    btnDesactivar.BackColor = Color.IndianRed;
                }
                else
                {
                    btnDesactivar.Text = "Activar";
                    btnDesactivar.BackColor = Color.ForestGreen;
                }
            }
        }
    }
}
