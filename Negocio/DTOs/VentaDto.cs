using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class VentaDto
    {
        public int VentaID { get; set; }
        public int UsuarioID { get; set; }
        public string? UsuarioNombre { get; set; } // Nombre del empleado/cajero que procesó la venta
        public int? SocioID { get; set; }
        public string? SocioNombre { get; set; }   // Nombre del socio (null si es cliente casual)
        public decimal Total { get; set; }
        public DateTime FechaVenta { get; set; }
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<DetalleVentaDto> Detalles { get; set; } = new List<DetalleVentaDto>();
    }

    // DTO para creación de una nueva venta
    public class VentaCreateDto
    {
        public int UsuarioID { get; set; }
        public int? SocioID { get; set; }
        public decimal Total { get; set; }

        public List<DetalleVentaCreateDto> Detalles { get; set; } = new List<DetalleVentaCreateDto>();
    }

    // DTO para el detalle en la lectura
    public class DetalleVentaDto
    {
        public int DetalleVentaID { get; set; }
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public string ProductoNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }

    // DTO para el detalle en la creación
    public class DetalleVentaCreateDto
    {
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
