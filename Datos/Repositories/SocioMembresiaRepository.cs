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
    public class SocioMembresiaRepository : ISocioMembresiaRepository
    {
        private readonly GimnasioDbContext _context;

        public SocioMembresiaRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SocioMembresia>> ObtenerPorSocioIdAsync(int socioId)
        {
            return await _context.SocioMembresia
                .Include(sm => sm.Membresia)
                .Include(sm => sm.Pagos)
                .Where(sm => sm.SocioID == socioId && sm.Estado != "Eliminado" && sm.Activo)
                .OrderByDescending(sm => sm.FechaInicio)
                .ToListAsync();
        }

        public async Task<SocioMembresia?> ObtenerPorIdAsync(int id)
        {
            return await _context.SocioMembresia
                .Include(sm => sm.Socio)
                .Include(sm => sm.Membresia)
                .Include(sm => sm.Pagos)
                .FirstOrDefaultAsync(sm => sm.SocioMembresiaID == id && sm.Estado != "Eliminado");
        }

        public async Task<SocioMembresia?> ObtenerMembresiaActivaPorSocioIdAsync(int socioId)
        {
            return await _context.SocioMembresia
                .Include(sm => sm.Membresia)
                .Include(sm => sm.Pagos)
                .Where(sm => sm.SocioID == socioId && sm.Estado == "Activa")
                .OrderByDescending(sm => sm.FechaFin)
                .FirstOrDefaultAsync();
        }

        public async Task AgregarAsync(SocioMembresia socioMembresia)
        {
            await _context.SocioMembresia.AddAsync(socioMembresia);
        }

        public void Actualizar(SocioMembresia socioMembresia)
        {
            _context.SocioMembresia.Update(socioMembresia);
        }

        // Reemplazo del borrado físico por Soft Delete
        public void MarcarComoEliminado(SocioMembresia socioMembresia)
        {
            socioMembresia.Activo = false;
            socioMembresia.Estado = "Eliminado";
            _context.SocioMembresia.Update(socioMembresia);
        }

        public void EliminarLogico(SocioMembresia socioMembresia)
        {
            socioMembresia.Activo = false;
            socioMembresia.Estado = "Inactivo";
            _context.SocioMembresia.Update(socioMembresia);
        }

        public async Task<IEnumerable<SocioMembresia>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.SocioMembresia
                .Include(m => m.Membresia)
                .Include(m => m.Socio)
                .Include(m => m.Pagos)
                .Where(m => m.CreatedAt >= fechaInicio && m.CreatedAt <= fechaFin)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }

        // Último vencimiento de cada socio (membresías activas y no canceladas), en una sola consulta agrupada.
        public async Task<Dictionary<int, DateTime>> ObtenerUltimoVencimientoPorSocioAsync()
        {
            return await _context.SocioMembresia
                .AsNoTracking()
                .Where(sm => sm.Activo && sm.Estado != "Cancelada")
                .GroupBy(sm => sm.SocioID)
                .Select(g => new { Id = g.Key, Vencimiento = g.Max(sm => sm.FechaFin) })
                .ToDictionaryAsync(x => x.Id, x => x.Vencimiento);
        }

        public async Task<IEnumerable<SocioMembresia>> ObtenerTodasAsync(bool incluirInactivos = false)
        {
            var query = _context.SocioMembresia
                 .Include(s => s.Pagos)
                 .AsQueryable();

            if (!incluirInactivos)
            {
                query = query.Where(s => s.Activo);
            }
            return await query.ToListAsync();
        }

       
    }
}
