Create Procedure SP_Alta_Articulo
@Sku varchar(6),
@Articulo varchar(15),
@Marca varchar(15),
@Modelo varchar(20),
@Familia varchar(3),
@Stock int,
@Cantidad int
as
Begin

Insert Into Articulo
		(Sku,Articulo,Marca,Modelo,Familia,Stock,Cantidad)
values	(@Sku,@Articulo,@Marca,@Modelo,@Familia,@Stock,@Cantidad);

END;

Create Procedure SP_Consulta_Sku
@Sku varchar(6)
as
Begin

select Articulo,Marca,Modelo,c.Id_departamento as Departamento, f.Id_clase as Clase, Familia, Stock, Cantidad, Fecha_alta,Fecha_baja, Descontinuado
from Articulo as a
inner join Familia as f on a.Familia = f.Id_familia
inner join Clase as c on f.Id_clase = c.Id_clase
where Sku=@Sku

END

exec SP_Consulta_Sku @Sku = '000001'

Create Procedure SP_Baja_Articulo
@Sku varchar(6)
as
Begin

delete from Articulo where Sku=@Sku

END

select * from Articulo

Create Procedure SP_Actualizar_Articulo
@Sku varchar(6),
@Articulo varchar(15),
@Marca varchar(15),
@Modelo varchar(20),
@Familia varchar(3),
@Stock int,
@Cantidad int,
@Descontinuado bit,
@FechaBaja Date
as
Begin

update Articulo
set Articulo = @Articulo, Marca = @Marca, Modelo = @Modelo, Familia = @Familia, Cantidad = @Cantidad, Stock = @Stock, Descontinuado = @Descontinuado, Fecha_baja = @FechaBaja
where Sku = @Sku

END


Create Procedure SP_Consulta_DCF
as
Begin

select d.Id_departamento as [Numero de departamento], d.Nombre_departamento as [Nombre de Departamento],
c.Id_clase as [Numero de Clase], c.Nombre_clase as [Nombre de Clase], f.Id_familia as [Numero de Familia],
f.Nombre_familia as [Nombre de Familia]
from Departamento as d
inner join Clase as c on d.Id_departamento = c.Id_departamento
inner join Familia as f on c.Id_clase = f.Id_clase
order by d.Id_departamento

END

exec SP_Consulta_DCF

Create Procedure SP_Consulta_D
as
Begin

SELECT * FROM DEPARTAMENTO

END

Create Procedure SP_Consulta_C
@ID_DEPARTAMENTO varchar(1)
as
Begin

SELECT * FROM CLASE WHERE Id_departamento = @ID_DEPARTAMENTO

END

Create Procedure SP_Consulta_F
@ID_CLASE varchar(2)
as
Begin

SELECT * FROM FAMILIA WHERE Id_clase = @ID_CLASE

END