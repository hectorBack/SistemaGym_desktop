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
    public class VisitaService : IVisitaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<VisitaCreateDto> _createValidator;
        private readonly IValidator<VisitaUpdateDto> _updateValidator;
        private const string CLAVE_VISITA_CASUAL = "100";

        public VisitaService(
            IUnitOfWork unitOfWork,
            IValidator<VisitaCreateDto> createValidator,
            IValidator<VisitaUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<VisitaDto>> ObtenerTodasAsync()
        {
            var visitas = await _unitOfWork.Visita.ObtenerTodasAsync();

            return visitas.Select(v => new VisitaDto
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                MembresiaID = v.MembresiaID,
                Clave = v.Clave,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Telefono = v.Telefono,
                MontoPagado = v.MontoPagado,
                TipoAcceso = v.TipoAcceso,
                Observaciones = v.Observaciones,
                NombreMembresia = v.Membresia?.Nombre ?? "N/A",
                Activo = v.Activo,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt
            });
        }

        public async Task<IEnumerable<VisitaDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var visitas = await _unitOfWork.Visita.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);

            return visitas.Select(v => new VisitaDto
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                MembresiaID = v.MembresiaID,
                Clave = v.Clave,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Telefono = v.Telefono,
                MontoPagado = v.MontoPagado,
                TipoAcceso = v.TipoAcceso,
                Observaciones = v.Observaciones,
                NombreMembresia = v.Membresia?.Nombre ?? "N/A",
                Activo = v.Activo,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt
            });
        }

        public async Task<VisitaDto?> ObtenerPorIdAsync(int id)
        {
            var visita = await _unitOfWork.Visita.ObtenerPorIdAsync(id);
            if (visita == null) return null;

            return new VisitaDto
            {
                VisitaID = visita.VisitaID,
                SocioID = visita.SocioID,
                MembresiaID = visita.MembresiaID,
                Clave = visita.Clave,
                Nombre = visita.Nombre,
                Apellido = visita.Apellido,
                Telefono = visita.Telefono,
                MontoPagado = visita.MontoPagado,
                TipoAcceso = visita.TipoAcceso,
                Observaciones = visita.Observaciones,
                NombreMembresia = visita.Membresia?.Nombre ?? "N/A",
                Activo = visita.Activo,
                CreatedAt = visita.CreatedAt,
                UpdatedAt = visita.UpdatedAt
            };
        }

        public async Task<IEnumerable<VisitaDto>> ObtenerPorSocioIdAsync(int socioId)
        {
            var visitas = await _unitOfWork.Visita.ObtenerPorSocioIdAsync(socioId);

            return visitas.Select(v => new VisitaDto
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                MembresiaID = v.MembresiaID,
                Clave = v.Clave,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Telefono = v.Telefono,
                MontoPagado = v.MontoPagado,
                TipoAcceso = v.TipoAcceso,
                Observaciones = v.Observaciones,
                NombreMembresia = v.Membresia?.Nombre ?? "N/A",
                Activo = v.Activo,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt
            });
        }

        public async Task<VisitaDto> RegistrarVisitaAsync(VisitaCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            string claveLimpia = dto.Clave.Trim();
            Visita nuevaVisita;

            // CASO 1: Visita Casual (Clave = 100)
            if (claveLimpia == CLAVE_VISITA_CASUAL)
            {
                var membresia = await _unitOfWork.Membresia.ObtenerPorIdAsync(dto.MembresiaID!.Value);
                if (membresia == null || !membresia.Activo)
                {
                    throw new BusinessException("La membresía o pase de visita seleccionado no existe o está inactivo.");
                }

                nuevaVisita = new Visita
                {
                    SocioID = null,
                    MembresiaID = membresia.MembresiaID,
                    Clave = CLAVE_VISITA_CASUAL,
                    Nombre = dto.Nombre!.Trim(),
                    Apellido = dto.Apellido?.Trim(),
                    Telefono = dto.Telefono?.Trim(),
                    MontoPagado = membresia.Precio,
                    TipoAcceso = "Visita Casual",
                    Observaciones = dto.Observaciones?.Trim(),
                    Activo = true
                };
            }
            // CASO 2: Socio Registrado
            else
            {
                var socio = await _unitOfWork.Socio.ObtenerPorClaveAsync(claveLimpia);
                if (socio == null)
                {
                    throw new BusinessException($"No se encontró ningún socio registrado con la clave '{claveLimpia}'.");
                }

                if (!socio.Activo)
                {
                    throw new BusinessException($"El socio '{socio.Nombre} {socio.Apellido}' se encuentra inactivo.");
                }

                var membresiaActiva = await _unitOfWork.SocioMembresia.ObtenerMembresiaActivaPorSocioIdAsync(socio.SocioID);
                if (membresiaActiva == null)
                {
                    throw new BusinessException($"El socio '{socio.Nombre} {socio.Apellido}' no cuenta con una membresía activa.");
                }

                nuevaVisita = new Visita
                {
                    SocioID = socio.SocioID,
                    MembresiaID = membresiaActiva.MembresiaID,
                    Clave = socio.Clave,
                    Nombre = socio.Nombre,
                    Apellido = socio.Apellido,
                    Telefono = socio.Telefono,
                    MontoPagado = 0.00m,
                    TipoAcceso = "Socio",
                    Observaciones = dto.Observaciones?.Trim(),
                    Activo = true
                };
            }

            await _unitOfWork.Visita.AgregarAsync(nuevaVisita);
            await _unitOfWork.SaveChangesAsync();

            // Cargar datos de navegación para armar el DTO de respuesta
            var visitaGuardada = await _unitOfWork.Visita.ObtenerPorIdAsync(nuevaVisita.VisitaID);

            return new VisitaDto
            {
                VisitaID = nuevaVisita.VisitaID,
                SocioID = nuevaVisita.SocioID,
                MembresiaID = nuevaVisita.MembresiaID,
                Clave = nuevaVisita.Clave,
                Nombre = nuevaVisita.Nombre,
                Apellido = nuevaVisita.Apellido,
                Telefono = nuevaVisita.Telefono,
                MontoPagado = nuevaVisita.MontoPagado,
                TipoAcceso = nuevaVisita.TipoAcceso,
                Observaciones = nuevaVisita.Observaciones,
                NombreMembresia = visitaGuardada?.Membresia?.Nombre ?? "N/A",
                Activo = nuevaVisita.Activo,
                CreatedAt = nuevaVisita.CreatedAt,
                UpdatedAt = nuevaVisita.UpdatedAt
            };
        }

        public async Task ActualizarAsync(VisitaUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            var visita = await _unitOfWork.Visita.ObtenerPorIdAsync(dto.VisitaID);
            if (visita == null)
            {
                throw new BusinessException("La visita que intenta actualizar no existe.");
            }

            visita.Nombre = dto.Nombre!.Trim();
            visita.Apellido = dto.Apellido?.Trim();
            visita.Telefono = dto.Telefono?.Trim();
            visita.Observaciones = dto.Observaciones?.Trim();
            visita.Activo = dto.Activo;

            _unitOfWork.Visita.Actualizar(visita);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var visita = await _unitOfWork.Visita.ObtenerPorIdAsync(id);
            if (visita == null)
            {
                throw new BusinessException("La visita a eliminar no existe.");
            }

            _unitOfWork.Visita.EliminarFisico(visita);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<AccesoResultadoDto> ProcesarAccesoRapidoAsync(string clave)
        {
            string claveLimpia = clave?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(claveLimpia))
            {
                return CrearResultadoError("Debe ingresar una clave válida.");
            }

            if (claveLimpia == CLAVE_VISITA_CASUAL)
            {
                return await ProcesarVisitaCasualAsync();
            }

            return await ProcesarAccesoSocioAsync(claveLimpia);
        }

        // =========================================================================
        // MÉTODOS AUXILIARES PRIVADOS
        // =========================================================================

        private async Task<AccesoResultadoDto> ProcesarVisitaCasualAsync()
        {
            var membresias = await _unitOfWork.Membresia.ObtenerTodasAsync();
            var membresiaVisita = membresias.FirstOrDefault(m => m.Activo && m.Nombre.Contains("Visita"))
                                  ?? membresias.FirstOrDefault(m => m.Activo);

            var nuevaVisitaCasual = new Visita
            {
                SocioID = null,
                MembresiaID = membresiaVisita?.MembresiaID,
                Clave = CLAVE_VISITA_CASUAL,
                Nombre = "VISITA",
                Apellido = "CASUAL",
                MontoPagado = membresiaVisita?.Precio ?? 35.00m,
                TipoAcceso = "Visita Casual",
                Observaciones = "Casual",
                Activo = true
            };

            await _unitOfWork.Visita.AgregarAsync(nuevaVisitaCasual);
            await _unitOfWork.SaveChangesAsync();

            return new AccesoResultadoDto
            {
                VisitaID = nuevaVisitaCasual.VisitaID,
                Exitoso = true,
                EsVisitaCasual = true,
                Clave = CLAVE_VISITA_CASUAL,
                NombreCompleto = "VISITA CASUAL",
                NombreMembresia = membresiaVisita?.Nombre ?? "Visita",
                MembresiaVigente = true
            };
        }

        private async Task<AccesoResultadoDto> ProcesarAccesoSocioAsync(string clave)
        {
            var socio = await _unitOfWork.Socio.ObtenerPorClaveAsync(clave);
            if (socio == null)
            {
                return CrearResultadoError($"No existe ningún socio registrado con la clave '{clave}'.");
            }

            if (!socio.Activo)
            {
                return CrearResultadoError($"El socio '{socio.Nombre} {socio.Apellido}' está INACTIVO.");
            }

            // 1. Obtener la membresía activa fresca directamente desde el repositorio
            var membresiaActiva = await _unitOfWork.SocioMembresia.ObtenerMembresiaActivaPorSocioIdAsync
                (socio.SocioID);

            // 2. Calcular los valores usando la membresía activa real obtenida
            decimal precio = membresiaActiva?.Membresia?.Precio ?? 0m;

            // Validamos que los Pagos existan y no sean nulos
            decimal totalPagado = membresiaActiva?.Pagos != null && membresiaActiva.Pagos.Any()
                ? membresiaActiva.Pagos.Sum(p => p.Monto)
                : 0m;

            var visitaRegistrada = await RegistrarVisitaSocioAsync(socio, membresiaActiva?.MembresiaID);
            var asistenciasSemana = await CalcularAsistenciasSemanaAsync(socio.SocioID);

            return new AccesoResultadoDto
            {
                VisitaID = visitaRegistrada.VisitaID,
                Exitoso = true,
                EsVisitaCasual = false,
                SocioID = socio.SocioID,
                Clave = socio.Clave,
                NombreCompleto = $"{socio.Nombre} {socio.Apellido}".Trim(),
                Foto = socio.Foto,
                NombreMembresia = membresiaActiva?.Membresia?.Nombre ?? "Sin Membresía",
                FechaVencimiento = membresiaActiva?.FechaFin,
                MembresiaVigente = membresiaActiva != null && membresiaActiva.FechaFin >= DateTime.Today,
                PrecioMembresia = precio,
                TotalPagado = totalPagado,
                AsistenciasSemana = asistenciasSemana
            };
        }

        private async Task<Visita> RegistrarVisitaSocioAsync(Socio socio, int? membresiaId)
        {
            var nuevaVisita = new Visita
            {
                SocioID = socio.SocioID,
                MembresiaID = membresiaId,
                Clave = socio.Clave,
                Nombre = socio.Nombre,
                Apellido = socio.Apellido,
                Telefono = socio.Telefono,
                MontoPagado = 0.00m,
                TipoAcceso = "Socio",
                Observaciones = "Acceso Rápido",
                Activo = true
            };

            await _unitOfWork.Visita.AgregarAsync(nuevaVisita);
            await _unitOfWork.SaveChangesAsync();

            return nuevaVisita;
        }

        private async Task<Dictionary<DayOfWeek, string>> CalcularAsistenciasSemanaAsync(int socioId)
        {
            var asistencias = new Dictionary<DayOfWeek, string>();
            DateTime hoy = DateTime.Today;
            int offsetLunes = (int)hoy.DayOfWeek - (int)DayOfWeek.Monday;
            if (offsetLunes < 0) offsetLunes += 7;

            DateTime inicioSemana = hoy.AddDays(-offsetLunes);
            DateTime finSemana = inicioSemana.AddDays(7).AddSeconds(-1);

            var accesos = await _unitOfWork.Visita.ObtenerPorRangoFechasAsync(inicioSemana, finSemana);
            var accesosSocio = accesos.Where(v => v.SocioID == socioId).OrderBy(v => v.CreatedAt);

            foreach (var acceso in accesosSocio)
            {
                DayOfWeek dia = acceso.CreatedAt.DayOfWeek;
                if (!asistencias.ContainsKey(dia))
                {
                    asistencias.Add(dia, acceso.CreatedAt.ToString("HH:mm"));
                }
            }

            return asistencias;
        }

        private static AccesoResultadoDto CrearResultadoError(string mensaje)
        {
            return new AccesoResultadoDto
            {
                Exitoso = false,
                MensajeError = mensaje
            };
        }

        public async Task<IEnumerable<VisitaDto>> ObtenerPorSocioYFechasAsync(int socioId, DateTime desde, DateTime hasta)
        {
            // Usar la propiedad de repositorio del Unit of Work
            var visitas = await _unitOfWork.Visita.ObtenerVisitasPorSocioYFechasAsync(socioId, desde, hasta);

            // Mapeo adaptado a las propiedades reales de tu VisitaDto
            return visitas.Select(v => new VisitaDto
            {
                VisitaID = v.VisitaID,
                SocioID = v.SocioID,
                MembresiaID = v.MembresiaID,
                Clave = v.Clave,
                Nombre = v.Nombre,
                Apellido = v.Apellido,
                Telefono = v.Telefono,
                MontoPagado = v.MontoPagado,
                TipoAcceso = v.TipoAcceso,
                Observaciones = v.Observaciones,
                NombreMembresia = v.Membresia?.Nombre ?? "N/A",
                Activo = v.Activo,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt
            });
        }

        public async Task CancelarVisitaAsync(int id, string? motivo = null)
        {
            var visita = await _unitOfWork.Visita.ObtenerPorIdAsync(id);
            if (visita == null)
            {
                throw new BusinessException("La visita a cancelar no existe.");
            }

            if (!visita.Activo)
            {
                throw new BusinessException("La visita ya se encuentra inactiva o cancelada.");
            }

            visita.MontoPagado = 0.00m;
            visita.Activo = false;

            visita.Observaciones = string.IsNullOrWhiteSpace(motivo)
                 ? "Cancelada"
                 : $"Cancelada: {motivo.Trim()}";

            _unitOfWork.Visita.Actualizar(visita);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
