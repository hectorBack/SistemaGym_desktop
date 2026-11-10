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
        Task<IEnumerable<Socio>> ObtenerTodosAsync(bool incluirInactivos = false, bool incluirFoto = true);
        Task<Socio?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Socio socio);
        void Actualizar(Socio socio);
        void EliminarLogico(Socio socio);
        void MarcarComoEliminado(Socio socio);
        Task<bool> ExisteClaveAsync(string clave, int? idExcluir = null);
        Task<Socio?> ObtenerPorClaveAsync(string clave);
        Task<int> ObtenerSiguienteNumeroClaveAsync();
        Task<Socio?> ObtenerDetalleCompletoAsync(int socioId);
        Task<IEnumerable<Socio>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<bool> TieneMembresiasAsync(int socioId);
        Task<bool> TieneVisitasAsync(int socioId);
    }
}
