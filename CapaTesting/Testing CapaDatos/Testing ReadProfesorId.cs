using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Testing_ReadProfesorId
    {
        [TestMethod]
        public void TestReadProfesorId()
        {
            try
            {
                CrudAngularNetAppi objReadOrigen = new CrudAngularNetAppi();
                var listaProfesores = objReadOrigen.ReadProfesorId(9972);

                Assert.IsNotNull(listaProfesores, "No se encontró registro con la CC proporcionada.");
                Assert.IsTrue(listaProfesores.Count > 0, "La lista no debería estar vacía.");
                Assert.AreEqual(9972, listaProfesores.First().id,
                "La CC del registro encontrado no coincide con la búsqueda.");

                Console.WriteLine($"Registro Encontrado: {listaProfesores.First().nombre}, CC: {listaProfesores.First().id}");
            }
            catch (Exception ex)
            {
                Assert.Fail("[Testing TestReadProfesorId]Se ha producido una excepción durante la prueba: " + ex.Message);
            }
        }
    }
}
