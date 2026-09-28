using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Compra : BaseEntity
    {

        public int CompraID { get; set; }
        public string Codigo { get; set; } = string.Empty; // Código/Folio de la compra
        public decimal Total { get; set; }
        public string Estado { get; set; } = "Completada"; // "Completada", "Cancelada"
        public string? Observacion { get; set; }
        public int UsuarioID { get; set; }

        // Propiedad de navegación para el detalle de la compra
        public List<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();
    }
}
