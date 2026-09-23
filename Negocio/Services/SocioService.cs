using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    public class SocioService : ISocioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<SocioCreateDto> _createValidator;
        private readonly IValidator<SocioUpdateDto> _updateValidator;

        public SocioService(
            IUnitOfWork unitOfWork,
            IValidator<SocioCreateDto> createValidator,
            IValidator<SocioUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<SocioDto>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var socios = await _unitOfWork.Socio.ObtenerTodosAsync(incluirInactivos);

            return socios.Select(s => new SocioDto
            {
                SocioID = s.SocioID,
                Clave = s.Clave,
                Nombre = s.Nombre,
                Apellido = s.Apellido,
                Telefono = s.Telefono,
                Email = s.Email,
                Foto = s.Foto,
                Observaciones = s.Observaciones,
                Activo = s.Activo,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            });
        }

        public async Task<SocioDto?> ObtenerPorIdAsync(int id)
        {
            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(id);
            if (socio == null) return null;

            return new SocioDto
            {
                SocioID = socio.SocioID,
                Clave = socio.Clave,
                Nombre = socio.Nombre,
                Apellido = socio.Apellido,
                Telefono = socio.Telefono,
                Email = socio.Email,
                Foto = socio.Foto,
                Observaciones = socio.Observaciones,
                Activo = socio.Activo,
                CreatedAt = socio.CreatedAt,
                UpdatedAt = socio.UpdatedAt
            };
        }

        public async Task<SocioDto> CrearAsync(SocioCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            if (await _unitOfWork.Socio.ExisteClaveAsync(dto.Clave))
            {
                throw new BusinessException($"Ya existe un socio registrado con la clave '{dto.Clave}'.");
            }

            var nuevoSocio = new Socio
            {
                Clave = dto.Clave.Trim(),
                Nombre = dto.Nombre.Trim(),
                Apellido = dto.Apellido.Trim(),
                Telefono = dto.Telefono?.Trim(),
                Email = dto.Email?.Trim(),
                Foto = dto.Foto,
                Observaciones = dto.Observaciones?.Trim(),
                Activo = true
            };

            await _unitOfWork.Socio.AgregarAsync(nuevoSocio);
            await _unitOfWork.SaveChangesAsync();

            return new SocioDto
            {
                SocioID = nuevoSocio.SocioID,
                Clave = nuevoSocio.Clave,
                Nombre = nuevoSocio.Nombre,
                Apellido = nuevoSocio.Apellido,
                Telefono = nuevoSocio.Telefono,
                Email = nuevoSocio.Email,
                Foto = nuevoSocio.Foto,
                Observaciones = nuevoSocio.Observaciones,
                Activo = nuevoSocio.Activo,
                CreatedAt = nuevoSocio.CreatedAt,
                UpdatedAt = nuevoSocio.UpdatedAt
            };
        }

        public async Task ActualizarAsync(SocioUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(dto.SocioID);
            if (socio == null)
            {
                throw new BusinessException("El socio que intenta actualizar no existe.");
            }

            if (await _unitOfWork.Socio.ExisteClaveAsync(dto.Clave, dto.SocioID))
            {
                throw new BusinessException($"Ya existe otro socio registrado con la clave '{dto.Clave}'.");
            }

            socio.Clave = dto.Clave.Trim();
            socio.Nombre = dto.Nombre.Trim();
            socio.Apellido = dto.Apellido.Trim();
            socio.Telefono = dto.Telefono?.Trim();
            socio.Email = dto.Email?.Trim();
            socio.Foto = dto.Foto;
            socio.Observaciones = dto.Observaciones?.Trim();
            socio.Activo = dto.Activo;

            _unitOfWork.Socio.Actualizar(socio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(id);
            if (socio == null)
            {
                throw new BusinessException("El socio a desactivar no existe.");
            }

            _unitOfWork.Socio.EliminarLogico(socio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(id);
            if (socio == null)
            {
                throw new BusinessException("El socio a eliminar no existe.");
            }

            // Validar si tiene membresías asociadas antes de eliminar físicamente
            var membresiasAsociadas = await _unitOfWork.SocioMembresia.ObtenerPorSocioIdAsync(id);
            if (membresiasAsociadas.Any())
            {
                throw new BusinessException("No se puede eliminar el socio porque tiene historial de membresías registradas. Desactívelo en su lugar.");
            }

            _unitOfWork.Socio.EliminarFisico(socio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> ObtenerSiguienteClaveFormateadaAsync()
        {
            int siguienteNumero = await _unitOfWork.Socio.ObtenerSiguienteNumeroClaveAsync();

            // Retorna directamente el número formateado con 4 dígitos (ej: "0001", "0042")
            return siguienteNumero.ToString("D4");
        }

        public async Task<SocioDetalleDto?> ObtenerDetalleCompletoAsync(int socioId)
        {
            // Obtiene la entidad Socio junto con SocioMembresias y Visitas desde el repositorio
            var socio = await _unitOfWork.Socio.ObtenerDetalleCompletoAsync(socioId);

            if (socio == null) return null;

            return new SocioDetalleDto
            {
                SocioID = socio.SocioID,
                Clave = socio.Clave,
                Nombre = socio.Nombre,
                Apellidos = socio.Apellido, // Mapea la propiedad Apellido de la entidad a Apellidos del DTO
                Telefono = socio.Telefono,
                Email = socio.Email,
                Foto = socio.Foto,
                Activo = socio.Activo,

                // Mapeo del historial de membresías
                HistorialMembresias = socio.SocioMembresias
                    .OrderByDescending(sm => sm.FechaInicio)
                    .Select(sm => new SocioMembresiaHistorialDto
                    {
                        NombreMembresia = sm.Membresia?.Nombre ?? "N/A",
                        FechaInicio = sm.FechaInicio,
                        FechaFin = sm.FechaFin,
                        Precio = sm.Membresia?.Precio ?? 0,
                        Estado = sm.FechaFin >= DateTime.Today ? "Vigente" : "Vencida"
                    }).ToList(),

                // Mapeo del historial de visitas/asistencias
                HistorialVisitas = socio.Visitas
                    .OrderByDescending(v => v.CreatedAt) // Asegúrate que el campo de fecha en Visita coincida (ej: FechaHora o FechaVisita)
                    .Select(v => new SocioVisitaHistorialDto
                    {
                        FechaHoraEntrada = v.CreatedAt,
                        TipoAcceso = v.TipoAcceso // O el campo correspondiente al tipo de acceso en tu entidad Visita
                    }).ToList()
            };
        }
    }
}
