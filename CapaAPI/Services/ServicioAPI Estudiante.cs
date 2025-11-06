using System.Collections.Generic;
using System.Linq;
using CapaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapaAPI.Services
{
    public class ServicioEstudiante
    {
        private readonly AppDbContext _context;

        public ServicioEstudiante(AppDbContext context)
        {
            _context = context;
        }

        public List<Estudiante> Listar()
        {
            return _context.Estudiantes.ToList();
        }

 
        public Estudiante ObtenerPorId(int id)
        {
            return _context.Estudiantes.FirstOrDefault(e => e.Id == id);
        }


        public List<Estudiante> FiltrarPorNombre(string nombre)
        {
            return _context.Estudiantes
                .Where(e => e.Nombre.Contains(nombre))
                .ToList();
        }

        public List<Estudiante> OrdenarPorNombre(bool ascendente = true)
        {
            if (ascendente)
                return _context.Estudiantes.OrderBy(e => e.Nombre).ToList();
            else
                return _context.Estudiantes.OrderByDescending(e => e.Nombre).ToList();
        }

        public Estudiante Crear(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();
            return estudiante;
        }


        public Estudiante Actualizar(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            _context.SaveChanges();
            return estudiante;
        }

        public bool Eliminar(int id)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null)
                return false;

            _context.Estudiantes.Remove(estudiante);
            _context.SaveChanges();
            return true;
        }
    }
}
