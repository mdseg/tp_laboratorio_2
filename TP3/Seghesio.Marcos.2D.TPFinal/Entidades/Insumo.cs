using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Insumo
    {
        protected int cantidad;
        protected DateTime fechaIngreso;

        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                if(value > 0)
                {
                    this.cantidad = value;
                }
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return this.fechaIngreso.Date;
            }
            set
            {
                this.fechaIngreso = value;
            }
        }



        public Insumo(int cantidad,DateTime fechaIngreso)      
        {
            this.fechaIngreso = fechaIngreso;
            this.cantidad = cantidad;

        }

        public Insumo(int cantidad)
        :this(cantidad,DateTime.Now)
        {

        }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Fecha Ingreso: {0}, cantidad {1}", this.FechaIngreso, this.Cantidad);
            return sb.ToString();
        }

        public static bool operator ==(Insumo i1, Insumo i2)
        {
            bool output = false;
            
            if (i1 is Madera && i2 is Madera)
            {
                if((Madera)i1 == (Madera)i2)
                {
                    output = true;
                }
            }
            else if(i1 is Tela && i2 is Tela)
            {
                if((Tela)i1 == (Tela)i2)
                {
                    output = true;
                }
            }
            else if(i1 is Yute && i2 is Yute)
            {
                output = true;
            }
            return output;
        }
        public static bool operator !=(Insumo i1, Insumo i2)
        {
            bool output = false;
            if(!(i1 == i2))
            {
                output = true;
            }
            return output;
        }

        public static bool operator >(Insumo i1, Insumo i2)
        {
            bool output = false;
            if((i1 ==  i2) && i1.Cantidad > i2.Cantidad)
            {
                output = true;
            }
            return output;
        }

        public static bool operator <(Insumo i1, Insumo i2)
        {
            bool output = false;
            if ((i1 == i2) && i1.Cantidad < i2.Cantidad)
            {
                output = true;
            }
            return output;
        }



    }



}
