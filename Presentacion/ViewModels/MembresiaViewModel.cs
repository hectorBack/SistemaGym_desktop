using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class MembresiaViewModel
    {
        public int MembresiaID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string PrecioFormateado => Precio.ToString("C2");

        // Nuevos atributos visuales
        public string Tipo { get; set; } = string.Empty;
        public int Meses { get; set; }
        public int Semanas { get; set; }
        public int Dias { get; set; }

        public int DuracionDias { get; set; }
        public string DuracionTexto => $"{DuracionDias} día{(DuracionDias == 1 ? "" : "s")}";

        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
        public DateTime? CreatedAt { get; set; }
    }
}
