using Datos.Context;
using Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GimnasioDbContext _context;
        private IUsuarioRepository? _usuarios;
        private ICategoriaRepository? _categorias;
        private IProductoRepository? _productos;
        private IVentaRepository? _ventas;
        private IMembresiaRepository? _membresias;
        private ISocioRepository? _socios;
        private ISocioMembresiaRepository _socioMembresias;
        private IVisitaRepository _visitas;
        private IPagoSocioMembresiaRepository _pagoSocioMembresiaRepository;
        private IConceptoRepository _conceptos;
        private IMovimientoRepository _movimientos;
        private IRolRepository _roles;

        public UnitOfWork(GimnasioDbContext context)
        {
            _context = context;
        }

        public IUsuarioRepository Usuarios => _usuarios ??= new UsuarioRepository(_context);

        public ICategoriaRepository Categorias => _categorias ??= new CategoriaRepository(_context);

        public IProductoRepository Producto => _productos ??= new ProductoRepository(_context);

        public IVentaRepository Venta => _ventas ??= new VentaRepository(_context);

        public IMembresiaRepository Membresia => _membresias ??= new MembresiaRepository(_context);

        public ISocioRepository Socio => _socios ??= new SocioRepository(_context);
        public ISocioMembresiaRepository SocioMembresia => _socioMembresias ??= new SocioMembresiaRepository(_context);

        public IVisitaRepository Visita => _visitas ??= new VisitaRepository(_context);

        public IPagoSocioMembresiaRepository PagoSocioMembresia => _pagoSocioMembresiaRepository ??= new PagoSocioMembresiaRepository(_context);
        public IConceptoRepository Concepto => _conceptos ??= new ConceptoRepository(_context);

        public IMovimientoRepository Movimiento => _movimientos ??= new MovimientoRepository(_context);
        public IRolRepository Rol => _roles ??= new RolRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
