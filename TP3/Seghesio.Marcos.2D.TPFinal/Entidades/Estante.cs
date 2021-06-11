using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Estante : Producto
    {
        private int cantidadEstantes;

        public int CantidadEstantes
        {
            get
            {
                return this.cantidadEstantes;
            }
            set
            {
                this.cantidadEstantes = value;
            }
        }
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Estante()
        {

        }
        /// <summary>
        /// Constructor con argumentos que incluye el unico atributo propio de esta clase derivada
        /// </summary>
        /// <param name="madera"></param>
        /// <param name="tela"></param>
        /// <param name="cantidadEstantes"></param>
        public Estante(Madera madera, Tela tela, int cantidadEstantes)
        :base(madera,tela)
        {
            this.cantidadEstantes = cantidadEstantes;
        }
        /// <summary>
        /// Método para convertir el objeto en string sobrescrito de la clase base
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Estante - cantidad: {0} - {1}\n", this.CantidadEstantes, base.Mostrar());
            return sb.ToString();

        }

        /// <summary>
        /// Método que verifica que un producto sea del tipo Estante y este en el estado MaderasLijadas, para luego cambiar el estado del producto a Barnizado
        /// </summary>
        /// <returns></returns>
        public bool BarnizarProducto()
        {
            bool output = false;
            if (this is Estante && this.EstadoProducto == EEstado.MaderasLijadas)
            {
                this.estadoProducto = EEstado.Barnizado;
                output = true;
            }
            return output;
        }

        /// <summary>
        ///  Método que verifica que que el Estante este Barnizado
        ///  para luego cambiar el estado del mismo a Alfombrado
        /// </summary>
        /// <returns></returns>
        public override bool AlfombrarProducto()
        {
            bool output = false;
            if (this.estadoProducto == EEstado.Barnizado)
            {
                this.estadoProducto = EEstado.Alfombrado;
                output = true;
            }
            return output;
        }
        /// <summary>
        /// Verifica que el Estante esté alfombrado para luego asignarle el estado de completo
        /// </summary>
        /// <returns></returns>
        public override bool EnsamblarProducto()
        {
            bool output = false;
            if(this.estadoProducto == EEstado.Alfombrado)
            {
                this.estadoProducto = EEstado.Completo;
                output = true;
            }
            return output;
        }
    }
}
