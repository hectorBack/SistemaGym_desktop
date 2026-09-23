using Datos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Context
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext()
        {
        }

        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options) : base(options)
        {
        }

        // Mapeo de Tablas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<SocioMembresia> SocioMembresia { get; set; } 
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; } 
        public DbSet<Visita> Visitas { get; set; }

        public DbSet<PagoSocioMembresia> PagoSocioMembresias { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }

        public DbSet<Movimiento> Movimientos { get; set; }

        public DbSet<Rol> Roles { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Conexión apuntando a bd_gym
                string connectionString = "Server=localhost; Port=3308; Database=bd_gym; Uid=root; Pwd=;";

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo explícito de nombres de tablas para coincidir exactamente con el script SQL
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Socio>().ToTable("Socios");
            modelBuilder.Entity<Membresia>().ToTable("Membresias");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<SocioMembresia>().ToTable("SocioMembresia");
            modelBuilder.Entity<Venta>().ToTable("Ventas");
            modelBuilder.Entity<DetalleVenta>().ToTable("DetalleVentas");
            modelBuilder.Entity<Visita>().ToTable("Visitas");
            modelBuilder.Entity<PagoSocioMembresia>().ToTable("pagos_sociomembresia");
            modelBuilder.Entity<Movimiento>().ToTable("Movimientos");
            modelBuilder.Entity<Rol>().ToTable("Roles");
            

            // Mapeo explícito de nombres de columnas que difieren del estándar de C#
            modelBuilder.Entity<Usuario>()
                .Property(u => u.NombreUsuario)
                .HasColumnName("Usuario");

            // Precisión de campos decimales
            modelBuilder.Entity<Membresia>().Property(m => m.Precio).HasPrecision(10, 2);
            modelBuilder.Entity<Producto>().Property(p => p.Precio).HasPrecision(10, 2);
            modelBuilder.Entity<Venta>().Property(v => v.Total).HasPrecision(10, 2);
            modelBuilder.Entity<DetalleVenta>().Property(d => d.PrecioUnitario).HasPrecision(10, 2);
            modelBuilder.Entity<DetalleVenta>().Property(d => d.Subtotal).HasPrecision(10, 2);
            modelBuilder.Entity<Visita>().Property(v => v.MontoPagado).HasPrecision(10, 2);
            modelBuilder.Entity<PagoSocioMembresia>().Property(p => p.Monto).HasPrecision(10, 2);
            modelBuilder.Entity<Movimiento>().Property(m => m.Total).HasPrecision(10, 2);
        }
    }
}
