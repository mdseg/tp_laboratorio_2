using Files.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Clase personalizada del tipo excepción pensada para poder ser almacenada en un archivo de texto sobrescribiendo método ToString()
    /// Esta clase y sus derivadas incluyen los conceptos propios de la clase 15 Excepciones
    /// </summary>
    public abstract class CustomException : Exception
    {
        DateTime dateException;

        public CustomException(string message)
        :base(message)
        {
            this.dateException = DateTime.Now;
        }
        /// <summary>
        /// Sobrescritura método ToString() usada para el Logger
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"Fecha error: {dateException.ToString("g")}");
            return sb.ToString();
        }
    }
}
