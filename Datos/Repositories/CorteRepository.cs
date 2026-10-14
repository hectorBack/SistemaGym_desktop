using Datos.Context;
using Datos.Entities;
using Datos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datos.Repositories
{
    public class CorteRepository : ICorteRepository
    {
        private readonly GimnasioDbContext _context;

        public CorteRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Corte>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var query = _context.Cortes
                .Include(c => c.Usuario)
                .AsQueryable();

            if (!incluirInactivos)
            {
                query = query.Where(c => c.Activo);
            }

            return await query
                .OrderByDescending(c => c.FechaApertura)
                .ToListAsync();
        }

        public async Task<Corte?> ObtenerPorIdAsync(int id)
        {
            return await _context.Cortes
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.CorteID == id);
        }

        public async Task AgregarAsync(Corte corte)
        {
            await _context.Cortes.AddAsync(corte);
        }

        public void Actualizar(Corte corte)
        {
            _context.Cortes.Update(corte);
        }

        public void EliminarLogico(Corte corte)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            corte.Activo = !corte.Activo;
            _context.Cortes.Update(corte);
        }

        public void EliminarFisico(Corte corte)
        {
            _context.Cortes.Remove(corte);
        }

        public async Task<Corte?> ObtenerCorteAbiertoPorUsuarioAsync(int usuarioId)
        {
            return await _context.Cortes
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.UsuarioID == usuarioId && c.Estado == "Abierto" && c.Activo);
        }

        public async Task<bool> TieneCorteAbiertoAsync(int usuarioId)
        {
            return await _context.Cortes
                .AnyAsync(c => c.UsuarioID == usuarioId && c.Estado == "Abierto" && c.Activo);
        }

        public async Task<IEnumerable<Corte>> ObtenerPorRangoFechasAsync(DateTime inicio, DateTime fin)
        {
            return await _context.Cortes
                .Include(c => c.Usuario)
                .Where(c => c.FechaApertura >= inicio && c.FechaApertura <= fin && c.Activo)
                .OrderByDescending(c => c.FechaApertura)
                .ToListAsync();
        }

        public async Task<IEnumerable<Corte>> ObtenerAbiertosAsync()
        {
            return await _context.Cortes
                .Include(c => c.Usuario)
                .Where(c => c.Estado == "Abierto" && c.FechaCierre == null && c.Activo)
                .OrderBy(c => c.FechaApertura)
                .ToListAsync();
        }

        // OBSOLETO: lo reemplaza CorteService.ObtenerEfectivoEnCajaAsync (fondo + movimientos reales).
        // Tomaba el primer corte abierto de cualquier usuario y usaba sus totales, que no se actualizan hasta cerrar.
        public async Task<decimal> ObtenerEfectivoEnCajaAsync()
        {
            var corteAbierto = await _context.Cortes
                .FirstOrDefaultAsync(c => c.FechaCierre == null && c.Activo);

            if (corteAbierto == null)
                return 0m;

            return corteAbierto.MontoInicial + corteAbierto.TotalIngresos - corteAbierto.TotalEgresos;
        }
    }
}
