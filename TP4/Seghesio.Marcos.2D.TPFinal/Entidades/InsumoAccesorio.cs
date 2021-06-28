using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
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

        public InsumoAccesorio()
        {

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
        /// <summary>
        /// Sobrescritura del método Mostrar()
        /// </summary>
        /// <returns></returns>
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
                case ETipoAccesorio.Yute:
                    sb.AppendFormat("Yute - {0}\n", base.Mostrar());
                    break;
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga de operador que plantea la igual entre dos InsumoAccesorio siempre y cuando cada Insumo.TipoAccesorio sea equivalente entre ambos
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Sobrecarga para desigualdad
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
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
    /// <summary>
    /// Enum con los tipos de accesorios que puede adoptar un objeto del tipo InsumoAccesorio
    /// </summary>
    public enum ETipoAccesorio
    {
        Tornillo,
        Pegamento,
        Barniz,
        Yute
    }
}
