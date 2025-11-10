using Microsoft.AspNetCore.Mvc;
using CapaAPI.Models;
using CapaAPI.Services;
using System.Collections.Generic;

namespace CapaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly ServicioNota _servicio;

        public NotaController(ServicioNota servicio)
        {
            _servicio = servicio;
        }

        // GET: api/nota
        [HttpGet]
        public ActionResult<List<Nota>> GetAll()
        {
            return _servicio.Listar();
        }

        // GET: api/nota/{id}
        [HttpGet("{id}")]
        public ActionResult<Nota> GetById(int id)
        {
            var nota = _servicio.ObtenerPorId(id);
            if (nota == null)
                return NotFound();
            return nota;
        }

        // POST: api/nota
        [HttpPost]
        public ActionResult<Nota> Crear(Nota nota)
        {
            _servicio.Crear(nota);
            return CreatedAtAction(nameof(GetById), new { id = nota.Id }, nota);
        }

        // PUT: api/nota/{id}
        [HttpPut("{id}")]
        public ActionResult<Nota> Actualizar(int id, Nota nota)
        {
            if (id != nota.Id)
                return BadRequest();

            var existente = _servicio.ObtenerPorId(id);
            if (existente == null)
                return NotFound();

            _servicio.Actualizar(id, nota); 
            return nota;
        }

        // DELETE: api/nota/{id}
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var eliminado = _servicio.Eliminar(id);
            if (!eliminado)
                return NotFound();
            return NoContent();
        }

        //[HttpPost]
        //public IActionResult RegistrarNota([FromBody] Nota nota)
        //{
        //    if (nota == null) return BadRequest("Datos inválidos");

        //    var registrada = _servicio.RegistrarNota(nota);
        //    if (!registrada)
        //        return BadRequest("El profesor o el estudiante no existen.");

        //    return Ok(nota);
        //}
    }
}
