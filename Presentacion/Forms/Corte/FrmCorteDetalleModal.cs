using Negocio.DTOs;
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
        private readonly CorteDto _corte;

        public FrmCorteDetalleModal(CorteDto corte)
        {
            InitializeComponent();
            _corte = corte ?? throw new ArgumentNullException(nameof(corte));
        }

        private void FrmCorteDetalleModal_Load(object sender, EventArgs e)
        {
            CargarDatosCorte();
        }

        private void CargarDatosCorte()
        {
            // 1. Cabecera - Datos Generales del Corte
            // Se corrige UsuarioNombre -> NombreUsuario
            lblUsuarioValor.Text = string.IsNullOrWhiteSpace(_corte.NombreUsuario) ? "N/A" : _corte.NombreUsuario;
            lblEstadoValor.Text = _corte.Estado;

            lblFechaInicioValor.Text = _corte.FechaApertura.ToString("dd/MM/yyyy HH:mm");
            lblFechaFinValor.Text = _corte.FechaCierre.HasValue
                ? _corte.FechaCierre.Value.ToString("dd/MM/yyyy HH:mm")
                : "En Proceso";

            lblObservacionValor.Text = string.IsNullOrWhiteSpace(_corte.Observaciones)
                ? "Sin observaciones"
                : _corte.Observaciones;

            if (string.Equals(_corte.Estado, "Abierto", StringComparison.OrdinalIgnoreCase))
            {
                lblEstadoValor.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                lblEstadoValor.ForeColor = Color.ForestGreen;
            }

            // 2. Totales de Caja
            lblEfectivoInicialValor.Text = _corte.MontoInicial.ToString("C2");
            lblTotalIngresosValor.Text = _corte.TotalIngresos.ToString("C2");
            lblTotalEgresosValor.Text = _corte.TotalEgresos.ToString("C2");
            lblEfectivoFinalValor.Text = _corte.MontoFinal.ToString("C2");

            // 3. Cargar tabla de movimientos asociados
            // (Asegúrate de agregar 'public List<MovimientoDto> Movimientos { get; set; }' en CorteDto si usas _corte.Movimientos)
            if (_corte.Movimientos != null && _corte.Movimientos.Any())
            {
                dgvMovimientos.DataSource = _corte.Movimientos.Select(m => new
                {
                    Fecha = m.FechaMovimiento.ToString("dd/MM/yyyy HH:mm"),
                    Concepto = m.Concepto,
                    TipoPago = string.IsNullOrWhiteSpace(m.TipoPago) ? "Efectivo" : m.TipoPago,
                    Usuario = string.IsNullOrWhiteSpace(m.UsuarioNombre) ? "N/A" : m.UsuarioNombre,
                    Ingresos = EsIngreso(m.Tipo) ? m.Total.ToString("C2") : "$0.00",
                    Egresos = !EsIngreso(m.Tipo) ? m.Total.ToString("C2") : "$0.00"
                }).ToList();
            }
            else
            {
                dgvMovimientos.DataSource = null;
            }

            ConfigurarGrid();
        }

        private bool EsIngreso(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo)) return true;

            var t = tipo.Trim().ToLower();
            return t == "ingreso" || t == "venta" || t == "cobro";
        }

        private void ConfigurarGrid()
        {
            if (dgvMovimientos.Columns.Count == 0) return;

            if (dgvMovimientos.Columns["Fecha"] != null)
            {
                dgvMovimientos.Columns["Fecha"].HeaderText = "Fecha";
                dgvMovimientos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvMovimientos.Columns["Concepto"] != null)
                dgvMovimientos.Columns["Concepto"].HeaderText = "Concepto";

            if (dgvMovimientos.Columns["TipoPago"] != null)
            {
                dgvMovimientos.Columns["TipoPago"].HeaderText = "Tipo de Pago";
                dgvMovimientos.Columns["TipoPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvMovimientos.Columns["Usuario"] != null)
                dgvMovimientos.Columns["Usuario"].HeaderText = "Usuario";

            if (dgvMovimientos.Columns["Ingresos"] != null)
            {
                dgvMovimientos.Columns["Ingresos"].HeaderText = "Ingresos";
                dgvMovimientos.Columns["Ingresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMovimientos.Columns["Ingresos"].DefaultCellStyle.ForeColor = Color.DarkGreen;
            }

            if (dgvMovimientos.Columns["Egresos"] != null)
            {
                dgvMovimientos.Columns["Egresos"].HeaderText = "Egresos";
                dgvMovimientos.Columns["Egresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMovimientos.Columns["Egresos"].DefaultCellStyle.ForeColor = Color.DarkRed;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
