using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {

        private ETipo tipo;

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {                  
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
        : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }
        /// <summary>
        /// Constructor que permite asignar un valor distinto a tipo introducido como parámetro
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color,ETipo tipo)
        : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Especializacion del método Mostrar() de la clase base para mostrar Datos de un tipo Sedan
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0} TIPO : {1}", this.Tamanio,this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        public enum ETipo { CuatroPuertas, CincoPuertas }
    }
}
