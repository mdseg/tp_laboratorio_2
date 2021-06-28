using Entidades.Exceptions;
using Files;
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
    /// Clase utilizada para guardar en formato texto las distintas CustomException surgidas utilizando un objeto que implementa la interfaz IFile
    /// Incluye los conceptos de la clase 19 Archivos
    /// </summary>
    public class Logger
    {
        private IFile<string> serviceArchivoTexto;
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
        /// <summary>
        /// Abre un archivo de texto y devuelve su contenido como string
        /// </summary>
        /// <returns></returns>
        public string readReport()
        {
            string output = String.Empty;
            string contenidoReporte = String.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Bitacora de errores:");
                serviceArchivoTexto.Read(filePath, out contenidoReporte);
                sb.Append(contenidoReporte);
                output = sb.ToString();
                
            }
            catch(FileNotFoundException)
            {
                output = "Hubo problemas al abrir el archivo";
            }
            return output;
        }
    }
}
