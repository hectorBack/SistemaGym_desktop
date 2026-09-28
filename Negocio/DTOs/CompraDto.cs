using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class CompraDto
    {
        public int CompraID { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string Estado { get; set; } = "Completada";
        public string? Observacion { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty; // Para mostrar qué usuario registró la compra
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<DetalleCompraDto> Detalles { get; set; } = new List<DetalleCompraDto>();
    }

    // DTO para la creación de una compra (procesamiento en FrmCompraModal)
    public class CompraCreateDto
    {
        public string Codigo { get; set; } = string.Empty;
        public string? Observacion { get; set; }
        public int UsuarioID { get; set; }
        public string FormaPago { get; set; } = "Efectivo"; // Necesario para registrar en Movimientos

        public List<DetalleCompraCreateDto> Detalles { get; set; } = new List<DetalleCompraCreateDto>();
    }

    // DTO para actualización de estado / cancelación
    public class CompraUpdateDto
    {
        public int CompraID { get; set; }
        public string Estado { get; set; } = "Cancelada";
        public string? Observacion { get; set; }
        public bool Activo { get; set; }
    }
}
