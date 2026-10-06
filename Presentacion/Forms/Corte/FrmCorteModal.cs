using Negocio.DTOs;
using Negocio.Exceptions;
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
    public partial class FrmCorteModal : Form
    {
        private readonly CorteController _corteController;
        private readonly MovimientoController _movimientoController;

        private readonly int _usuarioIdActual = 1;
        private List<MovimientoViewModel> _movimientosActuales = new();

        private decimal _totalIngresos;
        private decimal _totalEgresos;
        private decimal _montoFinalCalculado;

        public FrmCorteModal(
            CorteController corteController,
            MovimientoController movimientoController)
        {
            InitializeComponent();

            _corteController = corteController;
            _movimientoController = movimientoController;

            lblTitulo.Text = "Corte de Caja / Flujo de Efectivo";
        }

        private async void FrmCorteModal_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddDays(1).AddTicks(-1);

            await ConsultarMovimientosAsync();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            await ConsultarMovimientosAsync();
        }

        private async Task ConsultarMovimientosAsync()
        {
            try
            {
                btnConsultar.Enabled = false;

                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);

                // Obtener movimientos por rango utilizando MovimientoController
                var movimientos = await _movimientoController.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);
                _movimientosActuales = movimientos.Where(m => m.Activo).ToList();

                // LLAMADA CORREGIDA: sin parámetro y utilizando el nombre exacto de tu controller
                decimal efectivoInicial = await _corteController.ObtenerEfectivoEnCajaAsync();

                LlenarGridMovimientos(_movimientosActuales);
                CalcularTotales(efectivoInicial);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del corte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConsultar.Enabled = true;
            }
        }

        private void LlenarGridMovimientos(List<MovimientoViewModel> lista)
        {
            dgvMovimientos.DataSource = null;
            dgvMovimientos.DataSource = lista.Select(m => new
            {
                ID = m.MovimientoID,
                Fecha = m.CreatedAt.HasValue ? m.CreatedAt.Value.ToString("dd/MM/yyyy HH:mm") : "N/A",
                Concepto = m.ConceptoNombre,
                Tipo = m.Tipo,
                FormaPago = m.FormaPago,
                Ingresos = EsIngreso(m.Tipo) ? m.Total.ToString("C2") : "$0.00",
                Egresos = !EsIngreso(m.Tipo) ? m.Total.ToString("C2") : "$0.00",
                Observacion = m.Observacion ?? string.Empty
            }).ToList();

            ConfigurarEstiloGrid();
        }

        private bool EsIngreso(string tipo)
        {
            return string.Equals(tipo, "Ingreso", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(tipo, "Entrada", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(tipo, "Venta", StringComparison.OrdinalIgnoreCase);
        }

        private void CalcularTotales(decimal efectivoInicial)
        {
            // Asignar directamente a las variables privadas de la clase
            _totalIngresos = _movimientosActuales
                .Where(m => EsIngreso(m.Tipo))
                .Sum(m => m.Total);

            _totalEgresos = _movimientosActuales
                .Where(m => !EsIngreso(m.Tipo))
                .Sum(m => m.Total);

            _montoFinalCalculado = efectivoInicial + _totalIngresos - _totalEgresos;

            lblTotalIngresosValue.Text = _totalIngresos.ToString("C2");
            lblTotalEgresosValue.Text = _totalEgresos.ToString("C2");
            lblEfectivoInicialValue.Text = efectivoInicial.ToString("C2");
            lblEfectivoFinalValue.Text = _montoFinalCalculado.ToString("C2");
        }

        private async void btnRealizarCorte_Click(object sender, EventArgs e)
        {
            if (!_movimientosActuales.Any())
            {
                var result = MessageBox.Show(
                    "No se encontraron movimientos activos registrados en este rango. ¿Deseas realizar el corte de todas formas?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;
            }

            try
            {
                btnRealizarCorte.Enabled = false;

                // 1. Validar que exista un corte abierto para el usuario
                var corteAbierto = await _corteController.ObtenerCorteAbiertoPorUsuarioAsync(_usuarioIdActual);

                if (corteAbierto == null)
                {
                    MessageBox.Show("No se encontró ningún corte de caja abierto para este usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Ejecutar el cierre utilizando el método exacto de CorteController
                await _corteController.CerrarCorteAsync(
                    corteId: corteAbierto.CorteID,
                    totalIngresos: _totalIngresos,       // Cambia por tu variable con el total de ingresos calculados
                    totalEgresos: _totalEgresos,         // Cambia por tu variable con el total de egresos calculados
                    montoFinal: _montoFinalCalculado,    // Cambia por tu variable con el monto final de caja
                    observaciones: txtObservaciones.Text.Trim()
                );

                MessageBox.Show("El corte de caja se ha realizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al procesar el corte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRealizarCorte.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfigurarEstiloGrid()
        {
            if (dgvMovimientos.Columns.Count == 0) return;

            dgvMovimientos.Columns["ID"].HeaderText = "ID";
            dgvMovimientos.Columns["Fecha"].HeaderText = "Fecha";
            dgvMovimientos.Columns["Concepto"].HeaderText = "Concepto";
            dgvMovimientos.Columns["Tipo"].HeaderText = "Tipo";
            dgvMovimientos.Columns["FormaPago"].HeaderText = "Forma Pago";
            dgvMovimientos.Columns["Ingresos"].HeaderText = "Ingresos";
            dgvMovimientos.Columns["Egresos"].HeaderText = "Egresos";
            dgvMovimientos.Columns["Observacion"].HeaderText = "Observación";

            dgvMovimientos.Columns["Ingresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMovimientos.Columns["Egresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
