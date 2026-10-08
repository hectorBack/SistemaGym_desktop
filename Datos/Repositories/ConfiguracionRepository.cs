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
    public class ConfiguracionRepository : IConfiguracionRepository
    {
        private readonly GimnasioDbContext _context;

        public ConfiguracionRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task GuardarOActualizarAsync(string clave, string valor, string? descripcion = null)
        {
            var config = await _context.Set<Configuracion>()
                .FirstOrDefaultAsync(c => c.Clave == clave);

            if (config == null)
            {
                config = new Configuracion
                {
                    Clave = clave,
                    Valor = valor,
                    Descripcion = descripcion,
                    Activo = true
                };
                await _context.Set<Configuracion>().AddAsync(config);
            }
            else
            {
                config.Valor = valor;
                if (!string.IsNullOrEmpty(descripcion)) config.Descripcion = descripcion;
                config.UpdatedAt = DateTime.Now;
                _context.Set<Configuracion>().Update(config);
            }
        }

        public async Task<Configuracion?> ObtenerPorClaveAsync(string clave)
        {
            return await _context.Set<Configuracion>()
                .FirstOrDefaultAsync(c => c.Clave == clave && c.Activo);
        }

        public async Task<IEnumerable<Configuracion>> ObtenerTodasAsync()
        {
            return await _context.Set<Configuracion>()
                .Where(c => c.Activo)
                .ToListAsync();
        }
    }
}
