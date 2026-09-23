using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class ProductoService : IProductoService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductoCreateDto> _createValidator;
        private readonly IValidator<ProductoUpdateDto> _updateValidator;

        public ProductoService(
             IUnitOfWork unitOfWork,
            IValidator<ProductoCreateDto> createValidator,
            IValidator<ProductoUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task ActualizarAsync(ProductoUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(dto.ProductoID);
            if (producto == null)
            {
                throw new BusinessException("El producto que intenta actualizar no existe.");
            }

            // Validar que la categoría exista
            var categoria = await _unitOfWork.Categorias.ObtenerPorIdAsync(dto.CategoriaID);
            if (categoria == null)
            {
                throw new BusinessException("La categoría asignada no existe.");
            }

            // Validar nombre duplicado excluyendo el ID actual
            if (await _unitOfWork.Producto.ExisteNombreAsync(dto.Nombre, dto.ProductoID))
            {
                throw new BusinessException($"Ya existe otro producto con el nombre '{dto.Nombre}'.");
            }

            // Validar código de barras duplicado excluyendo el ID actual
            if (!string.IsNullOrWhiteSpace(dto.CodigoBarras))
            {
                if (await _unitOfWork.Producto.ExisteCodigoBarrasAsync(dto.CodigoBarras, dto.ProductoID))
                {
                    throw new BusinessException($"El código de barras '{dto.CodigoBarras}' ya pertenece a otro producto.");
                }
            }

            producto.CategoriaID = dto.CategoriaID;
            producto.CodigoBarras = string.IsNullOrWhiteSpace(dto.CodigoBarras) ? null : dto.CodigoBarras.Trim();
            producto.Nombre = dto.Nombre.Trim();
            producto.Precio = dto.Precio;
            producto.Stock = dto.Stock;
            producto.Activo = dto.Activo;

            _unitOfWork.Producto.Actualizar(producto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ProductoDto> CrearAsync(ProductoCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            // Validar que la categoría exista
            var categoria = await _unitOfWork.Categorias.ObtenerPorIdAsync(dto.CategoriaID);
            if (categoria == null)
            {
                throw new BusinessException("La categoría asignada no existe.");
            }

            // Validar si ya existe un producto con el mismo nombre
            if (await _unitOfWork.Producto.ExisteNombreAsync(dto.Nombre))
            {
                throw new BusinessException($"Ya existe un producto registrado con el nombre '{dto.Nombre}'.");
            }

            // Validar código de barras único si fue proporcionado
            if (!string.IsNullOrWhiteSpace(dto.CodigoBarras))
            {
                if (await _unitOfWork.Producto.ExisteCodigoBarrasAsync(dto.CodigoBarras))
                {
                    throw new BusinessException($"El código de barras '{dto.CodigoBarras}' ya se encuentra registrado.");
                }
            }

            var nuevoProducto = new Producto
            {
                CategoriaID = dto.CategoriaID,
                CodigoBarras = string.IsNullOrWhiteSpace(dto.CodigoBarras) ? null : dto.CodigoBarras.Trim(),
                Nombre = dto.Nombre.Trim(),
                Precio = dto.Precio,
                Stock = dto.Stock,
                Activo = true
            };

            await _unitOfWork.Producto.AgregarAsync(nuevoProducto);
            await _unitOfWork.SaveChangesAsync();

            return new ProductoDto
            {
                ProductoID = nuevoProducto.ProductoID,
                CategoriaID = nuevoProducto.CategoriaID,
                CategoriaNombre = categoria.Nombre,
                CodigoBarras = nuevoProducto.CodigoBarras,
                Nombre = nuevoProducto.Nombre,
                Precio = nuevoProducto.Precio,
                Stock = nuevoProducto.Stock,
                Activo = nuevoProducto.Activo,
                CreatedAt = nuevoProducto.CreatedAt,
                UpdatedAt = nuevoProducto.UpdatedAt
            };
        }

        // 1. Descontar stock al vender en el gimnasio
        public async Task DescontarStockAsync(int productoId, int cantidad)
        {
            if (cantidad <= 0)
                throw new BusinessException("La cantidad a descontar debe ser mayor a cero.");

            var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(productoId);
            if (producto == null)
                throw new BusinessException("El producto no existe.");

            if (!producto.Activo)
                throw new BusinessException($"El producto '{producto.Nombre}' está inactivo y no se puede vender.");

            if (producto.Stock < cantidad)
                throw new BusinessException($"Stock insuficiente para '{producto.Nombre}'. Stock actual: {producto.Stock}, requerido: {cantidad}.");

            producto.Stock -= cantidad;
            _unitOfWork.Producto.Actualizar(producto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(id);
            if (producto == null)
            {
                throw new BusinessException("El producto a eliminar no existe.");
            }

            // Validar en la tabla de DetalleVentas antes de borrar físicamente
            bool tieneVentasAsociadas = await _unitOfWork.Venta.ExisteProductoEnVentasAsync(id);
            if (tieneVentasAsociadas)
            {
                throw new BusinessException("No se puede eliminar físicamente este producto porque cuenta con historial de ventas. Utilice la desactivación (eliminación lógica).");
            }

            _unitOfWork.Producto.EliminarFisico(producto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(id);
            if (producto == null)
            {
                throw new BusinessException("El Producto a desactivar no existe.");
            }

            _unitOfWork.Producto.EliminarLogico(producto);
            await _unitOfWork.SaveChangesAsync();
        }

        // 4. Búsqueda rápida por lector de código de barras
        public async Task<ProductoDto?> ObtenerPorCodigoBarrasAsync(string codigoBarras)
        {
            if (string.IsNullOrWhiteSpace(codigoBarras))
                return null;

            var productos = await _unitOfWork.Producto.ObtenerTodasAsync(incluirInactivas: false);
            var producto = productos.FirstOrDefault(p => p.CodigoBarras == codigoBarras.Trim());

            if (producto == null) return null;

            return new ProductoDto
            {
                ProductoID = producto.ProductoID,
                CategoriaID = producto.CategoriaID,
                CategoriaNombre = producto.Categoria?.Nombre ?? "Sin Categoría",
                CodigoBarras = producto.CodigoBarras,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
                Activo = producto.Activo,
                CreatedAt = producto.CreatedAt,
                UpdatedAt = producto.UpdatedAt
            };
        }

        public async Task<ProductoDto?> ObtenerPorIdAsync(int id)
        {
            var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(id);
            if (producto == null) return null;

            return new ProductoDto
            {
                ProductoID = producto.ProductoID,
                CategoriaID = producto.CategoriaID,
                CategoriaNombre = producto.Categoria?.Nombre,
                CodigoBarras = producto.CodigoBarras,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
                Activo = producto.Activo,
                CreatedAt = producto.CreatedAt,
                UpdatedAt = producto.UpdatedAt
            };
        }

        // 3. Alertas de bajo stock para reabastecimiento oportunamente
        public async Task<IEnumerable<ProductoDto>> ObtenerProductosConBajoStockAsync(int umbralMinimo = 5)
        {
            var productos = await _unitOfWork.Producto.ObtenerTodasAsync(incluirInactivas: false);

            return productos
                .Where(p => p.Stock <= umbralMinimo)
                .Select(p => new ProductoDto
                {
                    ProductoID = p.ProductoID,
                    CategoriaID = p.CategoriaID,
                    CategoriaNombre = p.Categoria?.Nombre ?? "Sin Categoría",
                    CodigoBarras = p.CodigoBarras,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    Activo = p.Activo,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                });
        }

        public async Task<IEnumerable<ProductoDto>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var productos = await _unitOfWork.Producto.ObtenerTodasAsync(incluirInactivas);

            return productos.Select(p => new ProductoDto
            {
                ProductoID = p.ProductoID,
                CategoriaID = p.CategoriaID,
                CategoriaNombre = p.Categoria?.Nombre ?? "Sin Categoría",
                CodigoBarras = p.CodigoBarras,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock,
                Activo = p.Activo,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });
        }

        // 2. Reabastecer stock (Entrada de mercancía)
        public async Task ReabastecerStockAsync(int productoId, int cantidad)
        {
            if (cantidad <= 0)
                throw new BusinessException("La cantidad a ingresar debe ser mayor a cero.");

            var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(productoId);
            if (producto == null)
                throw new BusinessException("El producto no existe.");

            producto.Stock += cantidad;
            _unitOfWork.Producto.Actualizar(producto);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
