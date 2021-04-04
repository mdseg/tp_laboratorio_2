using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double output = 0;
            string operadorInput = ValidarOperador(operador[0]);
            switch(operadorInput)
            {
                case "+":
                    output = numeroUno + numeroDos;
                    break;
                case "-":
                    output = numeroUno - numeroDos;
                    break;
                case "*":
                    output = numeroUno * numeroDos;
                    break;
                case "/":
                    output = numeroUno / numeroDos;
                    break;
            }
            return output;
        }

        static string ValidarOperador(char operador)
        {
            string output = "+";
            switch (operador)
            {
                case '-':
                case '*':
                case '/':
                    output = operador.ToString();
                    break;
            }
            return output;
        }
    }
}
