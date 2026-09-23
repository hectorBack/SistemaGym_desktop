using Datos.Context;
using Datos.Entities;
using Datos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly GimnasioDbContext _context;

        public CategoriaRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var query = _context.Categorias.AsQueryable();

            if (!incluirInactivas)
            {
                query = query.Where(c => c.Activo);
            }

            return await query.ToListAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task AgregarAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
        }

        public void Actualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
        }

        public void EliminarLogico(Categoria categoria)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            categoria.Activo = !categoria.Activo;
            _context.Categorias.Update(categoria);
        }

        public void EliminarFisico(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);

        }

        public async Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null)
        {
            var query = _context.Categorias.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(c => c.CategoriaID != idExcluir.Value);
            }

            return await query.AnyAsync(c => c.Nombre.ToLower() == nombre.ToLower());
        }
    }
}
