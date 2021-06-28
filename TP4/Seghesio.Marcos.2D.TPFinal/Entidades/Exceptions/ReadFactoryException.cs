using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepción derivada de CustomException pensada  para los problemas al deserializar los atributos de la fabrica
    /// </summary>
    public class ReadFactoryException : CustomException
    {
        public ReadFactoryException(string message)
        :base(message)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{base.ToString()}. Los problemas estan vinculados al abrir los archivos de fábrica");
            return sb.ToString();
        }
    }
}
