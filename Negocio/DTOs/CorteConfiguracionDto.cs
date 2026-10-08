using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class CorteConfiguracionDto
    {
        public decimal EfectivoInicial { get; set; }
        public string EmailNotificacion { get; set; } = string.Empty;
    }
}
