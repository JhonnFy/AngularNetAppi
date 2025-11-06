using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaDatos;
using CapaNegocio;

namespace CapaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly CapaNegocio_Estudiante _negocioEstudiante;

        public EstudianteController()
        {
            _negocioEstudiante = new CapaNegocio_Estudiante();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = _negocioEstudiante.NegocioReadEstudiante();
            return Ok(lista);
        }


    }
}
