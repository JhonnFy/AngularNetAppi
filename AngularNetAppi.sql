
--CREATE DATABASE AngularNetAppi
--GO

USE AngularNetAppi
GO

CREATE TABLE Estudiante (
    idIdentity INT Identity(1,1),
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Profesor (
    idIdentity INT Identity(1,1),
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Nota (
    idIdentity INT Identity(1,1),
    id INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    idProfesor INT NOT NULL,
    idEstudiante INT NOT NULL,
    valor DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (idProfesor) REFERENCES Profesor(id),
    FOREIGN KEY (idEstudiante) REFERENCES Estudiante(id)
);
