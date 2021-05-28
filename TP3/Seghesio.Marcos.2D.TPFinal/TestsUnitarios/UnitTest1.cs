using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Collections.Generic;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Retorna_ListInsumoFaltante_Cuando_Recibe_Un_Producto_Sin_Stock_Suficiente()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            Insumo madera = new Madera(ETipoMadera.Mdf, EForma.Tablon, 5);
            Insumo maderaColumna = new Madera(ETipoMadera.Pino, EForma.Tubo, 3);
            Insumo tela = new Tela(EColor.Azul, ETela.Corderito, 5);
            GenericInventario<Insumo> stockInsumos = new GenericInventario<Insumo>();
            stockInsumos.listadoObjetos.Add(madera);
            Producto producto = new Torre((Madera)madera, (Tela)tela, Torre.ModeloTorre.King,(Madera)maderaColumna);
            List<Insumo> faltante = new List<Insumo>();
            faltante.Add(tela);

            //Act

            List<Insumo> resultado = fabrica.VerificarStockProducto(stockInsumos.listadoObjetos, producto);

            //Assert

            Assert.AreEqual(faltante[0], resultado[0]);
        }

        [TestMethod]
        public void Retorna_ListVacia_Cuando_Recibe_Un_Producto_Con_Stock_Suficiente()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            Insumo madera = new Madera(ETipoMadera.Mdf, EForma.Tablon, 5);
            Insumo maderaColumna = new Madera(ETipoMadera.Pino, EForma.Tubo, 3);
            Insumo tela = new Tela(EColor.Bordo, ETela.PolarSoft, 10);
            GenericInventario<Insumo> stockInsumos = new GenericInventario<Insumo>();
            stockInsumos.listadoObjetos.Add(madera);
            stockInsumos.listadoObjetos.Add(tela);
            stockInsumos.listadoObjetos.Add(maderaColumna);
            Producto producto = new Torre((Madera)madera, (Tela)tela, Torre.ModeloTorre.King, (Madera)maderaColumna);

            //Act

            List<Insumo> resultado = fabrica.VerificarStockProducto(stockInsumos.listadoObjetos, producto);

            //Assert

            Assert.AreEqual(0, resultado.Count);
        }
        [TestMethod]
        public void Retorna_Producto_Lijado_Cuando_Recibe_Un_Producto_Sin_Lijar()
        {
            Fabrica fabrica = Fabrica.Instance;
            Insumo madera = new Madera(ETipoMadera.Mdf, EForma.Tablon, 5);
            Insumo maderaColumna = new Madera(ETipoMadera.Pino, EForma.Tubo, 3);
            Insumo tela = new Tela(EColor.Bordo, ETela.PolarSoft, 10);
            GenericInventario<Insumo> stockInsumos = new GenericInventario<Insumo>();
            stockInsumos.listadoObjetos.Add(madera);
            stockInsumos.listadoObjetos.Add(tela);
            stockInsumos.listadoObjetos.Add(maderaColumna);
            Producto producto = new Torre((Madera)madera, (Tela)tela, Torre.ModeloTorre.King, (Madera)maderaColumna);

            //Act

            producto.LijarMaderaProducto(producto);

            //Assert

            Assert.AreEqual(Producto.EEstado.MaderasLijadas, producto.EstadoProducto);
        }

    }
}
