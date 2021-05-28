using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tela : Insumo
    {
        private EColor color;
        private ETela tipoTela;

        public EColor Color
        {
            get
            {
                return this.color;
            }
        }
        public ETela TipoTela
        {
            get
            {
                return this.tipoTela;
            }
        }

        
        public Tela(EColor color, ETela tipoTela, int cantidad, DateTime fechaIngreso)
        :base(cantidad,fechaIngreso)
        {
            this.color = color;
            this.tipoTela = tipoTela;
        }

        public Tela(EColor color, ETela tipoTela, int cantidad)
        : this(color, tipoTela, cantidad, DateTime.Now)
        {
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}, Color de tela: {1}, Tipo de tela: {2}\n", base.Mostrar(), this.Color, this.TipoTela);
            return sb.ToString();
        }

        public static bool operator ==(Tela t1, Tela t2)
        {
            bool output = false;
            if (!(t1 is null || t2 is null))
            {
                if ((t1.Color == t2.Color) && (t1.TipoTela == t2.TipoTela))
                {
                    output = true;
                }
            }
            return output;
        }
        public static bool operator !=(Tela t1, Tela t2)
        {
            bool output = false;
            if (!(t1 == t2))
            {
                output = true;
            }
            return output;
        }


    }
    public enum EColor
    {
        Amarillo,
        Azul,
        Rojo,
        Verde,
        Gris,
        Negro,
        Bordo,
        Rosa,
        Violeta
    }

    public enum ETela
    {
        Corderito,
        Peluche,
        Alfombra,
        PolarSoft
    }
}

