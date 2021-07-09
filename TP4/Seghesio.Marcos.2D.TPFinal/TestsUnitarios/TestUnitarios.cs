using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Collections.Generic;

namespace TestsUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Retorna los insumos que faltan cuando intencionalmente no se cargan todos los insumos necesarios para la fabricacion del producto
        /// Incluye conceptos de la clase 16 Test Unitarios
        /// </summary>
        [TestMethod]
        public void Retorna_ListInsumoFaltante_Cuando_Recibe_Un_Producto_Sin_Stock_Suficiente()
        {
            // Arrange

            List<Insumo> faltantes = new List<Insumo>();
            
            Fabrica fabrica = getFabricaTest(false);

            Producto productoValido = getTorreValido();
            //Act

            bool resultado = fabrica.AgregarProductoLineaProduccion(productoValido,out faltantes);
            

            //Assert
            
            Assert.IsTrue(new InsumoAccesorio(ETipoAccesorio.Pegamento, 1) == faltantes[0]);
            Assert.IsTrue(faltantes[0].Cantidad == 2);
        }
        /// <summary>
        /// Test de creación correcta de tres productos existiendo stock suficiente
        /// </summary>
        [TestMethod]
        public void Retorna_True_Cuando_Recibe_Un_Producto_Con_Stock_Suficiente_Y_Elimina_Insumos_Del_Stock_Original()
        {
            // Arrange

            int cantidadMaderaPrincipal = 0;
            int cantidadMaderaSecundaria = 0;
            int cantidadTela = 0;
            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 10);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 5);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 15);

            List<Insumo> faltantes = new List<Insumo>();

            Fabrica fabrica = getFabricaTest(true);

            Producto productoValido = getTorreValido();

            //Act

            bool resultado = fabrica.AgregarProductoLineaProduccion(productoValido, out faltantes);


            //Assert



            foreach(Insumo i in fabrica.ServicioInsumo.GetAll())
            {
                if(i == maderaUno)
                {
                    cantidadMaderaPrincipal += i.Cantidad;
                }
                else if(i == maderaSecundaria)
                {
                    cantidadMaderaSecundaria += i.Cantidad;
                }
                else if(i == telaUno)
                {
                    cantidadTela += i.Cantidad;
                }
            }
            Assert.IsTrue(resultado);
            Assert.AreEqual(6, cantidadMaderaPrincipal);
            Assert.AreEqual(2, cantidadMaderaSecundaria);
            Assert.AreEqual(12, cantidadTela);
        }

        /// <summary>
        /// Prueba del primer proceso de fabricación el cual se aplica a todo tipo de producto que este como "Planificado"
        /// </summary>
        [TestMethod]
        public void Retorna_Tres_Cuando_Se_Lijaron_Todos_Los_Productos_Para_Lijar()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();
           
            //Act

            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);

            //Assert

            Assert.AreEqual(3, numeroModificados);
        }
        /// <summary>
        /// Teste que vuelve a intentar lijar productos previente lijados
        /// </summary>
        [TestMethod]
        public void Retorna_Cero_Cuando_No_Hay_Productos_Para_Lijar()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();

            //Act

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            //Assert

            Assert.AreEqual(0, numeroModificados);
        }
        /// <summary>
        /// Test que intenta barnizar productos que no están aptos para dicho proceso
        /// </summary>
        [TestMethod]
        public void Retorna_Cero_Cuando_No_Hay_Productos_Para_Barnizar()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();

            //Act

            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            
            //Assert

            Assert.AreEqual(0, numeroModificados);
        }
        /// <summary>
        /// Test que prueba barnizar tres productos siendo solo el Estante el unico apto para este proceso
        /// </summary>
        [TestMethod]
        public void Retorna_Uno_Cuando_Hay_Productos_Para_Barnizar()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();

            //Act

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);

            //Assert

            Assert.AreEqual(1, numeroModificados);
        }
        /// <summary>
        /// Test que retorna cero cuando no hay productos aptos para ser alfombrados
        /// </summary>
        [TestMethod]
        public void Retorna_Cero_Cuando_No_Hay_Productos_Para_Alfombrar()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();

            //Act

            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);

            //Assert

            Assert.AreEqual(0, numeroModificados);
        }

        /// <summary>
        /// Test que prueba alfombrar tres productos actos para dicho procedimiento
        /// </summary>
        [TestMethod]
        public void Retorna_Tres_Cuando_Hay_Productos_Para_Alfombrar()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();

            //Act

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);
            //Assert

            Assert.AreEqual(3, numeroModificados);
        }

        /// <summary>
        /// Test que prueba ejecutar el proceso de ensamblar no habiendo productos aptos para este procedimiento, retornando 0
        /// </summary>
        [TestMethod]
        public void Retorna_Cero_Cuando_No_Hay_Productos_Para_Ensamblar()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();

            //Act

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);


            //Assert

            Assert.AreEqual(0, numeroModificados);
        }
        /// <summary>
        /// Test que intenta ensamblar tres productos aptos para este procedimiento
        /// </summary>
        [TestMethod]
        public void Retorna_Tres_Cuando_Hay_Productos_Para_Ensamblar()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();

            //Act

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);
            int numeroModificados = fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);


            //Assert

            Assert.AreEqual(3, numeroModificados);
        }
        /// <summary>
        /// Test que verifica que todos los productos que esten en estado Completado sean enviados al Stock de Productos terminados
        /// </summary>
        [TestMethod]
        public void Retorna_Tres_Cuando_Hay_Productos_Terminados_Y_Los_Envia_A_Stock_Permanente()
        {
            // Arrange

            Fabrica fabrica = getFabricaCompleta();

            //Act

            fabrica.EjecutarProcesoLineaProduccion(EProceso.Lijar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Barnizar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Alfombrar);
            fabrica.EjecutarProcesoLineaProduccion(EProceso.Ensamblar);
            int numeroModificados = fabrica.MudarProductosAStockTerminado();


            //Assert

            Assert.AreEqual(3, numeroModificados);
        }
        /// <summary>
        /// Este método es utilizado para preparar una fabrica para los test de dar de alta un producto, con la variable si stockPegamentoCompleto es true, habrá
        /// suficiente stock para dar de alta una torre, en el caso de que sea false no lo habrá
        /// </summary>
        /// <param name="stockPegamentoCompleto"></param>
        /// <returns></returns>
        public Fabrica getFabricaTest(bool stockPegamentoCompleto)
        {
            Fabrica fabrica = Fabrica.Instance;
            fabrica.ResetearFabrica();
            Insumo adicionalTres;
            Insumo maderaUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 10);
            Insumo maderaSecundaria = new Madera(ETipoMadera.Mdf, EForma.Tubo, 5);
            Insumo telaUno = new Tela(EColor.Bordo, ETipoTela.Alfombra, 15);

            Insumo adicionalUno = new InsumoAccesorio(ETipoAccesorio.Barniz, 6);
            Insumo adicionalDos = new InsumoAccesorio(ETipoAccesorio.Tornillo, 24);
            if(stockPegamentoCompleto)
            {
                adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 6);
            }
            else
            {
                adicionalTres = new InsumoAccesorio(ETipoAccesorio.Pegamento, 1);
            }
 

            List<Insumo> insumosAgregar = new List<Insumo>();
            insumosAgregar.Add(adicionalUno);
            insumosAgregar.Add(adicionalDos);
            insumosAgregar.Add(adicionalTres);
            insumosAgregar.Add(maderaUno);
            insumosAgregar.Add(maderaSecundaria);
            insumosAgregar.Add(telaUno);

            fabrica.AgregarInsumosAStock(insumosAgregar);

            return fabrica;
        }
        /// <summary>
        /// Genera un Producto del tipo torre para hacer pruebas
        /// </summary>
        /// <returns></returns>
        public Producto getTorreValido()
        {

            Madera maderaProducto = new Madera(ETipoMadera.Mdf, EForma.Tablon, 4);
            Madera maderaSecundariaProducto = new Madera(ETipoMadera.Mdf, EForma.Tubo, 3);
            Tela telaProducto = new Tela(EColor.Bordo, ETipoTela.Alfombra, 3);

            Producto output = new Torre(maderaProducto, telaProducto, Torre.EModeloTorre.King, maderaSecundariaProducto);
            return output;
        }
        /// <summary>
        /// Genera una fabrica con tres productos válidos para utilizarse en las pruebas de fabricación
        /// </summary>
        /// <returns></returns>
        public Fabrica getFabricaCompleta()
        {
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

            Madera maderaProductoUno = new Madera(ETipoMadera.Mdf, EForma.Tablon, 4);
            Madera maderaSecundariaProducto = new Madera(ETipoMadera.Mdf, EForma.Tubo, 3);
            Tela telaProducto = new Tela(EColor.Bordo, ETipoTela.Alfombra, 3);


            List<Insumo> faltantes = new List<Insumo>();
            Producto productoUno = new Torre(new Madera(ETipoMadera.Mdf, EForma.Tablon, Fabrica.CANTIDAD_MADERA_TORRE_PRINCIPAL), new Tela(EColor.Bordo, ETipoTela.Alfombra, Fabrica.CANTIDAD_TELA_TORRE), Torre.EModeloTorre.King, new Madera(ETipoMadera.Mdf, EForma.Tubo, Fabrica.CANTIDAD_MADERA_TORRE_COLUMNA));
            Producto productoDos = new Torre(new Madera(ETipoMadera.Pino, EForma.Tablon, Fabrica.CANTIDAD_MADERA_TORRE_PRINCIPAL), new Tela(EColor.Rosa, ETipoTela.Corderito, Fabrica.CANTIDAD_TELA_TORRE), Torre.EModeloTorre.King, new Madera(ETipoMadera.Mdf, EForma.Tubo, Fabrica.CANTIDAD_MADERA_TORRE_COLUMNA));
            Producto productoTres = new Estante(new Madera(ETipoMadera.Mdf, EForma.Tablon, Fabrica.CANTIDAD_MADERA_ESTANTE), new Tela(EColor.Rosa, ETipoTela.Corderito, Fabrica.CANTIDAD_TELA_ESTANTE), 3);

            fabrica.AgregarInsumosAStock(insumosAgregar);
            

            fabrica.AgregarProductoLineaProduccion(productoUno, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoDos, out faltantes);
            fabrica.AgregarProductoLineaProduccion(productoTres, out faltantes);

            return fabrica;
        }

    }

   
}
