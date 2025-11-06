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

        public List<ModeloEstudiante> ReadEstudiante()
        {
            var lista = crudDatos.ReadEstudiante();
            foreach (var estudiante in lista)
            {
                estudiante.nombre = ReglasNegocioHelper.HelperNombresEstudiantes(estudiante.nombre);
                estudiante.nombre = ReglasNegocioHelper.HleperOmitirAcentos(estudiante.nombre);
            }

            return lista;
        }

    }
}
