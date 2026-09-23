using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class VisitaViewModel
    {
        public int VisitaID { get; set; }
        public int? SocioID { get; set; }
        public int? MembresiaID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public decimal MontoPagado { get; set; }
        public string TipoAcceso { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public string? NombreMembresia { get; set; }
        public bool Activo { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Propiedades calculadas para la interfaz gráfica (DataGridView)
        public string NombreCompleto => string.IsNullOrWhiteSpace(Apellido)
            ? Nombre
            : $"{Nombre} {Apellido}";

        public string Estado => Activo ? "Activo" : "Inactivo";

        public string FechaRegistro => CreatedAt.HasValue
            ? CreatedAt.Value.ToString("dd/MM/yyyy HH:mm")
            : string.Empty;

        public string FechaTexto => CreatedAt.HasValue
        ? CreatedAt.Value.ToString("dd/MM/yyyy")
        : string.Empty;

        public string DiaSemana => CreatedAt.HasValue
            ? CreatedAt.Value.ToString("dddd", new System.Globalization.CultureInfo("es-ES"))
            : string.Empty;

        public string HoraEntrada => CreatedAt.HasValue
            ? CreatedAt.Value.ToString("hh:mm tt")
            : string.Empty;
    }
}
