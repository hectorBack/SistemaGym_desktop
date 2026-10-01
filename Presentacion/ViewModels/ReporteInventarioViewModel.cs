using System;
using System.Collections.Generic;
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
        public string Estado => Activo ? "Activo" : "Inactivo";
        public bool Activo { get; set; }
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

        // Propiedad con formato para mostrar limpio en la tabla
        public string FechaVencimientoTexto => FechaVencimiento.HasValue
            ? FechaVencimiento.Value.ToString("dd/MM/yyyy")
            : "N/A";

        public DateTime? FechaVencimiento { get; set; }
        public string Estatus { get; set; } = string.Empty; // "Sin Vencer", "Vencido", "Sin Membresía"
    }

    public class ReporteRegistroViewModel
    {
        public int SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string FechaRegistroTexto => FechaRegistro.ToString("dd/MM/yyyy HH:mm");
        public DateTime FechaRegistro { get; set; }
    }

    public class ReporteVentaProductoViewModel
    {
        public int ProductoID { get; set; }
        public string Producto { get; set; } = string.Empty;
        public int CantidadVendida { get; set; }
        public decimal TotalRecaudado { get; set; }
    }

    public class ReporteVisitaViewModel
    {
        public int VisitaID { get; set; }
        public int? SocioID { get; set; }
        public string SocioNombre { get; set; } = string.Empty;
        public string FechaHoraTexto => FechaHora.ToString("dd/MM/yyyy HH:mm");
        public DateTime FechaHora { get; set; }
        public string Observacion { get; set; } = string.Empty;
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
        public decimal Monto { get; set; }           // Importe del pago actual ($100)
        public decimal TotalPagado { get; set; }    // Total abonado acumulado
        public decimal PrecioMembresia { get; set; }// Precio total ($300)
        public string FormaPago { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }

        public string FechaPagoTexto => FechaPago.ToString("dd/MM/yyyy HH:mm");
        public string FechaInicioTexto => FechaInicio.ToString("dd/MM/yyyy");

        // Lógica para evaluar si la membresía ligada al pago está pagada o en parcialidad
        public string EstadoMembresia
        {
            get
            {
                if (TotalPagado >= PrecioMembresia && PrecioMembresia > 0)
                    return "Pagada";
                if (TotalPagado > 0)
                    return "Parcial";
                return "Sin Pagar";
            }
        }
    }

    public class ReporteMovimientoViewModel
    {
        public int MovimientoID { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Concepto { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string FormaPago { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string FechaTexto => Fecha.ToString("dd/MM/yyyy HH:mm");
        public DateTime Fecha { get; set; }
    }
}
