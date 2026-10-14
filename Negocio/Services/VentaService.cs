using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class VentaService : IVentaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<VentaCreateDto> _createValidator;
        private readonly CajaHelper _caja;

        public VentaService(
            IUnitOfWork unitOfWork,
            IValidator<VentaCreateDto> createValidator,
            CajaHelper caja)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _caja = caja;
        }

        public async Task<IEnumerable<VentaDto>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var ventas = await _unitOfWork.Venta.ObtenerTodasAsync(incluirInactivas);

            return ventas.Select(MapToDto);
        }

        public async Task<VentaDto?> ObtenerPorIdAsync(int id)
        {
            var venta = await _unitOfWork.Venta.ObtenerPorIdAsync(id);
            if (venta == null) return null;

            return MapToDto(venta);
        }

        public async Task<VentaDto> CrearAsync(VentaCreateDto dto)
        {
            // 1. Validar DTO con FluentValidation
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            // 2. Validar que la venta tenga al menos un producto
            if (dto.Detalles == null || !dto.Detalles.Any())
            {
                throw new BusinessException("La venta debe contener al menos un producto.");
            }

            // 3. Validar existencia y stock de los productos
            var nuevaVenta = new Venta
            {
                UsuarioID = dto.UsuarioID,
                SocioID = dto.SocioID,
                FechaVenta = DateTime.Now,
                Activo = true,
                Total = 0
            };

            foreach (var detalleDto in dto.Detalles)
            {
                var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(detalleDto.ProductoID);
                if (producto == null)
                {
                    throw new BusinessException($"El producto con ID {detalleDto.ProductoID} no existe.");
                }

                if (!producto.Activo)
                {
                    throw new BusinessException($"El producto '{producto.Nombre}' se encuentra inactivo y no se puede vender.");
                }

                if (producto.Stock < detalleDto.Cantidad)
                {
                    throw new BusinessException($"Stock insuficiente para '{producto.Nombre}'. Stock actual: {producto.Stock}, requerido: {detalleDto.Cantidad}.");
                }

                // Descontar stock
                producto.Stock -= detalleDto.Cantidad;
                _unitOfWork.Producto.Actualizar(producto);

                // Agregar al detalle
                nuevaVenta.Detalles.Add(new DetalleVenta
                {
                    ProductoID = detalleDto.ProductoID,
                    Cantidad = detalleDto.Cantidad,
                    PrecioUnitario = detalleDto.PrecioUnitario
                });

                nuevaVenta.Total += detalleDto.Cantidad * detalleDto.PrecioUnitario;
            }

            await _unitOfWork.Venta.AgregarAsync(nuevaVenta);

            // REGISTRAR INGRESO EN CAJA - 'Venta Producto'.
            // Venta, stock, movimiento (y el corte, si hubo que abrirlo) se guardan en UN solo paso:
            // antes eran tres guardados y un fallo en medio dejaba la venta sin su ingreso en caja.
            if (nuevaVenta.Total > 0)
            {
                var corteAbierto = await _caja.ObtenerOAbrirCorteAsync(dto.UsuarioID, "venta de productos");

                // El ID de la venta no existe hasta guardar, por eso la observación lleva la fecha y hora.
                await _caja.AgregarMovimientoAsync(
                    corteAbierto, dto.UsuarioID, CajaConstantes.ConceptoVenta, CajaConstantes.TipoIngreso,
                    nuevaVenta.Total, $"Cobro por venta de productos - {nuevaVenta.FechaVenta:dd/MM/yyyy HH:mm}");
            }

            await _unitOfWork.SaveChangesAsync();

            return MapToDto(nuevaVenta);
        }

        public async Task EliminarLogicoAsync(int id, int usuarioId, string? motivo = null)
        {
            var venta = await _unitOfWork.Venta.ObtenerPorIdAsync(id);
            if (venta == null)
            {
                throw new BusinessException("La venta a anular no existe.");
            }

            if (!venta.Activo)
            {
                throw new BusinessException("La venta ya se encuentra anulada.");
            }

            decimal montoDevuelto = venta.Total;

            // Revertir el stock de los productos al anular la venta
            foreach (var detalle in venta.Detalles)
            {
                var producto = await _unitOfWork.Producto.ObtenerPorIdAsync(detalle.ProductoID);
                if (producto != null)
                {
                    producto.Stock += detalle.Cantidad;
                    _unitOfWork.Producto.Actualizar(producto);
                }
            }

            _unitOfWork.Venta.EliminarLogico(venta);

            // REGISTRAR EGRESO EN CAJA - 'Cancelacion Venta Producto'
            // Antes, si el usuario no tenía corte abierto, la venta se anulaba pero la devolución no quedaba registrada.
            if (montoDevuelto > 0)
            {
                var corteAbierto = await _caja.ObtenerOAbrirCorteAsync(usuarioId, "cancelación de venta");

                await _caja.AgregarMovimientoAsync(
                    corteAbierto, usuarioId, CajaConstantes.ConceptoCancelacionVenta, CajaConstantes.TipoEgreso,
                    montoDevuelto, $"Devolución por cancelación de venta ID #{venta.VentaID}. {motivo?.Trim()}".Trim());
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var venta = await _unitOfWork.Venta.ObtenerPorIdAsync(id);
            if (venta == null)
            {
                throw new BusinessException("La venta a eliminar no existe.");
            }

            _unitOfWork.Venta.EliminarFisico(venta);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<VentaDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var ventas = await _unitOfWork.Venta.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);
            return ventas.Select(MapToDto);
        }

        public async Task<IEnumerable<VentaDto>> ObtenerPorSocioIdAsync(int socioId)
        {
            var ventas = await _unitOfWork.Venta.ObtenerPorSocioIdAsync(socioId);
            return ventas.Select(MapToDto);
        }

        // Método privado helper para mapear Entidad a DTO
        private static VentaDto MapToDto(Venta v)
        {
            return new VentaDto
            {
                VentaID = v.VentaID,
                UsuarioID = v.UsuarioID,
                SocioID = v.SocioID,
                Total = v.Total,
                FechaVenta = v.FechaVenta,
                Activo = v.Activo,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt,
                Detalles = v.Detalles?.Select(d => new DetalleVentaDto
                {
                    DetalleVentaID = d.DetalleID,
                    VentaID = d.VentaID,
                    ProductoID = d.ProductoID,
                    ProductoNombre = d.Producto?.Nombre ?? "Producto no disponible",
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList() ?? new List<DetalleVentaDto>()
            };
        }
    }
}
