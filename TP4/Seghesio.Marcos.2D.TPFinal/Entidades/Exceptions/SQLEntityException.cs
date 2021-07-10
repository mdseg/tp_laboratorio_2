using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
    {/// <summary>
    /// Excepcion que se lanza al momento de tener inconvenientes en la lectura y escritura de las Base de Datos
    /// </summary>
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
