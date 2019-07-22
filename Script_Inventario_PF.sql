create database Inventario
go
use Inventario

GO
/*==============================================================*/
/* Table: Cliente                                               */
/*==============================================================*/
create table Cliente (
   Nit                  varchar(64)          not null	Primary Key,
   Dpi                  varchar(64)          null,
   Nombre               varchar(128)         null,
   Direccion            varchar(128)         null,
)
go

/*==============================================================*/
/* Table: TelefonoCliente                                       */
/*==============================================================*/
create table TelefonoCliente (
   CodigoTelefono       int					 not null	  primary key,
   Numero               varchar(32)          null,
   Descripcion          varchar(128)         null,
   Nit                  varchar(64)          null,
   constraint FK_TelefonoCliente_Cliente foreign key (Nit) references Cliente (Nit)
)
go

/*==============================================================*/
/* Table: EmailCliente                                          */
/*==============================================================*/
create table EmailCliente (
   CodigoEmail          int					 not null	primary key,
   Email                varchar(128)         null,
   Nit                  varchar(64)          null,
   constraint FK_EmailCliente_Cliente foreign key (Nit) references Cliente (Nit)
)
go

/*==============================================================*/
/* Table: Factura                                               */
/*==============================================================*/
create table Factura (
   NumeroFactura        int					 not null primary key identity (1,1),
   Nit                  varchar(64)          null,
   Fecha                date                 null,
   Total                decimal(10,2)        null,
   constraint FK_Factura_Cliente foreign key (Nit) references Cliente (Nit)
)
go

/*==============================================================*/
/* Table: Proveedor                                             */
/*==============================================================*/
create table Proveedor (
   CodigoProveedor      int                  not null		Primary Key identity (1,1),
   Nit                  varchar(64)          null,
   RazonSocial          varchar(128)         null,
   Direccion            varchar(128)         null,
   PaginaWeb            varchar(64)          null,
   ContactoPrincipal    varchar(64)          null,
)
go

/*==============================================================*/
/* Table: Compra                                                */
/*==============================================================*/
create table Compra (
   IdCompra             int					 not null	primary key,
   NumeroDocumento      int	                 null,
   CodigoProveedor      int	                 not null,
   Fecha                date                 null,
   Total                decimal(10,2)        null,
   constraint FK_Compra_Proveedor foreign key (CodigoProveedor) references Proveedor (CodigoProveedor)
)
go

/*==============================================================*/
/* Table: TelefonoProveedor                                     */
/*==============================================================*/
create table TelefonoProveedor (
   CodigoTelefono       int					 not null		primary key,
   Numero               varchar(32)          null,
   Descripcion          varchar(64)          null,
   CodigoProveedor      int		             not null,
   constraint FK_TelefonoProveedor_Proveedor foreign key (CodigoProveedor)  references Proveedor (CodigoProveedor)
)

/*==============================================================*/
/* Table: EmailProveedor                                        */
/*==============================================================*/
create table EmailProveedor (
   CodigoEmail          int					 not null		primary key,
   Email                varchar(64)          null,
   CodigoProveedor      int		             not null,
   constraint FK_EmailProveedor_Proveedor foreign key (CodigoProveedor) references Proveedor (CodigoProveedor)
)
go

/*==============================================================*/
/* Table: Categoria                                             */
/*==============================================================*/
create table Categoria (
   CodigoCategoria      int					 not null	primary key identity (1,1),
   Descripcion          varchar(128)         null,
)
go

/*==============================================================*/
/* Table: TipoEmpaque                                           */
/*==============================================================*/
create table TipoEmpaque (
   CodigoEmpaque        int	                 not null	primary key identity (1,1),
   Descripcion          varchar(128)         null,
)
go

/*==============================================================*/
/* Table: Producto                                              */
/*==============================================================*/
create table Producto (
   CodigoProducto       int					 not null	primary key,
   CodigoCategoria      int			         not null,
   CodigoEmpaque        int		             not null,
   Descripcion          varchar(128)         null,
   PrecioUnitario       decimal(10,2)        null,
   PrecioPorDocena      decimal(10,2)        null,
   PrecioPorMayor       decimal(10,2)        null,
   Existencia           int	                 null,
   Imagen               varchar(128)         null,
   constraint FK_Producto_Categoria foreign key (CodigoCategoria) references Categoria (CodigoCategoria),
   constraint FK_Producto_TipoEmpaque foreign key (CodigoEmpaque) references TipoEmpaque (CodigoEmpaque)
)
go

/*==============================================================*/
/* Table: Inventario                                            */
/*==============================================================*/
create table Inventario (
   CodigoInventario     int		     		 not null	  primary key,
   CodigoProducto       int	                 not null,
   Fecha                date                 null,
   TipoRegistro         varchar(1)           null,
   Precio               decimal(10,2)        null,
   Entradas             int			         null,
   Salidas              int		             null,
   constraint FK_Inventario_Producto foreign key (CodigoProducto) references Producto (CodigoProducto)
)
go

/*==============================================================*/
/* Table: DetalleCompra                                         */
/*==============================================================*/
create table DetalleCompra (
   IdDetalle            int				     not null	  primary key,
   IdCompra             int                  not null,
   CodigoProducto       int                  not null,
   Cantidad             int	                 null,
   Precio               decimal(10,2)        null,
   constraint FK_DetalleCompra_Compra foreign key (IdCompra) references Compra (IdCompra),
   constraint FK_DetalleCompra_Producto foreign key (CodigoProducto) references Producto (CodigoProducto)
)
go

/*==============================================================*/
/* Table: DetalleFactura                                        */
/*==============================================================*/
create table DetalleFactura (
   CodigoDetalle        int				     not null	  primary key,
   NumeroFactura        int                  not null,
   CodigoProducto       int                  not null,
   Cantidad             int	                 null,
   Precio               decimal(10,2)        null,
   Descuento            decimal(10,2)        null,
   constraint FK_DetalleFactura_Factura foreign key (NumeroFactura) references Factura (NumeroFactura),
   constraint FK_DetalleFactura_Producto foreign key (CodigoProducto) references Producto (CodigoProducto)
)



