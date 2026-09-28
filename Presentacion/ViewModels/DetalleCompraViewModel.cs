using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class DetalleCompraViewModel
    {
        public int DetalleCompraID { get; set; }
        public int CompraID { get; set; }
        public int ProductoID { get; set; }
        public string CodigoBarras { get; set; } = string.Empty;
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Subtotal => Cantidad * CostoUnitario;

        // Propiedades auxiliares formateadas para DataGridView
        public string CostoUnitarioTexto => CostoUnitario.ToString("C2");
        public string SubtotalTexto => Subtotal.ToString("C2");
    }
}
