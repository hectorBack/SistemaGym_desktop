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
        private readonly decimal _efectivoInicialPredeterminado;

        private readonly int _usuarioIdActual;
        private List<MovimientoViewModel> _movimientosActuales = new();

        private decimal _totalIngresos;
        private decimal _totalEgresos;
        private decimal _montoFinalCalculado;

        public FrmCorteModal(
         CorteController corteController,
         MovimientoController movimientoController,
         int usuarioIdActual)
         : this(corteController, movimientoController, 0m, usuarioIdActual)
        {
        }

        public FrmCorteModal(
         CorteController corteController,
         MovimientoController movimientoController,
         decimal efectivoInicialPredeterminado,
         int usuarioIdActual)
        {
            InitializeComponent();

            _corteController = corteController;
            _movimientoController = movimientoController;
            _efectivoInicialPredeterminado = efectivoInicialPredeterminado;
            _usuarioIdActual = usuarioIdActual;

            lblTitulo.Text = "Corte de Caja / Flujo de Efectivo";
        }

        private async void FrmCorteModal_Load(object sender, EventArgs e)
        {
            // Configurar el formato visual para incluir fecha y hora
            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm";

            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Now;

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

                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                // Obtener movimientos por rango utilizando MovimientoController
                var movimientos = await _movimientoController.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);
                _movimientosActuales = movimientos.Where(m => m.Activo).ToList();

                // Si se recibió un efectivo inicial de la configuración, se usa; en caso contrario, se consulta el actual
                decimal efectivoInicial = _efectivoInicialPredeterminado > 0
                ? _efectivoInicialPredeterminado
                : await _corteController.ObtenerEfectivoEnCajaAsync();

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

                // 1. Consultar si el usuario en sesión tiene un corte abierto
                var corteAbierto = await _corteController.ObtenerCorteAbiertoPorUsuarioAsync(_usuarioIdActual);

                int corteIdAProcesar;

                if (corteAbierto == null)
                {
                    // Si no existe un registro de apertura previo, lo abrimos automáticamente
                    var nuevoCorteDto = await _corteController.AbrirCorteAsync(_usuarioIdActual, _efectivoInicialPredeterminado);

                    // Accedemos a la propiedad .CorteID de la respuesta
                    corteIdAProcesar = nuevoCorteDto.CorteID;
                }
                else
                {
                    corteIdAProcesar = corteAbierto.CorteID;
                }

                // 2. Realizar el cierre/corte definitivo de la caja
                await _corteController.CerrarCorteAsync(
                    corteId: corteIdAProcesar,
                    totalIngresos: _totalIngresos,
                    totalEgresos: _totalEgresos,
                    montoFinal: _montoFinalCalculado,
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
