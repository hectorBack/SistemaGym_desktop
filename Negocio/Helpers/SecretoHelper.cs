using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    /// <summary>
    /// Cifra los secretos guardados en la base de datos (por ejemplo, la contraseña de aplicación de Gmail) con DPAPI de Windows.
    /// El alcance es la computadora (LocalMachine): cualquier usuario de Windows de esa PC puede leerlos, pero no se pueden
    /// descifrar en otra computadora. Un valor sin el prefijo se considera texto plano antiguo y se devuelve tal cual;
    /// al guardar de nuevo queda cifrado.
    /// </summary>
    public static class SecretoHelper
    {
        private const string Prefijo = "dpapi:";
        private static readonly byte[] Entropia = Encoding.UTF8.GetBytes("SistemaGimnasio.Secretos");

        public static string Proteger(string? texto)
        {
            if (string.IsNullOrEmpty(texto)) return string.Empty;

            byte[] cifrado = ProtectedData.Protect(Encoding.UTF8.GetBytes(texto), Entropia, DataProtectionScope.LocalMachine);
            return Prefijo + Convert.ToBase64String(cifrado);
        }

        public static string Desproteger(string? valor)
        {
            if (string.IsNullOrEmpty(valor)) return string.Empty;
            if (!valor.StartsWith(Prefijo, StringComparison.Ordinal)) return valor; // texto plano antiguo

            try
            {
                byte[] datos = Convert.FromBase64String(valor.Substring(Prefijo.Length));
                return Encoding.UTF8.GetString(ProtectedData.Unprotect(datos, Entropia, DataProtectionScope.LocalMachine));
            }
            catch (Exception ex) when (ex is CryptographicException or FormatException)
            {
                // Cifrado en otra computadora (o dato dañado): hay que volver a escribir la contraseña.
                return string.Empty;
            }
        }
    }
}
