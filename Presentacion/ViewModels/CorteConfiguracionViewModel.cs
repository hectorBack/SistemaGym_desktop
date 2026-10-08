using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.ViewModels
{
    public class CorteConfiguracionViewModel
    {
        public decimal EfectivoInicial { get; set; }
        public string EmailNotificacion { get; set; } = string.Empty;

        // Propiedades de formato para bindings o etiquetas en UI
        public string EfectivoInicialFormateado => EfectivoInicial.ToString("C2");
    }
}
