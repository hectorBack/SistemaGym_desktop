using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class TicketConfiguracionDto
    {
        // Impresora
        public bool HabilitarImpresora { get; set; }

        // Contenido
        public string TextoInferior { get; set; } = string.Empty;

        // Medidas
        public int AnchoTicket { get; set; } = 80;                  // milímetros (58 u 80 en impresoras térmicas)
        public int AnchoImagenPorcentaje { get; set; } = 70;        // % del ancho del ticket que ocupa el logo

        // Cuerpo del ticket
        public string NombreFuente { get; set; } = "Arial";
        public int TamanoTexto { get; set; } = 9;                   // puntos
        public int TamanoRenglon { get; set; } = 12;                // alto de cada renglón, en puntos

        // Encabezado del ticket
        public int TamanoTextoEncabezado { get; set; } = 12;        // puntos
        public int TamanoRenglonEncabezado { get; set; } = 15;      // puntos

        // Espaciado
        public int TamanoEntreSecciones { get; set; } = 6;          // puntos
    }

}
