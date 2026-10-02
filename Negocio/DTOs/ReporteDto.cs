using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class ReporteDto
    {
        public class ReporteInventarioDto
        {
            public int ProductoID { get; set; }
            public string Codigo { get; set; } = string.Empty;
            public string Producto { get; set; } = string.Empty;
            public string Categoria { get; set; } = string.Empty;
            public int StockActual { get; set; }
            public decimal PrecioCompra { get; set; }
            public decimal PrecioVenta { get; set; }
            public decimal ValorTotalInventario => StockActual * PrecioCompra;
            public bool Activo { get; set; }
        }

        // 2. Reporte de Membresías
        public class ReporteMembresiaDto
        {
            public int SocioMembresiaID { get; set; }
            public string Membresia { get; set; } = string.Empty;
            public string Socio { get; set; } = string.Empty;
            public DateTime FechaRegistro { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime Vencimiento { get; set; }
            public decimal Precio { get; set; }          // Precio global contratado (ej. $300.00)
            public decimal TotalAbonado { get; set; }    // Suma abonada acumulada
            public string EstadoMembresia { get; set; } = string.Empty;
        }

        // 3. Reporte de Socios
        public class ReporteSocioDto
        {
            public int SocioID { get; set; }
            public string Clave { get; set; } = string.Empty;
            public string NombreCompleto { get; set; } = string.Empty;
            public DateTime? FechaVencimiento { get; set; }
            public string Estatus { get; set; } = string.Empty; // "Sin Vencer", "Vencido", "Sin Membresía"
        }

        // 4. Reporte de Registros (Nuevos socios por rango de fechas)
        public class ReporteRegistroDto
        {
            public int SocioID { get; set; }
            public string NombreCompleto { get; set; } = string.Empty;
            public DateTime FechaRegistro { get; set; }
        }

        // 5. Reporte de Venta de Productos
        public class ReporteVentaProductoDto
        {
            public int ProductoID { get; set; }
            public string Producto { get; set; } = string.Empty;
            public int CantidadVendida { get; set; }
            public decimal TotalRecaudado { get; set; }
        }

        // 6. Reporte de Visitas
        public class ReporteVisitaDto
        {
            public int VisitaID { get; set; }
            public int? SocioID { get; set; }
            public string Nombre { get; set; } = string.Empty; // Nombre del visitante casual
            public DateTime FechaHora { get; set; }
            public decimal Monto { get; set; }                 // Precio de la visita
        }

        // 7. Reporte de Pagos de Membresías
        public class ReportePagoMembresiaDto
        {
            public int PagoID { get; set; }
            public int SocioMembresiaID { get; set; }
            public string Socio { get; set; } = string.Empty;
            public string Membresia { get; set; } = string.Empty;
            public DateTime FechaInicio { get; set; }     // AGREGADO
            public string? Folio { get; set; }            // AGREGADO
            public string? Observaciones { get; set; }     // AGREGADO
            public decimal Monto { get; set; }            // Monto abonado en esta transacción
            public decimal TotalPagado { get; set; }     // Acumulado abonado hasta hoy
            public decimal PrecioMembresia { get; set; } // Precio total de la membresía
            public string FormaPago { get; set; } = string.Empty;
            public DateTime FechaPago { get; set; }
        }

        // 8. Reporte de Movimientos (Egresos / Ingresos)
        public class ReporteMovimientoDto
        {
            public int MovimientoID { get; set; }
            public string Tipo { get; set; } = string.Empty;
            public string Concepto { get; set; } = string.Empty;
            public decimal Total { get; set; }
            public string FormaPago { get; set; } = string.Empty;
            public string Usuario { get; set; } = string.Empty;
            public DateTime Fecha { get; set; }
        }
    }
}
