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
    public class SocioMembresiaService : ISocioMembresiaService
    {
        private const string EstadoActiva = "Activa";
        private const string EstadoCancelada = "Cancelada";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AsignarMembresiaDto> _asignarValidator;

        public SocioMembresiaService(
            IUnitOfWork unitOfWork,
            IValidator<AsignarMembresiaDto> asignarValidator)
        {
            _unitOfWork = unitOfWork;
            _asignarValidator = asignarValidator;
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

            // Solo la fecha: evita que la hora de captura mueva el vencimiento
            var fechaInicio = dto.FechaInicio.Date;
            var fechaFin = fechaInicio.AddDays(membresia.DuracionDias);

            // No permitir periodos encimados con otra membresía no cancelada del mismo socio.
            // Para renovar por adelantado basta elegir como inicio la fecha de vencimiento de la actual.
            var existentes = await _unitOfWork.SocioMembresia.ObtenerPorSocioIdAsync(dto.SocioID);
            var choque = existentes.FirstOrDefault(sm =>
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
                // Si tu tabla TIENE la columna Precio, descomenta para congelar el precio al momento de la venta:
                // Precio = membresia.Precio
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

            // Borrar una membresía con pagos (activos o no) dejaría movimientos de caja sin origen.
            // Requiere que el repositorio incluya los Pagos en ObtenerPorIdAsync (ver cambio indicado).
            if (registro.Pagos != null && registro.Pagos.Any())
                throw new BusinessException("No se puede eliminar la membresía porque tiene pagos registrados. Cancélela en su lugar.");

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
