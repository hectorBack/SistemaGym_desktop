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
    public class ProductoRepository : IProductoRepository
    {
        private readonly GimnasioDbContext _context;

        public ProductoRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var query = _context.Productos
                .Include(p => p.Categoria)
                .AsQueryable();

            if (!incluirInactivas)
            {
                query = query.Where(p => p.Activo);
            }

            return await query.ToListAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.ProductoID == id);
        }

        public async Task AgregarAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
        }

        public void Actualizar(Producto producto)
        {
            _context.Productos.Update(producto);
        }

        public void EliminarLogico(Producto producto)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            producto.Activo = !producto.Activo;
            _context.Productos.Update(producto);
        }

        public void EliminarFisico(Producto producto)
        {
            _context.Productos.Remove(producto);
        }

        public async Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null)
        {
            var query = _context.Productos.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(p => p.ProductoID != idExcluir.Value);
            }

            return await query.AnyAsync(p => p.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<bool> ExisteCodigoBarrasAsync(string codigoBarras, int? idExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(codigoBarras)) return false;

            var query = _context.Productos.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(p => p.ProductoID != idExcluir.Value);
            }

            return await query.AnyAsync(p => p.CodigoBarras == codigoBarras);
        }

        public async Task<Producto?> ObtenerPorCodigoBarrasAsync(string codigoBarras)
        {
            if (string.IsNullOrWhiteSpace(codigoBarras)) return null;

            return await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.CodigoBarras == codigoBarras);
        }
    }
}
