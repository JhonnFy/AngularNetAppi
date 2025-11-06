using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Nota
    {
        private CrudAngularNetAppi crudDatos = new CrudAngularNetAppi();

        public List<ModeloNota> NegocioReadNota()
        {
            var lista = crudDatos.ReadNota();
            foreach (var nota in lista)
            {
                nota.nombre = ReglasNegocioHelper.HelperNombreNota(nota.nombre);
                nota.valor = ReglasNegocioHelper.HelperAjustarValoresNotas(nota.valor);
            }
            return lista;
        }

        public List<ModeloNota> NegocioReadNotaId(int id)
        {
            var lista = crudDatos.ReadNotaId(id);

            foreach (var notaId in lista)
            {
                notaId.nombre = ReglasNegocioHelper.HelperNombreNota(notaId.nombre);
                notaId.valor = ReglasNegocioHelper.HelperAjustarValoresNotas(notaId.valor);
            }

            return lista;
        }

        public bool NegocioCreateNota(ModeloNota nuevaNota)
        {
            if (nuevaNota == null)
                throw new ArgumentNullException(nameof(nuevaNota));

            nuevaNota.nombre = ReglasNegocioHelper.HelperNombreNota(nuevaNota.nombre);
            nuevaNota.valor = ReglasNegocioHelper.HelperAjustarValoresNotas(nuevaNota.valor);

            return crudDatos.CreateNota(nuevaNota);
        }

        public bool NegocioUpdateNota(ModeloNota actualizarNota)
        {
            if (actualizarNota == null)
                throw new ArgumentException(nameof(actualizarNota));

            actualizarNota.nombre = ReglasNegocioHelper.HelperNombreNota(actualizarNota.nombre);
            actualizarNota.valor = ReglasNegocioHelper.HelperAjustarValoresNotas(actualizarNota.valor);

            return crudDatos.UpdateNotas(actualizarNota);
        }

    }
}
