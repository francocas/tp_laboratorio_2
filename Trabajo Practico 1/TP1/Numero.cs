using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Numero
    {
        double numero;
        private static double validarOperador(string operador)
        {
            double numeroConvert;
            double.TryParse(operador, out numeroConvert);
            return numeroConvert;
        }
        private void setNumero(string numero)
        { 
            this.numero = Numero.validarOperador(numero);
        }
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            this.setNumero(numero);
        }
        public double getNumero()
        {
            return this.numero;
        }
    }
}
