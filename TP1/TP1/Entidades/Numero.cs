using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto, inicializa el atributo numero en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que recibe un parámetro del tipo double para inicializar su atributo número
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        ///Constructor que recibe un parámetro del tipo string para inicializar su atributo número
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            setNumero(numero);
        }
        /// <summary>
        /// Método que valida un número para asignarlo al campo número
        /// </summary>
        /// <param name="numero"></param>
        public void setNumero(string numero)
        {
            double doubleNumero = ValidarNumero(numero);
            if(doubleNumero != 0)
            {
                this.numero = doubleNumero;
            }
        }
        /// <summary>
        /// Recibe un tipo de dato del tipo string y valida que pueda convertirse
        /// en double para despues retornar el valor como float.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Valor del tipo float con número validado</returns>
        private double ValidarNumero(string strNumero)
        {
            double output = 0;

            if(Double.TryParse(strNumero, out double doubleNumero))
            {
                output = doubleNumero;
            }
            
            return output;  
        }
        /// <summary>
        /// Recibe una cadena del tipo string y valida que se corresponda a un número binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> retorna true si es binario y false si no es binario</returns>
        private static bool EsBinario(string binario)
        {
            bool output = true;
            char[] charBinario;
            charBinario = binario.ToCharArray();

            if(charBinario.Length > 0)
            {
                for (int i = 0; i < charBinario.Length; i++)
                {
                    if (charBinario[i] != '1' && charBinario[i] != '0')
                    {
                        output = false;
                    }
                }
            }
            else
            {
                output = false;
            }          
            return output;
        }
        /// <summary>
        /// Recibe un string, valida que sea binario y lo convierte
        /// a un string que representa a ese valor en sistema decimal.
        /// </summary>
        /// <param name="binario">string binario a ser convertido en string decimal</param>
        /// <returns>string decimal con el binario convertido</returns>
        public static string BinarioDecimal(string binario)
        {
            string output = "";
            string inputInvertido = "";
            int resultadoParcial = 0;
            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    inputInvertido = binario[i] + inputInvertido;
                }
                for (int j = 0; j < inputInvertido.Length; j++)
                {
                    if (inputInvertido[j] == '1')
                    {
                        resultadoParcial += (int)(Math.Pow(2, j));
                    }
                }
                output = resultadoParcial.ToString();
            }
            else
            {
                output = "Valor inválido";
            }
            return output;
        }
        /// <summary>
        /// Recibe un string e intenta convertirlo en double para despues
        /// convertirlo en Binario llamando al método DecimalBinario(), en caso de que no
        /// se pueda convertir a double se emite un mensaje de error.
        /// </summary>
        /// <param name="numero">string con el valor a convertir</param>
        /// <returns>string con el número binario convertido o un string con el error</returns>
        public static string DecimalBinario(string numero)
        {
            string output = "";
            if(Double.TryParse(numero, out double doubleNumero))
            {
                output = DecimalBinario(doubleNumero);
            }
            else
            {
                output = "Valor inválido";
            }
            return output;
        }
        /// <summary>
        /// Recibe un valor del tipo double y lo convierte en un string binario.
        /// </summary>
        /// <param name="numero">numero a convertir en binario</param>
        /// <returns>retorno con el string convertido en binario</returns>
        public static string DecimalBinario(double numero)
        {
            string output = "";

            if(numero > int.MaxValue)
            {
                numero = int.MaxValue;
            }
            int bufferNumber = Math.Abs(Convert.ToInt32(numero));
            
            bool continueOrder = true;
            int resto;
            do
            {
                resto = bufferNumber % 2;
                output = resto + output;
                if (bufferNumber < 2)
                {
                    continueOrder = false;
                }
                else
                {
                    bufferNumber = bufferNumber / 2;
                }
            }
            while (continueOrder == true);
            return output;
        }
        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns></returns>
        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            double output;
            output = numeroUno.numero + numeroDos.numero;
            return output;
        }
        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns></returns>
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            double output;
            output = numeroUno.numero - numeroDos.numero;
            return output;
        }
        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns></returns>
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            double output;
            output = numeroUno.numero * numeroDos.numero;
            return output;
        }
        /// <summary>
        /// Sobrecarga del operador /, en el caso de error se retorna double.MinValue
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns></returns>
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            if (numeroDos.numero != 0)
            {
                return numeroUno.numero / numeroDos.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
    }
}
