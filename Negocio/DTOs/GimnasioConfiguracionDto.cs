using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class GimnasioConfiguracionDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Rfc { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty; // Ruta o imagen del logotipo
    }
}
