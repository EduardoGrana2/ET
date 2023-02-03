alter table num add fechaACT date default getdate();

insert into num(num_p) values(04)

select * from num

Insert into Departamento (Id_departamento,Nombre_departamento)
VALUES 
	(1,'DOMESTICOS'),
	(2,'ELECTRONICA'),
	(3,'MUEBLES SUELTOS'),
	(4, 'SALAS,RECAMARAS,COMEDORES')

Insert into Clase (Id_clase,Nombre_clase,id_departamento)
VALUES 
	('1','COMESTIBLES','1'),
	('2','LICUADORAS','1'),
	('3','BATIDORAS','1'),
	('4','CAFETERAS','1'),
	('5','AMPLIFICADORES CAR AUDIO','2'),
	('6','AUTO STEREOS','2'),
	('7','COLCHON','3'),
	('8','JUEGO BOX','3'),
	('9','SALAS','4'),
	('10','COMPLEMENTOS PARA SALA','4'),
	('11','SOFAS CAMA','4');

Insert into Familia (Id_familia,Nombre_familia,id_clase)
VALUES 
	('01','SIN NOMBRE','1'),
	('02','LICUADORAS','2'),
	('03','EXCLUSIVO COPPEL.COM','2'),
	('04','BATIDORA MANUAL','3'),
	('05','PROCESADOR','3'),
	('06','MULTIPRACTICOS','3'),
	('07','CAFETERAS','4'),
	('08','PERCOLADORAS','4'),
	('09','KIT DE INSTALACION','5'),
	('10','AMPLIFICADORES COPPEL','5'),
	('11','AMPLIFICADOR','6'),
	('12','MULTIMEDIA','6'),
	('13','PILLOW TOP KS','7'),
	('14','PILLOW TOP DOBLE KS','7'),
	('15','ESTANDAR INDIVIDUAL','8'),
	('16','ESQUINERAS SUPERIORES','9'),
	('17','TIPO L SECCIONAL','9'),
	('18','SILLON OCASIONAL','10'),
	('19','PUFF','10'),
	('20','SOFACAMA CLASICO','11'),
	('21','ESTUDIO','11')

select * from DEPARTAMENTO;

select * from CLASE


select * from familia

alter table Familia		
add constraint FK_FamiliaClase foreign key (Id_clase) references Clase(Id_clase)

truncate table clase