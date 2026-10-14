using Datos.Interfaces;
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
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CorteConfiguracionDto> _corteConfigValidator;

        // Claves constantes para evitar errores tipográficos.
        // La clave del fondo vive en CajaConstantes, porque CajaHelper la usa para abrir cortes automáticos.
        public const string CLAVE_EFECTIVO_INICIAL = CajaConstantes.ClaveEfectivoInicial;
        public const string CLAVE_EMAIL_NOTIFICACION = "Corte_EmailNotificacion";

        public ConfiguracionService(
            IUnitOfWork unitOfWork,
            IValidator<CorteConfiguracionDto> corteConfigValidator)
        {
            _unitOfWork = unitOfWork;
            _corteConfigValidator = corteConfigValidator;
        }

        public async Task<CorteConfiguracionDto> ObtenerConfigCorteCajaAsync()
        {
            var cfgEfectivo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_EFECTIVO_INICIAL);
            var cfgEmail = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_EMAIL_NOTIFICACION);

            // El monto se guarda siempre con punto decimal (InvariantCulture), sin depender de la región del equipo.
            decimal.TryParse(cfgEfectivo?.Valor, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal efectivo);

            return new CorteConfiguracionDto
            {
                EfectivoInicial = efectivo,
                EmailNotificacion = cfgEmail?.Valor ?? string.Empty
            };
        }

        public async Task GuardarConfigCorteCajaAsync(CorteConfiguracionDto dto)
        {
            var validationResult = await _corteConfigValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new BusinessException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_EFECTIVO_INICIAL,
                dto.EfectivoInicial.ToString("F2", CultureInfo.InvariantCulture),
                "Monto de efectivo inicial predeterminado para la caja");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_EMAIL_NOTIFICACION,
                (dto.EmailNotificacion ?? string.Empty).Trim(),
                "Correo electrónico donde se enviarán los reportes de cortes de caja");

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string?> ObtenerValorPorClaveAsync(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave)) return null;

            var config = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(clave);
            return config?.Valor;
        }
    }
}
