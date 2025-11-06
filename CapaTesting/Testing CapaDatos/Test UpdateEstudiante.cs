using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting
{
    [TestClass]
    public class Test_UpdateEstudiante
    {
        [TestMethod]
        public void TestUpdateEstudiante()
        {
            try
            {
                ModeloEstudiante objUpdateEstudiante = new ModeloEstudiante
                {
                    id = 1307,
                    nombre = "Test Natalia Mariana Morales Sanchez V1"
                };

                CrudAngularNetAppi sqlUpdate = new CrudAngularNetAppi();
                bool resultado = sqlUpdate.UpdateEstudiante(objUpdateEstudiante);

                Assert.IsTrue(resultado, "[Test Update Estudiante] La actualización del registro fue exitosa.");
                Console.WriteLine("[Test Update Estudiante] La actualización del registro fue exitosa");
            }
            catch (Exception ex)
            {
                Assert.Fail($"[Test Update Estudiante] La prueba falló con una excepción: {ex.Message}");
            }
        }

    }
}
