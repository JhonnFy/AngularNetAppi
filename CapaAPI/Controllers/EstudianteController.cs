using Microsoft.AspNetCore.Mvc;
using CapaNegocio;

namespace CapaAPI.Controllers
{
    [Route("api/Estudiante")] // Ruta fija
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly CapaNegocio_Estudiante _negocioEstudiante;

        public EstudianteController(CapaNegocio_Estudiante negocioEstudiante)
        {
            _negocioEstudiante = negocioEstudiante;
        }

        // GET: api/Estudiante
        [HttpGet]
        public IActionResult Get()
        {
            // Llama a la capa de negocio que retorna todos los estudiantes
            var lista = _negocioEstudiante.NegocioReadEstudiante();

            // Retorna 200 OK con la lista
            return Ok(lista);
        }
    }
}
