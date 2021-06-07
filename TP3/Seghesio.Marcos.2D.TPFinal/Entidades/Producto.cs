using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
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
            sb.AppendFormat("Madera Principal: {0} - Tela: {1},{2}, Estado: {3}", this.MaderaPrincipal.TipoMadera, this.TelaProducto.TipoTela, this.TelaProducto.Color, this.EstadoProducto);
            return sb.ToString();
        }
        
        public enum EEstado
        {
            Planificado,
            MaterialesPreparados,
            MaderasLijadas,
            Barnizado,
            Alfombrado,
            AdicionalesAgregados,
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

        public virtual bool LijarMaderaProducto()
        {
            bool output = false;
            if (this.EstadoProducto == Producto.EEstado.Planificado)
            {
                this.MaderaPrincipal.LijarMadera();
                this.estadoProducto = EEstado.MaderasLijadas;
                output = true;
            }
            return output;
        }

        public bool PrepararProductoParaProduccion()
        {
            bool output = false;
            if(this.EstadoProducto == EEstado.Planificado)
            {
                this.estadoProducto = EEstado.MaterialesPreparados;
                output = true;
            }
            return output;
        }

        public bool BarnizarProducto()
        {
            bool output = false;
            if(this is Estante && this.EstadoProducto == EEstado.MaderasLijadas)
            {
                this.estadoProducto = EEstado.Barnizado;
                output = true;
            }
            return output;
        }

        public bool AlfombrarProducto()
        {
            bool output = false;
            if((this is Estante && this.estadoProducto == EEstado.Barnizado) ||
                (this is Torre && this.estadoProducto == EEstado.MaderasLijadas)) 
            {
                this.estadoProducto = EEstado.Alfombrado;
                output = true;
            }
            return output;
        }

        public bool AgregarYuteProducto()
        {
            bool output = false;
            if ((this is Torre && this.estadoProducto == EEstado.Alfombrado) && ((Torre)this).MetrosYute > 0)
            {
                ((Torre)this).AgregarYute();
                this.estadoProducto = EEstado.AdicionalesAgregados;
                output = true;
            }
            return output;
        }



        public bool EnsamblarProducto()
        {
            bool output = false;
            if ((this is Torre && this.estadoProducto == EEstado.AdicionalesAgregados) ||
                (this is Torre && this.estadoProducto == EEstado.Alfombrado && ((Torre)this).MetrosYute == 0) ||
                (this is Estante && this.estadoProducto == EEstado.Alfombrado))
            {
                this.estadoProducto = EEstado.Completo;
                output = true;
            }
            return output;
        }



    }
}
