using Datos.Entities;
using Datos.Interfaces;
using Datos.Repositories;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Interfaces;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class CorteService : ICorteService
    {
        private const string ESTADO_ABIERTO = CajaConstantes.EstadoAbierto;
        private const string ESTADO_CERRADO = CajaConstantes.EstadoCerrado;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CorteCreateDto> _createValidator;
        private readonly IValidator<CorteUpdateDto> _updateValidator;
        private readonly CajaHelper _caja;

        public CorteService(
            IUnitOfWork unitOfWork,
            IValidator<CorteCreateDto> createValidator,
            IValidator<CorteUpdateDto> updateValidator,
            CajaHelper caja)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _caja = caja;
        }

        // ───────────── Consultas ─────────────

        public async Task<IEnumerable<CorteDto>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var cortes = await _unitOfWork.Corte.ObtenerTodosAsync(incluirInactivos);
            return await MapearConTotalesAsync(cortes);
        }

        public async Task<CorteDto?> ObtenerPorIdAsync(int id)
        {
            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(id);
            if (corte == null) return null;

            return (await MapearConTotalesAsync(new[] { corte })).First();
        }

        public async Task<CorteDto?> ObtenerCorteAbiertoPorUsuarioAsync(int usuarioId)
        {
            var corte = await _unitOfWork.Corte.ObtenerCorteAbiertoPorUsuarioAsync(usuarioId);
            if (corte == null) return null;

            return (await MapearConTotalesAsync(new[] { corte })).First();
        }

        public async Task<IEnumerable<CorteDto>> ObtenerPorRangoFechasAsync(DateTime inicio, DateTime fin)
        {
            if (inicio > fin)
                throw new BusinessException("La fecha de inicio no puede ser posterior a la fecha de fin.");

            var cortes = await _unitOfWork.Corte.ObtenerPorRangoFechasAsync(inicio, fin);
            return await MapearConTotalesAsync(cortes);
        }

        /// <summary>
        /// Efectivo que debería haber ahora en la caja:
        ///  - Con un corte abierto: su fondo inicial + ingresos en efectivo − egresos en efectivo desde que se abrió.
        ///  - Sin corte abierto: el fondo configurado (lo que se deja en caja después de un corte).
        /// Antes se sumaba el fondo de la configuración al fondo del corte abierto (se contaba dos veces)
        /// y no se tomaban en cuenta los movimientos del corte.
        /// </summary>
        public async Task<decimal> ObtenerEfectivoEnCajaAsync()
        {
            var abiertos = (await _unitOfWork.Corte.ObtenerAbiertosAsync())
                .OrderBy(c => c.FechaApertura)
                .ToList();

            if (abiertos.Count == 0)
                return await _caja.ObtenerFondoConfiguradoAsync();

            // Con varios cortes abiertos (uno por usuario) la caja es la misma: se cuenta desde el más antiguo.
            var principal = abiertos[0];

            var movimientos = (await _unitOfWork.Movimiento.ObtenerPorRangoFechasAsync(principal.FechaApertura, DateTime.Now))
                .Where(m => m.Activo && EsEfectivo(m))
                .ToList();

            decimal ingresos = movimientos.Where(EsIngreso).Sum(m => m.Total);
            decimal egresos = movimientos.Where(m => !EsIngreso(m)).Sum(m => m.Total);

            return principal.MontoInicial + ingresos - egresos;
        }

        // ───────────── Apertura y cierre ─────────────

        public async Task<CorteDto> AbrirCorteAsync(CorteCreateDto dto)
        {
            await ValidarAsync(_createValidator, dto);

            if (dto.MontoInicial < 0)
                throw new BusinessException("El monto inicial no puede ser negativo.");

            // Validar que el usuario no tenga ya un corte abierto
            if (await _unitOfWork.Corte.TieneCorteAbiertoAsync(dto.UsuarioID))
                throw new BusinessException("El usuario ya tiene un corte de caja abierto actualmente.");

            var nuevoCorte = new Corte
            {
                UsuarioID = dto.UsuarioID,
                FechaApertura = DateTime.Now,
                MontoInicial = dto.MontoInicial,
                TotalIngresos = 0m,
                TotalEgresos = 0m,
                MontoFinal = dto.MontoInicial,
                Observaciones = dto.Observaciones?.Trim(),
                Estado = ESTADO_ABIERTO,
                Activo = true
            };

            await _unitOfWork.Corte.AgregarAsync(nuevoCorte);
            await _unitOfWork.SaveChangesAsync();

            // Se vuelve a leer para que el DTO incluya el nombre del usuario.
            var corteCreado = await _unitOfWork.Corte.ObtenerPorIdAsync(nuevoCorte.CorteID);
            return MapearADto(corteCreado ?? nuevoCorte);
        }

        public async Task CerrarCorteAsync(CorteUpdateDto dto)
        {
            await ValidarAsync(_updateValidator, dto);

            if (dto.TotalIngresos < 0 || dto.TotalEgresos < 0 || dto.MontoFinal < 0)
                throw new BusinessException("Los totales del corte no pueden ser negativos.");

            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(dto.CorteID);
            if (corte == null)
                throw new BusinessException("El corte que intenta cerrar no existe.");

            if (corte.Estado == ESTADO_CERRADO)
                throw new BusinessException("El corte ya se encuentra cerrado.");

            if (!corte.Activo)
                throw new BusinessException("El corte está desactivado y no puede cerrarse.");

            DateTime ahora = DateTime.Now;

            // PeriodoInicio = desde cuándo abarca el corte (lo que el usuario vio en pantalla).
            // Si no llega (llamadas antiguas) se conserva el comportamiento anterior sin verificar.
            if (dto.PeriodoInicio.HasValue)
            {
                DateTime inicio = dto.PeriodoInicio.Value;
                if (inicio > ahora)
                    throw new BusinessException("El inicio del periodo no puede ser posterior al momento del cierre.");

                // Los totales se comparan contra los movimientos reales de la base de datos.
                await VerificarTotalesAsync(inicio, ahora, dto);

                // Si el corte se abrió automáticamente justo antes de cerrarlo, FechaApertura quedaba casi igual
                // a FechaCierre y el detalle no mostraba los movimientos. Se amplía al periodo realmente cortado.
                if (inicio < corte.FechaApertura)
                    corte.FechaApertura = inicio;
            }

            corte.FechaCierre = ahora;
            corte.TotalIngresos = dto.TotalIngresos;
            corte.TotalEgresos = dto.TotalEgresos;
            corte.MontoFinal = dto.MontoFinal;

            // Antes el estado y "Activo" los decidía quien llamaba (dto.Estado / dto.Activo): se podía
            // "cerrar" un corte dejándolo como Abierto, o desactivarlo de paso. Cerrar siempre deja Cerrado y activo.
            corte.Estado = ESTADO_CERRADO;

            // Antes la observación del cierre borraba la de la apertura. Ahora se conservan las dos.
            string? obsCierre = dto.Observaciones?.Trim();
            if (!string.IsNullOrEmpty(obsCierre))
            {
                corte.Observaciones = string.IsNullOrWhiteSpace(corte.Observaciones)
                    ? obsCierre
                    : $"{corte.Observaciones.Trim()} | Cierre: {obsCierre}";
            }

            _unitOfWork.Corte.Actualizar(corte);
            await _unitOfWork.SaveChangesAsync();
        }

        // Recalcula ingresos y egresos del periodo con los mismos criterios que la pantalla del corte
        // (movimientos activos en efectivo; todo lo que no es "Ingreso" cuenta como egreso) y rechaza el cierre si no coinciden.
        // Evita guardar cifras viejas (otro usuario cobró mientras el modal estaba abierto) o alteradas.
        private async Task VerificarTotalesAsync(DateTime inicio, DateTime fin, CorteUpdateDto dto)
        {
            var movimientos = (await _unitOfWork.Movimiento.ObtenerPorRangoFechasAsync(inicio, fin))
                .Where(m => m.Activo && EsEfectivo(m))
                .ToList();

            decimal ingresos = movimientos.Where(EsIngreso).Sum(m => m.Total);
            decimal egresos = movimientos.Where(m => !EsIngreso(m)).Sum(m => m.Total);

            const decimal tolerancia = 0.01m;
            if (Math.Abs(ingresos - dto.TotalIngresos) > tolerancia || Math.Abs(egresos - dto.TotalEgresos) > tolerancia)
            {
                throw new BusinessException(
                    "Los movimientos de caja en efectivo cambiaron mientras se realizaba el corte " +
                    $"(ingresos {ingresos:C2}, egresos {egresos:C2}). Vuelva a consultar e intente de nuevo.");
            }
        }

        // Debe coincidir con TipoMovimiento.EsIngreso de la capa de presentación.
        // Si esa clase es accesible desde Negocio, sustituye este método por ella.
        private static bool EsIngreso(Movimiento m) => CajaConstantes.EsIngreso(m);

        // ───────────── Eliminación ─────────────

        public async Task EliminarLogicoAsync(int id)
        {
            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(id);
            if (corte == null)
                throw new BusinessException("El corte a desactivar no existe.");

            // Desactivar una caja en uso dejaría al usuario cobrando contra un corte "invisible".
            if (corte.Estado == ESTADO_ABIERTO)
                throw new BusinessException("No se puede desactivar un corte abierto. Ciérrelo primero.");

            _unitOfWork.Corte.EliminarLogico(corte);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFisicoAsync(int id)
        {
            var corte = await _unitOfWork.Corte.ObtenerPorIdAsync(id);
            if (corte == null)
                throw new BusinessException("El corte a eliminar no existe.");

            if (corte.Estado == ESTADO_ABIERTO)
                throw new BusinessException("No se puede eliminar un corte abierto. Ciérrelo primero.");

            _unitOfWork.Corte.EliminarFisico(corte);
            await _unitOfWork.SaveChangesAsync();
        }

        // ───────────── Utilidades ─────────────

        private static bool EstaAbierto(Corte c) => c.Estado == ESTADO_ABIERTO && c.FechaCierre == null;

        // Los totales del corte cuentan SOLO movimientos en efectivo (tarjeta, transferencia, etc. no entran a la caja).
        private static bool EsEfectivo(Movimiento m) => CajaConstantes.EsEfectivo(m.FormaPago);

        // Un corte abierto guarda sus totales en 0 hasta cerrarse. Para que el historial no muestre cifras
        // engañosas, a los cortes abiertos se les calculan ingresos, egresos y caja con sus movimientos reales.
        // Solo se modifica el DTO: nunca la entidad, para no guardar estos valores provisionales en la base.
        private async Task<List<CorteDto>> MapearConTotalesAsync(IEnumerable<Corte> cortes)
        {
            var lista = cortes.ToList();
            var abiertos = lista.Where(EstaAbierto).ToList();

            List<Movimiento> movimientos = new();
            if (abiertos.Count > 0)
            {
                // Una sola consulta desde el corte abierto más antiguo, repartida en memoria.
                DateTime desde = abiertos.Min(c => c.FechaApertura);
                movimientos = (await _unitOfWork.Movimiento.ObtenerPorRangoFechasAsync(desde, DateTime.Now))
                    .Where(m => m.Activo && EsEfectivo(m))
                    .ToList();
            }

            return lista
                .Select(c => EstaAbierto(c) ? MapearEnVivo(c, movimientos) : MapearADto(c))
                .ToList();
        }

        private static CorteDto MapearEnVivo(Corte c, List<Movimiento> movimientos)
        {
            var dto = MapearADto(c);

            var propios = movimientos.Where(m => m.CreatedAt >= c.FechaApertura).ToList();
            dto.TotalIngresos = propios.Where(EsIngreso).Sum(m => m.Total);
            dto.TotalEgresos = propios.Where(m => !EsIngreso(m)).Sum(m => m.Total);
            dto.MontoFinal = c.MontoInicial + dto.TotalIngresos - dto.TotalEgresos;

            return dto;
        }

        private static async Task ValidarAsync<T>(IValidator<T> validador, T dto)
        {
            var resultado = await validador.ValidateAsync(dto);
            if (!resultado.IsValid)
                throw new BusinessException(string.Join(" ", resultado.Errors.Select(e => e.ErrorMessage)));
        }

        private static CorteDto MapearADto(Corte c) => new()
        {
            CorteID = c.CorteID,
            UsuarioID = c.UsuarioID,
            NombreUsuario = c.Usuario?.NombreUsuario ?? $"Usuario {c.UsuarioID}",
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
}
