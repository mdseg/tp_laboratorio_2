using Entidades.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void ModificacionFabrica();

    [Serializable]
    public class Fabrica
    {
        private static Fabrica instance;
        public event ModificacionFabrica CambioRealizado;

        private ProductoService productoService;
        private InsumoService insumoService;
        bool lanzarEventos;

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




        public ProductoService ServicioProducto
        {
            get
            {
                return this.productoService;
            }            
        }

        public InsumoService ServicioInsumo
        {
            get
            {
                return this.insumoService;
            }
        }

        public bool LanzarEventos
        {
            get
            {
                return this.lanzarEventos;
            }
            set
            {
                this.lanzarEventos = value;
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
            this.insumoService = new InsumoService(@"Data Source=.;Initial Catalog=TPFinalMarcosSeghesio;Integrated Security=True");
            this.productoService = new ProductoService(@"Data Source=.;Initial Catalog=TPFinalMarcosSeghesio;Integrated Security=True");
            this.LanzarEventos = true;
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
                foreach(Insumo insumo in this.insumoService.GetAll())
                {
                    if(insumo == insumoProducto)
                    {
                        if(insumoProducto.Cantidad <= insumo.Cantidad)
                        {
                            insumoEncontrado = true;
                            insumoProducto.Id = insumo.Id;
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
                Insumo bufferInsumo = insumoService.GetEntityById(i);
               bufferInsumo.Cantidad = bufferInsumo.Cantidad - i.Cantidad;
               if(bufferInsumo.Cantidad > 0)
               {
                    insumoService.UpdateEntity(bufferInsumo);
               }
               else
               {
                    insumoService.DeleteEntity(bufferInsumo);
               }

                            
            }
            EmitirEvento();
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
                this.ServicioProducto.CreateEntity(prospectoProducto);
                output = true;
                EmitirEvento();
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
                insumoService.CreateEntity(insumo);
                output = true;
                EmitirEvento();
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
            EmitirEvento();
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
            if(proceso != EProceso.Despachar)
            {
                foreach (Producto producto in this.ServicioProducto.GetAll())
                {
                    bool procesoRealizado = false;
                    switch (proceso)
                    {
                        case EProceso.Lijar:

                            procesoRealizado = producto.LijarMaderaProducto();
                            ServicioProducto.UpdateEntity(producto);
                            break;
                        case EProceso.Barnizar:
                            if (producto is Estante)
                            {
                                procesoRealizado = ((Estante)producto).BarnizarProducto();
                                ServicioProducto.UpdateEntity(producto);
                            }
                            break;
                        case EProceso.Alfombrar:
                            procesoRealizado = producto.AlfombrarProducto();
                            ServicioProducto.UpdateEntity(producto);
                            break;
                        case EProceso.AgregarYute:
                            if (producto is Torre)
                            {
                                procesoRealizado = ((Torre)producto).AgregarYute();
                                ServicioProducto.UpdateEntity(producto);
                            }
                            break;
                        case EProceso.Ensamblar:
                            procesoRealizado = producto.EnsamblarProducto();
                            ServicioProducto.UpdateEntity(producto);
                            break;

                    }
                    if (procesoRealizado)
                    {
                        output++;
                    }
                }

                    EmitirEvento();
            }
            else
            {

                output = MudarProductosAStockTerminado();
            }
            
            return output;

        }
        /// <summary>
        /// Método que limpia los atributos de la fábrica
        /// </summary>
        public void ResetearFabrica()
        {
            this.productoService.DeleteAll();
            this.insumoService.DeleteAll();
            EmitirEvento();
        }
        /// <summary>
        /// Itera la lista de linea de producción, separando los productos que esten en estado Completo
        /// </summary>
        /// <returns></returns>
        public int MudarProductosAStockTerminado()
        {
            int output = 0;
            foreach (Producto producto in this.ServicioProducto.GetAll())
            {
                if (producto.EstadoProducto == EEstado.Completo)
                {
                    producto.EstadoProducto = EEstado.Despachado;
                    this.ServicioProducto.UpdateEntity(producto);
                    output++;
                }
            }
            EmitirEvento();
            return output;
        }
        /// <summary>
        /// Calcula el número de elementos disponibles para aplicarse cierto proceso productivo devolviendo un listado con estos productos aptos
        /// </summary>
        /// <param name="proceso"></param>
        /// <param name="listadoProductos"></param>
        /// <returns></returns>
        public int CalcularCantidadDeProductosAptosProceso(EProceso proceso, out List<Producto> listadoProductos)
        {
            int output = 0;
            listadoProductos = new List<Producto>();
            foreach (Producto producto in this.productoService.GetAll())
            {
                switch(proceso)
                {
                    case EProceso.Lijar:
                        if(producto.EstadoProducto == EEstado.Planificado)
                        {
                            output++;
                            listadoProductos.Add(producto);
                        }
                        break;
                    case EProceso.Barnizar:
                        if(producto is Estante && producto.EstadoProducto == EEstado.MaderasLijadas )
                        {
                            output++;
                            listadoProductos.Add(producto);
                        }
                        break;
                    case EProceso.Alfombrar:
                        if((producto is Torre && producto.EstadoProducto == EEstado.MaderasLijadas) ||
                            (producto.EstadoProducto == EEstado.Barnizado))
                        {
                            output++;
                            listadoProductos.Add(producto);
                        }
                        break;
                    case EProceso.AgregarYute:
                        if(producto is Torre && producto.EstadoProducto == EEstado.Alfombrado && ((Torre)producto).MetrosYute > 0)
                        {
                            output++;
                            listadoProductos.Add(producto);
                        }
                        break;
                    case EProceso.Ensamblar:
                        if (producto is Torre)
                        {
                            if ((producto.EstadoProducto == EEstado.Alfombrado && ((Torre)producto).MetrosYute == 0) ||
                                (producto.EstadoProducto == EEstado.AdicionalesAgregados))
                            {
                                output++;
                                listadoProductos.Add(producto);
                            }
                        } else if( producto.EstadoProducto == EEstado.Alfombrado)
                        {
                            output++;
                            listadoProductos.Add(producto);
                        }
                        break;
                    case EProceso.Despachar:
                        if(producto.EstadoProducto == EEstado.Completo)
                        {
                            output++;
                            listadoProductos.Add(producto);
                        }
                        break;

                }
            }


            return output;
        }
        /// <summary>
        /// Método encargado de emitir el evento de cambio realizado cuando sea necesario que la fábrica comunique cambios a la interfaz gráfica, este método no
        /// es llamado cuando se ejecutan los test unitarios
        /// </summary>
        public void EmitirEvento()
        {
            if(this.lanzarEventos)
            {
                try
                {
                    this.CambioRealizado.Invoke();
                }
                catch (Exception e)
                {

                }
            }

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
        Ensamblar,
        Despachar
    }
}
