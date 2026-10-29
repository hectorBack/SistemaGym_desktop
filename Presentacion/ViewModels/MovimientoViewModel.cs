using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class MovimientoViewModel
    {
        public int MovimientoID { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int ConceptoID { get; set; }
        public string ConceptoNombre { get; set; } = string.Empty;
        public string FormaPago { get; set; } = "Efectivo";
        public decimal Total { get; set; }
        public string? Observacion { get; set; }
        public int? CorteID { get; set; }
        public DateTime? FechaAperturaCorte { get; set; }
        public DateTime? FechaCierreCorte { get; set; }
        // Si el corte tiene fecha de apertura y de cierre (está cerrado), muestra el rango. 
        // De lo contrario (sigue abierto), devuelve vacío para que la celda aparezca limpia.
        public string RangoCorteTexto => (FechaAperturaCorte.HasValue && FechaCierreCorte.HasValue)
             ? $"{FechaAperturaCorte.Value:yyyy-MM-dd HH:mm:ss} - {FechaCierreCorte.Value:yyyy-MM-dd HH:mm:ss}"
             : string.Empty;
        public int? UsuarioID { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
        public DateTime? CreatedAt { get; set; }
    }
}
