using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting
{
    [TestClass]
    public class Test_CreateEstudiante
    {
        [TestMethod]
        public void TestCreateEstudiante()
        {
            try
            {
                ModeloEstudiante nuevoRegistro = new ModeloEstudiante
                {
                    id = 1023,
                    nombre = "Estudiante Test"
                };

                CrudAngularNetAppi objCreate = new CrudAngularNetAppi();
                bool resultado = objCreate.CreateEstudiante(nuevoRegistro);

                Assert.IsTrue(resultado, "[Test Create Estudiante] La creación del registro fue exitosa.");
                Console.WriteLine("[****].[OK].[Test Create Estudiante] La creación del registro fue exitosa.");

            }
            catch (Exception ex)
            {
                Assert.Fail($"[Test Create Estudiante] La prueba falló con una excepción: + {ex.Message}");
                Console.WriteLine($"[ERROR].[Test Create Estudiante] La prueba falló con una excepción: +  {ex.Message}");
            }
        }
    }
}
