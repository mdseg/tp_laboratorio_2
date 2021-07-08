using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Torre))]
    [XmlInclude(typeof(Estante))]
    public abstract class Producto : Entity
    {
        protected Madera maderaPrincipal;
     
        protected Tela telaProducto;
        protected EEstado estadoProducto;
        

        public Madera MaderaPrincipal
        {
            get
            {
                return this.maderaPrincipal;
            }
            set
            {
                this.maderaPrincipal = value;
            }
            

        }
        public Tela TelaProducto
        {
            get
            {
                return this.telaProducto;
            }
            set
            {
                this.telaProducto = value;
            }


        }
        
        public EEstado EstadoProducto
        {
            get
            {
                return this.estadoProducto;
            }
            set
            {
                this.estadoProducto = value;
            }
        }
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Producto()
        {

        }
        
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="maderaPrincipal"></param>
        /// <param name="telaProducto"></param>
        public Producto(Madera maderaPrincipal, Tela telaProducto)
        {
            this.maderaPrincipal = maderaPrincipal;
            this.telaProducto = telaProducto;
            this.estadoProducto = EEstado.Planificado;
        }

        /// <summary>
        /// Método abstracto para alfombrar producto 
        /// </summary>
        /// <returns></returns>
        public abstract bool AlfombrarProducto();

        /// <summary>
        /// Verifica que un producto se encuentre en los distintos estados validos previos para luego asignar como estadoProducto a Completo
        /// </summary>
        /// <returns></returns>
        public abstract bool EnsamblarProducto();

        /// <summary>
        /// Método que verifica que el estado del producto sea planificado y ejecuta el proceso de LijarMadera() en cada una de las Maderas del producto
        /// y posteriormente cambia el estado del producto a MaderasLijadas
        /// </summary>
        /// <returns></returns>
        public virtual bool LijarMaderaProducto()
        {
            bool output = false;
            if (this.EstadoProducto == EEstado.Planificado)
            {
                this.MaderaPrincipal.LijarMadera();
                this.estadoProducto = EEstado.MaderasLijadas;
                output = true;
            }
            return output;
        }

        /// <summary>
        /// Método encargado de mostrar en consola los atributos del producto, que puede ser sobreescrito en clases derivadas
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Madera Principal: {0} - Tela: {1}, {2} - Estado: {3}", this.MaderaPrincipal.TipoMadera, this.TelaProducto.TipoTela, this.TelaProducto.Color, this.EstadoProducto);
            return sb.ToString();
        }
        
        /// <summary>
        /// Conversion explicita que recibe un producto y devuelve la lista de insumos que lo componen
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator List<Insumo>(Producto p)
        {
            List<Insumo> insumos = new List<Insumo>();
            insumos.Add(p.MaderaPrincipal);
            insumos.Add(p.TelaProducto);
            if(p is Torre)
            {
                Torre bufferTorre = (Torre)p;
                insumos.Add(bufferTorre.MaderaColumna);
                if(bufferTorre.MetrosYute > 0)
                {
                    insumos.Add(new InsumoAccesorio(ETipoAccesorio.Yute, bufferTorre.MetrosYute));
                    
                }               
            }
            return insumos;
        }

        public static List<Producto> ConcatenarProductos(List<Producto> listaUno, List<Producto> listaDos)
        {
            if (!(listaUno is null || listaUno is null))
            {
                foreach (Producto producto in listaDos)
                {
                    listaUno += producto;
                }
            }
            return listaUno;
        }

        public static List<Producto> operator +(List<Producto> listaProductos, Producto producto)
        {
            if (!(listaProductos is null || producto is null))
            {
                listaProductos.Add(producto);
            }
            return listaProductos;
        }

        public static List<Producto> ToListProducto(List<Torre> torres)
        {
            List<Producto> output = new List<Producto>();
            if (!(torres is null))
            {
                foreach (Torre producto in torres)
                {
                    output.Add(producto);
                }
            }
            return output;
        }

        public static List<Producto> ToListProducto(List<Estante> estantes)
        {
            List<Producto> output = new List<Producto>();
            if (!(estantes is null))
            {
                foreach (Estante estante in estantes)
                {
                    output.Add(estante);
                }
            }
            return output;
        }

    }
    /// <summary>
    /// Enum con los distintos estados que puede adoptar un producto en un proceso de fabricación
    /// </summary>
    public enum EEstado
    {
        Planificado,
        MaderasLijadas,
        Barnizado,
        Alfombrado,
        AdicionalesAgregados,
        Completo
    }
}
