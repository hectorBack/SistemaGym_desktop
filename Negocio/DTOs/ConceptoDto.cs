using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class ConceptoDto
    {
        public int ConceptoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string? Observacion { get; set; }
        public bool EsSistema { get; set; }
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class ConceptoCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string? Observacion { get; set; }
        public bool EsSistema { get; set; } = false;
    }

    public class ConceptoUpdateDto
    {
        public int ConceptoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string? Observacion { get; set; }
        public bool EsSistema { get; set; }
        public bool Activo { get; set; }
    }
}
