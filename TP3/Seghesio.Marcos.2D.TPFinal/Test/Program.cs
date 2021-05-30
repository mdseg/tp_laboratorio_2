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
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);

            // Agregar a fabrica

            fabrica.AgregarInsumosAStock(insumosAgregar);

            // Obtener y mostrar

            List<Insumo> insumosCargados = fabrica.StockInsumos;

            foreach(Insumo i in insumosCargados)
            {
                Console.WriteLine(i.Mostrar());
            }

            //2- Usuario da de alta un producto para agregar a la linea de producción

            Producto productoValido = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            List<Insumo> faltantes = new List<Insumo>();

            fabrica.AgregarProductoLineaProduccion(productoValido, out faltantes);

            foreach (Insumo i in insumosCargados)
            {
                Console.WriteLine(i.Mostrar());
            }

            // Caso de error
        }
    }
}
