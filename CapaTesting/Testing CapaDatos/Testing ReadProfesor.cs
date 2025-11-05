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
    public class Testing_ReadProfesor
    {
        [TestMethod]
        public void TestReadProfesor()
        {
            try
            {
                CrudAngularNetAppi objReadOrigen = new CrudAngularNetAppi();
                var listaProfesores = objReadOrigen.ReadProfesor();


                Assert.IsNotNull(listaProfesores, "El resultado no debe ser nulo.");
                Assert.IsInstanceOfType(listaProfesores, typeof(List<ModeloProfesor>),
                    "El resultado debe ser una lista de ModeloProfesor.");
                Assert.IsTrue(listaProfesores.Count > 0, "La lista debe contener al menos un registro.");

                Console.WriteLine($"Cantidad de registros devueltos: {listaProfesores.Count}");

            }
            catch (Exception ex)
            {
                Assert.Fail($"La prueba falló con una excepción: {ex.Message}");
            }
        }
    }
}
