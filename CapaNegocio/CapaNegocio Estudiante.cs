using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public List<ModeloProfesor> NegocioReadProfesor()
        {
            var lista = crudDatos.ReadProfesor();
            foreach (var profesor in lista)
            {
                profesor.nombre = ReglasNegocioHelper.HelperNombreProfesores(profesor.nombre);
                profesor.nombre = ReglasNegocioHelper.HelperOmitirAcentos(profesor.nombre);
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

        public List<ModeloProfesor> NegocioReadProfesorId(int id)
        {
            var lista = crudDatos.ReadProfesorId(id);

            foreach (var profesorId in lista)
            {
                profesorId.nombre = ReglasNegocioHelper.HelperNombreProfesores(profesorId.nombre);
                profesorId.nombre = ReglasNegocioHelper.HelperOmitirAcentos(profesorId.nombre);
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

        public bool NegocioReadCreateProfesor(ModeloProfesor nuevoProfesor)
        {
            if (nuevoProfesor == null)
                throw new ArgumentNullException(nameof(nuevoProfesor));

            nuevoProfesor.nombre = ReglasNegocioHelper.HelperNombreProfesores(nuevoProfesor.nombre);
            nuevoProfesor.nombre = ReglasNegocioHelper.HelperOmitirAcentos(nuevoProfesor.nombre);

            return crudDatos.CreateProfesor(nuevoProfesor);
        }

        public bool NegocioUpdateEstudiante(ModeloEstudiante actualizaEstudiante)
        {
            if (actualizaEstudiante == null)
                throw new ArgumentException(nameof(actualizaEstudiante));

            actualizaEstudiante.nombre = ReglasNegocioHelper.HelperNombresEstudiantes(actualizaEstudiante.nombre);
            actualizaEstudiante.nombre = ReglasNegocioHelper.HelperOmitirAcentos(actualizaEstudiante.nombre);

            return crudDatos.UpdateEstudiante(actualizaEstudiante);
        }

        public bool NegocioUpdateProfesor(ModeloProfesor actualizarProfesor)
        {
            if (actualizarProfesor == null)
                throw new ArgumentException(nameof(actualizarProfesor));

            actualizarProfesor.nombre = ReglasNegocioHelper.HelperNombreProfesores(actualizarProfesor.nombre);
            actualizarProfesor.nombre = ReglasNegocioHelper.HelperOmitirAcentos(actualizarProfesor.nombre);

            return crudDatos.UpdateProfesor(actualizarProfesor);
        }

        public bool NegocioEliminarEstudiante(int idEstudiante)
        {
            var listaNotas = crudDatos.ReadNota();
            if (!ReglasNegocioHelper.HelperEliminarEstudiantes(idEstudiante, listaNotas))
            {
                Console.WriteLine("[*****][Negocio].[No se puede eliminar el estudiante, tiene notas asociadas]");
                Debug.WriteLine("[*****][Negocio].[No se puede eliminar el estudiante, tiene notas asociadas].");
                return false;
            }

            var estudiante = new CapaDatos.ModeloEstudiante { id = idEstudiante };
            return crudDatos.DeleteEstudiante(estudiante);
        }


    }
}
