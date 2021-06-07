using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Torre : Producto
    {
        private EModeloTorre modelo;
        private Madera maderaColumna;
        private int metrosYute;
        private bool yuteInstalado;

        public EModeloTorre Modelo
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
        public bool YuteInstalado
        {
            get
            {
                return this.yuteInstalado;
            }
            set
            {
                this.yuteInstalado = value;
            }
        }
        
       

        public Torre(Madera madera, Tela tela, EModeloTorre modelo, Madera maderaColumna)
        :base(madera,tela)
        {
            this.Modelo = modelo;
            this.MaderaColumna = maderaColumna;
            this.yuteInstalado = false;
        }

        public Torre(Madera madera, Tela tela, EModeloTorre modelo,Madera maderaColumna, int metrosYute)
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
                sb.AppendFormat("Metros yute: {0} - Yute Instalado: ", this.MetrosYute);
                if(this.YuteInstalado)
                {
                    sb.AppendFormat("Si.\n");
                }
                else
                {
                    sb.AppendFormat("No.\n");
                }
            }
            else
            {
                sb.AppendFormat(".\n");
            }
            return sb.ToString();
        }
        //TODO revisar que el metodo sea para Torre
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

        public bool AgregarYute()
        {
            bool output = false;
            if(this.EstadoProducto == EEstado.Alfombrado && this.metrosYute > 0 && this.YuteInstalado)
            {
                this.YuteInstalado = true;
                this.estadoProducto = EEstado.AdicionalesAgregados;
                output = true;
            }
            return output;
        }


        public enum EModeloTorre
        {
            King,
            Queen,
            Prince,
            FunnyCat,
            Petite

        }
    }
}
