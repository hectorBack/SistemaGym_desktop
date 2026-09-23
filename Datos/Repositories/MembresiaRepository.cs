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
    public class MembresiaRepository : IMembresiaRepository
    {
        private readonly GimnasioDbContext _context;

        public MembresiaRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public void Actualizar(Membresia membresia)
        {
            _context.Membresias.Update(membresia);
        }

        public async Task AgregarAsync(Membresia membresia)
        {
            await _context.Membresias.AddAsync(membresia);
        }

        public void EliminarFisico(Membresia membresia)
        {
            _context.Membresias.Remove(membresia);
        }

        public void EliminarLogico(Membresia membresia)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            membresia.Activo = !membresia.Activo;
            _context.Membresias.Update(membresia);
        }

        public async Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null)
        {
            var query = _context.Membresias.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(m => m.MembresiaID != idExcluir.Value);
            }

            return await query.AnyAsync(m => m.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<Membresia?> ObtenerPorIdAsync(int id)
        {
            return await _context.Membresias.FindAsync(id);
        }

        public async Task<IEnumerable<Membresia>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var query = _context.Membresias.AsQueryable();

            if (!incluirInactivas)
            {
                query = query.Where(m => m.Activo);
            }

            return await query.ToListAsync();
        }
    }
}
