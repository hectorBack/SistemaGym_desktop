using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class AccesoResultadoDto
    {
        public bool Exitoso { get; set; }
        public string MensajeError { get; set; } = string.Empty;
        public bool EsVisitaCasual { get; set; }

        // Datos del Socio
        public int? SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Foto { get; set; }
        public string? NombreMembresia { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool MembresiaVigente { get; set; }

        // Registros de la semana actual (Key: DayOfWeek, Value: Hora de entrada HH:mm)
        public Dictionary<DayOfWeek, string> AsistenciasSemana { get; set; } = new();

        public int VisitaID { get; set; }
        public decimal PrecioMembresia { get; set; }
        public decimal TotalPagado { get; set; }
    }
}
