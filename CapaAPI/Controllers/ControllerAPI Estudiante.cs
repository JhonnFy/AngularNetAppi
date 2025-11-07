using Microsoft.AspNetCore.Mvc;
using CapaAPI.Models;
using CapaAPI.Services;
using System.Collections.Generic;

namespace CapaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly ServicioEstudiante _servicio;

        public EstudianteController(ServicioEstudiante servicio)
        {
            _servicio = servicio;
        }

        // GET: api/estudiante
        [HttpGet]
        public ActionResult<List<Estudiante>> GetAll()
        {
            return _servicio.Listar();
        }

        // GET: api/estudiante/{id}
        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetById(int id)
        {
            var estudiante = _servicio.ObtenerPorId(id);
            if (estudiante == null)
                return NotFound();
            return estudiante;
        }

        // POST: api/estudiante
        [HttpPost]
        public ActionResult<Estudiante> Crear(Estudiante estudiante)
        {
            _servicio.Crear(estudiante);
            return CreatedAtAction(nameof(GetById), new { id = estudiante.Id }, estudiante);
        }

        // PUT: api/estudiante/{id}
        [HttpPut("{id}")]
        public ActionResult<Estudiante> Actualizar(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
                return BadRequest();

            var existente = _servicio.ObtenerPorId(id);
            if (existente == null)
                return NotFound();

            _servicio.Actualizar(id, estudiante);
            return estudiante;
        }

        // DELETE: api/estudiante/{id}
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var eliminado = _servicio.Eliminar(id);
            if (!eliminado)
                return NotFound();
            return NoContent();
        }

        //ListarEstudiantesQueNoSeEliminan
        [HttpGet("EstudiantesConNotas")]
        public ActionResult<List<int>> ListarEstudiantesConNotas()
        {
            var ids = _servicio.ListarEstudiantesConNotas();
            return Ok(ids);
        }

        //ListarEstudiantesQueNoSiEliminan
        [HttpGet("EstudiantesSinNotas")]
        public ActionResult<List<int>> ListarEstudiantesSinNotas()
        {
            var ids = _servicio.ListarEstudiantesSinNotas();
            return Ok(ids);
        }
    }
}
