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
        /// <summary>Una fila del detalle. Mantiene los números como decimal (no como texto) para que se alineen y ordenen bien.</summary>
        private sealed record FilaDetalle(string Producto, int Cantidad, decimal PrecioUnitario, decimal Subtotal);

        private readonly VentaDto _venta;

        public FrmVentaDetalleModal(VentaDto venta)
        {
            _venta = venta ?? throw new ArgumentNullException(nameof(venta));

            InitializeComponent();
            ConfigurarColumnas();
            CargarDatosVenta();
        }

        // Las columnas se definen una sola vez.
        private void ConfigurarColumnas()
        {
            dgvDetalles.AutoGenerateColumns = false;

            dgvDetalles.AgregarTexto(nameof(FilaDetalle.Producto), "Producto", 220, 120);
            dgvDetalles.AgregarTexto(nameof(FilaDetalle.Cantidad), "Cantidad", 70, 70, alinearDerecha: true);
            dgvDetalles.AgregarTexto(nameof(FilaDetalle.PrecioUnitario), "Precio unitario", 90, 90, "C2", alinearDerecha: true);
            dgvDetalles.AgregarTexto(nameof(FilaDetalle.Subtotal), "Subtotal", 90, 90, "C2", alinearDerecha: true);
        }

        private void CargarDatosVenta()
        {
            var filas = _venta.Detalles
                .Select(d => new FilaDetalle(d.ProductoNombre, d.Cantidad, d.PrecioUnitario, d.Subtotal))
                .ToList();

            // Cabecera
            lblFechaValor.Text = _venta.FechaVenta.ToString("dd/MM/yyyy HH:mm");
            lblTotalCalculado.Text = _venta.Total.ToString("C2");

            int articulos = filas.Sum(f => f.Cantidad);
            lblArticulos.Text = $"{articulos} artículo(s) en {filas.Count} producto(s)";

            // Desglose (ordenable al hacer clic en los encabezados)
            dgvDetalles.DataSource = new ListaOrdenable<FilaDetalle>(filas);
            dgvDetalles.ClearSelection();
        }
    }
}
