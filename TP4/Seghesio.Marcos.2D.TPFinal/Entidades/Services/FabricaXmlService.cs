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
    /// <summary>
    /// Clase que implementa la intefaz genérica IFile para serializar y desserializar en XML los datos correspondientes a insumos y productos
    /// </summary>
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

        /// <summary>
        /// Constructor que inicializa los campos y asigna el directorio donde se leeran y guardaran los archivos
        /// </summary>
        /// <param name="path"></param>
        public FabricaXmlService(string path)
        {
            this.serializadorInsumos = new Xml<List<Insumo>>();
            this.serializadorProductos = new Xml<List<Producto>>();
            this.path = path;
        }
        /// <summary>
        /// Metodo encargado de persistir en xml los datos de los insumos y productos en fábrica
        /// </summary>
        /// <param name="fabrica"></param>
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
        /// <summary>
        /// Metodo encargado de leer en xml los datos de los insumos y productos en fábrica
        /// </summary>
        /// <returns></returns>
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
