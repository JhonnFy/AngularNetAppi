using System.Collections.Generic;
using System.Linq;
using CapaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapaAPI.Services
{
    public class ServicioProfesor
    {
        private readonly AppDbContext _context;

        public ServicioProfesor(AppDbContext context)
        {
            _context = context;
        }

        public List<Profesor> Listar()
        {
            return _context.Profesores.ToList();
        }

        public Profesor ObtenerPorId(int id)
        {
            return _context.Profesores.FirstOrDefault(p => p.Id == id);
        }

        public List<Profesor> FiltrarPorNombre(string nombre)
        {
            return _context.Profesores
                .Where(p => p.Nombre.Contains(nombre))
                .ToList();
        }

        public List<Profesor> OrdenarPorNombre(bool ascendente = true)
        {
            if (ascendente)
                return _context.Profesores.OrderBy(p => p.Nombre).ToList();
            else
                return _context.Profesores.OrderByDescending(p => p.Nombre).ToList();
        }

        public Profesor Crear(Profesor profesor)
        {
            _context.Profesores.Add(profesor);
            _context.SaveChanges();
            return profesor;
        }

        public Profesor Actualizar(int id, Profesor profesor)
        {
            var existente = _context.Profesores.FirstOrDefault(p => p.Id == id);
            if (existente == null)
                return null;

            existente.Nombre = profesor.Nombre;
            _context.SaveChanges();
            return existente;
        }

        public bool Eliminar(int id)
        {
            var profesor = _context.Profesores.FirstOrDefault(p => p.Id == id);
            if (profesor == null)
                return false;

            _context.Profesores.Remove(profesor);
            _context.SaveChanges();
            return true;
        }

        public List<int> ListarProfesoresConNotas()
        {
            return _context.Notas
                .Select(n => n.IdProfesor)
                .Distinct()
                .ToList();
        }

        public List<int> ListarProfesoresSinNotas()
        {
            var idsConNotas = _context.Notas
                .Select(n => n.IdProfesor)
                .Distinct()
                .ToList();

            var idsTodos = _context.Profesores
                .Select(p => p.Id)
                .ToList();

            // Lista los profesores que no tienen notas
            var idsSinNotas = idsTodos
                .Where(id => !idsConNotas.Contains(id))
                .ToList();

            return idsSinNotas;
        }



    }
}
