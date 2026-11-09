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

            // Consulta ligera: ya devuelve solo las visitas activas (excluye las canceladas), sin cargar socio ni membresía.
            var visitas = await _visitaService.ObtenerActivasPorRangoFechasAsync(hoy, hoy.AddDays(1).AddTicks(-1));

            return visitas.Select(v =>
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

        // Solo consulta el logotipo guardado (antes se leían los 6 datos del gimnasio para usar uno)
        public async Task<string> ObtenerLogoGimnasioAsync()
        {
            return await _configuracionService.ObtenerLogoGimnasioAsync();
        }
    }
}
