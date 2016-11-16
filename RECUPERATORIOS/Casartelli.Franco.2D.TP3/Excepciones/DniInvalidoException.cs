using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;
        public DniInvalidoException()
        {
            
        }
        public DniInvalidoException(Exception e)
        {
            this.mensajeBase = e.Message;
        }
        public DniInvalidoException(string message)
        {
            this.mensajeBase = message;
        }
        public DniInvalidoException(string message, Exception e)
        {
            this.mensajeBase = message + " " + e.Message;
        }
    }
}
