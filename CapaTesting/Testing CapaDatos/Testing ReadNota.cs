using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Testing_ReadNota
    {
        [TestMethod]
        public void TestReadNota()
        {

            try
            {
                CrudAngularNetAppi objReadOrigen = new CrudAngularNetAppi();
                var listaNotas = objReadOrigen.ReadNota();


                Assert.IsNotNull(listaNotas, "El resultado no debe ser nulo.");
                Assert.IsInstanceOfType(listaNotas, typeof(List<ModeloNota>),
                    "El resultado debe ser una lista de ModeloNota.");
                Assert.IsTrue(listaNotas.Count > 0, "La lista debe contener al menos un registro.");

                Console.WriteLine($"Cantidad de registros devueltos: {listaNotas.Count}");

            }
            catch (Exception ex)
            {
                Assert.Fail($"La prueba falló con una excepción: {ex.Message}");
            }
        }
    }
}
