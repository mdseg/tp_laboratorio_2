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


        public Proceso(int productosAptos,EProceso procesoAsociado, IconButton labelAsociado, Button btnDetalles)
        {
            this.productosAptos = productosAptos;
            this.procesoAsociado = procesoAsociado;
            this.labelAsociado = labelAsociado;
            this.btnDetalles = btnDetalles;
        }

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
