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
    public class VentaRepository : IVentaRepository
    {

        private readonly GimnasioDbContext _context;

        public VentaRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public void Actualizar(Venta venta)
        {
            _context.Ventas.Update(venta);
        }

        public async Task AgregarAsync(Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
        }

        public void EliminarFisico(Venta venta)
        {
            _context.Ventas.Remove(venta);
        }

        public void EliminarLogico(Venta venta)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            venta.Activo = !venta.Activo;
            _context.Ventas.Update(venta);
        }

        public async Task<bool> ExisteProductoEnVentasAsync(int productoId)
        {
            return await _context.Set<DetalleVenta>()
                .AnyAsync(dv => dv.ProductoID == productoId);
        }

        public async Task<Venta?> ObtenerPorIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Detalles)
                .FirstOrDefaultAsync(v => v.VentaID == id);
        }

        public async Task<IEnumerable<Venta>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Ventas
                .Include(v => v.Detalles)
                .Where(v => v.Activo && v.FechaVenta >= fechaInicio && v.FechaVenta <= fechaFin)
                .OrderByDescending(v => v.FechaVenta)
                .ToListAsync();
        }

        public async Task<IEnumerable<Venta>> ObtenerPorSocioIdAsync(int socioId)
        {
            return await _context.Ventas
                .Include(v => v.Detalles)
                .Where(v => v.Activo && v.SocioID == socioId)
                .OrderByDescending(v => v.FechaVenta)
                .ToListAsync();
        }

        public async Task<IEnumerable<Venta>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var query = _context.Ventas
                .Include(v => v.Detalles)
                .AsQueryable();

            if (!incluirInactivas)
            {
                query = query.Where(v => v.Activo);
            }

            return await query.OrderByDescending(v => v.FechaVenta).ToListAsync();
        }
    }
}
