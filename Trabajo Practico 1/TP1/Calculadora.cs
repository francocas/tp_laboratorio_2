using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Calculadora
    {
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double retorno = 0;
            switch (operador)
            { 
                case "+":
                    retorno = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    retorno = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    retorno = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    retorno = numero1.getNumero() / numero2.getNumero();
                    if (numero1.getNumero() == 0 && numero2.getNumero() == 0 )
                    {
                        retorno = 0;
                    }
                    break;
            }
            return retorno;
        }
        public static string validarOperador(string operador)
        {
            if (operador == "")
            {
                operador = "+";
            }
            return operador;
        }
    }
}
