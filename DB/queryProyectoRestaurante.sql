--Alexander Fernandez Quesada, 1-1133-0996
--Daniel Céspedes Ávila, 2-0735-0628
-- Creacion de Base de Datos "Proyecto ASPX Restaurante"
CREATE DATABASE [proyecto_Restaurante] 
ON  PRIMARY 
	( NAME = 'proyectoName', 
  	FILENAME = 'C:\DB\proyecto.mdf' , 
    SIZE = 10MB , 
   	MAXSIZE = 20MB, 
	FILEGROWTH = 5MB )
 LOG ON 
	( NAME = 'proyectoLog', 
   	FILENAME = 'C:\DB\proyecto.ldf' , 
    SIZE = 8MB , 
    MAXSIZE = 10MB , 
 	FILEGROWTH = 10%)
GO
Use proyecto_Restaurante


--Creacion de tablas 

CREATE TABLE restaurante
(id int not null identity,
nombre varchar(60) not null,
direccion varchar(150) not null,
telefono varchar(50) not null,
logo varchar(60) not null,
)

CREATE TABLE rol 
(id int not null identity,
descripcion varchar(50) not null,
)

CREATE TABLE usuario
(id varchar(60) not null,
idRol int not null,
nombre varchar(60) not null,
direccion varchar(150) not null,
correo varchar(50) not null,
telefono varchar(50) not null,
estado binary not null,
)

CREATE TABLE tipoProducto
(id int not null identity,
descripcion varchar(50) not null,
estado binary not null,
)

CREATE TABLE producto
(id int not null identity,
idTipoProducto int not null,
nombre varchar(60) not null,
precio float not null,
imagen varchar(50) not null,
estado binary not null,
)

CREATE TABLE productoRestaurante
(idProducto int not null,
idRestaurante int not null,
)

CREATE TABLE restauranteUsuario
(idUsuario varchar(60) not null,
idRestaurante int not null,
)

CREATE TABLE estadoMesa
(id int not null identity,
descripcion varchar(50) not null,
)

CREATE TABLE mesa
(id int not null identity,
idEstadoMesa int not null,
)

CREATE TABLE estadoPedido
(id int not null identity,
descripcion varchar(50) not null,
)

CREATE TABLE tipoPago
(id int not null identity,
descripcion varchar(50) not null,
)

CREATE TABLE EncabezadoPedido
(id int not null identity,
idMesa int not null,
idUsuario varchar(60) not null,
idEstadoPedido int not null,
)

CREATE TABLE detallePedido
(id int not null identity,
idEncabezadoPedido int not null,
idProducto int not null,
cantidad int not null,
precio float not null,
comentario varchar(100) not null,
)

CREATE TABLE EncabezadoFactura
(id int not null identity,
idEncabezadoPedido int not null,
idRestaurante int not null,
idUsuario varchar(60) not null,
nombreCliente varchar(60) not null,
fecha datetime not null,
idTipoPago int not null,
)

/*CREATE TABLE detalleFactura
(id int not null identity,
idEncabezadoFactura int not null,
idProducto int not null,
cantidad int not null,
precio float not null,
)*/

--Adicion de los Primary Key por medio del alter table
alter table  restaurante add Primary key (id)
alter table rol add Primary key (id)
alter table usuario add Primary key (id)
alter table tipoProducto add Primary key (id)
alter table producto add Primary key (id)
alter table productoRestaurante add Primary key (idProducto, idRestaurante)
alter table restauranteUsuario add Primary key (idRestaurante, idUsuario)
alter table estadoMesa add Primary key (id)
alter table mesa add Primary key (id)
alter table estadoPedido add Primary key (id)
alter table tipoPago add Primary key (id)
alter table EncabezadoPedido add Primary key (id)
alter table detallePedido add Primary key (id)
alter table EncabezadoFactura add Primary key (id)
--alter table detalleFactura add Primary key (id)


--Adicion de los Foreign key por medio del alter table
alter table producto add CONSTRAINT FK_Producto_TipoProducto FOREIGN key (idTipoProducto) references tipoProducto(id);
alter table usuario add CONSTRAINT FK_Usuario_Rol FOREIGN key (idRol) references rol(id);
alter table restauranteUsuario add CONSTRAINT FK_RestauranteUsuario_Usuario FOREIGN key (idUsuario) references usuario(id);
alter table restauranteUsuario add CONSTRAINT FK_RestauranteUsuario_Restaurante FOREIGN key (idRestaurante) references restaurante(id);
alter table mesa add CONSTRAINT FK_Mesa_EstadoMesa FOREIGN key (idEstadoMesa) references estadoMesa(id);
alter table productoRestaurante add CONSTRAINT FK_ProductoRestaurante_Producto FOREIGN key (idProducto) references producto(id);
alter table productoRestaurante add CONSTRAINT FK_ProductoRestaurante_Restaurante FOREIGN key (idRestaurante) references restaurante(id);
alter table EncabezadoFactura add CONSTRAINT FK_EncabezadoFactura_TipoPago FOREIGN key (idTipoPago) references tipoPago(id);
alter table EncabezadoFactura add CONSTRAINT FK_EncabezadoFactura_EncabezadoPedido FOREIGN key (idEncabezadoPedido) references EncabezadoPedido(id);
--alter table detalleFactura add CONSTRAINT FK_detalleFactura_Producto FOREIGN key (idProducto) references producto(id);
--alter table detalleFactura add CONSTRAINT FK_detalleFactura_EncabezadoFactura FOREIGN key (idEncabezadoFactura) references EncabezadoFactura(id);
alter table EncabezadoPedido add CONSTRAINT FK_EncabezadoPedido_Mesa FOREIGN key (idMesa) references mesa(id);
alter table EncabezadoPedido add CONSTRAINT FK_EncabezadoPedido_EstadoPedido FOREIGN key (idEstadoPedido) references estadoPedido(id);
alter table EncabezadoPedido add CONSTRAINT FK_EncabezadoPedido_usuario FOREIGN key (idUsuario) references usuario(id);
alter table detallePedido add CONSTRAINT FK_DetallePedido_EncabezadoPedido FOREIGN key (idEncabezadoPedido) references EncabezadoPedido(id);
alter table detallePedido add CONSTRAINT FK_DetallePedido_Producto FOREIGN key (idProducto) references  producto(id);

--Procedimientos almacenados
--Mostrar EstadoMesa
CREATE PROCEDURE [dbo].[PA_SeleccionarEstadoMesa] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from estadoMesa;
END


--Mostrar EstadoPedido
CREATE PROCEDURE [dbo].[PA_SeleccionarEstadoPedido] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from estadoPedido;
END


--Mostrar Mesa
CREATE PROCEDURE [dbo].[PA_SeleccionarMesas] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select m.*, e.descripcion from mesa m, estadoMesa e;
END


--Mostrar Productos
CREATE PROCEDURE [dbo].[PA_SeleccionarProductos] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select p.*, t.descripcion, t.estado from producto p, tipoProducto t;
END


--Mostrar ProductoRestaurante
CREATE PROCEDURE [dbo].[PA_SeleccionarProductoRestaurante] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from productoRestaurante;
END


--Mostrar Restaurante
CREATE PROCEDURE [dbo].[PA_SeleccionarRestaurantes] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from restaurante;
END



--Mostrar RestauranteUsuario
CREATE PROCEDURE [dbo].[PA_SeleccionarRestauranteUsuario] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from restauranteUsuario;
END



--Mostrar Roles
CREATE PROCEDURE [dbo].[PA_SeleccionarRol] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from rol;
END



--Mostrar TipoPagos
CREATE PROCEDURE [dbo].[PA_SeleccionarTipoPagos] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from tipoPago;
END


--Mostrar TipoProductos
CREATE PROCEDURE [dbo].[PA_SeleccionarTipoProductos] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from tipoProducto;
END


--Mostrar Usuarios
CREATE PROCEDURE [dbo].[PA_SeleccionarUsuarios] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select u.*, r.descripcion from usuario u, rol r;
END



--Mostrar EncabezadoFactura
CREATE PROCEDURE [dbo].[PA_SeleccionarEncabezadosFactura] 
 @idRestaurante int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select e.*, t.descripcion from EncabezadoFactura e, tipoPago t;
END

/*
--Mostrar DetalleFactura
CREATE PROCEDURE [dbo].[PA_SeleccionarDetallesFactura] 
 @idEncabezadoFactura int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select * from detalleFactura where idEncabezadoFactura = @idEncabezadoFactura;
END*/



--Mostrar EncabezadoPedido
CREATE PROCEDURE [dbo].[PA_SeleccionarEncabezadosPedido] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select e.*, t.descripcion from EncabezadoPedido e, tipoPago t;
END



--Mostrar DetallePedido
CREATE PROCEDURE [dbo].[PA_SeleccionarDetallesPedido] 
 @idEncabezadoPedido int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select d.*, p.nombre from detallePedido d, producto p where d.idEncabezadoPedido = @idEncabezadoPedido;
END