using Negocio.DTOs;
using Negocio.Interfaces;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controller
{
    public class ProductoController
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IEnumerable<ProductoViewModel>> ObtenerProductosAsync(bool incluirInactivos = true)
        {
            var dtos = await _productoService.ObtenerTodasAsync(incluirInactivos);

            return dtos.Select(p => new ProductoViewModel
            {
                ProductoID = p.ProductoID,
                CategoriaID = p.CategoriaID,
                CategoriaNombre = p.CategoriaNombre ?? "Sin Categoría",
                CodigoBarras = p.CodigoBarras,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock,
                Activo = p.Activo,
                CreatedAt = p.CreatedAt
            });
        }

        public async Task<ProductoDto?> ObtenerPorIdAsync(int id)
        {
            return await _productoService.ObtenerPorIdAsync(id);
        }

        public async Task GuardarProductoAsync(int? id, int categoriaId, string? codigoBarras, string nombre, decimal precio, int stock, bool activo = true)
        {
            if (id.HasValue && id.Value > 0)
            {
                var updateDto = new ProductoUpdateDto
                {
                    ProductoID = id.Value,
                    CategoriaID = categoriaId,
                    CodigoBarras = codigoBarras,
                    Nombre = nombre,
                    Precio = precio,
                    Stock = stock,
                    Activo = activo
                };
                await _productoService.ActualizarAsync(updateDto);
            }
            else
            {
                var createDto = new ProductoCreateDto
                {
                    CategoriaID = categoriaId,
                    CodigoBarras = codigoBarras,
                    Nombre = nombre,
                    Precio = precio,
                    Stock = stock
                };
                await _productoService.CrearAsync(createDto);
            }
        }

        public async Task CambiarEstadoLogicoAsync(int id)
        {
            await _productoService.EliminarLogicoAsync(id);
        }

        public async Task EliminarFisicoAsync(int id)
        {
            await _productoService.EliminarFisicoAsync(id);
        }
    }
}
