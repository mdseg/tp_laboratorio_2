using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    class XmlSerializerException : Exception
    {
        public XmlSerializerException(string message)
        :base(message)
        {

        }
    }
}
