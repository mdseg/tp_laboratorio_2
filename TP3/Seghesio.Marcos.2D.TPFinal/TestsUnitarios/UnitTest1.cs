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
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 10);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 5);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 15);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 6);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 24);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 1);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoValido = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            bool resultado = fabrica.AgregarProductoLineaProduccion(productoValido,out faltantes);
            

            //Assert
            
            Assert.IsTrue(adicionalTres == faltantes[0]);
            Assert.IsTrue(faltantes[0].Cantidad == 2);
        }
        [TestMethod]
        public void Retorna_True_Cuando_Recibe_Un_Producto_Con_Stock_Suficiente()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 10);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 5);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 15);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 6);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 24);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 6);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoValido = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            bool resultado = fabrica.AgregarProductoLineaProduccion(productoValido, out faltantes);


            //Assert

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Retorna_Tres_Cuando_Se_Lijaron_Todos_Los_Productos_Para_Lijar()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            //Assert

            Assert.AreEqual(3, numeroModificados);
        }
        [TestMethod]
        public void Retorna_Cero_Cuando_No_Hay_Productos_Para_Lijar()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            //Assert

            Assert.AreEqual(0, numeroModificados);
        }
        [TestMethod]
        public void Retorna_Cero_Cuando_No_Hay_Productos_Para_Barnizar()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            
            //Assert

            Assert.AreEqual(0, numeroModificados);
        }
        [TestMethod]
        public void Retorna_Uno_Cuando_Hay_Productos_Para_Barnizar()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);

            //Assert

            Assert.AreEqual(1, numeroModificados);
        }
        [TestMethod]
        public void Retorna_Cero_Cuando_No_Hay_Productos_Para_Alfombrar()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);


            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);

            //Assert

            Assert.AreEqual(0, numeroModificados);
        }

        [TestMethod]
        public void Retorna_Tres_Cuando_Hay_Productos_Para_Alfombrar()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);
            //Assert

            Assert.AreEqual(3, numeroModificados);
        }

        [TestMethod]
        public void Retorna_Cero_Cuando_No_Hay_Productos_Para_Ensamblar()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);


            //Assert

            Assert.AreEqual(0, numeroModificados);
        }

        [TestMethod]
        public void Retorna_Tres_Cuando_Hay_Productos_Para_Ensamblar()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);
            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);


            //Assert

            Assert.AreEqual(3, numeroModificados);
        }

        [TestMethod]
        public void Retorna_Tres_Cuando_Hay_Productos_Terminados_Y_Los_Envia_A_Stock_Permanente()
        {
            // Arrange

            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();

            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 100);
            Insumo maderaDos = new Madera(ETipoMadera.Pino, EForma.Tablon, 200);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 100);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 100);
            Insumo telaDos = new Tela(EColor.Rosa, ETipoTela.Corderito, 200);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 300);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 300);
            Insumo adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 300);

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaDos);

            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);
            insumosAgregar.Add(telaDos);

            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre((Madera)maderaUno, (Tela)telaUno, Torre.ModeloTorre.King, (Madera)maderaSecundaria);
            Producto productoDos = new Torre((Madera)maderaDos, (Tela)telaDos, Torre.ModeloTorre.Queen, (Madera)maderaSecundaria);
            Producto productoTres = new Estante((Madera)maderaUno, (Tela)telaDos, 5);
            fabrica.AgregarInsumosAStock(insumosAgregar);
            //Act

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);
            int numeroModificados = fabrica.MudarProductosAStockTerminado();


            //Assert

            Assert.AreEqual(3, numeroModificados);
        }
        /*
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
        */
    }
}
