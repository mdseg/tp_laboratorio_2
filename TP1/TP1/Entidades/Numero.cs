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

        public Numero()
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            setNumero(numero);
        }

        public void setNumero(string numero)
        {
            double doubleNumero = ValidarNumero(numero);
            if(doubleNumero != 0)
            {
                this.numero = doubleNumero;
            }
        }

        private double ValidarNumero(string strNumero)
        {
            double output = 0;

            if(Double.TryParse(strNumero, out double doubleNumero))
            {
                output = doubleNumero;
            }
            
            return output;  
        }

        private bool EsBinario(string binario)
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

        public string BinarioDecimal(string binario)
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

        public string DecimalBinario(string numero)
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

        public string DecimalBinario(double numero)
        {
            string output = "";
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

        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            double output;
            output = numeroUno.numero + numeroDos.numero;
            return output;
        }

        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            double output;
            output = numeroUno.numero - numeroDos.numero;
            return output;
        }

        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            double output;
            output = numeroUno.numero * numeroDos.numero;
            return output;
        }

        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            double output;
            output = numeroUno.numero / numeroDos.numero;
            return output;
        }
    }
}
