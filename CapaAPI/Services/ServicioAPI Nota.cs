using CapaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaAPI.Services
{
    public class ServicioNota
    {
        private readonly List<Nota> _notas;

        public ServicioNota()
        {

            _notas = new List<Nota>
            {
                new Nota { IdIdentity = 1, Id = 301, Nombre = "Matemáticas", IdProfesor = 201, IdEstudiante = 101, Valor = 4.5m },
                new Nota { IdIdentity = 2, Id = 302, Nombre = "Historia", IdProfesor = 202, IdEstudiante = 102, Valor = 3.8m }
            };
        }


        public List<Nota> GetTodos()
        {
            return _notas;
        }


        public Nota GetPorId(int id)
        {
            return _notas.FirstOrDefault(n => n.Id == id);
        }


        public void Agregar(Nota nota)
        {
            nota.IdIdentity = _notas.Max(n => n.IdIdentity) + 1;
            _notas.Add(nota);
        }


        public bool Actualizar(Nota nota)
        {
            var existente = _notas.FirstOrDefault(n => n.Id == nota.Id);
            if (existente == null) return false;

            existente.Nombre = nota.Nombre;
            existente.IdProfesor = nota.IdProfesor;
            existente.IdEstudiante = nota.IdEstudiante;
            existente.Valor = nota.Valor;
            return true;
        }


        public bool Eliminar(int id)
        {
            var nota = _notas.FirstOrDefault(n => n.Id == id);
            if (nota == null) return false;

            _notas.Remove(nota);
            return true;
        }


        public List<Nota> Filtrar(int? idEstudiante = null, int? idProfesor = null)
        {
            return _notas
                .Where(n => (!idEstudiante.HasValue || n.IdEstudiante == idEstudiante.Value) &&
                            (!idProfesor.HasValue || n.IdProfesor == idProfesor.Value))
                .ToList();
        }


        public List<Nota> Ordenar(string campo = "Nombre", bool ascendente = true)
        {
            return campo.ToLower() switch
            {
                "valor" => ascendente ? _notas.OrderBy(n => n.Valor).ToList() : _notas.OrderByDescending(n => n.Valor).ToList(),
                "nombre" => ascendente ? _notas.OrderBy(n => n.Nombre).ToList() : _notas.OrderByDescending(n => n.Nombre).ToList(),
                _ => _notas.ToList()
            };
        }
    }
}
