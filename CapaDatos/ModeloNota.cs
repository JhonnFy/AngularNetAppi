using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ModeloNota
    {
        public int idIdentity { get; set; }
        public int id {  get; set; }
        public string nombre { get; set; }
        public int idProfesor { get; set; }
        public int idEstudiante { get; set; }
        public decimal valor { get; set; }
    }
}
