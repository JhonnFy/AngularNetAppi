using System.Collections.Generic;
using System.Linq;
using CapaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CapaAPI.Services
{
    public class ServicioEstudiante
    {
        private readonly AppDbContext _context;

        public ServicioEstudiante(AppDbContext context)
        {
            _context = context;
        }

        // Listar todos los estudiantes
        public List<Estudiante> Listar()
        {
            return _context.Estudiantes.ToList();
        }

        // Obtener un estudiante por Id
        public Estudiante ObtenerPorId(int id)
        {
            return _context.Estudiantes.FirstOrDefault(e => e.Id == id);
        }

        // Filtrar por nombre
        public List<Estudiante> FiltrarPorNombre(string nombre)
        {
            return _context.Estudiantes
                .Where(e => e.Nombre.Contains(nombre))
                .ToList();
        }

        // Ordenar por nombre
        public List<Estudiante> OrdenarPorNombre(bool ascendente = true)
        {
            if (ascendente)
                return _context.Estudiantes.OrderBy(e => e.Nombre).ToList();
            else
                return _context.Estudiantes.OrderByDescending(e => e.Nombre).ToList();
        }

        // Crear estudiante
        public Estudiante Crear(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();
            return estudiante;
        }

        // Actualizar estudiante (sin conflictos de tracking)
        public Estudiante Actualizar(int id, Estudiante estudiante)
        {
            var existente = _context.Estudiantes.FirstOrDefault(e => e.Id == id);
            if (existente == null)
                return null;

            existente.Nombre = estudiante.Nombre;
            _context.SaveChanges();
            return existente;
        }

        // Eliminar estudiante
        public bool Eliminar(int id)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null)
                return false;

            _context.Estudiantes.Remove(estudiante);
            _context.SaveChanges();
            return true;
        }

        public List<int> ListarEstudiantesConNotas()
        {
            return _context.Notas
                .Select(n => n.IdEstudiante)
                .Distinct()
                .ToList();
        }

        public List<int> ListarEstudiantesSinNotas()
        {
            var idsConNotas = _context.Notas
                .Select(n => n.IdEstudiante)
                .Distinct()
                .ToList();

            var idsTodos = _context.Estudiantes
                .Select(e => e.Id)
                .ToList();

            // Lista Los Candidatos A Eliminar
            var idsSinNotas = idsTodos
                .Where(id => !idsConNotas.Contains(id))
                .ToList();

            return idsSinNotas;
        }


    }
}

