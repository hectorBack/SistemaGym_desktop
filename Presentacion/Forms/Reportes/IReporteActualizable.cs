using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms.Reportes
{
    public interface IReporteActualizable
    {
        Task ActualizarAsync();
    }
}
