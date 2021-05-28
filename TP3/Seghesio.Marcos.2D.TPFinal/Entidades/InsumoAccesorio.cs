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
    }

    public enum ETipoAccesorio
    {
        Tornillo,
        Pegamento,
        Barniz,
        Yute
    }
}
