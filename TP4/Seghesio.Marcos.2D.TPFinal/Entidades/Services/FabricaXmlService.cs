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
            string pathProductos = path + "listadoProductosFabrica.xml";

            if(File.Exists(pathInsumos) && File.Exists(pathProductos))
            {
                serializadorInsumos.Save(pathInsumos, fabrica.ServicioInsumo.GetAll());
                serializadorProductos.Save(pathProductos, fabrica.ServicioProducto.GetAll());

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
            string pathProductos = path + "listadoProductosFabrica.xml";

            List<Insumo> insumosStock = new List<Insumo>();
            List<Producto> listadoProductos = new List<Producto>();

            try
            {
                serializadorInsumos.Read(pathInsumos, out insumosStock);
                serializadorProductos.Read(pathProductos, out listadoProductos);


                fabrica.ResetearFabrica();

                fabrica.ServicioInsumo.CreateEntity(insumosStock);
                fabrica.ServicioProducto.CreateEntity(listadoProductos);



            }
            catch(Exception e)
            {
                throw new ReadFactoryException("Hubo errores al leer los archivos.");
            }

            return fabrica;
        }
    }
}
