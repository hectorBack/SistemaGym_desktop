using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class ReporteInventarioViewModel
    {
        public int ProductoID { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int StockActual { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal ValorTotalInventario { get; set; }
        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
    }

    public class ReporteMembresiaViewModel
    {
        public int SocioMembresiaID { get; set; }
        public string Membresia { get; set; } = string.Empty;
        public string Socio { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime Vencimiento { get; set; }
        public decimal Precio { get; set; }
        public decimal TotalAbonado { get; set; }
        public string EstadoMembresia { get; set; } = string.Empty;
    }

    public class ReporteSocioViewModel
    {
        public int SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public DateTime? FechaVencimiento { get; set; }
        public string Estatus { get; set; } = string.Empty; // "Sin Vencer", "Vencido", "Sin Membresía"

        public string FechaVencimientoTexto => FechaVencimiento.HasValue
            ? FechaVencimiento.Value.ToString("dd/MM/yyyy")
            : "N/A";
    }

    public class ReporteRegistroViewModel
    {
        public int SocioID { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }

        public string FechaRegistroTexto => FechaRegistro.ToString("dd/MM/yyyy HH:mm");
    }

    public class ReporteVentaProductoViewModel
    {
        public int ProductoID { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Producto { get; set; } = string.Empty;
        public int CantidadVendida { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Ganancia { get; set; }

        public string FechaRegistroTexto => FechaRegistro.ToString("dd/MM/yyyy HH:mm");
    }

    public class ReporteVisitaViewModel
    {
        public int VisitaID { get; set; }
        public int? SocioID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaHora { get; set; }

        public string FechaHoraTexto => FechaHora.ToString("dd/MM/yyyy hh:mm tt");
    }

    public class ReportePagoMembresiaViewModel
    {
        public int PagoID { get; set; }
        public int SocioMembresiaID { get; set; }
        public string Socio { get; set; } = string.Empty;
        public string Membresia { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public string Folio { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public decimal Monto { get; set; }            // Importe de este pago
        public decimal TotalPagado { get; set; }      // Total abonado acumulado
        public decimal PrecioMembresia { get; set; }  // Precio total de la membresía
        public string FormaPago { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }

        public string FechaPagoTexto => FechaPago.ToString("dd/MM/yyyy HH:mm");
        public string FechaInicioTexto => FechaInicio.ToString("dd/MM/yyyy");

        public string EstadoMembresia
        {
            get
            {
                if (PrecioMembresia > 0 && TotalPagado >= PrecioMembresia) return "Pagada";
                if (TotalPagado > 0) return "Parcial";
                return "Sin Pagar";
            }
        }
    }

    public class ReporteMovimientoViewModel
    {
        public int MovimientoID { get; set; }
        public string Tipo { get; set; } = string.Empty;       // Ingreso / Egreso
        public string Concepto { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string FormaPago { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
        public string CorteInfo { get; set; } = string.Empty;  // Rango de fechas/horas del corte
        public DateTime Fecha { get; set; }

        public string FechaTexto => Fecha.ToString("dd/MM/yyyy HH:mm");
    }
}
