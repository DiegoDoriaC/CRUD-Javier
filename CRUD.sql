create database CrudJavier;

use CrudJavier;

set dateFormat dmy

create table Usuario
(
	IdUsuario int primary key identity(1000, 1),
	Nombre varchar(20),
	Apellido varchar(20),
	Dni varchar(8) unique,
	Telefono varchar(9) unique
)

insert into Usuario values
	('Diego', 'Doria', '72557870', '928109364')
go



--Creando los procedures--

create or alter procedure sp_listarClientes	
as
begin
	select * from Usuario
end
go

create procedure sp_eliminarUsuarios
	@ID int
as
begin
	DELETE FROM Usuario 
	WHERE IdUsuario = @ID;
end
go

--CREATE
create procedure sp_crearUsuario
	@nombre varchar(20),
	@apellido varchar(20),
	@dni varchar(8),
	@telefono varchar(9)
as
begin
	insert into Usuario values
	(@nombre, @apellido, @dni, @telefono)
end
go

--UPDATE--
create procedure sp_actualizarUsuario
	@id int,
	@nombre varchar(20),
	@apellido varchar(20),
	@dni varchar(8),
	@telefono varchar(9)
as
begin
	update Usuario set 
	Nombre = @nombre,
	Apellido = @apellido,
	Dni = @dni,
	Telefono = @telefono 
	where IdUsuario = @id
end
go