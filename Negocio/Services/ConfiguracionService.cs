using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Exceptions;
using Negocio.Helpers;
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
        private readonly IValidator<RespaldosConfiguracionDto> _respaldosConfigValidator;
        private readonly IValidator<MasConfiguracionesDto> _masConfigValidator;
        private readonly IValidator<TicketConfiguracionDto> _ticketConfigValidator;
        private readonly IEmailService _emailService;

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

        // Claves constantes para la Configuracion de Respaldos
        public const string CLAVE_RESPALDO_RUTA = "Respaldo_RutaDestino";

        // Claves constantes para Mas Configuraciones
        public const string CLAVE_MAS_MONEDA = "Mas_Moneda";
        public const string CLAVE_MAS_ENVIAR_PAGO_POR_CORREO = "Mas_EnviarPagoPorCorreo";

        // Claves constantes para la configuración del Ticket
        public const string CLAVE_TICKET_IMPRESORA = "Ticket_HabilitarImpresora";
        public const string CLAVE_TICKET_TEXTO_INFERIOR = "Ticket_TextoInferior";
        public const string CLAVE_TICKET_ANCHO = "Ticket_Ancho";
        public const string CLAVE_TICKET_ANCHO_IMAGEN = "Ticket_AnchoImagen";
        public const string CLAVE_TICKET_FUENTE = "Ticket_Fuente";
        public const string CLAVE_TICKET_TAMANO_TEXTO = "Ticket_TamanoTexto";
        public const string CLAVE_TICKET_TAMANO_RENGLON = "Ticket_TamanoRenglon";
        public const string CLAVE_TICKET_TAMANO_TEXTO_ENC = "Ticket_TamanoTextoEncabezado";
        public const string CLAVE_TICKET_TAMANO_RENGLON_ENC = "Ticket_TamanoRenglonEncabezado";
        public const string CLAVE_TICKET_ENTRE_SECCIONES = "Ticket_TamanoEntreSecciones";

        public ConfiguracionService(
            IUnitOfWork unitOfWork,
            IValidator<CorteConfiguracionDto> corteConfigValidator,
            IValidator<GimnasioConfiguracionDto> gimnasioConfigValidator,
            IValidator<CorreosConfiguracionDto> correosConfigValidator,
            IValidator<RespaldosConfiguracionDto> respaldosConfigValidator,
            IValidator<MasConfiguracionesDto> masConfigValidator,
            IValidator<TicketConfiguracionDto> ticketConfigValidator,
            IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _corteConfigValidator = corteConfigValidator;
            _gimnasioConfigValidator = gimnasioConfigValidator;
            _correosConfigValidator = correosConfigValidator;
            _respaldosConfigValidator = respaldosConfigValidator;
            _masConfigValidator = masConfigValidator;
            _ticketConfigValidator = ticketConfigValidator;
            _emailService = emailService;
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

        // Implementación para Obtener los Datos del Gimnasio
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

        // Implementación para Guardar los Datos del Gimnasio
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
                Password = SecretoHelper.Desproteger(cfgPassword?.Valor),
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
                SecretoHelper.Proteger(dto.Password), // se guarda cifrada
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

        public async Task EnviarCorreoPruebaAsync(string destinatario)
        {
            if (string.IsNullOrWhiteSpace(destinatario))
            {
                throw new BusinessException("Debe ingresar y guardar un correo electrónico válido antes de realizar una prueba.");
            }

            string asunto = "Prueba de Configuración - Sistema de Gimnasio";
            string mensaje = "<h3>¡Prueba de correo exitosa!</h3><p>Si estás leyendo este mensaje, tu configuración de Gmail y la contraseña de aplicación funcionan correctamente en el sistema de gimnasio.</p>";

            await _emailService.EnviarCorreoAsync(destinatario, asunto, mensaje);
        }

        // Implementación para Obtener la Configuración de Respaldos
        public async Task<RespaldosConfiguracionDto> ObtenerConfigRespaldosAsync()
        {
            var cfgRuta = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_RESPALDO_RUTA);

            return new RespaldosConfiguracionDto
            {
                RutaRespaldo = cfgRuta?.Valor ?? string.Empty
            };
        }


        // Implementación para Guardar la Configuración de Respaldos
        public async Task GuardarConfigRespaldosAsync(RespaldosConfiguracionDto dto)
        {
            var validationResult = await _respaldosConfigValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new BusinessException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_RESPALDO_RUTA,
                (dto.RutaRespaldo ?? string.Empty).Trim(),
                "Ruta o directorio seleccionado para almacenar los respaldos de la base de datos");

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<MasConfiguracionesDto> ObtenerConfigMasConfiguracionesAsync()
        {
            var cfgMoneda = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_MAS_MONEDA);
            var cfgEnviarPago = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_MAS_ENVIAR_PAGO_POR_CORREO);

            bool.TryParse(cfgEnviarPago?.Valor, out bool enviarPagoPorCorreo);

            return new MasConfiguracionesDto
            {
                Moneda = cfgMoneda?.Valor ?? "MXN",
                EnviarPagoPorCorreo = enviarPagoPorCorreo
            };
        }

        public async Task GuardarConfigMasConfiguracionesAsync(MasConfiguracionesDto dto)
        {
            var validationResult = await _masConfigValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new BusinessException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_MAS_MONEDA,
                (dto.Moneda ?? string.Empty).Trim(),
                "Moneda utilizada por el sistema para mostrar montos y realizar cobros");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_MAS_ENVIAR_PAGO_POR_CORREO,
                dto.EnviarPagoPorCorreo ? "True" : "False",
                "Indica si se envía el comprobante o recibo de pago por correo electrónico");

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> ObtenerSimboloMonedaAsync()
        {
            var valor = await ObtenerValorPorClaveAsync(CLAVE_MAS_MONEDA);

            return string.IsNullOrWhiteSpace(valor)
                ? "MXN"
                : valor.Trim();
        }

        // Pestaña Ticket: lo que no esté guardado todavía toma los valores predeterminados del DTO.
        public async Task<TicketConfiguracionDto> ObtenerConfigTicketAsync()
        {
            var dto = new TicketConfiguracionDto();

            bool.TryParse(await ObtenerValorPorClaveAsync(CLAVE_TICKET_IMPRESORA), out bool impresora);
            dto.HabilitarImpresora = impresora;

            dto.TextoInferior = await ObtenerValorPorClaveAsync(CLAVE_TICKET_TEXTO_INFERIOR) ?? string.Empty;

            string? fuente = await ObtenerValorPorClaveAsync(CLAVE_TICKET_FUENTE);
            if (!string.IsNullOrWhiteSpace(fuente)) dto.NombreFuente = fuente.Trim();

            dto.AnchoTicket = await LeerEnteroAsync(CLAVE_TICKET_ANCHO, dto.AnchoTicket);
            dto.AnchoImagenPorcentaje = await LeerEnteroAsync(CLAVE_TICKET_ANCHO_IMAGEN, dto.AnchoImagenPorcentaje);
            dto.TamanoTexto = await LeerEnteroAsync(CLAVE_TICKET_TAMANO_TEXTO, dto.TamanoTexto);
            dto.TamanoRenglon = await LeerEnteroAsync(CLAVE_TICKET_TAMANO_RENGLON, dto.TamanoRenglon);
            dto.TamanoTextoEncabezado = await LeerEnteroAsync(CLAVE_TICKET_TAMANO_TEXTO_ENC, dto.TamanoTextoEncabezado);
            dto.TamanoRenglonEncabezado = await LeerEnteroAsync(CLAVE_TICKET_TAMANO_RENGLON_ENC, dto.TamanoRenglonEncabezado);
            dto.TamanoEntreSecciones = await LeerEnteroAsync(CLAVE_TICKET_ENTRE_SECCIONES, dto.TamanoEntreSecciones);

            return dto;
        }

        public async Task GuardarConfigTicketAsync(TicketConfiguracionDto dto)
        {
            var validationResult = await _ticketConfigValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new BusinessException(string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_IMPRESORA,
                dto.HabilitarImpresora ? "True" : "False",
                "Indica si la impresora de tickets está habilitada");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_TEXTO_INFERIOR,
                (dto.TextoInferior ?? string.Empty).Trim(),
                "Texto que aparece al final del ticket");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_ANCHO,
                dto.AnchoTicket.ToString(CultureInfo.InvariantCulture),
                "Ancho del ticket en milímetros");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_ANCHO_IMAGEN,
                dto.AnchoImagenPorcentaje.ToString(CultureInfo.InvariantCulture),
                "Porcentaje del ancho del ticket que ocupa el logotipo");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_FUENTE,
                dto.NombreFuente.Trim(),
                "Nombre de la fuente del ticket");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_TAMANO_TEXTO,
                dto.TamanoTexto.ToString(CultureInfo.InvariantCulture),
                "Tamaño del texto del ticket");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_TAMANO_RENGLON,
                dto.TamanoRenglon.ToString(CultureInfo.InvariantCulture),
                "Alto de cada renglón del ticket");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_TAMANO_TEXTO_ENC,
                dto.TamanoTextoEncabezado.ToString(CultureInfo.InvariantCulture),
                "Tamaño del texto del encabezado del ticket");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_TAMANO_RENGLON_ENC,
                dto.TamanoRenglonEncabezado.ToString(CultureInfo.InvariantCulture),
                "Alto de cada renglón del encabezado del ticket");

            await _unitOfWork.Configuracion.GuardarOActualizarAsync(
                CLAVE_TICKET_ENTRE_SECCIONES,
                dto.TamanoEntreSecciones.ToString(CultureInfo.InvariantCulture),
                "Espacio entre las secciones del ticket");

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<int> LeerEnteroAsync(string clave, int predeterminado)
        {
            var valor = await ObtenerValorPorClaveAsync(clave);

            return int.TryParse(valor, NumberStyles.Integer, CultureInfo.InvariantCulture, out int numero)
                ? numero
                : predeterminado;
        }

        public async Task<string> ObtenerLogoGimnasioAsync()
        {
            var cfgLogo = await _unitOfWork.Configuracion.ObtenerPorClaveAsync(CLAVE_GYM_LOGO);
            return cfgLogo?.Valor ?? string.Empty;
        }
    }
}
