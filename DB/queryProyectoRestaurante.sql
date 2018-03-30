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
estado int not null,
password varchar(50) not null
)

CREATE TABLE tipoProducto
(id int not null identity,
descripcion varchar(50) not null,
estado int not null,
)

CREATE TABLE producto
(id int not null identity,
idTipoProducto int not null,
nombre varchar(60) not null,
precio float not null,
imagen varchar(50) not null,
estado int not null,
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
cantidadPersonas int not null
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
estado int not null,
facturado int
)

CREATE TABLE detallePedido
(id int not null identity,
idEncabezadoPedido int not null,
idProducto int not null,
cantidad int not null,
precio float not null,
comentario varchar(100) not null,
estado int not null,
)

CREATE TABLE EncabezadoFactura
(id int not null identity,
idEncabezadoPedido int not null,
idRestaurante int not null,
idUsuario varchar(60) not null,
nombreCliente varchar(60) not null,
fecha datetime not null,
iv float not null,
subTotal float not null,
total float not null
)

CREATE TABLE EncabezadoFacturaTipoPago
(idEncabezadoFactura int not null,
idTipoPago int not null,
monto float not null 
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
alter table  EncabezadoFacturaTipoPago add Primary key (idEncabezadoFactura,idTipoPago)
--alter table detalleFactura add Primary key (id)



--Adicion de los Foreign key por medio del alter table
alter table producto add CONSTRAINT FK_Producto_TipoProducto FOREIGN key (idTipoProducto) references tipoProducto(id);
alter table usuario add CONSTRAINT FK_Usuario_Rol FOREIGN key (idRol) references rol(id);
alter table restauranteUsuario add CONSTRAINT FK_RestauranteUsuario_Usuario FOREIGN key (idUsuario) references usuario(id);
alter table restauranteUsuario add CONSTRAINT FK_RestauranteUsuario_Restaurante FOREIGN key (idRestaurante) references restaurante(id);
alter table mesa add CONSTRAINT FK_Mesa_EstadoMesa FOREIGN key (idEstadoMesa) references estadoMesa(id);
alter table productoRestaurante add CONSTRAINT FK_ProductoRestaurante_Producto FOREIGN key (idProducto) references producto(id);
alter table productoRestaurante add CONSTRAINT FK_ProductoRestaurante_Restaurante FOREIGN key (idRestaurante) references restaurante(id);
--alter table EncabezadoFactura add CONSTRAINT FK_EncabezadoFactura_TipoPago FOREIGN key (idTipoPago) references tipoPago(id);
--ALTER TABLE EncabezadoFactura DROP CONSTRAINT FK_EncabezadoFactura_TipoPago;
alter table EncabezadoFactura add CONSTRAINT FK_EncabezadoFactura_EncabezadoPedido FOREIGN key (idEncabezadoPedido) references EncabezadoPedido(id);
--alter table detalleFactura add CONSTRAINT FK_detalleFactura_Producto FOREIGN key (idProducto) references producto(id);
--alter table detalleFactura add CONSTRAINT FK_detalleFactura_EncabezadoFactura FOREIGN key (idEncabezadoFactura) references EncabezadoFactura(id);
alter table EncabezadoPedido add CONSTRAINT FK_EncabezadoPedido_Mesa FOREIGN key (idMesa) references mesa(id);
--alter table EncabezadoPedido add CONSTRAINT FK_EncabezadoPedido_EstadoPedido FOREIGN key (idEstadoPedido) references estadoPedido(id);
alter table EncabezadoPedido add CONSTRAINT FK_EncabezadoPedido_usuario FOREIGN key (idUsuario) references usuario(id);
alter table detallePedido add CONSTRAINT FK_DetallePedido_EncabezadoPedido FOREIGN key (idEncabezadoPedido) references EncabezadoPedido(id);
alter table detallePedido add CONSTRAINT FK_DetallePedido_Producto FOREIGN key (idProducto) references  producto(id);
alter table EncabezadoFacturaTipoPago add CONSTRAINT FK_EncabezadoFacturaTipoPago_EncabezadoFactura FOREIGN key (idEncabezadoFactura) references EncabezadoFactura(id);
alter table EncabezadoFacturaTipoPago add CONSTRAINT FK_EncabezadoFacturaTipoPago_TipoPago FOREIGN key (idTipoPago) references tipoPago(id);

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



CREATE PROCEDURE [dbo].[PA_SeleccionarEncabezadoFacturaTipoPago] 
@idEncabezadoFactura int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select e.*, t.descripcion from EncabezadoFacturaTipoPago e, tipoPago t where idEncabezadoFactura = @idEncabezadoFactura;
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
	Select m.*, e.descripcion from mesa m, estadoMesa e where m.idEstadoMesa = e.id;
END


--Insertar Mesa
CREATE PROCEDURE [dbo].[PA_InsertarMesa] 
@idEstadoMesa int,
@cantidadPersonas int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].mesa
           ([idEstadoMesa]
		   ,[cantidadPersonas]
           )
     VALUES
           (@idEstadoMesa, @cantidadPersonas);
           
END


--Modificar Usuario
CREATE PROCEDURE [dbo].[PA_ModificarMesa] 
@id int,
@idEstadoMesa int,
@cantidadPersonas int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
UPDATE [dbo].mesa
   SET [idEstadoMesa] = @idEstadoMesa,
	   [cantidadPersonas] = @cantidadPersonas
 WHERE [id] = @id;
     

END


--Mostrar Productos
CREATE PROCEDURE [dbo].[PA_SeleccionarProductos] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select p.*, t.descripcion as 'descriTipoProducto', t.estado from producto p, tipoProducto t where p.idTipoProducto = t.id;
END


--Insertar Productos
CREATE PROCEDURE [dbo].[PA_InsertarProductos] 
@idTipoProducto int,
@nombre varchar(60),
@descripcion varchar(200),
@precio float,
@imagen varchar(50),
@estado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].producto
           ([idTipoProducto]
           ,[nombre]
		   ,[descripcion]
           ,[precio]
           ,[imagen]
           ,[estado])
     VALUES
           (@idTipoProducto,
           @nombre,
		   @descripcion,
           @precio,
           @imagen,
		   @estado);

END


--Modificar Productos
CREATE PROCEDURE [dbo].[PA_ModificarProductos] 
@id int,
@idTipoProducto int,
@nombre varchar(60),
@descripcion varchar(200),
@precio float,
@imagen varchar(50),
@estado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
UPDATE [dbo].producto
   SET [idTipoProducto] = @idTipoProducto,
       [nombre] = @nombre,
	   [descripcion] = @descripcion,
       [precio] = @precio,
       [imagen] = @imagen,
       [estado] = @estado
 WHERE [id] = @id
     

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
	Select u.*, r.descripcion from usuario u, rol r where u.idRol = r.id;
END


--Insertar Usuario
CREATE PROCEDURE [dbo].[PA_InsertarUsuarios] 
@id varchar(60),
@idRol int,
@nombre varchar(60),
@direccion varchar(150),
@correo varchar(50),
@password varchar(50),
@telefono varchar(50),
@estado binary(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[usuario]
           ([id]
           ,[idRol]
           ,[nombre]
           ,[direccion]
           ,[correo]
		   ,[password]
           ,[telefono]
           ,[estado])
     VALUES
           (@id,
           @idRol,
           @nombre,
           @direccion,
           @correo,
		   @password,
           @telefono,
           @estado);

END


--Modificar Usuario
CREATE PROCEDURE [dbo].[PA_ModificarUsuarios] 
@id varchar(60),
@idRol int,
@nombre varchar(60),
@direccion varchar(150),
@correo varchar(50),
@password varchar(50),
@telefono varchar(50),
@estado binary(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
UPDATE [dbo].[usuario]
   SET [idRol] = @idRol,
       [nombre] = @nombre,
       [direccion] = @direccion,
       [correo] = @correo,
	   [password] = @password,
       [telefono] = @telefono,
       [estado] = @estado
 WHERE [id] = @id
     

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


--Insertar EncabezadoFactura
CREATE PROCEDURE [dbo].[PA_InsertarEncabezadoFactura] 
@idEncabezadoPedido int,
@idRestaurante int,
@idUsuario varchar(60),
@nombreCliente varchar(60),
@fecha datetime,
@iv float,
@subTotal float,
@total float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].EncabezadoFactura
           ([idEncabezadoPedido]
		   ,[idRestaurante]
           ,[idUsuario]
		   ,[nombreCliente]
		   ,[fecha]
		   ,[iv]
		   ,[subTotal]
		   ,[total])
     VALUES
           (@idEncabezadoPedido,
           @idRestaurante,
           @idUsuario,
           @nombreCliente,
		   @fecha,
		   @iv,
		   @subTotal,
		   @total);
	SELECT TOP 1 * FROM EncabezadoFactura ORDER BY id DESC;
END


--Modificar EncabezadoFactura
CREATE PROCEDURE [dbo].[PA_ModificarEncabezadoFactura] 
@id int,
@idEncabezadoPedido int,
@idRestaurante int,
@idUsuario varchar(60),
@nombreCliente varchar(60),
@fecha datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
UPDATE [dbo].EncabezadoFactura
   SET [idEncabezadoPedido] = @idEncabezadoPedido,
       [idRestaurante] = @idRestaurante,
	   [idUsuario] = @idUsuario,
       [nombreCliente] = @nombreCliente,
	   [fecha] = @fecha
 WHERE [id] = @id
     

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
	Select * from EncabezadoPedido;
END



--Insertar EncabezadoPedido
CREATE PROCEDURE [dbo].[PA_InsertarEncabezadoPedido] 
@idMesa int,
@idUsuario varchar(60),
@estado int,
@facturado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].EncabezadoPedido
           ([idMesa]
           ,[idUsuario]
           ,[estado]
		   ,[facturado])
     VALUES
           (@idMesa,
           @idUsuario,
           @estado,
		   @facturado);
		   
		   UPDATE [dbo].EncabezadoPedido SET [facturado] = 1 where [id] = @idEncabezadoPedido;
		   
	SELECT TOP 1 * FROM EncabezadoPedido ORDER BY id DESC;

END


--Modificar EncabezadoPedido
CREATE PROCEDURE [dbo].[PA_ModificarEncabezadoPedido] 
@id int,
@idMesa int,
@idUsuario varchar(60),
@estado int,
@facturado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
UPDATE [dbo].EncabezadoPedido
   SET [idMesa] = @idMesa,
       [idUsuario] = @idUsuario,
       [estado] = @estado,
	   [facturado] = @facturado
 WHERE [id] = @id
     

END



--Mostrar DetallePedido
CREATE PROCEDURE [dbo].[PA_SeleccionarDetallesPedido] 
 @idEncabezadoPedido int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select d.*, p.nombre, p.imagen, p.precio as 'precioProducto' from detallePedido d, producto p where d.idEncabezadoPedido = @idEncabezadoPedido and d.idProducto = p.id;
END


--Insertar DetallePedido
CREATE PROCEDURE [dbo].[PA_InsertarDetallesPedido] 
@idEncabezadoPedido int,
@idProducto int,
@cantidad int,
@precio float,
@comentario varchar(100),
@estado binary(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].detallePedido
           ([idEncabezadoPedido]
           ,[idProducto]
		   ,[cantidad]
           ,[precio]
           ,[comentario]
           ,[estado])
     VALUES
           (@idEncabezadoPedido,
           @idProducto,
           @cantidad,
           @precio,
		   @comentario,
		   @estado);

END

--Modificar DetallePedido
CREATE PROCEDURE [dbo].[PA_ModificarDetallesPedido] 
@id int,
@idEncabezadoPedido int,
@idProducto int,
@cantidad int,
@precio float,
@comentario varchar(100),
@estado binary(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
UPDATE [dbo].detallePedido
   SET [idEncabezadoPedido] = @idEncabezadoPedido,
       [idProducto] = @idProducto,
	   [cantidad] = @cantidad,
       [precio] = @precio,
       [comentario] = @comentario,
       [estado] = @estado
 WHERE [id] = @id
     

END




USE [proyecto_Restaurante]
GO
/****** Object:  StoredProcedure [dbo].[PA_InsertarEncabezadoFacturaTipoPago]    Script Date: 30/3/2018 1:10:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[PA_InsertarEncabezadoFacturaTipoPago] 
@idEncabezadoFactura int,
@idTipoPago int,
@monto float

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].EncabezadoFacturaTipoPago
           ([idEncabezadoFactura]
		   ,[idTipoPago]
		   ,[monto]
           )
     VALUES
           (@idEncabezadoFactura, @idTipoPago, @monto);
           
END