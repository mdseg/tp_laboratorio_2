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


            Console.Title = "Seghesio, Marcos Daniel TP3 2D";


            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("----------Fabrica de Productos para Gatos: demostración Consola--------");
            Console.WriteLine("-----------------------------------------------------------------------");


            Console.WriteLine("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
             Console.ReadKey();


            // Declarar los objetos necesarios para leer archivos XML
            Fabrica fabrica = Fabrica.Instance;
            fabrica.LanzarEventos = false;
            fabrica.ResetearFabrica();
            FabricaXmlService serviceXmlFabrica = new FabricaXmlService($"{AppDomain.CurrentDomain.BaseDirectory}Origen\\");
            fabrica = serviceXmlFabrica.ReadXmlFabrica();
            fabrica.LanzarEventos = false;

            Console.WriteLine("\n-----------------------------------------------------------------------");
            Console.WriteLine("------------Atributos asignados a fabrica correctamente----------------");
            Console.WriteLine("-----------------------------------------------------------------------");


            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("---------------------Iterar lista de insumos --------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");


            foreach (Insumo i in fabrica.ServicioInsumo.GetAll())
            {
                Console.WriteLine(i.Mostrar());
            }

            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
            Console.ReadKey();
            Console.Clear();

            //1- Usuario Ingresa insumos a fabrica existente

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("---------------------Agregar nuevos Insumos----------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            List<Insumo> insumosAgregar = new List<Insumo>();

            Insumo maderaUno = new Madera(ETipoMadera.Pino, EForma.Tablon, 10);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Pino, EForma.Tubo, 5);
            Insumo telaUno = new Tela(EColor.Rosa, ETipoTela.Alfombra, 15);
            

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 10);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 24);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 10);
            Insumo adicionalCuatro = new InsumoAccesorio(ETipoAccesorio.Yute, 10);



            insumosAgregar += maderaUno;
            insumosAgregar += maderaUno;
            insumosAgregar += maderaSecundaria;
            insumosAgregar += telaUno;
            insumosAgregar += adicionalUno;
            insumosAgregar += adicionalDos;
            insumosAgregar += adicionalTres;
            insumosAgregar += adicionalCuatro;

            insumosAgregar += maderaUno;

            fabrica.AgregarInsumosAStock(insumosAgregar);

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("-------Insumos agregados con éxito-------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine("--Se itera de nuevo el stock de insumos----------------------------");
             foreach (Insumo i in fabrica.ServicioInsumo.GetAll())
            {
                Console.WriteLine(i.Mostrar());
            }

            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
            Console.WriteLine("\n-----------------------------------------------------------------------");
            Console.ReadKey();
            Console.Clear();


            //2- Usuario da de alta un producto para agregar a la linea de producción

            Console.WriteLine("\n-----------------------------------------------------------------------");
            Console.WriteLine("--------Se van a cargar dos nuevos productos---------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            Producto productoTorre = new Torre(new Madera(ETipoMadera.Mdf, EForma.Tablon, Fabrica.CANTIDAD_MADERA_TORRE_PRINCIPAL), new Tela(EColor.Bordo, ETipoTela.Alfombra, Fabrica.CANTIDAD_TELA_TORRE), Torre.EModeloTorre.Queen, new Madera(ETipoMadera.Pino, EForma.Tubo, Fabrica.CANTIDAD_MADERA_TORRE_COLUMNA), 3);
            Producto productoEstante = new Estante(new Madera(ETipoMadera.Pino, EForma.Tablon, Fabrica.CANTIDAD_MADERA_ESTANTE), new Tela(EColor.Rosa, ETipoTela.Alfombra, Fabrica.CANTIDAD_TELA_ESTANTE),5);
            List<Insumo> faltantes = new List<Insumo>();

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("-----Productos cargados, se procedera a iterar-------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            fabrica.AgregarProductoLineaProduccion(productoTorre, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoEstante, out faltantes);

            foreach(Producto p in fabrica.ServicioProducto.GetAllProductosLineaProduccion())
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");

            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("---Se van a ejecutar los procesos de la fábrica en orden---------------");
            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
            Console.ReadKey();


            Console.WriteLine("\n-----------------------------------------------------------------------");


            Console.WriteLine("----------------Lijar Maderas------------------------------------------");

            //3- Ejecutar procesos de linea de Producción

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);

            foreach(Producto p in fabrica.ServicioProducto.GetAllProductosLineaProduccion())
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n----------------Barnizar---------------------------------------------");

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);

            foreach (Producto p in fabrica.ServicioProducto.GetAllProductosLineaProduccion())
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n----------------Alfombrar--------------------------------------------");

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);

            foreach (Producto p in fabrica.ServicioProducto.GetAllProductosLineaProduccion())
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\n----------------Agregar Yute-----------------------------------------");
            fabrica.EjecutarProcesoLineaProduccion(EProceso.AgregarYute);

            foreach (Producto p in fabrica.ServicioProducto.GetAllProductosLineaProduccion())
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n----------------Ensamblar--------------------------------------------");
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);

            foreach (Producto p in fabrica.ServicioProducto.GetAllByEstado(EEstado.Completo))
            {
                Console.WriteLine(p.Mostrar());
            }
            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
            Console.ReadKey();
            Console.Clear();



            // 4 - Mudar productos terminados de la linea de producción al stock de productos terminados

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("--Mudar productos terminados  al stock de productos terminados-----------");
            Console.WriteLine("-------------------------------------------------------------------------");


            fabrica.MudarProductosAStockTerminado();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("--------Iterar lista de productos despachados de la fabrica-------------");
            Console.WriteLine("-----------------------------------------------------------------------");


            foreach (Producto p in fabrica.ServicioProducto.GetAllByEstado(EEstado.Despachado))
            {
                Console.WriteLine(p.Mostrar());
            }

            Console.Write("------------PRESIONE UNA TECLA PARA CONTINUAR--------------------------");
            Console.ReadKey();
            Console.Clear();


            // 5 - Guardar datos de fábrica en archivos XML
            Console.WriteLine("\n-----------------------------------------------------------------------");
            Console.WriteLine("----------------Persistir atributos de fábrica en archivos XML---------");
            Console.WriteLine("-----------------------------------------------------------------------");


            try
            {
                serviceXmlFabrica.Path = $"{AppDomain.CurrentDomain.BaseDirectory}Destino\\";
                serviceXmlFabrica.SaveXmlFabrica(fabrica);
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("----------------Datos guardados correctamente -------------------------");
                Console.WriteLine("-----------------------------------------------------------------------");
            }
            catch (SaveFactoryException e)
            {
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("----------------Errores al guardar los datos --------------------------");
                Console.WriteLine("-----------------------------------------------------------------------");
            }




        }
    }
}
