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

        public bool NegocioReadCreateEstudiante(ModeloEstudiante nuevoEstudiante)
        {
            if (nuevoEstudiante == null)
                throw new ArgumentNullException(nameof(nuevoEstudiante));

            nuevoEstudiante.nombre = ReglasNegocioHelper.HelperNombresEstudiantes(nuevoEstudiante.nombre);
            nuevoEstudiante.nombre = ReglasNegocioHelper.HelperOmitirAcentos(nuevoEstudiante.nombre);

            return crudDatos.CreateEstudiante(nuevoEstudiante);
        }

        public bool NegocioUpdateEstudiante(ModeloEstudiante actualizaEstudiante)
        {
            if (actualizaEstudiante == null)
                throw new ArgumentException(nameof(actualizaEstudiante));

            actualizaEstudiante.nombre = ReglasNegocioHelper.HelperNombresEstudiantes(actualizaEstudiante.nombre);
            actualizaEstudiante.nombre = ReglasNegocioHelper.HelperOmitirAcentos(actualizaEstudiante.nombre);

            return crudDatos.UpdateEstudiante(actualizaEstudiante);
        }

    }
}
