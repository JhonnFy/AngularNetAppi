using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Testing_CreateProfesor
    {
        [TestMethod]
        public void TestCreateProfesor()
        {
            try
            {
                ModeloProfesor nuevoRegistro = new ModeloProfesor
                {
                    id = 9999,
                    nombre = "Profesor Test"
                };

                CrudAngularNetAppi objCreate = new CrudAngularNetAppi();
                bool resultado = objCreate.CreateProfesor(nuevoRegistro);

                Assert.IsTrue(resultado, "[Test Create Profesor] La creación del registro fue exitosa.");
                Console.WriteLine("[****].[OK].[Test Create Profesor] La creación del registro fue exitosa.");

            }
            catch (Exception ex)
            {
                Assert.Fail($"[Test Create Profesor] La prueba falló con una excepción: + {ex.Message}");
                Console.WriteLine($"[ERROR].[Test Create Profesor] La prueba falló con una excepción: +  {ex.Message}");
            }
        }
    }
}
