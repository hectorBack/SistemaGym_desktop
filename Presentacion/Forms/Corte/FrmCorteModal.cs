using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
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

namespace Presentacion.Forms.Corte
{
    public partial class FrmCorteModal : Form
    {
        /// <summary>Una fila del grid. Los importes son decimal (no texto) para que se alineen y ordenen bien.</summary>
        private sealed record FilaMovimiento(
            DateTime? Fecha,
            string Concepto,
            string Tipo,
            string FormaPago,
            decimal Ingresos,
            decimal Egresos,
            string Observacion);

        private readonly CorteController _corteController;
        private readonly MovimientoController _movimientoController;
        private readonly IEmailService _emailService;
        private readonly decimal _efectivoInicialPredeterminado;
        private readonly int _usuarioIdActual;

        private List<MovimientoViewModel> _movimientos = new();
        private decimal _efectivoInicial;
        private decimal _totalIngresos;
        private decimal _totalEgresos;
        private decimal _montoFinal;

        private bool _guardando;
        private bool _asignandoFechas;

        // Mientras el usuario no toque "Fecha fin", se entiende como "hasta este momento":
        // al realizar el corte se actualiza a la hora exacta para no dejar movimientos fuera.
        private bool _finAutomatico = true;

        public FrmCorteModal(
            CorteController corteController,
            MovimientoController movimientoController,
            IEmailService emailService,
            int usuarioIdActual)
            : this(corteController, movimientoController, emailService, 0m, usuarioIdActual)
        {
        }

        public FrmCorteModal(
            CorteController corteController,
            MovimientoController movimientoController,
            IEmailService emailService,
            decimal efectivoInicialPredeterminado,
            int usuarioIdActual)
        {
            _corteController = corteController ?? throw new ArgumentNullException(nameof(corteController));
            _movimientoController = movimientoController ?? throw new ArgumentNullException(nameof(movimientoController));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _efectivoInicialPredeterminado = efectivoInicialPredeterminado;
            _usuarioIdActual = usuarioIdActual > 0 ? usuarioIdActual : SesionUsuario.UsuarioID;

            InitializeComponent();
            ConfigurarColumnas();
        }

        // ───────────── Carga ─────────────

        private async void FrmCorteModal_Load(object? sender, EventArgs e)
        {
            _asignandoFechas = true;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Now;
            _asignandoFechas = false;

            await ConsultarAsync();
        }

        private void ConfigurarColumnas()
        {
            dgvMovimientos.AutoGenerateColumns = false;

            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Fecha), "Fecha", 190, 190, "dd/MM/yyyy hh:mm tt");
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Concepto), "Concepto", 180, 160);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Tipo), "Tipo", 70, 80);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.FormaPago), "Forma de pago", 110, 130);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Ingresos), "Ingresos", 90, 100, "C2", alinearDerecha: true)
                .DefaultCellStyle.ForeColor = Tema.Exito;
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Egresos), "Egresos", 90, 100, "C2", alinearDerecha: true)
                .DefaultCellStyle.ForeColor = Tema.Peligro;
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Observacion), "Observación", 140, 120);
        }

        // Los importes en cero se dejan en blanco para que se lea mejor qué es ingreso y qué es egreso.
        private void dgvMovimientos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value is not decimal valor || valor != 0m) return;

            string propiedad = dgvMovimientos.Columns[e.ColumnIndex].DataPropertyName;
            if (propiedad == nameof(FilaMovimiento.Ingresos) || propiedad == nameof(FilaMovimiento.Egresos))
            {
                e.Value = string.Empty;
                e.FormattingApplied = true;
            }
        }

        // ───────────── Consulta ─────────────

        private void dtpFechaFin_ValueChanged(object? sender, EventArgs e)
        {
            if (!_asignandoFechas)
                _finAutomatico = false; // el usuario eligió una fecha concreta
        }

        private async void btnConsultar_Click(object? sender, EventArgs e) => await ConsultarAsync();

        private async Task<bool> ConsultarAsync()
        {
            DateTime inicio = dtpFechaInicio.Value;
            DateTime fin = dtpFechaFin.Value;

            if (inicio > fin)
            {
                FormHelper.MostrarAdvertencia("La fecha de inicio no puede ser posterior a la fecha fin.", "Rango de fechas");
                return false;
            }

            return await FormHelper.EjecutarAsync(async () =>
            {
                var movimientos = await _movimientoController.ObtenerPorRangoFechasAsync(inicio, fin);

                // El fondo es el del corte abierto del usuario; si no tiene uno, el predeterminado de la configuración.
                // (Antes se usaba el "efectivo en caja", que ahora ya incluye los movimientos y los contaría dos veces.)
                var corteAbierto = await _corteController.ObtenerCorteAbiertoPorUsuarioAsync(_usuarioIdActual);
                decimal efectivoInicial = corteAbierto?.MontoInicial ?? _efectivoInicialPredeterminado;

                if (IsDisposed) return;

                // El corte cuenta todos los movimientos activos, sin importar la forma de pago (Efectivo, Tarjeta, Otro...).
                _movimientos = movimientos
                    .Where(m => m.Activo)
                    .ToList();
                _efectivoInicial = efectivoInicial;

                MostrarMovimientos();
                CalcularTotales();
            },
            "No se pudieron cargar los datos del corte.",
            panelFiltros, btnRealizarCorte);
        }

        private void MostrarMovimientos()
        {
            var filas = _movimientos
                .Select(m =>
                {
                    bool ingreso = TipoMovimiento.EsIngreso(m.Tipo);
                    return new FilaMovimiento(
                        m.CreatedAt,
                        m.ConceptoNombre ?? string.Empty,
                        m.Tipo ?? string.Empty,
                        m.FormaPago ?? string.Empty,
                        ingreso ? m.Total : 0m,
                        ingreso ? 0m : m.Total,
                        m.Observacion ?? string.Empty);
                })
                .ToList();

            dgvMovimientos.DataSource = new ListaOrdenable<FilaMovimiento>(filas);
            dgvMovimientos.ClearSelection();

            lblConteo.Text = $"{filas.Count} movimiento(s)";
        }

        private void CalcularTotales()
        {
            _totalIngresos = _movimientos.Where(m => TipoMovimiento.EsIngreso(m.Tipo)).Sum(m => m.Total);
            _totalEgresos = _movimientos.Where(m => !TipoMovimiento.EsIngreso(m.Tipo)).Sum(m => m.Total);
            _montoFinal = _efectivoInicial + _totalIngresos - _totalEgresos;

            lblEfectivoInicialValue.Text = _efectivoInicial.ToString("C2");
            lblTotalIngresosValue.Text = _totalIngresos.ToString("C2");
            lblTotalEgresosValue.Text = _totalEgresos.ToString("C2");
            lblEfectivoFinalValue.Text = _montoFinal.ToString("C2");
        }

        // ───────────── Realizar el corte ─────────────

        private async void btnRealizarCorte_Click(object? sender, EventArgs e)
        {
            if (_guardando) return;

            // Con "fecha fin" automática se toma el momento exacto del corte y se vuelve a consultar,
            // para que lo que se confirma sea justo lo que se guarda.
            if (_finAutomatico)
            {
                _asignandoFechas = true;
                dtpFechaFin.Value = DateTime.Now;
                _asignandoFechas = false;
            }

            if (!await ConsultarAsync() || IsDisposed) return;

            string aviso = _movimientos.Count == 0
                ? "No hay movimientos activos en este rango.\n\n"
                : string.Empty;

            if (!FormHelper.ConfirmarAccion(
                    $"{aviso}¿Realizar el corte de caja con estos totales?\n\n" +
                    $"Ingresos:  {_totalIngresos:C2}\n" +
                    $"Egresos:  {_totalEgresos:C2}\n" +
                    $"Total en caja:  {_montoFinal:C2}",
                    "Confirmar corte de caja"))
                return;

            // Se toman los valores antes del await: lo guardado es exactamente lo confirmado.
            decimal ingresos = _totalIngresos;
            decimal egresos = _totalEgresos;
            decimal montoFinal = _montoFinal;
            DateTime periodoInicio = dtpFechaInicio.Value; // el periodo que el usuario vio y confirmó
            string observaciones = txtObservaciones.Text.Trim();

            _guardando = true;
            bool realizado = await FormHelper.EjecutarAsync(async () =>
            {
                // Si el usuario no tiene un corte abierto, se abre automáticamente.
                var corteAbierto = await _corteController.ObtenerCorteAbiertoPorUsuarioAsync(_usuarioIdActual);

                int corteId = corteAbierto != null
                    ? corteAbierto.CorteID
                    : (await _corteController.AbrirCorteAsync(_usuarioIdActual, _efectivoInicialPredeterminado)).CorteID;

                await _corteController.CerrarCorteAsync(
                    corteId: corteId,
                    totalIngresos: ingresos,
                    totalEgresos: egresos,
                    montoFinal: montoFinal,
                    observaciones: observaciones,
                    periodoInicio: periodoInicio);

                try
                {
                    await _emailService.EnviarCorreoCorteCajaAsync(
                        efectivoInicial: _efectivoInicial,
                        totalVentas: ingresos,
                        totalEntradas: 0m, // Ajusta si manejas entradas/salidas desglosadas en tu lógica de negocio
                        totalSalidas: egresos,
                        efectivoEsperado: montoFinal,
                        efectivoReal: montoFinal, // O el monto físico contado si aplica
                        diferencia: 0m,
                        fechaCorte: DateTime.Now,
                        fechaInicio: periodoInicio
                    );
                }
                catch (Exception mailEx)
                {
                    // Registramos de forma silenciosa o advertimos sin bloquear el éxito del cierre de caja
                    System.Diagnostics.Debug.WriteLine($"No se pudo enviar el correo de corte de caja: {mailEx.Message}");
                }

            },
            "No se pudo realizar el corte de caja.",
            btnRealizarCorte, btnCancelar, panelFiltros, txtObservaciones);
            _guardando = false;

            if (realizado && !IsDisposed)
                DialogResult = DialogResult.OK; // cierra el diálogo; el historial se recarga solo
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // No cerrar mientras se está guardando el corte.
            if (_guardando)
                e.Cancel = true;

            base.OnFormClosing(e);
        }
    }
}
