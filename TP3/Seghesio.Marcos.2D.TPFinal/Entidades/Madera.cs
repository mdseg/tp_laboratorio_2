using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Madera : Insumo
    {
        private ETipoMadera tipoMadera;
        private EForma forma;
        private bool estaLijada;

        public ETipoMadera TipoMadera
        {
            get
            {
                return this.tipoMadera;
            }
        }

        public EForma Forma
        {
            get
            {
                return this.forma;
            }
        }
        public bool EstaLijada
        {
            get
            {
                return this.estaLijada;
            }
        }
        public void LijarMadera()
        {
           this.estaLijada = true;
        }
        public Madera(ETipoMadera tipoMadera, EForma forma, int cantidad, DateTime fechaIngreso)
        :base(cantidad,fechaIngreso)
        {
            this.tipoMadera = tipoMadera;
            this.forma = forma;
            this.estaLijada = false;
        }

        public Madera(ETipoMadera tipoMadera, EForma forma, int cantidad)
        :this(tipoMadera,forma,cantidad,DateTime.Now)
        {

        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Madera: {0}, Tipo de Madera: {1}, Forma: {2}\n", base.Mostrar(), this.TipoMadera, this.Forma);
            return sb.ToString();
        }

        public static bool operator ==(Madera m1, Madera m2)
        {
            bool output = false;
            if(!(m1 is null || m2 is null))
            {
                if((m1.TipoMadera == m2.TipoMadera) && (m1.Forma == m2.Forma))
                {
                    output = true;
                }
            }
            return output;
        }
        public static bool operator !=(Madera m1, Madera m2)
        {
            bool output = false;
            if (!(m1 == m2))
            {
                output = true;
            }
            return output;
        }
    }

    public enum ETipoMadera
    {
        Mdf,
        Pino
    }
    public enum EForma
    {
        Tablon,
        Tubo
    }
}
