using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Test_UpdateNota
    {
        [TestMethod]
        public void TestUpdateNotas()
        {
            try
            {
                ModeloNota objUpdateNota = new ModeloNota
                {
                    id = 1,
                    nombre = "Corte Recuperacion TEST",
                    valor = 4
                };

                CrudAngularNetAppi sqlUpdate = new CrudAngularNetAppi();
                bool resultado = sqlUpdate.UpdateNotas(objUpdateNota);

                Assert.IsTrue(resultado, "[Test Update Notas] La actualización del registro fue exitosa.");
                Console.WriteLine("[Test Update Notas] La actualización del registro fue exitosa");
            }
            catch (Exception ex)
            {
                Assert.Fail($"[Test Update Notas] La prueba falló con una excepción: {ex.Message}");
            }
        }

    }
}
