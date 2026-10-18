using Negocio.DTOs;

namespace Negocio.Interfaces
{
    public interface IConfiguracionService
    {
        Task<CorteConfiguracionDto> ObtenerConfigCorteCajaAsync();
        Task GuardarConfigCorteCajaAsync(CorteConfiguracionDto dto);
        Task<string?> ObtenerValorPorClaveAsync(string clave);
        Task<GimnasioConfiguracionDto> ObtenerConfigGimnasioAsync();
        Task GuardarConfigGimnasioAsync(GimnasioConfiguracionDto dto);

        Task<CorreosConfiguracionDto> ObtenerConfigCorreosAsync();
        Task GuardarConfigCorreosAsync(CorreosConfiguracionDto dto);

        Task EnviarCorreoPruebaAsync(string destinatario);
    }
}
