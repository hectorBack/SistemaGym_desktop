using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Concepto : BaseEntity
    {
        public int ConceptoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string? Observacion { get; set; }
        public bool EsSistema { get; set; }
    }
}
