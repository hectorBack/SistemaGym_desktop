using Datos.Context;
using Datos.Entities;
using Datos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class ConceptoRepository : IConceptoRepository
    {
        private readonly GimnasioDbContext _context;

        public ConceptoRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Concepto>> ObtenerTodosAsync(bool incluirInactivos = false)
        {
            var query = incluirInactivos
                ? _context.Conceptos.Where(c => c.Estado != "Eliminado")
                : _context.Conceptos.Where(c => c.Activo);

            return await query.ToListAsync();
        }

        public async Task<Concepto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Conceptos.FindAsync(id);
        }

        public async Task AgregarAsync(Concepto concepto)
        {
            await _context.Conceptos.AddAsync(concepto);
        }

        public void Actualizar(Concepto concepto)
        {
            _context.Conceptos.Update(concepto);
        }

        public void EliminarLogico(Concepto concepto)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            concepto.Activo = !concepto.Activo;
            concepto.Estado = concepto.Activo ? "Activo" : "Inactivo";
            _context.Conceptos.Update(concepto);
        }

        public void MarcarComoEliminado(Concepto concepto)
        {
            concepto.Activo = false;
            concepto.Estado = "Eliminado";
            _context.Conceptos.Update(concepto);
        }

        public async Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null)
        {
            // Un concepto eliminado libera su nombre.
            var query = _context.Conceptos.Where(c => c.Estado != "Eliminado");

            if (idExcluir.HasValue)
            {
                query = query.Where(c => c.ConceptoID != idExcluir.Value);
            }

            return await query.AnyAsync(c => c.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<Concepto?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Conceptos.FirstOrDefaultAsync(c => c.Estado != "Eliminado" && c.Nombre.ToLower() == nombre.ToLower());
        }
    }
}
