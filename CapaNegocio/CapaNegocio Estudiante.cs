using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    public class CapaNegocio_Estudiante
    {

        private CrudAngularNetAppi crudDatos = new CrudAngularNetAppi();

        public List<ModeloEstudiante> NegocioReadEstudiante()
        {
            var lista = crudDatos.ReadEstudiante();
            foreach (var estudiante in lista)
            {
                estudiante.nombre = ReglasNegocioHelper.HelperNombresEstudiantes(estudiante.nombre);
                estudiante.nombre = ReglasNegocioHelper.HelperOmitirAcentos(estudiante.nombre);
            }

            return lista;
        }

        public List<ModeloEstudiante> NegocioReadEstudianteId(int id)
        {
            var lista = crudDatos.ReadEstudianteId(id);

            foreach (var estudienteId in lista)
            {
                estudienteId.nombre = ReglasNegocioHelper.HelperNombresEstudiantes(estudienteId.nombre);
                estudienteId.nombre = ReglasNegocioHelper.HelperOmitirAcentos(estudienteId.nombre);
            }

            return lista;
                
        }

    }
}
