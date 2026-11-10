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

        public async Task<bool> ExisteProductoEnVentasAsync(int productoId)
        {
            return await _context.Set<DetalleVenta>()
                .AnyAsync(dv => dv.ProductoID == productoId);
        }

        public void MarcarComoEliminado(Venta venta)
        {
            venta.Activo = false;
            venta.Estado = "Eliminado"; // O el campo que utilices para distinguir el estado
            _context.Ventas.Update(venta);
        }

        // Cambia el estado a Inactivo (Anulado)
        public void MarcarComoInactivo(Venta venta)
        {
            venta.Activo = false;
            venta.Estado = "Inactivo";
            _context.Ventas.Update(venta);
        }

        public async Task<Venta?> ObtenerPorIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Producto)   // para mostrar el nombre del producto en el detalle y el ticket
               .FirstOrDefaultAsync(v => v.VentaID == id && v.Estado != "Eliminado");
        }

        public async Task<IEnumerable<Venta>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Ventas
                .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
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

        // Listado: sin ThenInclude(Producto) y sin rastreo. Solo cargan las líneas (para contar productos).
        // Incluye las ventas anuladas (el formulario las muestra en gris y no las suma al total).
        public async Task<IEnumerable<Venta>> ObtenerResumenPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Ventas
                .AsNoTracking()
                .Include(v => v.Detalles)
               .Where(v => v.Estado != "Eliminado" && v.FechaVenta >= fechaInicio && v.FechaVenta <= fechaFin)
                .OrderByDescending(v => v.FechaVenta)
                .ToListAsync();
        }

        public async Task<IEnumerable<Venta>> ObtenerTodasAsync(string? estadoFiltro = "Activo")
        {
            var query = _context.Ventas
                .Include(v => v.Detalles)
                .AsQueryable();

            // Con un estado ("Activo", "Inactivo" o "Eliminado") se devuelven solo las ventas en ese estado;
            // sin estado (null o vacío) se devuelven todas menos las eliminadas.
            if (!string.IsNullOrEmpty(estadoFiltro))
            {
                query = query.Where(v => v.Estado == estadoFiltro);
            }
            else
            {
                query = query.Where(v => v.Estado != "Eliminado");
            }

            return await query.OrderByDescending(v => v.FechaVenta).ToListAsync();
        }
    }
}
