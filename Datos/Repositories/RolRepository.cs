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
    public class RolRepository : IRolRepository
    {
        private readonly GimnasioDbContext _context;

        public RolRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> ObtenerTodasAsync(bool incluirInactivos = false)
        {
            var query = _context.Roles.AsQueryable();

            if (!incluirInactivos)
            {
                query = query.Where(r => r.Activo);
            }

            return await query.ToListAsync();
        }

        public async Task<Rol?> ObtenerPorIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task AgregarAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
        }

        public void Actualizar(Rol rol)
        {
            _context.Roles.Update(rol);
        }

        public void EliminarLogico(Rol rol)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            rol.Activo = !rol.Activo;
            _context.Roles.Update(rol);
        }

        public void EliminarFisico(Rol rol)
        {
            _context.Roles.Remove(rol);
        }

        public async Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null)
        {
            var query = _context.Roles.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(r => r.RolID != idExcluir.Value);
            }

            return await query.AnyAsync(r => r.Nombre.ToLower() == nombre.ToLower());
        }
    }
}
