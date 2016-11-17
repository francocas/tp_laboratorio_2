using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace EntidadesInstanciables
{
    [Serializable]

    public class Instructor : PersonaGimnasio
    {
        #region ATRIBUTOS
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region CONSTRUCTORES
        static Instructor()
        {
            _random = new Random();
        }
        public Instructor()
        {

        }
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id: id, nombre: nombre, apellido: apellido, dni: dni, nacionalidad: nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }

        private void _randomClases()
        {
            int r;
            for (int i = 0; i < 2; i++)
            {
                r = _random.Next(1, 5);
                switch (r)
                {
                    case 1:
                        this._clasesDelDia.Enqueue(Gimnasio.EClases.CrossFit);
                        break;
                    case 2:
                        this._clasesDelDia.Enqueue(Gimnasio.EClases.Natacion);
                        break;
                    case 3:
                        this._clasesDelDia.Enqueue(Gimnasio.EClases.Pilates);
                            break;
                    case 4:
                        this._clasesDelDia.Enqueue(Gimnasio.EClases.Yoga);
                        break;
                }
            }
        }
        #endregion

        #region SOBRECARGAS
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA ");
            foreach (Gimnasio.EClases a in this._clasesDelDia)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            
            return base.MostrarDatos() + ParticiparEnClase();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        public static bool operator ==(Instructor i, Gimnasio.EClases clases)
        {
            bool retorno = false;
            foreach (Gimnasio.EClases a in i._clasesDelDia)
            {
                if (a == clases)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clases)
        {
            return !(i == clases);
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
