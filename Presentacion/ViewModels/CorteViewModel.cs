using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class CorteViewModel
    {
        public int CorteID { get; set; }
        public int UsuarioID { get; set; }
        public string Usuario { get; set; } = string.Empty;

        public DateTime FechaApertura { get; set; }
        public string FechaAperturaTexto => FechaApertura.ToString("dd/MM/yyyy HH:mm");

        public DateTime? FechaCierre { get; set; }
        public string FechaCierreTexto => FechaCierre.HasValue
            ? FechaCierre.Value.ToString("dd/MM/yyyy HH:mm")
            : "Pendiente";

        public decimal MontoInicial { get; set; }
        public string MontoInicialFormateado => MontoInicial.ToString("C2");

        public decimal TotalIngresos { get; set; }
        public string TotalIngresosFormateado => TotalIngresos.ToString("C2");

        public decimal TotalEgresos { get; set; }
        public string TotalEgresosFormateado => TotalEgresos.ToString("C2");

        public decimal MontoFinal { get; set; }
        public string MontoFinalFormateado => MontoFinal.ToString("C2");

        public string Observaciones { get; set; } = string.Empty;
        public string Estado { get; set; } = "Abierto"; // "Abierto" o "Cerrado"

        public bool Activo { get; set; }
        public string EstadoRegistro => Activo ? "Activo" : "Inactivo";

        public DateTime? CreatedAt { get; set; }
    }
}
