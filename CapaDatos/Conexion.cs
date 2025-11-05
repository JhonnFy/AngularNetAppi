using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        private readonly string cadenaConexion;

        public Conexion()
        {
            try
            {

            }catch(Exception e)
            {
                Debug.WriteLine("[****].[ERROR] [Capa Datos Conexion].[Cadenda Conexion] " + e.Message);
                throw new Exception("ERROR [Capa Datos Conexion].[Cadenda Conexion] " + e.Message);
            }
        }

    }
}
