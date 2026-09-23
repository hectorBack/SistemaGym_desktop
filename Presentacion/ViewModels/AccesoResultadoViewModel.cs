using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class AccesoResultadoViewModel
    {
        public bool Exitoso { get; set; }
        public string MensajeError { get; set; } = string.Empty;
        public bool EsVisitaCasual { get; set; }

        public int VisitaID { get; set; }
        public int? SocioID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string? FotoRuta { get; set; }
        public string? NombreMembresia { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool MembresiaVigente { get; set; }

        public decimal PrecioMembresia { get; set; }
        public decimal TotalPagado { get; set; }

        public decimal Deuda => Math.Max(0, PrecioMembresia - TotalPagado);

        public Dictionary<DayOfWeek, string> AsistenciasSemana { get; set; } = new();

        // --- Propiedades calculadas para controles WinForms ---

        public string EstadoMembresiaTexto => MembresiaVigente ? "VIGENTE" : "VENCIDA";

        public string FechaVencimientoTexto => FechaVencimiento.HasValue
            ? FechaVencimiento.Value.ToString("dd/MM/yyyy")
            : "N/A";

        /// <summary>
        /// Convierte la ruta guardada a un Image usable por el PictureBox.
        /// Retorna null si no existe la ruta o el archivo.
        /// </summary>
        public Image? ObtenerImagenFoto()
        {
            if (string.IsNullOrWhiteSpace(FotoRuta) || !File.Exists(FotoRuta))
                return null;

            try
            {
                using (var stream = new FileStream(FotoRuta, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(stream);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
