using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    public class CorteDto
    {
        public int CorteID { get; set; }
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string UsuarioNombre => NombreUsuario;

        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }

        public decimal MontoInicial { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public decimal MontoFinal { get; set; }

        public string? Observaciones { get; set; }
        public string Estado { get; set; } = "Abierto";
        public bool Activo { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<MovimientoDto> Movimientos { get; set; } = new List<MovimientoDto>();
    }

    // DTO para la apertura de caja / creación del corte
    public class CorteCreateDto
    {
        public int UsuarioID { get; set; }
        public decimal MontoInicial { get; set; }
        public string? Observaciones { get; set; }
    }

    // DTO para el cierre de caja / actualización del corte
    public class CorteUpdateDto
    {
        public int CorteID { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public decimal MontoFinal { get; set; }
        public string? Observaciones { get; set; }

        /// <summary>
        /// Desde cuándo abarca el corte (el "Fecha inicio" que el usuario vio al confirmar).
        /// Con este dato el servicio verifica los totales contra los movimientos reales y
        /// ajusta la fecha de apertura del corte para que el detalle muestre todo el periodo.
        /// Opcional: si es null, no se verifica (compatibilidad con llamadas anteriores).
        /// </summary>
        public DateTime? PeriodoInicio { get; set; }

        // Ya no se usan: el servicio siempre cierra el corte y no cambia "Activo".
        // Se conservan para no romper llamadas existentes; puedes eliminarlas cuando nada más las use.
        public string Estado { get; set; } = "Cerrado";
        public bool Activo { get; set; } = true;
    }
}
