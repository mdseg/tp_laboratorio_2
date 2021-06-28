using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class RemoveEntityException : CustomException
    {
        public RemoveEntityException(string message)
      : base(message)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{base.ToString()}. Los problemas estan vinculados al eliminar un registro en la base de datos");
            return sb.ToString();
        }
    }
}
