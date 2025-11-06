using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaControlador
{
    public class CapaControladorNota
    {
        private CapaNegocio_Nota objNegocioNota;


        public CapaControladorNota()
        {
            objNegocioNota = new CapaNegocio_Nota();
        }

        public List<ModeloNota> ControladorReadNota()
        {
            return objNegocioNota.NegocioReadNota();
        }

        public List<ModeloNota> ControladorReadNotaId(int id)
        {
            return objNegocioNota.NegocioReadNotaId(id);
        }

        public bool ControladorCreateNota(ModeloNota nuevaNota)
        {
            return objNegocioNota.NegocioCreateNota(nuevaNota);       
        }

    }
}
