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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GimnasioDbContext _context;

        public UsuarioRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var query = _context.Usuarios
                .Include(u => u.Rol)
                .AsQueryable();

            query = incluirInactivos
                ? query.Where(u => u.Estado != "Eliminado")
                : query.Where(u => u.Activo);

            return await query.ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.UsuarioID == id);
        }

        public async Task AgregarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public void Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void EliminarLogico(Usuario usuario)
        {
            usuario.Activo = !usuario.Activo;
            usuario.Estado = usuario.Activo ? "Activo" : "Inactivo";
            _context.Usuarios.Update(usuario);
        }

        public void MarcarComoEliminado(Usuario usuario)
        {
            usuario.Activo = false;
            usuario.Estado = "Eliminado";
            _context.Usuarios.Update(usuario);
        }

        public async Task<bool> ExisteNombreUsuarioAsync(string nombreUsuario, int? idExcluir = null)
        {
            // Un usuario eliminado libera su nombre de usuario.
            var query = _context.Usuarios.Where(u => u.Estado != "Eliminado");

            if (idExcluir.HasValue)
            {
                query = query.Where(u => u.UsuarioID != idExcluir.Value);
            }

            return await query.AnyAsync(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower());
        }

        public async Task<Usuario?> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower() && u.Activo);
        }

    }
}
