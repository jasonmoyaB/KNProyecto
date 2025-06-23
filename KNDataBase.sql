IF DB_ID('KNJasonMoya') IS NULL
BEGIN
    CREATE DATABASE KNJasonMoya;
END
GO

-- IMPORTANTE: Separar la ejecución para asegurarse de que la base existe antes de usarla
USE KNJasonMoya;
GO

-- Borrar tabla si ya existe
IF OBJECT_ID('dbo.TUsuario', 'U') IS NOT NULL
DROP TABLE dbo.TUsuario;
GO

-- Crear tabla TUsuario correctamente
CREATE TABLE dbo.TUsuario (
    IdUsuario BIGINT IDENTITY(1,1) NOT NULL,
    Identificacion VARCHAR(20) NOT NULL,
    Nombre VARCHAR(255) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    Contrasenna VARCHAR(10) NOT NULL,
    CONSTRAINT PK_TUsuario PRIMARY KEY CLUSTERED (IdUsuario ASC)
);
GO

-- Insertar usuario de prueba
INSERT INTO dbo.TUsuario (Identificacion, Nombre, Correo, Contrasenna)
VALUES ('304590415', 'Eduardo Calvo', 'ecalvo90415@ufide.ac.cr', '90415');
GO

-- Eliminar procedimiento si existe
IF OBJECT_ID('dbo.RegistroUsuario', 'P') IS NOT NULL
DROP PROCEDURE dbo.RegistroUsuario;
GO

-- Crear procedimiento de registro
CREATE PROCEDURE dbo.RegistroUsuario
    @Identificacion VARCHAR(20),
    @Nombre VARCHAR(255),
    @Correo VARCHAR(100),
    @Contrasenna VARCHAR(10)
AS
BEGIN
    INSERT INTO dbo.TUsuario (Identificacion, Nombre, Correo, Contrasenna)
    VALUES (@Identificacion, @Nombre, @Correo, @Contrasenna);
END
GO

-- Eliminar procedimiento si existe
IF OBJECT_ID('dbo.ValidarInicioSesion', 'P') IS NOT NULL
DROP PROCEDURE dbo.ValidarInicioSesion;
GO

-- Crear procedimiento de validación
CREATE PROCEDURE dbo.ValidarInicioSesion
    @Correo VARCHAR(100),
    @Contrasenna VARCHAR(10)
AS
BEGIN
    SELECT IdUsuario, Identificacion, Nombre, Correo, Contrasenna
    FROM dbo.TUsuario
    WHERE Correo = @Correo AND Contrasenna = @Contrasenna;
END
GO