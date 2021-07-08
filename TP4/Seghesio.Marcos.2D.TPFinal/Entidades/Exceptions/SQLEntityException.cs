using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class SQLEntityException : CustomException
    {
        public SQLEntityException(string message)
      : base(message)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{base.ToString()}. {this.Message}");
            return sb.ToString();
        }
    }
}
