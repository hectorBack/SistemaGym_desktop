using Datos.Context;
using Datos.Entities;
using Datos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly GimnasioDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(GimnasioDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            return await _dbSet.Where(x => x.Activo).ToListAsync();
        }

        public async Task<T?> ObtenerPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(x => x.Activo).Where(predicate).ToListAsync();
        }

        public async Task InsertarAsync(T entidad)
        {
            entidad.CreatedAt = DateTime.Now;
            entidad.UpdatedAt = DateTime.Now;
            entidad.Activo = true;
            await _dbSet.AddAsync(entidad);
        }

        public void Actualizar(T entidad)
        {
            entidad.UpdatedAt = DateTime.Now;
            _dbSet.Update(entidad);
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            if (entidad != null)
            {
                entidad.Activo = false;
                entidad.UpdatedAt = DateTime.Now;
                _dbSet.Update(entidad);
            }
        }
    }
}
