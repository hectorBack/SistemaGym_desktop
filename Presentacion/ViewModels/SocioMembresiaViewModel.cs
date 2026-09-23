using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    namespace TuProyecto.Presentacion.ViewModels
    {
        public class SocioMembresiaViewModel
        {
            public int SocioMembresiaID { get; set; }
            public int SocioID { get; set; }
            public int MembresiaID { get; set; }
            public string NombreMembresia { get; set; } = string.Empty;
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }

            // Propiedades auxiliares para formateo directo en DataGridView / UI
            public string FechaInicioTexto => FechaInicio.ToString("dd/MM/yyyy");
            public string FechaFinTexto => FechaFin.ToString("dd/MM/yyyy");

            public decimal Precio { get; set; }
            public string PrecioTexto => Precio.ToString("C2"); // Formato de moneda local ($)

            public decimal TotalPagado { get; set; }
            public string EstadoMembresia => (TotalPagado >= Precio && Precio > 0) ? "Pagada" : "Sin Pagar";

            public DateTime? CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }

            // Formateo seguro contra nulos
            public string CreatedAtTexto => CreatedAt.HasValue ? CreatedAt.Value.ToString("dd/MM/yyyy HH:mm") : "-";
            public string UpdatedAtTexto => UpdatedAt.HasValue ? UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm") : "-";

            public string Estado { get; set; } = "Activa";
        }
    }
}
