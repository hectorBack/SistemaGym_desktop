using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms.Corte
{
    public static class TipoMovimiento
    {
        private static readonly HashSet<string> Ingresos = new(StringComparer.OrdinalIgnoreCase)
    {
        "Ingreso", "Entrada", "Venta", "Cobro"
    };

        public static bool EsIngreso(string? tipo) =>
            !string.IsNullOrWhiteSpace(tipo) && Ingresos.Contains(tipo.Trim());
    }
}
