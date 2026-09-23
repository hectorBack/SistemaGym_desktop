using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Producto : BaseEntity
    {
        public int ProductoID { get; set; }
        public int CategoriaID { get; set; }
        public string? CodigoBarras { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Propiedad de navegación (opcional si usas EF Core)
        public Categoria? Categoria { get; set; }
    }
}
