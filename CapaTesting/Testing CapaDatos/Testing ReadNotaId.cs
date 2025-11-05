using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapaTesting.Testing_CapaDatos
{
    [TestClass]
    public class Testing_ReadNotaId
    {
        [TestMethod]
        public void TestReadNotaId()
        {
            try
            {
                CrudAngularNetAppi objReadOrigen = new CrudAngularNetAppi();
                var listaNotas = objReadOrigen.ReadNotaId(1);

                Assert.IsNotNull(listaNotas, "No se encontró registro con la Nota proporcionada.");
                Assert.IsTrue(listaNotas.Count > 0, "La lista no debería estar vacía.");
                Assert.AreEqual(1, listaNotas.First().id,
                "La Nota del registro encontrado no coincide con la búsqueda.");

                Console.WriteLine($"Nota Encontrada: {listaNotas.First().nombre}, Id: {listaNotas.First().id}");
                Console.WriteLine($"idProfesor: {listaNotas.First().idProfesor}");
                Console.WriteLine($"idEstudiante: {listaNotas.First().idEstudiante}");
                Console.WriteLine($"valor: {listaNotas.First().valor}");
            }
            catch (Exception ex)
            {
                Assert.Fail("[Testing TestReadNotaId] Se ha producido una excepción durante la prueba: " + ex.Message);
            }
        }
    }
}