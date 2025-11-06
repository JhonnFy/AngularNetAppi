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


        public List<Nota> FiltrarPorEstudiante(int idEstudiante)
        {
            return _context.Notas
                .Where(n => n.IdEstudiante == idEstudiante)
                .ToList();
        }


        public List<Nota> FiltrarPorProfesor(int idProfesor)
        {
            return _context.Notas
                .Where(n => n.IdProfesor == idProfesor)
                .ToList();
        }


        public List<Nota> OrdenarPorValor(bool ascendente = true)
        {
            if (ascendente)
                return _context.Notas.OrderBy(n => n.Valor).ToList();
            else
                return _context.Notas.OrderByDescending(n => n.Valor).ToList();
        }


        public Nota Crear(Nota nota)
        {
            _context.Notas.Add(nota);
            _context.SaveChanges();
            return nota;
        }


        public Nota Actualizar(Nota nota)
        {
            _context.Notas.Update(nota);
            _context.SaveChanges();
            return nota;
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
