using System;
using Entidades;
using Util;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero n1 = new Numero("2");
            Numero n2 = new Numero(8);

            double output;
            string outputString;

            //Operaciones basicas

            output = n1 + n2;
            Console.WriteLine("Suma: {0}", output);
            output = n1 - n2;
            Console.WriteLine("Resta: {0}", output);
            output = n1 * n2;
            Console.WriteLine("Multi: {0}", output);
            output = n1 / n2;
            Console.WriteLine("Divisiones: {0}", output);

            // Operaciones decimal a binario

            outputString = Numero.DecimalBinario(12);
            Console.WriteLine("a Binario: {0}", outputString);

            outputString = Numero.DecimalBinario(-12);
            Console.WriteLine("a Binario: {0}", outputString);
            outputString = Numero.DecimalBinario(-12.5);
            Console.WriteLine("a Binario: {0}", outputString);
            outputString = Numero.DecimalBinario("-12");
            Console.WriteLine("a Binario: {0}", outputString);

            // Operaciones binario a decimal

            outputString = Numero.BinarioDecimal("10011");
            Console.WriteLine("a Decimal: {0}", outputString);
            outputString = Numero.BinarioDecimal("10012");
            Console.WriteLine("a Decimal: {0}", outputString);


            string prueba = "12121.1221,12";
            if(Validaciones.isValidDouble(prueba))
            {
                Console.WriteLine("Anduvo");
            }
            else
            {
                Console.WriteLine("No anduvo");
            }
            


        }
    }
}
