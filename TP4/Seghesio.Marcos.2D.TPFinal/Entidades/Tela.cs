using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Tela : Insumo
    {
        private EColor color;
        private ETipoTela tipoTela;

        public EColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public ETipoTela TipoTela
        {
            get
            {
                return this.tipoTela;
            }
            set
            {
                this.tipoTela = value;
            }
        }
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Tela()
        {

        }
        /// <summary>
        /// Constructor con parámetros y fecha de ingreso distinta a la actual
        /// </summary>
        /// <param name="color"></param>
        /// <param name="tipoTela"></param>
        /// <param name="cantidad"></param>
        /// <param name="fechaIngreso"></param>
        public Tela(EColor color, ETipoTela tipoTela, int cantidad, DateTime fechaIngreso)
        :base(cantidad,fechaIngreso)
        {
            this.color = color;
            this.tipoTela = tipoTela;
        }
        /// <summary>
        /// Constructor con parámetros y fecha de ingreso actual
        /// </summary>
        /// <param name="color"></param>
        /// <param name="tipoTela"></param>
        /// <param name="cantidad"></param>
        public Tela(EColor color, ETipoTela tipoTela, int cantidad)
        : this(color, tipoTela, cantidad, DateTime.Now)
        {
        }
        /// <summary>
        /// Sobrescritura del método Mostrar()
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tela: {0} - Color de tela: {1} - Tipo de tela: {2}\n", base.Mostrar(), this.Color, this.TipoTela);
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga de operador == que plantea la igualdad cuanto un objeto tipo Tela tiene igual Color y TipoTela que otro
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator ==(Tela t1, Tela t2)
        {
            bool output = false;
            if (!(t1 is null || t2 is null))
            {
                if ((t1.Color == t2.Color) && (t1.TipoTela == t2.TipoTela))
                {
                    output = true;
                }
            }
            return output;
        }
        /// <summary>
        /// Sobrecarga de operador !=
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator !=(Tela t1, Tela t2)
        {
            bool output = false;
            if (!(t1 == t2))
            {
                output = true;
            }
            return output;
        }


    }
    /// <summary>
    /// Enum con todos los colores posibles para la tela
    /// </summary>
    public enum EColor
    {
        Amarillo,
        Azul,
        Rojo,
        Verde,
        Gris,
        Negro,
        Bordo,
        Rosa,
        Violeta
    }
    /// <summary>
    /// Enum con todos los tipos posibles para la tela
    /// </summary>
    public enum ETipoTela
    {
        Corderito,
        Peluche,
        Alfombra,
        PolarSoft
    }
}

