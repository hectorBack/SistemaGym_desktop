using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class SocioDetalleViewModel
    {
        public int SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellidos}";
        public string Telefono { get; set; } = "N/A";
        public string Email { get; set; } = "N/A";
        public string? Foto { get; set; }
        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";

        public List<SocioMembresiaHistorialViewModel> HistorialMembresias { get; set; } = new();
        public List<SocioVisitaHistorialViewModel> HistorialVisitas { get; set; } = new();

        // Helper para convertir la imagen directamente a la UI
        public Image? ObtenerImagenFoto()
        {
            if (string.IsNullOrEmpty(Foto)) return null;

            try
            {
                byte[] bytes = Convert.FromBase64String(Foto);
                using (var ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                if (File.Exists(Foto))
                {
                    return Image.FromFile(Foto);
                }
                return null;
            }
        }
    }

    public class SocioMembresiaHistorialViewModel
    {
        public string NombreMembresia { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string FechaInicioTexto => FechaInicio.ToString("dd/MM/yyyy");
        public string FechaFinTexto => FechaFin.ToString("dd/MM/yyyy");
        public decimal Precio { get; set; }
        public string PrecioTexto => Precio.ToString("C2"); // Formato moneda: $0.00
        public string Estado { get; set; } = string.Empty;
    }

    public class SocioVisitaHistorialViewModel
    {
        public DateTime FechaHoraEntrada { get; set; }
        public string FechaTexto => FechaHoraEntrada.ToString("dd/MM/yyyy");
        public string DiaSemana => FechaHoraEntrada.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));
        public string HoraEntrada => FechaHoraEntrada.ToString("hh:mm tt");
        public string TipoAcceso { get; set; } = string.Empty;
    }
}
