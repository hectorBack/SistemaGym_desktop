using Datos.Entities;
using Datos.Interfaces;
using Datos.Repositories;
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
    public class CorteService : ICorteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CorteCreateDto> _createValidator;
        private readonly IValidator<CorteUpdateDto> _updateValidator;

        public CorteService(
            IUnitOfWork unitOfWork,
            IValidator<CorteCreateDto> createValidator,
            IValidator<CorteUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<CorteDto>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var cortes = await _unitOfWork.Corte.ObtenerTodosAsync(incluirInactivos);

            return cortes.Select(MapearADto);
        }

        public async Task<CorteDto?> ObtenerPorIdAsync(int id)
        {
            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(id);
            if (corte == null) return null;

            return MapearADto(corte);
        }

        public async Task<CorteDto> AbrirCorteAsync(CorteCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            // Validar que el usuario no tenga ya un corte abierto
            if (await _unitOfWork.Corte.TieneCorteAbiertoAsync(dto.UsuarioID))
            {
                throw new BusinessException("El usuario ya tiene un corte de caja abierto actualmente.");
            }

            var nuevoCorte = new Corte
            {
                UsuarioID = dto.UsuarioID,
                FechaApertura = DateTime.Now,
                MontoInicial = dto.MontoInicial,
                TotalIngresos = 0m,
                TotalEgresos = 0m,
                MontoFinal = dto.MontoInicial,
                Observaciones = dto.Observaciones?.Trim(),
                Estado = "Abierto",
                Activo = true
            };

            await _unitOfWork.Corte.AgregarAsync(nuevoCorte);
            await _unitOfWork.SaveChangesAsync();

            // Cargar datos para incluir la navegación de Usuario al retornar el DTO
            var corteCreado = await _unitOfWork.Corte.ObtenerPorIdAsync(nuevoCorte.CorteID);
            return MapearADto(corteCreado ?? nuevoCorte);
        }

        public async Task CerrarCorteAsync(CorteUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(dto.CorteID);
            if (corte == null)
            {
                throw new BusinessException("El corte que intenta cerrar no existe.");
            }

            if (corte.Estado == "Cerrado")
            {
                throw new BusinessException("El corte ya se encuentra cerrado.");
            }

            corte.FechaCierre = DateTime.Now;
            corte.TotalIngresos = dto.TotalIngresos;
            corte.TotalEgresos = dto.TotalEgresos;
            corte.MontoFinal = dto.MontoFinal;
            corte.Observaciones = dto.Observaciones?.Trim();
            corte.Estado = dto.Estado;
            corte.Activo = dto.Activo;

            _unitOfWork.Corte.Actualizar(corte);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(id);
            if (corte == null)
            {
                throw new BusinessException("El corte a desactivar no existe.");
            }

            _unitOfWork.Corte.EliminarLogico(corte);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(id);
            if (corte == null)
            {
                throw new BusinessException("El corte a eliminar no existe.");
            }

            _unitOfWork.Corte.EliminarFisico(corte);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CorteDto?> ObtenerCorteAbiertoPorUsuarioAsync(int usuarioId)
        {
            var corte = await _unitOfWork.Corte.ObtenerCorteAbiertoPorUsuarioAsync(usuarioId);
            if (corte == null) return null;

            return MapearADto(corte);
        }

        public async Task<IEnumerable<CorteDto>> ObtenerPorRangoFechasAsync(DateTime inicio, DateTime fin)
        {
            if (inicio > fin)
            {
                throw new BusinessException("La fecha de inicio no puede ser posterior a la fecha de fin.");
            }

            var cortes = await _unitOfWork.Corte.ObtenerPorRangoFechasAsync(inicio, fin);
            return cortes.Select(MapearADto);
        }

        private static CorteDto MapearADto(Corte c)
        {
            return new CorteDto
            {
                CorteID = c.CorteID,
                UsuarioID = c.UsuarioID,
                NombreUsuario = c.Usuario != null ? c.Usuario.NombreCompleto : $"Usuario {c.UsuarioID}",
                FechaApertura = c.FechaApertura,
                FechaCierre = c.FechaCierre,
                MontoInicial = c.MontoInicial,
                TotalIngresos = c.TotalIngresos,
                TotalEgresos = c.TotalEgresos,
                MontoFinal = c.MontoFinal,
                Observaciones = c.Observaciones,
                Estado = c.Estado,
                Activo = c.Activo,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            };
        }

        public async Task<decimal> ObtenerEfectivoEnCajaAsync()
        {
            return await _unitOfWork.Corte.ObtenerEfectivoEnCajaAsync();
        }
    }
}
