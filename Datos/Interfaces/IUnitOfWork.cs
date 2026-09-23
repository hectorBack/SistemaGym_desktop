using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        ICategoriaRepository Categorias { get; }
        // Aquí agregaremos repositorios de Socios, Productos, Ventas, etc.
        IProductoRepository Producto { get;  }
        IVentaRepository Venta { get; }
        IMembresiaRepository Membresia { get; }

        ISocioRepository Socio { get; }
        ISocioMembresiaRepository SocioMembresia { get; }

        IVisitaRepository Visita { get; }

        IPagoSocioMembresiaRepository PagoSocioMembresia { get; }

        IConceptoRepository Concepto { get; }

        IMovimientoRepository Movimiento { get; }

        IRolRepository Rol { get; }

        //Task<int> CompleteAsync();
        Task<int> SaveChangesAsync();
    }
}
