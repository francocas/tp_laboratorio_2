using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
namespace gimnasioTest
{
    [TestClass]
    public class UnitTest4
    {
        Gimnasio g = new Gimnasio();

        [TestMethod]
        public void ValidarListaInstructorNula()
        {
            Assert.IsNotNull(g.Instructores);
        }
    }
}
