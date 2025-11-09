------------------------------------------------------------
--Base de Datos: AngularNetAppi
--Fecha creación: 2025-11-06
--Creado por: JhonFy 
--Descripción:
--Estructura de tablas y restricción para impedir la eliminación de notas asociadas a profesor y estudiante.
----------------------------------------------------------

CREATE DATABASE AngularNetAppi

USE AngularNetAppi

CREATE TABLE Estudiante (
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Profesor (
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Nota (
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    idProfesor INT NOT NULL,
    idEstudiante INT NOT NULL,
    valor DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (idProfesor) REFERENCES Profesor(id),
    FOREIGN KEY (idEstudiante) REFERENCES Estudiante(id)
);


------------------------------------------------------------
-- Trigger: TR_Nota_NoEliminarAsociadas
-- Impide eliminar notas que tengan profesor y estudiante asignados.
------------------------------------------------------------
GO
CREATE TRIGGER TR_Nota_NoEliminarAsociadas
ON Nota
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si alguna nota tiene profesor y estudiante asociados
    IF EXISTS (
        SELECT 1
        FROM deleted
        WHERE idProfesor IS NOT NULL AND idEstudiante IS NOT NULL
    )
    BEGIN
        RAISERROR('No se puede eliminar una nota asociada a un profesor y estudiante.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Si pasa la validación, eliminar normalmente
    DELETE FROM Nota
    WHERE id IN (SELECT id FROM deleted);
END
GO
