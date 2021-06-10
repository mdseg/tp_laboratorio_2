using Entidades;
using Files;
using Files.Xml;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declarar los objetos necesarios para leer archivos XML

            Console.WriteLine(Directory.GetCurrentDirectory());


            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("----------Fabrica de Productos para Gatos: demostración Consola----------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            FabricaXmlService serviceXmlFabrica = new FabricaXmlService(AppDomain.CurrentDomain.BaseDirectory);
            Fabrica fabrica = serviceXmlFabrica.ReadXmlFabrica();

            /*
            IFile<List<Insumo>> serializadorInsumos = new Xml<List<Insumo>>();
            IFile<List<Producto>> serializadorProductos = new Xml<List<Producto>>();

            
            string rutaInsumos = AppDomain.CurrentDomain.BaseDirectory + "listaInsumosTest.xml";
            string rutaLineaProduccion = AppDomain.CurrentDomain.BaseDirectory + "lineaProduccionTest.xml";
            string rutaProductosTerminados = AppDomain.CurrentDomain.BaseDirectory + "productosTerminadosTest.xml";

            List<Insumo> insumosStock = new List<Insumo>();
            List<Producto> lineaProduccion = new List<Producto>();
            List<Producto> stockProductosTerminados = new List<Producto>();

            try
            {
                serializadorInsumos.Read(rutaInsumos, out insumosStock);
                serializadorProductos.Read(rutaLineaProduccion, out lineaProduccion);
                serializadorProductos.Read(rutaProductosTerminados, out stockProductosTerminados);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            Console.WriteLine("\n\n\n");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Archivos leidos correctamente-----------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            */
            // Instancia fabrica y asigna valores leidos en el archivo XML
            /*
            Fabrica fabrica = Fabrica.Instance;

            fabrica.StockInsumos = insumosStock;
            fabrica.LineaProduccion = lineaProduccion;
            fabrica.StockProductosTerminados = stockProductosTerminados;
            */
            Console.WriteLine("\n\n\n");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Atributos asignados a fabrica correctamente---------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.WriteLine("\n\n\n");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Iterar lista de insumos ----------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Insumo i in fabrica.StockInsumos)
            {
                Console.WriteLine(i.Mostrar());
            }

            //1- Usuario Ingresa insumos a fabrica existente

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Agregar nuevos Insumos------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            List<Insumo> insumosAgregar = new List<Insumo>();

            Insumo maderaUno = new Madera(ETipoMadera.Pino, EForma.Tablon, 10);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Pino, EForma.Tubo, 5);
            Insumo telaUno = new Tela(EColor.Rosa, ETipoTela.Alfombra, 15);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 10);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 24);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 10);



            insumosAgregar += maderaUno;
            insumosAgregar += maderaSecundaria;
            insumosAgregar += telaUno;
            insumosAgregar += adicionalUno;
            insumosAgregar += adicionalDos;
            insumosAgregar += adicionalTres;

            insumosAgregar += maderaUno;

            fabrica.AgregarInsumosAStock(insumosAgregar);

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Insumos agregados con éxito-------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.WriteLine("---------------------Se itera de nuevo el stock de insumos----------------------");
            foreach (Insumo i in fabrica.StockInsumos)
            {
                Console.WriteLine(i.Mostrar());
            }



            //2- Usuario da de alta un producto para agregar a la linea de producción

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Se van a cargar dos nuevos productos----------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");


            Producto productoTorre = new Torre(new Madera(ETipoMadera.Mdf, EForma.Tablon, 4), new Tela(EColor.Bordo, ETipoTela.Alfombra, 3), Torre.EModeloTorre.Queen, new Madera(ETipoMadera.Mdf, EForma.Tubo, 2));
            Producto productoEstante = new Estante(new Madera(ETipoMadera.Pino, EForma.Tablon, 4), new Tela(EColor.Rosa, ETipoTela.Alfombra, 3),5);
            List<Insumo> faltantes = new List<Insumo>();

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Productos cargados, se procedera a iterar-----------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            fabrica.AgregarProductoLineaProduccion(productoTorre, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoEstante, out faltantes);

            foreach(Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("----------------Se van a ejecutar los porceos de la fábrica en orden-----------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.WriteLine("----------------Lijar Maderas------------------------------------------------------------------------------------------------\n");

            //3- Ejecutar procesos de linea de Producción

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);

            foreach(Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }

            Console.WriteLine("----------------Barnizar------------------------------------------------------------------------------------------------------\n");

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);

            foreach (Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.WriteLine("----------------Alfombrar-----------------------------------------------------------------------------------------------------\n");

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);

            foreach (Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.WriteLine("----------------Agregar Yute---------------------------------------------------------------------------------------------------\n");
            fabrica.EjecutarProcesoLineaProduccion(EProceso.AgregarYute);

            foreach (Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.WriteLine("----------------Ensamblar-----------------------------------------------------------------------------------------------------\n");
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);

            foreach (Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }

            // 4 - Mudar productos terminados de la linea de producción al stock de productos terminados
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("----------------Mudar productos terminados de la linea de producción al stock de productos terminados--------------------------\n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------\n");

            fabrica.MudarProductosAStockTerminado();

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("----------------Iterar lista de productos terminados de la fabrica ------------------------------------------------------------\n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------\n");

            foreach (Producto p in fabrica.StockProductosTerminados)
            {
                Console.WriteLine(p.Mostrar());
            }

            // 5 - Guardar datos de fábrica en archivos XML

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("----------------Persistir atributos de fábrica en archivos XML-----------------------------------------------------------------\n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------\n");

            /*
            string rutaInsumosAlternativa = AppDomain.CurrentDomain.BaseDirectory + "listaInsumosTestAlternativo.xml";
            string rutaLineaProduccionAlternativa = AppDomain.CurrentDomain.BaseDirectory + "lineaProduccionTestAlternativa.xml";
            string rutaStockInsumosAlternativa = AppDomain.CurrentDomain.BaseDirectory + "stockInsumosAlternativa.xml";

            try
            {
                serializadorInsumos.Save(rutaInsumosAlternativa, fabrica.StockInsumos);
                serializadorProductos.Save(rutaLineaProduccionAlternativa, fabrica.LineaProduccion);
                serializadorProductos.Save(rutaStockInsumosAlternativa, fabrica.StockProductosTerminados);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            */

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("----------------Datos guardados correctamente ---------------------------------------------------------------------------------\n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------\n");

        }
    }
}
