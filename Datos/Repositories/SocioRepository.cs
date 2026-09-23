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
    public class SocioRepository : ISocioRepository
    {
        private readonly GimnasioDbContext _context;

        public SocioRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Socio>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var query = _context.Socios.AsQueryable();

            if (!incluirInactivos)
            {
                query = query.Where(s => s.Activo);
            }

            return await query.ToListAsync();
        }

        public async Task<Socio?> ObtenerPorIdAsync(int id)
        {
            return await _context.Socios.FindAsync(id);
        }

        public async Task AgregarAsync(Socio socio)
        {
            await _context.Socios.AddAsync(socio);
        }

        public void Actualizar(Socio socio)
        {
            _context.Socios.Update(socio);
        }

        public void EliminarLogico(Socio socio)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            socio.Activo = !socio.Activo;
            _context.Socios.Update(socio);
        }

        public void EliminarFisico(Socio socio)
        {
            _context.Socios.Remove(socio);
        }

        public async Task<bool> ExisteClaveAsync(string clave, int? idExcluir = null)
        {
            var query = _context.Socios.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(s => s.SocioID != idExcluir.Value);
            }

            return await query.AnyAsync(s => s.Clave.ToLower() == clave.ToLower());
        }

        public async Task<Socio?> ObtenerPorClaveAsync(string clave)
        {
            return await _context.Socios
                .FirstOrDefaultAsync(s => s.Clave.ToLower() == clave.ToLower());
        }

        public async Task<int> ObtenerSiguienteNumeroClaveAsync()
        {
            bool existenSocios = await _context.Socios.AnyAsync();

            if (!existenSocios)
            {
                return 1;
            }

            int ultimoId = await _context.Socios.MaxAsync(s => s.SocioID);
            return ultimoId + 1;
        }

        public async Task<Socio?> ObtenerDetalleCompletoAsync(int socioId)
        {
            return await _context.Socios
                .Include(s => s.SocioMembresias)     // Carga la colección SocioMembresias
                    .ThenInclude(sm => sm.Membresia) // Carga los datos del catálogo Membresia (Nombre, Precio, etc.)
                .Include(s => s.Visitas)             // Carga el historial de visitas
                .FirstOrDefaultAsync(s => s.SocioID == socioId);
        }
    }
}
