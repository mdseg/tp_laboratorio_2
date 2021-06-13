using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Files.Xml
{
    /// <summary>
    /// Clase genérnica encargada de la serialización y desserialización de Xml
    /// Incluye conceptos de la clase 15 Excepciones, 17 Generics, 18 Interfaces y 19 Archivos 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IFile<T>
    {
        /// <summary>
        /// método encargado de leer un archivo Xml y desserializarlo al tipo de Dato T adoptado por el genérico
        /// </summary>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Read(string file, out T data)
        {
            bool output = false;
            try
            {
                XmlSerializer newXml = new XmlSerializer(typeof(T));
                using (XmlTextReader newTR = new XmlTextReader(file))
                {
                    data = (T)newXml.Deserialize(newTR);
                    output = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return output;
        }
        /// <summary>
        /// Método encargado de recibir un tipo de dato por parámetros y serializarlo en la ruta del archivo enviada en el parametro file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Save(string file, T data)
        {
            bool output = false;
            try
            {
                using (XmlTextWriter auxFile = new XmlTextWriter(file, Encoding.UTF8))
                {
                    XmlSerializer auxWritter = new XmlSerializer(typeof(T));
                    auxWritter.Serialize(auxFile, data);
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return output;
        }
    }
}
