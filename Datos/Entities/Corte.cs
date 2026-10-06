using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Corte : BaseEntity
    {
        public int CorteID { get; set; }

        // Relación con Usuario
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;

        public DateTime FechaApertura { get; set; } = DateTime.Now;
        public DateTime? FechaCierre { get; set; }

        public decimal MontoInicial { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public decimal MontoFinal { get; set; }

        public string? Observaciones { get; set; }

        /// <summary>
        /// Indica si la caja está 'Abierto' o 'Cerrado'
        /// </summary>
        public string Estado { get; set; } = "Abierto";
    }
}
