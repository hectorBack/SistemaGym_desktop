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
        public int DuracionDias { get; set; }
        public string DuracionTexto => $"{DuracionDias} día{(DuracionDias == 1 ? "" : "s")}";
        public bool Activo { get; set; }
        public string Estado => Activo ? "Activo" : "Inactivo";
        public DateTime? CreatedAt { get; set; }
    } 
}
