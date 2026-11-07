using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class TicketConfiguracionViewModel
    {
        public bool HabilitarImpresora { get; set; }
        public string TextoInferior { get; set; } = string.Empty;

        public int AnchoTicket { get; set; } = 80;
        public int AnchoImagenPorcentaje { get; set; } = 70;

        public string NombreFuente { get; set; } = "Arial";
        public int TamanoTexto { get; set; } = 9;
        public int TamanoRenglon { get; set; } = 12;

        public int TamanoTextoEncabezado { get; set; } = 12;
        public int TamanoRenglonEncabezado { get; set; } = 15;

        public int TamanoEntreSecciones { get; set; } = 6;
    }
}
