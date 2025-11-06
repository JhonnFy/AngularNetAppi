using System.Collections.Generic;
using System.Linq;
using CapaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapaAPI.Services
{
    public class ServicioNota
    {
        private readonly AppDbContext _context;

        public ServicioNota(AppDbContext context)
        {
            _context = context;
        }

        public List<Nota> Listar()
        {
            return _context.Notas.ToList();
        }

        public Nota ObtenerPorId(int id)
        {
            return _context.Notas.FirstOrDefault(n => n.Id == id);
        }

        public List<Nota> FiltrarPorNombre(string nombre)
        {
            return _context.Notas
                .Where(n => n.Nombre.Contains(nombre))
                .ToList();
        }

        public List<Nota> OrdenarPorNombre(bool ascendente = true)
        {
            if (ascendente)
                return _context.Notas.OrderBy(n => n.Nombre).ToList();
            else
                return _context.Notas.OrderByDescending(n => n.Nombre).ToList();
        }

        public Nota Crear(Nota nota)
        {
            _context.Notas.Add(nota);
            _context.SaveChanges();
            return nota;
        }

        public Nota Actualizar(int id, Nota nota)
        {
            var existente = _context.Notas.FirstOrDefault(n => n.Id == id);
            if (existente == null)
                return null;

            existente.Nombre = nota.Nombre;
            existente.IdEstudiante = nota.IdEstudiante;
            existente.IdProfesor = nota.IdProfesor;
            existente.Valor = nota.Valor;

            _context.SaveChanges();
            return existente;
        }

        public bool Eliminar(int id)
        {
            var nota = _context.Notas.FirstOrDefault(n => n.Id == id);
            if (nota == null)
                return false;

            _context.Notas.Remove(nota);
            _context.SaveChanges();
            return true;
        }
    }
}
