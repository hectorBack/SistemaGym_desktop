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
            var query = _context.PagoSocioMembresias
                .AsNoTracking()
                .Where(p => p.Estado != "Eliminado")
                .AsQueryable();

            if (!incluirInactivas)
            {
                query = query.Where(p => p.Activo);
            }

            return await query.ToListAsync();
        }

        public async Task<PagoSocioMembresia?> ObtenerPorIdAsync(int id)
        {
            // para evitar que devuelva un pago con estado Eliminado
            return await _context.PagoSocioMembresias
                .FirstOrDefaultAsync(p => p.PagoID == id && p.Estado != "Eliminado");
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
            pago.Estado = pago.Activo ? "Activo" : "Inactivo";
            _context.PagoSocioMembresias.Update(pago);
        }

        public void MarcarComoEliminado(PagoSocioMembresia pago)
        {
            pago.Activo = false;
            pago.Estado = "Eliminado";
            _context.PagoSocioMembresias.Update(pago);
        }

        public async Task<IEnumerable<PagoSocioMembresia>> ObtenerPorSocioMembresiaIdAsync(int socioMembresiaId, bool incluirInactivos = false)
        {
            var query = _context.PagoSocioMembresias
                .Where(p => p.SocioMembresiaID == socioMembresiaId && p.Estado != "Eliminado");

            if (!incluirInactivos)
            {
                query = query.Where(p => p.Activo);
            }

            return await query.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<decimal> ObtenerTotalPagadoPorSocioMembresiaIdAsync(int socioMembresiaId)
        {
            return await _context.PagoSocioMembresias
                .Where(p => p.SocioMembresiaID == socioMembresiaId && p.Activo && p.Estado != "Eliminado")
                .SumAsync(p => p.Monto);
        }

        // Total pagado (pagos activos) de varias membresías en una sola consulta, para los reportes.
        public async Task<Dictionary<int, decimal>> ObtenerTotalesPagadosAsync(IEnumerable<int> socioMembresiaIds)
        {
            var ids = socioMembresiaIds.Distinct().ToList();
            if (ids.Count == 0) return new Dictionary<int, decimal>();

            return await _context.PagoSocioMembresias
                .AsNoTracking()
                .Where(p => p.Activo && p.Estado != "Eliminado" && ids.Contains(p.SocioMembresiaID))
                .GroupBy(p => p.SocioMembresiaID)
                .Select(g => new { Id = g.Key, Total = g.Sum(p => p.Monto) })
                .ToDictionaryAsync(x => x.Id, x => x.Total);
        }

        public async Task<bool> ExisteFolioAsync(string folio, int? idExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(folio)) return false;

            var query = _context.PagoSocioMembresias.Where(p => p.Estado != "Eliminado");

            if (idExcluir.HasValue)
            {
                query = query.Where(p => p.PagoID != idExcluir.Value);
            }

            return await query.AnyAsync(p => p.Folio != null && p.Folio.ToLower() == folio.ToLower());
        }

        public async Task<IEnumerable<PagoSocioMembresia>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.PagoSocioMembresias
                .Include(p => p.SocioMembresia)
                    .ThenInclude(sm => sm.Socio)
                .Include(p => p.SocioMembresia)
                    .ThenInclude(sm => sm.Membresia)
                .Where(p => p.Estado != "Eliminado" && p.CreatedAt >= fechaInicio && p.CreatedAt <= fechaFin) // <-- Filtro agregado
                .OrderByDescending(p => p.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
