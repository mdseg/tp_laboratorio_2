using Entidades.Exceptions;
using Files.Text;
using Files.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Logger
{   
    /// <summary>
    /// Clase utilizada para guardar en formato texto las distintas CustomException surgidas utilizando un objeto que implementa la interfaz ISaveOnlyFile
    /// </summary>
    public class Logger
    {
        private ISaveOnlyFile<string> serviceArchivoTexto;
        private string filePath;

        public Logger(string path)
        {
            this.serviceArchivoTexto = new TxtLogger();
            this.filePath = path;
        }
        /// <summary>
        /// Abre un archivo de texto y la añada la información de la CustomException
        /// </summary>
        /// <param name="e"></param>
        public void saveReport(CustomException e)
        {
            try
            {
                serviceArchivoTexto.Save(filePath, e.ToString());
            }
            catch(FileNotFoundException ex)
            {

            }
        }
    }
}
