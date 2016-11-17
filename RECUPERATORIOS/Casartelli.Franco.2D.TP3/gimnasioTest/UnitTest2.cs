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
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        [TestMethod]
        
        public void ValidacionDNI()
        {

                Instructor instructor = new Instructor(5, "Humberto", "Velez", "asd", Persona.ENacionalidad.Argentino);
        }
    }
}
