﻿
USE master

GO
IF(SELECT Count(name) FROM sys.databases WHERE name = 'ExFileMVCDB')=1
	BEGIN
		ALTER DATABASE ExFileMVCDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		DROP DATABASE ExFileMVCDB;
	END
GO

--Criando DATABASE ExFileMVCDB
CREATE DATABASE ExFileMVCDB ON  PRIMARY 
( NAME = N'ExFileMVCDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ExFileMVCDB.mdf' , 
	SIZE = 30MB , FILEGROWTH = 100%)
 LOG ON 
( NAME = N'ExFileMVCDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ExFileMVCDB_log.ldf' ,
	 SIZE = 5MB , FILEGROWTH = 100%)
GO
USE ExFileMVCDB;
GO

---- Alterando para simple p/ não acumular LOG
ALTER DATABASE ExFileMVCDB SET RECOVERY SIMPLE WITH NO_WAIT;

CREATE TABLE Arquivo
(
	ID				INT					IDENTITY(1,1),
	Nome			VARCHAR(200)		NOT NULL,
	AnexoBytes		VARBINARY(MAX)		NOT NULL,
	AnexoExtensao	CHAR(5)				NOT NULL,
	AnexoTipo		VARCHAR(200)		NOT NULL

	CONSTRAINT PK_Arquivo_ID PRIMARY KEY(ID),
	CONSTRAINT UQ_Arquivo_Nome UNIQUE(Nome)
);