using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using Excepciones;
using EntidadesAbstractas;
namespace gimnasioTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidacionDNI2()
        {
            Alumno test = new Alumno(1, "Franco", "Casartelli", "12345678", Persona.ENacionalidad.Extranjero, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);     
        }
    }
}
