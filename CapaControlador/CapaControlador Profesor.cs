using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class CapaControladorProfesor
    {
        private CapaNegocio_Profesor objNegocioProfesor;
        
        public CapaControladorProfesor()
        {
            objNegocioProfesor = new CapaNegocio_Profesor();
        }

        public List<ModeloProfesor> ConstructorReadProfesor()
        {
            return objNegocioProfesor.NegocioReadProfesor();
        }

        public List<ModeloProfesor> ContructorReadProfesorId(int id)
        {
            return objNegocioProfesor.NegocioReadProfesorId(id);
        }

        public bool ConstructorCreateProfesor(ModeloProfesor nuevoProfesor)
        {
            return objNegocioProfesor.NegocioReadCreateProfesor(nuevoProfesor);
        }



    }
}
