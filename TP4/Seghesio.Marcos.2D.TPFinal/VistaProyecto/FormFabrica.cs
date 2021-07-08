using Entidades;
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
        private List<Insumo> insumosFaltantes;
        private Fabrica fabrica;
        private Form formDetalles;

        private Producto bufferProducto;




        private List<Proceso> controlPaneles;

        public FormFabrica(Fabrica fabrica)
        {
            this.fabrica = fabrica;
            controlPaneles = new List<Proceso>();
            
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
            CargarControlPaneles();
            ActualizarCantidadProductosAptos();
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

            CargarCamposProducto();



            if (fabrica.AgregarProductoLineaProduccion(bufferProducto, out insumosFaltantes))
            {
                MessageBox.Show("Producto agregado a linea de Producción con éxito", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cambiarVisibilidadControlesFaltantes(false);
                ActualizarVistaLineaProduccion();
            }
            else
            {
                MessageBox.Show("No se puede agregar producto debido a que hay faltantes", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void CargarCamposProducto()
        {

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
                    bufferProducto = new Torre(maderaPrincipal, telaProducto, modeloTorre, maderaColumna, metrosYute);
                }
                else
                {
                    bufferProducto = new Torre(maderaPrincipal, telaProducto, modeloTorre, maderaColumna);
                }
            }
            else
            {
                maderaPrincipal = new Madera(tipoMaderaPrincipal, EForma.Tablon, Fabrica.CANTIDAD_MADERA_ESTANTE);
                telaProducto = new Tela(colorTela, tipoTela, Fabrica.CANTIDAD_TELA_ESTANTE);
                bufferProducto = new Estante(maderaPrincipal, telaProducto, (int)nudCantidadEstantes.Value);
            }
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
            List<Insumo> listaFaltantes = new List<Insumo>();

            foreach(Insumo insumo in insumosFaltantes)
            {
                insumo.Cantidad *= multiplicadorInsumos;
            }

            fabrica.AgregarInsumosAStock(insumosFaltantes);

            insumosFaltantes.Clear();
            cambiarVisibilidadControlesFaltantes(false);
            DialogResult result = MessageBox.Show("Pedido de insumos faltantes realizado correctamente. ¿Desea dar de alta el producto ahora que hay insumos suficientes?", "Solicitar faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result == DialogResult.Yes)
            {
                fabrica.AgregarProductoLineaProduccion(bufferProducto,out listaFaltantes);
                MessageBox.Show("Producto agregado a linea de Producción con éxito", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Carga los elementos de la linea de producción actualizando el datagrid dgLineaProduccionTodos
        /// </summary>
        public void ActualizarVistaLineaProduccion()
        {
            ActualizarCantidadProductosAptos();           
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
        public void EjecutarProceso(EProceso proceso)
        {
            string mensaje = String.Empty;
            int productosModificados = fabrica.EjecutarProcesoLineaProduccion(proceso);
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
            int productosDespachados = fabrica.MudarProductosAStockTerminado();
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

        private void btnLijar_Click(object sender, EventArgs e)
        {
            EjecutarProceso(EProceso.Lijar);
        }

        private void btnBarnizar_Click(object sender, EventArgs e)
        {
            EjecutarProceso(EProceso.Barnizar);
        }

        private void btnAlfombrar_Click(object sender, EventArgs e)
        {
            EjecutarProceso(EProceso.Alfombrar);
        }

        private void btnAgregarAdicional_Click(object sender, EventArgs e)
        {
            EjecutarProceso(EProceso.AgregarYute);
        }
        private void btnProductosEnsamblar_Click(object sender, EventArgs e)
        {
            EjecutarProceso(EProceso.Ensamblar);
        }
        private void btnDespachar_Click(object sender, EventArgs e)
        {
            int productosDespachados = fabrica.MudarProductosAStockTerminado();
            string mensaje;
            if (productosDespachados > 0)
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

        private void ActualizarCantidadProductosAptos()
        {
            List<Producto> productos = new List<Producto>();
            foreach( Proceso proceso in controlPaneles)
            {
                proceso.ProductosAptos = fabrica.CalcularCantidadDeProductosAptosProceso(proceso.ProcesoAsociado, out productos);
                proceso.LabelAsociado.Text = $"Productos disponibles: {proceso.ProductosAptos}";
                proceso.CambiarEstadoPaneles();
            }
        }

        private void CargarControlPaneles()
        {
            List<Producto> productos = new List<Producto>();
            Proceso controlLijar = new Proceso(fabrica.CalcularCantidadDeProductosAptosProceso(EProceso.Lijar, out productos), EProceso.Lijar,iBLijarMaderas,btnLijar,btnMostarProductosLijar);
            Proceso controlBarnizar = new Proceso(fabrica.CalcularCantidadDeProductosAptosProceso(EProceso.Barnizar, out productos), EProceso.Barnizar,IBBarnizar,btnBarnizar,btnMostrarProductosBarnizar);
            Proceso controlAlfombrar = new Proceso(fabrica.CalcularCantidadDeProductosAptosProceso(EProceso.Alfombrar, out productos), EProceso.Alfombrar,IBAlfombrar,btnAlfombrar,btnMostrarProductosAlfombrar);
            Proceso controlAgregarAdicional = new Proceso(fabrica.CalcularCantidadDeProductosAptosProceso(EProceso.AgregarYute, out productos), EProceso.AgregarYute, IBAgregarAdicional,btnAgregarAdicional,btnMostrarProductosAgregarAdicionales);
            Proceso controlEnsamblar = new Proceso(fabrica.CalcularCantidadDeProductosAptosProceso(EProceso.Ensamblar, out productos), EProceso.Ensamblar,IBEnsamblar, btnEnsamblar,btnMostrarProductosEnsamblar);
            Proceso controlDespachar = new Proceso(fabrica.CalcularCantidadDeProductosAptosProceso(EProceso.Despachar, out productos), EProceso.Despachar, IBCompleto,btnDespachar,btnMostrarProductosCompletos);

            controlPaneles.Add(controlLijar);
            controlPaneles.Add(controlBarnizar);
            controlPaneles.Add(controlAlfombrar);
            controlPaneles.Add(controlAgregarAdicional);
            controlPaneles.Add(controlEnsamblar);
            controlPaneles.Add(controlDespachar);



        }

        private void btnMostarProductosLijar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDetalles(this,fabrica,EProceso.Lijar));
        }

        /// <summary>
        /// Método encargado de gestionar los formularios hijos y anexarlos dentro del FormPrincipal
        /// </summary>
        /// <param name="childForm"></param>
        private void OpenChildForm(Form childForm)
        {
            if (this.formDetalles != null)
            {
                formDetalles.Close();
            }
            
            formDetalles = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void btnMostrarProductosBarnizar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDetalles(this,fabrica, EProceso.Barnizar));
        }

        private void btnMostrarProductosAlfombrar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDetalles(this, fabrica, EProceso.Alfombrar));
        }

        private void btnMostrarProductosAgregarAdicionales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDetalles(this, fabrica, EProceso.AgregarYute));
        }


        private void btnMostrarProductosEnsamblar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDetalles(this, fabrica, EProceso.Ensamblar));
        }

        private void btnMostrarProductosCompletos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDetalles(this, fabrica, EProceso.Despachar));
        }

        private void Actualizar(object sender, EventArgs e)
        {
            ActualizarVistaLineaProduccion();
        }


    }

}
