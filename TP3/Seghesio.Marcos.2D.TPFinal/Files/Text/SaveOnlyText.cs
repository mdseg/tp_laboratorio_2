using Files.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Text
{
    /// <summary>
    /// Clase encargada en implementar la interfaz ISaveOnlyFile para guardar string en un archivo de texto.
    /// </summary>
    public class TxtLogger : ISaveOnlyFile<string>
    {
        /// <summary>
        /// Recibe la ubicación de un archivo, y un string para guardarlos en el mismo añadiendole la información nueva a la existente
        /// </summary>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Save(string file, string data)
        {
            bool output = false;
            
            try
            {
                using (StreamWriter sw = new StreamWriter(file, true))
                {
                    sw.WriteLine(data.ToString());
                    sw.Close();
                    output = true;
                }
            }
            catch(Exception e)
            {
                throw new DirectoryNotFoundException();
            }
            

            
            return output;
        }
    }
}
