using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Fabrica
    {
        private static Fabrica instance;

        private List<Insumo> stockInsumos;
        private List<Producto> lineaProduccion;
        private List<Producto> stockProductosTerminados;

        public const int CANTIDAD_TORNILLOS_TORRE = 16;
        public const int CANTIDAD_BARNIZ_TORRE = 3;
        public const int CANTIDAD_PEGAMENTO_TORRE = 3;

        public const int CANTIDAD_TORNILLOS_ESTANTE = 8;
        public const int CANTIDAD_BARNIZ_ESTANTE = 1;
        public const int CANTIDAD_PEGAMENTO_ESTANTE = 1;

        public const int CANTIDAD_MADERA_TORRE_PRINCIPAL = 4;
        public const int CANTIDAD_MADERA_TORRE_COLUMNA = 2;
        public const int CANTIDAD_MADERA_ESTANTE = 4;

        public const int CANTIDAD_TELA_TORRE = 2;
        public const int CANTIDAD_TELA_ESTANTE = 2;


        public List<Insumo> StockInsumos
        {
            get
            {
                return this.stockInsumos;
            }
            set
            {
                this.stockInsumos = value;
            }
        }

        public List<Producto> LineaProduccion
        {
            get
            {
                return this.lineaProduccion;
            }
            set
            {
                this.lineaProduccion = value;
            }
        }

        public List<Producto> StockProductosTerminados
        {
            get
            {
                return this.stockProductosTerminados;
            }
            set
            {
                this.stockProductosTerminados = value;
            }
        }
        /// <summary>
        /// Propiedad que devuelve una instancia de Fabrica, permitiendose solo en una ocasion instanciar la clase
        /// </summary>
        public static Fabrica Instance
        {
            get
            {
                if(instance is null)
                {
                    instance = new Fabrica();
                }
                return instance;
            }
        }
        /// <summary>
        /// Constructor privado sin argumentos
        /// </summary>
        private Fabrica()
        {
            this.stockInsumos = new List<Insumo>();
            this.lineaProduccion = new List<Producto>();
            this.stockProductosTerminados = new List<Producto>();
        }
        /// <summary>
        /// Método que recibe un producto, añade los Insumos adicionales necesarios para su fabriación, retorna true si puede fabricarse el producto y false si no es posible por falta
        /// de stock. En el caso de haber falta de stkock se indican los insumos que faltan a traves de la variable de salida insumosFaltantes y la totalidad de insumos necesarios por medio de
        /// la variable de saluda materialesProducto
        /// </summary>
        /// <param name="prospectoProducto"></param>
        /// <param name="insumosFaltantes"></param>
        /// <param name="materialesProducto"></param>
        /// <returns></returns>
        public bool VerificarStockInsumo(Producto prospectoProducto, out List<Insumo> insumosFaltantes, out List<Insumo> materialesProducto)
        {
            materialesProducto = (List<Insumo>)prospectoProducto;
            insumosFaltantes = new List<Insumo>();

            if (prospectoProducto is Torre)
            {
                materialesProducto.Add(new InsumoAccesorio(ETipoAccesorio.Tornillo, CANTIDAD_TORNILLOS_TORRE));
                materialesProducto.Add(new InsumoAccesorio(ETipoAccesorio.Pegamento, CANTIDAD_PEGAMENTO_TORRE));
                materialesProducto.Add(new InsumoAccesorio(ETipoAccesorio.Barniz, CANTIDAD_BARNIZ_TORRE));
            }
            else if(prospectoProducto is Estante)
            {
                materialesProducto.Add(new InsumoAccesorio(ETipoAccesorio.Tornillo, CANTIDAD_TORNILLOS_ESTANTE));
                materialesProducto.Add(new InsumoAccesorio(ETipoAccesorio.Pegamento, CANTIDAD_PEGAMENTO_ESTANTE));
                materialesProducto.Add(new InsumoAccesorio(ETipoAccesorio.Barniz, CANTIDAD_BARNIZ_ESTANTE));
            }
            int contador = 0;
            foreach (Insumo insumoProducto in materialesProducto)
            {
                bool insumoEncontrado = false;
                contador++;
                foreach(Insumo insumo in stockInsumos)
                {
                    if(insumo == insumoProducto)
                    {
                        if(insumoProducto.Cantidad <= insumo.Cantidad)
                        {
                            insumoEncontrado = true;
                        }
                        else
                        {
                            insumoProducto.Cantidad = insumoProducto.Cantidad - insumo.Cantidad;

                        }
                        break;
                    }
                }
                if(!insumoEncontrado)
                {
                    insumosFaltantes += insumoProducto;
                }
            }
            if(insumosFaltantes.Count > 0)
            {
                return false;
            }
            else
            {
                
                return true;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="insumosASeparar"></param>
        /// <returns></returns>
        private void SepararInsumos(List<Insumo> insumosASeparar)
        {
            foreach(Insumo i in insumosASeparar)
            {
               bool resultado = this.stockInsumos - i;               
            }
        }
        /// <summary>
        /// Método que recibe un producto a fabricar y en el caso que el método VerificarStockInsumo de true va a separar los insumos necesarios del inventario
        /// y agregar el producto a la linea de producción, devolviendo true en el output. En el caso de no haber stock se devolverá por medio de la variable de salida insumosFaltantes
        /// aquellos insumos que hagan falta
        /// </summary>
        /// <param name="prospectoProducto"></param>
        /// <param name="insumosFaltantes"></param>
        /// <returns></returns>
        public bool AgregarProductoLineaProduccion(Producto prospectoProducto, out List<Insumo> insumosFaltantes)
        {
            bool output = false;
            List<Insumo> insumosCompletos = new List<Insumo>();
            if (VerificarStockInsumo(prospectoProducto,out insumosFaltantes, out insumosCompletos))
            {
                SepararInsumos(insumosCompletos);
                this.lineaProduccion.Add(prospectoProducto);
                output = true;
            }
            else
            {
                output = false;

            }
            return output;
        }
        /// <summary>
        /// Agrega un unico insumo al stock de la fábrica
        /// </summary>
        /// <param name="insumo"></param>
        /// <returns></returns>
        public bool AgregarInsumosAStock(Insumo insumo)
        {
            bool output = false;
            if(!(insumo is null))
            {
                this.stockInsumos +=insumo;
                output = true;
            }
            return output;
        }
        /// <summary>
        /// Agrega una lista de insumos al stock de la fábrica
        /// </summary>
        /// <param name="insumos"></param>
        /// <returns></returns>
        public int AgregarInsumosAStock(List<Insumo> insumos)
        {
            int output = 0;
            foreach(Insumo i in insumos)
            {
                if(this.AgregarInsumosAStock(i))
                {
                    output++;
                }
            }
            return output;
        }
        /// <summary>
        /// El método recibe una variable del tipo EProceso indicando el proceso a realizar y recorre la lista de linea de produccion para ejecutar dicho proceso
        /// cuando corresponda, devolviendo la cantidad de productos a los cuales se les aplico el proceso.
        /// </summary>
        /// <param name="proceso"></param>
        /// <returns></returns>
        public int EjecutarProcesoLineaProduccion(EProceso proceso)
        {
            int output = 0;
            foreach(Producto producto in lineaProduccion)
            {
                bool procesoRealizado = false;
                switch (proceso)
                {
                    case EProceso.Lijar:
                        
                        procesoRealizado = producto.LijarMaderaProducto();
                        break;
                    case EProceso.Barnizar:
                        if(producto is Estante)
                        {
                            procesoRealizado = ((Estante)producto).BarnizarProducto();
                        }
                        break;
                    case EProceso.Alfombrar:
                        procesoRealizado = producto.AlfombrarProducto();
                        break;
                    case EProceso.AgregarYute:
                        if(producto is Torre)
                        {
                            procesoRealizado = ((Torre)producto).AgregarYute();
                        }
                        break;
                    case EProceso.Ensamblar:
                        procesoRealizado = producto.EnsamblarProducto();
                        break;
                }
                if(procesoRealizado)
                {
                    output++;
                }
            }
            return output;

        }
        /// <summary>
        /// Método que limpia los atributos de la fábrica
        /// </summary>
        public void ResetearFabrica()
        {
            this.lineaProduccion.Clear();
            this.stockInsumos.Clear();
            this.stockProductosTerminados.Clear();
        }
        /// <summary>
        /// Itera la lista de linea de producción, separando los productos que esten en estado Completo
        /// </summary>
        /// <returns></returns>
        public int MudarProductosAStockTerminado()
        {
            int output = 0;
            List<Producto> productosAEliminar = new List<Producto>();
            foreach (Producto producto in this.lineaProduccion)
            {
                if (producto.EstadoProducto == EEstado.Completo)
                {
                    this.stockProductosTerminados.Add(producto);
                    productosAEliminar.Add(producto);
                    output++;
                }
            }

            foreach (Producto producto in productosAEliminar)
            {
                this.lineaProduccion.Remove(producto);
            }

            return output;
        }




    }
    /// <summary>
    /// Enum con todos los procesos que la fábrica realiza
    /// </summary>
    public enum EProceso
    {
        Lijar,
        Barnizar,
        Alfombrar,
        AgregarYute,
        Ensamblar
    }
}
