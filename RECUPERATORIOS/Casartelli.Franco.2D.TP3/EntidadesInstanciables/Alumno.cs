using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta{Deudor, AlDia, MesPrueba};

        #region ATRIBUTOS
        private Gimnasio.EClases _ClaseQueToma;

        public Gimnasio.EClases ClaseQueToma
        {
            get { return _ClaseQueToma; }
        }

        private EEstadoCuenta _estadoCuenta;

        public EEstadoCuenta EstadoCuenta
        {
            get { return _estadoCuenta; }
        }

        #endregion

        #region CONSTRUCTORES
        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id : id, nombre : nombre, apellido : apellido, dni : dni, nacionalidad : nacionalidad)
        {
            this._ClaseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id: id, nombre: nombre, apellido: apellido, dni: dni, nacionalidad: nacionalidad, claseQueToma: claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region SOBRECARGAS
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._ClaseQueToma.ToString();
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            bool retorno = false;
            if (a._estadoCuenta != EEstadoCuenta.Deudor && a._ClaseQueToma == clase)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            return !(a == clase);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
