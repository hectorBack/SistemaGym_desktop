using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class InicioViewModel
    {
        public string Id { get; set; } = string.Empty;
        public int? SocioID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public string Logo { get; set; } = string.Empty;
    }
}
