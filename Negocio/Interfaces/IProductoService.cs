using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<ProductoDto?> ObtenerPorIdAsync(int id);
        Task<ProductoDto> CrearAsync(ProductoCreateDto dto);
        Task ActualizarAsync(ProductoUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);

        /// <summary>
        /// Descuenta stock de un producto al realizar una venta en la recepción.
        /// </summary>
        Task DescontarStockAsync(int productoId, int cantidad);

        /// <summary>
        /// Reabastece inventario (ingreso de suplidores/bebidas).
        /// </summary>
        Task ReabastecerStockAsync(int productoId, int cantidad);

        /// <summary>
        /// Consulta productos con bajo stock para alertas en el dashboard.
        /// </summary>
        Task<IEnumerable<ProductoDto>> ObtenerProductosConBajoStockAsync(int umbralMinimo = 5);

        /// <summary>
        /// Busca un producto escaneando directamente con lector de código de barras.
        /// </summary>
        Task<ProductoDto?> ObtenerPorCodigoBarrasAsync(string codigoBarras);

    }
}
