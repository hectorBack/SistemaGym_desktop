using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class MonedaHelper
    {
        private const string SimboloPredeterminado = "$";
        private static string _simboloActual = SimboloPredeterminado;

        public static string SimboloActual => _simboloActual;

        public static void ConfigurarSimbolo(string? simbolo)
        {
            _simboloActual = NormalizarSimbolo(simbolo);
        }

        public static string NormalizarSimbolo(string? simbolo)
        {
            return string.IsNullOrWhiteSpace(simbolo)
                ? SimboloPredeterminado
                : simbolo.Trim();
        }

        public static string Formatear(decimal monto, string? simbolo)
        {
            var simboloNormalizado = NormalizarSimbolo(simbolo);

            return $"{simboloNormalizado}{monto:F2}";
        }

        public static string Formatear(decimal monto)
        {
            return Formatear(monto, SimboloActual);
        }

        public static string ObtenerFormatoDataGridView(string? simbolo)
        {
            var simboloNormalizado = NormalizarSimbolo(simbolo);

            return $"'{simboloNormalizado}'#,##0.00";
        }

        public static string ObtenerFormatoDataGridView()
        {
            return ObtenerFormatoDataGridView(SimboloActual);
        }
    }
}
