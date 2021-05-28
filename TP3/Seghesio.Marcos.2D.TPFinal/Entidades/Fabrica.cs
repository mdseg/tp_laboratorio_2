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

        private List<Insumo> faltantes;

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

        }

        public List<Insumo> VerificarStockProducto(List<Insumo> insumosEnStock, Producto prospectoProducto)
        {
            List<Insumo> materialesProducto = (List<Insumo>)prospectoProducto;
            List<Insumo> insumosFaltantes = new List<Insumo>();
            
            foreach(Insumo insumoProducto in materialesProducto)
            {
                bool insumoEncontrado = false;
                foreach(Insumo insumo in insumosEnStock)
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
            return insumosFaltantes;
        }
        

        
    }
}
