using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class ControladorProfesor
    {
        private CapaNegocio_Profesor objNegocioProfesor;

        public ControladorProfesor()
        {
            objNegocioProfesor = new CapaNegocio_Profesor();
        }

        public List<ModeloProfesor> ControladorReadProfesor()
        {
            return objNegocioProfesor.NegocioReadProfesor();
        }

        public List<ModeloProfesor> ControladorReadProfesorId(int id)
        {
            return objNegocioProfesor.NegocioReadProfesorId(id);
        }

        public bool ControladorCreateProfesor(ModeloProfesor nuevoProfesor)
        {
            return objNegocioProfesor.NegocioReadCreateProfesor(nuevoProfesor);
        }

        public bool ControladorUpdateProfesor(ModeloProfesor actualizarProfesor)
        {
            return objNegocioProfesor.NegocioUpdateProfesor(actualizarProfesor);
        }

        public bool ControladorDeleteProfesor(int idProfesor)
        {
            return objNegocioProfesor.NegocioEliminarProfesor(idProfesor);
        }
    }
}
