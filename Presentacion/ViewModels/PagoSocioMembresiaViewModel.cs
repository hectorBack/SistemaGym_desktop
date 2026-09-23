using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class PagoSocioMembresiaViewModel
    {
        public int PagoID { get; set; }
        public int SocioMembresiaID { get; set; }
      
        public decimal Monto { get; set; }
        public string? Folio { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public string? Observacion { get; set; }
        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
        public DateTime? CreatedAt { get; set; }

        // Propiedades de formato conveniente para el DataGridView
        public string MontoFormateado => Monto.ToString("C2");
        public string FechaFormateada => CreatedAt.HasValue ? CreatedAt.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
    }
}
