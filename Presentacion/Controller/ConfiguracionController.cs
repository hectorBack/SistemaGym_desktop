using Negocio.DTOs;
using Negocio.Interfaces;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controller
{
    public class ConfiguracionController
    {
        private readonly IConfiguracionService _configuracionService;

        public ConfiguracionController(IConfiguracionService configuracionService)
        {
            _configuracionService = configuracionService;
        }

        #region Pestaña: Corte de Caja

        public async Task<CorteConfiguracionViewModel> ObtenerConfigCorteCajaAsync()
        {
            var dto = await _configuracionService.ObtenerConfigCorteCajaAsync();

            return new CorteConfiguracionViewModel
            {
                EfectivoInicial = dto.EfectivoInicial,
                EmailNotificacion = dto.EmailNotificacion
            };
        }

        public async Task GuardarConfigCorteCajaAsync(CorteConfiguracionViewModel model)
        {
            var dto = new CorteConfiguracionDto
            {
                EfectivoInicial = model.EfectivoInicial,
                EmailNotificacion = model.EmailNotificacion
            };

            await _configuracionService.GuardarConfigCorteCajaAsync(dto);
        }

        #endregion

        #region Pestaña: Datos del Gimnasio

        public async Task<GimnasioConfiguracionViewModel> ObtenerConfigGimnasioAsync()
        {
            var dto = await _configuracionService.ObtenerConfigGimnasioAsync();

            return new GimnasioConfiguracionViewModel
            {
                Nombre = dto.Nombre,
                Domicilio = dto.Domicilio,
                Telefono = dto.Telefono,
                Rfc = dto.Rfc,
                Mensaje = dto.Mensaje,
                Logo = dto.Logo
            };
        }

        public async Task GuardarConfigGimnasioAsync(GimnasioConfiguracionViewModel model)
        {
            var dto = new GimnasioConfiguracionDto
            {
                Nombre = model.Nombre,
                Domicilio = model.Domicilio,
                Telefono = model.Telefono,
                Rfc = model.Rfc,
                Mensaje = model.Mensaje,
                Logo = model.Logo
            };

            await _configuracionService.GuardarConfigGimnasioAsync(dto);
        }

        #endregion

        #region Pestaña: Configuración de Correos

        /// <summary>
        /// Obtiene la configuración actual de la pestaña Configuración de Correos mapeada al ViewModel.
        /// </summary>
        public async Task<CorreoConfiguracionViewModel> ObtenerConfigCorreosAsync()
        {
            var dto = await _configuracionService.ObtenerConfigCorreosAsync();

            return new CorreoConfiguracionViewModel
            {
                Email = dto.Email,
                Password = dto.Password,
                EnviarRecordatorioVencimiento = dto.EnviarRecordatorioVencimiento,
                EnviarFelicitaciones = dto.EnviarFelicitaciones
            };
        }

        /// <summary>
        /// Guarda o actualiza los parámetros de la pestaña Configuración de Correos.
        /// </summary>
        public async Task GuardarConfigCorreosAsync(CorreoConfiguracionViewModel model)
        {
            var dto = new CorreosConfiguracionDto
            {
                Email = model.Email,
                Password = model.Password,
                EnviarRecordatorioVencimiento = model.EnviarRecordatorioVencimiento,
                EnviarFelicitaciones = model.EnviarFelicitaciones
            };

            await _configuracionService.GuardarConfigCorreosAsync(dto);
        }

        #endregion

        #region Consultas Generales

        public async Task<string?> ObtenerValorPorClaveAsync(string clave)
        {
            return await _configuracionService.ObtenerValorPorClaveAsync(clave);
        }

        #endregion
    }
}
