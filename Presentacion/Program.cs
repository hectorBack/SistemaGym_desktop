using Datos.Context;
using Datos.Repositories;
using Negocio.Services;
using Presentacion.Forms;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Datos.Interfaces;
using FluentValidation;
using Negocio.DTOs;
using Negocio.Interfaces;
using Negocio.Validators;
using Presentacion.Controls;
using Presentacion.Controller;
using Presentacion.Forms.Productos;
using Presentacion.Forms.Ventas;
using Presentacion.Forms.Membresias;
using Presentacion.Forms.Socios;
using Presentacion.Forms.Visitas;
using Presentacion.Forms.Conceptos;
using Presentacion.Forms.Movimientos;
using Presentacion.Forms.Roles;
using Presentacion.Forms.Usuarios;

namespace Presentacion
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            // Iniciar aplicación inyectando dependencias desde el contenedor
            var loginForm = ServiceProvider.GetRequiredService<FrmLogin>();
            Application.Run(loginForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // 1. Base de Datos & Repositorios
            services.AddDbContext<GimnasioDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IMembresiaRepository, MembresiaRepository>();
            services.AddScoped<ISocioRepository, SocioRepository>();
            services.AddScoped<ISocioMembresiaRepository, SocioMembresiaRepository>();
            services.AddScoped<IVisitaRepository, VisitaRepository>();
            services.AddScoped<IPagoSocioMembresiaRepository, PagoSocioMembresiaRepository>();
            services.AddScoped<IConceptoRepository, ConceptoRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // 2. Validadores
            services.AddScoped<IValidator<CategoriaCreateDto>, CategoriaCreateValidator>();
            services.AddScoped<IValidator<CategoriaUpdateDto>, CategoriaUpdateValidator>();
            services.AddScoped<IValidator<ProductoCreateDto>, ProductoCreateValidator>();
            services.AddScoped<IValidator<ProductoUpdateDto>, ProductoUpdateValidator>();
            services.AddScoped<IValidator<VentaCreateDto>, VentaCreateValidator>();
            services.AddScoped<IValidator<MembresiaCreateDto>, MembresiaCreateValidator>();
            services.AddScoped<IValidator<MembresiaUpdateDto>, MembresiaUpdateValidator>();
            services.AddScoped<IValidator<SocioCreateDto>, SocioCreateValidator>();
            services.AddScoped<IValidator<SocioUpdateDto>, SocioUpdateValidator>();
            services.AddScoped<IValidator<AsignarMembresiaDto>, AsignarMembresiaValidator>();
            services.AddScoped<IValidator<VisitaCreateDto>, VisitaCreateValidator>();
            services.AddScoped<IValidator<VisitaUpdateDto>, VisitaUpdateValidator>();
            services.AddScoped<IValidator<PagoSocioMembresiaCreateDto>, PagoSocioMembresiaCreateValidator>();
            services.AddScoped<IValidator<PagoSocioMembresiaUpdateDto>, PagoSocioMembresiaUpdateValidator>();
            services.AddScoped<IValidator<ConceptoCreateDto>, ConceptoCreateValidator>();
            services.AddScoped<IValidator<ConceptoUpdateDto>, ConceptoUpdateValidator>();
            services.AddScoped<IValidator<MovimientoCreateDto>, MovimientoCreateValidator>();
            services.AddScoped<IValidator<MovimientoUpdateDto>, MovimientoUpdateValidator>();
            services.AddScoped<IValidator<RolCreateDto>, RolCreateValidator>();
            services.AddScoped<IValidator<RolUpdateDto>, RolUpdateValidator>();
            services.AddScoped<IValidator<UsuarioCreateDto>, UsuarioCreateValidator>();
            services.AddScoped<IValidator<UsuarioUpdateDto>, UsuarioUpdateValidator>();

            // 3. Servicios de Negocio
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IVentaService, VentaService>();
            services.AddScoped<IMembresiaService, MembresiaService>();
            services.AddScoped<ISocioService, SocioService>();
            services.AddScoped<ISocioMembresiaService, SocioMembresiaService>();
            services.AddScoped<IVisitaService, VisitaService>();
            services.AddScoped<IPagoSocioMembresiaService, PagoSocioMembresiaService>();
            services.AddScoped<IConceptoService, ConceptoService>();
            services.AddScoped<IMovimientoService, MovimientoService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();


            // 4. Controladores de Presentación
            services.AddTransient<CategoriaController>();
            services.AddTransient<ProductoController>();
            services.AddTransient<VentaController>();
            services.AddTransient<MembresiaController>();
            services.AddTransient<SocioController>();
            services.AddTransient<SocioMembresiaController>();
            services.AddTransient<VisitaController>();
            services.AddTransient<PagoSocioMembresiaController>();
            services.AddTransient<ConceptoController>();
            services.AddTransient<MovimientoController>();
            services.AddTransient<RolController>();
            services.AddTransient<UsuarioController>();

            // 5. Formularios
            services.AddTransient<FrmLogin>();
            services.AddTransient<FrmPrincipal>();
            services.AddTransient<FrmCategorias>();
            services.AddTransient<FrmProductos>();
            services.AddTransient<FrmVentas>();
            services.AddTransient<FrmMembresias>();
            services.AddTransient<FrmSocios>();
            services.AddTransient<FrmVisitas>();
            services.AddTransient<FrmRegistroVisita>();
            services.AddTransient<FrmConceptos>();
            services.AddTransient<FrmMovimientos>();
            services.AddTransient<FrmRoles>();
            services.AddTransient<FrmUsuarios>();
           
        }
    }
}
