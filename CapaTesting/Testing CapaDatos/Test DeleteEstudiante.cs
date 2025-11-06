using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Test_DeleteEstudiante
    {
        [TestMethod]
        public void TestDeleteEstudiante()
        {
            try
            {
                ModeloEstudiante borrarRegistro = new ModeloEstudiante
                {
                    id = 1307
                };

                CrudAngularNetAppi objDelete = new CrudAngularNetAppi();
                bool resultado = objDelete.DeleteEstudiante(borrarRegistro);

                Assert.IsTrue(resultado, "[Delete Estudiante] El registro fue eliminado correctamente.");
                Console.WriteLine("[Delete Estudiante] El registro fue eliminado correctamente.");

            }
            catch (Exception ex)
            {
                Assert.Fail($"[Test Delete Estudiante] La prueba falló con una excepción: {ex.Message}");
            }
        }
    }
}
