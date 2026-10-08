using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Configuracion : BaseEntity
    {
        public int ConfiguracionID { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string? Valor { get; set; }
        public string? Descripcion { get; set; }
    }
}
