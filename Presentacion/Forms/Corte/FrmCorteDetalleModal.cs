using Negocio.DTOs;
using Presentacion.Controller;
using Presentacion.Helpers;
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
    public partial class FrmCorteDetalleModal : Form
    {
        /// <summary>Una fila del desglose. Los importes son decimal (no texto) para que se alineen y ordenen bien.</summary>
        private sealed record FilaMovimiento(
            DateTime? Fecha,
            string Concepto,
            string TipoPago,
            decimal Ingresos,
            decimal Egresos);

        private readonly CorteDto _corte;
        private readonly MovimientoController _movimientoController;

        public FrmCorteDetalleModal(CorteDto corte, MovimientoController movimientoController)
        {
            _corte = corte ?? throw new ArgumentNullException(nameof(corte));
            _movimientoController = movimientoController ?? throw new ArgumentNullException(nameof(movimientoController));

            InitializeComponent();
            ConfigurarColumnas();
            MostrarDatosCorte(); // la cabecera sale de _corte, no necesita consultar nada
        }

        // Las columnas se definen una sola vez.
        private void ConfigurarColumnas()
        {
            dgvMovimientos.AutoGenerateColumns = false;

            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Fecha), "Fecha", 110, 110, "dd/MM/yyyy HH:mm");
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Concepto), "Concepto", 170, 100);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.TipoPago), "Tipo de pago", 90, 90);
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Ingresos), "Ingresos", 85, 85, "C2", alinearDerecha: true)
                .DefaultCellStyle.ForeColor = Tema.Exito;
            dgvMovimientos.AgregarTexto(nameof(FilaMovimiento.Egresos), "Egresos", 85, 85, "C2", alinearDerecha: true)
                .DefaultCellStyle.ForeColor = Tema.Peligro;
        }

        private void MostrarDatosCorte()
        {
            lblUsuarioValor.Text = string.IsNullOrWhiteSpace(_corte.NombreUsuario) ? "N/A" : _corte.NombreUsuario;

            lblEstadoValor.Text = _corte.Estado;
            lblEstadoValor.ForeColor = string.Equals(_corte.Estado, "Abierto", StringComparison.OrdinalIgnoreCase)
                ? Tema.Advertencia
                : Tema.Exito;

            lblFechaInicioValor.Text = _corte.FechaApertura.ToString("dd/MM/yyyy HH:mm");
            lblFechaFinValor.Text = _corte.FechaCierre.HasValue
                ? _corte.FechaCierre.Value.ToString("dd/MM/yyyy HH:mm")
                : "En proceso";

            lblObservacionValor.Text = string.IsNullOrWhiteSpace(_corte.Observaciones)
                ? "Sin observaciones"
                : _corte.Observaciones;

            lblEfectivoInicialValor.Text = _corte.MontoInicial.ToString("C2");
            lblTotalIngresosValor.Text = _corte.TotalIngresos.ToString("C2");
            lblTotalEgresosValor.Text = _corte.TotalEgresos.ToString("C2");
            lblEfectivoFinalValor.Text = _corte.MontoFinal.ToString("C2");
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

        private async void FrmCorteDetalleModal_Load(object? sender, EventArgs e)
        {
            // Si falla, el modal sigue abierto: los totales de arriba ya son válidos por sí solos.
            await FormHelper.EjecutarAsync(async () =>
            {
                DateTime inicio = _corte.FechaApertura;
                DateTime fin = _corte.FechaCierre ?? DateTime.Now;

                var movimientos = await _movimientoController.ObtenerPorRangoFechasAsync(inicio, fin);
                if (IsDisposed) return;

                var filas = movimientos
                    .Where(m => m.Activo)
                    .Select(m =>
                    {
                        bool ingreso = TipoMovimiento.EsIngreso(m.Tipo);
                        return new FilaMovimiento(
                            m.CreatedAt,
                            m.ConceptoNombre ?? string.Empty,
                            string.IsNullOrWhiteSpace(m.FormaPago) ? "Efectivo" : m.FormaPago,
                            ingreso ? m.Total : 0m,
                            ingreso ? 0m : m.Total);
                    })
                    .ToList();

                dgvMovimientos.DataSource = new ListaOrdenable<FilaMovimiento>(filas);
                dgvMovimientos.ClearSelection();

                lblConteo.Text = $"{filas.Count} movimiento(s)";
            },
            "No se pudo cargar el detalle de movimientos del corte.",
            dgvMovimientos);
        }
    }
}
