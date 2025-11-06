using CapaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaAPI.Services
{
    public class ServicioEstudiante
    {
        private readonly List<Estudiante> _estudiantes;

        public ServicioEstudiante()
        {
            // Datos de ejemplo, luego se reemplaza con acceso a base de datos
            _estudiantes = new List<Estudiante>
            {
                new Estudiante { IdIdentity = 1, Id = 101, Nombre = "Juan Perez" },
                new Estudiante { IdIdentity = 2, Id = 102, Nombre = "Maria Gomez" }
            };
        }


        public List<Estudiante> GetTodos()
        {
            return _estudiantes;
        }


        public Estudiante GetPorId(int id)
        {
            return _estudiantes.FirstOrDefault(e => e.Id == id);
        }


        public void Agregar(Estudiante estudiante)
        {
            estudiante.IdIdentity = _estudiantes.Max(e => e.IdIdentity) + 1;
            _estudiantes.Add(estudiante);
        }


        public bool Actualizar(Estudiante estudiante)
        {
            var existente = _estudiantes.FirstOrDefault(e => e.Id == estudiante.Id);
            if (existente == null) return false;

            existente.Nombre = estudiante.Nombre;
            return true;
        }


        public bool Eliminar(int id)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null) return false;

            _estudiantes.Remove(estudiante);
            return true;
        }
    }
}
