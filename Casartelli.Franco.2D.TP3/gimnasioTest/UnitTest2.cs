using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using Excepciones;
using EntidadesAbstractas;
namespace gimnasioTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Instructor instructor = new Instructor(5, "Humberto", "Velez", "90000000", Persona.ENacionalidad.Argentino);
                Assert.Fail();
            }
            catch (Exception a)
            {
                Assert.IsInstanceOfType(a, typeof(NacionalidadInvalidaException));
            }
        }
    }
}
