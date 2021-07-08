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
    public abstract class Insumo : Entity
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
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Insumo()
        {

        }
        /// <summary>
        /// Constructor de clase base con fecha de ingreso distinta a la actual
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="fechaIngreso"></param>
        public Insumo(int cantidad, DateTime fechaIngreso)
        {
            this.fechaIngreso = fechaIngreso;
            this.cantidad = cantidad;

        }
        /// <summary>
        /// Constructor de clase base con fecha de ingreso actual
        /// </summary>
        /// <param name="cantidad"></param>
        public Insumo(int cantidad)
        : this(cantidad, DateTime.Now)
        {

        }
        /// <summary>
        /// Método basico para Mostrar en consola el objeto Insumo
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("cantidad {0}", this.Cantidad);
            return sb.ToString();
        }
        /// <summary>
        /// sobrecarga de operador que valida que un Insumo sea o on equivalente a otro
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator ==(Insumo i1, Insumo i2)
        {
            bool output = false;

            if (i1 is Madera && i2 is Madera)
            {
                if ((Madera)i1 == (Madera)i2)
                {
                    output = true;
                }
            }
            else if (i1 is Tela && i2 is Tela)
            {
                if ((Tela)i1 == (Tela)i2)
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
        /// <summary>
        /// Verificar desigualdad entre Insumos
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator !=(Insumo i1, Insumo i2)
        {
            bool output = false;
            if (!(i1 == i2))
            {
                output = true;
            }
            return output;
        }
        /// <summary>
        /// Verifica que un insumo esté presente en una lista y si la cantidad del mismo es menor o igual a la de la lista
        /// modifica la cantidad de insumos presentes en la misma. Por ejemplo si tengo una lista con 40 unidades de un tipo de Madera y quiero restar una Madera
        /// que tiene 30 unidades, la nueva cantidad de la madera de la lista será 10. En el caso de que la cantidad del insumo sea 0 tras la resta, este insumo será
        /// retirado de la lista
        /// </summary>
        /// <param name="listaInsumos"></param>
        /// <param name="insumo"></param>
        /// <returns></returns>
        public static bool operator -(List<Insumo> listaInsumos, Insumo insumo)
        {
            bool output = false;
            List<Insumo> insumosSinStock = new List<Insumo>();
            foreach (Insumo i in listaInsumos)
            {
                if ((insumo == i) && (insumo.Cantidad <= i.Cantidad))
                {
                    int nuevaCantidad = i.Cantidad - insumo.Cantidad;
                    i.Cantidad = nuevaCantidad;
                    if (i.Cantidad == 0)
                    {
                        insumosSinStock.Add(i);
                    }
                    output = true;
                    break;
                }
            }
            foreach (Insumo i in insumosSinStock)
            {
                listaInsumos.Remove(i);
            }
            return output;
        }
        /// <summary>
        /// Verifica que un insumo esté en una lista y en el caso de ser así suma las cantidades del insumo ingresado y el insumo presente, colocando como fecha de Ingreso
        /// la del insumo mas reciente. En el caso de no estar presente lo agrega a la lista como un nuevo objeto. 
        /// </summary>
        /// <param name="listaInsumos"></param>
        /// <param name="insumo"></param>
        /// <returns></returns>
        public static List<Insumo> operator +(List<Insumo> listaInsumos, Insumo insumo)
        {
            bool insumoAgregado = false;
            foreach (Insumo i in listaInsumos)
            {

                if ((insumo == i))
                {
                    int nuevaCantidad = i.Cantidad + insumo.Cantidad;
                    i.Cantidad = nuevaCantidad;
                    if (insumo.FechaIngreso > i.FechaIngreso)
                    {
                        i.FechaIngreso = insumo.FechaIngreso;
                    }
                    insumoAgregado = true;
                    break;
                }
            }
            if (!insumoAgregado)
            {
                listaInsumos.Add(insumo);
            }
            return listaInsumos;
        }
        public static List<Insumo> ConcatenarInsumos(List<Insumo> listaUno, List<Insumo> listaDos)
        {
            if (!(listaUno is null || listaUno is null))
            {
                foreach (Insumo insumo in listaDos)
                {
                    listaUno += insumo;
                }
            }
            return listaUno;
        }

        public static List<Insumo> ToListInsumo(List<Madera> maderas)
        {
            List<Insumo> output = new List<Insumo>();
            if (!(maderas is null))
            {
                foreach (Madera insumo in maderas)
                {
                    output.Add(insumo);
                }
            }
            return output;
        }


        public static List<Insumo> ToListInsumo(List<Tela> telas)
        {
            List<Insumo> output = new List<Insumo>();
            if (!(telas is null))
            {
                foreach (Tela insumo in telas)
                {
                    output.Add(insumo);
                }
            }
            return output;
        }

        public static List<Insumo> ToListInsumo(List<InsumoAccesorio> insumoAccesorios)
        {
            List<Insumo> output = new List<Insumo>();
            if (!(insumoAccesorios is null))
            {
                foreach (InsumoAccesorio insumo in insumoAccesorios)
                {
                    output.Add(insumo);
                }
            }
            return output;
        }
        /// <summary>
        /// Itera todos los insumos de la lista para corres el método Mostrar()
        /// </summary>
        /// <param name="listaInsumos"></param>
        /// <returns></returns>
        public static string ListarInsumos(List<Insumo> listaInsumos)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Insumo insumo in listaInsumos)
            {
                sb.AppendFormat($"{insumo.Mostrar()}");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Recibe como parametro un ETipoInsumo que representa cada uno de los tipos de insumos posibles y devuelve la cantidad de insumos de este tipo
        /// existentes
        /// </summary>
        /// <param name="listaInsumos"></param>
        /// <param name="tipoInsumo"></param>
        /// <returns></returns>
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
    /// <summary>
    /// Enum con los distintos tipos de insumos presentes en la aplicación
    /// </summary>
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
