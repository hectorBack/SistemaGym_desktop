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
    public class SocioRepository : ISocioRepository
    {
        private readonly GimnasioDbContext _context;

        public SocioRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Socio>> ObtenerTodosAsync(bool incluirInactivos = false, bool incluirFoto = true)
        {
            var query = incluirInactivos
                ? _context.Socios.Where(s => s.Estado != "Eliminado")
                : _context.Socios.Where(s => s.Activo);

            if (incluirFoto)
                return await query.ToListAsync();

            // Para listados: sin la columna Foto (puede ser pesada) y sin rastreo de cambios.
            return await query
                .AsNoTracking()
                .Select(s => new Socio
                {
                    SocioID = s.SocioID,
                    Clave = s.Clave,
                    Nombre = s.Nombre,
                    Apellido = s.Apellido,
                    Telefono = s.Telefono,
                    Email = s.Email,
                    FechaNacimiento = s.FechaNacimiento,
                    Observaciones = s.Observaciones,
                    Activo = s.Activo,
                    Estado = s.Estado,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<Socio?> ObtenerPorIdAsync(int id)
        {
            return await _context.Socios.FindAsync(id);
        }

        public async Task AgregarAsync(Socio socio)
        {
            await _context.Socios.AddAsync(socio);
        }

        public void Actualizar(Socio socio)
        {
            _context.Socios.Update(socio);
        }

        public void EliminarLogico(Socio socio)
        {
            // Cambia el estado al opuesto (Activar/Desactivar)
            socio.Activo = !socio.Activo;
            socio.Estado = socio.Activo ? "Activo" : "Inactivo";
            _context.Socios.Update(socio);
        }

        public void MarcarComoEliminado(Socio socio)
        {
            socio.Activo = false;
            socio.Estado = "Eliminado";
            _context.Socios.Update(socio);
        }

        public async Task<bool> ExisteClaveAsync(string clave, int? idExcluir = null)
        {
            var query = _context.Socios.AsQueryable();

            if (idExcluir.HasValue)
            {
                query = query.Where(s => s.SocioID != idExcluir.Value);
            }

            return await query.AnyAsync(s => s.Clave.ToLower() == clave.ToLower());
        }

        public async Task<Socio?> ObtenerPorClaveAsync(string clave)
        {
            return await _context.Socios
                .FirstOrDefaultAsync(s => s.Estado != "Eliminado" && s.Clave.ToLower() == clave.ToLower());
        }

        public async Task<int> ObtenerSiguienteNumeroClaveAsync()
        {
            // Se toma el mayor número entre las CLAVES reales (activos e inactivos),
            // no el SocioID. Las claves no numéricas se ignoran.
            var claves = await _context.Socios.Select(s => s.Clave).ToListAsync();

            int mayor = claves
                .Select(c => int.TryParse(c?.Trim(), out var n) ? n : 0)
                .DefaultIfEmpty(0)
                .Max();

            return mayor + 1;
        }

        public async Task<bool> TieneMembresiasAsync(int socioId)
        {
            return await _context.Set<SocioMembresia>().AnyAsync(sm => sm.SocioID == socioId);
        }

        public async Task<bool> TieneVisitasAsync(int socioId)
        {
            return await _context.Set<Visita>().AnyAsync(v => v.SocioID == socioId);
        }

        public async Task<Socio?> ObtenerDetalleCompletoAsync(int socioId)
        {
            return await _context.Socios
                .Include(s => s.SocioMembresias)     // Carga la colección SocioMembresias
                    .ThenInclude(sm => sm.Membresia) // Carga los datos del catálogo Membresia (Nombre, Precio, etc.)
                .Include(s => s.Visitas)             // Carga el historial de visitas
                .FirstOrDefaultAsync(s => s.SocioID == socioId);
        }

        public async Task<IEnumerable<Socio>> ObtenerPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Socios
                .Include(s => s.Visitas)
                .Include(s => s.SocioMembresias)
                .Where(m => m.Estado != "Eliminado" && m.CreatedAt >= fechaInicio && m.CreatedAt <= fechaFin)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }
    }
}
