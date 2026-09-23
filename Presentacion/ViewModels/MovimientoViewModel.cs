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
        public int? UsuarioID { get; set; }
        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
        public DateTime? CreatedAt { get; set; }
    }
}
