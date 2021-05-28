using Entidades;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Insumo madera = new Madera(ETipoMadera.Mdf, EForma.Tablon, 5);
            Insumo tela = new Tela(EColor.Bordo, ETela.PolarSoft, 10);
            Insumo tela2 = new Tela(EColor.Azul, ETela.Corderito, 5);
            GenericInventario<Insumo> stockInsumos = new GenericInventario<Insumo>();
            stockInsumos.listadoObjetos.Add(madera);
            stockInsumos.listadoObjetos.Add(tela);
            /*
            foreach(Insumo i in stockInsumos.listadoObjetos)
            {
                Console.WriteLine(i.Mostrar());
            }
            */
            Producto producto = new Torre((Madera)madera, (Tela)tela2, Torre.ModeloTorre.King,new Madera(ETipoMadera.Pino,EForma.Tubo,2));
            Console.WriteLine(producto.Mostrar());

            List<Insumo> desarmado = (List<Insumo>)producto;
            /*
            foreach (Insumo i in desarmado)
            {
                Console.WriteLine(i.Mostrar());
            }
            */
            Fabrica fabrica = Fabrica.Instance;
            fabrica.VerificarStockProducto(stockInsumos.listadoObjetos, producto);
            
            /*
            Insumo madera2 = new Madera(ETipoMadera.Mdf, EForma.Tubo, 3);
            bool prueba = (madera == madera2);
            */
        }
    }
}
