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

            return registros.Select(sm => new SocioMembresiaDto
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
                TotalPagado = sm.Pagos != null && sm.Pagos.Any()
            ? sm.Pagos.Sum(p => p.Monto)
            : 0
            });
        }

        public async Task<SocioMembresiaDto?> ObtenerPorIdAsync(int id)
        {
            var registro = await _unitOfWork.SocioMembresia.ObtenerPorIdAsync(id);
            if (registro == null) return null;

            return new SocioMembresiaDto
            {
                SocioMembresiaID = registro.SocioMembresiaID,
                SocioID = registro.SocioID,
                MembresiaID = registro.MembresiaID,
                NombreMembresia = registro.Membresia?.Nombre,
                Precio = registro.Membresia?.Precio ?? 0,
                FechaInicio = registro.FechaInicio,
                FechaFin = registro.FechaFin,
                CreatedAt = registro.CreatedAt,
                Estado = registro.Estado,
                TotalPagado = registro.Pagos != null ? registro.Pagos.Sum(p => p.Monto) : 0
            };
        }

        public async Task<SocioMembresiaDto?> ObtenerMembresiaActivaPorSocioIdAsync(int socioId)
        {
            var registro = await _unitOfWork.SocioMembresia.ObtenerMembresiaActivaPorSocioIdAsync(socioId);
            if (registro == null) return null;

            return new SocioMembresiaDto
            {
                SocioMembresiaID = registro.SocioMembresiaID,
                SocioID = registro.SocioID,
                MembresiaID = registro.MembresiaID,
                NombreMembresia = registro.Membresia?.Nombre,
                Precio = registro.Membresia?.Precio ?? 0,
                FechaInicio = registro.FechaInicio,
                FechaFin = registro.FechaFin,
                CreatedAt = registro.CreatedAt,
                Estado = registro.Estado
            };
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
            {
                throw new BusinessException("El socio especificado no existe o no se encuentra activo.");
            }

            var membresia = await _unitOfWork.Membresia.ObtenerPorIdAsync(dto.MembresiaID);
            if (membresia == null || !membresia.Activo)
            {
                throw new BusinessException("La membresía seleccionada no existe o no se encuentra activa.");
            }

            DateTime fechaFinCalculada = dto.FechaInicio.AddDays(membresia.DuracionDias);

            var nuevaSocioMembresia = new SocioMembresia
            {
                SocioID = dto.SocioID,
                MembresiaID = dto.MembresiaID,
                FechaInicio = dto.FechaInicio,
                FechaFin = fechaFinCalculada,
                Estado = "Activa"
                // Si tu tabla de BD TIENE la columna Precio, descomenta la siguiente línea:
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
                Precio = membresia.Precio, // Se obtiene el precio base de la membresía asignada
                CreatedAt = nuevaSocioMembresia.CreatedAt,
                Estado = nuevaSocioMembresia.Estado
            };
        }

        public async Task CancelarMembresiaAsync(int socioMembresiaId)
        {
            var registro = await _unitOfWork.SocioMembresia.ObtenerPorIdAsync(socioMembresiaId);
            if (registro == null)
            {
                throw new BusinessException("El registro de membresía del socio no existe.");
            }

            registro.Estado = "Cancelada";

            _unitOfWork.SocioMembresia.Actualizar(registro);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var registro = await _unitOfWork.SocioMembresia.ObtenerPorIdAsync(id);
            if (registro == null)
            {
                throw new BusinessException("La membresía que intenta eliminar no existe.");
            }

            _unitOfWork.SocioMembresia.Eliminar(registro);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
