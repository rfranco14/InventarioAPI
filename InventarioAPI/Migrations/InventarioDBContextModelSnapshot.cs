﻿// <auto-generated />
using System;
using InventarioAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventarioAPI.Migrations
{
    [DbContext(typeof(InventarioDBContext))]
    partial class InventarioDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventarioAPI.Entities.Categoria", b =>
                {
                    b.Property<int>("CodigoCategoria")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.HasKey("CodigoCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Cliente", b =>
                {
                    b.Property<string>("Nit")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion");

                    b.Property<string>("Dpi")
                        .IsRequired();

                    b.Property<string>("Nombre");

                    b.HasKey("Nit");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProveedor");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("NumeroDocumento");

                    b.Property<decimal>("Total");

                    b.HasKey("IdCompra");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("InventarioAPI.Entities.DetalleCompra", b =>
                {
                    b.Property<int>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("CodigoProducto");

                    b.Property<int>("IdCompra");

                    b.Property<decimal>("Precio");

                    b.HasKey("IdDetalle");

                    b.HasIndex("CodigoProducto");

                    b.HasIndex("IdCompra");

                    b.ToTable("DetalleCompras");
                });

            modelBuilder.Entity("InventarioAPI.Entities.DetalleFactura", b =>
                {
                    b.Property<int>("CodigoDetalle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int>("CodigoProducto");

                    b.Property<double>("Descuento");

                    b.Property<int>("NumeroFactura");

                    b.Property<double>("Precio");

                    b.HasKey("CodigoDetalle");

                    b.HasIndex("CodigoProducto");

                    b.HasIndex("NumeroFactura");

                    b.ToTable("DetalleFacturas");
                });

            modelBuilder.Entity("InventarioAPI.Entities.EmailCliente", b =>
                {
                    b.Property<int>("CodigoEmail")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nit");

                    b.HasKey("CodigoEmail");

                    b.HasIndex("Nit");

                    b.ToTable("EmailClientes");
                });

            modelBuilder.Entity("InventarioAPI.Entities.EmailProveedor", b =>
                {
                    b.Property<int>("CodigoEmail")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProveedor");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("CodigoEmail");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("EmailProveedores");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Factura", b =>
                {
                    b.Property<int>("NumeroFactura")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Nit")
                        .IsRequired();

                    b.Property<double>("Total");

                    b.HasKey("NumeroFactura");

                    b.HasIndex("Nit");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Inventario", b =>
                {
                    b.Property<int>("CodigoInventario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProducto");

                    b.Property<int>("Entradas");

                    b.Property<DateTime>("Fecha");

                    b.Property<double>("Precio");

                    b.Property<int>("Salidas");

                    b.Property<string>("TipoRegistro");

                    b.HasKey("CodigoInventario");

                    b.HasIndex("CodigoProducto");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Producto", b =>
                {
                    b.Property<int>("CodigoProducto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoCategoria");

                    b.Property<int>("CodigoEmpaque");

                    b.Property<string>("Descripcion");

                    b.Property<int>("Existencia");

                    b.Property<string>("Imagen");

                    b.Property<decimal>("PrecioPorDocena");

                    b.Property<decimal>("PrecioPorMayor");

                    b.Property<decimal>("PrecioUnitario");

                    b.HasKey("CodigoProducto");

                    b.HasIndex("CodigoCategoria");

                    b.HasIndex("CodigoEmpaque");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Proveedor", b =>
                {
                    b.Property<int>("CodigoProveedor")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactoPrincipal");

                    b.Property<string>("Direccion");

                    b.Property<string>("Nit")
                        .IsRequired();

                    b.Property<string>("PaginaWeb");

                    b.Property<string>("RazonSocial");

                    b.HasKey("CodigoProveedor");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("InventarioAPI.Entities.TelefonoCliente", b =>
                {
                    b.Property<int>("CodigoTelefono")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Nit");

                    b.Property<string>("Numero")
                        .IsRequired();

                    b.HasKey("CodigoTelefono");

                    b.HasIndex("Nit");

                    b.ToTable("TelefonoClientes");
                });

            modelBuilder.Entity("InventarioAPI.Entities.TelefonoProveedor", b =>
                {
                    b.Property<int>("CodigoTelefono")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoProveedor");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Numero")
                        .IsRequired();

                    b.HasKey("CodigoTelefono");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("TelefonoProveedores");
                });

            modelBuilder.Entity("InventarioAPI.Entities.TipoEmpaque", b =>
                {
                    b.Property<int>("CodigoEmpaque")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.HasKey("CodigoEmpaque");

                    b.ToTable("TipoEmpaque");
                });

            modelBuilder.Entity("InventarioAPI.Entities.Compra", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.DetalleCompra", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Producto", "Producto")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventarioAPI.Entities.Compra", "Compra")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.DetalleFactura", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Producto", "Producto")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventarioAPI.Entities.Factura", "Factura")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("NumeroFactura")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.EmailCliente", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Cliente", "Cliente")
                        .WithMany("EmailClientes")
                        .HasForeignKey("Nit");
                });

            modelBuilder.Entity("InventarioAPI.Entities.EmailProveedor", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Proveedor", "Proveedor")
                        .WithMany("EmailProveedores")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.Factura", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("Nit")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.Inventario", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Producto", "Producto")
                        .WithMany("Inventarios")
                        .HasForeignKey("CodigoProducto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.Producto", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CodigoCategoria")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventarioAPI.Entities.TipoEmpaque", "TipoEmpaque")
                        .WithMany("Productos")
                        .HasForeignKey("CodigoEmpaque")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioAPI.Entities.TelefonoCliente", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Cliente", "Cliente")
                        .WithMany("TelefonoClientes")
                        .HasForeignKey("Nit");
                });

            modelBuilder.Entity("InventarioAPI.Entities.TelefonoProveedor", b =>
                {
                    b.HasOne("InventarioAPI.Entities.Proveedor", "Proveedor")
                        .WithMany("TelefonoProveedores")
                        .HasForeignKey("CodigoProveedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
