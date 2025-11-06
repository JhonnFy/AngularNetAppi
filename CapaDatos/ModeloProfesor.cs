using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloProfesor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        
        public ModeloProfesor()
        {
            id = 0;
            nombre = string.Empty;
        }
    }
}
