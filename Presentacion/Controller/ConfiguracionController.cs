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

        /// <summary>
        /// Obtiene la configuración actual de la pestaña Corte de Caja mapeada al ViewModel.
        /// </summary>
        public async Task<CorteConfiguracionViewModel> ObtenerConfigCorteCajaAsync()
        {
            var dto = await _configuracionService.ObtenerConfigCorteCajaAsync();

            return new CorteConfiguracionViewModel
            {
                EfectivoInicial = dto.EfectivoInicial,
                EmailNotificacion = dto.EmailNotificacion
            };
        }

        /// <summary>
        /// Guarda o actualiza los parámetros de la pestaña Corte de Caja.
        /// </summary>
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

        #region Consultas Generales

        /// <summary>
        /// Obtiene el valor de cualquier clave de configuración del sistema.
        /// </summary>
        public async Task<string?> ObtenerValorPorClaveAsync(string clave)
        {
            return await _configuracionService.ObtenerValorPorClaveAsync(clave);
        }

        #endregion

        // Próximamente se agregarán las demás secciones:
        // #region Pestaña: Datos del Gimnasio
        // #region Pestaña: Configuración de Correos
        // #region Pestaña: Respaldos
    }
}
