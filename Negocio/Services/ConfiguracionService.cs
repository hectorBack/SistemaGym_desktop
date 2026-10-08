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
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CorteConfiguracionDto> _corteConfigValidator;

        // Claves constantes para evitar errores tipográficos
        private const string CLAVE_EFECTIVO_INICIAL = "Corte_EfectivoInicial";
        private const string CLAVE_EMAIL_NOTIFICACION = "Corte_EmailNotificacion";

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

            decimal.TryParse(cfgEfectivo?.Valor ?? "0", out decimal efectivo);

            return new CorteConfiguracionDto
            {
                EfectivoInicial = efectivo,
                EmailNotificacion = cfgEmail?.Valor ?? string.Empty
            };
        }

        public async Task GuardarConfigCorteCajaAsync(CorteConfiguracionDto dto)
        {
            // 1. Validar el DTO usando FluentValidation
            var validationResult = await _corteConfigValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMsg = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new BusinessException(errorMsg);
            }

            // 2. Guardar o actualizar las claves en la base de datos
            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_EFECTIVO_INICIAL,
                dto.EfectivoInicial.ToString("F2"),
                "Monto de efectivo inicial predeterminado para la caja");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_EMAIL_NOTIFICACION,
                dto.EmailNotificacion.Trim(),
                "Correo electrónico donde se enviarán los reportes de cortes de caja");

            // 3. Confirmar la transacción
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
