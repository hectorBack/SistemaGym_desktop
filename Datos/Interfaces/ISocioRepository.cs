using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface ISocioRepository
    {
        Task<IEnumerable<Socio>> ObtenerTodosAsync(bool incluirInactivos = false);
        Task<Socio?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Socio socio);
        void Actualizar(Socio socio);
        void EliminarLogico(Socio socio);
        void EliminarFisico(Socio socio);
        Task<bool> ExisteClaveAsync(string clave, int? idExcluir = null);
        Task<Socio?> ObtenerPorClaveAsync(string clave);
        Task<int> ObtenerSiguienteNumeroClaveAsync();
        Task<Socio?> ObtenerDetalleCompletoAsync(int socioId);
    }
}
