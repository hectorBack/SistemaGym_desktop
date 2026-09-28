using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class DetalleCompra : BaseEntity
    {
        public int DetalleCompraID { get; set; }
        public int CompraID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        [NotMapped]
        public decimal Subtotal => Cantidad * CostoUnitario;

        // Propiedades opcionales para facilitar la visualización en controles o DataGridViews
        [NotMapped]
        public string? CodigoBarras { get; set; }
        [NotMapped]
        public string? ProductoNombre { get; set; }
    }
}
