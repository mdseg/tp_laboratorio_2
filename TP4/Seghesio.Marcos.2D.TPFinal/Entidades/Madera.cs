using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase de Madera
    /// </summary>
    [Serializable]
    public class Madera : Insumo
    {
        private ETipoMadera tipoMadera;
        private EForma forma;
        private bool estaLijada;

        public ETipoMadera TipoMadera
        {
            get
            {
                return this.tipoMadera;
            }
            set
            {
                this.tipoMadera = value;
            }
        }

        public EForma Forma
        {
            get
            {
                return this.forma;
            }
            set
            {
                this.forma = value;
            }
        }
        public bool EstaLijada
        {
            get
            {
                return this.estaLijada;
            }
            set
            {
                this.estaLijada = value;
            }
        }
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Madera()
        {

        }
        /// <summary>
        /// Constructor con todos los parámetros incluyendo una fecha distinta a la fecha actual
        /// </summary>
        /// <param name="tipoMadera"></param>
        /// <param name="forma"></param>
        /// <param name="cantidad"></param>
        /// <param name="fechaIngreso"></param>
        public Madera(ETipoMadera tipoMadera, EForma forma, int cantidad, DateTime fechaIngreso)
        :base(cantidad,fechaIngreso)
        {
            this.tipoMadera = tipoMadera;
            this.forma = forma;
            this.estaLijada = false;
        }
        /// <summary>
        /// Constructor con parametros incluyendo la fecha actual
        /// </summary>
        /// <param name="tipoMadera"></param>
        /// <param name="forma"></param>
        /// <param name="cantidad"></param>
        public Madera(ETipoMadera tipoMadera, EForma forma, int cantidad)
        :this(tipoMadera,forma,cantidad,DateTime.Now)
        {

        }
        /// <summary>
        /// Sobreescritura del método Mostrar() de la clase base
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Madera: {0}, Tipo de Madera: {1}, Forma: {2}\n", base.Mostrar(), this.TipoMadera, this.Forma);
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga de operador == siendo igualdad dos maderas si son del mismo tipo y forma
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator ==(Madera m1, Madera m2)
        {
            bool output = false;
            if(!(m1 is null || m2 is null))
            {
                if((m1.TipoMadera == m2.TipoMadera) && (m1.Forma == m2.Forma))
                {
                    output = true;
                }
            }
            return output;
        }
        /// <summary>
        /// Sobrecarga de operador para desigualdad
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator !=(Madera m1, Madera m2)
        {
            bool output = false;
            if (!(m1 == m2))
            {
                output = true;
            }
            return output;
        }
        /// <summary>
        /// Método para cambiar el estado de estaLijada a true
        /// </summary>
        public void LijarMadera()
        {
            this.estaLijada = true;
        }
    }
    /// <summary>
    /// Enum con los tipos de madera posibles
    /// </summary>
    public enum ETipoMadera
    {
        Mdf,
        Pino
    }
    /// <summary>
    /// Enum con las distintas formas de la madera
    /// </summary>
    public enum EForma
    {
        Tablon,
        Tubo
    }
}
