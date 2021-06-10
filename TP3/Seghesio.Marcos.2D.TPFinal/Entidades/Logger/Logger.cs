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
    public class Logger
    {
        private ISaveOnlyFile<string> serviceArchivoTexto;
        private string filePath;

        public Logger(string path)
        {
            this.serviceArchivoTexto = new TxtLogger();
            this.filePath = path;
        }

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
