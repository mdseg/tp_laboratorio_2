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
                if(value >= 0)
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
            sb.AppendFormat("cantidad {0}", this.Cantidad);
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
            else if (i1 is InsumoAccesorio && i2 is InsumoAccesorio)
            {
                if ((InsumoAccesorio)i1 == (InsumoAccesorio)i2)
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

        public static bool operator -(List<Insumo> listaInsumos, Insumo insumo)
        {
            bool output = false;
            List<Insumo> insumosSinStock = new List<Insumo>();
            foreach(Insumo i in listaInsumos)
            {
                if((insumo == i) && (insumo.Cantidad <= i.Cantidad))
                {
                    int nuevaCantidad = i.Cantidad - insumo.Cantidad;
                    i.Cantidad = nuevaCantidad;
                    if(i.Cantidad == 0)
                    {
                        insumosSinStock.Add(i);
                    }
                    output = true;
                    break;
                }
            }
            foreach(Insumo i in insumosSinStock)
            {
                listaInsumos.Remove(i);
            }
            return output;
        }

        public static List<Insumo> operator +(List<Insumo> listaInsumos, Insumo insumo)
        {
            bool insumoAgregado = false;
            foreach (Insumo i in listaInsumos)
            {

                if ((insumo == i))
                {
                    int nuevaCantidad = i.Cantidad + insumo.Cantidad;
                    i.Cantidad = nuevaCantidad;
                    if(insumo.FechaIngreso > i.FechaIngreso)
                    {
                        i.FechaIngreso = insumo.FechaIngreso;
                    }
                    insumoAgregado = true;
                    break;
                }
            }
            if(!insumoAgregado)
            {
                listaInsumos.Add(insumo);
            }
            return listaInsumos;
        }

        public static string ListarInsumos(List<Insumo> listaInsumos)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Insumo insumo in listaInsumos)
            {
                sb.AppendFormat($"{insumo.Mostrar()}");
            }
            return sb.ToString();
        }
    }



}
