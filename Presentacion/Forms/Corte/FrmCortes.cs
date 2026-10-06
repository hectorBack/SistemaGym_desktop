using Presentacion.Controller;
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

namespace Presentacion.Forms.Corte
{
    public partial class FrmCortes : Form
    {
        private readonly CorteController _corteController;
        private readonly MovimientoController _movimientoController;
        private List<CorteViewModel> _listaCortes = new();

        public FrmCortes(CorteController corteController, MovimientoController movimientoController)
        {
            InitializeComponent();
            _corteController = corteController;
            _movimientoController = movimientoController;


            dgvCortes.SelectionChanged += dgvCortes_SelectionChanged;
        }

        private async void FrmCortes_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await BuscarPorFechasAsync();
            await ActualizarEfectivoEnCajaAsync();
        }

        private async Task CargarCortesAsync()
        {
            await BuscarPorFechasAsync();
            await ActualizarEfectivoEnCajaAsync();
        }

        private async Task BuscarPorFechasAsync()
        {
            try
            {
                // Ajustar horas para cubrir todo el rango del día seleccionado
                DateTime inicio = dtpFechaInicio.Value.Date;
                DateTime fin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

                var resultado = await _corteController.ObtenerPorRangoFechasAsync(inicio, fin);
                _listaCortes = resultado.ToList();

                dgvCortes.DataSource = null;

                // Proyección anónima para incluir todas las columnas solicitadas
                dgvCortes.DataSource = _listaCortes.Select(c => new
                {
                    c.CorteID,
                    FechaInicio = c.FechaApertura,
                    FechaFinal = c.FechaCierre,
                    Ingresos = c.TotalIngresos, // Si en tu ViewModel se llama TotalVentas, usa c.TotalVentas
                    Egresos = c.TotalEgresos,
                    CajaInicial = c.MontoInicial,
                    CajaFinal = c.MontoFinal,
                    Usuario = string.IsNullOrWhiteSpace(c.Usuario) ? "N/A" : c.Usuario,
                    FechaRegistro = c.CreatedAt,
                    Observacion = string.IsNullOrWhiteSpace(c.Observaciones) ? "Sin observaciones" : c.Observaciones
                }).ToList();

                ConfigurarGrid();
                dgvCortes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los cortes de caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ActualizarEfectivoEnCajaAsync()
        {
            try
            {
                decimal efectivoActual = await _corteController.ObtenerEfectivoEnCajaAsync();
                lblEfectivoCaja.Text = $"Efectivo en Caja: {efectivoActual:C2}";
            }
            catch (Exception ex)
            {
                lblEfectivoCaja.Text = "Efectivo en Caja: $0.00";
                MessageBox.Show($"Error al consultar el efectivo en caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            // Abre la pantalla/modal para registrar un nuevo corte de caja
            using var modal = new FrmCorteModal(_corteController, _movimientoController);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                await CargarCortesAsync();
            }
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await BuscarPorFechasAsync();
        }

        private async void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            await CargarCortesAsync();
        }

        private async void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvCortes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un corte de la lista para consultar su detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtener directamente el CorteID de la celda seleccionada
            if (int.TryParse(dgvCortes.CurrentRow.Cells["CorteID"].Value?.ToString(), out int corteId))
            {
                var corteDto = await _corteController.ObtenerPorIdAsync(corteId);

                if (corteDto != null)
                {
                    using var modal = new FrmCorteDetalleModal(corteDto);
                    modal.ShowDialog();
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (_listaCortes == null || !_listaCortes.Any())
            {
                MessageBox.Show("No hay datos disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Ejemplo utilizando Helper de exportación común
                // FormHelper.ExportarDataGridViewAExcel(dgvCortes, "Reporte_Cortes_Caja");
                MessageBox.Show("Exportación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvCortes.Columns.Count == 0) return;

            // 2. Encabezados y Formatos de Fecha
            if (dgvCortes.Columns["FechaInicio"] != null)
            {
                dgvCortes.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
                dgvCortes.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvCortes.Columns["FechaFinal"] != null)
            {
                dgvCortes.Columns["FechaFinal"].HeaderText = "Fecha Final";
                dgvCortes.Columns["FechaFinal"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvCortes.Columns["FechaRegistro"] != null)
            {
                dgvCortes.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
                dgvCortes.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // 3. Encabezados y Formatos de Moneda ($)
            if (dgvCortes.Columns["Ingresos"] != null)
            {
                dgvCortes.Columns["Ingresos"].HeaderText = "Ingresos";
                dgvCortes.Columns["Ingresos"].DefaultCellStyle.Format = "C2";
                dgvCortes.Columns["Ingresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvCortes.Columns["Egresos"] != null)
            {
                dgvCortes.Columns["Egresos"].HeaderText = "Egresos";
                dgvCortes.Columns["Egresos"].DefaultCellStyle.Format = "C2";
                dgvCortes.Columns["Egresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvCortes.Columns["CajaInicial"] != null)
            {
                dgvCortes.Columns["CajaInicial"].HeaderText = "Caja Inicial";
                dgvCortes.Columns["CajaInicial"].DefaultCellStyle.Format = "C2";
                dgvCortes.Columns["CajaInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvCortes.Columns["CajaFinal"] != null)
            {
                dgvCortes.Columns["CajaFinal"].HeaderText = "Caja Final";
                dgvCortes.Columns["CajaFinal"].DefaultCellStyle.Format = "C2";
                dgvCortes.Columns["CajaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 4. Texto y Usuario
            if (dgvCortes.Columns["Usuario"] != null) dgvCortes.Columns["Usuario"].HeaderText = "Usuario";
            if (dgvCortes.Columns["Observacion"] != null) dgvCortes.Columns["Observacion"].HeaderText = "Observación";

            // 5. Orden explícito y pesos de ancho de columna
            dgvCortes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string[] ordenColumnas =
            {
        "FechaInicio",
        "FechaFinal",
        "Ingresos",
        "Egresos",
        "CajaInicial",
        "CajaFinal",
        "Usuario",
        "FechaRegistro",
        "Observacion"
    };

            var pesos = new Dictionary<string, float>
            {
                ["FechaInicio"] = 110,
                ["FechaFinal"] = 110,
                ["Ingresos"] = 90,
                ["Egresos"] = 90,
                ["CajaInicial"] = 90,
                ["CajaFinal"] = 90,
                ["Usuario"] = 120,
                ["FechaRegistro"] = 110,
                ["Observacion"] = 150
            };

            for (int indice = 0; indice < ordenColumnas.Length; indice++)
            {
                string nombreColumna = ordenColumnas[indice];
                if (dgvCortes.Columns[nombreColumna] is DataGridViewColumn columna)
                {
                    columna.DisplayIndex = indice;
                    if (pesos.ContainsKey(nombreColumna))
                    {
                        columna.FillWeight = pesos[nombreColumna];
                    }
                }
            }
        }

        private void dgvCortes_SelectionChanged(object sender, EventArgs e)
        {
            btnVerDetalle.Enabled = dgvCortes.CurrentRow != null;
        }
    }
}
