using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDatos;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Testing_ReadEstudianteId
    {
        [TestMethod]
        public void TestReadEstudianteId()
        {
            try
            {
                CrudAngularNetAppi objReadOrigen = new CrudAngularNetAppi();
                var listaEstudiantes = objReadOrigen.ReadEstudianteId(1307);

                Assert.IsNotNull(listaEstudiantes, "No se encontró registro con la CC proporcionada.");
                Assert.IsTrue(listaEstudiantes.Count > 0, "La lista no debería estar vacía.");
                Assert.AreEqual(1307, listaEstudiantes.First().id,
                "La CC del registro encontrado no coincide con la búsqueda.");

                Console.WriteLine($"Registro Encontrado: {listaEstudiantes.First().nombre}, CC: {listaEstudiantes.First().id}");
            }
            catch (Exception ex)
            {
                Assert.Fail("[Testing TestReadEstudianteId]Se ha producido una excepción durante la prueba: " + ex.Message);
            }
        }
    }
}