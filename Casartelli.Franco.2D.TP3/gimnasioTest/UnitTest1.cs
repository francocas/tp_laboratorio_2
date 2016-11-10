using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
namespace gimnasioTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Gimnasio hola = new Gimnasio();
            Assert.IsNotNull(hola.Alumno, null);
        }
    }
}
