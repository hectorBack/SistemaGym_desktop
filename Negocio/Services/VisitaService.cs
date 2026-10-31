using Datos.Entities;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using Presentacion.Helpers;
using System.Globalization;

namespace Negocio.Services
{
    public class VisitaService : IVisitaService
    {
        // ───────────── Constantes (antes eran valores sueltos dentro del código) ─────────────
        private const string CLAVE_VISITA_CASUAL = "100";

        // Si en tu base de datos estos conceptos tienen otro ID, cámbialo SOLO aquí.
        private const int CONCEPTO_VISITA = CajaConstantes.ConceptoVisita;
        private const int CONCEPTO_CANCELACION_VISITA = CajaConstantes.ConceptoCancelacionVisita;

        private const string TIPO_INGRESO = CajaConstantes.TipoIngreso;
        private const string TIPO_EGRESO = CajaConstantes.TipoEgreso;

        private const string ACCESO_VISITA_CASUAL = "Visita Casual";
        private const string ACCESO_SOCIO = "Socio";

        // Clave de la tabla Configuracion.
        private const string CONFIG_MEMBRESIA_VISITA = "MembresiaVisitaID"; // opcional: ID de la membresía que se cobra como visita

        // Evita registrar dos accesos seguidos si la credencial se escanea dos veces. 0 = desactivado.
        private const int MINUTOS_ENTRE_ACCESOS = 2;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<VisitaCreateDto> _createValidator;
        private readonly IValidator<VisitaUpdateDto> _updateValidator;
        private readonly CajaHelper _caja;

        public VisitaService(
            IUnitOfWork unitOfWork,
            IValidator<VisitaCreateDto> createValidator,
            IValidator<VisitaUpdateDto> updateValidator,
            CajaHelper caja)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _caja = caja;
        }

        // ───────────── Consultas ─────────────

        public async Task<IEnumerable<VisitaDto>> ObtenerTodasAsync()
        {
            var visitas = await _unitOfWork.Visita.ObtenerTodasAsync();
            return visitas.Select(v => ADto(v)).ToList();
        }

        public async Task<IEnumerable<VisitaDto>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var visitas = await _unitOfWork.Visita.ObtenerPorRangoFechasAsync(fechaInicio, fechaFin);
            return visitas.Select(v => ADto(v)).ToList();
        }

        public async Task<VisitaDto?> ObtenerPorIdAsync(int id)
        {
            var visita = await _unitOfWork.Visita.ObtenerPorIdAsync(id);
            return visita == null ? null : ADto(visita);
        }

        public async Task<IEnumerable<VisitaDto>> ObtenerPorSocioIdAsync(int socioId)
        {
            var visitas = await _unitOfWork.Visita.ObtenerPorSocioIdAsync(socioId);
            return visitas.Select(v => ADto(v)).ToList();
        }

        public async Task<IEnumerable<VisitaDto>> ObtenerPorSocioYFechasAsync(int socioId, DateTime desde, DateTime hasta)
        {
            var visitas = await _unitOfWork.Visita.ObtenerVisitasPorSocioYFechasAsync(socioId, desde, hasta);
            return visitas.Select(v => ADto(v)).ToList();
        }

        // ───────────── Registro manual ─────────────

        public async Task<VisitaDto> RegistrarVisitaAsync(VisitaCreateDto dto, int? usuarioIdSesion = null)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new BusinessException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));

            string claveLimpia = dto.Clave.Trim();
            Visita nuevaVisita;
            string nombreMembresia;
            decimal montoCobrado = 0m;

            // CASO 1: Visita Casual (Clave = 100)
            if (claveLimpia == CLAVE_VISITA_CASUAL)
            {
                var membresia = await _unitOfWork.Membresia.ObtenerPorIdAsync(dto.MembresiaID!.Value);
                if (membresia == null || !membresia.Activo)
                    throw new BusinessException("La membresía o pase de visita seleccionado no existe o está inactivo.");

                montoCobrado = membresia.Precio;

                // Antes, sin usuario, la visita se guardaba cobrada pero NO entraba a caja.
                if (montoCobrado > 0 && !usuarioIdSesion.HasValue)
                    throw new BusinessException("No se pudo identificar al usuario de la sesión para registrar el cobro en caja.");

                nombreMembresia = membresia.Nombre;
                nuevaVisita = new Visita
                {
                    SocioID = null,
                    MembresiaID = membresia.MembresiaID,
                    Clave = CLAVE_VISITA_CASUAL,
                    Nombre = dto.Nombre!.Trim(),
                    Apellido = dto.Apellido?.Trim(),
                    Telefono = dto.Telefono?.Trim(),
                    MontoPagado = montoCobrado,
                    TipoAcceso = ACCESO_VISITA_CASUAL,
                    Observaciones = dto.Observaciones?.Trim(),
                    Activo = true
                };
            }
            // CASO 2: Socio registrado (mismas reglas que el acceso rápido)
            else
            {
                var socio = await _unitOfWork.Socio.ObtenerPorClaveAsync(claveLimpia);
                if (socio == null)
                    throw new BusinessException($"No se encontró ningún socio registrado con la clave '{claveLimpia}'.");

                var validacion = await ValidarAccesoSocioAsync(socio);
                if (validacion.Error != null)
                    throw new BusinessException(validacion.Error);

                nombreMembresia = validacion.Membresia!.Membresia?.Nombre ?? "N/A";
                nuevaVisita = CrearVisitaSocio(socio, validacion.Membresia.MembresiaID, dto.Observaciones?.Trim());
            }

            await _unitOfWork.Visita.AgregarAsync(nuevaVisita);

            // La visita y su movimiento de caja se guardan JUNTOS: o entran los dos o ninguno.
            if (montoCobrado > 0)
            {
                var nuevoMovimiento = await _caja.RegistrarMovimientoAsync(usuarioIdSesion!.Value, CONCEPTO_VISITA, TIPO_INGRESO, montoCobrado, string.Empty);

                // Se enlaza por navegación: el movimiento aún no tiene ID (se genera al guardar).
                nuevaVisita.Movimiento = nuevoMovimiento;
            }

            await _unitOfWork.SaveChangesAsync();

            return ADto(nuevaVisita, nombreMembresia);
        }

        public async Task ActualizarAsync(VisitaUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new BusinessException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));

            var visita = await _unitOfWork.Visita.ObtenerPorIdAsync(dto.VisitaID);
            if (visita == null)
                throw new BusinessException("La visita que intenta actualizar no existe.");

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
                throw new BusinessException("La visita a eliminar no existe.");

            // Borrar una visita cobrada dejaría su ingreso en caja sin respaldo y el corte no cuadraría.
            if (visita.MontoPagado > 0)
                throw new BusinessException(
                    "Esta visita tiene un cobro registrado en caja y no puede eliminarse. " +
                    "Cancélela para generar la devolución correspondiente.");

            _unitOfWork.Visita.EliminarFisico(visita);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CancelarVisitaAsync(int id, int usuarioId, string? motivo = null)
        {
            var visita = await _unitOfWork.Visita.ObtenerPorIdAsync(id);
            if (visita == null)
                throw new BusinessException("La visita a cancelar no existe.");

            if (!visita.Activo)
                throw new BusinessException("La visita ya se encuentra inactiva o cancelada.");

            decimal montoDevuelto = visita.MontoPagado;
            string motivoLimpio = motivo?.Trim() ?? string.Empty;

            // Se conserva el texto original y el monto devuelto en las observaciones (rastro de auditoría).
            // MontoPagado queda en 0 para que los reportes no cuenten una visita cancelada.
            var partes = new List<string> { string.IsNullOrEmpty(motivoLimpio) ? "Cancelada" : $"Cancelada: {motivoLimpio}" };
            if (montoDevuelto > 0) partes.Add($"devuelto {montoDevuelto:C2}");
            if (!string.IsNullOrWhiteSpace(visita.Observaciones)) partes.Add($"obs. original: {visita.Observaciones.Trim()}");

            visita.Observaciones = string.Join(" | ", partes);
            visita.MontoPagado = 0m;
            visita.Activo = false;
            _unitOfWork.Visita.Actualizar(visita);

            // La devolución siempre queda registrada: en el corte abierto, o sin corte si no hay uno.
            if (montoDevuelto > 0)
            {
                await _caja.RegistrarMovimientoAsync(usuarioId, CONCEPTO_CANCELACION_VISITA, TIPO_EGRESO, montoDevuelto, string.Empty);
            }

            // Cancelación y egreso se guardan juntos.
            await _unitOfWork.SaveChangesAsync();
        }

        // ───────────── Acceso rápido ─────────────

        public async Task<AccesoResultadoDto> ProcesarAccesoRapidoAsync(string clave, int usuarioIdSesion)
        {
            string claveLimpia = clave?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(claveLimpia))
                return CrearResultadoError("Debe ingresar una clave válida.");

            return claveLimpia == CLAVE_VISITA_CASUAL
                ? await ProcesarVisitaCasualAsync(usuarioIdSesion)
                : await ProcesarAccesoSocioAsync(claveLimpia);
        }

        private async Task<AccesoResultadoDto> ProcesarVisitaCasualAsync(int usuarioIdSesion)
        {
            var membresiaVisita = await ObtenerMembresiaDeVisitaAsync();
            if (membresiaVisita == null)
                return CrearResultadoError(
                    "No hay un pase de visita configurado. Cree una membresía con la palabra \"Visita\" en el nombre " +
                    $"o defina la clave '{CONFIG_MEMBRESIA_VISITA}' en la configuración.");

            decimal monto = membresiaVisita.Precio;

            var nuevaVisita = new Visita
            {
                SocioID = null,
                MembresiaID = membresiaVisita.MembresiaID,
                Clave = CLAVE_VISITA_CASUAL,
                Nombre = "VISITA",
                Apellido = "CASUAL",
                MontoPagado = monto,
                TipoAcceso = ACCESO_VISITA_CASUAL,
                Observaciones = "Casual",
                Activo = true
            };

            await _unitOfWork.Visita.AgregarAsync(nuevaVisita);

            if (monto > 0)
            {
                var nuevoMovimiento = await _caja.RegistrarMovimientoAsync(usuarioIdSesion, CONCEPTO_VISITA, TIPO_INGRESO, monto, string.Empty);

                // Enlazamos la visita con el movimiento financiero exacto
                nuevaVisita.Movimiento = nuevoMovimiento;
            }

            // Visita y movimiento se guardan en un solo paso.
            await _unitOfWork.SaveChangesAsync();

            return new AccesoResultadoDto
            {
                VisitaID = nuevaVisita.VisitaID,
                Exitoso = true,
                EsVisitaCasual = true,
                Clave = CLAVE_VISITA_CASUAL,
                NombreCompleto = "VISITA CASUAL",
                NombreMembresia = membresiaVisita.Nombre,
                MembresiaVigente = true
            };
        }

        private async Task<AccesoResultadoDto> ProcesarAccesoSocioAsync(string clave)
        {
            var socio = await _unitOfWork.Socio.ObtenerPorClaveAsync(clave);
            if (socio == null)
                return CrearResultadoError($"No existe ningún socio registrado con la clave '{clave}'.");

            var validacion = await ValidarAccesoSocioAsync(socio);
            if (validacion.Error != null)
                return CrearResultadoError(validacion.Error);

            var membresiaActiva = validacion.Membresia!;

            if (await YaRegistroAccesoRecienteAsync(socio.SocioID))
                return CrearResultadoError($"El socio '{socio.Nombre} {socio.Apellido}' ya registró su acceso hace unos momentos.");

            var visita = CrearVisitaSocio(socio, membresiaActiva.MembresiaID, "Acceso Rápido");
            await _unitOfWork.Visita.AgregarAsync(visita);
            await _unitOfWork.SaveChangesAsync();

            var asistenciasSemana = await CalcularAsistenciasSemanaAsync(socio.SocioID);

            return new AccesoResultadoDto
            {
                VisitaID = visita.VisitaID,
                Exitoso = true,
                EsVisitaCasual = false,
                SocioID = socio.SocioID,
                Clave = socio.Clave,
                NombreCompleto = $"{socio.Nombre} {socio.Apellido}".Trim(),
                Foto = socio.Foto,
                NombreMembresia = membresiaActiva.Membresia?.Nombre ?? "Sin Membresía",
                FechaVencimiento = membresiaActiva.FechaFin,
                MembresiaVigente = true, // si estuviera vencida, ValidarAccesoSocioAsync ya la habría rechazado
                PrecioMembresia = validacion.Precio,
                TotalPagado = validacion.TotalPagado,
                AsistenciasSemana = asistenciasSemana
            };
        }

        // ───────────── Reglas compartidas ─────────────

        /// <summary>Resultado de validar si un socio puede entrar. Si Error != null, el acceso se niega.</summary>
        private sealed record ValidacionAcceso(string? Error, SocioMembresia? Membresia, decimal Precio, decimal TotalPagado);

        // Mismas reglas para el registro manual y para el acceso rápido.
        private async Task<ValidacionAcceso> ValidarAccesoSocioAsync(Socio socio)
        {
            string nombre = $"{socio.Nombre} {socio.Apellido}".Trim();

            if (!socio.Activo)
                return new ValidacionAcceso($"El socio '{nombre}' está INACTIVO.", null, 0m, 0m);

            var membresiaActiva = await _unitOfWork.SocioMembresia.ObtenerMembresiaActivaPorSocioIdAsync(socio.SocioID);
            if (membresiaActiva == null)
                return new ValidacionAcceso($"El socio '{nombre}' no cuenta con una membresía activa.", null, 0m, 0m);

            decimal precio = membresiaActiva.Membresia?.Precio ?? 0m;
            decimal totalPagado = membresiaActiva.Pagos?.Sum(p => p.Monto) ?? 0m;

            if (membresiaActiva.FechaFin < DateTime.Today)
                return new ValidacionAcceso(
                    $"Acceso denegado: La membresía del socio venció el {membresiaActiva.FechaFin:dd/MM/yyyy}.",
                    membresiaActiva, precio, totalPagado);

            return new ValidacionAcceso(null, membresiaActiva, precio, totalPagado);
        }

        // Membresía que se cobra como visita: primero la configurada; si no, una activa cuyo nombre contenga "Visita".
        // Ya NO se cae a "cualquier membresía activa" ni a un precio fijo.
        private async Task<Membresia?> ObtenerMembresiaDeVisitaAsync()
        {
            var config = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CONFIG_MEMBRESIA_VISITA);
            if (config != null && int.TryParse(config.Valor, NumberStyles.Integer, CultureInfo.InvariantCulture, out int id))
            {
                var configurada = await _unitOfWork.Membresia.ObtenerPorIdAsync(id);
                if (configurada != null && configurada.Activo)
                    return configurada;
            }

            var membresias = await _unitOfWork.Membresia.ObtenerTodasAsync();
            return membresias.FirstOrDefault(m => m.Activo &&
                m.Nombre.Contains("Visita", StringComparison.OrdinalIgnoreCase));
        }

        private async Task<bool> YaRegistroAccesoRecienteAsync(int socioId)
        {
            if (MINUTOS_ENTRE_ACCESOS <= 0) return false;

            DateTime ahora = DateTime.Now;
            var recientes = await _unitOfWork.Visita.ObtenerVisitasPorSocioYFechasAsync(
                socioId, ahora.AddMinutes(-MINUTOS_ENTRE_ACCESOS), ahora);

            return recientes.Any(v => v.Activo);
        }

        private async Task<Dictionary<DayOfWeek, string>> CalcularAsistenciasSemanaAsync(int socioId)
        {
            var asistencias = new Dictionary<DayOfWeek, string>();

            DateTime hoy = DateTime.Today;
            int offsetLunes = ((int)hoy.DayOfWeek + 6) % 7; // lunes = 0 ... domingo = 6
            DateTime inicioSemana = hoy.AddDays(-offsetLunes);
            DateTime finSemana = inicioSemana.AddDays(7).AddTicks(-1);

            // Antes se traían las visitas de TODOS los socios de la semana y se filtraba en memoria.
            var accesos = await _unitOfWork.Visita.ObtenerVisitasPorSocioYFechasAsync(socioId, inicioSemana, finSemana);

            // Las visitas canceladas no cuentan como asistencia.
            foreach (var acceso in accesos.Where(v => v.Activo).OrderBy(v => v.CreatedAt))
            {
                DayOfWeek dia = acceso.CreatedAt.DayOfWeek;
                if (!asistencias.ContainsKey(dia))
                    asistencias.Add(dia, acceso.CreatedAt.ToString("hh:mm tt"));
            }

            return asistencias;
        }

        // ───────────── Utilidades ─────────────

        private static Visita CrearVisitaSocio(Socio socio, int? membresiaId, string? observaciones) => new()
        {
            SocioID = socio.SocioID,
            MembresiaID = membresiaId,
            Clave = socio.Clave,
            Nombre = socio.Nombre,
            Apellido = socio.Apellido,
            Telefono = socio.Telefono,
            MontoPagado = 0m,
            TipoAcceso = ACCESO_SOCIO,
            Observaciones = observaciones,
            Activo = true
        };

        // Único lugar donde se arma el DTO (antes estaba copiado seis veces).
        private static VisitaDto ADto(Visita v, string? nombreMembresia = null) => new()
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
            NombreMembresia = nombreMembresia ?? v.Membresia?.Nombre ?? "N/A",
            Activo = v.Activo,
            CreatedAt = v.CreatedAt,
            UpdatedAt = v.UpdatedAt
        };

        private static AccesoResultadoDto CrearResultadoError(string mensaje) => new()
        {
            Exitoso = false,
            MensajeError = mensaje
        };
    }

}
