using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventarioAPI.Context;
using InventarioAPI.Entities;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InventarioAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Options =>
            {
                Options.CreateMap<CategoriaCreacionDTO, Categoria>();
                Options.CreateMap<ClienteCreacionDTO, Cliente>();
                Options.CreateMap<CompraCreacionDTO, Compra>();
                Options.CreateMap<DetalleCompraDTO, DetalleCompra>();
                Options.CreateMap<DetalleFacturaCreacionDTO, DetalleFactura>();
                Options.CreateMap<EmailClienteCreacionDTO, EmailCliente>();
                Options.CreateMap<EmailProveedorCreacionDTO, EmailProveedor>();
                Options.CreateMap<FacturaCreacionDTO, Factura>();
                Options.CreateMap<InventarioCreacionDTO, Inventario>();
                Options.CreateMap<ProductoCreacionDTO, Producto>();
                Options.CreateMap<ProveedorCreacionDTO, Proveedor>();
                Options.CreateMap<TelefonoClienteCreacionDTO, TelefonoCliente>();
                Options.CreateMap<TelefonoProveedorCreacionDTO, TelefonoProveedor>();
                Options.CreateMap<TipoEmpaqueCreacionDTO, TipoEmpaque>();
            });


            services.AddDbContext<InventarioDBContext>(Options => 
                Options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
