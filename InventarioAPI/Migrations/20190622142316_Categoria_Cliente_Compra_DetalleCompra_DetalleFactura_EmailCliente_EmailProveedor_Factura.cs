using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventarioAPI.Migrations
{
    public partial class Categoria_Cliente_Compra_DetalleCompra_DetalleFactura_EmailCliente_EmailProveedor_Factura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CodigoCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CodigoCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Nit = table.Column<string>(nullable: false),
                    Dpi = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Nit);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    CodigoProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<string>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    PaginaWeb = table.Column<string>(nullable: true),
                    ContactoPrincipal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.CodigoProveedor);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpaque",
                columns: table => new
                {
                    CodigoEmpaque = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpaque", x => x.CodigoEmpaque);
                });

            migrationBuilder.CreateTable(
                name: "EmailClientes",
                columns: table => new
                {
                    CodigoEmail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Nit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailClientes", x => x.CodigoEmail);
                    table.ForeignKey(
                        name: "FK_EmailClientes_Clientes_Nit",
                        column: x => x.Nit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    NumeroFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.NumeroFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_Nit",
                        column: x => x.Nit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoClientes",
                columns: table => new
                {
                    CodigoTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Nit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoClientes", x => x.CodigoTelefono);
                    table.ForeignKey(
                        name: "FK_TelefonoClientes_Clientes_Nit",
                        column: x => x.Nit,
                        principalTable: "Clientes",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroDocumento = table.Column<int>(nullable: false),
                    CodigoProveedor = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_CodigoProveedor",
                        column: x => x.CodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailProveedores",
                columns: table => new
                {
                    CodigoEmail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    CodigoProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailProveedores", x => x.CodigoEmail);
                    table.ForeignKey(
                        name: "FK_EmailProveedores_Proveedores_CodigoProveedor",
                        column: x => x.CodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoProveedores",
                columns: table => new
                {
                    CodigoTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    CodigoProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoProveedores", x => x.CodigoTelefono);
                    table.ForeignKey(
                        name: "FK_TelefonoProveedores_Proveedores_CodigoProveedor",
                        column: x => x.CodigoProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoCategoria = table.Column<int>(nullable: false),
                    CodigoEmpaque = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    PrecioUnitario = table.Column<decimal>(nullable: false),
                    PrecioPorDocena = table.Column<decimal>(nullable: false),
                    PrecioPorMayor = table.Column<decimal>(nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CodigoCategoria",
                        column: x => x.CodigoCategoria,
                        principalTable: "Categorias",
                        principalColumn: "CodigoCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_TipoEmpaque_CodigoEmpaque",
                        column: x => x.CodigoEmpaque,
                        principalTable: "TipoEmpaque",
                        principalColumn: "CodigoEmpaque",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompras",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCompra = table.Column<int>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompras", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleCompras_Productos_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompras_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturas",
                columns: table => new
                {
                    CodigoDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroFactura = table.Column<int>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Descuento = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturas", x => x.CodigoDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Productos_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Facturas_NumeroFactura",
                        column: x => x.NumeroFactura,
                        principalTable: "Facturas",
                        principalColumn: "NumeroFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    CodigoInventario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoRegistro = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    Entradas = table.Column<int>(nullable: false),
                    Salidas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.CodigoInventario);
                    table.ForeignKey(
                        name: "FK_Inventarios_Productos_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CodigoProveedor",
                table: "Compras",
                column: "CodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_CodigoProducto",
                table: "DetalleCompras",
                column: "CodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_IdCompra",
                table: "DetalleCompras",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_CodigoProducto",
                table: "DetalleFacturas",
                column: "CodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_NumeroFactura",
                table: "DetalleFacturas",
                column: "NumeroFactura");

            migrationBuilder.CreateIndex(
                name: "IX_EmailClientes_Nit",
                table: "EmailClientes",
                column: "Nit");

            migrationBuilder.CreateIndex(
                name: "IX_EmailProveedores_CodigoProveedor",
                table: "EmailProveedores",
                column: "CodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Nit",
                table: "Facturas",
                column: "Nit");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_CodigoProducto",
                table: "Inventarios",
                column: "CodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CodigoCategoria",
                table: "Productos",
                column: "CodigoCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CodigoEmpaque",
                table: "Productos",
                column: "CodigoEmpaque");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoClientes_Nit",
                table: "TelefonoClientes",
                column: "Nit");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoProveedores_CodigoProveedor",
                table: "TelefonoProveedores",
                column: "CodigoProveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCompras");

            migrationBuilder.DropTable(
                name: "DetalleFacturas");

            migrationBuilder.DropTable(
                name: "EmailClientes");

            migrationBuilder.DropTable(
                name: "EmailProveedores");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "TelefonoClientes");

            migrationBuilder.DropTable(
                name: "TelefonoProveedores");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "TipoEmpaque");
        }
    }
}
