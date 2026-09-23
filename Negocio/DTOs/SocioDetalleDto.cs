using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class SocioDetalleDto
    {
        // Datos Personales
        public int SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellidos}";
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Foto { get; set; }
        public bool Activo { get; set; }

        // Pestaña 1: Historial de Membresías
        public List<SocioMembresiaHistorialDto> HistorialMembresias { get; set; } = new();

        // Pestaña 2: Historial de Visitas / Asistencias
        public List<SocioVisitaHistorialDto> HistorialVisitas { get; set; } = new();
    }

    public class SocioMembresiaHistorialDto
    {
        public string NombreMembresia { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; } = string.Empty; // Ej: "Vigente", "Vencida"
    }

    public class SocioVisitaHistorialDto
    {
        public DateTime FechaHoraEntrada { get; set; }
        public string DiaSemana => FechaHoraEntrada.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));
        public string HoraEntrada => FechaHoraEntrada.ToString("hh:mm tt");
        public string TipoAcceso { get; set; } = string.Empty; // Ej: "Membresía", "Visita Casual"
    }
}
