using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IPagoSocioMembresiaService
    {
        Task<IEnumerable<PagoSocioMembresiaDto>> ObtenerTodasAsync(bool incluirInactivas = false);
        Task<PagoSocioMembresiaDto?> ObtenerPorIdAsync(int id);
        Task<PagoSocioMembresiaDto> CrearAsync(PagoSocioMembresiaCreateDto dto);
        Task ActualizarAsync(PagoSocioMembresiaUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);

        // Métodos específicos para la gestión de pagos/abonos de membresías
        Task<IEnumerable<PagoSocioMembresiaDto>> ObtenerPorSocioMembresiaIdAsync(int socioMembresiaId, bool incluirInactivos = false);
        Task<decimal> ObtenerTotalPagadoPorSocioMembresiaIdAsync(int socioMembresiaId);
    }
}
