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

namespace VistaProyecto
{
    public partial class FormDetalles : Form
    {
        EProceso proceso;
        FormFabrica formPadre;
        Fabrica fabrica;
        public FormDetalles(FormFabrica formPadre,Fabrica fabrica,EProceso proceso)
        {
            this.fabrica = fabrica;
            this.formPadre = formPadre;
            this.proceso = proceso;
            InitializeComponent();
        }

        private void FormDetalles_Load(object sender, EventArgs e)
        {
            CargarControlesVista();
        }

        public void CargarControlesVista()
        {
            switch(proceso)
            {
                case EProceso.Lijar:
                    lblTitulo.Text = "Productos disponibles para Lijar";
                    btnEjecutarProceso.Text = "Lijar";
                    break;
                case EProceso.Barnizar:
                    lblTitulo.Text = "Productos disponibles para Barnizar";
                    btnEjecutarProceso.Text = "Barnizar";
                    break;
                case EProceso.Alfombrar:
                    lblTitulo.Text = "Productos disponibles para Alfombrar";
                    btnEjecutarProceso.Text = "Alfombrar";
                    break;
                case EProceso.AgregarYute:
                    lblTitulo.Text = "Productos disponibles para Agregar Adicionales";
                    btnEjecutarProceso.Text = "Agregar Yute";
                    break;
                case EProceso.Ensamblar:
                    lblTitulo.Text = "Productos disponibles para Ensamblar";
                    btnEjecutarProceso.Text = "Ensamblar";
                    break;
                case EProceso.Despachar:
                    lblTitulo.Text = "Productos disponibles para Despachar";
                    btnEjecutarProceso.Text = "Despachar";
                    break;
            }

            CargarListadoProductosDataGrid(proceso);
        }
        

        public void CargarListadoProductosDataGrid(EProceso proceso)
        {
            List<Producto> productos = new List<Producto>();
            fabrica.CalcularCantidadDeProductosAptosProceso(proceso,out productos);
            
           if (productos.Count > 0)
           {
               dgLineaProduccion.Rows.Clear();
               dgLineaProduccion.Columns.Clear();
               dgLineaProduccion.Columns.Add("tipoProducto", "Tipo de Producto");
               dgLineaProduccion.Columns.Add("modelo", "Modelo");
               dgLineaProduccion.Columns.Add("maderaPrincipal", "Madera Principal");
               dgLineaProduccion.Columns.Add("maderaSecundaria", "Madera Secundaria");
               dgLineaProduccion.Columns.Add("tipoTela", "Material Tela");
               dgLineaProduccion.Columns.Add("colorTela", "Color Tela");
               dgLineaProduccion.Columns.Add("detalles", "Detalles");
               dgLineaProduccion.Columns.Add("estado", "Estado");

               foreach (Producto p in productos)
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

                        dgLineaProduccion.Rows.Add(tipoProducto, modelo, maderaPrincipal, maderaSecundaria, tipoTelaProducto,colorTelaProducto, adicional, estado);
               }

           }
       
        }

        public void EjecutarProcesoLineaProduccion()
        {
            EjecutarProceso(proceso);
        }

        private void btnEjecutarProceso_Click(object sender, EventArgs e)
        {
            EjecutarProcesoLineaProduccion();
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
            if (productosModificados > 0)
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
                    case EProceso.Despachar:
                        mensaje = $"Se han despachado {productosModificados} productos";
                        break;
                }
            }
            else
            {
                mensaje = "No se ha modificado ningun producto";
            }
            MessageBox.Show(mensaje, "Realizar operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            formPadre.ActualizarVistaLineaProduccion();
            this.Close();
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formPadre.ActualizarVistaLineaProduccion();
            this.Close();

        }
    }
}
