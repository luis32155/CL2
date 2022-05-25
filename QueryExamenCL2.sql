Create database Academico2022
go
Use Academico2022
go
Set dateFormat dmy
go
create table tb_curso(
	codcurso int primary key,
	nomcurso varchar(255) not null
)
go
insert tb_curso 
Values(1,'Visual Basic'),(2,'C#'),(3,'Node JS'),(4,'Phyton'),(5,'React JS')
go
create table tb_horario(
	codhorario int primary key,
	codcurso int references tb_curso,
	fecinicio datetime,
	fecterminio datetime null,
	vacantes int
)
go

create table tb_registro(
	idvacante int identity(1,1) primary key,
	codhorario int references tb_horario,
	fregistro datetime,
	alumno varchar(255),
	email varchar(255)
)
go


-- Store Procedure 


-- sp listar todos los cursos
create proc sp_listar_cursos
as 
select* from tb_curso
go

-- sp listar por fechas cursos

create proc sp_listar_fechas_registro
@fecha1  varchar(50),
@fecha2  varchar(50) 
as
begin
select h.codhorario,c.nomcurso,c.codcurso,h.fecinicio,h.fecterminio,h.vacantes from  tb_horario h  inner join tb_curso c on c.codcurso=h.codcurso
where    CONVERT(DATETIME,h.fecinicio) BETWEEN  @fecha1 and @fecha2
end 
Go

exec sp_listar_fechas_registro '01/06/2022','02/06/2022'

-- sp insertar horario

create proc sp_insert_horario
@codigohorario int,
@codigocurso int,
@fechainicio datetime
as 
begin 
insert into tb_horario(codhorario,codcurso,fecinicio,fecterminio,vacantes) values(@codigohorario,@codigocurso,@fechainicio,DATEADD(DAY,28,@fechainicio),25)
end 
GO

exec sp_insert_horario 100,1,'1-6-2022'
exec sp_insert_horario 101,2,'2-6-2022'
exec sp_insert_horario 103,1,'10-06-2022'
exec sp_insert_horario 104,3,'10-06-2022'
exec sp_insert_horario 105,2,'15-06-2022'
exec sp_insert_horario 106,1,'18-06-2022'
exec sp_insert_horario 107,5,'21-06-2022'
go


select * from tb_horario
  
CREATE TRIGGER vacante_update ON dbo.tb_registro
AFTER UPDATE
AS
     UPDATE tb_horario
       SET 
           fecinicio = CAST(GETDATE() AS DATE)
     FROM inserted
     WHERE tb_horario.codhorario = inserted.codhorario;
GO

create TRIGGER actualizar_STOCK
  ON COMPROBANTE_DETALLE
 FOR INSERT
 AS
 DECLARE @CODPROD VARCHAR(4),@CANT INT
SELECT @CODPROD=CODPRO,@CANT=CANTIDAD FROM inserted
  UPDATE PRODUCTOS SET STOCK =STOCK-@CANT
  WHERE CODPROD=@CODPROD
  GO