using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace EntidadesAbstractas
{
    [Serializable]

    public abstract class Persona
    {
        #region ATRIBUTOS
        public enum ENacionalidad{Argentino, Extranjero}

        private string _nombre;

        private ENacionalidad _nacionalidad;

        private string _apellido;

        private int _dni;
#endregion

        #region PROPIEDADES
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set {
                this._apellido = ValidarNombreApellido(value);
                }
        }

        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public int DNI
        {
            get { return _dni; }
            set {
                this._dni = ValidarDni(this._nacionalidad, value);
                }
        }

        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDni(this._nacionalidad, value);
            }
        }
#endregion

        #region METODOS
        public Persona()
        {

        }
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno;
            if (dato >= 1 && dato <= 89999999 && nacionalidad == ENacionalidad.Argentino)
            {
                retorno = dato;
            }
            else if (ENacionalidad.Extranjero == nacionalidad && dato > 89999999)
            {
                retorno = dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
            return retorno;
        }

        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = -1;
            int retorno = 0;
            dato = dato.Replace(".", "");
            if (int.TryParse(dato, out aux))
            {
                return Persona.ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        private static string ValidarNombreApellido(string dato)
        {
            string aux = dato;
            int length = dato.Length;
            int cont = 0;
            foreach (char a in aux)
            {
                if (char.IsLetter(a))
                {
                    cont++;
                }
            }
            if (length == cont)
            {
                aux = dato;
            }
            
            return aux;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", "+ this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);
            return sb.ToString();
        }
        #endregion

        #region CONSTRUCTORES
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre: nombre, apellido: apellido, nacionalidad: nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre: nombre, apellido: apellido, nacionalidad: nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

    }
}
