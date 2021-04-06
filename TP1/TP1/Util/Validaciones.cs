using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Validaciones
    {
        /// <summary>
        /// Valida que una cadena de caracteres sea un valor del tipo double
        /// empleando expresiones regulares. Retorna true en caso de que sea double y
        /// false en caso de que no lo sea
        /// </summary>
        /// <param name="input">string a validar</param>
        /// <returns>true: valido, false: no valido</returns>
        public static bool isValidDouble(string input)
        {
            bool output = false;
            if ((System.Text.RegularExpressions.Regex.IsMatch(input, @"[-]?[0-9]*\,?[0-9]+")) &&
                !(System.Text.RegularExpressions.Regex.IsMatch(input, @"[^\d\,]")) &&
                !(System.Text.RegularExpressions.Regex.IsMatch(input, @"[\,]\d*[\,]"))
                )
            {
                output = true;
            }
            return output;
        }
    }
}
