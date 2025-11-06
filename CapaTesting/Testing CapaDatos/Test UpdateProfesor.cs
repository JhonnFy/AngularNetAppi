using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Test_UpdateProfesor
    {
        [TestMethod]
        public void TestUpdateProfesor()
        {
            try
            {
                ModeloProfesor objUpProfesor = new ModeloProfesor
                {
                    id = 1111,
                    nombre = "Test Andres Daniel Sanchez Rojas:)"
                };

                CrudAngularNetAppi sqlUpdate = new CrudAngularNetAppi();
                bool resultado = sqlUpdate.UpdateProfesor(objUpProfesor);

                Assert.IsTrue(resultado, "[Test Update Profesor] La actualización del registro fue exitosa.");
                Console.WriteLine("[Test Update Profesor] La actualización del registro fue exitosa");
            }
            catch (Exception ex)
            {
                Assert.Fail($"[Test Update Profesor] La prueba falló con una excepción: {ex.Message}");
            }
        }

    }
}
