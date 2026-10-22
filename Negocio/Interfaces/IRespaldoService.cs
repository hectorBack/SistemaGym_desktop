using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IRespaldoService
    {
        Task GenerarRespaldoManualAsync(RespaldoManualDto dto);
        Task RestaurarBaseDatosAsync(RestaurarManualDto dto);
    }
}
