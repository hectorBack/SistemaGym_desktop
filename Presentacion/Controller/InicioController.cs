using Negocio.Interfaces;
using Negocio.Services;
using Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controller
{
    public class InicioController
    {
        private readonly IVisitaService _visitaService;
        private readonly IConfiguracionService _configuracionService;

        public InicioController(IVisitaService visitaService, IConfiguracionService configuracionService)
        {
            _visitaService = visitaService ?? throw new ArgumentNullException(nameof(visitaService));
            _configuracionService = configuracionService ?? throw new ArgumentNullException(nameof(configuracionService));
        }

        public async Task<IEnumerable<InicioViewModel>> ObtenerVisitantesDelDiaAsync()
        {
            DateTime hoy = DateTime.Today;
            var visitas = await _visitaService.ObtenerPorRangoFechasAsync(hoy, hoy.AddDays(1).AddTicks(-1));

            // 🟢 Filtramos estrictamente solo las visitas que estén activas (excluyendo las canceladas)
            return visitas.Where(v => v.Activo).Select(v =>
            {
                bool esVisitaCasual = string.Equals(v.Clave?.Trim(), "100", StringComparison.OrdinalIgnoreCase) ||
                                      string.Equals(v.TipoAcceso?.Trim(), "Visita Casual", StringComparison.OrdinalIgnoreCase);

                return new InicioViewModel
                {
                    Id = v.Clave ?? v.SocioID?.ToString() ?? "N/A",
                    SocioID = v.SocioID,
                    Nombre = esVisitaCasual ? "Visita" : (v.Nombre ?? string.Empty),
                    Apellido = esVisitaCasual ? string.Empty : (v.Apellido ?? string.Empty),
                    CreatedAt = v.CreatedAt
                };
            }).ToList();
        }

        // Método nuevo para obtener la ruta del logotipo guardado en Configuración de Gimnasio
        public async Task<string> ObtenerLogoGimnasioAsync()
        {
            var configGym = await _configuracionService.ObtenerConfigGimnasioAsync();
            return configGym?.Logo ?? string.Empty;
        }
    }
}
