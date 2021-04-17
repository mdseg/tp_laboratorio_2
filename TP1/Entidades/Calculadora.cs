using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operación correspondiente a la calculadora validando el operador ingresado
        /// </summary>
        /// <param name="numeroUno"> Primer número ingresado </param>
        /// <param name="numeroDos"> Segundo número ingresado </param>
        /// <param name="operador"> Operador</param>
        /// <returns> el resultado de la operacion </returns>
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double output = 0;

            if(operador.Equals(""))
            {
                operador = " ";
            }

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
            return Math.Round(output,2);
        }
        /// <summary>
        /// Valida el char ingresado y retorna el string correspondiente a la
        /// operación indicada. Por defecto se indicará la suma (+)
        /// </summary>
        /// <param name="operador">char correspondiente al operador ingresado</param>
        /// <returns> Operador validado </returns>
        private static string ValidarOperador(char operador)
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
