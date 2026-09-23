using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class PagoSocioMembresiaDto
    {
        public int PagoID { get; set; }
        public int SocioMembresiaID { get; set; }
        public decimal Monto { get; set; }
        public string? Folio { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public string? Observacion { get; set; }
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    // DTO para Registro de Nuevo Pago
    public class PagoSocioMembresiaCreateDto
    {
        public int SocioMembresiaID { get; set; }
        public decimal Monto { get; set; }
        public string? Folio { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public string? Observacion { get; set; }
    }

    // DTO para Edición / Actualización de Pago
    public class PagoSocioMembresiaUpdateDto
    {
        public int PagoID { get; set; }
        public decimal Monto { get; set; }
        public string? Folio { get; set; }
        public string FormaPago { get; set; } = "Efectivo";
        public string? Observacion { get; set; }
        public bool Activo { get; set; }
    }
}
