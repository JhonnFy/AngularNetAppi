using CapaDatos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Profesor
    {
        private CrudAngularNetAppi crudDatos = new CrudAngularNetAppi();

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

        public bool NegocioReadCreateProfesor(ModeloProfesor nuevoProfesor)
        {
            if (nuevoProfesor == null)
                throw new ArgumentNullException(nameof(nuevoProfesor));

            nuevoProfesor.nombre = ReglasNegocioHelper.HelperNombreProfesores(nuevoProfesor.nombre);
            nuevoProfesor.nombre = ReglasNegocioHelper.HelperOmitirAcentos(nuevoProfesor.nombre);

            return crudDatos.CreateProfesor(nuevoProfesor);
        }

        public bool NegocioUpdateProfesor(ModeloProfesor actualizarProfesor)
        {
            if (actualizarProfesor == null)
                throw new ArgumentException(nameof(actualizarProfesor));

            actualizarProfesor.nombre = ReglasNegocioHelper.HelperNombreProfesores(actualizarProfesor.nombre);
            actualizarProfesor.nombre = ReglasNegocioHelper.HelperOmitirAcentos(actualizarProfesor.nombre);

            return crudDatos.UpdateProfesor(actualizarProfesor);
        }

        public bool NegocioEliminarProfesor(int idProfesor)
        {
            var listaNotas = crudDatos.ReadNota();
            if (!ReglasNegocioHelper.HelperEliminarProfesor(idProfesor, listaNotas))
            {
                Console.WriteLine("[*****][Negocio].[No se puede eliminar el profesor, tiene notas asociadas]");
                Debug.WriteLine("[*****][Negocio].[No se puede eliminar el profesor, tiene notas asociadas].");
                return false;
            }

            var profesor = new CapaDatos.ModeloProfesor { id = idProfesor };
            return crudDatos.DeleteProfesor(profesor);
        }

    }
}
