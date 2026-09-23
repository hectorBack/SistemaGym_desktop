using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Movimiento : BaseEntity
    {
        public int MovimientoID { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int ConceptoID { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public decimal Total { get; set; }
        public string? Observacion { get; set; }
        public int? CorteID { get; set; }
        public int? UsuarioID { get; set; }
        public bool Activo { get; set; } = true;

        // Propiedad de navegación (opcional según el uso en tu capa de dominio)
        public virtual Concepto? Concepto { get; set; }
    }
}
