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
            // 1. Cargar cabecera (Solo Fecha y Total)
            lblFechaValor.Text = _venta.FechaVenta.ToString("dd/MM/yyyy HH:mm");
            lblTotalCalculado.Text = _venta.Total.ToString("C2");

            // (Opcional) Si quieres ocultar etiquetas secundarias de la interfaz gráfica si aún existen en el diseñador:
            // lblFolioValor.Visible = false;
            // lblAtendidoValor.Visible = false;
            // lblSocioValor.Visible = false;
            // lblEstadoValor.Visible = false;

            // 2. Cargar desglose de la tabla solo con Producto, Cantidad, Precio Unitario y Subtotal/Total
            dgvDetalles.DataSource = _venta.Detalles.Select(d => new
            {
                Producto = d.ProductoNombre,
                d.Cantidad,
                PrecioUnitario = d.PrecioUnitario.ToString("C2"),
                Subtotal = d.Subtotal.ToString("C2")
            }).ToList();

            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            // Ocultar ProductoID o cualquier columna residual por si acaso
            if (dgvDetalles.Columns["ProductoID"] != null)
                dgvDetalles.Columns["ProductoID"].Visible = false;

            // Configuración de encabezados y alineaciones
            if (dgvDetalles.Columns["Producto"] != null)
            {
                dgvDetalles.Columns["Producto"].HeaderText = "Nombre";
                dgvDetalles.Columns["Producto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvDetalles.Columns["Cantidad"] != null)
            {
                dgvDetalles.Columns["Cantidad"].HeaderText = "Cantidad";
                dgvDetalles.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvDetalles.Columns["PrecioUnitario"] != null)
            {
                dgvDetalles.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
                dgvDetalles.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvDetalles.Columns["Subtotal"] != null)
            {
                dgvDetalles.Columns["Subtotal"].HeaderText = "Total";
                dgvDetalles.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Ajuste de ancho de columnas para ocupar toda la tabla
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
