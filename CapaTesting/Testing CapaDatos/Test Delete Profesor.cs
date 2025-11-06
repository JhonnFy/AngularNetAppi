using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Test_Delete_Profesor
    {
        [TestMethod]
        public void TestDeleteProfesor()
        {
            try
            {
                ModeloProfesor borrarRegistro = new ModeloProfesor
                {
                    id = 8979
                };

                CrudAngularNetAppi objDelete = new CrudAngularNetAppi();
                bool resultado = objDelete.DeleteProfesor(borrarRegistro);

                Assert.IsTrue(resultado, "[Delete Profesor] El registro fue eliminado correctamente.");
                Console.WriteLine("[Delete Profesor] El registro fue eliminado correctamente.");

            }
            catch (Exception ex)
            {
                Assert.Fail($"[Test Delete Profesor] La prueba falló con una excepción: {ex.Message}");
            }
        }
    }
}
