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
    public class PagoSocioMembresiaService : IPagoSocioMembresiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<PagoSocioMembresiaCreateDto> _createValidator;
        private readonly IValidator<PagoSocioMembresiaUpdateDto> _updateValidator;

        public PagoSocioMembresiaService(
            IUnitOfWork unitOfWork,
            IValidator<PagoSocioMembresiaCreateDto> createValidator,
            IValidator<PagoSocioMembresiaUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<PagoSocioMembresiaDto>> ObtenerTodasAsync(bool incluirInactivas = false)
        {
            var pagos = await _unitOfWork.PagoSocioMembresia.ObtenerTodasAsync(incluirInactivas);

            return pagos.Select(MapToDto);
        }

        public async Task<PagoSocioMembresiaDto?> ObtenerPorIdAsync(int id)
        {
            var pago = await _unitOfWork.PagoSocioMembresia.ObtenerPorIdAsync(id);
            if (pago == null) return null;

            return MapToDto(pago);
        }

        public async Task<PagoSocioMembresiaDto> CrearAsync(PagoSocioMembresiaCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            // Validar que la asignación de membresía exista
            var socioMembresia = await _unitOfWork.SocioMembresia.ObtenerPorIdAsync(dto.SocioMembresiaID);
            if (socioMembresia == null)
            {
                throw new BusinessException("La membresía del socio especificada no existe.");
            }

            // Validar si el folio ya está registrado
            if (!string.IsNullOrWhiteSpace(dto.Folio) && await _unitOfWork.PagoSocioMembresia.ExisteFolioAsync(dto.Folio))
            {
                throw new BusinessException($"Ya existe un pago registrado con el folio '{dto.Folio}'.");
            }

            var nuevoPago = new PagoSocioMembresia
            {
                SocioMembresiaID = dto.SocioMembresiaID,
                Monto = dto.Monto,
                Folio = dto.Folio?.Trim(),
                FormaPago = string.IsNullOrWhiteSpace(dto.FormaPago) ? "Efectivo" : dto.FormaPago.Trim(),
                Observacion = dto.Observacion?.Trim(),
                UsuarioID = dto.UsuarioID,
                Activo = true
            };

            await _unitOfWork.PagoSocioMembresia.AgregarAsync(nuevoPago);

            // 1. REGISTRAR INGRESO EN CAJA - ConceptoID 3 ('Pago Membresia')
            if (dto.Monto > 0)
            {
                // Obtiene el corte abierto o lo abre automáticamente si no existe
                var corteAbierto = await ObtenerOAbrirCorteAsync(dto.UsuarioID);

                var movimientoIngreso = new Movimiento
                {
                    CorteID = corteAbierto.CorteID,
                    UsuarioID = dto.UsuarioID,
                    ConceptoID = 3, // 3: 'Pago Membresia' (Ingreso)
                    Tipo = "Ingreso",
                    FormaPago = string.IsNullOrWhiteSpace(dto.FormaPago) ? "Efectivo" : dto.FormaPago.Trim(),
                    Total = dto.Monto,
                    Observacion = $"Pago Membresía ID: {dto.SocioMembresiaID}. {dto.Observacion}".Trim(),
                    Activo = true
                };

                await _unitOfWork.Movimiento.AgregarAsync(movimientoIngreso);
            }

            await _unitOfWork.SaveChangesAsync();

            return MapToDto(nuevoPago);
        }

        public async Task ActualizarAsync(PagoSocioMembresiaUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var pago = await _unitOfWork.PagoSocioMembresia.ObtenerPorIdAsync(dto.PagoID);
            if (pago == null)
            {
                throw new BusinessException("El pago que intenta actualizar no existe.");
            }

            // Validar si el folio ya existe en otro registro
            if (!string.IsNullOrWhiteSpace(dto.Folio) && await _unitOfWork.PagoSocioMembresia.ExisteFolioAsync(dto.Folio, dto.PagoID))
            {
                throw new BusinessException($"Ya existe otro pago registrado con el folio '{dto.Folio}'.");
            }

            pago.Monto = dto.Monto;
            pago.Folio = dto.Folio?.Trim();
            pago.FormaPago = string.IsNullOrWhiteSpace(dto.FormaPago) ? "Efectivo" : dto.FormaPago.Trim();
            pago.Observacion = dto.Observacion?.Trim();
            pago.Activo = dto.Activo;

            _unitOfWork.PagoSocioMembresia.Actualizar(pago);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var pago = await _unitOfWork.PagoSocioMembresia.ObtenerPorIdAsync(id);
            if (pago == null)
            {
                throw new BusinessException("El pago a desactivar no existe.");
            }

            _unitOfWork.PagoSocioMembresia.EliminarLogico(pago);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var pago = await _unitOfWork.PagoSocioMembresia.ObtenerPorIdAsync(id);
            if (pago == null)
            {
                throw new BusinessException("El pago a eliminar no existe.");
            }

            _unitOfWork.PagoSocioMembresia.EliminarFisico(pago);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<PagoSocioMembresiaDto>> ObtenerPorSocioMembresiaIdAsync(int socioMembresiaId, bool incluirInactivos = false)
        {
            var pagos = await _unitOfWork.PagoSocioMembresia.ObtenerPorSocioMembresiaIdAsync(socioMembresiaId, incluirInactivos);

            return pagos.Select(MapToDto);
        }

        public async Task<decimal> ObtenerTotalPagadoPorSocioMembresiaIdAsync(int socioMembresiaId)
        {
            return await _unitOfWork.PagoSocioMembresia.ObtenerTotalPagadoPorSocioMembresiaIdAsync(socioMembresiaId);
        }

        public async Task AnularPagoAsync(int pagoId, int usuarioId, string? motivo = null)
        {
            var pago = await _unitOfWork.PagoSocioMembresia.ObtenerPorIdAsync(pagoId);
            if (pago == null)
            {
                throw new BusinessException("El pago que intenta anular no existe.");
            }

            if (!pago.Activo)
            {
                throw new BusinessException("El pago seleccionado ya se encuentra anulado o inactivo.");
            }

            // 1. Desactivar el pago y actualizar observación
            pago.Activo = false;
            pago.Observacion = string.IsNullOrEmpty(pago.Observacion)
                ? $"[ANULADO]: {motivo}"
                : $"{pago.Observacion} | [ANULADO]: {motivo}";

            _unitOfWork.PagoSocioMembresia.Actualizar(pago);

            // 2. REGISTRAR EGRESO EN CAJA - ConceptoID 4 ('Cancelacion Pago Membresia')
            if (pago.Monto > 0)
            {
                // Obtiene el corte abierto o lo abre automáticamente si no existe
                var corteAbierto = await ObtenerOAbrirCorteAsync(usuarioId);

                var movimientoEgreso = new Movimiento
                {
                    CorteID = corteAbierto.CorteID,
                    UsuarioID = usuarioId,
                    ConceptoID = 4, // 4: 'Cancelacion Pago Membresia' (Egreso)
                    Tipo = "Egreso",
                    FormaPago = string.IsNullOrWhiteSpace(pago.FormaPago) ? "Efectivo" : pago.FormaPago,
                    Total = pago.Monto,
                    Observacion = $"Cancelación Pago Membresía Folio/ID: {pago.Folio ?? pago.PagoID.ToString()}. Motivo: {motivo}".Trim(),
                    Activo = true
                };

                await _unitOfWork.Movimiento.AgregarAsync(movimientoEgreso);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        private static PagoSocioMembresiaDto MapToDto(PagoSocioMembresia pago)
        {
            return new PagoSocioMembresiaDto
            {
                PagoID = pago.PagoID,
                SocioMembresiaID = pago.SocioMembresiaID,
                Monto = pago.Monto,
                Folio = pago.Folio,
                FormaPago = pago.FormaPago,
                Observacion = pago.Observacion,
                Activo = pago.Activo,
                CreatedAt = pago.CreatedAt,
                UpdatedAt = pago.UpdatedAt
            };
        }

        private async Task<Corte> ObtenerOAbrirCorteAsync(int usuarioId)
        {
            var corteAbierto = await _unitOfWork.Corte.ObtenerCorteAbiertoPorUsuarioAsync(usuarioId);

            if (corteAbierto == null)
            {
                // 1. Consultar la configuración del Efectivo Inicial predeterminado
                var configEfectivo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync("EfectivoInicial");
                decimal efectivoInicial = 0.00m;

                if (configEfectivo != null && decimal.TryParse(configEfectivo.Valor, out decimal monto))
                {
                    efectivoInicial = monto;
                }

                // 2. Crear automáticamente la caja para el usuario actual
                corteAbierto = new Corte
                {
                    UsuarioID = usuarioId,
                    FechaApertura = DateTime.Now,
                    MontoInicial = efectivoInicial,
                    TotalIngresos = 0m,
                    TotalEgresos = 0m,
                    MontoFinal = efectivoInicial,
                    Observaciones = "Apertura automática iniciada por cobro/movimiento de Membresía",
                    Estado = "Abierto",
                    Activo = true
                };

                await _unitOfWork.Corte.AgregarAsync(corteAbierto);
                await _unitOfWork.SaveChangesAsync();
            }

            return corteAbierto;
        }
    }
}
