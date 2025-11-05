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
                var listaEstudiantes = objReadOrigen.ReadEstudiante();


                Assert.IsNotNull(listaEstudiantes, "El resultado no debe ser nulo.");
                Assert.IsInstanceOfType(listaEstudiantes, typeof(List<ModeloEstudiante>),
                    "El resultado debe ser una lista de ModeloEstudiante.");
                Assert.IsTrue(listaEstudiantes.Count > 0, "La lista debe contener al menos un registro.");

                Console.WriteLine($"Cantidad de registros devueltos: {listaEstudiantes.Count}");

            }
            catch (Exception ex)
            {
                Assert.Fail($"La prueba falló con una excepción: {ex.Message}");
            }
        }
    }
}
