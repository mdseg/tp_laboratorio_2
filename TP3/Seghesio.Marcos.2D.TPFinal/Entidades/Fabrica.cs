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

        private const int CANTIDAD_TORNILLOS_TORRE = 16;
        private const int CANTIDAD_BARNIZ_TORRE = 3;
        private const int CANTIDAD_PEGAMENTO_TORRE = 3;

        private const int CANTIDAD_TORNILLOS_ESTANTE = 8;
        private const int CANTIDAD_BARNIZ_ESTANTE = 1;
        private const int CANTIDAD_PEGAMENTO_ESTANTE = 1;

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

        private Fabrica()
        {
            this.stockInsumos = new List<Insumo>();
            this.lineaProduccion = new List<Producto>();
            this.stockProductosTerminados = new List<Producto>();
        }

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
                        procesoRealizado = producto.BarnizarProducto();
                        break;
                    case EProceso.Alfombrar:
                        procesoRealizado = producto.AlfombrarProducto();
                        break;
                    case EProceso.AgregarYute:
                        procesoRealizado = producto.AgregarYuteProducto();
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

        public void ResetearFabrica()
        {
            this.lineaProduccion.Clear();
            this.stockInsumos.Clear();
            this.stockProductosTerminados.Clear();
        }

        public int MudarProductosAStockTerminado()
        {
            int output = 0;
            List<Producto> productosAEliminar = new List<Producto>();
            foreach (Producto producto in this.lineaProduccion)
            {
                if (producto.EstadoProducto == Producto.EEstado.Completo)
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
    public enum EProceso
    {
        Lijar,
        Barnizar,
        Alfombrar,
        AgregarYute,
        Ensamblar
    }
}
