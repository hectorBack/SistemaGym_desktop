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

namespace Presentacion.Forms.Compras
{
    public partial class FrmCompras : Form
    {
        private readonly CompraController _controller;
        private readonly ProductoController _productoController;
        private List<CompraViewModel> _listaCompras = new();

        public FrmCompras(CompraController controller, ProductoController productoController)
        {
            InitializeComponent();
            _controller = controller;
            _productoController = productoController;
            dgvCompras.SelectionChanged += dgvCompras_SelectionChanged;
        }

        private async void FrmCompras_Load(object sender, EventArgs e)
        {
            // Ocultar botón según permisos
            if (btnEliminarFisico != null)
                btnEliminarFisico.Visible = SesionUsuario.TienePermiso("Eliminar");

            // Establecer rango de fechas por defecto al día de hoy
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddDays(1).AddTicks(-1);

            await CargarComprasAsync();
        }

        private async Task CargarComprasAsync()
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

                var resultado = await _controller.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);
                _listaCompras = resultado.ToList();

                // Pausar layout y desvincular evento de selección
                dgvCompras.SuspendLayout();
                dgvCompras.SelectionChanged -= dgvCompras_SelectionChanged;

                // Asignación directa sin limpiar a null para evitar IndexOutOfRangeException
                dgvCompras.AutoGenerateColumns = true;
                dgvCompras.DataSource = _listaCompras;

                ConfigurarGrid();
                dgvCompras.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar compras: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar evento y refrescar estado de UI
                dgvCompras.SelectionChanged += dgvCompras_SelectionChanged;
                dgvCompras.ResumeLayout();
                ActualizarEstadoBotones();
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvCompras.Columns.Count == 0) return;

            // 1. Ocultar todas las columnas no requeridas
            string[] columnasAOcultar = { "CompraID", "UsuarioID", "UsuarioNombre", "Activo", "Observacion", "Detalles", "Total", "CreatedAt", "Codigo", "Estado" };
            foreach (var col in columnasAOcultar)
            {
                if (dgvCompras.Columns.Contains(col))
                    dgvCompras.Columns[col].Visible = false;
            }

            // 2. Configurar las columnas visibles
            if (dgvCompras.Columns.Contains("TotalTexto"))
            {
                dgvCompras.Columns["TotalTexto"].Visible = true;
                dgvCompras.Columns["TotalTexto"].HeaderText = "Total";
            }

            if (dgvCompras.Columns.Contains("FechaTexto"))
            {
                dgvCompras.Columns["FechaTexto"].Visible = true;
                dgvCompras.Columns["FechaTexto"].HeaderText = "Fecha de Registro";
            }

            if (dgvCompras.Columns.Contains("EstadoTexto"))
            {
                dgvCompras.Columns["EstadoTexto"].Visible = true;
                dgvCompras.Columns["EstadoTexto"].HeaderText = "Estado";
            }

            // 3. Formato y ordenamiento de columnas
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas = { "TotalTexto", "FechaTexto", "EstadoTexto" };

            var pesos = new Dictionary<string, float>
            {
                ["TotalTexto"] = 20,
                ["FechaTexto"] = 20,
                ["EstadoTexto"] = 90
            };

            int index = 0;
            foreach (string nombreColumna in ordenColumnas)
            {
                if (dgvCompras.Columns.Contains(nombreColumna))
                {
                    var columna = dgvCompras.Columns[nombreColumna];
                    columna.DisplayIndex = index++;
                    columna.FillWeight = pesos[nombreColumna];
                    columna.MinimumWidth = nombreColumna switch
                    {
                        "FechaTexto" => 110,
                        "TotalTexto" => 90,
                        _ => 70
                    };

                    if (nombreColumna == "TotalTexto")
                    {
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else
                    {
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                }
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            using var modal = new FrmCompraModal(_controller, _productoController);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarComprasAsync();
            }
        }

        private async void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow == null || dgvCompras.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccione una compra de la lista para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (CompraViewModel)dgvCompras.CurrentRow.DataBoundItem;

            if (item.Estado == "Cancelada" || !item.Activo)
            {
                MessageBox.Show("La compra seleccionada ya se encuentra cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FormHelper.ConfirmarAccion($"¿Está seguro de cancelar la compra con folio '{item.Codigo}' por {item.TotalTexto}?\nEsta acción reajustará el stock y registrará la devolución del importe en el corte de caja.", "Confirmar Cancelación"))
            {
                try
                {
                    int usuarioIdSesion = SesionUsuario.UsuarioID;
                    string observacion = "Cancelado desde módulo de compras";

                    // Se envía el usuarioIdSesion como nuevo parámetro requerido
                    await _controller.CancelarCompraAsync(item.CompraID, usuarioIdSesion, observacion);

                    MessageBox.Show("La compra se ha cancelado correctamente y se devolvió el efectivo a la caja.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CargarComprasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al cancelar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow == null || dgvCompras.CurrentRow.Index < 0)
            {
                MessageBox.Show("Seleccione una compra de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (CompraViewModel)dgvCompras.CurrentRow.DataBoundItem;

            if (FormHelper.ConfirmarAccion($"¿Desea eliminar PERMANENTEMENTE la compra '{item.Codigo}' de la base de datos?", "Eliminación Definitiva"))
            {
                try
                {
                    await _controller.EliminarFisicoAsync(item.CompraID);
                    await CargarComprasAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            if (dgvCompras.CurrentRow != null &&
                dgvCompras.CurrentRow.Index >= 0 &&
                dgvCompras.CurrentRow.DataBoundItem is CompraViewModel item)
            {
                if (btnDesactivar != null)
                {
                    if (item.Activo && item.Estado != "Cancelada")
                    {
                        btnDesactivar.Text = "Cancelar Compra";
                        btnDesactivar.BackColor = Color.IndianRed;
                        btnDesactivar.Enabled = true;
                    }
                    else
                    {
                        btnDesactivar.Text = "Cancelada";
                        btnDesactivar.BackColor = Color.Gray;
                        btnDesactivar.Enabled = false;
                    }
                }
            }
            else
            {
                if (btnDesactivar != null)
                {
                    btnDesactivar.Text = "Cancelar Compra";
                    btnDesactivar.BackColor = Color.Gray;
                    btnDesactivar.Enabled = false;
                }
            }
        }

        private async void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra de la lista para consultar su detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = (CompraViewModel)dgvCompras.CurrentRow.DataBoundItem;
            var compraDto = await _controller.ObtenerPorIdAsync(item.CompraID);

            if (compraDto != null)
            {
                using var modal = new FrmCompraDetalleModal(compraDto);
                modal.ShowDialog();
            }
        }

        private async void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            await CargarComprasAsync();
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await CargarComprasAsync();
        }
    }
}
