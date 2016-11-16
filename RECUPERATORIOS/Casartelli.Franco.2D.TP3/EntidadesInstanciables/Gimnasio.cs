using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    
    [XmlInclude(typeof(Persona))]
    public class Gimnasio
    {
        public enum EClases { Natacion, Pilates, Yoga, CrossFit }

        #region ATRIBUTOS
        private List<Alumno> _alumno;

        public List<Alumno> Alumno
        {
            get { return _alumno; }
        }

        private List<Instructor> _instructores;

        public List<Instructor> Instructores
        {
            get { return _instructores; }
        }

        private List<Jornada> _jornada;

        public List<Jornada> Jornada
        {
            get { return _jornada; }
        }
        #endregion

        #region PROPIEDADES
        public Jornada this[int i] 
        {
            get{ return this._jornada[i]; }
        }
        #endregion


        #region CONSTRUCTORES

        public Gimnasio()
        {
            this._alumno = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        public static bool Guardar(Gimnasio gim)
        {
            try
            {
                Xml<Gimnasio> asd = new Xml<Gimnasio>();
                asd.Guardar("../../../Gimnasio.xml", gim);                
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

        #endregion


        #region SOBRECARGAS

        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno b in g._alumno)
            {
                if (a == b)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool retorno = false;
            foreach (Instructor a in g._instructores)
            {
                if (a == i)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor b in g._instructores)
            {
                if (b == clase)
                {
                    return b;
                }
            }
            throw new SinInstructorException();
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            foreach (Instructor a in g._instructores)
            {
                if (a != clase)
                {
                    return a;
                }
            }
            throw new SinInstructorException();
        }

        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {

            for (int i = 0; i < g._alumno.Count; i++)
            {
                if (g._alumno[i] == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
                g._alumno.Add(a);
            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            for (int a = 0; a < g._instructores.Count; a++)
            {
                if (g._instructores[a] == i)
                {
                    throw new SinInstructorException();
                }
            }
            g._instructores.Add(i);
            return g;
        }

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);
            foreach (Alumno a in g._alumno)
            {
                if (a == clase)
                {
                    j += a;
                }
            }
            g._jornada.Add(j);
            return g;
        }

        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada a in gim._jornada)
            {
                sb.AppendLine(a.ToString());
                sb.AppendLine("<--------------------------------------------------->");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
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
