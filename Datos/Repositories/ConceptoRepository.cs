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
            var query = _context.Conceptos.AsQueryable();

            if (!incluirInactivos)
            {
                query = query.Where(c => c.Activo);
            }

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
            _context.Conceptos.Update(concepto);
        }

        public void EliminarFisico(Concepto concepto)
        {
            _context.Conceptos.Remove(concepto);
        }

        public async Task<bool> ExisteNombreAsync(string nombre, int? idExcluir = null)
        {
            var query = _context.Conceptos.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(c => c.ConceptoID != idExcluir.Value);
            }

            return await query.AnyAsync(c => c.Nombre.ToLower() == nombre.ToLower());
        }
    }
}
