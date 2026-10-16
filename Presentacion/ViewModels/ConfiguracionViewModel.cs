using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class ConfiguracionViewModel
    {
        // Pestaña Corte de Caja
        public CorteConfiguracionViewModel CorteCaja { get; set; } = new CorteConfiguracionViewModel();
        public GimnasioConfiguracionViewModel DatosGimnasio { get; set; } = new GimnasioConfiguracionViewModel();
        public CorreoConfiguracionViewModel Correos { get; set; } = new CorreoConfiguracionViewModel();

        // Futuras pestañas (preparadas para cuando las agregues):

        // public EmailConfiguracionViewModel Correos { get; set; } = new EmailConfiguracionViewModel();
        // public RespaldoConfiguracionViewModel Respaldos { get; set; } = new RespaldoConfiguracionViewModel();
    }
}
