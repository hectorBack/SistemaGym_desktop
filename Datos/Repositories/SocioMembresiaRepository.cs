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
                .Where(sm => sm.SocioID == socioId)
                .OrderByDescending(sm => sm.FechaInicio)
                .ToListAsync();
        }

        public async Task<SocioMembresia?> ObtenerPorIdAsync(int id)
        {
            return await _context.SocioMembresia
                .Include(sm => sm.Socio)
                .Include(sm => sm.Membresia)
                .FirstOrDefaultAsync(sm => sm.SocioMembresiaID == id);
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

        public void Eliminar(SocioMembresia socioMembresia)
        {
            _context.SocioMembresia.Remove(socioMembresia);
        }
    }
}
