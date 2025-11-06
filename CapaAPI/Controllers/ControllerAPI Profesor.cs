using Microsoft.AspNetCore.Mvc;
using CapaAPI.Models;
using CapaAPI.Services;
using System.Collections.Generic;

namespace CapaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly ServicioProfesor _servicio;

        public ProfesorController(ServicioProfesor servicio)
        {
            _servicio = servicio;
        }

        // GET: api/profesor
        [HttpGet]
        public ActionResult<List<Profesor>> GetAll()
        {
            return _servicio.Listar();
        }

        // GET: api/profesor/{id}
        [HttpGet("{id}")]
        public ActionResult<Profesor> GetById(int id)
        {
            var profesor = _servicio.ObtenerPorId(id);
            if (profesor == null)
                return NotFound();
            return profesor;
        }

        // POST: api/profesor
        [HttpPost]
        public ActionResult<Profesor> Crear(Profesor profesor)
        {
            _servicio.Crear(profesor);
            return CreatedAtAction(nameof(GetById), new { id = profesor.Id }, profesor);
        }

        // PUT: api/profesor/{id}
        [HttpPut("{id}")]
        public ActionResult<Profesor> Actualizar(int id, Profesor profesor)
        {
            if (id != profesor.Id)
                return BadRequest();

            var existente = _servicio.ObtenerPorId(id);
            if (existente == null)
                return NotFound();

            _servicio.Actualizar(id, profesor); // <- CORREGIDO
            return profesor;
        }

        // DELETE: api/profesor/{id}
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var eliminado = _servicio.Eliminar(id);
            if (!eliminado)
                return NotFound();
            return NoContent();
        }
    }
}
