using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    [Serializable]

    public abstract class PersonaGimnasio : Persona
    {
        #region ATRIBUTOS
        private int _identificador;

        public int Identificador
        {
            get { return _identificador; }
        }
        #endregion

        #region CONSTRUCTORES
        public PersonaGimnasio()
        {

        }
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre: nombre, apellido: apellido, dni : dni, nacionalidad: nacionalidad)
        
        {
            this._identificador = id;
        }
        #endregion

        #region SOBRECARGAS
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NUMERO: " + this._identificador.ToString());
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
        
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (this.GetType() == obj.GetType())
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) && (pg1._identificador == pg2._identificador || pg1.DNI == pg2.DNI))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
