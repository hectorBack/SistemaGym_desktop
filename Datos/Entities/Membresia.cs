using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entities
{
    public class Membresia : BaseEntity
    {
        public int MembresiaID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }

        // Nuevos atributos visuales
        public string Tipo { get; set; } = "Mensual"; // "Mensual", "Dias", etc.
        public int Meses { get; set; }
        public int Semanas { get; set; }
        public int Dias { get; set; }

        // Propiedad calculada para saber cuántos días exactos dura la membresía
        public int DuracionDias
        {
            get
            {
                // Puedes ajustar el cálculo de meses (por ejemplo, 30 días por mes o 31)
                return (Meses * 30) + (Semanas * 7) + Dias;
            }
            set { /* Requerido por EF Core si mapea el campo antiguo */ }
        }
    }
}
