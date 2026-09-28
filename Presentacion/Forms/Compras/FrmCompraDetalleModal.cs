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

namespace Presentacion.Forms.Compras
{
    public partial class FrmCompraDetalleModal : Form
    {
        private readonly CompraDto _compra;

        public FrmCompraDetalleModal(CompraDto compra)
        {
            InitializeComponent();
            _compra = compra ?? throw new ArgumentNullException(nameof(compra));
        }

        private void FrmCompraDetalleModal_Load(object sender, EventArgs e)
        {
            CargarDatosCompra();
        }

        private void CargarDatosCompra()
        {
            // 1. Cargar fecha desde CreatedAt (con respaldo si viniera nula)
            DateTime fechaRegistro = _compra.CreatedAt ?? DateTime.Now;
            lblFechaValor.Text = fechaRegistro.ToString("dd/MM/yyyy HH:mm");

            // 2. Cargar total de la compra
            lblTotalCalculado.Text = _compra.Total.ToString("C2");

            // 3. Cargar desglose de ítems en el DataGridView
            dgvDetalles.DataSource = _compra.Detalles.Select(d => new
            {
                Stock = d.Cantidad,
                Nombre = d.ProductoNombre,
                CostoUnitario = d.CostoUnitario.ToString("C2"),
                Total = d.Subtotal.ToString("C2")
            }).ToList();

            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            if (dgvDetalles.Columns["Stock"] != null)
            {
                dgvDetalles.Columns["Stock"].HeaderText = "Stock";
                dgvDetalles.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvDetalles.Columns["Nombre"] != null)
            {
                dgvDetalles.Columns["Nombre"].HeaderText = "Nombre";
                dgvDetalles.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvDetalles.Columns["CostoUnitario"] != null)
            {
                dgvDetalles.Columns["CostoUnitario"].HeaderText = "Costo Unitario";
                dgvDetalles.Columns["CostoUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvDetalles.Columns["Total"] != null)
            {
                dgvDetalles.Columns["Total"].HeaderText = "Total";
                dgvDetalles.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
