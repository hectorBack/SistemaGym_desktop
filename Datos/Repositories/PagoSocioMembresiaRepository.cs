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
    public class PagoSocioMembresiaRepository : IPagoSocioMembresiaRepository
    {
        private readonly GimnasioDbContext _context;

        public PagoSocioMembresiaRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PagoSocioMembresia>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var query = _context.PagoSocioMembresias.AsQueryable();

            if (!incluirInactivas)
            {
                query = query.Where(p => p.Activo);
            }

            return await query.ToListAsync();
        }

        public async Task<PagoSocioMembresia?> ObtenerPorIdAsync(int id)
        {
            return await _context.PagoSocioMembresias.FindAsync(id);
        }

        public async Task AgregarAsync(PagoSocioMembresia pago)
        {
            await _context.PagoSocioMembresias.AddAsync(pago);
        }

        public void Actualizar(PagoSocioMembresia pago)
        {
            _context.PagoSocioMembresias.Update(pago);
        }

        public void EliminarLogico(PagoSocioMembresia pago)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            pago.Activo = !pago.Activo;
            _context.PagoSocioMembresias.Update(pago);
        }

        public void EliminarFisico(PagoSocioMembresia pago)
        {
            _context.PagoSocioMembresias.Remove(pago);
        }

        public async Task<IEnumerable<PagoSocioMembresia>> ObtenerPorSocioMembresiaIdAsync(int socioMembresiaId, bool incluirInactivos = false)
        {
            var query = _context.PagoSocioMembresias
                .Where(p => p.SocioMembresiaID == socioMembresiaId);

            if (!incluirInactivos)
            {
                query = query.Where(p => p.Activo);
            }

            return await query.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<decimal> ObtenerTotalPagadoPorSocioMembresiaIdAsync(int socioMembresiaId)
        {
            return await _context.PagoSocioMembresias
                .Where(p => p.SocioMembresiaID == socioMembresiaId && p.Activo)
                .SumAsync(p => p.Monto);
        }

        public async Task<bool> ExisteFolioAsync(string folio, int? idExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(folio)) return false;

            var query = _context.PagoSocioMembresias.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(p => p.PagoID != idExcluir.Value);
            }

            return await query.AnyAsync(p => p.Folio != null && p.Folio.ToLower() == folio.ToLower());
        }
    }
}
