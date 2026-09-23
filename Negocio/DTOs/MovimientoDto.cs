using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class MovimientoDto
    {
        public int MovimientoID { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int ConceptoID { get; set; }
        public string? ConceptoNombre { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public decimal Total { get; set; }
        public string? Observacion { get; set; }
        public int? CorteID { get; set; }
        public int? UsuarioID { get; set; }
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class MovimientoCreateDto
    {
        public string Tipo { get; set; } = string.Empty;
        public int ConceptoID { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public decimal Total { get; set; }
        public string? Observacion { get; set; }
        public int? CorteID { get; set; }
        public int? UsuarioID { get; set; }
    }

    public class MovimientoUpdateDto
    {
        public int MovimientoID { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int ConceptoID { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public decimal Total { get; set; }
        public string? Observacion { get; set; }
        public int? CorteID { get; set; }
        public int? UsuarioID { get; set; }
        public bool Activo { get; set; }
    }
}
