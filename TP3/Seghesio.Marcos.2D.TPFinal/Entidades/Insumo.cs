using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Madera))]
    [XmlInclude(typeof(Tela))]
    [XmlInclude(typeof(InsumoAccesorio))]
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
                this.cantidad = value;
                
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return this.fechaIngreso;
            }
            set
            {
                this.fechaIngreso = value;
            }
        }

        public Insumo()
        {

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

        public static int CountInsumoType(List<Insumo> listaInsumos, ETipoInsumo tipoInsumo)
        {
            int output = 0;
            foreach(Insumo insumo in listaInsumos)
            switch(tipoInsumo)
            {
                    case ETipoInsumo.Madera:
                        if(insumo is Madera)
                        {
                            output++;
                        }
                        break;
                    case ETipoInsumo.Tela:
                        if (insumo is Tela)
                        {
                            output++;
                        }
                        break;
                    default:
                        if(insumo is InsumoAccesorio)
                        {
                            InsumoAccesorio insumoAccesorio = (InsumoAccesorio)insumo;
                            if (tipoInsumo == ETipoInsumo.Barniz && insumoAccesorio.TipoAccesorio == ETipoAccesorio.Barniz)
                            {
                                output += insumoAccesorio.Cantidad;
                            }
                            else if (tipoInsumo == ETipoInsumo.Pegamento && insumoAccesorio.TipoAccesorio == ETipoAccesorio.Pegamento)
                            {
                                output += insumoAccesorio.Cantidad;
                            }
                            else if (tipoInsumo == ETipoInsumo.Tornillo && insumoAccesorio.TipoAccesorio == ETipoAccesorio.Tornillo)
                            {
                                output += insumoAccesorio.Cantidad;
                            }
                            else if (tipoInsumo == ETipoInsumo.Yute && insumoAccesorio.TipoAccesorio == ETipoAccesorio.Yute)
                            {
                                output += insumoAccesorio.Cantidad;
                            }

                        }                       
                        break;
            }
            return output;
        }

    }

    public enum ETipoInsumo
    {
        Madera,
        Tela,
        Yute,
        Barniz,
        Pegamento,
        Tornillo
    }



}
