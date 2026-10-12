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
        /// <summary>Una fila del detalle. Mantiene los números como decimal (no como texto) para que se alineen y ordenen bien.</summary>
        private sealed record FilaDetalle(string Producto, int Cantidad, decimal CostoUnitario, decimal Subtotal);

        private readonly CompraDto _compra;
        private readonly string? _folio;

        // El folio es opcional: si se pasa, aparece en el título.
        public FrmCompraDetalleModal(CompraDto compra, string? folio = null)
        {
            _compra = compra ?? throw new ArgumentNullException(nameof(compra));
            _folio = folio;

            InitializeComponent();
            ConfigurarColumnas();
            CargarDatosCompra();
        }

        // Las columnas se definen una sola vez.
        private void ConfigurarColumnas()
        {
            dgvDetalles.AutoGenerateColumns = false;

            dgvDetalles.AgregarTexto(nameof(FilaDetalle.Producto), "Producto", 220, 120);
            dgvDetalles.AgregarTexto(nameof(FilaDetalle.Cantidad), "Cantidad", 70, 70, alinearDerecha: true);
            dgvDetalles.AgregarTexto(nameof(FilaDetalle.CostoUnitario), "Costo unitario", 90, 90, "C2", alinearDerecha: true);
            dgvDetalles.AgregarTexto(nameof(FilaDetalle.Subtotal), "Subtotal", 90, 90, "C2", alinearDerecha: true);
        }

        private void CargarDatosCompra()
        {
            var filas = _compra.Detalles
                .Select(d => new FilaDetalle(d.ProductoNombre, d.Cantidad, d.CostoUnitario, d.Subtotal))
                .ToList();

            if (!string.IsNullOrWhiteSpace(_folio))
                lblTitulo.Text = $"Detalle de Compra · {_folio}";

            // Cabecera
            lblFechaValor.Text = (_compra.CreatedAt ?? DateTime.Now).ToString("dd/MM/yyyy HH:mm");
            lblTotalCalculado.Text = _compra.Total.ToString("C2");

            int articulos = filas.Sum(f => f.Cantidad);
            lblArticulos.Text = $"{articulos} artículo(s) en {filas.Count} producto(s)";

            // Desglose (ordenable al hacer clic en los encabezados)
            dgvDetalles.DataSource = new ListaOrdenable<FilaDetalle>(filas);
            dgvDetalles.ClearSelection();
        }
    }
}
