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
        private readonly IValidator<GimnasioConfiguracionDto> _gimnasioConfigValidator;
        private readonly IValidator<CorreosConfiguracionDto> _correosConfigValidator;

        // Claves constantes para el Corte de Caja
        public const string CLAVE_EFECTIVO_INICIAL = CajaConstantes.ClaveEfectivoInicial;
        public const string CLAVE_EMAIL_NOTIFICACION = "Corte_EmailNotificacion";

        // Claves constantes para los Datos del Gimnasio
        public const string CLAVE_GYM_NOMBRE = "Gym_Nombre";
        public const string CLAVE_GYM_DOMICILIO = "Gym_Domicilio";
        public const string CLAVE_GYM_TELEFONO = "Gym_Telefono";
        public const string CLAVE_GYM_RFC = "Gym_Rfc";
        public const string CLAVE_GYM_MENSAJE = "Gym_Mensaje";
        public const string CLAVE_GYM_LOGO = "Gym_Logo";

        // Claves constantes para la Configuración de Correos
        public const string CLAVE_CORREO_EMAIL = "Correo_Email";
        public const string CLAVE_CORREO_PASSWORD = "Correo_Password";
        public const string CLAVE_CORREO_RECORDATORIO = "Correo_RecordatorioVencimiento";
        public const string CLAVE_CORREO_FELICITACIONES = "Correo_EnviarFelicitaciones";

        public ConfiguracionService(
            IUnitOfWork unitOfWork,
            IValidator<CorteConfiguracionDto> corteConfigValidator,
            IValidator<GimnasioConfiguracionDto> gimnasioConfigValidator,
            IValidator<CorreosConfiguracionDto> correosConfigValidator)
        {
            _unitOfWork = unitOfWork;
            _corteConfigValidator = corteConfigValidator;
            _gimnasioConfigValidator = gimnasioConfigValidator;
            _correosConfigValidator = correosConfigValidator;
        }

        public async Task<CorteConfiguracionDto> ObtenerConfigCorteCajaAsync()
        {
            var cfgEfectivo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_EFECTIVO_INICIAL);
            var cfgEmail = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_EMAIL_NOTIFICACION);

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

        // 🟢 Implementación para Obtener los Datos del Gimnasio
        public async Task<GimnasioConfiguracionDto> ObtenerConfigGimnasioAsync()
        {
            var cfgNombre = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_GYM_NOMBRE);
            var cfgDomicilio = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_GYM_DOMICILIO);
            var cfgTelefono = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_GYM_TELEFONO);
            var cfgRfc = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_GYM_RFC);
            var cfgMensaje = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_GYM_MENSAJE);
            var cfgLogo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_GYM_LOGO);

            return new GimnasioConfiguracionDto
            {
                Nombre = cfgNombre?.Valor ?? string.Empty,
                Domicilio = cfgDomicilio?.Valor ?? string.Empty,
                Telefono = cfgTelefono?.Valor ?? string.Empty,
                Rfc = cfgRfc?.Valor ?? string.Empty,
                Mensaje = cfgMensaje?.Valor ?? string.Empty,
                Logo = cfgLogo?.Valor ?? string.Empty
            };
        }

        // 🟢 Implementación para Guardar los Datos del Gimnasio
        public async Task GuardarConfigGimnasioAsync(GimnasioConfiguracionDto dto)
        {
            var validationResult = await _gimnasioConfigValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new BusinessException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_GYM_NOMBRE,
                (dto.Nombre ?? string.Empty).Trim(),
                "Nombre comercial del gimnasio");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_GYM_DOMICILIO,
                (dto.Domicilio ?? string.Empty).Trim(),
                "Domicilio fiscal o físico del gimnasio");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_GYM_TELEFONO,
                (dto.Telefono ?? string.Empty).Trim(),
                "Teléfono de contacto principal");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_GYM_RFC,
                (dto.Rfc ?? string.Empty).Trim(),
                "RFC del establecimiento");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_GYM_MENSAJE,
                (dto.Mensaje ?? string.Empty).Trim(),
                "Mensaje de bienvenida para los socios");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_GYM_LOGO,
                (dto.Logo ?? string.Empty).Trim(),
                "Ruta o identificador del logotipo del gimnasio");

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string?> ObtenerValorPorClaveAsync(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave)) return null;

            var config = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(clave);
            return config?.Valor;
        }

        public async Task<CorreosConfiguracionDto> ObtenerConfigCorreosAsync()
        {
            var cfgEmail = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_CORREO_EMAIL);
            var cfgPassword = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_CORREO_PASSWORD);
            var cfgRecordatorio = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_CORREO_RECORDATORIO);
            var cfgFelicitaciones = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_CORREO_FELICITACIONES);

            bool.TryParse(cfgRecordatorio?.Valor, out bool recordatorio);
            bool.TryParse(cfgFelicitaciones?.Valor, out bool felicitaciones);

            return new CorreosConfiguracionDto
            {
                Email = cfgEmail?.Valor ?? string.Empty,
                Password = cfgPassword?.Valor ?? string.Empty,
                EnviarRecordatorioVencimiento = recordatorio,
                EnviarFelicitaciones = felicitaciones
            };
        }

        public async Task GuardarConfigCorreosAsync(CorreosConfiguracionDto dto)
        {
            var validationResult = await _correosConfigValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new BusinessException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_CORREO_EMAIL,
                (dto.Email ?? string.Empty).Trim(),
                "Correo electrónico (Gmail) configurado para envíos");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_CORREO_PASSWORD,
                dto.Password ?? string.Empty,
                "Contraseña o token de aplicación para el correo");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_CORREO_RECORDATORIO,
                dto.EnviarRecordatorioVencimiento ? "True" : "False",
                "Indica si se envían recordatorios automáticos de vencimiento de membresía");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_CORREO_FELICITACIONES,
                dto.EnviarFelicitaciones ? "True" : "False",
                "Indica si se envían felicitaciones automáticas por correo electrónico");

            await _unitOfWork.SaveChangesAsync();
        }  
    }
}
