using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting
{
    [TestClass]
    public class Test_CreateNota
    {
        [TestMethod]
        public void TestCreateNota()
        {
            try
            {
                ModeloNota nuevoRegistro = new ModeloNota
                {
                    id = 4445,
                    nombre = "Nota 4445",
                    idProfesor = 8979,
                    idEstudiante = 1307,
                    valor = 416
                };

                CrudAngularNetAppi objCreate = new CrudAngularNetAppi();
                bool resultado = objCreate.CreateNota(nuevoRegistro);

                Assert.IsTrue(resultado, "[Test Create Nota] La creación del registro fue exitosa.");
                Console.WriteLine("[****].[OK].[Test Create Nota] La creación del registro fue exitosa.");

            }
            catch (Exception e)
            {
                Assert.Fail($"[Test Create Nota] La prueba falló con una excepción: + {e.Message}");
                Console.WriteLine($"[ERROR].[Test Create Nota] La prueba falló con una excepción: +  {e.Message}");
            }
        }
    }
}
