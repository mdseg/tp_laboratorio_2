using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{   
    [Serializable]
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
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Torre()
        {

        }
        /// <summary>
        /// Constructor con parámetros, sin el agregado de Yute
        /// </summary>
        /// <param name="madera"></param>
        /// <param name="tela"></param>
        /// <param name="modelo"></param>
        /// <param name="maderaColumna"></param>
        public Torre(Madera madera, Tela tela, EModeloTorre modelo, Madera maderaColumna)
        :base(madera,tela)
        {
            this.Modelo = modelo;
            this.MaderaColumna = maderaColumna;
            this.yuteInstalado = false;
        }
        /// <summary>
        /// Constructor con parámetros, con agregado de yute expresado en metros
        /// </summary>
        /// <param name="madera"></param>
        /// <param name="tela"></param>
        /// <param name="modelo"></param>
        /// <param name="maderaColumna"></param>
        /// <param name="metrosYute"></param>
        public Torre(Madera madera, Tela tela, EModeloTorre modelo,Madera maderaColumna, int metrosYute)
        :this(madera,tela,modelo,maderaColumna)
        {
            this.metrosYute = metrosYute;
        }
        /// <summary>
        /// Sobrescritura del método Mostrar() incluyendo los atributos propios de una Torre
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Torre - Modelo: {0}, Madera Columna: {1}, {2}", this.Modelo,this.MaderaColumna.TipoMadera, base.Mostrar());
            if(this.metrosYute > 0)
            {
                sb.AppendFormat(", Metros yute: {0} - Yute Instalado: ", this.MetrosYute);
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
        /// <summary>
        /// Verifica que el producto se encuentre en estado Planificado para luego ejecutar el método LijarMadera por cada insumo del Tipo Madera que compone el producto
        /// </summary>
        /// <returns></returns>
        public override bool LijarMaderaProducto()
        {
            bool output = false;
            if (this.EstadoProducto == EEstado.Planificado)
            {
                this.MaderaPrincipal.LijarMadera();
                this.MaderaColumna.LijarMadera();
                this.estadoProducto = EEstado.MaderasLijadas;
                output = true;
            }
            return output;
        }

        /// <summary>
        ///  Método que verifica que un producto sea del tipo Torre y este en el estado MaderasLijadas, o que sea del tipo Estante y este Barnizado
        ///  para luego cambiar el estado del producto a Alfombrado
        /// </summary>
        /// <returns></returns>
        public override bool AlfombrarProducto()
        {
            bool output = false;
            if (this.estadoProducto == EEstado.MaderasLijadas)
            {
                this.estadoProducto = EEstado.Alfombrado;
                output = true;
            }
            return output;
        }

        /// <summary>
        /// Verifica que el producto se encuentre en estado Alfombrado y que existe yute a agregar expresado con valores de metrosYute > 0 asignando el estado del producto como
        /// AdicionalesAgregados
        /// </summary>
        /// <returns></returns>
        public bool AgregarYute()
        {
            bool output = false;
            if(this.EstadoProducto == EEstado.Alfombrado && this.metrosYute > 0)
            {
                this.YuteInstalado = true;
                this.estadoProducto = EEstado.AdicionalesAgregados;
                output = true;
            }
            return output;
        }
        /// <summary>
        /// Verifica que los estados del producto sean 
        /// </summary>
        /// <returns></returns>
        public override bool EnsamblarProducto()
        {
            bool output = false;
            if ((this.estadoProducto == EEstado.AdicionalesAgregados) ||
                (this.estadoProducto == EEstado.Alfombrado && this.MetrosYute == 0))
            {
                this.estadoProducto = EEstado.Completo;
                output = true;
            }
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
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
