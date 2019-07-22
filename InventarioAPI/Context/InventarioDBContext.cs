using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioAPI.Entities;

namespace InventarioAPI.Context
{
    public class InventarioDBContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<EmailCliente>EmailClientes { get; set; }
        public DbSet<EmailProveedor> EmailProveedores { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TelefonoCliente> TelefonoClientes { get; set; }
        public DbSet<TelefonoProveedor> TelefonoProveedores { get; set; }
        public DbSet<TipoEmpaque> TipoEmpaques { get; set; }

        public InventarioDBContext(DbContextOptions<InventarioDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categorias")
                .HasKey(key => key.CodigoCategoria);

            modelBuilder.Entity<Cliente>().ToTable("Clientes")
                .HasKey(key => key.Nit);

            modelBuilder.Entity<Compra>().ToTable("Compras")
                .HasKey(key => key.IdCompra);

            modelBuilder.Entity<DetalleCompra>().ToTable("DetalleCompras")
                .HasKey(key => key.IdDetalle);

            modelBuilder.Entity<DetalleFactura>().ToTable("DetalleFacturas")
                .HasKey(key => key.CodigoDetalle);

            modelBuilder.Entity<EmailCliente>().ToTable("EmailClientes")
                .HasKey(key => key.CodigoEmail);

            modelBuilder.Entity<EmailProveedor>().ToTable("EmailProveedores")
                .HasKey(key => key.CodigoEmail);

            modelBuilder.Entity<Factura>().ToTable("Facturas")
                .HasKey(key => key.NumeroFactura);

            modelBuilder.Entity<Inventario>().ToTable("Inventarios")
                .HasKey(key => key.CodigoInventario);

            modelBuilder.Entity<Producto>().ToTable("Productos")
                .HasKey(key => key.CodigoProducto);

            modelBuilder.Entity<Proveedor>().ToTable("Proveedores")
                .HasKey(key => key.CodigoProveedor);

            modelBuilder.Entity<TelefonoCliente>().ToTable("TelefonoClientes")
                .HasKey(key => key.CodigoTelefono);

            modelBuilder.Entity<TelefonoProveedor>().ToTable("TelefonoProveedores")
                .HasKey(key => key.CodigoTelefono);

            modelBuilder.Entity<TipoEmpaque>().ToTable("TipoEmpaque")
                .HasKey(key => key.CodigoEmpaque);

            base.OnModelCreating(modelBuilder);
        }
    }
}
