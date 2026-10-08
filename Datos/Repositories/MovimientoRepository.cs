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
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly GimnasioDbContext _context;

        public MovimientoRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movimiento>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var query = _context.Movimientos
                .Include(m => m.Concepto) // Se incluye la navegación a Concepto para consultar el nombre
                .Include(m => m.Corte)
                .Include(m => m.Usuario)
                .AsQueryable();

            if (!incluirInactivos)
            {
                query = query.Where(m => m.Activo);
            }

            return await query.ToListAsync();
        }

        public async Task<Movimiento?> ObtenerPorIdAsync(int id)
        {
            return await _context.Movimientos
                .Include(m => m.Concepto)
                .Include(m => m.Corte)
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.MovimientoID == id);
        }

        public async Task AgregarAsync(Movimiento movimiento)
        {
            await _context.Movimientos.AddAsync(movimiento);
        }

        public void Actualizar(Movimiento movimiento)
        {
            _context.Movimientos.Update(movimiento);
        }

        public void EliminarLogico(Movimiento movimiento)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            movimiento.Activo = !movimiento.Activo;
            _context.Movimientos.Update(movimiento);
        }

        public void EliminarFisico(Movimiento movimiento)
        {
            _context.Movimientos.Remove(movimiento);
        }

        public async Task<IEnumerable<Movimiento>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
           return await _context.Movimientos
                .Include(m => m.Concepto)
                .Include(m => m.Corte)
                .Include(m => m.Usuario)
                .Where(m => m.CreatedAt >= fechaInicio && m.CreatedAt <= fechaFin)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }
    }
}
