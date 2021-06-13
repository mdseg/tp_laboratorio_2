﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entidades.Torre;

namespace VistaProyecto
{
    public partial class FormFabrica : Form
    {
        List<Insumo> insumosFaltantes;

        public FormFabrica()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Carga todos los controles del formulario con los datos de las entidades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFabrica_Load(object sender, EventArgs e)
        {
            rbTorre.Checked = true;
            cmbColorTela.DataSource = Enum.GetValues(typeof(EColor));
            cmbTipoTela.DataSource = Enum.GetValues(typeof(ETipoTela));
            cmbMaderaPrincipal.DataSource = Enum.GetValues(typeof(ETipoMadera));
            cmbMaderaColumna.DataSource = Enum.GetValues(typeof(ETipoMadera));
            cmbModeloTorre.DataSource = Enum.GetValues(typeof(EModeloTorre));
            cmbProcesoFabrica.DataSource = Enum.GetValues(typeof(EProceso));
            tabControlFabrica.SelectedTab = tabPageLineaProduccion;
            cambiarVisibilidadControlesFaltantes(false);
            ActualizarVistaLineaProduccion();
        }


        /// <summary>
        /// Activa y desactiva controles para el ingreso de un Producto del tipo Torre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbTorre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTorre.Checked)
            {
                gbTorre.Enabled = true;
                gbEstante.Enabled = false;
            }
        }
        /// <summary>
        /// Activa y desactiva controles para el ingreso de un Producto del tipo Estante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbEstante_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEstante.Checked)
            {
                gbTorre.Enabled = false;
                gbEstante.Enabled = true;
            }
        }

        /// <summary>
        /// Cambia a la pestaña de agregar producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBAgregarProducto_Click(object sender, EventArgs e)
        {
            tabControlFabrica.SelectedTab = tabPageAgregarProducto;
        }
        /// <summary>
        /// Verifica los campos cargados y envia a cargar un producto. En el caso de no poder por haber faltantes, activa los controles correspondientes
        /// al ingreso de los insumos faltantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            
            insumosFaltantes = new List<Insumo>();

            Producto bufferProducto = CargarCamposProducto();



            if (FormPrincipal.fabricaSingleton.AgregarProductoLineaProduccion(bufferProducto, out insumosFaltantes))
            {
                MessageBox.Show("Producto agregado a linea de Producción con éxito");
                cambiarVisibilidadControlesFaltantes(false);
                CambiarVisibilidadControlesProcesos(true);
                ActualizarVistaLineaProduccion();
            }
            else
            {

                MessageBox.Show("No se puede ingresar el producto, dado que hay faltantes");
                dgFaltantes.Rows.Clear();
                dgFaltantes.Columns.Clear();
                dgFaltantes.Columns.Add("tipoInsumo", "Tipo de Insumo");
                dgFaltantes.Columns.Add("caracteristicas", "Características");
                foreach (Insumo i in insumosFaltantes)
                {
                    string stringInsumo;
                    if(i is Madera)
                    {
                        stringInsumo = "Madera";
                    }
                    else if(i is Tela)
                    {
                        stringInsumo = "Tela";
                    }                   
                    else
                    {
                        stringInsumo = "Insumo Accesorio";
                    }
                    dgFaltantes.Rows.Add(stringInsumo, i.Mostrar());
                }
                cambiarVisibilidadControlesFaltantes(true);

            }
        }
        /// <summary>
        /// Crea el tipo de producto apropiado conforme a lo ingresado en el formulario
        /// </summary>
        /// <returns></returns>
        private Producto CargarCamposProducto()
        {

            Producto producto;

            ETipoMadera tipoMaderaPrincipal = (ETipoMadera)cmbMaderaPrincipal.SelectedItem;
            ETipoTela tipoTela = (ETipoTela)cmbTipoTela.SelectedItem;
            EColor colorTela = (EColor)cmbColorTela.SelectedItem;

            Madera maderaPrincipal;
            Tela telaProducto;

            if (rbTorre.Checked)
            {
                maderaPrincipal = new Madera(tipoMaderaPrincipal, EForma.Tablon, Fabrica.CANTIDAD_MADERA_TORRE_PRINCIPAL);
                telaProducto = new Tela(colorTela, tipoTela, Fabrica.CANTIDAD_TELA_TORRE);
                EModeloTorre modeloTorre = (EModeloTorre)cmbModeloTorre.SelectedItem;
                ETipoMadera tipoMaderaColumna = (ETipoMadera)cmbMaderaColumna.SelectedItem;

                Madera maderaColumna = new Madera(tipoMaderaColumna, EForma.Tubo, 1);

                if (chkYute.Checked)
                {
                    int metrosYute = (int)nudCantidadYute.Value;
                    producto = new Torre(maderaPrincipal, telaProducto, modeloTorre, maderaColumna, metrosYute);
                }
                else
                {
                    producto = new Torre(maderaPrincipal, telaProducto, modeloTorre, maderaColumna);
                }
            }
            else
            {
                maderaPrincipal = new Madera(tipoMaderaPrincipal, EForma.Tablon, Fabrica.CANTIDAD_MADERA_ESTANTE);
                telaProducto = new Tela(colorTela, tipoTela, Fabrica.CANTIDAD_TELA_ESTANTE);
                producto = new Estante(maderaPrincipal, telaProducto, (int)nudCantidadEstantes.Value);
            }
            return producto;
        }

        /// <summary>
        /// Activa o desactiva controles vinculados al ingreso de insumos faltantes
        /// </summary>
        /// <param name="visibilidad"></param>
        private void cambiarVisibilidadControlesFaltantes(bool visibilidad)
        {
            lblFaltantes.Visible = visibilidad;
            dgFaltantes.Visible = visibilidad;
            nudCantidadInsumos.Visible = visibilidad;
            lblPedido.Visible = visibilidad;
            btnSolicitarFaltantes.Visible = visibilidad;
        }

        /// <summary>
        /// Solicita los insumos faltantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSolicitarFaltantes_Click(object sender, EventArgs e)
        {
            int multiplicadorInsumos = (int)nudCantidadInsumos.Value;
            

            foreach(Insumo insumo in insumosFaltantes)
            {
                insumo.Cantidad *= multiplicadorInsumos;
            }

            FormPrincipal.fabricaSingleton.AgregarInsumosAStock(insumosFaltantes);

            insumosFaltantes.Clear();
            cambiarVisibilidadControlesFaltantes(false);
            MessageBox.Show("Pedido de insumos faltantes realizado correctamente", "Solicitar faltantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Carga los elementos de la linea de producción actualizando el datagrid dgLineaProduccionTodos
        /// </summary>
        private void ActualizarVistaLineaProduccion()
        {
            if (FormPrincipal.fabricaSingleton.LineaProduccion.Count > 0)
            {
                dgLineaProduccionTodos.Rows.Clear();
                dgLineaProduccionTodos.Columns.Clear();
                dgLineaProduccionTodos.Columns.Add("tipoProducto", "Tipo de Producto");
                dgLineaProduccionTodos.Columns.Add("modelo", "Modelo");
                dgLineaProduccionTodos.Columns.Add("maderaPrincipal", "Madera Principal");
                dgLineaProduccionTodos.Columns.Add("maderaSecundaria", "Madera Secundaria");
                dgLineaProduccionTodos.Columns.Add("tipoTela", "Material Tela");
                dgLineaProduccionTodos.Columns.Add("colorTela", "Color Tela");
                dgLineaProduccionTodos.Columns.Add("detalles", "Detalles");
                dgLineaProduccionTodos.Columns.Add("estado", "Estado");

                foreach (Producto p in FormPrincipal.fabricaSingleton.LineaProduccion)
                {
                    string tipoProducto;
                    string maderaPrincipal;
                    string maderaSecundaria;
                    string modelo;
                    string tipoTelaProducto;
                    string colorTelaProducto;
                    string estado;
                    string adicional;

                    maderaPrincipal = p.MaderaPrincipal.TipoMadera.ToString();
                    tipoTelaProducto = p.TelaProducto.TipoTela.ToString();
                    colorTelaProducto = p.TelaProducto.Color.ToString();
                    estado = p.EstadoProducto.ToString();

                    if (p is Torre)
                    {
                        maderaSecundaria = ((Torre)p).MaderaPrincipal.TipoMadera.ToString();
                        modelo = ((Torre)p).Modelo.ToString();
                        tipoProducto = "Torre";
                        if(((Torre)p).MetrosYute > 0)
                        {
                            adicional = $"Agregado de Yute: {((Torre)p).MetrosYute} metros";
                        }
                        else
                        {
                            adicional = "Sin adicionales";
                        }

                    }
                    else
                    {
                        modelo = "Unico";
                        tipoProducto = "Estante";
                        maderaSecundaria = "No aplica";
                        adicional = $"Cantidad: {((Estante)p).CantidadEstantes}";
                    }

                    dgLineaProduccionTodos.Rows.Add(tipoProducto, modelo, maderaPrincipal, maderaSecundaria, tipoTelaProducto,colorTelaProducto, adicional, estado);
                }
                CambiarVisibilidadControlesProcesos(true);
            }
            else
            {
                CambiarVisibilidadControlesProcesos(false);

            }
        }
        /// <summary>
        /// Cambia la visibilidad si hay o no productos en linea de produccion
        /// </summary>
        /// <param name="estado"></param>
        private void CambiarVisibilidadControlesProcesos(bool estado)
        {
            dgLineaProduccionTodos.Visible = estado;
            lblListaVacia.Visible = !estado;
            lblProcesoFabrica.Visible = estado;
            cmbProcesoFabrica.Visible = estado;
            btnEjecutarProceso.Visible = estado;
            btnDespacharProductos.Visible = estado;
        }
        /// <summary>
        /// Abre la pestaña de linea de producción
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IBLineaProduccion_Click(object sender, EventArgs e)
        {
            ActualizarVistaLineaProduccion();
            tabControlFabrica.SelectedTab = tabPageLineaProduccion;
        }
        /// <summary>
        /// Ejecuta el proceso de linea de producción e informa de la cantidad de productos modificados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEjecutarProceso_Click(object sender, EventArgs e)
        {
            EProceso proceso = (EProceso)cmbProcesoFabrica.SelectedItem;
            string mensaje = String.Empty;
            int productosModificados = FormPrincipal.fabricaSingleton.EjecutarProcesoLineaProduccion(proceso);
            if(productosModificados > 0)
            {
                switch (proceso)
                {
                    case EProceso.Lijar:
                        mensaje = $"Se han lijado {productosModificados} productos";
                        break;
                    case EProceso.Ensamblar:
                        mensaje = $"Se han completado {productosModificados} productos";
                        break;
                    case EProceso.Barnizar:
                        mensaje = $"Se han barnizado {productosModificados} productos";
                        break;
                    case EProceso.Alfombrar:
                        mensaje = $"Se han alfombrado {productosModificados} productos";
                        break;
                    case EProceso.AgregarYute:
                        mensaje = $"Se ha agregado yute a {productosModificados} torres";
                        break;
                }
            }
            else
            {
                mensaje = "No se ha modificado ningun producto";
            }
            ActualizarVistaLineaProduccion();
            MessageBox.Show(mensaje, "Realizar operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Solicita despacha los productos e informa de la cantidad de productos despachados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDespacharProductos_Click(object sender, EventArgs e)
        {
            int productosDespachados = FormPrincipal.fabricaSingleton.MudarProductosAStockTerminado();
            string mensaje;
            if(productosDespachados > 0)
            {
                mensaje = $"Se han despachado {productosDespachados} productos";
            }
            else
            {
                mensaje = $"No hay productos listos para despachar";
            }
            ActualizarVistaLineaProduccion();
            MessageBox.Show(mensaje, "Despachar productos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }

}
