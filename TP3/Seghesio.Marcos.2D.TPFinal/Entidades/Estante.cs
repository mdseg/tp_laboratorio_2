using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante : Producto
    {
        private int cantidadEstantes;

        public int CantidadEstantes
        {
            get
            {
                return this.cantidadEstantes;
            }
            set
            {
                this.cantidadEstantes = value;
            }
        }

        public Estante(Madera madera, Tela tela, int cantidadEstantes)
        :base(madera,tela)
        {
            this.cantidadEstantes = cantidadEstantes;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Estante - cantidad: {0},\n", this.CantidadEstantes, base.Mostrar());
            return sb.ToString();

        }
    }
}
