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
    public class RespaldoController
    {
        private readonly IRespaldoService _respaldoService;

        public RespaldoController(IRespaldoService respaldoService)
        {
            _respaldoService = respaldoService ?? throw new ArgumentNullException(nameof(respaldoService));
        }

        public async Task GenerarRespaldoManualAsync(RespaldoViewModel model)
        {
            var dto = new RespaldoManualDto
            {
                RutaDestino = model.RutaDestino
            };

            await _respaldoService.GenerarRespaldoManualAsync(dto);
        }

        // método para manejar la restauración desde la capa de presentación
        public async Task RestaurarBaseDatosAsync(RestaurarViewModel model)
        {
            var dto = new RestaurarManualDto
            {
                RutaArchivo = model.RutaArchivo
            };

            await _respaldoService.RestaurarBaseDatosAsync(dto);
        }
    }
}
