using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        private Madera maderaPrincipal;
     
        private Tela telaProducto;
        private EEstado estadoProducto;
        

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


        

        public Producto(Madera maderaPrincipal, Tela telaProducto)
        {
            this.maderaPrincipal = maderaPrincipal;
            this.telaProducto = telaProducto;
            this.estadoProducto = EEstado.Planificado;
        }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Madera Principal: {0}, Tela: {1},{2}, Estado: {3}", this.MaderaPrincipal.TipoMadera, this.TelaProducto.TipoTela, this.TelaProducto.Color, this.EstadoProducto);
            return sb.ToString();
        }
        
        public enum EEstado
        {
            Planificado,
            MaderasLijadas,
            Barnizado,
            Alfombrado,
            Ensamblado,
            Completo
        }

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
                    insumos.Add(new Yute(bufferTorre.MetrosYute));
                }               
            }
            return insumos;
        }

        public virtual void LijarMaderaProducto(Producto producto)
        {
            if (producto.EstadoProducto == Producto.EEstado.Planificado)
            {
                producto.MaderaPrincipal.LijarMadera();                
                producto.EstadoProducto = EEstado.MaderasLijadas;
            }

        }
    }
}
