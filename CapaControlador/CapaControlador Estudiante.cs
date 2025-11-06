using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using CapaDatos;

namespace CapaControlador
{
    public class ControladorEstudiante
    {
        private CapaNegocio_Estudiante objNegocioEstudiante;

        public ControladorEstudiante()
        {
            objNegocioEstudiante = new CapaNegocio_Estudiante();
        }

        public List<ModeloEstudiante> ControladorReadEstudiante()
        {
            return objNegocioEstudiante.NegocioReadEstudiante();
        }

        public List<ModeloEstudiante> ControladorReadEstudianteId(int id)
        {
            return objNegocioEstudiante.NegocioReadEstudianteId(id);
        }

        public bool ControladorCreateEstudiante(ModeloEstudiante nuevoEstudiante)
        {
            return objNegocioEstudiante.NegocioReadCreateEstudiante(nuevoEstudiante);
        }
          
        public bool ControladorUpdateEstudiante(ModeloEstudiante actualizarEstudiante)
        {
            return objNegocioEstudiante.NegocioUpdateEstudiante(actualizarEstudiante);
        }


    }     
}
