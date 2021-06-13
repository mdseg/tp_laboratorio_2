using Entidades;
using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Xml
{
    public class FabricaXmlService
    {
        private IFile<List<Insumo>> serializadorInsumos;
        private IFile<List<Producto>> serializadorProductos;
        private string path;

        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
            }
        }


        public FabricaXmlService(string path)
        {
            this.serializadorInsumos = new Xml<List<Insumo>>();
            this.serializadorProductos = new Xml<List<Producto>>();
            this.path = path;
        }

        public void SaveXmlFabrica(Fabrica fabrica)
        {
            string pathInsumos = path + "listadoInsumosFabrica.xml";
            string pathLineaProduccion = path + "lineaProduccionFabrica.xml";
            string pathStockProductos = path + "stockProductosFabrica.xml";

            if(File.Exists(pathInsumos) && File.Exists(pathLineaProduccion) && File.Exists(pathStockProductos))
            {
                serializadorInsumos.Save(pathInsumos, fabrica.StockInsumos);
                serializadorProductos.Save(pathLineaProduccion, fabrica.LineaProduccion);
                serializadorProductos.Save(pathStockProductos, fabrica.StockProductosTerminados);
            }
            else
            {
                throw new SaveFactoryException("Hubo errores al guardar los datos");
            }


        }

        public Fabrica ReadXmlFabrica()
        {
            Fabrica fabrica = Fabrica.Instance;

            string pathInsumos = path + "listadoInsumosFabrica.xml";
            string pathLineaProduccion = path + "lineaProduccionFabrica.xml";
            string pathStockProductos = path + "stockProductosFabrica.xml";

            List<Insumo> insumosStock = new List<Insumo>();
            List<Producto> lineaProduccion = new List<Producto>();
            List<Producto> stockProductosTerminados = new List<Producto>();

            try
            {
                serializadorInsumos.Read(pathInsumos, out insumosStock);
                serializadorProductos.Read(pathLineaProduccion, out lineaProduccion);
                serializadorProductos.Read(pathStockProductos, out stockProductosTerminados);



                fabrica.ResetearFabrica();

                fabrica.StockInsumos = insumosStock;
                fabrica.LineaProduccion = lineaProduccion;
                fabrica.StockProductosTerminados = stockProductosTerminados;
            }
            catch(Exception e)
            {
                throw new ReadFactoryException("Hubo errores al leer los archivos.");
            }

            return fabrica;
        }
    }
}
