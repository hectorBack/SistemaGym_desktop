using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IConfiguracionRepository
    {
        Task<Configuracion?> ObtenerPorClaveAsync(string clave);
        Task<IEnumerable<Configuracion>> ObtenerTodasAsync();
        Task GuardarOActualizarAsync(string clave, string valor, string? descripcion = null);
    }
}
