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
    public class SocioMembresiaService : ISocioMembresiaService
    {
        private const string EstadoActiva = "Activa";
        private const string EstadoCancelada = "Cancelada";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AsignarMembresiaDto> _asignarValidator;
        private readonly CajaHelper _caja;

        public SocioMembresiaService(
            IUnitOfWork unitOfWork,
            IValidator<AsignarMembresiaDto> asignarValidator,
            CajaHelper caja)
        {
            _unitOfWork = unitOfWork;
            _asignarValidator = asignarValidator;
            _caja = caja;
        }

        public async Task<IEnumerable<SocioMembresiaDto>> ObtenerPorSocioIdAsync(int socioId)
        {
            var registros = await _unitOfWork.SocioMembresia.ObtenerPorSocioIdAsync(socioId);
            return registros.Select(MapearADto).ToList();
        }

        public async Task<SocioMembresiaDto?> ObtenerPorIdAsync(int id)
        {
            var registro = await _unitOfWork.SocioMembresia.ObtenerPorIdAsync(id);
            return registro == null ? null : MapearADto(registro);
        }

        public async Task<SocioMembresiaDto?> ObtenerMembresiaActivaPorSocioIdAsync(int socioId)
        {
            var registro = await _unitOfWork.SocioMembresia.ObtenerMembresiaActivaPorSocioIdAsync(socioId);
            return registro == null ? null : MapearADto(registro);
        }

        public async Task<SocioMembresiaDto> AsignarMembresiaAsync(AsignarMembresiaDto dto)
        {
            var validationResult = await _asignarValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(dto.SocioID);
            if (socio == null || !socio.Activo)
                throw new BusinessException("El socio especificado no existe o no se encuentra activo.");

            var membresia = await _unitOfWork.Membresia.ObtenerPorIdAsync(dto.MembresiaID);
            if (membresia == null || !membresia.Activo)
                throw new BusinessException("La membresía seleccionada no existe o no se encuentra activa.");

            // 🟢 NUEVA VALIDACIÓN: Verificar si el socio tiene alguna membresía en estado "Parcial" (con pagos pendientes)
            var historialesSocio = await _unitOfWork.SocioMembresia.ObtenerPorSocioIdAsync(dto.SocioID);

            foreach (var hist in historialesSocio)
            {
                if (hist.Activo && hist.Estado != EstadoCancelada)
                {
                    // Calculamos lo pagado de esa membresía
                    decimal totalPagadoHist = hist.Pagos?.Where(p => p.Activo).Sum(p => p.Monto) ?? 0;
                    decimal precioMembresiaHist = hist.Membresia?.Precio ?? 0;

                    // Si el estado es "Parcial" o el total pagado es menor al precio total, bloqueamos la asignación
                    if (string.Equals(hist.Estado, "Parcial", StringComparison.OrdinalIgnoreCase) || (precioMembresiaHist > 0 && totalPagadoHist < precioMembresiaHist))
                    {
                        throw new BusinessException(
                            $"El socio tiene una membresía previa ('{hist.Membresia?.Nombre}') en estado Parcial con saldo pendiente. " +
                            "Debe liquidar el pago total de la membresía actual antes de poder asignar una nueva.");
                    }
                }
            }

            // Solo la fecha: evita que la hora de captura mueva el vencimiento
            var fechaInicio = dto.FechaInicio.Date;
            var fechaFin = fechaInicio.AddDays(membresia.DuracionDias);

            // No permitir periodos encimados con otra membresía no cancelada del mismo socio.
            var choque = historialesSocio.FirstOrDefault(sm =>
                sm.Activo &&
                sm.Estado != EstadoCancelada &&
                fechaInicio < sm.FechaFin.Date &&
                fechaFin > sm.FechaInicio.Date);

            if (choque != null)
            {
                throw new BusinessException(
                    $"El socio ya tiene una membresía vigente del {choque.FechaInicio:dd/MM/yyyy} al {choque.FechaFin:dd/MM/yyyy}. " +
                    "Elija una fecha de inicio posterior a su vencimiento.");
            }

            var nuevaSocioMembresia = new SocioMembresia
            {
                SocioID = dto.SocioID,
                MembresiaID = dto.MembresiaID,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                Estado = EstadoActiva
            };

            await _unitOfWork.SocioMembresia.AgregarAsync(nuevaSocioMembresia);
            await _unitOfWork.SaveChangesAsync();

            return new SocioMembresiaDto
            {
                SocioMembresiaID = nuevaSocioMembresia.SocioMembresiaID,
                SocioID = nuevaSocioMembresia.SocioID,
                MembresiaID = nuevaSocioMembresia.MembresiaID,
                NombreMembresia = membresia.Nombre,
                FechaInicio = nuevaSocioMembresia.FechaInicio,
                FechaFin = nuevaSocioMembresia.FechaFin,
                Precio = membresia.Precio,
                CreatedAt = nuevaSocioMembresia.CreatedAt,
                Estado = nuevaSocioMembresia.Estado,
                TotalPagado = 0
            };
        }

        public async Task CancelarMembresiaAsync(int socioMembresiaId)
        {
            var registro = await _unitOfWork.SocioMembresia.ObtenerPorIdAsync(socioMembresiaId);
            if (registro == null)
                throw new BusinessException("El registro de membresía del socio no existe.");

            if (registro.Estado == EstadoCancelada)
                throw new BusinessException("La membresía ya se encuentra cancelada.");

            registro.Estado = EstadoCancelada;

            _unitOfWork.SocioMembresia.Actualizar(registro);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var registro = await _unitOfWork.SocioMembresia.ObtenerPorIdAsync(id);
            if (registro == null)
                throw new BusinessException("La membresía que intenta eliminar no existe.");

            var pagosAsociados = await _unitOfWork.PagoSocioMembresia.ObtenerPorSocioMembresiaIdAsync(id);
            var pagosActivos = pagosAsociados?.Where(p => p.Activo).ToList() ?? new List<PagoSocioMembresia>();

            decimal montoTotalPagado = pagosActivos.Sum(p => p.Monto);
            int usuarioIdSesion = pagosActivos.FirstOrDefault()?.UsuarioID ?? 1;
            string formaPagoOriginal = pagosActivos.FirstOrDefault()?.FormaPago ?? "Efectivo";

            if (montoTotalPagado > 0)
            {
                // 1. Obtener o abrir el corte de caja vigente
                var corteAbierto = await _caja.ObtenerOAbrirCorteAsync(usuarioIdSesion, "cancelación de membresía y devolución");

                // 2. Registrar el egreso en la tabla Movimientos de forma explícita
                var nuevoMovimiento = await _caja.AgregarMovimientoAsync(
                    corteAbierto,
                    usuarioIdSesion,
                    CajaConstantes.ConceptoCancelacionPagoMembresia,
                    CajaConstantes.TipoEgreso,
                    montoTotalPagado,
                    string.Empty,
                    formaPagoOriginal // Pasamos la forma de pago para que no quede vacía
                );

                // 3. Desactivar lógicamente los pagos asociados y asignarles el MovimientoID de la cancelación si aplica
                foreach (var pago in pagosActivos)
                {
                    pago.Activo = false;
                    // Opcional: si tu entidad PagoSocioMembresia tiene MovimientoID, puedes enlazarlo aquí también
                    _unitOfWork.PagoSocioMembresia.Actualizar(pago);
                }
            }

            // 4. Eliminar la membresía y confirmar los cambios en la base de datos
            _unitOfWork.SocioMembresia.Eliminar(registro);
            await _unitOfWork.SaveChangesAsync();
        }

        // ───────── Helpers ─────────

        private static SocioMembresiaDto MapearADto(SocioMembresia sm) => new()
        {
            SocioMembresiaID = sm.SocioMembresiaID,
            SocioID = sm.SocioID,
            MembresiaID = sm.MembresiaID,
            NombreMembresia = sm.Membresia?.Nombre,
            Precio = sm.Membresia?.Precio ?? 0,
            FechaInicio = sm.FechaInicio,
            FechaFin = sm.FechaFin,
            CreatedAt = sm.CreatedAt,
            Estado = sm.Estado,
            // Solo pagos activos, igual que el reporte y el repositorio de pagos
            TotalPagado = sm.Pagos?.Where(p => p.Activo).Sum(p => p.Monto) ?? 0
        };
    }
}
