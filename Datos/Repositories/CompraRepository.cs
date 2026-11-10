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

        public async Task<IEnumerable<Compra>> ObtenerTodasAsync(string? estadoFiltro = "Activo")
        {
            var query = _context.Compras
                .Include(c => c.Detalles)
                .AsQueryable();

            // Con un estado ("Activo", "Inactivo" o "Eliminado") se devuelven solo las compras en ese estado;
            // sin estado (null o vacío) se devuelven todas menos las eliminadas.
            if (!string.IsNullOrEmpty(estadoFiltro))
            {
                query = query.Where(c => c.Estado == estadoFiltro);
            }
            else
            {
                query = query.Where(c => c.Estado != "Eliminado");
            }

            return await query
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<Compra?> ObtenerPorIdAsync(int id)
        {
            return await _context.Compras
                .Include(c => c.Detalles)
                .FirstOrDefaultAsync(c => c.CompraID == id && c.Estado != "Eliminado");
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
                .Where(c => c.Activo && c.CreatedAt.Date >= fechaInicio.Date && c.CreatedAt.Date <= fechaFin.Date)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        // Listado: sin detalles y sin rastreo. Mismo criterio de días completos que ObtenerPorRangoFechasAsync,
        // pero comparando la columna directamente (sin .Date) para que MySQL pueda usar un índice.
        public async Task<IEnumerable<Compra>> ObtenerResumenPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            DateTime desde = fechaInicio.Date;
            DateTime hasta = fechaFin.Date.AddDays(1);

            return await _context.Compras
                .AsNoTracking()
               .Where(c => c.Estado != "Eliminado" && c.CreatedAt >= desde && c.CreatedAt < hasta)
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

        public void MarcarComoEliminado(Compra compra)
        {
            compra.Activo = false;
            compra.Estado = "Eliminado"; // O el campo que utilices para distinguir el estado
            _context.Compras.Update(compra);
        }

        // Cambia el estado a Inactivo (Anulado)
        public void MarcarComoInactivo(Compra compra)
        {
            compra.Activo = false;
            compra.Estado = "Inactivo";
            _context.Compras.Update(compra);
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
