using Entidades;
using Entidades.Exceptions;
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




            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("----------Fabrica de Productos para Gatos: demostración Consola----------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

            // Declarar los objetos necesarios para leer archivos XML

            FabricaXmlService serviceXmlFabrica = new FabricaXmlService(AppDomain.CurrentDomain.BaseDirectory);
            Fabrica fabrica = serviceXmlFabrica.ReadXmlFabrica();

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Atributos asignados a fabrica correctamente---------------");
            Console.WriteLine("-------------------------------------------------------------------------------");

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
            Console.WriteLine("\n");
            foreach (Insumo i in fabrica.StockInsumos)
            {
                Console.WriteLine(i.Mostrar());
            }



            //2- Usuario da de alta un producto para agregar a la linea de producción

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("---------------------Se van a cargar dos nuevos productos----------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");


            Producto productoTorre = new Torre(new Madera(ETipoMadera.Mdf, EForma.Tablon, Fabrica.CANTIDAD_MADERA_TORRE_PRINCIPAL), new Tela(EColor.Bordo, ETipoTela.Alfombra, Fabrica.CANTIDAD_TELA_TORRE), Torre.EModeloTorre.Queen, new Madera(ETipoMadera.Pino, EForma.Tubo, Fabrica.CANTIDAD_MADERA_TORRE_COLUMNA));
            Producto productoEstante = new Estante(new Madera(ETipoMadera.Pino, EForma.Tablon, Fabrica.CANTIDAD_MADERA_ESTANTE), new Tela(EColor.Rosa, ETipoTela.Alfombra, Fabrica.CANTIDAD_TELA_ESTANTE),5);
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

            Console.WriteLine("----------------Lijar Maderas--------------------------------------------------\n");

            //3- Ejecutar procesos de linea de Producción

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);

            foreach(Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }

            Console.WriteLine("----------------Barnizar--------------------------------------------------------\n");

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);

            foreach (Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.WriteLine("----------------Alfombrar--------------------------------------------------------\n");

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);

            foreach (Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.WriteLine("----------------Agregar Yute------------------------------------------------------\n");
            fabrica.EjecutarProcesoLineaProduccion(EProceso.AgregarYute);

            foreach (Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.WriteLine("----------------Ensamblar----------------------------------------------------------\n");
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);

            foreach (Producto p in fabrica.LineaProduccion)
            {
                Console.WriteLine(p.Mostrar());
            }

            // 4 - Mudar productos terminados de la linea de producción al stock de productos terminados
            Console.WriteLine("------------------------------------------------------------------------------------------\n");
            Console.WriteLine("--Mudar productos terminados de la linea de producción al stock de productos terminados---\n");
            Console.WriteLine("------------------------------------------------------------------------------------------\n");

            fabrica.MudarProductosAStockTerminado();

            Console.WriteLine("------------------------------------------------------------------------------------------\n");
            Console.WriteLine("----------------Iterar lista de productos terminados de la fabrica -----------------------\n");
            Console.WriteLine("------------------------------------------------------------------------------------------\n");

            foreach (Producto p in fabrica.StockProductosTerminados)
            {
                Console.WriteLine(p.Mostrar());
            }

            // 5 - Guardar datos de fábrica en archivos XML

            Console.WriteLine("-------------------------------------------------------------------------------------------\n");
            Console.WriteLine("----------------Persistir atributos de fábrica en archivos XML-----------------------------\n");
            Console.WriteLine("-------------------------------------------------------------------------------------------\n");

            try
            {
                serviceXmlFabrica.SaveXmlFabrica(fabrica);
                Console.WriteLine("---------------------------------------------------------------------------------------\n");
                Console.WriteLine("----------------Datos guardados correctamente -----------------------------------------\n");
                Console.WriteLine("---------------------------------------------------------------------------------------\n");
            }
            catch(SaveFactoryException e)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------\n");
                Console.WriteLine("----------------Errores al guardar los datos ------------------------------------------\n");
                Console.WriteLine("---------------------------------------------------------------------------------------\n");
            }
            



        }
    }
}
