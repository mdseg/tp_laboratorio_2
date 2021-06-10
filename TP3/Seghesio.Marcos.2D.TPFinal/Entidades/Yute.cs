using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Yute : Insumo
    {
        
        public Yute(int cantidad, DateTime fechaIngreso)
        : base(cantidad, fechaIngreso)
        {
        }

        public Yute(int cantidad)
        :base(cantidad)
        {

        }

        public Yute()
        {

        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Yute - {0}\n",base.Mostrar());
            return sb.ToString();
        }

    }
}
