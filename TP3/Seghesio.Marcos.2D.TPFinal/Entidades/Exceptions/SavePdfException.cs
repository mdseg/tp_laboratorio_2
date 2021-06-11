using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepción derivada de CustomException pensada  para los problemas al generar reportes en pdf
    /// </summary>
    public class SavePdfException : CustomException
    {
        public SavePdfException(string message)
        :base(message)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{base.ToString()}. Hubo problemas al crear el reporte en PDF");
            return sb.ToString();
        }
    }
}
