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
    /// Clase encargada en implementar la interfaz ISaveFile para guardar string en un archivo de texto.
    /// Incluye conceptos de la clase 16 Generics, 17 Interfaces y 19 Archivos
    /// </summary>
    public class TxtLogger : IFile<string>
    {
        public bool Read(string file, out string data)
        {
            bool output = false;
            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    data = sr.ReadToEnd();
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            return output;
        }

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
