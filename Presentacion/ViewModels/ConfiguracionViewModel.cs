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

        // Futuras pestañas (preparadas para cuando las agregues):
        // public DatosGimnasioViewModel DatosGimnasio { get; set; } = new DatosGimnasioViewModel();
        // public EmailConfiguracionViewModel Correos { get; set; } = new EmailConfiguracionViewModel();
        // public RespaldoConfiguracionViewModel Respaldos { get; set; } = new RespaldoConfiguracionViewModel();
    }
}
