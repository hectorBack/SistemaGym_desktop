using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class DetalleCompraDto
    {
        public int DetalleCompraID { get; set; }
        public int CompraID { get; set; }
        public int ProductoID { get; set; }
        public string CodigoBarras { get; set; } = string.Empty;
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Subtotal => Cantidad * CostoUnitario;
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class DetalleCompraCreateDto
    {
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
    }
}
