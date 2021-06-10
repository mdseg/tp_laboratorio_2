using Files.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class CustomException : Exception
    {
        DateTime dateException;

        public CustomException(string message)
        :base(message)
        {
            this.dateException = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"Fecha error: {dateException.ToString("g")}");
            return sb.ToString();
        }
    }
}
