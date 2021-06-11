using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepción derivada de CustomException pensada  para los problemas al serializar los atributos de la fabrica
    /// </summary>
    public class SaveFactoryException : CustomException
    {
        public SaveFactoryException(string message)
        :base(message)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{base.ToString()}. Los problemas estan vinculados al guardar los datos de la fábrica en los archivos");
            return sb.ToString();
        }
    }
}
