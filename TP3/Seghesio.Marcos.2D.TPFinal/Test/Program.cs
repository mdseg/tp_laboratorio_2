using Entidades;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar la fábrica para poder probar todos los eventos
            Fabrica fabrica = Fabrica.Instance;

            //1- Usuario Ingresa insumos

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 10);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 5);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 15);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 10);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 24);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 10);

            List<Insumo> insumosAgregar = new List<Insumo>();

            insumosAgregar += maderaUno;
            insumosAgregar += maderaSecundaria;
            insumosAgregar += telaUno;
            insumosAgregar += adicionalUno;
            insumosAgregar += adicionalDos;
            insumosAgregar += adicionalTres;

            insumosAgregar += maderaUno;

            // Agregar a fabrica

            fabrica.AgregarInsumosAStock(insumosAgregar);

            // Obtener y mostrar

            List<Insumo> insumosCargados = fabrica.StockInsumos;

            /*
            foreach(Insumo i in insumosCargados)
            {
                Console.WriteLine(i.Mostrar());
            }
            */
            //2- Usuario da de alta un producto para agregar a la linea de producción

            Producto productoValido = new Torre(new Madera(ETipoMadera.Mdf, EForma.Tablon, 4), new Tela(EColor.Bordo, ETipoTela.Alfombra, 3), Torre.EModeloTorre.King, new Madera(ETipoMadera.Mdf, EForma.Tubo, 2));
            List<Insumo> faltantes = new List<Insumo>();

            fabrica.AgregarProductoLineaProduccion(productoValido, out faltantes);

            
            fabrica.AgregarProductoLineaProduccion(productoValido, out faltantes);

            /*
            foreach (Insumo i in insumosCargados)
            {
                Console.WriteLine(i.Mostrar());
            }
            */

            // Caso de error
        }
    }
}
