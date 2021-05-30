using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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

            foreach (Insumo insumoProducto in materialesProducto)
            {
                bool insumoEncontrado = false;
                foreach(Insumo insumo in stockInsumos)
                {
                    if(insumo == insumoProducto)
                    {
                        insumoEncontrado = true;
                        break;
                    }
                }
                if(!insumoEncontrado)
                {
                    insumosFaltantes.Add(insumoProducto);
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
        private bool SepararInsumos(List<Insumo> insumosASeparar)
        {
            bool output = false;
            foreach(Insumo i in insumosASeparar)
            {
               bool resultado = this.stockInsumos - i;
               if(resultado == false)
                {
                    throw new Exception();
                }
            }
            return output;
        }
        
        public bool AgregarProductoLineaProduccion(Producto prospectoProducto)
        {
            bool output = false;
            List<Insumo> insumosFaltantes = new List<Insumo>();
            List<Insumo> insumosCompletos = new List<Insumo>();
            if (VerificarStockInsumo(prospectoProducto,out insumosFaltantes, out insumosCompletos))
            {
                SepararInsumos(insumosCompletos);
                this.lineaProduccion.Add(prospectoProducto);
            }
            return output;
        }

        public bool AgregarInsumosAStock(Insumo insumo)
        {
            bool output = false;
            if(!(insumo is null))
            {
                this.stockInsumos.Add(insumo);
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
        public bool EjecutarProcesoLineaProduccion(EProceso proceso)
        {
            bool output = false;
            foreach(Producto producto in lineaProduccion)
            {
                switch (proceso)
                {
                    case EProceso.Lijar:
                        producto.LijarMaderaProducto();
                        break;
                    case EProceso.Barnizar:
                        producto.BarnizarProducto();
                        break;
                    case EProceso.Alfombrar:
                        producto.AlfombrarProducto();
                        break;
                    case EProceso.Ensamblar:
                        producto.EnsamblarProducto();
                        break;
                }
            }
            return output;

        }

        

        
    }
    public enum EProceso
    {
        Lijar,
        Barnizar,
        Alfombrar,
        Ensamblar
    }
}
