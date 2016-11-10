using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> _alumnos;

        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        private Gimnasio.EClases _clase;

        public Gimnasio.EClases Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }

        private Instructor _instructor;

        public Instructor Instructor
        {
            get { return _instructor; }
            set { _instructor = value; }
        }

#endregion

        #region METODOS
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Gimnasio.EClases clase, Instructor instructor):this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }  
        public static bool Guardar(Jornada jor)
        {
            try
            {
                Texto asd = new Texto();
                asd.Guardar("../../../Jornada.txt", jor.ToString());
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
        #endregion

        #region SOBRECARGAS
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno b in j._alumnos)
            {
                if (a == b)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {

            if (j != a)
            {
                j._alumnos.Add(a);
                return j;
            }
            throw new AlumnoRepetidoException();
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.AppendLine("CLASE DE: " + this._clase.ToString());
            sb.AppendLine("POR: " + this._instructor.ToString());
            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
            
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        #endregion
    }
}
