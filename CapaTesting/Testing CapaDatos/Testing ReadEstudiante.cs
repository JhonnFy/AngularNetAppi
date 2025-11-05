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
    public class Testing_ReadEstudiante
    {
        [TestMethod]
        public void TestReadEstudiante()
        {
            try
            {
                CrudAngularNetAppi objReadOrigen = new CrudAngularNetAppi();
                var varobjReadOrigen = objReadOrigen.ReadEstudiante();

                Assert.IsNotNull(varobjReadOrigen, "El resultado no debe ser nulo.");
                Assert.IsInstanceOfType(varobjReadOrigen, typeof(List<ModeloEstudiante>),
    "El resultado debe ser una lista de ModeloCodigoDeBarrasOrigen.");
                Assert.IsTrue(varobjReadOrigen.Count > 0, "La lista debe contener al menos un registro.");

                Console.WriteLine($"Cantidad de registros devueltos: {varobjReadOrigen.Count}");

            }
            catch (Exception ex)
            {
                Assert.Fail($"La prueba falló con una excepción: {ex.Message}");
            }
        }
    }
}
