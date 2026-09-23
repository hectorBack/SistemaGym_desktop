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

namespace Presentacion.Forms.Ventas
{
    public partial class FrmVentaDetalleModal : Form
    {
        private readonly VentaDto _venta;

        public FrmVentaDetalleModal(VentaDto venta)
        {
            InitializeComponent();
            _venta = venta ?? throw new ArgumentNullException(nameof(venta));
        }

        private void FrmVentaDetalleModal_Load(object sender, EventArgs e)
        {
            CargarDatosVenta();
        }

        private void CargarDatosVenta()
        {
            // Cargar cabecera
            lblFolioValor.Text = $"#{_venta.VentaID}";
            lblFechaValor.Text = _venta.FechaVenta.ToString("dd/MM/yyyy HH:mm");
            lblAtendidoValor.Text = string.IsNullOrWhiteSpace(_venta.UsuarioNombre) ? "N/A" : _venta.UsuarioNombre;
            lblSocioValor.Text = string.IsNullOrWhiteSpace(_venta.SocioNombre) ? "Cliente Casual" : _venta.SocioNombre;
            lblEstadoValor.Text = _venta.Activo ? "Completada" : "Anulada";

            if (!_venta.Activo)
            {
                lblEstadoValor.ForeColor = System.Drawing.Color.IndianRed;
            }

            // Cargar desglose de ítems
            dgvDetalles.DataSource = _venta.Detalles.Select(d => new
            {
                d.ProductoID,
                Producto = d.ProductoNombre,
                d.Cantidad,
                PrecioUnitario = d.PrecioUnitario.ToString("C2"),
                Subtotal = d.Subtotal.ToString("C2")
            }).ToList();

            ConfigurarGrid();

            // Cargar total
            lblTotalCalculado.Text = _venta.Total.ToString("C2");
        }

        private void ConfigurarGrid()
        {
            if (dgvDetalles.Columns["ProductoID"] != null)
                dgvDetalles.Columns["ProductoID"].HeaderText = "Código";

            if (dgvDetalles.Columns["Producto"] != null)
                dgvDetalles.Columns["Producto"].HeaderText = "Producto";

            if (dgvDetalles.Columns["Cantidad"] != null)
            {
                dgvDetalles.Columns["Cantidad"].HeaderText = "Cant.";
                dgvDetalles.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvDetalles.Columns["PrecioUnitario"] != null)
            {
                dgvDetalles.Columns["PrecioUnitario"].HeaderText = "Precio Unit.";
                dgvDetalles.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvDetalles.Columns["Subtotal"] != null)
            {
                dgvDetalles.Columns["Subtotal"].HeaderText = "Subtotal";
                dgvDetalles.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
