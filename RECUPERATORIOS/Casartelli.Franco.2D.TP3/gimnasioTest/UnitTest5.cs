using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
namespace gimnasioTest
{
    [TestClass]
    public class UnitTest5
    {
        Gimnasio g = new Gimnasio();
        [TestMethod]
        public void ValidarListaAlumnoNula()
        {
            Assert.IsNotNull(g.Alumno);
        }
    }
}
