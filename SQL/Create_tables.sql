create database examen_tecnico;

use examen_tecnico;

create table Departamento(
	Id_departamento varchar(1) not null primary key,
	Nombre_departamento varchar(25) not null
);

create table Clase(
	Id_clase varchar(2) not null primary key,
	Nombre_clase varchar(25) not null,
	Id_departamento varchar(1) not null,
	Foreign key (Id_departamento) References Departamento(Id_departamento)
);

create table Familia(
	Id_familia varchar(3) not null primary key,
	Nombre_familia varchar(25) not null,
	Id_clase varchar(2) not null,
	Foreign key (Id_clase) References Clase(Id_clase)
);

create table Articulo(
	Sku varchar(6) not null primary key,
	Articulo varchar(15) not null,
	Marca varchar(15) not null,
	Modelo varchar(20) not null,
	Familia varchar(3) not null,
	Fecha_alta date not null default getdate(),
	Stock int not null,
	Cantidad int not null,
	Descontinuado bit default 0,
	Fecha_baja date not null default '1990-01-01',
	Foreign key (Familia) References Familia(Id_familia)
);