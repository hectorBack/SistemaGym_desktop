using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IConfiguracionService
    {
        Task<CorteConfiguracionDto> ObtenerConfigCorteCajaAsync();
        Task GuardarConfigCorteCajaAsync(CorteConfiguracionDto dto);
        Task<string?> ObtenerValorPorClaveAsync(string clave);
    }
}
