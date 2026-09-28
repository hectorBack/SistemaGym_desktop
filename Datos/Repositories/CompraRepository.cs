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
    public class CompraRepository : ICompraRepository
    {
        private readonly GimnasioDbContext _context;

        public CompraRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Compra>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var query = _context.Compras
                .Include(c => c.Detalles)
                .AsQueryable();

            if (!incluirInactivas)
            {
                query = query.Where(c => c.Activo && c.Estado != "Cancelada");
            }

            return await query
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<Compra?> ObtenerPorIdAsync(int id)
        {
            return await _context.Compras
                .Include(c => c.Detalles)
                .FirstOrDefaultAsync(c => c.CompraID == id);
        }

        public async Task<Compra?> ObtenerPorCodigoAsync(string codigo)
        {
            return await _context.Compras
                .Include(c => c.Detalles)
                .FirstOrDefaultAsync(c => c.Codigo.ToLower() == codigo.ToLower());
        }

        public async Task<IEnumerable<Compra>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Compras
                .Include(c => c.Detalles)
                .Where(c => c.CreatedAt.Date >= fechaInicio.Date && c.CreatedAt.Date <= fechaFin.Date)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task AgregarAsync(Compra compra)
        {
            await _context.Compras.AddAsync(compra);
        }

        public void Actualizar(Compra compra)
        {
            _context.Compras.Update(compra);
        }

        public void EliminarLogico(Compra compra)
        {
            // Cambia el estado al opuesto (Activar/Desactivar) y marca como Cancelada si se desactiva
            compra.Activo = !compra.Activo;
            if (!compra.Activo)
            {
                compra.Estado = "Cancelada";
            }
            _context.Compras.Update(compra);
        }

        public void EliminarFisico(Compra compra)
        {
            _context.Compras.Remove(compra);
        }

        public async Task<bool> ExisteCodigoAsync(string codigo, int? idExcluir = null)
        {
            var query = _context.Compras.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(c => c.CompraID != idExcluir.Value);
            }

            return await query.AnyAsync(c => c.Codigo.ToLower() == codigo.ToLower());
        }

        public async Task<string> GenerarSiguienteCodigoAsync()
        {
            // Obtiene el último ID registrado para sugerir el siguiente folio secuencial (ej. COM-00001)
            int ultimoId = await _context.Compras
                .Select(c => (int?)c.CompraID)
                .MaxAsync() ?? 0;

            int siguienteId = ultimoId + 1;
            return $"COM-{siguienteId:D5}";
        }
    }
}
