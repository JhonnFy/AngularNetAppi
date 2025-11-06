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

        [HttpGet]
        public ActionResult<List<Nota>> Listar()
        {
            var lista = _servicio.Listar();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public ActionResult<Nota> ObtenerPorId(int id)
        {
            var nota = _servicio.ObtenerPorId(id);
            if (nota == null)
                return NotFound();
            return Ok(nota);
        }

        [HttpPost]
        public ActionResult<Nota> Crear([FromBody] Nota nota)
        {
            var creado = _servicio.Crear(nota);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public ActionResult<Nota> Actualizar(int id, [FromBody] Nota nota)
        {
            if (id != nota.Id)
                return BadRequest();

            var actualizado = _servicio.Actualizar(nota);
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
