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
    public class VisitaRepository : IVisitaRepository
    {
        private readonly GimnasioDbContext _context;

        public VisitaRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visita>> ObtenerTodasAsync()
        {
            return await _context.Visitas
                .Include(v => v.Socio)
                .Include(v => v.Membresia)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Visita>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Visitas
                .Include(v => v.Socio)
                .Include(v => v.Membresia)
                .Where(v => v.CreatedAt >= fechaInicio && v.CreatedAt <= fechaFin)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }

        public async Task<Visita?> ObtenerPorIdAsync(int id)
        {
            return await _context.Visitas
                .Include(v => v.Socio)
                .Include(v => v.Membresia)
                .FirstOrDefaultAsync(v => v.VisitaID == id);
        }

        public async Task<IEnumerable<Visita>> ObtenerPorSocioIdAsync(int socioId)
        {
            return await _context.Visitas
                .Include(v => v.Membresia)
                .Where(v => v.SocioID == socioId)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }

        public async Task AgregarAsync(Visita visita)
        {
            await _context.Visitas.AddAsync(visita);
        }

        public void Actualizar(Visita visita)
        {
            _context.Entry(visita).State = EntityState.Modified;
        }

        public void EliminarFisico(Visita visita)
        {
            _context.Visitas.Remove(visita);
        }

        public async Task<IEnumerable<Visita>> ObtenerPorSocioYFechasAsync(int socioId, DateTime inicioSemana, DateTime finSemana)
        {
            return await _context.Visitas
                .Where(v => v.SocioID == socioId && v.CreatedAt >= inicioSemana && v.CreatedAt <= finSemana)
                .OrderBy(v => v.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Visita>> ObtenerVisitasPorSocioYFechasAsync(int socioId, DateTime desde, DateTime hasta)
        {
            DateTime fechaHastaFinDia = hasta.Date.AddDays(1).AddTicks(-1);

            return await _context.Visitas
                .Include(v => v.Membresia)
                .Where(v => v.SocioID == socioId && v.CreatedAt >= desde.Date && v.CreatedAt <= fechaHastaFinDia)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> EliminarPorIdAsync(int id)
        {
            var visita = await _context.Visitas.FindAsync(id);
            if (visita == null) return false;

            _context.Visitas.Remove(visita);
            return true;
        }
    }
}
