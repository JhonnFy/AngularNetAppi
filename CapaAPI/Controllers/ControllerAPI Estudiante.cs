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


        [HttpGet]
        public ActionResult<List<Estudiante>> GetAll()
        {
            return _servicio.Listar();
        }


        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetById(int id)
        {
            var estudiante = _servicio.ObtenerPorId(id);
            if (estudiante == null)
                return NotFound();

            return estudiante;
        }


        [HttpPost]
        public ActionResult<Estudiante> Crear([FromBody] Estudiante estudiante)
        {
            var nuevoEstudiante = _servicio.Crear(estudiante);
            return CreatedAtAction(nameof(GetById), new { id = nuevoEstudiante.Id }, nuevoEstudiante);
        }


        [HttpPut("{id}")]
        public ActionResult<Estudiante> Actualizar(int id, [FromBody] Estudiante estudiante)
        {
            if (id != estudiante.Id)
                return BadRequest();

            var actualizado = _servicio.Actualizar(estudiante);
            return Ok(actualizado);
        }


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
