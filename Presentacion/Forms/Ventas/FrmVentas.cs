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

namespace Presentacion.Forms.Ventas
{
    public partial class FrmVentas : Form
    {
        private readonly VentaController _ventaController;
        private readonly ProductoController _productoController;
        private List<VentaViewModel> _listaVentas = new();

        public FrmVentas(VentaController ventaController, ProductoController productoController)
        {
            InitializeComponent();
            _ventaController = ventaController;
            _productoController = productoController;

            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
        }

        private async void FrmVentas_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
        }

        private async Task CargarVentasAsync()
        {
            await BuscarPorFechasAsync();
        }

        private async Task BuscarPorFechasAsync()
        {
            try
            {
                // Ajustar horas para cubrir todo el rango del día seleccionado
                DateTime inicio = dtpFechaInicio.Value.Date;
                DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

                var resultado = await _ventaController.ObtenerPorRangoFechasAsync(inicio, fin);
                _listaVentas = resultado.ToList();
                dgvVentas.DataSource = null;
                dgvVentas.DataSource = _listaVentas;

                ConfigurarGrid();
                dgvVentas.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            await BuscarPorFechasAsync();
        }


        private void ConfigurarGrid()
        {
            // 1. Ocultar columnas secundarias/técnicas
            if (dgvVentas.Columns["UsuarioID"] != null) dgvVentas.Columns["UsuarioID"].Visible = false;
            if (dgvVentas.Columns["SocioID"] != null) dgvVentas.Columns["SocioID"].Visible = false;
            if (dgvVentas.Columns["Activo"] != null) dgvVentas.Columns["Activo"].Visible = false;
            if (dgvVentas.Columns["CreatedAt"] != null) dgvVentas.Columns["CreatedAt"].Visible = false;

            // 2. Configurar encabezados y formatos especiales
            if (dgvVentas.Columns["VentaID"] != null) dgvVentas.Columns["VentaID"].HeaderText = "Folio / ID";
            if (dgvVentas.Columns["SocioNombre"] != null) dgvVentas.Columns["SocioNombre"].HeaderText = "Cliente / Socio";
            if (dgvVentas.Columns["UsuarioNombre"] != null) dgvVentas.Columns["UsuarioNombre"].HeaderText = "Atendido Por";

            if (dgvVentas.Columns["Total"] != null)
            {
                dgvVentas.Columns["Total"].HeaderText = "Total ($)";
                dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
            }

            if (dgvVentas.Columns["CantidadProductos"] != null)
            {
                dgvVentas.Columns["CantidadProductos"].HeaderText = "Cant. Ítems";
            }

            if (dgvVentas.Columns["FechaVenta"] != null)
            {
                dgvVentas.Columns["FechaVenta"].HeaderText = "Fecha de Venta";
                dgvVentas.Columns["FechaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvVentas.Columns["Estado"] != null) dgvVentas.Columns["Estado"].HeaderText = "Estado";

            // 3. Estructura de ordenamiento y pesos
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
        "VentaID",
        "SocioNombre",
        "UsuarioNombre",
        "CantidadProductos",
        "Total",
        "FechaVenta",
        "Estado"
    };

            var pesos = new Dictionary<string, float>
            {
                ["VentaID"] = 60,
                ["SocioNombre"] = 175,
                ["UsuarioNombre"] = 150,
                ["CantidadProductos"] = 85,
                ["Total"] = 100,
                ["FechaVenta"] = 130,
                ["Estado"] = 80
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                if (dgvVentas.Columns[ordenColumnas[indice]] is not DataGridViewColumn columna)
                    continue;

                columna.DisplayIndex = indice;
                columna.FillWeight = pesos[columna.Name];
                columna.MinimumWidth = columna.Name switch
                {
                    "SocioNombre" or "UsuarioNombre" => 110,
                    "FechaVenta" => 100,
                    _ => 55
                };
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private async void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            // Abre la pantalla/modal de caja para registrar productos
            using var modal = new FrmVentaModal(_ventaController, _productoController);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarVentasAsync();
            }
        }

        private async void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta de la lista para consultar su detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (VentaViewModel)dgvVentas.CurrentRow.DataBoundItem;
            var ventaDto = await _ventaController.ObtenerPorIdAsync(item.VentaID);

            if (ventaDto != null)
            {
                using var modal = new FrmVentaDetalleModal(ventaDto);
                modal.ShowDialog();
            }
        }

        private async void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (VentaViewModel)dgvVentas.CurrentRow.DataBoundItem;

            if (!item.Activo)
            {
                MessageBox.Show("Esta venta ya se encuentra anulada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FormHelper.ConfirmarAccion($"¿Está seguro de anular la venta N° '{item.VentaID}' por un total de ${item.Total:N2}?\nSe reajustará el stock de los productos vendidos.", "Confirmar Anulación"))
            {
                try
                {
                    await _ventaController.AnularVentaAsync(item.VentaID);
                    await CargarVentasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (VentaViewModel)dgvVentas.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE el registro de la venta N° '{item.VentaID}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _ventaController.EliminarFisicoAsync(item.VentaID);
                    await CargarVentasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow != null && dgvVentas.CurrentRow.DataBoundItem is VentaViewModel item)
            {
                if (item.Activo)
                {
                    btnAnular.Enabled = true;
                    btnAnular.Text = "Anular Venta";
                    btnAnular.BackColor = Color.IndianRed;
                }
                else
                {
                    btnAnular.Enabled = false;
                    btnAnular.Text = "Anulada";
                    btnAnular.BackColor = Color.Gray;
                }
            }
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {

            // Restablecer el rango de fechas al día de hoy
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            // Volver a consultar las ventas del día actual
            await BuscarPorFechasAsync();
        }
    }
}
