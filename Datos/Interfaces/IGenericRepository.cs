using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task<T?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicate);
        Task InsertarAsync(T entidad);
        void Actualizar(T entidad);
        Task EliminarLogicoAsync(int id); // Setea Activo = false
    }
}
