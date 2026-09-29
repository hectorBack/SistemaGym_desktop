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
        public int MembresiaID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int DuracionDias { get; set; }
        public decimal Precio { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
        public bool Activo { get; set; }
    }

    public class ReporteSocioViewModel
    {
        public int SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string EstadoSocio { get; set; } = string.Empty;
        public string FechaRegistroTexto => FechaRegistro.ToString("dd/MM/yyyy");
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
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
        public string Socio { get; set; } = string.Empty;
        public string Membresia { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public string FormaPago { get; set; } = string.Empty;
        public string FechaPagoTexto => FechaPago.ToString("dd/MM/yyyy HH:mm");
        public DateTime FechaPago { get; set; }
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
