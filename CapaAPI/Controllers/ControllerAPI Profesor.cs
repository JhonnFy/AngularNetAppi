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

        [HttpGet]
        public ActionResult<List<Profesor>> Listar()
        {
            var lista = _servicio.Listar();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public ActionResult<Profesor> ObtenerPorId(int id)
        {
            var profesor = _servicio.ObtenerPorId(id);
            if (profesor == null)
                return NotFound();
            return Ok(profesor);
        }

        [HttpPost]
        public ActionResult<Profesor> Crear([FromBody] Profesor profesor)
        {
            var creado = _servicio.Crear(profesor);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public ActionResult<Profesor> Actualizar(int id, [FromBody] Profesor profesor)
        {
            if (id != profesor.Id)
                return BadRequest();

            var actualizado = _servicio.Actualizar(profesor);
            if (actualizado == null)
                return NotFound();

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
