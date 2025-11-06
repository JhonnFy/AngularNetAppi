using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class ModeloEstudiante
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public ModeloEstudiante()
        {
            id = 0;
            nombre = string.Empty;
        }
    }
}
