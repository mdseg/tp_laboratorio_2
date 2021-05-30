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

        public override bool LijarMaderaProducto()
        {
            bool output = false;
            if (this.EstadoProducto == Producto.EEstado.Planificado)
            {
                this.MaderaPrincipal.LijarMadera();
                if (this is Torre)
                {
                    ((Torre)this).MaderaColumna.LijarMadera();
                }
                ((Torre)this).estadoProducto = EEstado.MaderasLijadas;
                output = true;
            }
            return output;
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
