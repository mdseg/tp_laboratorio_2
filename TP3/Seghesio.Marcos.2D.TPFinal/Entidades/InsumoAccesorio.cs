using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InsumoAccesorio : Insumo
    {
        private ETipoAccesorio tipoAccesorio;

        public ETipoAccesorio TipoAccesorio
        {
            get
            {
                return this.tipoAccesorio;
            }
            set
            {
                this.tipoAccesorio = value;
            }
        }

        public InsumoAccesorio(ETipoAccesorio tipoAccesorio,int cantidad, DateTime fechaIngreso)
        :base(cantidad,fechaIngreso)
        {
            this.TipoAccesorio = tipoAccesorio;
        }

        public InsumoAccesorio(ETipoAccesorio tipoAccesorio, int cantidad)
        :this(tipoAccesorio,cantidad, DateTime.Now)
        {

        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            switch(tipoAccesorio)
            {
                case ETipoAccesorio.Tornillo:
                    sb.AppendFormat("Tornillo - {0}\n", base.Mostrar());
                    break;
                case ETipoAccesorio.Pegamento:
                    sb.AppendFormat("Pegamento - {0}\n", base.Mostrar());
                    break;
                case ETipoAccesorio.Barniz:
                    sb.AppendFormat("Barniz - {0}\n", base.Mostrar());
                    break;
            }
            return sb.ToString();
        }

        public static bool operator ==(InsumoAccesorio i1, InsumoAccesorio i2)
        {
            bool output = false;
            if (!(i1 is null || i2 is null))
            {
                if (i1.TipoAccesorio == i2.TipoAccesorio)
                {
                    output = true;
                }
            }
            return output;
        }

        public static bool operator !=(InsumoAccesorio i1, InsumoAccesorio i2)
        {
            bool output = false;
            if (!(i1 == i2))
            {
                output = true;
            }
            return output;        
        }
    }

    public enum ETipoAccesorio
    {
        Tornillo,
        Pegamento,
        Barniz,

    }
}
