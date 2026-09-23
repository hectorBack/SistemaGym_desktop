using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> LoginAsync(LoginRequestDto loginDto);
        Task<IEnumerable<UsuarioDto>> ObtenerTodosAsync(bool incluirInactivas = false);
        Task<UsuarioDto?> ObtenerPorIdAsync(int id);
        Task<UsuarioDto> CrearAsync(UsuarioCreateDto dto);
        Task ActualizarAsync(UsuarioUpdateDto dto);
        Task EliminarLogicoAsync(int id);
        Task EliminarFisicoAsync(int id);
    }
}
