using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace VistaProyecto
{
    /// <summary>
    /// Clase diseñada para simplificar la habilitación y deshabilitación de la vista del formulario en la linea de produccion, todos los campos de
    /// un proceso incluye un panel con boton de ver detalles y un IconButon utilizado en este caso como un label que muestra la cantidad de productos
    /// aptos para un proceso
    /// </summary>
    public class Proceso
    {
        private int productosAptos;
        private EProceso procesoAsociado;
        private IconButton labelAsociado;
        private Button btnDetalles;

        public int ProductosAptos
        {
            get
            {
                return this.productosAptos;
            }
            set
            {
                this.productosAptos = value;
            }
        }

        public EProceso ProcesoAsociado
        {
            get
            {
                return this.procesoAsociado;
            }
            set
            {
                this.procesoAsociado = value;
            }
        }
        public IconButton LabelAsociado
        {
            get
            {
                return this.labelAsociado;
            }
        }

        

        public Button BtnDetalles
        {
            get
            {
                return this.btnDetalles;
            }
        }

        /// <summary>
        /// Unico constructor de esta clase
        /// </summary>
        /// <param name="productosAptos"></param>
        /// <param name="procesoAsociado"></param>
        /// <param name="labelAsociado"></param>
        /// <param name="btnDetalles"></param>
        public Proceso(int productosAptos,EProceso procesoAsociado, IconButton labelAsociado, Button btnDetalles)
        {
            this.productosAptos = productosAptos;
            this.procesoAsociado = procesoAsociado;
            this.labelAsociado = labelAsociado;
            this.btnDetalles = btnDetalles;
        }
        /// <summary>
        /// Metodo encargado de deshabilitar o habilitar los controles segun haya o no productos aptos
        /// </summary>
        public void CambiarEstadoPaneles()
        {
            if(this.productosAptos > 0)
            {
                btnDetalles.Enabled = true;
                labelAsociado.Enabled = true;
            }
            else
            {
                btnDetalles.Enabled = false;
                labelAsociado.Enabled = false;
            }
        }


    }


}
