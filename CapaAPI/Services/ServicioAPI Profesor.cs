using CapaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaAPI.Services
{
    public class ServicioProfesor
    {
        private readonly List<Profesor> _profesores;

        public ServicioProfesor()
        {
            // Datos de ejemplo, luego se reemplaza con acceso a base de datos
            _profesores = new List<Profesor>
            {
                new Profesor { IdIdentity = 1, Id = 201, Nombre = "Carlos López" },
                new Profesor { IdIdentity = 2, Id = 202, Nombre = "Ana Martínez" }
            };
        }


        public List<Profesor> GetTodos()
        {
            return _profesores;
        }


        public Profesor GetPorId(int id)
        {
            return _profesores.FirstOrDefault(p => p.Id == id);
        }


        public void Agregar(Profesor profesor)
        {
            profesor.IdIdentity = _profesores.Max(p => p.IdIdentity) + 1;
            _profesores.Add(profesor);
        }


        public bool Actualizar(Profesor profesor)
        {
            var existente = _profesores.FirstOrDefault(p => p.Id == profesor.Id);
            if (existente == null) return false;

            existente.Nombre = profesor.Nombre;
            return true;
        }


        public bool Eliminar(int id)
        {
            var profesor = _profesores.FirstOrDefault(p => p.Id == id);
            if (profesor == null) return false;

            _profesores.Remove(profesor);
            return true;
        }
    }
}
