using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades.Services
{
    public class HiloService
    {
        Thread hilo;
        Fabrica fabrica;



        public void IniciarProceso(EProceso proceso)
        {
            if (!(this.hilo is null) && this.hilo.IsAlive)
            {
                throw new Exception("Existe un proceso en ejecución");
            }
            else
            {
                this.hilo = new Thread(new ParameterizedThreadStart(fabrica.EjecutarProcesoLineaProduccion);
                this.hilo.Start(proceso);
            }
        }

        public void CerrarApp()
        {
            if (!(this.hilo is null) && this.hilo.IsAlive)
            {
                this.hilo.Abort();
            }
        }
    }
}
