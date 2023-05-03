CREATE DATABASE CIMA;
GO
USE CIMA
GO

IF OBJECT_ID ('dbo.Asistente', 'U') IS NOT NULL  
   DROP TABLE Asistente;
GO 
Create Table Asistente
(
Id_Asistente int,
Nombre Varchar(100),
Fecha_Asistencia DateTime
);
GO

IF OBJECT_ID ('dbo.Sesion', 'U') IS NOT NULL  
   DROP TABLE Sesion;
GO 
Create Table Sesion
(
Id_Sesion int,
Nombre Varchar(100)
);
GO

IF OBJECT_ID ('dbo.AsistentesPorSesion', 'U') IS NOT NULL  
   DROP TABLE AsistentesPorSesion;
GO 
Create Table AsistentesPorSesion
(
Id_Asistente int,
Id_Sesion int
);
GO

