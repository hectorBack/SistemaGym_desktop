using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class VentaViewModel
    {
        public int VentaID { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; } = "N/A";
        public int? SocioID { get; set; }
        public string SocioNombre { get; set; } = "Cliente Casual";
        public decimal Total { get; set; }
        public DateTime FechaVenta { get; set; }
        public bool Activo { get; set; }
        public string Estado => Activo ? "Completada" : "Anulada";
        public int CantidadProductos { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
