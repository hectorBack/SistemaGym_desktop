using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class CorreoConfiguracionViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool EnviarRecordatorioVencimiento { get; set; }
        public bool EnviarFelicitaciones { get; set; }
    }
}
