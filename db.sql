
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
