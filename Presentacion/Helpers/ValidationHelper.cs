using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Helpers
{
    public static class ValidationHelper
    {
        /// <summary>
        /// Evalúa si un texto está vacío, es nulo o contiene solo espacios en blanco.
        /// </summary>
        public static bool EsTextoVacio(string texto)
        {
            return string.IsNullOrWhiteSpace(texto);
        }
    }
}
