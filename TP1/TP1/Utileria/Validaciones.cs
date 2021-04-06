using System;

namespace Utileria
{
    public static class Validaciones

    {

        public static bool isValidDouble(string input)
        {
            bool output = false;
            if ((System.Text.RegularExpressions.Regex.IsMatch(input, @"[-]?[0-9]*\.?,?[0-9]+"))&& 
                !(System.Text.RegularExpressions.Regex.IsMatch(input, @"[^\d\.\,]")) &&
                !(System.Text.RegularExpressions.Regex.IsMatch(input, @"[\.\,]\d*[\.\,]"))    
                )
            {
                output = true;
            }
            return output;
        }


    }
}
