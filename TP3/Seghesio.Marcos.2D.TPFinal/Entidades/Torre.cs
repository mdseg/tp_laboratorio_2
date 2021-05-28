using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Torre : Producto
    {
        private ModeloTorre modelo;
        private Madera maderaColumna;
        private int metrosYute;

        public ModeloTorre Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }
        public Madera MaderaColumna
        {
            get
            {
                return this.maderaColumna;
            }
            set
            {
                if(value.Forma == EForma.Tubo)
                {
                    this.maderaColumna = value;
                }
            }
        }
        public int MetrosYute
        {
            get
            {
                return this.metrosYute;
            }
            set
            {
                this.metrosYute = value;
            }
        }

        
       

        public Torre(Madera madera, Tela tela, ModeloTorre modelo, Madera maderaColumna)
        :base(madera,tela)
        {
            this.Modelo = modelo;
            this.MaderaColumna = maderaColumna;
        }

        public Torre(Madera madera, Tela tela, ModeloTorre modelo,Madera maderaColumna, int metrosYute)
        :this(madera,tela,modelo,maderaColumna)
        {
            this.metrosYute = metrosYute;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Torre - Modelo: {0}, Madera Columna: {1}, {2}", this.Modelo,this.MaderaColumna, base.Mostrar());
            if(this.metrosYute > 0)
            {
                sb.AppendFormat("Metros yute: {0}\n", this.MetrosYute);
            }
            else
            {
                sb.AppendFormat(".\n");
            }
            return sb.ToString();
        }

        public override void LijarMaderaProducto(Producto producto)
        {
            if (producto.EstadoProducto == Producto.EEstado.Planificado)
            {
                producto.MaderaPrincipal.LijarMadera();
                if (producto is Torre)
                {
                    ((Torre)producto).MaderaColumna.LijarMadera();
                }
                producto.EstadoProducto = EEstado.MaderasLijadas;
            }

        }

        public enum ModeloTorre
        {
            King,
            Queen,
            Prince,
            FunnyCat,
            Petite

        }
    }
}
