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
            var query = incluirInactivos
                ? _context.Roles.Where(r => r.Estado != "Eliminado")
                : _context.Roles.Where(r => r.Activo);

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
            rol.Estado = rol.Activo ? "Activo" : "Inactivo";
            _context.Roles.Update(rol);
        }

        public void MarcarComoEliminado(Rol rol)
        {
            rol.Activo = false;
            rol.Estado = "Eliminado";
            _context.Roles.Update(rol);
        }

        public async Task<bool> TieneUsuariosAsync(int rolId)
        {
            return await _context.Set<Usuario>().AnyAsync(u => u.RolID == rolId && u.Estado != "Eliminado");
        }

        public async Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null)
        {
            // Un rol eliminado libera su nombre.
            var query = _context.Roles.Where(r => r.Estado != "Eliminado");

            if (idExcluir.HasValue)
            {
                query = query.Where(r => r.RolID != idExcluir.Value);
            }

            return await query.AnyAsync(r => r.Nombre.ToLower() == nombre.ToLower());
        }
    }
}
