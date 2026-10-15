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
        private const string EstadoCancelada = "Cancelada";

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
            return socios.Select(MapearADto).ToList();
        }

        public async Task<SocioDto?> ObtenerPorIdAsync(int id)
        {
            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(id);
            return socio == null ? null : MapearADto(socio);
        }

        public async Task<SocioDto> CrearAsync(SocioCreateDto dto)
        {
            ValidarResultado(await _createValidator.ValidateAsync(dto));

            var clave = dto.Clave.Trim();
            if (await _unitOfWork.Socio.ExisteClaveAsync(clave))
                throw new BusinessException($"Ya existe un socio registrado con la clave '{clave}'.");

            var nuevoSocio = new Socio
            {
                Clave = clave,
                Nombre = dto.Nombre.Trim(),
                Apellido = dto.Apellido.Trim(),
                Telefono = LimpiarOpcional(dto.Telefono),
                Email = LimpiarOpcional(dto.Email),
                Foto = dto.Foto,
                Observaciones = LimpiarOpcional(dto.Observaciones),
                Activo = true
            };

            await _unitOfWork.Socio.AgregarAsync(nuevoSocio);
            await _unitOfWork.SaveChangesAsync();

            return MapearADto(nuevoSocio);
        }

        public async Task ActualizarAsync(SocioUpdateDto dto)
        {
            ValidarResultado(await _updateValidator.ValidateAsync(dto));

            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(dto.SocioID);
            if (socio == null)
                throw new BusinessException("El socio que intenta actualizar no existe.");

            var clave = dto.Clave.Trim();
            if (await _unitOfWork.Socio.ExisteClaveAsync(clave, dto.SocioID))
                throw new BusinessException($"Ya existe otro socio registrado con la clave '{clave}'.");

            socio.Clave = clave;
            socio.Nombre = dto.Nombre.Trim();
            socio.Apellido = dto.Apellido.Trim();
            socio.Telefono = LimpiarOpcional(dto.Telefono);
            socio.Email = LimpiarOpcional(dto.Email);
            socio.Foto = dto.Foto;
            socio.Observaciones = LimpiarOpcional(dto.Observaciones);
            socio.Activo = dto.Activo;

            _unitOfWork.Socio.Actualizar(socio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarLogicoAsync(int id)
        {
            var socio = await _unitOfWork.Socio.ObtenerPorIdAsync(id);
            if (socio == null)
                throw new BusinessException("El socio a desactivar no existe.");

            if (!socio.Activo)
                throw new BusinessException("El socio ya se encuentra desactivado.");

            _unitOfWork.Socio.EliminarLogico(socio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            // Se usa el detalle completo para revisar también las visitas, no solo las membresías.
            var socio = await _unitOfWork.Socio.ObtenerDetalleCompletoAsync(id);
            if (socio == null)
                throw new BusinessException("El socio a eliminar no existe.");

            if (socio.SocioMembresias != null && socio.SocioMembresias.Any())
                throw new BusinessException("No se puede eliminar el socio porque tiene historial de membresías registradas. Desactívelo en su lugar.");

            if (socio.Visitas != null && socio.Visitas.Any())
                throw new BusinessException("No se puede eliminar el socio porque tiene visitas registradas. Desactívelo en su lugar.");

            _unitOfWork.Socio.EliminarFisico(socio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> ObtenerSiguienteClaveFormateadaAsync()
        {
            int siguienteNumero = await _unitOfWork.Socio.ObtenerSiguienteNumeroClaveAsync();
            return siguienteNumero.ToString("D4"); // "0001", "0042"
        }

        public async Task<SocioDetalleDto?> ObtenerDetalleCompletoAsync(int socioId)
        {
            var socio = await _unitOfWork.Socio.ObtenerDetalleCompletoAsync(socioId);
            if (socio == null) return null;

            var hoy = DateTime.Today;

            return new SocioDetalleDto
            {
                SocioID = socio.SocioID,
                Clave = socio.Clave,
                Nombre = socio.Nombre,
                Apellidos = socio.Apellido,
                Telefono = socio.Telefono,
                Email = socio.Email,
                Foto = socio.Foto,
                Activo = socio.Activo,

                HistorialMembresias = (socio.SocioMembresias ?? Enumerable.Empty<SocioMembresia>())
                    .OrderByDescending(sm => sm.FechaInicio)
                    .Select(sm => new SocioMembresiaHistorialDto
                    {
                        NombreMembresia = sm.Membresia?.Nombre ?? "N/A",
                        FechaInicio = sm.FechaInicio,
                        FechaFin = sm.FechaFin,
                        Precio = sm.Membresia?.Precio ?? 0,
                        // Una membresía cancelada ya no debe verse como "Vigente"
                        Estado = sm.Estado == EstadoCancelada
                            ? EstadoCancelada
                            : (sm.FechaFin >= hoy ? "Vigente" : "Vencida")
                    }).ToList(),

                HistorialVisitas = (socio.Visitas ?? Enumerable.Empty<Visita>())
                    .OrderByDescending(v => v.CreatedAt)
                    .Select(v => new SocioVisitaHistorialDto
                    {
                        FechaHoraEntrada = v.CreatedAt,
                        TipoAcceso = v.TipoAcceso
                    }).ToList()
            };
        }

        // ───────── Helpers ─────────

        private static void ValidarResultado(FluentValidation.Results.ValidationResult resultado)
        {
            if (resultado.IsValid) return;
            throw new BusinessException(string.Join(" ", resultado.Errors.Select(e => e.ErrorMessage)));
        }

        // Texto opcional: vacío o solo espacios se guarda como null
        private static string? LimpiarOpcional(string? valor)
            => string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();

        private static SocioDto MapearADto(Socio s) => new()
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
        };
    }
}
